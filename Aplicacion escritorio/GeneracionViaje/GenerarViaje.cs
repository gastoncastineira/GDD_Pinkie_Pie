using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Conexiones;
using FrbaCrucero.model;

namespace FrbaCrucero.GeneracionViaje
{
    public partial class GenerarViaje : FormTemplate
    {
        private Viaje ViajeAGenerar;
        private Conexion conexion = new Conexion();

        public GenerarViaje():base()
        {
            InitializeComponent();
            ViajeAGenerar = new Viaje();
        }

        private void BtnConsultarCruceros_Click(object sender, EventArgs e)
        {
            try
            {
                Cruceros VenCru = new Cruceros();
                VenCru.ShowDialog();

                if (VenCru.DialogResult == DialogResult.OK)
                {
                    txtCrucero.Text = VenCru.dataGridCruceros.Rows[VenCru.dataGridCruceros.CurrentRow.Index].Cells[0].Value.ToString();
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error: " + error.Message, "Error");
            }
        }

        private void BtnConsultarRecorridos_Click(object sender, EventArgs e)
        {
            try
            {
                Recorridos VenRe = new Recorridos();
                VenRe.ShowDialog();

                if (VenRe.DialogResult == DialogResult.OK)
                {
                    txtRecorrido.Text = VenRe.dataGridRecorridos.Rows[VenRe.dataGridRecorridos.CurrentRow.Index].Cells[0].Value.ToString();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message, "Error");
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e) 
        {
            String mensaje = ValidarCampos();
            if (mensaje == "")
            {
                ViajeAGenerar.Recorrido_id = Convert.ToInt16(txtRecorrido.Text);

                ViajeAGenerar.PasajesVendidos = 0;

                // Agrego cabinas vacias al Viaje que se va a generar
                List<Filtro> filtros = new List<Filtro>();
                filtros.Add(FiltroFactory.Exacto("id_crucero", txtCrucero.Text.ToString()));

                List<string> camposPiso = new List<string>();
                camposPiso.Add("Nro_piso");
                camposPiso.Add("cant_cabina");
                camposPiso.Add("id_crucero");
                camposPiso.Add("id_tipo");

                Dictionary<string, List<object>> pisos = conexion.ConsultaPlana(Tabla.Piso, camposPiso, filtros);

                List<Cabina> cabinasVacias = new List<Cabina>();

                for (int i = 0; i < pisos["Nro_piso"].Count; i++)
                {
                    for (int j = 0; j < Convert.ToInt32(pisos["cant_cabina"][i]); j++)
                    {
                        Cabina cabina = new Cabina();
                        cabina.Crucero_id = Convert.ToInt32(txtCrucero.Text);
                        cabina.Tipo_id = Convert.ToInt32(pisos["id_tipo"][i]);
                        cabina.NumeroPiso = Convert.ToInt32(pisos["Nro_piso"][i]);
                        cabina.NumeroHabitacion = GetNroHabitacion(Convert.ToInt32(pisos["Nro_piso"][i]), cabinasVacias);

                        cabinasVacias.Add(cabina);
                    }
                }

                ViajeAGenerar.Cabinas = cabinasVacias;

                InsertarViaje();

                MessageBox.Show("Se ha guardado correctamente!", "Generar viaje");

                txtCrucero.Text = string.Empty;
                txtRecorrido.Text = string.Empty;
                dtFechaFin.Value = ConfigurationHelper.FechaActual;
                dtFechaInicio.Value = ConfigurationHelper.FechaActual;
                dtHoraFin.Value = ConfigurationHelper.FechaActual;
                dtHoraInicio.Value = ConfigurationHelper.FechaActual;
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        int GetNroHabitacion(int numeroPiso, List<Cabina> cabinasInsertadasHastaElMomento)
        {
            List<Cabina> cabinasConMismoNumeroDePiso = cabinasInsertadasHastaElMomento.Where(c => c.NumeroPiso == numeroPiso).ToList();

            return cabinasConMismoNumeroDePiso.Count();
        }

        private void InsertarViaje()
        {
            Dictionary<string, object> datosViaje = new Dictionary<string, object>();
            datosViaje["fecha_inicio"] = ViajeAGenerar.FechaInicio;
            datosViaje["fecha_fin_estimada"] = ViajeAGenerar.Fecha_Fin_Estimada;
            datosViaje["pasajes_vendidos"] = ViajeAGenerar.PasajesVendidos;
            datosViaje["recorrido_id"] = ViajeAGenerar.Recorrido_id;

            Transaccion tr = conexion.IniciarTransaccion();

            int idViajeInsertado = tr.Insertar(Tabla.Viaje, datosViaje);

            ViajeAGenerar.Id = idViajeInsertado;

            foreach (Cabina cabina in ViajeAGenerar.Cabinas)
            {
                Dictionary<string, object> datosCabina = new Dictionary<string, object>();

                datosCabina["crucero_id"] = cabina.Crucero_id;
                datosCabina["viaje_id"] = idViajeInsertado;
                datosCabina["tipo_id"] = cabina.Tipo_id;
                datosCabina["numero_piso"] = cabina.NumeroPiso;
                datosCabina["numero_habitacion"] = cabina.NumeroHabitacion;
                datosCabina["ocupado"] = 0;

                int idCabinaInsertada = tr.Insertar(Tabla.Cabina, datosCabina);
            }

            tr.Commit();
        }

        // VALIDACIONES
        private String ValidarCampos()
        {
            String resultado = "";

            resultado += this.ValidarCamposVacios();

            // FECHA
            resultado += this.ValidarFechas();

            //CRUCERO 
            resultado += this.ValidarExisteCrucero(resultado);
            resultado += this.ValidarEsteDisponibleCrucero(resultado);

            // RECORRIDO 
            resultado += this.ValidarExisteRecorrido(resultado);

            return resultado;
        }

        private String ValidarCamposVacios()
        {
            if (string.IsNullOrEmpty(txtCrucero.Text) || string.IsNullOrEmpty(txtRecorrido.Text))
            {
                return "Se detecto un campo vacio. Revise. \n";
            }

            return "";
        }

        private String ValidarFechas()
        {

            DateTime fechaInicio = dtFechaInicio.Value.Date.AddHours(Convert.ToInt16(dtHoraInicio.Value.Hour)).AddMinutes(dtHoraInicio.Value.Minute).AddSeconds(dtHoraInicio.Value.Second);
            DateTime fechaFinalizacion = dtFechaFin.Value.Date.AddHours(Convert.ToInt16(dtHoraFin.Value.Hour)).AddMinutes(dtHoraFin.Value.Minute).AddSeconds(dtHoraFin.Value.Second);

            if (fechaFinalizacion > fechaInicio)
            {
                ViajeAGenerar.FechaInicio = fechaInicio;
                ViajeAGenerar.Fecha_Fin_Estimada = fechaFinalizacion;

                return "";
            }

            return "La fecha de finalizacion debe ser posterior a la fecha de inicio.\n";
        }

        public String ValidarExisteCrucero(string resultado)
        {
            if (resultado == "")
            {
                List<Filtro> filtros = new List<Filtro>();
                filtros.Add(FiltroFactory.Exacto("ID", txtCrucero.Text.ToString()));

                if (conexion.ExisteRegistro(Tabla.Crucero, new List<string>(new string[] { "ID" }), filtros))
                    return "";

                return "El id del crucero ingresado no existe.\n";
            }

            return "";
        }

        private String ValidarEsteDisponibleCrucero(string resultado)
        {
            if (resultado == "")
            {
                // EL CRUCERO ESTA DE BAJA DEFINITIVA
                List<Filtro> filtros = new List<Filtro>();
                filtros.Add(FiltroFactory.Exacto("ID", txtCrucero.Text.ToString()));
                List<string> columnasFechaBajaDefinitiva = new List<string>();
                columnasFechaBajaDefinitiva.Add("fecha_baja_definitiva");

                Dictionary<string, List<object>> fechaBajaDefinitiva = conexion.ConsultaPlana(Tabla.Crucero, columnasFechaBajaDefinitiva, filtros);

                if (!Convert.IsDBNull(fechaBajaDefinitiva["fecha_baja_definitiva"].First()))
                {
                    if (Convert.ToDateTime(fechaBajaDefinitiva["fecha_baja_definitiva"].First()) < ViajeAGenerar.Fecha_Fin_Estimada)
                        return "El crucero está de baja de forma definitiva en el rango de fechas que eligió.\n";
                }


                // EL CRUCERO NO EMPEZO A INICIAR SU SERVICIO
                List<string> columnasFechaDeInicioServicio = new List<string>();
                columnasFechaDeInicioServicio.Add("fecha_de_alta");

                Dictionary<string, List<object>> fechaDeInicioServicio = conexion.ConsultaPlana(Tabla.Crucero, columnasFechaDeInicioServicio, filtros);

                if (!Convert.IsDBNull(fechaDeInicioServicio["fecha_de_alta"].First()))
                {
                    if (Convert.ToDateTime(fechaDeInicioServicio["fecha_de_alta"].First()) > ViajeAGenerar.FechaInicio)
                        return "El crucero no empezó a iniciar su servicio en rango de fechas que eligió.\n";
                }


                // EL CRUCERO ESTA DE BAJA EN RANGO DE FECHAS
                List<Filtro> filtrosFechasBajas = new List<Filtro>();
                filtrosFechasBajas.Add(FiltroFactory.Exacto("id_Crucero", txtCrucero.Text.ToString()));

                List<string> campos = new List<string>();
                campos.Add("fecha_reinicio_servicio");
                campos.Add("fecha_fuera_de_servicio");

                Dictionary<string, List<object>> fechasFueraServicio = conexion.ConsultaPlana(Tabla.Fuera_Servicio, campos, filtrosFechasBajas);

                if (fechasFueraServicio[campos[0]].Count > 0 || fechasFueraServicio[campos[1]].Count > 0)
                {
                    if (!(Convert.IsDBNull(fechasFueraServicio["fecha_reinicio_servicio"].First()) || Convert.IsDBNull(fechasFueraServicio["fecha_fuera_de_servicio"].First())))
                    {
                        for (int i = 0; i < fechasFueraServicio["fecha_reinicio_servicio"].Count(); i++)
                        {
                            if (!(
                                (Convert.ToDateTime(fechasFueraServicio["fecha_reinicio_servicio"][i]) <= ViajeAGenerar.FechaInicio
                                && Convert.ToDateTime(fechasFueraServicio["fecha_fuera_de_servicio"][i]) < ViajeAGenerar.FechaInicio)
                                ||
                                (Convert.ToDateTime(fechasFueraServicio["fecha_fuera_de_servicio"][i]) > ViajeAGenerar.Fecha_Fin_Estimada
                                && Convert.ToDateTime(fechasFueraServicio["fecha_reinicio_servicio"][i]) > ViajeAGenerar.Fecha_Fin_Estimada)))
                                return "El crucero está de baja en el rango de fechas que eligió.\n";
                        }
                    }
                }


                // ESTA EL CRUCERO OCUPADO EN OTRO VIAJE EN LAS FECHAS ELEGIDAS
                List<Filtro> filtrosCruceroEnViaje = new List<Filtro>();
                filtrosCruceroEnViaje.Add(FiltroFactory.Exacto("crucero_id", txtCrucero.Text.ToString()));

                List<string> camposViajes = new List<string>();
                camposViajes.Add("id_viaje");
                camposViajes.Add("fecha_inicio");
                camposViajes.Add("fecha_fin_estimada");

                Dictionary<string, List<object>> viajesConCrucero = conexion.ConsultaPlana(Tabla.ViajesConCrucero, camposViajes, filtrosCruceroEnViaje);

                int cantidadDeViajesConCrucero = viajesConCrucero["id_viaje"].Count();
                for (int i = 0; i < cantidadDeViajesConCrucero; i++)
                {
                    if (!((Convert.ToDateTime(viajesConCrucero["fecha_inicio"][i]) <= ViajeAGenerar.FechaInicio
                        && Convert.ToDateTime(viajesConCrucero["fecha_fin_estimada"][i]) <= ViajeAGenerar.FechaInicio)
                        || (Convert.ToDateTime(viajesConCrucero["fecha_inicio"][i]) >= ViajeAGenerar.Fecha_Fin_Estimada
                        && Convert.ToDateTime(viajesConCrucero["fecha_fin_estimada"][i]) >= ViajeAGenerar.Fecha_Fin_Estimada)))
                    {
                        return "El crucero está ocupado en otro viaje en el rango de fechas que eligió.\n";
                    }
                }

                // EL CRUCERO ESTA DISPONIBLE
                return "";
            }
            return "";
        }

        public String ValidarExisteRecorrido(string resultado)
        {
            if (resultado == "")
            {
                List<Filtro> filtros = new List<Filtro>();
                filtros.Add(FiltroFactory.Exacto("ID", txtRecorrido.Text.ToString()));

                if (conexion.ExisteRegistro(Tabla.Recorrido, new List<string>(new string[] { "ID" }), filtros))
                    return "";

                return "El id del recorrido ingresado no existe.\n";
            }

            return "";
        }

        private void GenerarViaje_Load(object sender, EventArgs e)
        {
            dtFechaFin.MinDate = ConfigurationHelper.FechaActual;
            dtFechaInicio.MinDate = ConfigurationHelper.FechaActual;
        }
    }
}


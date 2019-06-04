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
    public partial class GenerarViaje : Form
    {
        private Viaje ViajeAGenerar;
        private Conexion conexion = new Conexion();

        public GenerarViaje()
        {
            InitializeComponent();
            ViajeAGenerar = new Viaje();
        }

        private void GenerarViaje_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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

        private void BtnGuardar_Click(object sender, EventArgs e) //ver video 39, ver poner un try catch
        {
            String mensaje = ValidarCampos();
            if (mensaje == "")
            {
                ViajeAGenerar.Recorrido_id = Convert.ToInt16(txtRecorrido.Text);
                
                ViajeAGenerar.PasajesVendidos = 0;

                // Agrego cabinas vacias al Viaje que se va a generar
                List<Filtro> filtros = new List<Filtro>();
                filtros.Add(FiltroFactory.Exacto("id_crucero", txtCrucero.Text.ToString()));

                Dictionary<string, List<object>> cantCabinas = conexion.ConsultaPlana(Tabla.Piso, new List<string>(new string[] { "isnull(SUM(cant_cabina), 0) AS cantidadCabinas" }), filtros);

                List<string> camposCabinas = new List<string>();
                camposCabinas.Add("tipo_id");
                camposCabinas.Add("numero_piso");
                camposCabinas.Add("numero_habitacion");

                Dictionary<string, List<object>> cabinas = conexion.ConsultaPlana(Tabla.Cabina, camposCabinas, new List<Filtro>(new Filtro[] { FiltroFactory.Exacto("crucero_id", txtCrucero.Text.ToString()) })); 

                List<Cabina> cabinasVacias = new List<Cabina>();

                 for (int i = 0; i < Convert.ToInt16(cantCabinas["cantidadCabinas"].First()); i++)
                 {
                     Cabina cabina = new Cabina(Convert.ToInt16(txtCrucero.Text), Convert.ToInt16(cabinas["tipo_id"][i]), Convert.ToInt16(cabinas["numero_piso"][i]), Convert.ToInt16(cabinas["numero_habitacion"][i]), false);

                     cabinasVacias.Add(cabina);
                 }

                 ViajeAGenerar.Cabinas = cabinasVacias;

                 InsertarViaje();

                 MessageBox.Show("Se ha guardado correctamente!", "Generar viaje");
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertarViaje()
        {
            Dictionary<string, object> datosViaje = new Dictionary<string, object>();
            datosViaje["fecha_inicio"] = ViajeAGenerar.FechaInicio;
            datosViaje["fecha_fin"] = null;
            datosViaje["fecha_fin_estimada"] = ViajeAGenerar.FechaFinalizacion;
            datosViaje["pasajes_vendidos"] = ViajeAGenerar.PasajesVendidos;
            datosViaje["recorrido_id"] = ViajeAGenerar.Recorrido_id;

            Transaccion tr = conexion.IniciarTransaccion();

            int idViajeInsertado = tr.Insertar(Tabla.Rol, datosViaje);

            ViajeAGenerar.Id = idViajeInsertado;
       
            foreach (Cabina cabina in ViajeAGenerar.Cabinas)
            {
                Dictionary<string, object> datosCabina = new Dictionary<string, object>();

                datosCabina["crucero_id"] = cabina.Crucero_id;
                datosCabina["viaje_id"] = idViajeInsertado;
                datosCabina["tipo_id"] = cabina.Tipo_id;
                datosCabina["numero_piso"] = cabina.NumeroPiso;
                datosCabina["numero_habitacion"] = cabina.NumeroHabitacion;
                datosCabina["ocupado"] = cabina.Ocupado;

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
                ViajeAGenerar.FechaFinalizacion = fechaFinalizacion;

                return "";
            }

            return "La fecha de finalizacion debe ser posterior a la fecha de inicio.\n";
        }

        public String ValidarExisteCrucero(string resultado) //TODO probarlo, tal vez se puede hacer una funcion ValidarExiste(le llega Crucero o Recorrido, "mesaje de error") 
        {
            if (resultado == "")
            {
                List<Filtro> filtros = new List<Filtro>();
                filtros.Add(FiltroFactory.Exacto("ID", txtCrucero.Text.ToString()));

                Dictionary<string, List<object>> crucero = conexion.ConsultaPlana(Tabla.Crucero, new List<string>(new string[] { "ID" }), filtros);

                if (crucero["ID"].First() != null)
                    return "";

                return "El id del crucero ingresado no existe.\n";
            }

            return "";
        }

        // ME QUEDE ACA, TODO PROBAR QUE ANDE
        private String ValidarEsteDisponibleCrucero(string resultado)
        {
            if (resultado == "")
            {
                List<Filtro> filtros = new List<Filtro>();
                filtros.Add(FiltroFactory.Exacto("ID", txtCrucero.Text.ToString()));

                Dictionary<string, List<object>> fechaBajaDefinitiva = conexion.ConsultaPlana(Tabla.Crucero, new List<string>(new string[] { "fecha_baja_definitiva" }), filtros);

                List<Filtro> filtrosFechasBajas = new List<Filtro>();
                filtros.Add(FiltroFactory.Exacto("id_Crucero", txtCrucero.Text.ToString()));

                List<string> campos = new List<string>();
                campos.Add("fecha_reinicio_servicio");
                campos.Add("fecha_fuera_de_servicio");
                

                Dictionary<string, List<object>> fechasFueraServicio = conexion.ConsultaPlana(Tabla.Fuera_Servicio, campos, filtros);

                for (int i = 0; i < fechasFueraServicio["fecha_reinicio_servicio"].Count(); i++)
                {
                    if (!(Convert.ToDateTime(fechasFueraServicio["fecha_reinicio_servicio"][i]) <= ViajeAGenerar.FechaInicio
                        || Convert.ToDateTime(fechasFueraServicio["fecha_fuera_de_servicio"][i]) > ViajeAGenerar.FechaFinalizacion))
                        return "El crucero está de baja en el rango de fechas que eligió.\n";
                }

                if (Convert.ToDateTime(fechaBajaDefinitiva["fecha_baja_definitiva"].First()) > ViajeAGenerar.FechaFinalizacion)
                {
                    Dictionary<string, List<object>> fechaReinicioServicio = conexion.ConsultaPlana(Tabla.Crucero, new List<string>(new string[] { "fecha_de_alta" }), filtros);

                    if (Convert.ToDateTime(fechaReinicioServicio["fecha_de_alta"].First()) < ViajeAGenerar.FechaInicio)
                    {
                        return "No se si esta disponible";
                        /* // TODO VIEW
                     List<Viaje> viajesConEseCruceroOcupado =
                         SELECT ID 
                         FROM Viaje v 
                         JOIN Cabina ca 
                            ON ca.crucero_id = Convert.ToInt16(txtCrucero)
                         WHERE ( !(ViajeAGenerar.FechaInicio > v.FechaFinalizacion || ViajeAGenerar.FechaFinalizacion < v.FechaInicio ))
                     )
                     
                    if (viajesConEseCruceroOcupado.IsNull())
                            return "";
                        else
                            return "El crucero está ocupado en otro viaje en el rango de fechas que eligió.\n"
                     */
                    }

                    return "El crucero está fuera de servicio en rango de fechas que eligió.\n";
                }

                return "El crucero está de baja de forma definitiva en el rango de fechas que eligió.\n";
            }

            return "";
        }



        public String ValidarExisteRecorrido(string resultado)
        {
            if (resultado == "")
            {
                List<Filtro> filtros = new List<Filtro>();
                filtros.Add(FiltroFactory.Exacto("ID", txtRecorrido.Text.ToString()));

                Dictionary<string, List<object>> recorrido = conexion.ConsultaPlana(Tabla.Recorrido, new List<string>(new string[] { "ID" }), filtros);

                if (recorrido["ID"].First() != null)
                    return "";

                return "El id del recorrido ingresado no existe.\n";
            }

            return "";
        }

        
    }
}


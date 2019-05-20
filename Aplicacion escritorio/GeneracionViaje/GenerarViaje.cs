using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FrbaCrucero.model;

namespace FrbaCrucero.GeneracionViaje
{
    public partial class GenerarViaje : Form
    {
        private Viaje ViajeAGenerar;
        DateTime FechaInicio;
        DateTime FechaFinalizacion;

        public GenerarViaje()
        {
            InitializeComponent();
            ViajeAGenerar = new Viaje();
        }

        
        // a la hora de hacer la validacion esperar para ver si los chicos suben del año pasado algo que valide y si no mirar video 40
        
            // TODO viaje_id

        private void GenerarViaje_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void BtnConsultarCruceros_Click(object sender, EventArgs e) //TODO ver video 44
        {
            try
            {
                Cruceros VenCru = new Cruceros();
                VenCru.ShowDialog();

                if (VenCru.DialogResult == DialogResult.OK)
                {
                    txtCrucero.Text = VenCru.dataGridCruceros.Rows[VenCru.dataGridCruceros.CurrentRow.Index].Cells[0].Value.ToString(); //sacado de video 47
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
                ViajeAGenerar.FechaInicio = dtFechaInicio.Value.Date.AddHours(Convert.ToInt16(dtHoraInicio.Value.Hour)).AddMinutes(dtHoraInicio.Value.Minute).AddSeconds(dtHoraInicio.Value.Second);
                ViajeAGenerar.FechaFinalizacion = dtFechaFin.Value.Date.AddHours(Convert.ToInt16(dtHoraFin.Value.Hour)).AddMinutes(dtHoraFin.Value.Minute).AddSeconds(dtHoraFin.Value.Second);
                ViajeAGenerar.Recorrido_id = Convert.ToInt16(txtRecorrido);
                ViajeAGenerar.PasajesVendidos = 0;

                List<Cabina> cabinasVacias = new List<Cabina>();
                int cantidadCabinas = 0;
                /*cantidadCabinas = 
                SELECT cantidadDePasajes 
                FROM Crucero c
                WHERE c.Id = Convert.ToInt16(txtCrucero)
                 */

                for (int i = 0; i < cantidadCabinas; i++)
                {
                    cabinasVacias.Add(new Cabina(i, Convert.ToInt16(txtCrucero), ViajeAGenerar.Id, false));
                }

                MessageBox.Show("Se ha guardado correctamente!", "Generar viaje");
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // VALIDACIONES
        private String ValidarCampos()
        {
            // TODO ver validar que no este vacio cuando casti haya subido la validacion
            String resultado = "";

            // FECHA
            resultado += this.ValidarFechas();

            //CRUCERO 
            //validar que no este vacio
            resultado += this.ValidarExisteCrucero();
            resultado += this.ValidarEsteDisponibleCrucero();

            // RECORRIDO 
            // validar que no este vacio
            resultado += this.ValidarExisteRecorrido();
           
            return resultado;
        }

        private String ValidarFechas() {
            
            FechaInicio = dtFechaInicio.Value.Date.AddHours(Convert.ToInt16(dtHoraInicio.Value.Hour)).AddMinutes(dtHoraInicio.Value.Minute).AddSeconds(dtHoraInicio.Value.Second);
            FechaFinalizacion = dtFechaFin.Value.Date.AddHours(Convert.ToInt16(dtHoraFin.Value.Hour)).AddMinutes(dtHoraFin.Value.Minute).AddSeconds(dtHoraFin.Value.Second);

            if (FechaFinalizacion > FechaInicio)
            {
                ViajeAGenerar.FechaInicio = FechaInicio;
                ViajeAGenerar.FechaFinalizacion = FechaFinalizacion;

                return "";
            }
            else
                return "La fecha de finalizacion debe ser posterior a la fecha de inicio.\n";
        }

        private String ValidarEsteDisponibleCrucero() { // fijarse si hay que poner try catchs
            String resultado = ""; //lo dejo para que no me rompa, pero desp borrar

            /*

            DateTime fechaBajaDefinitivaCrucero = SELECT fechaBajaDefinitiva FROM Crucero  // no se si se puede hacer esto pero es la idea
            
            if(fechaBajaDefinitiva == NULL || fechaBajaDefinitiva > FechaFinalizacion)
            {
                DateTime fechaReinicioServicioCrucero = SELECT fechaReinicioServicio FROM Crucero

                if(fechaReinicioServicioCrucero < FechaInicio)
                {
                    List<Viaje> viajesConEseCruceroOcupado =
                     SELECT Id 
                     FROM Viaje v 
                     JOIN Crucero c
                        ON c.Id == Convert.ToInt16(txtCrucero)
                     WHERE (v.Id != ViajeAGenerar.Id 
                            && !(FechaInicio > v.FechaFinalizacion || FechaFinalizacion < v.FechaInicio ))
             
                    // ver si lo del WHERE tiene que ir ahi hoy hay que hacer una funcion o algo así, porque dentro estoy "haciendo" la funcion EstaDisponible()

                    if (viajesConEseCruceroOcupado.IsNull())
                        return "";
                    else
                        return "El crucero está ocupado en otro viaje en el rango de fechas que eligió.\n"
                }
                else
                    return "El crucero está fuera de servicio en rango de fechas que eligió.\n"
                
            }
            else
                return "El crucero está de baja de forma definitiva en el rango de fechas que eligió.\n"
            
             */


            return resultado;
        }

        public String ValidarExisteCrucero() //TODO probarlo, tal vez se puede hacer una funcion ValidarExiste(le llega Crucero o Recorrido, "mesaje de error") 
        {
            try
            {
                /* // tal vez exite una forma tipo exists y en vez de tener var crucero tener var existe, ver despues sise una triy catch o hacer un if(existe) return "" else "El..0"
                 int crucero = 
                 SELECT crucero_id 
                 FROM Crucero c
                 WHERE c.crucero_id = Convert.ToInt16(txtCrucero)
                 */
                return "";
            }
            catch (Exception error)
            {
                return "El id del crucero ingresado no existe.\n";
            }
        }

        public String ValidarExisteRecorrido() //TODO probarlo, tal vez se puede hacer una funcion ValidarExiste(le llega Crucero o Recorrido)
        {
            try
            {
                /* // tal vez exite una forma tipo exists y en vez de tener var crucero tener var existe, ver despues sise una triy catch o hacer un if(existe) return "" else "El..0"
                 int recorrido = 
                 SELECT recorrido_id 
                 FROM Recorrido r
                 WHERE c.recorrido_id = Convert.ToInt16(txtRecorrido)
                 */
                return "";
            }
            catch(Exception error)
            {
                return "El id del crucero ingresado no existe.\n";
            }
        }

        
    }
}

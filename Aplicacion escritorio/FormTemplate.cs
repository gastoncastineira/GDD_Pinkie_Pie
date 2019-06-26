using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FrbaCrucero
{
    public partial class FormTemplate : Form
    {
        private bool flag = false;
        public static List<Funcion> Funciones = new List<Funcion>();
        public static string usuario { get; set; }
        public static int idCliente { get; set; }
        public static bool isAdmin { get; set; }
        public FormTemplate() : base()
        {
            InitializeComponent();

            foreach (Funcion f in Funciones.Distinct().ToList())
            {
                ToolStripMenuItem item;
                switch (f)
                {
                    case Funcion.ABM_CRUCERO:
                        item = new ToolStripMenuItem("ABM Crucero");
                        item.Click += ABM_Crucero_Click;
                        verToolStripMenuItem.DropDownItems.Add(item);
                        break;
                    case Funcion.COMPRA_PASAJE:
                        item = new ToolStripMenuItem("Compra/Reserva de pasaje");
                        item.Click += Compra_Pasaje_Click;
                        verToolStripMenuItem.DropDownItems.Add(item);
                        break;
                    case Funcion.ABM_RECORRIDO:
                        item = new ToolStripMenuItem("ABM Recorrido");
                        item.Click += ABM_Recorrido_Click;
                        verToolStripMenuItem.DropDownItems.Add(item);
                        break;
                    case Funcion.ABM_ROL:
                        item = new ToolStripMenuItem("ABM Rol");
                        item.Click += ABM_Rol_Click;
                        verToolStripMenuItem.DropDownItems.Add(item);
                        break;
                    case Funcion.GENERAR_VIAJE:
                        item = new ToolStripMenuItem("Generar Viaje");
                        item.Click += Generar_Viaje_Click;
                        verToolStripMenuItem.DropDownItems.Add(item);
                        break;
                    case Funcion.PAGO_RESERVA:
                        item = new ToolStripMenuItem("Pago de Reserva");
                        item.Click += Pago_Reserva_Click;
                        verToolStripMenuItem.DropDownItems.Add(item);
                        break;
                    case Funcion.LISTADO_ESTADISTICO:
                        item = new ToolStripMenuItem("Listado estadistico");
                        item.Click += ListadoEstadistico_Click;
                        verToolStripMenuItem.DropDownItems.Add(item);
                        break;
                }
            }
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = true;
            Close();
            Program.FormInicial.Show();
        }

        private void ABM_Crucero_Click(object sender, EventArgs e)
        {
            flag = true;
            Close();
            new AbmCrucero.ListaDeCruceros().Show();
        }

        private void Compra_Pasaje_Click(object sender, EventArgs e)
        {
            flag = true;
            Close();
            new FrbaCrucero.CompraPasaje.ComprarReservarViaje().Show();
        }

        private void ABM_Rol_Click(object sender, EventArgs e)
        {
            flag = true;
            Close();
            new AbmRol.ListadoRoles().Show();
        }

        private void ABM_Recorrido_Click(object sender, EventArgs e)
        {
            flag = true;
            Close();
            new AbmRecorrido.ListaDeRecorridos().Show();
        }

        private void Generar_Viaje_Click(object sender, EventArgs e)
        {
            flag = true;
            Close();
           new FrbaCrucero.GeneracionViaje.GenerarViaje().Show();
        }

        private void Pago_Reserva_Click(object sender, EventArgs e)
        {
            flag = true;
            Close();          
            new PagoReserva.PagoReserva().Show();
        }

        private void ListadoEstadistico_Click(object sender, EventArgs e)
        {
            flag = true;
            Close();
            new ListadoEstadistico.ListadoEstadistico().Show();
        }

        private void FormTemplate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(!flag)
                Program.FormInicial.Show();
            flag = false;
        }
    }
}

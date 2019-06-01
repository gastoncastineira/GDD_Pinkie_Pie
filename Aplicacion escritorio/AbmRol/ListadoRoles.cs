using Conexiones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmRol
{
    public partial class ListadoRoles : FormTemplate
    {
        Conexion conexion = new Conexion();
        public ListadoRoles() : base()
        {
            InitializeComponent();
        }

        private void MostrarResultado(DialogResult dr)
        {
            if (dr == DialogResult.OK)
                MessageBox.Show("Se actualizó correctamente");
            if (dr == DialogResult.Abort)
                MessageBox.Show("Se encontró un error fatal y se abortó la actualización");
            if (dr == DialogResult.Cancel)
                MessageBox.Show("Se canceló la solicitud");
        }

        private void ListadoRoles_Load(object sender, EventArgs e)
        {
            conexion.LlenarDataGridView(Tabla.Rol, ref dataGridView1, null);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            MostrarResultado(new ModificarRol(Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["id"].Value), dataGridView1.SelectedCells[0].OwningRow.Cells["nombre"].Value.ToString()).ShowDialog());
            conexion.LlenarDataGridView(Tabla.Rol, ref dataGridView1, null);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MostrarResultado(new CrearRol().ShowDialog());
            conexion.LlenarDataGridView(Tabla.Rol, ref dataGridView1, null);
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            conexion.deshabilitar(Tabla.Rol, Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["id"].Value));
            conexion.LlenarDataGridView(Tabla.Rol, ref dataGridView1, null);
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            conexion.habilitar(Tabla.Rol, Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["id"].Value));
            conexion.LlenarDataGridView(Tabla.Rol, ref dataGridView1, null);
        }
    }
}

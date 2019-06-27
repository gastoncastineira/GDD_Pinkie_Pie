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
    public partial class CrearRol : Form
    {
        Conexion conexion = new Conexion();
        public CrearRol()
        {
            InitializeComponent();
        }

        private void CrearRol_Load(object sender, EventArgs e)
        {
            Dictionary<string, List<object>> resul = conexion.ConsultaPlana(Tabla.Funcion, new List<string>(new string[] { "nombre" }), null);
            resul["nombre"].ForEach(o => checkedListBoxFuncion.Items.Add(o.ToString(), false));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Se debe ingresar un nombre");
                return;
            }


            List<string> columnas = new List<string>();
            columnas.Add("Nombre");
            List<Filtro> filtrosNom = new List<Filtro>();
            filtrosNom.Add(FiltroFactory.Exacto("Nombre", txtNombre.Text));

            if (!conexion.ExisteRegistro(Tabla.Rol, columnas, filtrosNom))
            {
                List<Funcion> funciones = new List<Funcion>();
                for (int i = 0; i < checkedListBoxFuncion.Items.Count; i++)
                {
                    if (checkedListBoxFuncion.GetItemChecked(i))
                    {
                        funciones.Add((Funcion)i + 1);
                    }
                }
                if (funciones.Count == 0)
                {
                    MessageBox.Show("Se debe seleccionar al menos una funcion");
                    return;
                }
                Dictionary<string, object> datos = new Dictionary<string, object>();
                datos["nombre"] = txtNombre.Text;

                Transaccion tr = conexion.IniciarTransaccion();

                int idinsertada = tr.Insertar(Tabla.Rol, datos);
                if(idinsertada == -1)
                {
                    DialogResult = DialogResult.Abort;
                    return;
                }

                foreach (int f in funciones)
                {                  
                    tr.InsertarTablaIntermedia(Tabla.RolXFuncion, "id_rol", "id_funcion", idinsertada, f);
                }

                tr.Commit();
                MessageBox.Show("Rol creado exitosamente");
            }
            else
            {
                MessageBox.Show("Ese rol ya existe.");
                txtNombre.Text = string.Empty;
            }
            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnLimpia_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.ToLower() != "administrador" && txtNombre.Text.ToLower() != "cliente")
                txtNombre.Text = string.Empty;
            foreach (int i in checkedListBoxFuncion.CheckedIndices)
            {
                checkedListBoxFuncion.SetItemCheckState(i, CheckState.Unchecked);
            }
        }
    }
}

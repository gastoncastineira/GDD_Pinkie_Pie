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
    public partial class ModificarRol : Form
    {
        int idRol;
        string nombreOG;
        private List<Funcion> funcionesOriginales = new List<Funcion>();
        private Conexion conexion = new Conexion();

        public ModificarRol(int id, string nombre)
        {
            idRol = id;
            InitializeComponent();
            nombreOG = nombre;
            txtNombre.Text = nombre;
            if (nombre.ToLower() == "administrador" || nombre.ToLower() == "cliente")
            {
                txtNombre.Enabled = false;
            }
        }

        private void ModificarRol_Load(object sender, EventArgs e)
        {
            Dictionary<string, List<object>> resul = conexion.ConsultaPlana(Tabla.Funcion, new List<string>(new string[] { "id", "nombre" }), null);
            List<Filtro> filtros = new List<Filtro>();
            filtros.Add(FiltroFactory.Exacto("id_rol", idRol.ToString()));
            filtros.Add(null);
            for (int i = 1; i <= resul["nombre"].Count; i++)
            {
                filtros[1] = FiltroFactory.Exacto("id_funcion", i.ToString());
                checkedListBoxFuncion.Items.Add(resul["nombre"][i - 1], (conexion.ExisteRegistro(Tabla.RolXFuncion, new List<string>(new string[] { "id_rol", "id_funcion" }), filtros)));
            }

            for (int i = 1; i <= checkedListBoxFuncion.Items.Count; i++)
            {
                if (checkedListBoxFuncion.GetItemChecked(i - 1))
                {
                    funcionesOriginales.Add((Funcion)i);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Se debe ingresar un nombre");
                return;
            }

            List<Funcion> aBorrar = new List<Funcion>();
            List<Funcion> aInsertar = new List<Funcion>();
            for (int i = 0; i < checkedListBoxFuncion.Items.Count; i++)
            {

                if (checkedListBoxFuncion.GetItemChecked(i) && !funcionesOriginales.Contains((Funcion)i + 1))
                    aInsertar.Add((Funcion)i + 1);
                if (!checkedListBoxFuncion.GetItemChecked(i) && funcionesOriginales.Contains((Funcion)i + 1))
                    aBorrar.Add((Funcion)i + 1);
            }

            Transaccion tr = conexion.IniciarTransaccion();
            Dictionary<string, object> datos = new Dictionary<string, object>();
            datos["nombre"] = txtNombre.Text;
            tr.Modificar(idRol, Tabla.Rol, datos);
            foreach (int v in aInsertar)
            {
                if (!tr.InsertarTablaIntermedia(Tabla.RolXFuncion, "id_rol", "id_funcion", idRol, v))
                {
                    DialogResult = DialogResult.Abort;
                    return;
                }

            }
            foreach (int v in aBorrar)
            {
                if (!tr.eliminarTablaIntermedia(Tabla.RolXFuncion, "id_rol", "id_funcion", idRol, v))
                {
                    DialogResult = DialogResult.Abort;
                    return;
                }
            }
            tr.Commit();
            DialogResult = DialogResult.OK;
        }


        private void btnRegresar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.ToLower() != "administrador" && txtNombre.Text.ToLower() != "cliente")
                txtNombre.Text = string.Empty;
            foreach (int i in checkedListBoxFuncion.CheckedIndices)
            {
                checkedListBoxFuncion.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            List<string> columnas = new List<string>();
            columnas.Add("Nombre");
            List<Filtro> filtrosNom = new List<Filtro>();
            filtrosNom.Add(FiltroFactory.Exacto("Nombre", txtNombre.Text));
            filtrosNom.Add(FiltroFactory.Exacto("Nombre", nombreOG));

            if (txtNombre.Text == nombreOG)
                return;

            if (conexion.ExisteRegistro(Tabla.Rol, columnas, filtrosNom))
            {
                MessageBox.Show("Ese rol ya existe. Elija otro o siga usando el mismo.");
                txtNombre.Text = nombreOG;
            }
        }
    }
}

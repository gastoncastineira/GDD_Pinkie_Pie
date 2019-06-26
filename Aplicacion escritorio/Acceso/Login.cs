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

namespace FrbaCrucero.Acceso
{
    public partial class Login : Form
    {
        private const int CANT_MAXIMA = 3;
        Conexion conexion = new Conexion();

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtContraseña.Text) || string.IsNullOrEmpty(txtusuario.Text))
            {
                MessageBox.Show("Se detecto un campo vacio. Revise");
                return;
            }
            List<Filtro> filtros = new List<Filtro>();
            filtros.Add(FiltroFactory.Exacto("usuario", txtusuario.Text));
            if (!conexion.ExisteRegistro(Tabla.Usuario, new List<string>(new string[] { "usuario" }), filtros))
            {
                MessageBox.Show("No existe dicho usuario en el sistema");
                return;
            }
            Dictionary<string, List<object>> resul = conexion.ConsultaPlana(Tabla.Usuario, new List<string>(new string[] { "ID", "cant_accesos_fallidos", "habilitado" }), filtros);
            if (!Convert.ToBoolean(resul["habilitado"][0]))
            {
                MessageBox.Show("Este usuario se encuentra deshabilitado");
                return;
            }
            int cantAccesos = Convert.ToInt32(resul["cant_accesos_fallidos"][0]);
            if (conexion.ValidarLogin(txtusuario.Text, txtContraseña.Text))
            {
                conexion.ActualizarFecha(ConfigurationHelper.FechaActual);
                new EnrutarRoles(txtusuario.Text).Show();
                Close();
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta");
                cantAccesos++;
            }
            if (cantAccesos >= CANT_MAXIMA)
            {
                MessageBox.Show("Se llegó al límite de intentos y se inhabilitó el usuario. Por favor, contacte al administrador");
                conexion.deshabilitar(Tabla.Usuario, Convert.ToInt32(resul["ID"][0]));
                Dictionary<string, object> datos = new Dictionary<string, object>();
                datos["cant_accesos_fallidos"] = 0;
                conexion.Modificar(Convert.ToInt32(resul["ID"][0]), Tabla.Usuario, datos);
            }
            txtContraseña.Text = string.Empty;
            txtusuario.Text = string.Empty;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

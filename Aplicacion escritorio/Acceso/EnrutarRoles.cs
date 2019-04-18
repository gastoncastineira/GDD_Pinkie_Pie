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
    public partial class EnrutarRoles : Form
    {
        Conexion conexion = new Conexion();
        private string usuario;
        private bool flag = false;

        public EnrutarRoles(string usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
        }

        private void EntutarRoles_Load(object sender, EventArgs e)
        {
            List<Filtro> filtros = new List<Filtro>();
            filtros.Add(FiltroFactory.Exacto("usuario", usuario));
            Dictionary<string, List<object>> resul = conexion.ConsultaPlana(Tabla.RolesUsuario, new List<string>(new string[] { "nombre_rol" }), filtros);
            if (resul["nombre_rol"].Count == 0)
            {
                MessageBox.Show("No se detectaron roles para ese usuario. Hable con su administrador");
                Program.FormInicial.Show();
                Close();
            }
            if (resul["nombre_rol"].Count == 1)
            {
                MessageBox.Show("Se detectó un unico rol");
                new EnrutarFuncion(resul["nombre_rol"][0].ToString(), usuario).Show();
                Close();
            }
            comboBox1.DataSource = resul["nombre_rol"];
            comboBox1.SelectedIndex = -1;
            flag = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!flag)
                return;
            new EnrutarFuncion(comboBox1.Text, usuario).Show();
            flag = false;
            Close();
        }

        private void EntutarRoles_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(flag)
                Program.FormInicial.Show();
        }
    }
}

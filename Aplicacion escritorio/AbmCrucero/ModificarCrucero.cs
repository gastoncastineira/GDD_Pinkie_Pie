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

namespace FrbaCrucero.AbmCrucero
{
    public partial class ModificarCrucero : Form
    {
        private Conexion conexion = new Conexion();
        private string ID;
        private string modelo;
        private string fabricante;
        private string identificador;
        public ModificarCrucero(string ID_, string modelo_, string fabricante_, string identificador_)
        {
            ID = ID_;
            modelo = modelo_;
            fabricante = fabricante_;
            identificador = identificador_;
            InitializeComponent();
        }

        private void ButtonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> cambios = new Dictionary<string, object>();

            if (this.camposVacios())
            {
                MessageBox.Show("Se han encontrado campos vacios. Por favor completelos e intentelo nuevamente", "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (this.identRepetido())
            {

                MessageBox.Show("Ya existe un crucero con ese identificador", "Identificador existente", MessageBoxButtons.OK, MessageBoxIcon.Error);

            } else 
            {

                cambios.Add("modelo", textBoxModelo.Text.Trim());
                
                // Extraigo fabricante
                Filtro filtroNombre = FiltroFactory.Exacto("nombre", comboBox1.Text);
                var returnFabricante = conexion.ConsultaPlana(Tabla.Fabricante, new List<string> { "id" }, new List<Filtro> { filtroNombre });
                var id = returnFabricante["id"][0];

                cambios.Add("fabricante_id", id);
                cambios.Add("identificador", textBoxIdentificador.Text.Trim());
                conexion.Modificar(int.Parse(ID), Tabla.Crucero, cambios);
                DialogResult = DialogResult.OK;

            }

        }

        private void ModificarCrucero_Load(object sender, EventArgs e)
        {
            conexion.LlenarComboFabricantes(ref comboBox1);
            textBoxModelo.Text = modelo;
            comboBox1.SelectedIndex = comboBox1.FindString(fabricante);
            textBoxIdentificador.Text = identificador;
        }

        private bool camposVacios()
        {
            return (this.stringVacio(textBoxModelo.Text) || this.stringVacio(comboBox1.Text) || this.stringVacio(textBoxIdentificador.Text)) ;
        }

        private bool stringVacio(string str)
        {
            return string.IsNullOrWhiteSpace(str) || string.IsNullOrEmpty(str);
        }

        private bool identRepetido() {

            if (identificador != textBoxIdentificador.Text)
            {
                Dictionary<string, List<object>> rdos = conexion.ConsultaPlana(Tabla.Crucero, new List<string> { "identificador" }, new List<Filtro> { FiltroFactory.Exacto("identificador", textBoxIdentificador.Text) });
                return rdos["identificador"].Count > 0;
            }
            else
            {
                return false;
            }
           
        }

    }
}

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
        private ListaDeCruceros padre;
        private string ID;
        private string modelo;
        private string fabricante;
        private string identificador;
        public ModificarCrucero(string ID_, string modelo_, string fabricante_, string identificador_, ListaDeCruceros padre_)
        {
            ID = ID_;
            padre = padre_;
            modelo = modelo_;
            fabricante = fabricante_;
            identificador = identificador_;
            InitializeComponent();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void ButtonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> cambios = new Dictionary<string, object>();
            cambios.Add("modelo",textBoxModelo.Text.Trim());
            cambios.Add("fabricante",textBoxFabricante.Text.Trim());
            cambios.Add("identificador",textBoxIdentificador.Text.Trim());
            conexion.Modificar(int.Parse(ID),Tabla.Crucero,cambios);
            padre.reLoad();
            this.Close();
        }

        private void ModificarCrucero_Load(object sender, EventArgs e)
        {
            textBoxModelo.Text = modelo;
            textBoxFabricante.Text = fabricante;
            textBoxIdentificador.Text = identificador;

            //List<Filtro> listFiltro = new List<Filtro>();
            //listFiltro.Add(FiltroFactory.Exacto("Crucero", ID));
            //conexion.LlenarDataGridView(Tabla.CabinasDeCrucero, ref dataGridViewCabinas, listFiltro);
            //listFiltro.Clear();
            //listFiltro.Add(FiltroFactory.Exacto("ID", ID));
            //comboBoxDescripcionCabina.DataSource = conexion.ConseguirTabla(Tabla.Tipo, listFiltro).Columns[1];
        }

    }
}

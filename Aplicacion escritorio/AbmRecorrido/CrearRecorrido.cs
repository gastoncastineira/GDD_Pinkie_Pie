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

namespace FrbaCrucero.AbmRecorrido
{
    public partial class CrearRecorrido : Form
    {
        private Conexion conexion = new Conexion();
        private List<string> ultimoOrigen = new List<string>();
        private string origenID = null ;
        private List<string> destinoID = new List<string>();
        private List<string> tramosID = new List<string>();
        ListaDeRecorridos padre;
        public CrearRecorrido(ListaDeRecorridos view)
        {
            padre = view;
            InitializeComponent();
        }

        private void CrearRecorrido_Load(object sender, EventArgs e)
        {
            conexion.LlenarCheckedListConTramosDescriptos(ref checkedListBoxTramos, null);
        }

        private void ButtonAgregar_Click(object sender, EventArgs e)
        {
            string tramos = "";
            int i = 0;
            while (i < checkedListBoxTramos.Items.Count){
                if (checkedListBoxTramos.GetItemChecked(i)){
                    tramos = checkedListBoxTramos.Items[i].ToString();
                    break;
                }
                i++;
            }

            if (i == checkedListBoxTramos.Items.Count){
                MessageBox.Show("Se debe seleccionar al menos un tramo");
                return;
            }

            Dictionary<string, List<object>> res;

                string[] cadenas = tramos.Split('.'); string origen; string destino;
            if (cadenas[0].Split(' ').Length == 3) {
                 origen = cadenas[0].Split(' ')[1] + " " + cadenas[0].Split(' ')[2];
            }else{ origen = cadenas[0].Split(' ')[1]; }
            if (cadenas[1].TrimStart(' ').Split(' ').Length == 3) { 
                destino =  cadenas[1].TrimStart(' ').Split(' ')[1] + " " + cadenas[1].TrimStart(' ').Split(' ')[2];
            }else{ destino = cadenas[1].TrimStart(' ').Split(' ')[1]; }

                Filtro filtroOrigen = FiltroFactory.Exacto("ORIGEN_DESC", origen );
                Filtro filtroDestino = FiltroFactory.Exacto("DESTINO_DESC", destino );
                List<Filtro> filtros = new List<Filtro>();
                filtros.Add(filtroOrigen);
                filtros.Add(filtroDestino);
            List<string> columnas = new List<string>();
            columnas.Add("ID");
            columnas.Add("ORIGEN_ID");
            columnas.Add("DESTINO_ID");
            res = conexion.ConsultaPlana(Tabla.TramoConDescripcion,columnas , filtros);

            if (ultimoOrigen.Count == 0){
                origenID = res["ORIGEN_ID"].Last().ToString();
            }  destinoID.Add( res["DESTINO_ID"].Last().ToString() );

            ultimoOrigen.Add(destino);
            this.agregarAlGridView(res["ID"].Last().ToString() );
            
            foreach (int item in checkedListBoxTramos.CheckedIndices)
            {
                checkedListBoxTramos.SetItemCheckState(item, CheckState.Unchecked);
            }
            this.reLoad();
        }
        private void agregarAlGridView(string tramoID)
        {
            tramosID.Add(tramoID);
            Filtro filtroTramo = FiltroFactory.Contenido(" ID ",tramosID );
            List<Filtro> filtros = new List<Filtro>();
            filtros.Add(filtroTramo);
            conexion.LlenarDataGridView(Tabla.TramoConDescripcion,ref dataGridViewRecorrido, filtros);
        } 
        private void reLoad()
        {
            while (checkedListBoxTramos.Items.Count != 0)
            {
                checkedListBoxTramos.Items.RemoveAt(0);
            }
            conexion.LlenarCheckedListConTramosDescriptos(ref checkedListBoxTramos, (ultimoOrigen.Count > 0)? ultimoOrigen.Last() : null);
        }

        private void ButtonConfirmar_Click(object sender, EventArgs e)
        {
            Transaccion tr = conexion.IniciarTransaccion();

            Dictionary<string, object> registros = new Dictionary<string, object>();
            registros.Add("codigo",1);
            registros.Add("puerto_origen_id", int.Parse(origenID));
            registros.Add("puerto_destino_id", int.Parse(destinoID.Last()));

            int pkRecorrido = tr.Insertar(Tabla.Recorrido, registros);

            tramosID.ForEach( id => tr.InsertarTablaIntermedia(Tabla.Tramo_X_Recorrido, "ID_Recorrido", "ID_Tramo", pkRecorrido, int.Parse(id)));

            tr.Commit();

            padre.reLoad();
            this.Close();
        }

        private void ButtonQuitar_Click(object sender, EventArgs e)
        {
            if(ultimoOrigen.Count > 0)
            {
                ultimoOrigen.RemoveAt(ultimoOrigen.Count - 1);
                tramosID.RemoveAt(tramosID.Count - 1);
                destinoID.RemoveAt(destinoID.Count - 1);
                dataGridViewRecorrido.Rows.RemoveAt(dataGridViewRecorrido.Rows.Count -1);
                this.reLoad();
            }
        }

        private void ButtonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            padre.Show();
        }
    }
}

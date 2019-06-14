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
    public partial class ModificarRecorrido : Form
    {
        private Conexion conexion = new Conexion();
        int PkRecorrido;
        ListaDeRecorridos viewPadre;
        public ModificarRecorrido(int PK, ListaDeRecorridos view)
        {
            PkRecorrido = PK;
            viewPadre = view;
            InitializeComponent();
        }

        private void ButtonAgregar_Click(object sender, EventArgs e)
        {
            List<string> tramos = new List<string>();
                for (int i = 0; i < checkedListBoxTramos.Items.Count; i++)
                {
                    if (checkedListBoxTramos.GetItemChecked(i))
                    {
                    tramos.Add( checkedListBoxTramos.Items[i].ToString() );
                    }
                }
                if (tramos.Count == 0)
                {
                    MessageBox.Show("Se debe seleccionar al menos un tramo");
                    return;
                }
            Dictionary<string, List<object> > res;

            
            Transaccion tr = conexion.IniciarTransaccion();
            int idTramo;
            string origen = "";
            string destino ="";

            for (int i = 0; i < tramos.Count(); i++)
            {
                string[] cadenas = tramos[i].Split('.'); 
                if (cadenas[0].Split(' ').Length == 3)
                {
                    origen = cadenas[0].Split(' ')[1] + " " + cadenas[0].Split(' ')[2];
                }
                else { origen = cadenas[0].Split(' ')[1]; }
                if (cadenas[1].TrimStart(' ').Split(' ').Length == 3)
                {
                    destino = cadenas[1].TrimStart(' ').Split(' ')[1] + " " + cadenas[1].TrimStart(' ').Split(' ')[2];
                }
                else { destino = cadenas[1].TrimStart(' ').Split(' ')[1]; }

                Filtro filtroOrigen = FiltroFactory.Exacto("ORIGEN_DESC",origen );
                Filtro filtroDestino = FiltroFactory.Exacto("DESTINO_DESC", destino );
                List<Filtro> filtros = new List<Filtro>();
                filtros.Add(filtroOrigen);
                filtros.Add(filtroDestino);

                res = conexion.ConsultaPlana(Tabla.TramoConDescripcion, new List<string>(new string[] { "ID" }), filtros);

                idTramo = int.Parse(res["ID"].Last().ToString());
                tr.InsertarTablaIntermedia(Tabla.Tramo_X_Recorrido, "ID_Recorrido", "ID_Tramo", PkRecorrido, idTramo);        
            }

            tr.Commit();

            actualizarCheckedListBoxConUltimoDestino(destino);
            this.reLoad();

        }

        private void actualizarCheckedListBoxConUltimoDestino(string ultimoDestino)
        {
            for (int i = checkedListBoxTramos.Items.Count; i > 0; i--)
            {
                checkedListBoxTramos.Items.RemoveAt(i - 1);
            }
            checkedListBoxTramos.Refresh();
            conexion.LlenarCheckedListConTramosDescriptos(ref checkedListBoxTramos, ultimoDestino);
        }

        private void DataGridViewTramos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                var senderGrid = (DataGridView)sender;
                string PkTramo = dataGridViewTramos.Rows[e.RowIndex].Cells[2].Value.ToString();


                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.ColumnIndex == 0)
                {
                    conexion.eliminarTablaIntermedia(Tabla.Tramo_X_Recorrido, "ID_Recorrido", "ID_Tramo", PkRecorrido, int.Parse(PkTramo));

                    if (dataGridViewTramos.Rows.Count > 1)
                    {
                        string ID = dataGridViewTramos.Rows[e.RowIndex - 1].Cells[2].Value.ToString();

                        List<Filtro> filtros = new List<Filtro>();
                        filtros.Add(FiltroFactory.Exacto("TRAMO_ID", ID));
                        List<string> columnas = new List<string>();
                        columnas.Add("PUERTO_DESTINO");
                        Dictionary<string, List<object>> res = conexion.ConsultaPlana(Tabla.TramosParaGridView, columnas, filtros);
                        actualizarCheckedListBoxConUltimoDestino(res["PUERTO_DESTINO"].Last().ToString());
                    }
                    else
                    {
                        actualizarCheckedListBoxConUltimoDestino(null);
                    }
                }
                this.reLoad();
            }
        }

        private void ModificarRecorrido_Load(object sender, EventArgs e)
        {
            this.reLoad();
            conexion.LlenarCheckedListConTramosDescriptos(ref checkedListBoxTramos, null);
        }

        private void reLoad()
        {
            List<Filtro> listFiltro = new List<Filtro>();
            listFiltro.Add(FiltroFactory.Exacto("RECORRIDO_ID", PkRecorrido.ToString()));
            conexion.LlenarDataGridView(Tabla.TramosParaGridView, ref dataGridViewTramos, listFiltro);
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            viewPadre.reLoad();
            this.Close();
        }
    }
}

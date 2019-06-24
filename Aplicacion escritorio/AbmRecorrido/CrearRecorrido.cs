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
        private List<int> IDsActual;
        private List<int> IDsInsert = new List<int>();
        public CrearRecorrido()
        {
            InitializeComponent();
        }

        private void actualizarTramos(string destino)
        {
            lbTramos.Items.Clear();
            List<string> col = new List<string>();
            col.Add("ID");
            col.Add("ORIGEN_DESC");
            col.Add("DESTINO_DESC");
            List<Filtro> filtro = new List<Filtro>();
            if (lbResultado.Items.Count > 0)
                filtro.Add(FiltroFactory.Exacto("ORIGEN_DESC", destino));
            Dictionary<string, List<object>> resul = conexion.ConsultaPlana(Tabla.TramoConDescripcion, col, filtro);
            IDsActual = new List<int>();
            for (int i = 0; i < resul["ORIGEN_DESC"].Count; i++)
            {
                lbTramos.Items.Add("DESDE: " + resul["ORIGEN_DESC"][i] + "; HASTA: " + resul["DESTINO_DESC"][i]);
                IDsActual.Add(Convert.ToInt32(resul["ID"][i]));
            }
            lbTramos.SelectedIndex = lbTramos.Items.Count - 1;
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            string puertoHasta = lbResultado.Items[lbResultado.Items.Count - 1].ToString();
            int longDesde = puertoHasta.LastIndexOf("HASTA: ") + 7;
            int longHasta = puertoHasta.Length - longDesde;
            List<Filtro> filtros = new List<Filtro>();
            filtros.Add(FiltroFactory.Exacto("descripcion", puertoHasta.Substring(longDesde, longHasta)));
            Dictionary<string, List<object>> resul = conexion.ConsultaPlana(Tabla.Puerto, new List<string>(new string[] { "ID" }), filtros);
            int IdPuertoDest = Convert.ToInt32(resul["ID"][0]);
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["puerto_destino_id"] = IdPuertoDest;
            string puertoDesde = lbResultado.Items[0].ToString();
            longDesde = 7;
            longHasta = puertoDesde.LastIndexOf(';') - longDesde;
            filtros[0] = FiltroFactory.Exacto("descripcion", puertoDesde.Substring(longDesde, longHasta));
            resul = conexion.ConsultaPlana(Tabla.Puerto, new List<string>(new string[] { "ID" }), filtros);
            data["puerto_origen_id"] = resul["ID"][0];
            Transaccion tr = conexion.IniciarTransaccion();
            int PkRecorrido = tr.Insertar(Tabla.Recorrido, data);
            foreach (int cod in IDsInsert)
                tr.InsertarTablaIntermedia(Tabla.Tramo_X_Recorrido, "id_recorrido", "id_tramo", PkRecorrido, cod);
            tr.Commit();
            DialogResult = DialogResult.OK;
        }

        private void AgregarRecorrido_Load(object sender, EventArgs e)
        {
            actualizarTramos(null);
        }

        private void lbResultado_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbResultado.SelectedIndex = lbResultado.Items.Count - 1;
        }

        private void btnSacar_Click(object sender, EventArgs e)
        {
            if (lbResultado.Items.Count == 0)
                return;
            lbResultado.Items.RemoveAt(lbResultado.SelectedIndex);
            if (IDsInsert.Count > 0)
                IDsInsert.RemoveAt(IDsInsert.Count - 1);
            else
            {
                return;
            }
            lbResultado.SelectedIndex = lbResultado.Items.Count - 1;
            string cadena = null;
            if (lbResultado.Items.Count > 0)
            {
                cadena = lbResultado.SelectedItem.ToString();
                int longDesde = cadena.LastIndexOf("HASTA: ") + 7;
                int longHasta = cadena.Length - longDesde;
                cadena = cadena.Substring(longDesde, longHasta);
            }
            actualizarTramos(cadena);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            lbResultado.Items.Add(lbTramos.SelectedItem);
            IDsInsert.Add(IDsActual[lbTramos.SelectedIndex]);
            string cadena = lbTramos.SelectedItem.ToString();
            int longDesde = cadena.LastIndexOf("HASTA: ") + 7;
            int longHasta = cadena.Length - longDesde;
            actualizarTramos(cadena.Substring(longDesde, longHasta));
            lbResultado.SelectedIndex = lbResultado.Items.Count - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

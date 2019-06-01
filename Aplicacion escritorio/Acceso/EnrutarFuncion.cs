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
    public partial class EnrutarFuncion : Form
    {
        Conexion conexion = new Conexion();
        private string rolSeleccionado;
        private string usuario;
        private int idCliente = -1;
        List<Funcion> funcion;
        private bool flag = false;

        public EnrutarFuncion(string rolSeleccionado, string usuario)
        {
            InitializeComponent();
            this.rolSeleccionado = rolSeleccionado;
            this.usuario = usuario;
        }

        private void enrutar(int index)
        {
            if (!flag)
                return;
            switch (funcion[index])
            {
                case Funcion.ABM_CRUCERO:
                    //new Abm_Cliente.ListadoClientes().Show();
                    break;
                case Funcion.ABM_PUERTO:
                    //new Abm_Empresa_Espectaculo.ListadoEmpresas().Show();
                    break;
                case Funcion.ABM_RECORRIDO:
                    new AbmRecorrido.ListaDeRecorridos().Show();
                    break;
                case Funcion.GENERAR_VIAJE:
                    //new Canje_Puntos.Canje_Puntos(idCliente).Show();
                    break;
                case Funcion.PAGO_RESERVA:
                    //new Comprar.Comprar(usuario).Show();
                    break;
                case Funcion.LISTADO_ESTADISTICO:
                    //new Listado_Estadistico.ListadoEstadistico().Show();
                    break;
                case Funcion.ABM_ROL:
                    new AbmRol.ListadoRoles().Show();
                    break;
            }
            flag = false;
            Close();
        }

        private void EnrutarFuncion_Load(object sender, EventArgs e)
        {
            List<Filtro> filtros = new List<Filtro>();
            filtros.Add(FiltroFactory.Exacto("usuario", usuario));
            filtros.Add(FiltroFactory.Exacto("nombre_rol", rolSeleccionado));
            Dictionary<string, List<object>> resul = conexion.ConsultaPlana(Tabla.FuncionesUsuarios, new List<string>(new string[] { "nombre_funcion", "funcion_id" }), filtros);
            funcion = resul["funcion_id"].Cast<Funcion>().ToList();
            FormTemplate.Funciones = funcion;
            FormTemplate.usuario = usuario;

            FormTemplate.isAdmin = true;


            if (resul["nombre_funcion"].Count > 1)
            {
                MessageBox.Show("Se detecto que tiene mas de una funcion asignada. Por favor, elija a la que desea ingresar");
                cbbSeleccion.DataSource = resul["nombre_funcion"];
                cbbSeleccion.SelectedIndex = -1;
            }
            else
            {
                enrutar(0);
            }
            flag = true;
        }

        private void cbbSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            enrutar(cbbSeleccion.SelectedIndex);
        }

        private void EnrutarFuncion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(flag)
                Program.FormInicial.Show();
        }
    }
}

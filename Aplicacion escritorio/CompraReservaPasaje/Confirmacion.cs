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
using FrbaCrucero.model;

namespace FrbaCrucero.CompraReservaPasaje
{
    public partial class Confirmacion : Form
    {
        public string IdPuertoOrigen, IdPuertoDestino, TipoDeOperacion;
        private Viaje ViajeElegido;
        public Cliente ClienteComprador;
        private int CantidadDePasajes;
        private double PrecioTotal;
        private MetodoDePago MedioDePago;
        private List<int> NumerosOperacion = new List<int>();
        private Conexion conexion = new Conexion();

        public Confirmacion(int cantPasajes, Viaje viajeElegido, string idPuertoOrigen, string idPuertoDestino, Cliente cliente, double precioTotal, MetodoDePago medioDePago, string tipoDeOperacion) : base()
        {
            CantidadDePasajes = cantPasajes;
            ViajeElegido = viajeElegido;
            IdPuertoOrigen = idPuertoOrigen;
            IdPuertoDestino = idPuertoDestino;
            ClienteComprador = cliente;
            PrecioTotal = precioTotal;
            MedioDePago = medioDePago;
            TipoDeOperacion = tipoDeOperacion;

            InitializeComponent();
        }

        private void Confirmacion_Load(object sender, EventArgs e)
        {
            if (TipoDeOperacion == "COMPRA")
                lblNumeros.Text += "compras";
            else
                lblNumeros.Text += "reservas";

            lblCantidadDePasajeros.Text += CantidadDePasajes.ToString();
            lblFechaDeConcepcion.Text += FrbaCrucero.ConfigurationHelper.FechaActual.ToString();
            lblFechaDeInicio.Text += ViajeElegido.FechaInicio.ToString();
            lblFechaFin.Text += ViajeElegido.Fecha_Fin_Estimada.ToString();

            List<Filtro> filtrosPuertoOrigen = new List<Filtro>();
            filtrosPuertoOrigen.Add(FiltroFactory.Exacto("ID", IdPuertoOrigen.ToString()));

            Dictionary<string, List<object>> puertoOrigen = conexion.ConsultaPlana(Tabla.Puerto, new List<string>(new string[] { "descripcion" }), filtrosPuertoOrigen);

            lblPuertoOrigen.Text += puertoOrigen["descripcion"].First().ToString();

            List<Filtro> filtrosPuertoDestino = new List<Filtro>();
            filtrosPuertoDestino.Add(FiltroFactory.Exacto("ID", IdPuertoDestino.ToString()));

            Dictionary<string, List<object>> puertoDestino = conexion.ConsultaPlana(Tabla.Puerto, new List<string>(new string[] { "descripcion" }), filtrosPuertoDestino);

            lblPuertoDestino.Text += puertoDestino["descripcion"].First().ToString();

            LlenarDGVNumerosOperacion();
            LlenarDGVTramos();

            List<Filtro> filtrosCrucero = new List<Filtro>();
            filtrosCrucero.Add(FiltroFactory.Exacto("ID", ViajeElegido.Cabinas.First().Crucero_id.ToString()));

            List<string> campos = new List<string>();
            campos.Add("modelo");
            campos.Add("identificador");

            Dictionary<string, List<object>> crucero = conexion.ConsultaPlana(Tabla.Crucero, campos, filtrosCrucero);

            lblIdeCrucero.Text += crucero["identificador"].First().ToString();
            lblModeloCrucero.Text += crucero["modelo"].First().ToString();

            List<Filtro> filtrosTipo = new List<Filtro>();
            filtrosTipo.Add(FiltroFactory.Exacto("ID", ViajeElegido.Cabinas.First().Tipo_id.ToString()));

            Dictionary<string, List<object>> tipoCabina = conexion.ConsultaPlana(Tabla.Tipo, new List<string>(new string[] { "tipo" }), filtrosTipo);

            lblTipoDeCabina.Text += tipoCabina["tipo"].First().ToString();
            lblPrecioTotal.Text += PrecioTotal.ToString();
        }

        private void LlenarDGVTramos()
        {
            List<Filtro> filtrosTramos = new List<Filtro>();
            filtrosTramos.Add(FiltroFactory.Exacto("RECORRIDO_ID", ViajeElegido.Recorrido_id.ToString()));

            conexion.LlenarDataGridView(Tabla.TramosParaGridView, ref dtTramos, filtrosTramos);

            dtTramos.Columns[0].Visible = false;
            dtTramos.Columns[1].Visible = false;
            dtTramos.ClearSelection();
        }

        private void LlenarDGVNumerosOperacion()
        {
            string tabla = "";
            if (TipoDeOperacion == "COMPRA")
                tabla = Tabla.Pasaje;
            else
                tabla = Tabla.Reserva;

            for (int i = 0; i < CantidadDePasajes; i++)
            {
                int numero = ObtenerCodigoDeOperacion(tabla);
                NumerosOperacion.Add(numero);
                dtNumerosOperacion.Rows.Add(numero.ToString(), (PrecioTotal / CantidadDePasajes).ToString());
            }

            dtNumerosOperacion.ClearSelection();
        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            String mensaje = ValidarCampos();
            if (mensaje == "")
            {
                // Se obtienen los datos que se van a insertar
                Dictionary<string, object> datosMetodoDePago = ObtenerDatosMetodoDePago();
                Dictionary<string, object> datosViaje = ObtenerDatosViaje();
                string tipo = "";

                // Se Inserta el Cliente en caso de que no exista
                if (ClienteComprador.Id == -1)
                {
                    Dictionary<string, object> datos = new Dictionary<string, object>();

                    datos["fecha_nacimiento"] = ClienteComprador.FechaDeNacimiento;
                    datos["telefono"] = ClienteComprador.Telefono;
                    datos["nombre"] = ClienteComprador.Nombre;
                    datos["apellido"] = ClienteComprador.Apellido;
                    datos["DNI"] = ClienteComprador.Dni;
                    datos["direccion"] = ClienteComprador.Direccion;
                    datos["mail"] = ClienteComprador.Mail;

                    ClienteComprador.Id = conexion.Insertar(Tabla.Cliente, datos);
                }

                int idMetodoDePago = 0;
                List<Filtro> filtros = new List<Filtro>();

                if (TipoDeOperacion == "COMPRA" && MedioDePago.Tipo != "EFECTIVO")
                {
                    filtros.Add(FiltroFactory.Exacto("tipo", MedioDePago.Tipo));
                    filtros.Add(FiltroFactory.Exacto("numero_de_tarjeta", MedioDePago.NumeroTarjeta.ToString()));

                    if (!(conexion.ExisteRegistro(Tabla.MedioDePago, new List<string>(new string[] { "ID" }), filtros)))
                    {
                        // Se inserta metodo de pago
                        idMetodoDePago = conexion.Insertar(Tabla.MedioDePago, datosMetodoDePago);
                    }
                    else
                    {
                        Dictionary<string, List<object>> tipoCabina = conexion.ConsultaPlana(Tabla.MedioDePago, new List<string>(new string[] { "ID" }), filtros);

                        idMetodoDePago = Convert.ToInt32(tipoCabina["ID"].First());
                    }
                }
                
                if (TipoDeOperacion == "COMPRA")
                    idMetodoDePago = 1;
                

                // Se suma al viaje elegido por el usuario la cantidad de pasajes vendidos 
                conexion.Modificar(ViajeElegido.Id, Tabla.Viaje, datosViaje);

                // Se marcan a las cabinas como ocupada y se insertan las compras/reservas
                for (int i = 0; i < CantidadDePasajes; i++)
                {
                    int idCabina = ObtenerIdCabina();
                    int nroOperacion;
                    Dictionary<string, object> datosOperacion = ObtenerDatosOperacion(idCabina);
                    datosOperacion["cliente_id"] = ClienteComprador.Id;

                    if (TipoDeOperacion == "COMPRA")
                    {   
                        // Se inserta una compra
                        nroOperacion = NumerosOperacion[i];

                        datosOperacion["medio_de_pago_id"] = idMetodoDePago;
                        datosOperacion["fecha_de_compra"] = FrbaCrucero.ConfigurationHelper.FechaActual;
                        datosOperacion["codigo"] = nroOperacion;

                        conexion.Insertar(Tabla.Pasaje, datosOperacion);
                        tipo = "compra";
                    }
                    else
                    {
                        // Se inserta una reserva
                        nroOperacion = NumerosOperacion[0];

                        datosOperacion["fecha_de_reserva"] = FrbaCrucero.ConfigurationHelper.FechaActual;
                        datosOperacion["codigo"] = nroOperacion;

                        conexion.Insertar(Tabla.Reserva, datosOperacion);
                        tipo = "reserva";
                    }
                    
                    // Se marca a la cabina como ocupada
                    Dictionary<string, object> datosCabina = ObtenerDatosCabina();
                    conexion.Modificar(idCabina, Tabla.Cabina, datosCabina);
                }

                MessageBox.Show("Se ha hecho la " + tipo + " correctamente!\n" + "Gracias por su " + tipo + "\n", "Confirmación");
                if (tipo == "reserva")
                    MessageBox.Show("Su codigo de reserva es " + NumerosOperacion[0]);
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ObtenerIdCabina()
        {
            List<Filtro> filtros = new List<Filtro>();
            filtros.Add(FiltroFactory.Exacto("viaje_id", ViajeElegido.Id.ToString()));
            filtros.Add(FiltroFactory.Exacto("tipo_id", ViajeElegido.Cabinas.First().Tipo_id.ToString()));
            filtros.Add(FiltroFactory.Exacto("ocupado", "0"));

            List<string> campos = new List<string>();
            campos.Add("ID");

            Dictionary<string, List<object>> cabinasVacias = conexion.ConsultaPlana(Tabla.Cabina, campos, filtros);

            Random random = new Random();
            int indiceCabinaRandom = random.Next(0, random.Next(0, cabinasVacias["ID"].Count()));

            return Convert.ToInt32(cabinasVacias["ID"][indiceCabinaRandom]);
        }

        private int ObtenerCodigoDeOperacion(string tabla)
        {
            Dictionary<string, List<object>> codigos = conexion.ConsultaPlana(tabla, new List<string>(new string[] { "codigo" }), null);
            Random random = new Random();

            int codigoGenerado;

            do
            {
                int codigoRandom = Convert.ToInt32(codigos["codigo"][random.Next(0, codigos["codigo"].Count())]);

                codigoGenerado = codigoRandom + random.Next(10, 100000);
            }
            while (codigos["codigo"].Any(c => Convert.ToInt32(c) == codigoGenerado)
            || NumerosOperacion.Any(n => n == codigoGenerado));

            return codigoGenerado;
        }

        // --------------------------------------------------OBTENER DATOS--------------------------------------------
        private Dictionary<string, object> ObtenerDatosMetodoDePago()
        {
            if (TipoDeOperacion == "COMPRA")
            {
                Dictionary<string, object> datosMetodoDePago = new Dictionary<string, object>();

                datosMetodoDePago["tipo"] = MedioDePago.Tipo;
                datosMetodoDePago["numero_de_tarjeta"] = MedioDePago.NumeroTarjeta;

                return datosMetodoDePago;
            }

            return null;
        }

        private Dictionary<string, object> ObtenerDatosOperacion(int idCabina)
        {
            Dictionary<string, object> datosOperacion = new Dictionary<string, object>();

            
            datosOperacion["precio"] = PrecioTotal;
            datosOperacion["cabina_id"] = idCabina; 
            

            return datosOperacion;
        }

        private Dictionary<string, object> ObtenerDatosViaje()
        {
            Dictionary<string, object> datosViaje = new Dictionary<string, object>();

            datosViaje["pasajes_vendidos"] = ViajeElegido.PasajesVendidos + CantidadDePasajes;

            return datosViaje;
        }

        private Dictionary<string, object> ObtenerDatosCabina()
        {
            Dictionary<string, object> datosCabina = new Dictionary<string, object>();

            datosCabina["ocupado"] = 1;

            return datosCabina;
        }

        // ---------------------------------------VALIDACIONES------------------------------------------

        private String ValidarCampos()
        {
            String resultado = "";

            // No puede hacer compras sobre viajes pasados.
            resultado += this.ValidarSiYaComproEseViaje();

            // No puede viajar a más de un destino a la vez
            resultado += this.ValidarSiHayMasDeUnDestino();

            return resultado;
        }
        private String ValidarSiYaComproEseViaje()
        {
            if (TieneUnPasajeConViajePorComprar() || TieneUnaReservaConViajePorComprar())
                return "No se puede hacer compras sobre viajes pasados.\n";

            return "";
        }

        private bool TieneUnPasajeConViajePorComprar()
        {
            int idCliente = ClienteComprador.Id;
            if (idCliente != -1)
            {
                List<Filtro> filtros = new List<Filtro>();
                filtros.Add(FiltroFactory.Exacto("cliente_id", idCliente.ToString()));
                filtros.Add(FiltroFactory.Exacto("viaje_id", ViajeElegido.Id.ToString()));

                return conexion.ExisteRegistro(Tabla.ClienteComproViaje, new List<string>(new string[] { "cliente_id" }), filtros);
            }

            return false;
        }

        private bool TieneUnaReservaConViajePorComprar()
        {
            if (ClienteComprador.Id != -1)
            {
                List<Filtro> filtros = new List<Filtro>();
                filtros.Add(FiltroFactory.Exacto("cliente_id", ClienteComprador.Id.ToString()));
                filtros.Add(FiltroFactory.Exacto("viaje_id", ViajeElegido.Id.ToString()));

                return conexion.ExisteRegistro(Tabla.ClienteReservoViaje, new List<string>(new string[] { "cliente_id" }), filtros);
            }

            return false;
        }

        private string ValidarSiHayMasDeUnDestino()
        {
            if (ClienteComprador.Id != -1)
            {
                List<Filtro> filtros = new List<Filtro>();
                filtros.Add(FiltroFactory.Exacto("cliente_id", ClienteComprador.Id.ToString()));
                filtros.Add(FiltroFactory.MenorIgual("FECHA_DE_INICIO", "'" + ViajeElegido.FechaInicio.ToString("yyyy-MM-dd") + "'"));
                filtros.Add(FiltroFactory.MayorIgual("FECHA_DE_FIN_ESTIMADA", "'" + ViajeElegido.FechaInicio.ToString("yyyy-MM-dd") + "'"));

                if (conexion.ExisteRegistro(Tabla.ClienteReservoViaje, new List<string>(new string[] { "cliente_id" }), filtros)
                    || conexion.ExisteRegistro(Tabla.ClienteComproViaje, new List<string>(new string[] { "cliente_id" }), filtros))
                    return "No puede viajar a más de un destino a la vez.\n";
            }

            return "";
        }

    }

}
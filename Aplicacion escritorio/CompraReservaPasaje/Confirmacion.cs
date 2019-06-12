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
        private Conexion conexion = new Conexion();
        private int NumeroOperacion;

        public Confirmacion(int cantPasajes, Viaje viajeElegido, string idPuertoOrigen, string idPuertoDestino, Cliente cliente, double precioTotal, MetodoDePago medioDePago, string tipoDeOperacion)
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
            {
                NumeroOperacion = ObtenerCodigoDeOperacion(Tabla.Pasaje);
                lblNumero.Text = "Numero de compra: " + NumeroOperacion.ToString();
            }
            else
            {
                NumeroOperacion = ObtenerCodigoDeOperacion(Tabla.Reserva);
                lblNumero.Text = "Numero de reserva: " + NumeroOperacion.ToString();
            }

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
            LlenarDGVTramos();

            List<Filtro> filtrosCrucero = new List<Filtro>();
            filtrosCrucero.Add(FiltroFactory.Exacto("ID", ViajeElegido.Cabinas.First().Crucero_id.ToString()));

            List<string> campos = new List<string>();
            campos.Add("modelo");
            campos.Add("fabricante");
            campos.Add("identificador");

            Dictionary<string, List<object>> crucero = conexion.ConsultaPlana(Tabla.Crucero, campos, filtrosCrucero);

            lblIdeCrucero.Text += crucero["identificador"].First().ToString();
            lblFabricanteCrucero.Text += crucero["fabricante"].First().ToString();
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

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            new MedioDePago(CantidadDePasajes, ViajeElegido, IdPuertoOrigen, IdPuertoDestino, ClienteComprador, PrecioTotal).Show();
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            // Se obtienen los datos que se van a insertar
            Dictionary<string, object> datosMetodoDePago = ObtenerDatosMetodoDePago();

            Cabina cabina = ObtenerCabina();

            Dictionary<string, object> datosOperacion = ObtenerDatosOperacion(cabina);
            Dictionary<string, object> datosViaje = ObtenerDatosViaje();
            Dictionary<string, object> datosCabina = ObtenerDatosCabina(cabina);


            Transaccion tr = conexion.IniciarTransaccion();

            // Se Inserta el Cliente en caso de que no exista
            if (ClienteComprador.Id == -1)
            {
                Dictionary<string, object> datos = new Dictionary<string, object>();

                datos["fecha_inicio"] = ClienteComprador.FechaDeNacimiento;
                datos["telefono"] = ClienteComprador.Telefono;
                datos["nombre"] = ClienteComprador.Telefono;
                datos["apellido"] = ClienteComprador.Apellido;
                datos["DNI"] = ClienteComprador.Dni;
                datos["mail"] = ClienteComprador.Direccion;
                datos["puntos"] = 0;

                tr.Insertar(Tabla.Cliente, datos);
            }

            // Se inserta metodo de pago
            int idMetodoDePago = tr.Insertar(Tabla.MedioDePago, datosMetodoDePago);


            datosOperacion["medio_de_pago_id"] = idMetodoDePago;

            if (TipoDeOperacion == "COMPRA")
            {
                // Se inserta una compra
                datosOperacion["codigo"] = ObtenerCodigoDeOperacion(Tabla.Pasaje);
                tr.Insertar(Tabla.Pasaje, datosMetodoDePago);
            }
            else
            {
                // Se inserta una reserva
                datosOperacion["codigo"] = ObtenerCodigoDeOperacion(Tabla.Reserva);
                tr.Insertar(Tabla.Reserva, datosMetodoDePago);
            }

            // Se suma al viaje elegido por el usuario la cantidad de pasajes vendidos 
            tr.Modificar(ViajeElegido.Id, Tabla.Viaje, datosViaje);

            // Se marca a la cabina como ocupada
            tr.Modificar(cabina.Id, Tabla.Cabina, datosCabina);

            tr.Commit();


            MessageBox.Show("Se ha hecho la compra correctamente!", "Compra confirmada");
        }

        private Cabina ObtenerCabina()
        {
            List<Filtro> filtros = new List<Filtro>();
            filtros.Add(FiltroFactory.Exacto("viaje_id", ViajeElegido.Id.ToString()));
            filtros.Add(FiltroFactory.Exacto("tipo_id", ViajeElegido.Cabinas.First().Tipo_id.ToString()));
            filtros.Add(FiltroFactory.Exacto("ocupado", "0"));

            Dictionary<string, List<object>> cabinasVacias = conexion.ConsultaPlana(Tabla.Cabina, new List<string>(new string[] { "*" }), filtros);

            Cabina cabina = new Cabina();

            Random random = new Random();
            int indiceCabinaRandom = random.Next(0, random.Next(0, cabinasVacias["ID"].Count()));

            cabina.Id = Convert.ToInt16(cabinasVacias["ID"][indiceCabinaRandom]);
            cabina.Crucero_id = Convert.ToInt16(cabinasVacias["crucero_id"][indiceCabinaRandom]);
            cabina.Viaje_id = Convert.ToInt16(cabinasVacias["viaje_id"][indiceCabinaRandom]);
            cabina.Tipo_id = Convert.ToInt16(cabinasVacias["tipo_id"][indiceCabinaRandom]);
            cabina.NumeroPiso = Convert.ToInt16(cabinasVacias["numero_piso"][indiceCabinaRandom]);
            cabina.NumeroHabitacion = Convert.ToInt16(cabinasVacias["numero_habitacion"][indiceCabinaRandom]);
            cabina.Ocupado = false;

            return cabina;
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
            while (codigos["codigo"].Any(c => Convert.ToInt32(c) == codigoGenerado));

            return codigoGenerado;
        }

        // --------------------------------------------------OBTENER DATOS--------------------------------------------
        private Dictionary<string, object> ObtenerDatosMetodoDePago()
        {
            Dictionary<string, object> datosMetodoDePago = new Dictionary<string, object>();

            datosMetodoDePago["tipo"] = MedioDePago.Tipo;
            datosMetodoDePago["numero_de_tarjeta"] = MedioDePago.NumeroTarjeta;

            return datosMetodoDePago;
        }

        private Dictionary<string, object> ObtenerDatosOperacion(Cabina cabina)
        {
            Dictionary<string, object> datosOperacion = new Dictionary<string, object>();

            datosOperacion["cliente_id"] = ClienteComprador.Id;
            datosOperacion["precio"] = PrecioTotal;
            datosOperacion["cabina_id"] = cabina.Id;
            datosOperacion["fecha_de_compra"] = FrbaCrucero.ConfigurationHelper.FechaActual;

            return datosOperacion;
        }

        private Dictionary<string, object> ObtenerDatosViaje()
        {
            Dictionary<string, object> datosViaje = new Dictionary<string, object>();

            datosViaje["ID"] = ViajeElegido.Id;
            datosViaje["fecha_inicio"] = ViajeElegido.FechaInicio;
            // datosViaje["fecha_fin"] = null; // TODO ver si va
            datosViaje["fecha_fin_estimada"] = ViajeElegido.Fecha_Fin_Estimada;
            datosViaje["pasajes_vendidos"] = ViajeElegido.PasajesVendidos + CantidadDePasajes;
            datosViaje["recorrido_id"] = ViajeElegido.Recorrido_id;

            return datosViaje;
        }

        private Dictionary<string, object> ObtenerDatosCabina(Cabina cabina)
        {
            Dictionary<string, object> datosCabina = new Dictionary<string, object>();

            datosCabina["ID"] = cabina.Id;
            datosCabina["crucero_id"] = cabina.Crucero_id;
            datosCabina["viaje_id"] = cabina.Viaje_id;
            datosCabina["tipo_id"] = cabina.Tipo_id;
            datosCabina["numero_piso"] = cabina.NumeroPiso;
            datosCabina["numero_habitacion"] = cabina.NumeroHabitacion;
            datosCabina["ocupado"] = 0;

            return datosCabina;
        }

    }

}
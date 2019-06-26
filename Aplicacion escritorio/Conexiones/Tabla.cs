using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexiones
{
    public static class Tabla
    {
        public static string Usuario { get { return "PINKIE_PIE.[Usuario]"; } }
        public static string Rol { get { return "PINKIE_PIE.[Rol]"; } }
        public static string Funcion { get { return "PINKIE_PIE.[Funcion]"; } }
        public static string RolXFuncion { get { return "PINKIE_PIE.[Rol_X_Funcion]"; }}
        public static string UsuarioXRol { get { return "PINKIE_PIE.[usuario_X_rol]"; } }
        public static string RolesUsuario { get { return "PINKIE_PIE.[Roles_usuario]"; } }
        public static string FuncionesUsuarios { get { return "PINKIE_PIE.[funciones_usuarios]"; } }
        public static string FechaFueraServicio { get { return "PINKIE_PIE.[fecha_fuera_servicio]"; } }
        public static string Recorrido { get { return "PINKIE_PIE.[Recorrido]"; } }
        public static string Tramo { get { return "PINKIE_PIE.[Tramo]"; } }
        public static string Tramo_X_Recorrido { get { return "PINKIE_PIE.[Tramo_X_Recorrido]"; } }
        public static string Puerto { get { return "PINKIE_PIE.[Puerto]"; } }
        public static string Crucero { get { return "PINKIE_PIE.[Crucero]"; } }
        public static string Fabricante { get { return "PINKIE_PIE.[Fabricante]"; } }
        public static string Cabina { get { return "PINKIE_PIE.[Cabina]"; } }
        public static string Reserva { get { return "PINKIE_PIE.[Reserva]"; } }
        public static string Pasaje { get { return "PINKIE_PIE.[Pasaje]"; } }
        public static string Piso { get { return "PINKIE_PIE.[Piso]"; } }
        public static string Viaje { get { return "PINKIE_PIE.[Viaje]"; } }
        public static string Tipo { get { return "PINKIE_PIE.[Tipo]"; } }
        public static string MedioDePago { get { return "PINKIE_PIE.[MedioDePago]"; } }
        public static string Top5RecorridosPasajes { get { return "PINKIE_PIE.top_5_recorridos"; } }
        public static string Top5PuntosClientes { get { return "PINKIE_PIE.top_5_clientes_puntos"; } }
        public static string Top5ViajesCabinasVacias { get { return "PINKIE_PIE.top_5_viajes_cabinas_vacias"; } }
        public static string Top5CrucerosFueraServicio { get { return "PINKIE_PIE.top_5_dias_crucero_fuera_servicio"; } }
        public static string Cliente { get { return "PINKIE_PIE.[Cliente]"; } }
        public static string Fuera_Servicio { get { return "PINKIE_PIE.[fecha_fuera_servicio]"; } }
        public static string RecorridosParaGridView { get { return "PINKIE_PIE.[RecorridosParaGridView]"; } }
        public static string TramosParaGridView { get { return "PINKIE_PIE.[TramosParaGridView]"; } }
        public static string TramoConDescripcion { get { return "PINKIE_PIE.[TramoConDescripcion]"; } }
        public static string ViajesConCrucero { get { return "PINKIE_PIE.[ViajesConCrucero]"; } }
        public static string ViajesEnFechaYOrigenDestino { get { return "PINKIE_PIE.[ViajesEnFechaYOrigenDestino]"; } }
        public static string ViajesDisponiblesGridView { get { return "PINKIE_PIE.[ViajesDisponiblesGridView]"; } }
        public static string CabinasDisponiblesGridView { get { return "PINKIE_PIE.[CabinasDisponiblesGridView]"; } }
        public static string CabinasDeCrucero { get { return "PINKIE_PIE.[CabinasDeCrucero]"; } }
        public static string ClienteComproViaje { get { return "PINKIE_PIE.[ClienteComproViaje]"; } }
        public static string ClienteReservoViaje { get { return "PINKIE_PIE.[ClienteReservoViaje]"; } }
    }

}

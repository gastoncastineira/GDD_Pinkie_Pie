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
        public static string Recorrido { get { return "PINKIE_PIE.[Recorrido]"; } }
        public static string Tramo { get { return "PINKIE_PIE.[Tramo]"; } }
        public static string Tramo_X_Recorrido { get { return "PINKIE_PIE.[Tramo_X_Recorrido]"; } }
        public static string Puerto { get { return "PINKIE_PIE.[Puerto]"; } }
        public static string Crucero { get { return "PINKIE_PIE.[Crucero]"; } }
        public static string Cabina { get { return "PINKIE_PIE.[Cabina]"; } }
        public static string Piso { get { return "PINKIE_PIE.[Piso]"; } }
    }
}

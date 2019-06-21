using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexiones
{
    static class PinkieLogger
    {
        private static string path = "pinkie_log.txt";

        public static void EscribirArchivo(string mensaje)
        {
            using (StreamWriter f = File.AppendText(path))
            {
                f.WriteLine("["+DateTime.Now.ToLongTimeString()+"]-"+mensaje);
                f.Close();
            }
        }

        private static void ConsultaConDatos(string mensaje, Dictionary<string, object> datos, string operacion)
        {
            string datosString = mensaje + Environment.NewLine;
            datosString += ("Se genera "+operacion+" con los datos:");
            foreach (KeyValuePair<string, object> par in datos)
            {
                datosString += Environment.NewLine;
                if (par.Value is DateTime)
                    datosString += par.Key + " = " + ((DateTime)par.Value).ToString("yyyy-MM-dd");
                else
                    datosString += par.Key + " = " + par.Value.ToString();
            }
            EscribirArchivo(datosString);
        }

        public static void logInsert(string consulta, Dictionary<string, object> datos)
        {
            ConsultaConDatos("Se genera el siguiente insert: "+ consulta, datos, "insert");
        }

        public static void logSelect(string consulta, string operacion)
        {
            EscribirArchivo("Se genera el siguiente select para "+operacion+": " + consulta);
        }

        public static void logUpdate(string consulta, Dictionary<string, object> datos)
        {
            ConsultaConDatos("Se genera el siguiente update: "+ consulta, datos, "update");
        }

        public static void logExcepcion(Exception ex)
        {
            EscribirArchivo("SE GENERO EXCEPCION"+ Environment.NewLine + ex.ToString());
        }
    }
}

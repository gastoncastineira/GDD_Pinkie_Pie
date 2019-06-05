using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexiones
{
    public static class FiltroFactory
    {
        public static Filtro Libre(string columna, string valor)
        {
            return new Filtro(columna, "LIKE '%" + valor + "%'");
        }
        public static Filtro Exacto(string columna, string valor)
        {
            return new Filtro(columna, " = '" + valor + "'");
        }
        public static Filtro Distinto(string columna, string valor)
        {
            return new Filtro(columna, " != '" + valor + "'");
        }
        public static Filtro Between(string columna, string menor, string mayor)
        {
            return new Filtro(columna, "BETWEEN " + menor + " AND " + mayor);
        }
        public static Filtro MenorIgual(string columna, string valor)
        {
            return new Filtro(columna, "<= " + valor);
        }
        internal static Filtro MayorIgual(string columna, string valor)
        {
            return new Filtro(columna, ">= " + valor);
        }
        public static Filtro Contenido(string columna, List<string> valoresList)
        {
            string valor = "";
            foreach (string id in valoresList)
            {
                valor = valor + id + ", ";
            }
            return new Filtro(columna, " in (" + valor.TrimEnd(' ').TrimEnd(',') + ") ");
        }
    }
}

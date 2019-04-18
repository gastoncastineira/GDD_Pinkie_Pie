using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero
{
    public static class ConfigurationHelper
    {
        public static string ConnectionString { get { return Properties.Cruceros.Default.ConnectionString; } }
        public static DateTime FechaActual { get { return Properties.Cruceros.Default.fechaActual; } }
    }
}

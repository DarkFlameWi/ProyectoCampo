using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEG_62_RS.Excepciones
{
    public class PermisoDuplicadoExcepcion_62_RS : Exception
    {
        public string NombrePermiso_62_RS { get; private set; }

        public PermisoDuplicadoExcepcion_62_RS (string nombrePermiso) : base()
        {
            NombrePermiso_62_RS = nombrePermiso;
        }
    }
}

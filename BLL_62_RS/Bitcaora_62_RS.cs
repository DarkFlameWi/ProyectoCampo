using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_62_RS
{
    public class Bitcaora_62_RS
    {
        private DAL_62_RS.Bitacora_62_RS dalBitacora_62_RS = new DAL_62_RS.Bitacora_62_RS();

        public int InsertarBitacora_62_RS(string usuario, string descripcion, string modulo, string criticida)
        {

            BE_62_RS.Bitacora_62_RS bitacora = new BE_62_RS.Bitacora_62_RS
            {
                Usu_62_RS = usuario,
                FechaCambio_62_RS = DateTime.Now,
                Descripcion_62_RS = descripcion,
                Modulo_62_RS = modulo,
                Criticidad_62_RS = criticida
            };
            return dalBitacora_62_RS.insertarbitacora_62_RS(bitacora);

        }

    }
}

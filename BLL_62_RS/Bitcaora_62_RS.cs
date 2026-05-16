using System;
using System.Collections.Generic;
using System.Data;
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

            SEG_62_RS.Bitacora_62_RS bitacora = new SEG_62_RS.Bitacora_62_RS
            {
                Usu_62_RS = usuario,
                FechaCambio_62_RS = DateTime.Now,
                Descripcion_62_RS = descripcion,
                Modulo_62_RS = modulo,
                Criticidad_62_RS = criticida
            };
            return dalBitacora_62_RS.insertarbitacora_62_RS(bitacora);

        }

        public DataTable ListarBitacora_62_RS()
        {
            try
            {
                DataTable dt_62_RS = dalBitacora_62_RS.ListarBitacora_62_RS();

                if (dt_62_RS == null || dt_62_RS.Rows.Count == 0)
                {

                }
                return dt_62_RS;
            }
            catch (Exception ex_62_RS)
            {
                throw new Exception("Error al procesar la lista de usuarios: " + ex_62_RS.Message);
            }
        }

    }
}

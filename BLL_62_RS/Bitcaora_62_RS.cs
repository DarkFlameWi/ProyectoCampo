using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEG_62_RS.Singleton;

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
            int idGenerado = dalBitacora_62_RS.insertarbitacora_62_RS(bitacora);
            bitacora.IdBitacora_62_RS = idGenerado;
            SEG_62_RS.DigitoVerificador_62_RS motorDV = new SEG_62_RS.DigitoVerificador_62_RS();
            bitacora.Dvh_62_RS = motorDV.CalcularDVH_62_RS(bitacora);
            dalBitacora_62_RS.ActualizarDVH_62_RS(idGenerado, bitacora.Dvh_62_RS);
            BLL_62_RS.DVV_62_RS gestorDvv = new BLL_62_RS.DVV_62_RS();
            gestorDvv.RecalcularDVVTabla_62_RS("Bitacora_62_RS");
            return idGenerado;
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
                string msjTraducido = SingletonSession_62_RS.Instancia_62_RS.IdiomaActual_62_RS.Traducciones_62_RS["Exc_BLL_ErrorProcesarBitacora"];
                throw new Exception(msjTraducido + ex_62_RS.Message);
            }
        }

        public DataTable FiltrarBitacora_62_RS(string login, string modulo, string evento, string criticidad, DateTime desde, DateTime hasta)
        {
            if (desde > hasta)
            {
                string msjValidacion = SingletonSession_62_RS.Instancia_62_RS.IdiomaActual_62_RS.Traducciones_62_RS["Exc_BLL_ErrorFechaDesdeMayorHasta"];
                throw new Exception(msjValidacion);
            }
            return dalBitacora_62_RS.FiltrarBitacora_62_RS(login, modulo, evento, criticidad, desde, hasta);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_62_RS
{
    public class DVV_62_RS
    {
        private DAL_62_RS.DVV_62_RS dalDvv_62_RS = new DAL_62_RS.DVV_62_RS();

        public void RecalcularDVVTabla_62_RS(string nombreTabla_62_RS)
        {
            try
            {
                List<int> listaDvhs = dalDvv_62_RS.ObtenerTodosLosDVH_62_RS(nombreTabla_62_RS);
                SEG_62_RS.DigitoVerificador_62_RS motorDV = new SEG_62_RS.DigitoVerificador_62_RS();
                int sumaTotalDvv = motorDV.CalcularDVV_62_RS(listaDvhs);
                dalDvv_62_RS.ActualizarSumaDVV_62_RS(nombreTabla_62_RS, sumaTotalDvv);
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo de integridad al recalcular DVV: " + ex.Message);
            }
        }
    }
}

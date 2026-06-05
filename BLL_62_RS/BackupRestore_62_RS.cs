using SEG_62_RS.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_62_RS
{
    public class BackupRestore_62_RS
    {
        private DAL_62_RS.BackupRestore_62_RS dalBackup_62_RS = new DAL_62_RS.BackupRestore_62_RS();
        private BLL_62_RS.Bitcaora_62_RS bllBitacora_62_RS = new BLL_62_RS.Bitcaora_62_RS();
        private string Traducir(string clave)
        {
            var idiomaActual = SingletonSession_62_RS.Instancia_62_RS.IdiomaActual_62_RS;
            if (idiomaActual != null && idiomaActual.Traducciones_62_RS.ContainsKey(clave))
            {
                return idiomaActual.Traducciones_62_RS[clave];
            }
            return clave;
        }

        public void RealizarBackup_62_RS(string directorioDestino_62_RS)
        {
            if (string.IsNullOrWhiteSpace(directorioDestino_62_RS) || !Directory.Exists(directorioDestino_62_RS))
            {
                throw new Exception(Traducir("Exc_BLL_DirInvalido"));
            }
            string timestamp_62_RS = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string nombreArchivo_62_RS = $"Backup_ProyectoCampo_{timestamp_62_RS}.bak";
            string rutaFinal_62_RS = Path.Combine(directorioDestino_62_RS, nombreArchivo_62_RS);

            try
            {
                dalBackup_62_RS.GenerarBackup_62_RS(rutaFinal_62_RS);
                string usuario_62_RS = SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS?.UsU_62_RS ?? "Sistema";
                bllBitacora_62_RS.InsertarBitacora_62_RS(usuario_62_RS, "Generar BackUp" + nombreArchivo_62_RS, "Administracion", "3");
            }
            catch (Exception ex_62_RS)
            {
                throw new Exception(Traducir("Exc_BLL_ErrorBackup") + ex_62_RS.Message);
            }
        }

        public void RealizarRestore_62_RS(string rutaArchivoBak_62_RS)
        {
            if (string.IsNullOrWhiteSpace(rutaArchivoBak_62_RS) || !File.Exists(rutaArchivoBak_62_RS))
            {
                throw new Exception(Traducir("Exc_BLL_ArchivoInvalido"));
            }

            try
            {
                dalBackup_62_RS.GenerarRestore_62_RS(rutaArchivoBak_62_RS);
                string usuario_62_RS = SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS?.UsU_62_RS ?? "Sistema";
                bllBitacora_62_RS.InsertarBitacora_62_RS(usuario_62_RS, "Realizar Restore", "Administracion", "4");
            }
            catch (Exception ex_62_RS)
            {
                throw new Exception(Traducir("Exc_BLL_ErrorRestore") + ex_62_RS.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace BLL_62_RS
{
    public class Idioma_62_RS
    {
        public SEG_62_RS.Observer.Idioma_62_RS CargarIdioma_62_RS(string codigoCultura)
        {
            SEG_62_RS.Observer.Idioma_62_RS idioma = new SEG_62_RS.Observer.Idioma_62_RS();
            idioma.Nombre_62_RS = codigoCultura;

            try
            {
                string rutaBase = AppDomain.CurrentDomain.BaseDirectory;
                string rutaArchivo = Path.Combine(rutaBase, "Idiomas", $"{codigoCultura}.json");

                if (File.Exists(rutaArchivo))
                {
                    string json = File.ReadAllText(rutaArchivo);
                    idioma.Traducciones_62_RS = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                }
                else
                {
                    throw new Exception($"No se encontró el archivo de idioma en: {rutaArchivo}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar el idioma: " + ex.Message);
            }

            return idioma;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEG_62_RS.Composite
{
    public abstract class Permiso_62_RS
    {
        public int Id_62_RS { get; set; }
        public string Nombre_62_RS { get; set; }
        public Permiso_62_RS(string nombre)
        {
            Nombre_62_RS = nombre;
        }
        public abstract void AgregarHijo_62_RS(Permiso_62_RS permiso);
        public abstract void QuitarHijo_62_RS(Permiso_62_RS permiso);
        public abstract IList<Permiso_62_RS> ObtenerHijos_62_RS();
        public abstract IList<Patente_62_RS> ObtenerTodasLasPatentes_62_RS();
        public abstract bool ValidarPermiso_62_RS(int idPermiso);
    }
}

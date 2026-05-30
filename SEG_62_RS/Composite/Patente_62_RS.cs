using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEG_62_RS.Composite
{
    public class Patente_62_RS : Permiso_62_RS
    {
        public Patente_62_RS(string nombre) : base(nombre) { }
        public override void AgregarHijo_62_RS(Permiso_62_RS permiso)
        {
            throw new Exception("No se pueden agregar permisos adentro de una patente individual.");
        }
        public override void QuitarHijo_62_RS(Permiso_62_RS permiso)
        {
            throw new Exception("No se pueden quitar permisos de una patente individual.");
        }
        public override IList<Permiso_62_RS> ObtenerHijos_62_RS()
        {
            return new List<Permiso_62_RS>();
        }
        public override bool Existe_62_RS(Permiso_62_RS permiso)
        {
            return this.Id_62_RS == permiso.Id_62_RS;
        }
    }
}

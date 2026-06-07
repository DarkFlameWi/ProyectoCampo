using SEG_62_RS.Excepciones;
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
            throw new OperacionInvalidaExcepcion_62_RS();
        }
        public override void QuitarHijo_62_RS(Permiso_62_RS permiso)
        {
            throw new OperacionInvalidaExcepcion_62_RS();
        }
        public override IList<Permiso_62_RS> ObtenerHijos_62_RS()
        {
            return new List<Permiso_62_RS>();
        }
        public override IList<Patente_62_RS> ObtenerTodasLasPatentes_62_RS()
        {
            return new List<Patente_62_RS> { this };
        }
        public override bool ValidarPermiso_62_RS(int idPermiso)
        {
            return this.Id_62_RS == idPermiso;
        }
    }
}

using SEG_62_RS.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEG_62_RS.Composite
{
    public class Rol_62_RS : Permiso_62_RS, IVerificable_62_RS
    {
        private List<Permiso_62_RS> _hijos_62_RS;
        public string Descripcion_62_RS { get; set; }
        public int? Dvh_62_RS { get; set; }

        public Rol_62_RS(string nombre) : base(nombre)
        {
            _hijos_62_RS = new List<Permiso_62_RS>();
        }

        public override void AgregarHijo_62_RS(Permiso_62_RS permiso)
        {
            var misPatentes = this.ObtenerTodasLasPatentes_62_RS();
            var patentesNuevas = permiso.ObtenerTodasLasPatentes_62_RS();

            foreach (var pNueva in patentesNuevas)
            {
                if (misPatentes.Any(p => p.Id_62_RS == pNueva.Id_62_RS))
                {
                    throw new PermisoDuplicadoExcepcion_62_RS(pNueva.Nombre_62_RS);
                }
            }
            _hijos_62_RS.Add(permiso);
        }

        public override void QuitarHijo_62_RS(Permiso_62_RS permiso)
        {
            _hijos_62_RS.Remove(permiso);
        }

        public override IList<Permiso_62_RS> ObtenerHijos_62_RS()
        {
            return _hijos_62_RS;
        }

        public override IList<Patente_62_RS> ObtenerTodasLasPatentes_62_RS()
        {
            var patentes = new List<Patente_62_RS>();
            foreach (var hijo in _hijos_62_RS)
            {
                patentes.AddRange(hijo.ObtenerTodasLasPatentes_62_RS());
            }
            return patentes;
        }

        public override bool ValidarPermiso_62_RS(int idPermiso)
        {
            if (this.Id_62_RS == idPermiso) return true;

            foreach (var hijo in _hijos_62_RS)
            {
                if (hijo.ValidarPermiso_62_RS(idPermiso)) return true;
            }
            return false;
        }

        public string GenerarCadenaDVH_62_RS()
        {
            return $"{this.Id_62_RS}{this.Nombre_62_RS}{this.Descripcion_62_RS}";
        }
    }
}

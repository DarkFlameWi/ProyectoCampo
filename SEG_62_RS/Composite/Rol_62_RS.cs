using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEG_62_RS.Composite
{
    public class Rol_62_RS : Permiso_62_RS
    {
        private List<Permiso_62_RS> _hijos_62_RS;

        public Rol_62_RS(string nombre) : base(nombre)
        {
            _hijos_62_RS = new List<Permiso_62_RS>();
        }

        public override void AgregarHijo_62_RS(Permiso_62_RS permiso)
        {
            if (!Existe_62_RS(permiso))
            {
                _hijos_62_RS.Add(permiso);
            }
            else
            {
                throw new Exception($"El permiso '{permiso.Nombre_62_RS}' ya está asignado a este Rol.");
            }
        }

        public override void QuitarHijo_62_RS(Permiso_62_RS permiso)
        {
            _hijos_62_RS.Remove(permiso);
        }

        public override IList<Permiso_62_RS> ObtenerHijos_62_RS()
        {
            return _hijos_62_RS;
        }

        public override bool Existe_62_RS(Permiso_62_RS permiso)
        {
            if (this.Id_62_RS == permiso.Id_62_RS) return true;

            foreach (var hijo in _hijos_62_RS)
            {
                if (hijo.Existe_62_RS(permiso)) return true;
            }

            return false;
        }
    }
}

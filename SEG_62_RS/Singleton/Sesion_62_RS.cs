using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEG_62_RS.Singleton
{
    public class Sesion_62_RS
    {
        Iusuario_62_RS _usuario_62_RS;

        public Iusuario_62_RS Usuario_62_RS
        {
            get { return _usuario_62_RS; }
        }

        public void IniciarSesion_62_RS(Iusuario_62_RS usuario_62_RS)
        {
            _usuario_62_RS = usuario_62_RS;
        }

        public void CerrarSesion_62_RS()
        {
            _usuario_62_RS = null;
        }

        public bool EstaAutenticado_62_RS()
        {
            return _usuario_62_RS != null;
        }
    }
}

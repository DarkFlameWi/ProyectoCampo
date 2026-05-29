using SEG_62_RS.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEG_62_RS.Singleton
{
    public class Sesion_62_RS
    {
        Usuario_62_RS _usuario_62_RS;

        public Idioma_62_RS IdiomaActual_62_RS { get; private set; }
        private List<IObservadorIdioma_62_RS> _observadores_62_RS = new List<IObservadorIdioma_62_RS>();

        public Usuario_62_RS Usuario_62_RS
        {
            get { return _usuario_62_RS; }
        }

        public void IniciarSesion_62_RS(Usuario_62_RS usuario_62_RS)
        {
            _usuario_62_RS = usuario_62_RS;
        }

        public void CerrarSesion_62_RS()
        {
            _usuario_62_RS = null;
            _observadores_62_RS.Clear();
        }

        public bool EstaAutenticado_62_RS()
        {
            return _usuario_62_RS != null;
        }
        public void SuscribirObservador_62_RS(IObservadorIdioma_62_RS observador)
        {
            if (!_observadores_62_RS.Contains(observador))
                _observadores_62_RS.Add(observador);
        }

        public void DesuscribirObservador_62_RS(IObservadorIdioma_62_RS observador)
        {
            if (_observadores_62_RS.Contains(observador))
                _observadores_62_RS.Remove(observador);
        }

        private void NotificarObservadores_62_RS()
        {
            foreach (var obs in _observadores_62_RS)
            {
                obs.ActualizarIdioma_62_RS(IdiomaActual_62_RS);
            }
        }

        public void CambiarIdioma_62_RS(Idioma_62_RS nuevoIdioma)
        {
            IdiomaActual_62_RS = nuevoIdioma;
            NotificarObservadores_62_RS();
        }

    }
}

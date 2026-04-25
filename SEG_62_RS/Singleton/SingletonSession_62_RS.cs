using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEG_62_RS.Singleton
{
    public class SingletonSession_62_RS
    {
        private static Sesion_62_RS _instancia_62_RS;

        private static object _lock_62_RS = new object();

        public static Sesion_62_RS Instancia_62_RS
        {
            get
            {
                lock (_lock_62_RS)
                {
                    if (_instancia_62_RS == null)
                    {
                        _instancia_62_RS = new Sesion_62_RS();
                    }
                }
                return _instancia_62_RS;
            }
               
        }
    }

    
}

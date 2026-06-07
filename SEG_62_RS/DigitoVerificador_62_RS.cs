using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEG_62_RS
{
    public class DigitoVerificador_62_RS
    {
        public int ConvertToAscii_62_RS(string input)
        {
            if (string.IsNullOrEmpty(input)) return 0;

            int asciiValueSum = 0;
            foreach (char c in input)
            {
                asciiValueSum += (int)c;
            }

            return asciiValueSum;
        }
        public int CalcularDVV_62_RS(List<int> todosLosDvh)
        {
            int dvv = 0;
            foreach (int dvh in todosLosDvh)
            {
                dvv += dvh;
            }
            return dvv;
        }
    }
}

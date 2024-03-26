using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaparcial
{
    class Temperatura
    {
        int codigo;
        int temp;
        DateTime fechaLectura;

        public int Codigo { get => codigo; set => codigo = value; }
        public int Temp { get => temp; set => temp = value; }
        public DateTime FechaLectura { get => fechaLectura; set => fechaLectura = value; }
    }
}

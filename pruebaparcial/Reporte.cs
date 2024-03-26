using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaparcial
{
    internal class Reporte
    {
        string nombre;
        int temp;
        DateTime fecha;

        public string Nombre { get => nombre; set => nombre = value; }
        public int Temp { get => temp; set => temp = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }
}

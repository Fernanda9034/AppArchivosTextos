using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppArchivosTextos
{
    class Libro
    {
        private string nombre;
        private double precio;

        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public Libro()
        {
            nombre = "";
            precio = 0;
        }
        public override string ToString()
        {
            return nombre + "-" + precio;
        }
    }
}

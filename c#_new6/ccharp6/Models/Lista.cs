using System;
using System.Collections.Generic;

namespace ccharp6.Models
{
    public class Lista
    {
        public int id { get; set; }
        public string tipo { get; set; } = null!;
        public string nombre { get; set; } = null!;
        public double cantidad { get; set; }
        public string descripcion { get; set; } = null!;
    }
}

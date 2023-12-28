using System;
using System.Collections.Generic;

namespace ccharp6.Models
{
    public partial class Colacion
    {
        public Colacion()
        {
            ColacionIngredientes = new HashSet<ColacionIngrediente>();
        }

        public int Id { get; set; }
        public int DietaColacionId { get; set; }
        public string TipoComida { get; set; } = null!;

        public virtual DietaColacion DietaColacion { get; set; } = null!;
        public virtual ICollection<ColacionIngrediente> ColacionIngredientes { get; set; }
    }
}


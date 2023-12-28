using System;
using System.Collections.Generic;

namespace ccharp6.Models
{
    public partial class IngredientesImagen
    {
        public IngredientesImagen()
        {
            ColacionIngredientes = new HashSet<ColacionIngrediente>();
        }

        public int Id { get; set; }
        public string? ImagenUrl { get; set; }
        public string? Nombre { get; set; }
        public string? Tipo { get; set; }

        public virtual ICollection<ColacionIngrediente> ColacionIngredientes { get; set; }
    }
}

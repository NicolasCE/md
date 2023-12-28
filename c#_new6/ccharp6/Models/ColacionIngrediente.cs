using System;
using System.Collections.Generic;

namespace ccharp6.Models
{
    public partial class ColacionIngrediente
    {
        public int Id { get; set; }
        public int IdColacion { get; set; }
        public int IdIngredientesImagen { get; set; }
        public string? Tipo { get; set; }
        public string? Nombre { get; set; }
        public string? Cantidad { get; set; }

        public virtual Colacion IdColacionNavigation { get; set; } = null!;
        public virtual IngredientesImagen IdIngredientesImagenNavigation { get; set; } = null!;
    }
}

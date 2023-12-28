using System;
using System.Collections.Generic;

namespace ccharp6.Models
{
    public partial class Comentario
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int? IdDietaColacion { get; set; }

        public virtual DietaColacion? IdDietaColacionNavigation { get; set; }
    }
}

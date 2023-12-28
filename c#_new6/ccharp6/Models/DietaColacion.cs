using System;
using System.Collections.Generic;

namespace ccharp6.Models
{
    public partial class DietaColacion
    {
        public DietaColacion()
        {
            Colacions = new HashSet<Colacion>();
            Comentarios = new HashSet<Comentario>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? TipoVegan { get; set; }
        public string? TipoComida { get; set; }
        public int? PacienteId { get; set; }

        public virtual Paciente? Paciente { get; set; }
        public virtual ICollection<Colacion> Colacions { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}

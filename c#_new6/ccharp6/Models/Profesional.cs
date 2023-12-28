using System;
using System.Collections.Generic;

namespace ccharp6.Models
{
    public partial class Profesional
    {
        public Profesional()
        {
            SeguimientoCita = new HashSet<SeguimientoCitum>();
        }

        public int Id { get; set; }
        public string Rut { get; set; } = null!;
        public string? Nombre { get; set; }
        public string? Especialidad { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<SeguimientoCitum> SeguimientoCita { get; set; }
    }
}

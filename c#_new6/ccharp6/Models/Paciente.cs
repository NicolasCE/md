using System;
using System.Collections.Generic;

namespace ccharp6.Models
{
    public partial class Paciente
    {
        public Paciente()
        {
            DietaColacions = new HashSet<DietaColacion>();
            SeguimientoCita = new HashSet<SeguimientoCitum>();
        }

        public int Id { get; set; }
        public string? Rut { get; set; }
        public string? Nombre { get; set; }
        public string? FechaNac { get; set; }
        public string? Sexo { get; set; }
        public int? Edad { get; set; }
        public double? Peso { get; set; }
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }
        public string? Apellidos { get; set; }
        public string? Correo { get; set; }
        public int? Telefono { get; set; }

        public virtual ICollection<DietaColacion> DietaColacions { get; set; }
        public virtual ICollection<SeguimientoCitum> SeguimientoCita { get; set; }
    }
}

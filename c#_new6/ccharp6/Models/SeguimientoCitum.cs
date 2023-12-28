using System;
using System.Collections.Generic;

namespace ccharp6.Models
{
    public partial class SeguimientoCitum
    {
        public int Id { get; set; }
        public DateOnly? Fecha { get; set; }
        public string? Peso { get; set; }
        public string? Estatura { get; set; }
        public string? Observacion { get; set; }
        public int IdPaciente { get; set; }
        public int IdProfesional { get; set; }

        public virtual Paciente IdPacienteNavigation { get; set; } = null!;
        public virtual Profesional IdProfesionalNavigation { get; set; } = null!;
    }
}

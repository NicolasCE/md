using System;
using System.Collections.Generic;

namespace ccharp6.Models
{
    public class Datos
    {

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? TipoVegan { get; set; }
        public string? TipoComida { get; set; }
        public int? PacienteId { get; set; }
        public List<Lista> ingredientes { get; set; } 
    }
}
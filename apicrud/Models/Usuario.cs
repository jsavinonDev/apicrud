using System;
using System.Collections.Generic;

namespace apicrud.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
    }
}

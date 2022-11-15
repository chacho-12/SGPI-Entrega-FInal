using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class Documento
    {
        public Documento()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Iddoc { get; set; }
        public string? TipoDocumento { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}

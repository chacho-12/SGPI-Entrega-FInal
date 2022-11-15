using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Programacions = new HashSet<Programacion>();
        }

        public int Idusuario { get; set; }
        public string NumeroDocumento { get; set; } = null!;
        public int Iddoc { get; set; }
        public string PrimerNombre { get; set; } = null!;
        public string PrimerApellido { get; set; } = null!;
        public string SegundoApellido { get; set; } = null!;
        public int Idgenero { get; set; }
        public string Email { get; set; } = null!;
        public int Idrol { get; set; }
        public string Password { get; set; } = null!;
        public int Idprograma { get; set; }

        public virtual Documento IddocNavigation { get; set; } = null!;
        public virtual Genero IdgeneroNavigation { get; set; } = null!;
        public virtual Programa IdprogramaNavigation { get; set; } = null!;
        public virtual Rol IdrolNavigation { get; set; } = null!;
        public virtual ICollection<Programacion> Programacions { get; set; }
    }
}

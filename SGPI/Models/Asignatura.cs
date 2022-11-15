using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class Asignatura
    {
        public Asignatura()
        {
            Homologacions = new HashSet<Homologacion>();
            Programacions = new HashSet<Programacion>();
        }

        public int Idasignatura { get; set; }
        public string Nombre { get; set; } = null!;
        public string Codigo { get; set; } = null!;
        public int Idprograma { get; set; }
        public int Nivel { get; set; }
        public int Creditos { get; set; }

        public virtual Programa IdprogramaNavigation { get; set; } = null!;
        public virtual ICollection<Homologacion> Homologacions { get; set; }
        public virtual ICollection<Programacion> Programacions { get; set; }
    }
}

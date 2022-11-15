using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Homologacions = new HashSet<Homologacion>();
        }

        public int Idestudiante { get; set; }
        public string Archivo { get; set; } = null!;
        public int Idpago { get; set; }
        public int Idusuario { get; set; }
        public bool Egresado { get; set; }

        public virtual ICollection<Homologacion> Homologacions { get; set; }
    }
}

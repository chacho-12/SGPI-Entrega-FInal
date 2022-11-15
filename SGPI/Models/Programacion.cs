using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class Programacion
    {
        public int Idprogramacion { get; set; }
        public string PeriodoAcademico { get; set; } = null!;
        public int Idprograma { get; set; }
        public DateTime FechaProgramacion { get; set; }
        public string Sala { get; set; } = null!;
        public int Idasignatura { get; set; }
        public int Idusuario { get; set; }

        public virtual Asignatura IdasignaturaNavigation { get; set; } = null!;
        public virtual Programa IdprogramaNavigation { get; set; } = null!;
        public virtual Usuario IdusuarioNavigation { get; set; } = null!;
    }
}

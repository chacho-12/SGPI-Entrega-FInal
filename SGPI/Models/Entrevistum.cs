using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class Entrevistum
    {
        public int Identrevista { get; set; }
        public int Idusuario { get; set; }
        public int Idestudiante { get; set; }
        public DateTime Fecha { get; set; }
    }
}

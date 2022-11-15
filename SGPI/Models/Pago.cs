using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class Pago
    {
        public int Idpago { get; set; }
        public int ValorPago { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }
    }
}

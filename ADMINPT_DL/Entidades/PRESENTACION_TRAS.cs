using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.DL.Modelo
{
    public class PRESENTACION_TRAS
    {
        public int ID_PRESEN_TRAS { get; set; }
        public string NOMBRE_PRESEN_TRAA { get; set; }
        public Boolean ESTADO { get; set; }
        public string USUARIO_CREA { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public string USUARIO_ACT { get; set; }
        public DateTime FECHA_ACT { get; set; }
        public double FKG { get; set; }
        public double FQQ { get; set; }
        public double FJB { get; set; }
        public double FG { get; set; }
        public double FSACO { get; set; }
        public double FMT { get; set; }
    }
}

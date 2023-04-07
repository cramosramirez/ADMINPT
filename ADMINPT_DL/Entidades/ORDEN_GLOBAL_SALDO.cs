using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.DL.Modelo
{
    public class ORDEN_GLOBAL_SALDO
    {
        public int ID_ORDEN_SALDO { get; set; }
        public int ID_ORDEN_TRAS { get; set; }
        public DateTime FECHA { get; set; }
        public double NASIGNACIONO { get; set; }
        public double ASIGNACIONO { get; set; }
        public double AMPLIACIONES { get; set; }
        public double ASIGNACIONT { get; set; }
        public double EJECUTADO { get; set; }
        public double SALDO { get; set; }
        public string OBSERVACION { get; set; }
        public string USUARIO_CREA { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public string USUARIO_ACT { get; set; }
        public DateTime FECHA_ACT { get; set; }
    }
}

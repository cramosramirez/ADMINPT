using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.DL.Modelo
{
    public class TIPO_CONCEPTO
    {
        public int ID_TIPO_CONCEPTO { get; set; }
        public string NOMBRE_CONCEPTO { get; set; }
        public Boolean ES_ENTRADA { get; set; }
        public Boolean ES_SALIDA { get; set; }
        public Boolean ESTADO { get; set; }
        public string USUARIO_CREA { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public string USUARIO_ACT { get; set; }
        public DateTime FECHA_ACT { get; set; }
    }
}

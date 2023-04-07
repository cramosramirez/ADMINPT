using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.DL.Modelo
{
    public class DOCUMENTO_ANULADO
    {
        public int ID_DOCUMENTO_ANUL { get; set; }
        public int ID_DOCUMENTO_NUM { get; set; }
        public int ID_ES_ENCA { get; set; }
        public int ID_ZAFRA { get; set; }
        public int NUMDOCUMENTO { get; set; }
        public DateTime FECHA_ANULACION { get; set; }
        public string MOTIVO_ANULACION { get; set; }
        public string USUARIO_CREA { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public string USUARIO_ACT { get; set; }
        public DateTime FECHA_ACT { get; set; }
    }
}

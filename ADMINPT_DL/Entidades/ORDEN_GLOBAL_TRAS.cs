using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.DL.Modelo
{
    public class ORDEN_GLOBAL_TRAS
    {
        public int ID_ORDEN_TRAS { get; set; }
        public int COD_CAPTURA { get; set; }
        public DateTime FECHA { get; set; }
        public int ID_SOLICITANTE { get; set; }
        public int ID_BODEGAO { get; set; }
        public int ID_BODEGAD { get; set; }
        public int ID_TIPO_MOV { get; set; }
        public int ID_CONCE { get; set; }
        public int ID_ESPECI { get; set; }
        public int ID_REF { get; set; }
        public int NUMREF { get; set; }
        public int ID_ZAFRA_PROD { get; set; }
        public int ID_PRODUCTO { get; set; }
        public double ASIGNACIONO { get; set; }
        public double AMPLIACIONES { get; set; }
        public double ASIGNACIONT { get; set; }        
        public double EJECUTADO { get; set; }
        public double SALDO { get; set; }
        public string OBSERVACION { get; set; }
        public Boolean ESTADO { get; set; }
        public string USUARIO_CREA { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public string USUARIO_ACT { get; set; }
        public DateTime FECHA_ACT { get; set; }
        public Boolean ES_PROPIO { get; set; }
        public Boolean ES_AJENO { get; set; }
        public int ID_ESTADO { get; set; }
        public string NOMBREDT { get; set; }
    }
}



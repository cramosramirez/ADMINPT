using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.DL.Modelo
{
    public class MOVIMIENTO_DETA
    {
        public int ID_DETA { get; set; }
        public int ID_ENCA { get; set; }
        public int ID_PRODUCTO { get; set; }
        public int ID_TIPO_CONCEPTO { get; set; }
        public int ID_PRESEN_TRAS { get; set; }
        public int ID_PRESEN_VTA { get; set; }
        public int ID_UNIDAD_CONSAA { get; set; }
        public int ID_UNIDAD_FAC { get; set; }
        public System.Guid REFERENCIA_DETA { get; set; }
        public decimal FACTOR_QQ { get; set; }
        public decimal FACTOR_KG { get; set; }
        public decimal TARIMA { get; set; }
        public decimal SACOS { get; set; }
        public decimal QUINTALES { get; set; }
        public decimal KILOGRAMOS { get; set; }
        public decimal GALONES { get; set; }
        public string USUARIO_CREA { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public string USUARIO_ACT { get; set; }
        public DateTime FECHA_ACT { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.DL.Modelo
{
    public class KARDEX
    {
		public int ID_KARDEX { get; set; }
        public int ID_BODEGAO { get; set; }
        public int ID_BODEGAD { get; set; }
        public int ID_TIPO_MOV { get; set; }
        public int ID_CONCE { get; set; }
        public int ID_ESPECI { get; set; }
        public Boolean ES_PROPIO { get; set; }
        public Boolean ES_AJENO { get; set; }
        public DateTime FECHA { get; set; }
        public string  NUM_DOC { get; set; }
        public int ID_ZAFRA_PROD { get; set; }
        public int ID_ZAFRA_ACTUAL { get; set; }
        public int ID_PRODUCTO { get; set; }
        public System.Guid REFERENCIA { get; set; }
    public int ID_PRESEN_TRAS { get; set; }
    public int ID_UNIDAD_FAC { get; set; }
        public Double CANTIDAD { get; set; }
        public Double FACTOR_QQ { get; set; }
        public Double FACTOR_KG { get; set; }
        public Double SDOINI_QQ { get; set; }
        public Double SDOINI_KG { get; set; }
        public Double SDOINI_GAL { get; set; }
        public Double ENTRADA_QQ { get; set; }
        public Double ENTRADA_KG { get; set; }
        public Double ENTRADA_GAL { get; set; }
        public Double SALIDA_QQ { get; set; }
        public Double SALIDA_KG { get; set; }
        public Double SALIDA_GAL { get; set; }
        public Double SDOFIN_QQ { get; set; }
        public Double SDOFIN_KG { get; set; }
        public Double SDOFIN_GAL { get; set; }
      

        public string USUARIO_CREA { get; set; }
		public DateTime FECHA_CREA { get; set; }
		public string USUARIO_ACT { get; set; }
		public DateTime FECHA_ACT { get; set; }
        public int ID_BODEGAK { get; set; }
        public string NOMBRE { get; set; }
        public int ID_BODEGA { get; set; }
        public Double EXISTENCIA_BODE { get; set; }
        public string PRESENTACION { get; set; }

    }
}

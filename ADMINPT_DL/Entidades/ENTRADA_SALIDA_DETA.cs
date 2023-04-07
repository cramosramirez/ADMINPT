using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.DL.Modelo
{
    public class ENTRADA_SALIDA_DETA
    {
        public int ID_ES_DETA { get; set; }
		public int ID_ES_ENCA { get; set; }
		public int ID_PRODUCTO { get; set; }
		public int ID_PRESEN_TRAS { get; set; }
		public int ID_UNIDAD_FAC { get; set; }
		public Double CANTIDAD { get; set; }
		public Double FACTOR { get; set; }		
		public System.Guid REFERENCIA_DETA { get; set; }
		public string USUARIO_CREA { get; set; }
		public DateTime FECHA_CREA { get; set; }
		public string USUARIO_ACT { get; set; }
		public DateTime FECHA_ACT { get; set; }
		public Double FACTORKG { get; set; }
		public Double QUINTALES { get; set; }
		public Double KILOGRAMOS { get; set; }
		public Double GALONES { get; set; }
		public int ID_BODEP { get; set; }
		public DateTime FECHA { get; set; }
		public string NUM_DOC { get; set; }
	}
}

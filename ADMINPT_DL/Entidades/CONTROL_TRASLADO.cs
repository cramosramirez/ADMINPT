using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.DL.Entidades
{
    public class CONTROL_TRASLADO
    {
		public int ID_CONTROL_TRAS { get; set; }
		public int ID_ES_ENCA { get; set; }
		public int ID_ES_DETA { get; set; }
		public string NUM_DOC { get; set; }
		public int ID_ORDEN_TRAS { get; set; }
		public int ID_ESTADO { get; set; }
		public string NOM_ESTADO { get; set; }
		public int ID_UNIDAD_FAC { get; set; }
		public string NOM_UNIDAD { get; set; }
		public string PLACA_CABEZAL { get; set; }
		public int CANTIDAD { get; set; }
		public int QUINTALES { get; set; }
		public int KILOGRAMOS { get; set; }
		public int GALONES { get; set; }
		public string OBSERVACION { get; set; }
	    public string BODEGA_DESTINO { get; set; }
	    public string NOM_ZAFRA { get; set; }
	    public string PRESENACION_TRAS { get; set; }
	    public string NOM_PRODUCTO { get; set; }
        public string USUARIO_CREA { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public string USUARIO_ACT { get; set; }
        public DateTime FECHA_ACT { get; set; }

    }
}

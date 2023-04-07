using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.DL.Entidades
{
   public  class DOCTO_ENCA
    {
	    public int ID_ENCA { get; set; }
		public int ID_TIPO { get; set; }
		public int CODIQR { get; set; }
		public int NO_DOCTO { get; set; }
		public int ID_BODEGA { get; set; }
		public int ID_ZAFRA_ACT { get; set; }
		public int ID_ZAFRA_DES { get; set; }
		public DateTime FECHA { get; set; }
		public string NRC { get; set; }
		public string GIRO { get; set; }
		public string NIT { get; set; }
		public string DUI { get; set; }
		public string DEPARTAMENTO { get; set; }
		public string MUNICIPIO { get; set; }
		public string DIRECCION { get; set; }
		public string NACIONALIDAD { get; set; }
		public string NOTA { get; set; }
		public string PROVEEDOR_TRA { get; set; }
		public string TRANSPORTE { get; set; }
		public string MOTORISTA { get; set; }
		public string NIT_MOTORISTA { get; set; }
		public string CLIENTE_FINAL { get; set; }

		public int ID_BODEGA_DEST { get; set; }
		public int ID_TIPO_MOV { get; set; }
		public int ID_CONCE { get; set; }
		public int ID_ESPECI { get; set; }
		public int ID_ESTADO { get; set; }
		public string ESTADO { get; set; }
		public int ID_ORDEN_TRAS { get; set; }
	}
}

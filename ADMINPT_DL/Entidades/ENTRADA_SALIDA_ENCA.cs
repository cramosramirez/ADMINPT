using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.DL.Modelo
{
    public class ENTRADA_SALIDA_ENCA
    {
        public int ID_ES_ENCA { get; set; }
		public int COD_CAPTURA { get; set; }
		public DateTime FECHA { get; set; }
		public Boolean ES_PROPIO { get; set; }
		public Boolean ES_AJENO { get; set; }
		public int ID_ZAFRA_PROD { get; set; }
		public int ID_ZAFRA_ACTUAL { get; set; }
		public int ID_TIPO_MOV { get; set; }
		public int ID_CONCE { get; set; }
		public int ID_ESPECI { get; set; }
		public int ID_BODEGAO { get; set; }
		public int ID_BODEGAD { get; set; }
		public System.Guid REFERENCIA_DETA { get; set; }
		public string USUARIO_CREA { get; set; }
		public DateTime FECHA_CREA { get; set; }
		public string USUARIO_ACT { get; set; }
		public DateTime FECHA_ACT { get; set; }
		public string NUM_DOC { get; set; }
		public int ID_ESTADO { get; set; }
		public int ID_ORDEN_TRAS { get; set; }

		public int ID_PROV_TRAS { get; set; }
		public int ID_TRANSPORTE { get; set; }
		public string MOTORISTA { get; set; }
		public string NIT { get; set; }
		public string PLACA_CABEZAL { get; set; }
		public string PLACA_REMOLQUE { get; set; }
		public string CONTENEDOR { get; set; }
		public string MARCHAMOS { get; set; }
		public string OBSERVACION { get; set; }
		public int ID_PRODUCTO { get; set; }
		public string NFORMULARIO { get; set; }
		public string ENCCLIENTE { get; set; }
		public string ENCNIT { get; set; }
		public string ENCNRC { get; set; }
		public string ENCDEPARTAMENTO { get; set; }
		public string ENCMUNICIPIO { get; set; }
		public string ENCGIRO { get; set; }
		public string ENCDIRECCION { get; set; }
		public DateTime FECHADESPACHO { get; set; }
		public int ID_TIPO { get; set; }
		public string ULT_NUM_ASIGNADO { get; set; }
		public int ID_BODEP { get; set; }
		public int ID_FMPAGO { get; set; }
		public Double EFECTIVO { get; set; }
		public Double CHEQUE { get; set; }
		public Double NOTAABONO { get; set; }
		public Double TOTAL { get; set; }
		public string NCUENTA { get; set; }
		public string NCHEQUE { get; set; }
		public string BANCO { get; set; }
		public string ID_ESTIBA { get; set; }
		public string TENDIDO { get; set; }
		public Nullable<System.DateTime> FECHA_PRODUCCION { get; set; }
		public Nullable<System.DateTime> FECHA_PRODUCCION1 { get; set; }
		public Double COLOR { get; set; }
		public Double MCHEQUE { get; set; }
		public Double MNOTAABONO { get; set; }
	}
}

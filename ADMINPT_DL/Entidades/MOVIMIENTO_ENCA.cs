using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.DL.Modelo
{
    public class MOVIMIENTO_ENCA
    {
	public int ID_ENCA { get; set; }
	public int ID_BODEGA { get; set; }
	public DateTime FECHA { get; set; }
	public int ID_ZAFRA_ACTUAL { get; set; }
	public int ID_ZAFRA_PROD { get; set; }
	public int ID_DIA_ZAFRA { get; set; }
	public int ID_TURNO { get; set; }
	public int ID_TIPO_CONCEPTO { get; set; }
	public string OBSERVACIONES { get; set; }
	public int ID_BODEGA_TRAS { get; set; }
	public int ID_ESTADO { get; set; }
public int CORR_BODEGA { get; set; }
public string USUARIO_CREA { get; set; }
	public DateTime FECHA_CREA { get; set; }
	public string USUARIO_ACT { get; set; }
	public DateTime FECHA_ACT { get; set; }
	}
}

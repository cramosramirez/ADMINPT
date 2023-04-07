using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.DL.Entidades
{
    public class DOCTO_DETA
    {
		public int ID_DETA { get; set; }
		public int ID_ENCA { get; set; }
		public int ID_PRODUCTO { get; set; }
		public string DESCRIP_PRODUCTO { get; set; }
		public double CANTIDAD { get; set; }
		public double ENTREGADO { get; set; }
		public double SALDO { get; set; }
		public string TURNO { get; set; }
		public int NTARIMA { get; set; }
		public double FACTORQQ { get; set; }
		public double FACTORKQ { get; set; }
		public double TARA { get; set; }
		public double BRUTO { get; set; }
		public double NETO { get; set; }
		public double QUINTALES { get; set; }
		public double KGS { get; set; }
		public string NOTA { get; set; }
	}
}

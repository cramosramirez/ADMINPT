using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.DL.Modelo
{
    public class PRODUCTO_PRES_TRAS
    {
        public int ID_PROD_PRES_TRAS { get; set; }
        public int ID_PRODUCTO { get; set; }
        public int ID_PRESEN_TRAS { get; set; }
        public Boolean ESTADO { get; set; }
        public string USUARIO_CREA { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public string USUARIO_ACT { get; set; }
        public DateTime FECHA_ACT { get; set; }
    }
}

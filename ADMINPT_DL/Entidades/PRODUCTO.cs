using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.DL.Modelo
{
    public class PRODUCTO
    {
        public int ID_PRODUCTO { get; set; }
        public string CODI_PRODUCTO { get; set; }
        public string NOMBRE_PRODUCTO { get; set; }
        public string NOMBRE_KARDEX { get; set; }
        public string NOMBRE_VENTA { get; set; }
        public int ID_TIPO_PROD { get; set; }
        public int ID_UNIDAD_CONSAA { get; set; }
        public int ID_UNIDAD_FAC { get; set; }
        public int ID_MARCA { get; set; }
        public Boolean APLICA_VTA { get; set; }
        public Boolean APLICA_TRAS { get; set; }
        public decimal FACTOR { get; set; }
        public Boolean ESTADO { get; set; }
        public string USUARIO_CREA { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public string USUARIO_ACT { get; set; }
        public DateTime FECHA_ACT { get; set; }
    }
}

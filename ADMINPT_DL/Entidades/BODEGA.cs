using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.DL.Modelo
{
    public class BODEGA
    {  
        public int ID_BODEGA { get; set; } 
        public string NOMBRE { get; set; }
        public int ID_DEPARTAMENTO { get; set; }
        public int ID_MUNICIPIO { get; set; }
        public string NIT { get; set; }
        public string NRC { get; set; }
        public string GIRO { get; set; }
        public string DIRECCION { get; set; }
        public Boolean  ESTADO { get; set; }
        public string USUARIO_CREA { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public string USUARIO_ACT { get; set; }
        public DateTime FECHA_ACT { get; set; }
        public string NOMDEPARTAMENTO { get; set; }
        public string NOMMUNICIPIO { get; set; }
    }
}

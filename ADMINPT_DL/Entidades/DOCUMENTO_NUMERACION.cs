using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.DL.Modelo
{
    public class DOCUMENTO_NUMERACION
    {
        public int ID_DOCUMENTO_NUM { get; set; }
        public int ID_TIPO { get; set; }
        public int NUM_INICIAL { get; set; }
        public int NUM_FINAL { get; set; }
        public int ULT_NUM_ASIGNADO { get; set; }
      
        public Boolean ACTIVO { get; set; }
        public string USUARIO_CREA { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public string USUARIO_ACT { get; set; }
        public DateTime FECHA_ACT { get; set; }
    }
}

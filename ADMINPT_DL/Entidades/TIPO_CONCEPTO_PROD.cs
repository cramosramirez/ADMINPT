﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.DL.Modelo
{
    public class TIPO_CONCEPTO_PROD
    {
        public int ID_CONCEPTO_PROD { get; set; }
        public int ID_TIPO_CONCEPTO { get; set; }
        public int ID_TIPO_PROD { get; set; }
        public Boolean ESTADO { get; set; }
        public string USUARIO_CREA { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public string USUARIO_ACT { get; set; }
        public DateTime FECHA_ACT { get; set; }
    }
}
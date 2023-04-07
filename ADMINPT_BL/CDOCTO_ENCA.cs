using ADMINPT.DL.Entidades;
using ADMINPT.DL.Modelo;
using Microsoft.ApplicationBlocks.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.BL
{
    public class CDOCTO_ENCA
    {
        public string sError = "";

        public DOCTO_ENCA ObtenerPorId(int id)
        {
            try
            {
                DOCTO_ENCA entidad = new DOCTO_ENCA();
                using (var db = new DbDOCTO_ENCA())
                {
                    entidad = db.ObtenerPorId(id);
                }
                return entidad;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
    }
}
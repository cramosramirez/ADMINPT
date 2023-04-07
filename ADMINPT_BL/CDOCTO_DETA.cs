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
    public class CDOCTO_DETA
    {
        public string sError = "";
        public DOCTO_DETA ObtenerPorId(int id)//, long idt)
        {
            try
            {
                DOCTO_DETA entidad = new DOCTO_DETA();
                using (var db = new DbDOCTO_DETA())
                {
                    entidad = db.ObtenerPorId(id);//, idt);
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
using ADMINPT.DL.Modelo;
using Microsoft.ApplicationBlocks.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.BL
{
    public class CESPECI_MOV
    {
        public string sError = "";

        public List<ESPECI_MOV> ObtenerPorIdTC(int id)
        {
            try
            {
                List<ESPECI_MOV> lista = new List<ESPECI_MOV>();
                using (var db = new DbESPECI_MOV())
                {
                    lista = db.ObtenerPorIdTC(id);
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public ESPECI_MOV ObtenerPorId(int id)
        {
            try
            {
                ESPECI_MOV entidad = new ESPECI_MOV();
                using (var db = new DbESPECI_MOV())
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
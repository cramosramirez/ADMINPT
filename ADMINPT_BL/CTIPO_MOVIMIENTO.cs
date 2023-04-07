using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADMINPT.DL.Modelo;
using Microsoft.ApplicationBlocks.ExceptionManagement;

namespace ADMINPT.BL
{
    public class CTIPO_MOVIMIENTO
    {
        public string sError = "";


        public List<TIPO_MOVIMIENTO> ObtenerLista()
        {
            try
            {
                List<TIPO_MOVIMIENTO> lista = new List<TIPO_MOVIMIENTO>();
                using (var db = new DbTIPO_MOVIMIENTO())
                {
                    lista = db.ObtenerLista();
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public TIPO_MOVIMIENTO ObtenerPorId(int id)
        {
            try
            {
                TIPO_MOVIMIENTO entidad = new TIPO_MOVIMIENTO();
                using (var db = new DbTIPO_MOVIMIENTO())
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

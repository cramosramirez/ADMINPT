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
    public class CCONTROL_TRASLADO
    {
        public string sError = "";

        public List<CONTROL_TRASLADO> ObtenerLista()
        {
            try
            {
                List<CONTROL_TRASLADO> lista = new List<CONTROL_TRASLADO>();
                using (var db = new DbCONTROL_TRASLADO())
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
        public CONTROL_TRASLADO ObtenerPorId(int id)
        {
            try
            {
                CONTROL_TRASLADO entidad = new CONTROL_TRASLADO();
                using (var db = new DbCONTROL_TRASLADO())
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
        public int Agregar(CONTROL_TRASLADO entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbCONTROL_TRASLADO())
                {
                    lRet = db.Agregar(entidad);
                }
                return lRet;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return -1;
            }
        }
        public int Actualizar(CONTROL_TRASLADO entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbCONTROL_TRASLADO())
                {
                    lRet = db.Actualizar(entidad);
                }
                return lRet;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return -1;
            }
        }
        public int Eliminar(int id)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbCONTROL_TRASLADO())
                {
                    lRet = db.Eliminar(id);
                }
                return lRet;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return -1;
            }
        }
    }
}

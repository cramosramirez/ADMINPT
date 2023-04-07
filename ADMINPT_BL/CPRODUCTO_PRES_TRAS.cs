using ADMINPT.DL.Modelo;
using Microsoft.ApplicationBlocks.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.BL
{
    public class CPRODUCTO_PRES_TRAS
    {
        public string sError = "";

        public List<PRODUCTO_PRES_TRAS> ObtenerLista()
        {
            try
            {
                List<PRODUCTO_PRES_TRAS> lista = new List<PRODUCTO_PRES_TRAS>();
                using (var db = new DbPRODUCTO_PRES_TRAS())
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

        public PRODUCTO_PRES_TRAS ObtenerPorId(int id)
        {
            try
            {
                PRODUCTO_PRES_TRAS entidad = new PRODUCTO_PRES_TRAS();
                using (var db = new DbPRODUCTO_PRES_TRAS())
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
        public int Agregar(PRODUCTO_PRES_TRAS entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbPRODUCTO_PRES_TRAS())
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
        public int Actualizar(PRODUCTO_PRES_TRAS entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbPRODUCTO_PRES_TRAS())
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
                using (var db = new DbPRODUCTO_PRES_TRAS())
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
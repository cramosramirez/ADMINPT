using ADMINPT.DL.Modelo;
using Microsoft.ApplicationBlocks.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.BL
{
    public class CPROVEEDOR_TRAS
    {
        public string sError = "";

        public List<PROVEEDOR_TRAS> ObtenerLista()
        {
            try
            {
                List<PROVEEDOR_TRAS> lista = new List<PROVEEDOR_TRAS>();
                using (var db = new DbPROVEEDOR_TRAS())
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

        public PROVEEDOR_TRAS ObtenerPorId(int id)
        {
            try
            {
                PROVEEDOR_TRAS entidad = new PROVEEDOR_TRAS();
                using (var db = new DbPROVEEDOR_TRAS())
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
        public int Agregar(PROVEEDOR_TRAS entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbPROVEEDOR_TRAS())
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
        public int Actualizar(PROVEEDOR_TRAS entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbPROVEEDOR_TRAS())
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
                using (var db = new DbPROVEEDOR_TRAS())
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
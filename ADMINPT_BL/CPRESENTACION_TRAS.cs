using ADMINPT.DL.Modelo;
using Microsoft.ApplicationBlocks.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.BL
{
    public class CPRESENTACION_TRAS
    {
        public string sError = "";

        public List<PRESENTACION_TRAS> ObtenerLista()
        {
            try
            {
                List<PRESENTACION_TRAS> lista = new List<PRESENTACION_TRAS>();
                using (var db = new DbPRESENTACION_TRAS())
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
        public PRESENTACION_TRAS ObtenerPorId(int id)
        {
            try
            {
                PRESENTACION_TRAS entidad = new PRESENTACION_TRAS();
                using (var db = new DbPRESENTACION_TRAS())
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
        public List<PRESENTACION_TRAS> ObtenerPorIdProducto(int id)
        {
            try
            {
                List<PRESENTACION_TRAS> lista = new List<PRESENTACION_TRAS>();
                using (var db = new DbPRESENTACION_TRAS())
                {
                    lista = db.ObtenerPorIdProducto(id);
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public List<PRESENTACION_TRAS> ObtenerPorIdProductoALMAPAC(int id)
        {
            try
            {
                List<PRESENTACION_TRAS> lista = new List<PRESENTACION_TRAS>();
                using (var db = new DbPRESENTACION_TRAS())
                {
                    lista = db.ObtenerPorIdProductoALMAPAC(id);
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public int Agregar(PRESENTACION_TRAS entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbPRESENTACION_TRAS())
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
        public int Actualizar(PRESENTACION_TRAS entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbPRESENTACION_TRAS())
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
                using (var db = new DbPRESENTACION_TRAS())
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
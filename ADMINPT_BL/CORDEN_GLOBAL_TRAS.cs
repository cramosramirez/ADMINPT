using ADMINPT.DL.Modelo;
using Microsoft.ApplicationBlocks.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.BL
{
    public class CORDEN_GLOBAL_TRAS
    {
        public string sError = "";

        public List<ORDEN_GLOBAL_TRAS> ObtenerLista(int ID_BODEP)
        {
            try
            {
                List<ORDEN_GLOBAL_TRAS> lista = new List<ORDEN_GLOBAL_TRAS>();
                using (var db = new DbORDEN_GLOBAL_TRAS())
                {
                    lista = db.ObtenerLista(ID_BODEP);
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public List<ORDEN_GLOBAL_TRAS> ObtenerListaCb(int ID_BODEP)
        {
            try
            {
                List<ORDEN_GLOBAL_TRAS> lista = new List<ORDEN_GLOBAL_TRAS>();
                using (var db = new DbORDEN_GLOBAL_TRAS())
                {
                    lista = db.ObtenerListaCb(ID_BODEP);
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }

        public ORDEN_GLOBAL_TRAS ObtenerPorId(int id, int idbp)
        {
            try
            {
                ORDEN_GLOBAL_TRAS entidad = new ORDEN_GLOBAL_TRAS();
                using (var db = new DbORDEN_GLOBAL_TRAS())
                {
                    entidad = db.ObtenerPorId(id, idbp);
                }
                return entidad;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public int Agregar(ORDEN_GLOBAL_TRAS entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbORDEN_GLOBAL_TRAS())
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
        public int Actualizar(ORDEN_GLOBAL_TRAS entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbORDEN_GLOBAL_TRAS())
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
                using (var db = new DbORDEN_GLOBAL_TRAS())
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
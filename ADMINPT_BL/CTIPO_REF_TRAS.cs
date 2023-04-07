using ADMINPT.DL.Modelo;
using Microsoft.ApplicationBlocks.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.BL
{
    public class CTIPO_REF_TRAS
    {
        public string sError = "";

        public List<TIPO_REF_TRAS> ObtenerLista()
        {
            try
            {
                List<TIPO_REF_TRAS> lista = new List<TIPO_REF_TRAS>();
                using (var db = new DbTIPO_REF_TRAS())
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

        public TIPO_REF_TRAS ObtenerPorId(int id)
        {
            try
            {
                TIPO_REF_TRAS entidad = new TIPO_REF_TRAS();
                using (var db = new DbTIPO_REF_TRAS())
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
        public int Agregar(TIPO_REF_TRAS entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbTIPO_REF_TRAS())
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
        public int Actualizar(TIPO_REF_TRAS entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbTIPO_REF_TRAS())
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
                using (var db = new DbTIPO_REF_TRAS())
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
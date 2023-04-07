using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADMINPT.DL.Modelo;
using Microsoft.ApplicationBlocks.ExceptionManagement;

namespace ADMINPT.BL
{
    public class CTIPO_PRODUCTO
    {
        public string sError = "";

        public List<TIPO_PRODUCTO> ObtenerLista()
        {
            try
            {
                List<TIPO_PRODUCTO> lista = new List<TIPO_PRODUCTO>();
                using (var db = new DbTIPO_PRODUCTO())
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

        public TIPO_PRODUCTO ObtenerPorId(int id)
        {
            try
            {
                TIPO_PRODUCTO entidad = new TIPO_PRODUCTO();
                using (var db = new DbTIPO_PRODUCTO())
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
        public int Agregar(TIPO_PRODUCTO entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbTIPO_PRODUCTO())
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
        public int Actualizar(TIPO_PRODUCTO entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbTIPO_PRODUCTO())
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
                using (var db = new DbTIPO_PRODUCTO())
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

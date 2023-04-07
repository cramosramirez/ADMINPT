using ADMINPT.DL.Modelo;
using Microsoft.ApplicationBlocks.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.BL
{
    public class CTIPO_CONCEPTO
    {
        public string sError = "";

        public List<TIPO_CONCEPTO> ObtenerLista()
        {
            try
            {
                List<TIPO_CONCEPTO> lista = new List<TIPO_CONCEPTO>();
                using (var db = new DbTIPO_CONCEPTO())
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

        public TIPO_CONCEPTO ObtenerPorId(int id)
        {
            try
            {
                TIPO_CONCEPTO entidad = new TIPO_CONCEPTO();
                using (var db = new DbTIPO_CONCEPTO())
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
        public List<TIPO_CONCEPTO> ObtenerPorIdProducto(int id, int ent, int sali)
        {
            try
            {
                List<TIPO_CONCEPTO> lista = new List<TIPO_CONCEPTO>();
                using (var db = new DbTIPO_CONCEPTO())
                {
                    lista = db.ObtenerPorIdProducto(id, ent, sali);
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public int Agregar(TIPO_CONCEPTO entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbTIPO_CONCEPTO())
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
        public int Actualizar(TIPO_CONCEPTO entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbTIPO_CONCEPTO())
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
                using (var db = new DbTIPO_CONCEPTO())
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADMINPT.DL.Modelo;
using Microsoft.ApplicationBlocks.ExceptionManagement;

namespace ADMINPT.BL
{
    public class CTIPO_CONCEPTO_PROD
    {
        public string sError = "";

        public List<TIPO_CONCEPTO_PROD> ObtenerLista()
        {
            try
            {
                List<TIPO_CONCEPTO_PROD> lista = new List<TIPO_CONCEPTO_PROD>();
                using (var db = new DbTIPO_CONCEPTO_PROD())
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

        public TIPO_CONCEPTO_PROD ObtenerPorId(int id)
        {
            try
            {
                TIPO_CONCEPTO_PROD entidad = new TIPO_CONCEPTO_PROD();
                using (var db = new DbTIPO_CONCEPTO_PROD())
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

      

        public int Agregar(TIPO_CONCEPTO_PROD entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbTIPO_CONCEPTO_PROD())
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
        public int Actualizar(TIPO_CONCEPTO_PROD entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbTIPO_CONCEPTO_PROD())
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
                using (var db = new DbTIPO_CONCEPTO_PROD())
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
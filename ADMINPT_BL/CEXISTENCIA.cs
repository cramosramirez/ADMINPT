using ADMINPT.DL.Modelo;
using Microsoft.ApplicationBlocks.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.BL
{
    public class CEXISTENCIA
    {
        public string sError = "";

        public List<EXISTENCIA> ObtenerLista()
        {
            try
            {
                List<EXISTENCIA> lista = new List<EXISTENCIA>();
                using (var db = new DbEXISTENCIA())
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

        public EXISTENCIA ObtenerPorId(int id)
        {
            try
            {
                EXISTENCIA entidad = new EXISTENCIA();
                using (var db = new DbEXISTENCIA())
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

        public int Agregar(EXISTENCIA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbEXISTENCIA())
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
        public int Actualizar(EXISTENCIA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbEXISTENCIA())
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
                using (var db = new DbEXISTENCIA())
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
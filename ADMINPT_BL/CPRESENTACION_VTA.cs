using ADMINPT.DL.Modelo;
using Microsoft.ApplicationBlocks.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.BL
{
   public class CPRESENTACION_VTA
    {
        public string sError = "";

        public List<PRESENTACION_VTA> ObtenerLista()
        {
            try
            {
                List<PRESENTACION_VTA> lista = new List<PRESENTACION_VTA>();
                using (var db = new DbPRESENTACION_VTA())
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
        public PRESENTACION_VTA ObtenerPorId(int id)
        {
            try
            {
                PRESENTACION_VTA entidad = new PRESENTACION_VTA();
                using (var db = new DbPRESENTACION_VTA())
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
        public List<PRESENTACION_VTA> ObtenerPorIdProducto(int id)
        {
            try
            {
                List<PRESENTACION_VTA> lista = new List<PRESENTACION_VTA>();
                using (var db = new DbPRESENTACION_VTA())
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

        public int Agregar(PRESENTACION_VTA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbPRESENTACION_VTA())
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
        public int Actualizar(PRESENTACION_VTA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbPRESENTACION_VTA())
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
                using (var db = new DbPRESENTACION_VTA())
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

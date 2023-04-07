using ADMINPT.DL.Modelo;
using Microsoft.ApplicationBlocks.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.BL
{
   public class CPRODUCTO_PRES_VTA
    {
        public string sError = "";

        public List<PRODUCTO_PRES_VTA> ObtenerLista()
        {
            try
            {
                List<PRODUCTO_PRES_VTA> lista = new List<PRODUCTO_PRES_VTA>();
                using (var db = new DbPRODUCTO_PRES_VTA())
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

        public PRODUCTO_PRES_VTA ObtenerPorId(int id)
        {
            try
            {
                PRODUCTO_PRES_VTA entidad = new PRODUCTO_PRES_VTA();
                using (var db = new DbPRODUCTO_PRES_VTA())
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
        public int Agregar(PRODUCTO_PRES_VTA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbPRODUCTO_PRES_VTA())
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
        public int Actualizar(PRODUCTO_PRES_VTA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbPRODUCTO_PRES_VTA())
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
                using (var db = new DbPRODUCTO_PRES_VTA())
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

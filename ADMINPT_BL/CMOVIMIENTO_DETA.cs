using ADMINPT.DL.Modelo;
using Microsoft.ApplicationBlocks.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.BL
{
    public class CMOVIMIENTO_DETA
    {
        public string sError = "";

        public List<MOVIMIENTO_DETA> ObtenerLista()
        {
            try
            {
                List<MOVIMIENTO_DETA> lista = new List<MOVIMIENTO_DETA>();
                using (var db = new DbMOVIMIENTO_DETA())
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

        public MOVIMIENTO_DETA ObtenerPorId(int id)
        {
            try
            {
                MOVIMIENTO_DETA entidad = new MOVIMIENTO_DETA();
                using (var db = new DbMOVIMIENTO_DETA())
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
        public int Agregar(MOVIMIENTO_DETA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbMOVIMIENTO_DETA())
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
        public int Actualizar(MOVIMIENTO_DETA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbMOVIMIENTO_DETA())
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
                using (var db = new DbMOVIMIENTO_DETA())
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
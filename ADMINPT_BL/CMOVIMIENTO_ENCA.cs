using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADMINPT.DL.Modelo;
using Microsoft.ApplicationBlocks.ExceptionManagement;

namespace ADMINPT.BL
{
    public class CMOVIMIENTO_ENCA
    {
        public string sError = "";

        public List<MOVIMIENTO_ENCA> ObtenerLista()
        {
            try
            {
                List<MOVIMIENTO_ENCA> lista = new List<MOVIMIENTO_ENCA>();
                using (var db = new DbMOVIMIENTO_ENCA())
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
        public List<MOVIMIENTO_ENCA> ObtenerListaSali()
        {
            try
            {
                List<MOVIMIENTO_ENCA> lista = new List<MOVIMIENTO_ENCA>();
                using (var db = new DbMOVIMIENTO_ENCA())
                {
                    lista = db.ObtenerListaSali();
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public MOVIMIENTO_ENCA ObtenerPorId(int id)
        {
            try
            {
                MOVIMIENTO_ENCA entidad = new MOVIMIENTO_ENCA();
                using (var db = new DbMOVIMIENTO_ENCA())
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
        public int Agregar(ref MOVIMIENTO_ENCA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbMOVIMIENTO_ENCA())
                {
                    lRet = db.Agregar(ref entidad);
                }
                return lRet;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return -1;
            }
        }
        public int Actualizar(ref MOVIMIENTO_ENCA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbMOVIMIENTO_ENCA())
                {
                    lRet = db.Actualizar(ref entidad);
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
                using (var db = new DbMOVIMIENTO_ENCA())
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


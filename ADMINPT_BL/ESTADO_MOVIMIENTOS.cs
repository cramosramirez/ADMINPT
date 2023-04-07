using ADMINPT.DL.Modelo;
using Microsoft.ApplicationBlocks.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.BL
{
    public class CESTADO_MOVIMIENTOS
    {
        public string sError = "";

        public List<ESTADO_MOVIMIENTOS> ObtenerLista()
        {
            try
            {
                List<ESTADO_MOVIMIENTOS> lista = new List<ESTADO_MOVIMIENTOS>();
                using (var db = new DbESTADO_MOVIMIENTOS())
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

        public ESTADO_MOVIMIENTOS ObtenerPorId(int id)
        {
            try
            {
                ESTADO_MOVIMIENTOS entidad = new ESTADO_MOVIMIENTOS();
                using (var db = new DbESTADO_MOVIMIENTOS())
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
        public int Agregar(ESTADO_MOVIMIENTOS entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbESTADO_MOVIMIENTOS())
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
        public int Actualizar(ESTADO_MOVIMIENTOS entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbESTADO_MOVIMIENTOS())
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
                using (var db = new DbESTADO_MOVIMIENTOS())
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
using ADMINPT.DL.Modelo;
using Microsoft.ApplicationBlocks.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.BL
{
    public class CORDEN_GLOBAL_SALDO
    {
        public string sError = "";

        public List<ORDEN_GLOBAL_SALDO> ObtenerLista()
        {
            try
            {
                List<ORDEN_GLOBAL_SALDO> lista = new List<ORDEN_GLOBAL_SALDO>();
                using (var db = new DbORDEN_GLOBAL_SALDO())
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

        public ORDEN_GLOBAL_SALDO ObtenerPorId(int id)
        {
            try
            {
                ORDEN_GLOBAL_SALDO entidad = new ORDEN_GLOBAL_SALDO();
                using (var db = new DbORDEN_GLOBAL_SALDO())
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
        public int Agregar(ORDEN_GLOBAL_SALDO entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbORDEN_GLOBAL_SALDO())
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
        public int Actualizar(ORDEN_GLOBAL_SALDO entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbORDEN_GLOBAL_SALDO())
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
                using (var db = new DbORDEN_GLOBAL_SALDO())
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
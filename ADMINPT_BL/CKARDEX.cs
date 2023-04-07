using ADMINPT.DL.Modelo;
using Microsoft.ApplicationBlocks.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.BL
{
    public class CKARDEX
    {
        public string sError = "";

        public List<KARDEX> ObtenerLista()
        {
            try
            {
                List<KARDEX> lista = new List<KARDEX>();
                using (var db = new DbKARDEX())
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

        public KARDEX ObtenerPorId(int id)
        {
            try
            {
                KARDEX entidad = new KARDEX();
                using (var db = new DbKARDEX())
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
        public List<KARDEX> ObtenerPorIdBodega(long ID_PRODUCTO)
        {
            try
            {
                List<KARDEX> lista = new List<KARDEX>();
                using (var db = new DbKARDEX())
                {
                    lista = db.ObtenerPorIdBodega(ID_PRODUCTO);
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }

           
        }
        public List<KARDEX> ObtenerPorIdBodegaOT(long ID_PRODUCTO)
        {
            try
            {
                List<KARDEX> lista = new List<KARDEX>();
                using (var db = new DbKARDEX())
                {
                    lista = db.ObtenerPorIdBodegaOT(ID_PRODUCTO);
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }


        }
        public KARDEX ObtenerPorIdBodegaExist(long ID_PRODUCTO, long ID_ZAFRA_PROD, long ID_BODEGA, DateTime FECHA)
        {
            try
            {
                KARDEX entidad = new KARDEX();
                using (var db = new DbKARDEX())
                {
                    entidad = db.ObtenerPorIdBodegaExist(ID_PRODUCTO,ID_ZAFRA_PROD,ID_BODEGA, FECHA);
                }
                return entidad;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }

        public int Agregar(KARDEX entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbKARDEX())
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
        public int Actualizar(KARDEX entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbKARDEX())
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
                using (var db = new DbKARDEX())
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
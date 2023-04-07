using ADMINPT.DL.Modelo;
using Microsoft.ApplicationBlocks.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.BL
{
    public class CBODEGA
    {
        public string sError = "";

        public List<BODEGA> ObtenerLista()
        {
            try
            {
                List<BODEGA> lista = new List<BODEGA>();
                using (var db = new DbBODEGA())
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
        public List<BODEGA> ObtenerListaBodegaOrigen(long ID_BODEP, long ID_PRODUCTO)
        {
            try
            {
                List<BODEGA> lista = new List<BODEGA>();
                using (var db = new DbBODEGA())
                {
                    lista = db.ObtenerListaBodegaOrigen(ID_BODEP, ID_PRODUCTO);
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public List<BODEGA> ObtenerListaBodegaOrigenP(long ID_BODEP, long ID_PRODUCTO)
        {
            try
            {
                List<BODEGA> lista = new List<BODEGA>();
                using (var db = new DbBODEGA())
                {
                    lista = db.ObtenerListaBodegaOrigenP(ID_BODEP, ID_PRODUCTO);
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public List<BODEGA> ObtenerListaBodegaDestino(long ID_BODEP, long ID_PRODUCTO)
        {
            try
            {
                List<BODEGA> lista = new List<BODEGA>();
                using (var db = new DbBODEGA())
                {
                    lista = db.ObtenerListaBodegaDestino(ID_BODEP, ID_PRODUCTO);
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public List<BODEGA> ObtenerListaBodegaDestinoP(long ID_BODEP, long ID_PRODUCTO)
        {
            try
            {
                List<BODEGA> lista = new List<BODEGA>();
                using (var db = new DbBODEGA())
                {
                    lista = db.ObtenerListaBodegaDestinoP(ID_BODEP, ID_PRODUCTO);
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public List<BODEGA> ObtenerListaBodegaOrdenG()
        {
            try
            {
                List<BODEGA> lista = new List<BODEGA>();
                using (var db = new DbBODEGA())
                {
                    lista = db.ObtenerListaBodegaOrdenG();
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }


        public BODEGA ObtenerPorId(int id)
        {
            try
            {
                BODEGA entidad = new BODEGA();
                using (var db = new DbBODEGA())
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
        public int Agregar(BODEGA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbBODEGA())
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
        public int Actualizar(BODEGA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbBODEGA())
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
                using (var db = new DbBODEGA())
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

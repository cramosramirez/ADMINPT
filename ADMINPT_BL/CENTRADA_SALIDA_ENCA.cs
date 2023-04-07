using ADMINPT.DL.Entidades;
using ADMINPT.DL.Modelo;
using Microsoft.ApplicationBlocks.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.BL
{
    public class CENTRADA_SALIDA_ENCA
    {
        public string sError = "";

        public List<ENTRADA_SALIDA_ENCA> ObtenerLista()
        {
            try
            {
                List<ENTRADA_SALIDA_ENCA> lista = new List<ENTRADA_SALIDA_ENCA>();
                using (var db = new DbENTRADA_SALIDA_ENCA())
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
        public List<ENTRADA_SALIDA_ENCA> ObtenerListaEspecial()
        {
            try
            {
                List<ENTRADA_SALIDA_ENCA> lista = new List<ENTRADA_SALIDA_ENCA>();
                using (var db = new DbENTRADA_SALIDA_ENCA())
                {
                    lista = db.ObtenerListaEspecial();
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public List<ENTRADA_SALIDA_ENCA> ObtenerListaTraslado()
        {
            try
            {
                List<ENTRADA_SALIDA_ENCA> lista = new List<ENTRADA_SALIDA_ENCA>();
                using (var db = new DbENTRADA_SALIDA_ENCA())
                {
                    lista = db.ObtenerListaTraslado();
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public List<ENTRADA_SALIDA_ENCA> ObtenerListaTrasladoCfExpres()
        {
            try
            {
                List<ENTRADA_SALIDA_ENCA> lista = new List<ENTRADA_SALIDA_ENCA>();
                using (var db = new DbENTRADA_SALIDA_ENCA())
                {
                    lista = db.ObtenerListaTrasladoCfExpres();
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public List<ENTRADA_SALIDA_ENCA> ObtenerListaTrasladoInterno()
        {
            try
            {
                List<ENTRADA_SALIDA_ENCA> lista = new List<ENTRADA_SALIDA_ENCA>();
                using (var db = new DbENTRADA_SALIDA_ENCA())
                {
                    lista = db.ObtenerListaTrasladoInterno();
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public List<ENTRADA_SALIDA_ENCA> ObtenerListaVtacDizucar()
        {
            try
            {
                List<ENTRADA_SALIDA_ENCA> lista = new List<ENTRADA_SALIDA_ENCA>();
                using (var db = new DbENTRADA_SALIDA_ENCA())
                {
                    lista = db.ObtenerListaVtacDizucar();
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public List<ENTRADA_SALIDA_ENCA> ObtenerListaVtJiboa()
        {
            try
            {
                List<ENTRADA_SALIDA_ENCA> lista = new List<ENTRADA_SALIDA_ENCA>();
                using (var db = new DbENTRADA_SALIDA_ENCA())
                {
                    lista = db.ObtenerListaVtJiboa();
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public List<ENTRADA_SALIDA_ENCA> ObtenerListaDespacho()
        {
            try
            {
                List<ENTRADA_SALIDA_ENCA> lista = new List<ENTRADA_SALIDA_ENCA>();
                using (var db = new DbENTRADA_SALIDA_ENCA())
                {
                    lista = db.ObtenerListaDespacho();
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public ENTRADA_SALIDA_ENCA ObtenerNDoc(int id, int idbg)
        {
            try
            {
                ENTRADA_SALIDA_ENCA entidad = new ENTRADA_SALIDA_ENCA();
                using (var db = new DbENTRADA_SALIDA_ENCA())
                {
                    entidad = db.ObtenerNDoc(id, idbg);
                }
                return entidad;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public ENTRADA_SALIDA_ENCA ObtenerPorId(int id)
        {
            try
            {
                ENTRADA_SALIDA_ENCA entidad = new ENTRADA_SALIDA_ENCA();
                using (var db = new DbENTRADA_SALIDA_ENCA())
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
        public ENTRADA_SALIDA_ENCA ObtenerPorIdT(int id)
        {
            try
            {
                ENTRADA_SALIDA_ENCA entidad = new ENTRADA_SALIDA_ENCA();
                using (var db = new DbENTRADA_SALIDA_ENCA())
                {
                    entidad = db.ObtenerPorIdT(id);
                }
                return entidad;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public int Agregar(ref ENTRADA_SALIDA_ENCA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbENTRADA_SALIDA_ENCA())
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
        public int Actualizar(ref ENTRADA_SALIDA_ENCA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbENTRADA_SALIDA_ENCA())
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
        public int AgregarEspecial(ref ENTRADA_SALIDA_ENCA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbENTRADA_SALIDA_ENCA())
                {
                    lRet = db.AgregarEspecial(ref entidad);
                }
                return lRet;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return -1;
            }
        }
        public int ActualizarEspecial(ref ENTRADA_SALIDA_ENCA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbENTRADA_SALIDA_ENCA())
                {
                    lRet = db.ActualizarEspecial(ref entidad);
                }
                return lRet;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return -1;
            }
        }
        public int AgregarTraslado(ref ENTRADA_SALIDA_ENCA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbENTRADA_SALIDA_ENCA())
                {
                    lRet = db.AgregarTraslado(ref entidad);
                }
                return lRet;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return -1;
            }
        }
        public int ActualizarTraslado(ref ENTRADA_SALIDA_ENCA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbENTRADA_SALIDA_ENCA())
                {
                    lRet = db.ActualizarTraslado(ref entidad);
                }
                
                return lRet;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return -1;
            }
        }
        public int AgregarTrasladoExpres(ref ENTRADA_SALIDA_ENCA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbENTRADA_SALIDA_ENCA())
                {
                    lRet = db.AgregarTrasladoExpres(ref entidad);
                }
                return lRet;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return -1;
            }
        }
        public int ActualizarTrasladoExpres(ref ENTRADA_SALIDA_ENCA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbENTRADA_SALIDA_ENCA())
                {
                    lRet = db.ActualizarTrasladoExpres(ref entidad);
                }

                return lRet;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return -1;
            }
        }
        public int AgregarVtaDizucar(ref ENTRADA_SALIDA_ENCA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbENTRADA_SALIDA_ENCA())
                {
                    lRet = db.AgregarVtaDizucar(ref entidad);
                }
                return lRet;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return -1;
            }
        }
        public int ActualizarVtaDizucar(ref ENTRADA_SALIDA_ENCA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbENTRADA_SALIDA_ENCA())
                {
                    lRet = db.ActualizarVtaDizucar(ref entidad);
                }
                return lRet;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return -1;
            }
        }
        public int AgregarVtaJiboa(ref ENTRADA_SALIDA_ENCA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbENTRADA_SALIDA_ENCA())
                {
                    lRet = db.AgregarVtaJiboa(ref entidad);
                }
                return lRet;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return -1;
            }
        }
        public int ActualizarVtaJiboa(ref ENTRADA_SALIDA_ENCA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbENTRADA_SALIDA_ENCA())
                {
                    lRet = db.ActualizarVtaJiboa(ref entidad);
                }
                return lRet;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return -1;
            }
        }
        public int ActualizarDespacho(ENTRADA_SALIDA_ENCA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbENTRADA_SALIDA_ENCA())
                {
                    lRet = db.ActualizarDespacho(entidad);
                }
                return lRet;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return -1;
            }
        }
        public int AgregarTrasladoCfExpres(ref ENTRADA_SALIDA_ENCA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbENTRADA_SALIDA_ENCA())
                {
                    lRet = db.AgregarTrasladoCfExpres(ref entidad);
                }
                return lRet;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return -1;
            }
        }
        public int ActualizarTrasladoCfExpres(ref ENTRADA_SALIDA_ENCA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbENTRADA_SALIDA_ENCA())
                {
                    lRet = db.ActualizarTrasladoCfExpres(ref entidad);
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
                using (var db = new DbENTRADA_SALIDA_ENCA())
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
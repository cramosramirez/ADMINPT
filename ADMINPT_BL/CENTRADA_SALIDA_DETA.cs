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
    public class CENTRADA_SALIDA_DETA
    {
        public string sError = "";

        public List<ENTRADA_SALIDA_DETA> ObtenerLista()
        {
            try
            {
                List<ENTRADA_SALIDA_DETA> lista = new List<ENTRADA_SALIDA_DETA>();
                using (var db = new DbENTRADA_SALIDA_DETA())
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
        public ENTRADA_SALIDA_DETA ObtenerPorId(int id)
        {
            try
            {
                ENTRADA_SALIDA_DETA entidad = new ENTRADA_SALIDA_DETA();
                using (var db = new DbENTRADA_SALIDA_DETA())
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
        public ENTRADA_SALIDA_DETA ObtenerPorIdT(int id)
        {
            try
            {
                ENTRADA_SALIDA_DETA entidad = new ENTRADA_SALIDA_DETA();
                using (var db = new DbENTRADA_SALIDA_DETA())
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
        public ENTRADA_SALIDA_DETA ObtenerPorIdEnc(int id)
        {
            try
            {
                ENTRADA_SALIDA_DETA entidad = new ENTRADA_SALIDA_DETA();
                using (var db = new DbENTRADA_SALIDA_DETA())
                {
                    entidad = db.ObtenerPorIdEnc(id);
                }
                return entidad;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public ENTRADA_SALIDA_DETA ObtenerPorIdEncT(int id)
        {
            try
            {
                ENTRADA_SALIDA_DETA entidad = new ENTRADA_SALIDA_DETA();
                using (var db = new DbENTRADA_SALIDA_DETA())
                {
                    entidad = db.ObtenerPorIdEncT(id);
                }
                return entidad;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public int Agregar(ENTRADA_SALIDA_DETA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbENTRADA_SALIDA_DETA())
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
        public int Actualizar(ENTRADA_SALIDA_DETA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbENTRADA_SALIDA_DETA())
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

        public int AgregarEspecial(ENTRADA_SALIDA_DETA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbENTRADA_SALIDA_DETA())
                {
                    lRet = db.AgregarEspecial(entidad);
                }
                return lRet;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return -1;
            }
        }
        public int ActualizarEspecial(ENTRADA_SALIDA_DETA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbENTRADA_SALIDA_DETA())
                {
                    lRet = db.ActualizarEspecial(entidad);
                }
                return lRet;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return -1;
            }
        }


        public int AgregarTraslado(ENTRADA_SALIDA_DETA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbENTRADA_SALIDA_DETA())
                {
                    lRet = db.AgregarTraslado(entidad);
                }
                return lRet;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return -1;
            }
        }
        public int ActualizarTraslado(ENTRADA_SALIDA_DETA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbENTRADA_SALIDA_DETA())
                {
                    lRet = db.ActualizarTraslado(entidad);
                }
                return lRet;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return -1;
            }
        }

        public int AgregarTrasladoExpres(ENTRADA_SALIDA_DETA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbENTRADA_SALIDA_DETA())
                {
                    lRet = db.AgregarTrasladoExpres(entidad);
                }
                return lRet;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return -1;
            }
        }
        public int ActualizarTrasladoExpres(ENTRADA_SALIDA_DETA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbENTRADA_SALIDA_DETA())
                {
                    lRet = db.ActualizarTrasladoExpres(entidad);
                }
                return lRet;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return -1;
            }
        }

        public int AgregarVtaDizucar(ENTRADA_SALIDA_DETA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbENTRADA_SALIDA_DETA())
                {
                    lRet = db.AgregarVtaDizucar(entidad);
                }
                return lRet;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return -1;
            }
        }
        public int ActualizarVtaDizucar(ENTRADA_SALIDA_DETA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbENTRADA_SALIDA_DETA())
                {
                    lRet = db.ActualizarVtaDizucar(entidad);
                }
                return lRet;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return -1;
            }
        }


        public int AgregarVtaJiboa(ENTRADA_SALIDA_DETA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbENTRADA_SALIDA_DETA())
                {
                    lRet = db.AgregarVtaJiboa(entidad);
                }
                return lRet;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return -1;
            }
        }
        public int ActualizarVtaJiboa(ENTRADA_SALIDA_DETA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbENTRADA_SALIDA_DETA())
                {
                    lRet = db.ActualizarVtaJiboa(entidad);
                }
                return lRet;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return -1;
            }
        }


        public int AgregarTrasladoCfExpres(ENTRADA_SALIDA_DETA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbENTRADA_SALIDA_DETA())
                {
                    lRet = db.AgregarTrasladoCfExpres(entidad);
                }
                return lRet;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return -1;
            }
        }
        public int ActualizarTrasladoCfExpres(ENTRADA_SALIDA_DETA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbENTRADA_SALIDA_DETA())
                {
                    lRet = db.ActualizarTrasladoCfExpres(entidad);
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
                using (var db = new DbENTRADA_SALIDA_DETA())
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
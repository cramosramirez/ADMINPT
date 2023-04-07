using ADMINPT.DL.Modelo;
using Microsoft.ApplicationBlocks.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.BL
{
    public class CZAFRA
    {
        public string sError = "";

        public List<ZAFRA> ObtenerLista()
        {
            try
            {
                List<ZAFRA> lista = new List<ZAFRA>();
                using (var db = new DbZAFRA())
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
        public List<ZAFRA> ObtenerListaActiva()
        {
            try
            {
                List<ZAFRA> lista = new List<ZAFRA>();
                using (var db = new DbZAFRA())
                {
                    lista = db.ObtenerListaActiva();
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }

        public List<ZAFRA> ObtenerListaProductActiva(int ID_PRODUCTO, string TIPO)
        {
            try
            {
                List<ZAFRA> lista = new List<ZAFRA>();
                using (var db = new DbZAFRA())
                {
                    lista = db.ObtenerListaProductActiva(ID_PRODUCTO, TIPO);
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public List<ZAFRA> ObtenerListaActivaALMAPAC()
        {
            try
            {
                List<ZAFRA> lista = new List<ZAFRA>();
                using (var db = new DbZAFRA())
                {
                    lista = db.ObtenerListaActivaALMAPAC();
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public List<ZAFRA> ObtenerListaProductALMAPAC(int ID_PRODUCTO, string TIPO)
        {
            try
            {
                List<ZAFRA> lista = new List<ZAFRA>();
                using (var db = new DbZAFRA())
                {
                    lista = db.ObtenerListaProductALMAPAC(ID_PRODUCTO, TIPO);
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public ZAFRA ObtenerPorId(int id)
        {
            try
            {
                ZAFRA entidad = new ZAFRA();
                using (var db = new DbZAFRA())
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
        public int Agregar(ZAFRA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbZAFRA())
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
        public int Actualizar(ZAFRA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbZAFRA())
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
                using (var db = new DbZAFRA())
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
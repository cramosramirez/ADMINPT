using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADMINPT.DL.Modelo;
using Microsoft.ApplicationBlocks.ExceptionManagement;

namespace ADMINPT.BL
{
    public class CPRODUCTO
    {
        public string sError = "";

        public List<PRODUCTO> ObtenerLista()
        {
            try
            {
                List<PRODUCTO> lista = new List<PRODUCTO>();
                using (var db = new DbPRODUCTO())
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
        public List<PRODUCTO> ObtenerListaConsumo()
        {
            try
            {
                List<PRODUCTO> lista = new List<PRODUCTO>();
                using (var db = new DbPRODUCTO())
                {
                    lista = db.ObtenerListaConsumo();
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public List<PRODUCTO> ObtenerListaTraslado()
        {
            try
            {
                List<PRODUCTO> lista = new List<PRODUCTO>();
                using (var db = new DbPRODUCTO())
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
        public List<PRODUCTO> ObtenerListaTrasladoC5()
        {
            try
            {
                List<PRODUCTO> lista = new List<PRODUCTO>();
                using (var db = new DbPRODUCTO())
                {
                    lista = db.ObtenerListaTrasladoC5();
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public List<PRODUCTO> ObtenerListaOrdenGlobal()
        {
            try
            {
                List<PRODUCTO> lista = new List<PRODUCTO>();
                using (var db = new DbPRODUCTO())
                {
                    lista = db.ObtenerListaOrdenGlobal();
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public List<PRODUCTO> ObtenerListaVtaDizucar()
        {
            try
            {
                List<PRODUCTO> lista = new List<PRODUCTO>();
                using (var db = new DbPRODUCTO())
                {
                    lista = db.ObtenerListaVtaDizucar();
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public List<PRODUCTO> ObtenerListaAlmapac()
        {
            try
            {
                List<PRODUCTO> lista = new List<PRODUCTO>();
                using (var db = new DbPRODUCTO())
                {
                    lista = db.ObtenerListaAlmapac();
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public List<PRODUCTO> ObtenerListaVtJiboa()
        {
            try
            {
                List<PRODUCTO> lista = new List<PRODUCTO>();
                using (var db = new DbPRODUCTO())
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

        public List<PRODUCTO> ObtenerListaVtJiboaEmpacado()
        {
            try
            {
                List<PRODUCTO> lista = new List<PRODUCTO>();
                using (var db = new DbPRODUCTO())
                {
                    lista = db.ObtenerListaVtJiboaEmpacado();
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }

        public PRODUCTO ObtenerPorId(int id)
        {
            try
            {
                PRODUCTO entidad = new PRODUCTO();
                using (var db = new DbPRODUCTO())
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
        public int Agregar(PRODUCTO entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbPRODUCTO())
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
        public int Actualizar(PRODUCTO entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbPRODUCTO())
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
                using (var db = new DbPRODUCTO())
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


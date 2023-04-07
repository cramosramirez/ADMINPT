using ADMINPT.DL.Modelo;
using Microsoft.ApplicationBlocks.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.BL
{
    public class CUNIDAD_MEDI_FAC
    {
        public string sError = "";

        public List<UNIDAD_MEDI_FAC> ObtenerLista()
        {
            try
            {
                List<UNIDAD_MEDI_FAC> lista = new List<UNIDAD_MEDI_FAC>();
                using (var db = new DbUNIDAD_MEDI_FAC())
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

        public UNIDAD_MEDI_FAC ObtenerPorId(int id)
        {
            try
            {
                UNIDAD_MEDI_FAC entidad = new UNIDAD_MEDI_FAC();
                using (var db = new DbUNIDAD_MEDI_FAC())
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
        public List<UNIDAD_MEDI_FAC> ObtenerPorIdProducto(int id)
        {
            try
            {
                List<UNIDAD_MEDI_FAC> lista = new List<UNIDAD_MEDI_FAC>();
                using (var db = new DbUNIDAD_MEDI_FAC())
                {
                    lista = db.ObtenerPorIdProducto(id);
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public List<UNIDAD_MEDI_FAC> ObtenerPorIdProductoALMAPAC(int id)
        {
            try
            {
                List<UNIDAD_MEDI_FAC> lista = new List<UNIDAD_MEDI_FAC>();
                using (var db = new DbUNIDAD_MEDI_FAC())
                {
                    lista = db.ObtenerPorIdProductoALMAPAC(id);
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public int Agregar(UNIDAD_MEDI_FAC entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbUNIDAD_MEDI_FAC())
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
        public int Actualizar(UNIDAD_MEDI_FAC entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbUNIDAD_MEDI_FAC())
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
                using (var db = new DbUNIDAD_MEDI_FAC())
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
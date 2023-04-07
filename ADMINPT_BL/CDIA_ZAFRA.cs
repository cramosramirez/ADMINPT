using ADMINPT.DL.Modelo;
using Microsoft.ApplicationBlocks.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.BL
{
    public class CDIA_ZAFRA
    {
        public string sError = "";

        public List<DIA_ZAFRA> ObtenerLista()
        {
            try
            {
                List<DIA_ZAFRA> lista = new List<DIA_ZAFRA>();
                using (var db = new DbDIA_ZAFRA())
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

        public DIA_ZAFRA ObtenerPorId(int id)
        {
            try
            {
                DIA_ZAFRA entidad = new DIA_ZAFRA();
                using (var db = new DbDIA_ZAFRA())
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
        public int Agregar(DIA_ZAFRA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbDIA_ZAFRA())
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
        public int Actualizar(DIA_ZAFRA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbDIA_ZAFRA())
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
                using (var db = new DbDIA_ZAFRA())
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

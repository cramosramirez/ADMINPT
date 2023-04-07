using ADMINPT.DL.Modelo;
using Microsoft.ApplicationBlocks.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.BL
{
    public class CUNIDAD_MEDI_CONSAA
    {
        public string sError = "";

        public List<UNIDAD_MEDI_CONSAA> ObtenerLista()
        {
            try
            {
                List<UNIDAD_MEDI_CONSAA> lista = new List<UNIDAD_MEDI_CONSAA>();
                using (var db = new DbUNIDAD_MEDI_CONSAA())
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

        public UNIDAD_MEDI_CONSAA ObtenerPorId(int id)
        {
            try
            {
                UNIDAD_MEDI_CONSAA entidad = new UNIDAD_MEDI_CONSAA();
                using (var db = new DbUNIDAD_MEDI_CONSAA())
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
        public int Agregar(UNIDAD_MEDI_CONSAA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbUNIDAD_MEDI_CONSAA())
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
        public int Actualizar(UNIDAD_MEDI_CONSAA entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbUNIDAD_MEDI_CONSAA())
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
                using (var db = new DbUNIDAD_MEDI_CONSAA())
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
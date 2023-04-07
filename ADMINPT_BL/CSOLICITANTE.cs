using ADMINPT.DL.Modelo;
using Microsoft.ApplicationBlocks.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.BL
{
    public class CSOLICITANTE
    {
        public string sError = "";

        public List<SOLICITANTE> ObtenerLista()
        {
            try
            {
                List<SOLICITANTE> lista = new List<SOLICITANTE>();
                using (var db = new DbSOLICITANTE())
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

        public SOLICITANTE ObtenerPorId(int id)
        {
            try
            {
                SOLICITANTE entidad = new SOLICITANTE();
                using (var db = new DbSOLICITANTE())
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
        public int Agregar(SOLICITANTE entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbSOLICITANTE())
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
        public int Actualizar(SOLICITANTE entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbSOLICITANTE())
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
                using (var db = new DbSOLICITANTE())
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

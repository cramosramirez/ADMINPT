using ADMINPT.DL.Modelo;
using Microsoft.ApplicationBlocks.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.BL
{
    public class CTRANSPORTE
    {
        public string sError = "";

        public List<TRANSPORTE> ObtenerLista()
        {
            try
            {
                List<TRANSPORTE> lista = new List<TRANSPORTE>();
                using (var db = new DbTRANSPORTE())
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

        public TRANSPORTE ObtenerPorId(int id)
        {
            try
            {
                TRANSPORTE entidad = new TRANSPORTE();
                using (var db = new DbTRANSPORTE())
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
        public int Agregar(TRANSPORTE entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbTRANSPORTE())
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
        public int Actualizar(TRANSPORTE entidad)
        {
            try
            {
                int lRet = 0;
                using (var db = new DbTRANSPORTE())
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
                using (var db = new DbTRANSPORTE())
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

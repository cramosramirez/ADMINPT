using ADMINPT.DL.Modelo;
using Microsoft.ApplicationBlocks.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.BL
{
    public class CCONCEPTO_MOVI
    {
        public string sError = "";

        public List<CONCEPTO_MOVI> ObtenerPorIdTM(int ID_PRODUCTO, int ID_TIPO_MOV)
        {
            try
            {
                List<CONCEPTO_MOVI> lista = new List<CONCEPTO_MOVI>();
                using (var db = new DbCONCEPTO_MOVI())
                {
                    lista = db.ObtenerPorIdTM(ID_PRODUCTO, ID_TIPO_MOV);
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }

        public List<CONCEPTO_MOVI> ObtenerPorIdTMEspcial(int ID_PRODUCTO, int ID_TIPO_MOV)
        {
            try
            {
                List<CONCEPTO_MOVI> lista = new List<CONCEPTO_MOVI>();
                using (var db = new DbCONCEPTO_MOVI())
                {
                    lista = db.ObtenerPorIdTMEspcial(ID_PRODUCTO, ID_TIPO_MOV);
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }

        public List<CONCEPTO_MOVI> ObtenerPorIdTMTraslado(int ID_PRODUCTO, int ID_TIPO_MOV)
        {
            try
            {
                List<CONCEPTO_MOVI> lista = new List<CONCEPTO_MOVI>();
                using (var db = new DbCONCEPTO_MOVI())
                {
                    lista = db.ObtenerPorIdTMTraslado(ID_PRODUCTO, ID_TIPO_MOV);
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public List<CONCEPTO_MOVI> ObtenerPorIdTMVzaDizucar(int ID_PRODUCTO, int ID_TIPO_MOV)
        {
            try
            {
                List<CONCEPTO_MOVI> lista = new List<CONCEPTO_MOVI>();
                using (var db = new DbCONCEPTO_MOVI())
                {
                    lista = db.ObtenerPorIdTMVzaDizucar(ID_PRODUCTO, ID_TIPO_MOV);
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public List<CONCEPTO_MOVI> ObtenerPorIdTMVJiboa(int ID_PRODUCTO, int ID_TIPO_MOV)
        {
            try
            {
                List<CONCEPTO_MOVI> lista = new List<CONCEPTO_MOVI>();
                using (var db = new DbCONCEPTO_MOVI())
                {
                    lista = db.ObtenerPorIdTMVJiboa(ID_PRODUCTO, ID_TIPO_MOV);
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }

        public List<CONCEPTO_MOVI> ObtenerPorIdTMConfi(int ID_PRODUCTO, int ID_TIPO_MOV)
        {
            try
            {
                List<CONCEPTO_MOVI> lista = new List<CONCEPTO_MOVI>();
                using (var db = new DbCONCEPTO_MOVI())
                {
                    lista = db.ObtenerPorIdTMConfi(ID_PRODUCTO, ID_TIPO_MOV);
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public List<CONCEPTO_MOVI> ObtenerPorIdTMProduc(int ID_PRODUCTO, int ID_TIPO_MOV)
        {
            try
            {
                List<CONCEPTO_MOVI> lista = new List<CONCEPTO_MOVI>();
                using (var db = new DbCONCEPTO_MOVI())
                {
                    lista = db.ObtenerPorIdTMProduc(ID_PRODUCTO, ID_TIPO_MOV);
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }

        public List<CONCEPTO_MOVI> ObtenerPorIdTMConsumo(int ID_PRODUCTO, int ID_TIPO_MOV)
        {
            try
            {
                List<CONCEPTO_MOVI> lista = new List<CONCEPTO_MOVI>();
                using (var db = new DbCONCEPTO_MOVI())
                {
                    lista = db.ObtenerPorIdTMConsumo(ID_PRODUCTO, ID_TIPO_MOV);
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public List<CONCEPTO_MOVI> ObtenerPorIdTMDonacion(int ID_PRODUCTO, int ID_TIPO_MOV)
        {
            try
            {
                List<CONCEPTO_MOVI> lista = new List<CONCEPTO_MOVI>();
                using (var db = new DbCONCEPTO_MOVI())
                {
                    lista = db.ObtenerPorIdTMDonacion(ID_PRODUCTO, ID_TIPO_MOV);
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }

        public List<CONCEPTO_MOVI> ObtenerPorIdTMVtExterior(int ID_PRODUCTO, int ID_TIPO_MOV)
        {
            try
            {
                List<CONCEPTO_MOVI> lista = new List<CONCEPTO_MOVI>();
                using (var db = new DbCONCEPTO_MOVI())
                {
                    lista = db.ObtenerPorIdTMVtExterior(ID_PRODUCTO, ID_TIPO_MOV);
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
        public List<CONCEPTO_MOVI> ObtenerPorIdTMVtIng(int ID_PRODUCTO, int ID_TIPO_MOV)
        {
            try
            {
                List<CONCEPTO_MOVI> lista = new List<CONCEPTO_MOVI>();
                using (var db = new DbCONCEPTO_MOVI())
                {
                    lista = db.ObtenerPorIdTMVtIng(ID_PRODUCTO, ID_TIPO_MOV);
                }
                return lista;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                return null;
            }
        }
    }
}

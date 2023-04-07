using ADMINPT.DL.Modelo;
using Microsoft.ApplicationBlocks.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.BL
{
    public class CCLIENTE
    {
        public string sError = "";
        //class CCLIENTE
        //{
        //    public string sError = "";

        public List<CLIENTE> ObtenerLista()
        {
            try
            {
                List<CLIENTE> lista = new List<CLIENTE>();
                using (var db = new DbCLIENTE())
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
    }
}

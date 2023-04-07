using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using ADMINPT.DL.Entidades;

namespace ADMINPT.DL.Modelo
{
   public  class DbDOCTO_DETA : DbBase
    {
        public DOCTO_DETA ObtenerPorId(long id)//,long idt)
        {
            List<DOCTO_DETA> lista = new List<DOCTO_DETA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ENCA", id);
                ///parametros.Add("@ID_DETA", idt);
                lista = db.Query<DOCTO_DETA>("SEL_DOCTO_DETA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
    }
}

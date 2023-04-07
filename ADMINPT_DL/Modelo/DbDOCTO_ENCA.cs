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
    public class DbDOCTO_ENCA : DbBase
    {
        public DOCTO_ENCA ObtenerPorId(long id)
        {
            List<DOCTO_ENCA> lista = new List<DOCTO_ENCA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ENCA", id);
                lista = db.Query<DOCTO_ENCA>("SEL_DOCTO_ENCA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
    }
}

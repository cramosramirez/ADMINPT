using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace ADMINPT.DL.Modelo
{
    public class DbESPECI_MOV : DbBase
    {
        public List<ESPECI_MOV> ObtenerPorIdTC(int id)
        {
            List<ESPECI_MOV> lista = new List<ESPECI_MOV>();
            using (var db = new SqlConnection(Conexion))
            {                                                                            
                var parametros = new DynamicParameters();
                parametros.Add("@ID_CONCE", id);
                lista = db.Query<ESPECI_MOV>("SEL_ESPECI_MOV", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista;
            else
                return null;
        }
        public ESPECI_MOV ObtenerPorId(long id)
        {
            List<ESPECI_MOV> lista = new List<ESPECI_MOV>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ESPECI", id);
                lista = db.Query<ESPECI_MOV>("SEL_ESPECI_MOV_ID", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }

    }
}
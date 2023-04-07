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
    public class DbTIPO_MOVIMIENTO : DbBase
    {
        public List<TIPO_MOVIMIENTO> ObtenerLista()
        {
            List<TIPO_MOVIMIENTO> lista = new List<TIPO_MOVIMIENTO>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_TIPO_MOV", -1);
                lista = db.Query<TIPO_MOVIMIENTO>("SEL_TIPO_MOVIMIENTO", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public TIPO_MOVIMIENTO ObtenerPorId(long id)
        {
            List<TIPO_MOVIMIENTO> lista = new List<TIPO_MOVIMIENTO>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_TIPO_MOV", id);
                lista = db.Query<TIPO_MOVIMIENTO>("SEL_TIPO_MOVIMIENTO", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public List<TIPO_MOVIMIENTO> ObtenerPorIdTpMov(int id)
        {
            List<TIPO_MOVIMIENTO> lista = new List<TIPO_MOVIMIENTO>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_TIPO_MOV", id);
                lista = db.Query<TIPO_MOVIMIENTO>("SEL_CONCEPTO_MOVI", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista;
            else
                return null;
        }

    }
}
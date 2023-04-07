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
    public class DbDIA_ZAFRA : DbBase
    {
        public List<DIA_ZAFRA> ObtenerLista()
        {
            List<DIA_ZAFRA> lista = new List<DIA_ZAFRA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_DIA_ZAFRA", -1);
                lista = db.Query<DIA_ZAFRA>("SEL_DIA_ZAFRA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public DIA_ZAFRA ObtenerPorId(long id)
        {
            List<DIA_ZAFRA> lista = new List<DIA_ZAFRA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_DIA_ZAFRA", id);
                lista = db.Query<DIA_ZAFRA>("SEL_DIA_ZAFRA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public int Agregar(DIA_ZAFRA entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ZAFRA", entidad.ID_ZAFRA);
                parametros.Add("@DIAZAFRA", entidad.DIAZAFRA);
                regAfectados = db.Execute("CRE_DIA_ZAFRA", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int Actualizar(DIA_ZAFRA entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_DIA_ZAFRA > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_DIA_ZAFRA", entidad.ID_DIA_ZAFRA);
                    parametros.Add("@ID_ZAFRA", entidad.ID_ZAFRA);
                    parametros.Add("@DIAZAFRA", entidad.DIAZAFRA);
                    regAfectados = db.Execute("UPD_DIA_ZAFRA", parametros, commandType: CommandType.StoredProcedure);
                }
            }
            else
            {
                regAfectados = Agregar(entidad);
            }
            return regAfectados;
        }
        public int Eliminar(int id)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_DIA_ZAFRA", id);
                regAfectados = db.Execute("DEL_DIA_ZAFRA", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }

    }
}

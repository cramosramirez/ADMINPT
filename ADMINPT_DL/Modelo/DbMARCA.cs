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
    public class DbMARCA: DbBase
    {
        public List<MARCA> ObtenerLista()
        {
            List<MARCA> lista = new List<MARCA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_MARCA", -1);
                lista = db.Query<MARCA>("SEL_MARCA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public MARCA ObtenerPorId(long id)
        {
            List<MARCA> lista = new List<MARCA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_MARCA", id);
                lista = db.Query<MARCA>("SEL_MARCA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public int Agregar(MARCA entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@NOMBRE_MARCA", entidad.NOMBRE_MARCA.Trim().ToUpper());
                parametros.Add("@ESTADO", entidad.ESTADO);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                regAfectados = db.Execute("CRE_MARCA", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int Actualizar(MARCA entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_MARCA > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_MARCA", entidad.ID_MARCA);
                    parametros.Add("@NOMBRE_MARCA", entidad.NOMBRE_MARCA.Trim().ToUpper());
                    parametros.Add("@ESTADO", entidad.ESTADO);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    regAfectados = db.Execute("UPD_MARCA", parametros, commandType: CommandType.StoredProcedure);
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
                parametros.Add("@ID_MARCA", id);
                regAfectados = db.Execute("DEL_MARCA", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
    }
}

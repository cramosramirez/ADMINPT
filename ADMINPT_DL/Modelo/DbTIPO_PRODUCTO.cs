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
    public class DbTIPO_PRODUCTO: DbBase
    {
        public List<TIPO_PRODUCTO> ObtenerLista()
        {
            List<TIPO_PRODUCTO> lista = new List<TIPO_PRODUCTO>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_TIPO_PROD", -1);
                lista = db.Query<TIPO_PRODUCTO>("SEL_TIPO_PRODUCTO", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public TIPO_PRODUCTO ObtenerPorId(long id)
        {
            List<TIPO_PRODUCTO> lista = new List<TIPO_PRODUCTO>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_TIPO_PROD", id);
                lista = db.Query<TIPO_PRODUCTO>("SEL_TIPO_PRODUCTO", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public int Agregar(TIPO_PRODUCTO entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@NOMBRE_TIPO", entidad.NOMBRE_TIPO.Trim().ToUpper());
                parametros.Add("@ID_FAMILIA", entidad.ID_FAMILIA);
                parametros.Add("@ESTADO", entidad.ESTADO);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                regAfectados = db.Execute("CRE_TIPO_PRODUCTO", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int Actualizar(TIPO_PRODUCTO entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_TIPO_PROD > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_TIPO_PROD", entidad.ID_TIPO_PROD);
                    parametros.Add("@NOMBRE_TIPO", entidad.NOMBRE_TIPO.Trim().ToUpper());
                    parametros.Add("@ID_FAMILIA", entidad.ID_FAMILIA);
                    parametros.Add("@ESTADO", entidad.ESTADO);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    regAfectados = db.Execute("UPD_TIPO_PRODUCTO", parametros, commandType: CommandType.StoredProcedure);
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
                parametros.Add("@ID_TIPO_PROD", id);
                regAfectados = db.Execute("DEL_TIPO_PRODUCTO", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
    }
}

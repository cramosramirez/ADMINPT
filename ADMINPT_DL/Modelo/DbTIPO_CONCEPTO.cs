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
    public class DbTIPO_CONCEPTO : DbBase
    {
        public List<TIPO_CONCEPTO> ObtenerLista()
        {
            List<TIPO_CONCEPTO> lista = new List<TIPO_CONCEPTO>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_TIPO_CONCEPTO", -1);
                lista = db.Query<TIPO_CONCEPTO>("SEL_TIPO_CONCEPTO", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
      
        public TIPO_CONCEPTO ObtenerPorId(long id)
        {
            List<TIPO_CONCEPTO> lista = new List<TIPO_CONCEPTO>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_TIPO_CONCEPTO", id);
                lista = db.Query<TIPO_CONCEPTO>("SEL_TIPO_CONCEPTO", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public List<TIPO_CONCEPTO> ObtenerPorIdProducto(int id, int ent, int sali)
        {
            List<TIPO_CONCEPTO> lista = new List<TIPO_CONCEPTO>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", id);
                parametros.Add("@ES_ENTRADA", ent);
                parametros.Add("@ES_SALIDA", sali);
                lista = db.Query<TIPO_CONCEPTO>("SEL_CONCEPTO_PRODUCTOS", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista;
            else
                return null;
        }
      
        public int Agregar(TIPO_CONCEPTO entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@NOMBRE_CONCEPTO", entidad.NOMBRE_CONCEPTO.Trim().ToUpper());
                parametros.Add("@ES_ENTRADA", entidad.ES_ENTRADA);
                parametros.Add("@ES_SALIDA", entidad.ES_SALIDA);
                parametros.Add("@ESTADO", entidad.ESTADO);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                regAfectados = db.Execute("CRE_TIPO_CONCEPTO", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int Actualizar(TIPO_CONCEPTO entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_TIPO_CONCEPTO > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_TIPO_CONCEPTO", entidad.ID_TIPO_CONCEPTO);
                    parametros.Add("@NOMBRE_CONCEPTO", entidad.NOMBRE_CONCEPTO.Trim().ToUpper());
                    parametros.Add("@ES_ENTRADA", entidad.ES_ENTRADA);
                    parametros.Add("@ES_SALIDA", entidad.ES_SALIDA);
                    parametros.Add("@ESTADO", entidad.ESTADO);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    regAfectados = db.Execute("UPD_TIPO_CONCEPTO", parametros, commandType: CommandType.StoredProcedure);
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
                parametros.Add("@ID_TIPO_CONCEPTO", id);
                regAfectados = db.Execute("DEL_TIPO_CONCEPTO", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }

    }
}

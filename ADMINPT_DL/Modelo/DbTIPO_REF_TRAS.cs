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
    public class DbTIPO_REF_TRAS : DbBase
    {
        public List<TIPO_REF_TRAS> ObtenerLista()
        {
            List<TIPO_REF_TRAS> lista = new List<TIPO_REF_TRAS>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_REF", -1);
                lista = db.Query<TIPO_REF_TRAS>("SEL_TIPO_REF_TRAS", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public TIPO_REF_TRAS ObtenerPorId(long id)
        {
            List<TIPO_REF_TRAS> lista = new List<TIPO_REF_TRAS>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_REF", id);
                lista = db.Query<TIPO_REF_TRAS>("SEL_TIPO_REF_TRAS", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public int Agregar(TIPO_REF_TRAS entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@NOMBRE", entidad.NOMBRE.Trim().ToUpper());
                parametros.Add("@ESTADO", entidad.ESTADO);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                regAfectados = db.Execute("CRE_TIPO_REF_TRAS", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int Actualizar(TIPO_REF_TRAS entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_REF > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_REF", entidad.ID_REF);
                    parametros.Add("@NOMBRE", entidad.NOMBRE.Trim().ToUpper());
                    parametros.Add("@ESTADO", entidad.ESTADO);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    regAfectados = db.Execute("UPD_TIPO_REF_TRAS", parametros, commandType: CommandType.StoredProcedure);
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
                parametros.Add("@ID_REF", id);
                regAfectados = db.Execute("DEL_TIPO_REF_TRAS", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }

    }
}
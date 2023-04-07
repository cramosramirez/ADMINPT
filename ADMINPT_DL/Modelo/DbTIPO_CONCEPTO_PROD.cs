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
    public class DbTIPO_CONCEPTO_PROD : DbBase
    {
        public List<TIPO_CONCEPTO_PROD> ObtenerLista()
        {
            List<TIPO_CONCEPTO_PROD> lista = new List<TIPO_CONCEPTO_PROD>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_CONCEPTO_PROD", -1);
                lista = db.Query<TIPO_CONCEPTO_PROD>("SEL_TIPO_CONCEPTO_PROD", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public TIPO_CONCEPTO_PROD ObtenerPorId(long id)
        {
            List<TIPO_CONCEPTO_PROD> lista = new List<TIPO_CONCEPTO_PROD>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_CONCEPTO_PROD", id);
                lista = db.Query<TIPO_CONCEPTO_PROD>("SEL_TIPO_CONCEPTO_PROD", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }


        public int Agregar(TIPO_CONCEPTO_PROD entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_TIPO_CONCEPTO", entidad.ID_TIPO_CONCEPTO);
                parametros.Add("@ID_TIPO_PROD", entidad.ID_TIPO_PROD);
                parametros.Add("@ESTADO", entidad.ESTADO);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                regAfectados = db.Execute("CRE_TIPO_CONCEPTO_PROD", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int Actualizar(TIPO_CONCEPTO_PROD entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_CONCEPTO_PROD > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_CONCEPTO_PROD", entidad.ID_CONCEPTO_PROD);
                    parametros.Add("@ID_TIPO_CONCEPTO", entidad.ID_TIPO_CONCEPTO);
                    parametros.Add("@ID_TIPO_PROD", entidad.ID_TIPO_PROD);
                    parametros.Add("@ESTADO", entidad.ESTADO);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    regAfectados = db.Execute("UPD_TIPO_CONCEPTO_PROD", parametros, commandType: CommandType.StoredProcedure);
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
                parametros.Add("@ID_CONCEPTO_PROD", id);
                regAfectados = db.Execute("DEL_TIPO_CONCEPTO_PROD", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
    }
}
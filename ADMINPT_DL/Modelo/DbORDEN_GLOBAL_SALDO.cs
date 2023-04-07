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
    public class DbORDEN_GLOBAL_SALDO : DbBase
    {
        public List<ORDEN_GLOBAL_SALDO> ObtenerLista()
        {
            List<ORDEN_GLOBAL_SALDO> lista = new List<ORDEN_GLOBAL_SALDO>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ORDEN_SALDO", -1);
                lista = db.Query<ORDEN_GLOBAL_SALDO>("SEL_ORDEN_GLOBAL_SALDO", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public ORDEN_GLOBAL_SALDO ObtenerPorId(long id)
        {
            List<ORDEN_GLOBAL_SALDO> lista = new List<ORDEN_GLOBAL_SALDO>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ORDEN_SALDO", id);
                lista = db.Query<ORDEN_GLOBAL_SALDO>("SEL_ORDEN_GLOBAL_SALDO", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public int Agregar(ORDEN_GLOBAL_SALDO entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ORDEN_TRAS", entidad.ID_ORDEN_TRAS);
                parametros.Add("@FECHA", entidad.FECHA);
                parametros.Add("@NASIGNACIONO", entidad.NASIGNACIONO);
                parametros.Add("@ASIGNACIONO", entidad.ASIGNACIONO);
                parametros.Add("@AMPLIACIONES", entidad.AMPLIACIONES);
                parametros.Add("@ASIGNACIONT", entidad.ASIGNACIONT);
                parametros.Add("@EJECUTADO", entidad.EJECUTADO);
                parametros.Add("@SALDO", entidad.SALDO);
                parametros.Add("@OBSERVACION", entidad.OBSERVACION.Trim().ToUpper());
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                regAfectados = db.Execute("CRE_ORDEN_GLOBAL_SALDO", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int Actualizar(ORDEN_GLOBAL_SALDO entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_ORDEN_SALDO > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_ORDEN_SALDO", entidad.ID_ORDEN_SALDO);
                    parametros.Add("@ID_ORDEN_TRAS", entidad.ID_ORDEN_TRAS);
                    parametros.Add("@FECHA", entidad.FECHA);
                    parametros.Add("@ASIGNACIONO", entidad.ASIGNACIONO);
                    parametros.Add("@AMPLIACIONES", entidad.AMPLIACIONES);
                    parametros.Add("@ASIGNACIONT", entidad.ASIGNACIONT);
                    parametros.Add("@EJECUTADO", entidad.EJECUTADO);
                    parametros.Add("@SALDO", entidad.SALDO);
                    parametros.Add("@OBSERVACION", entidad.OBSERVACION.Trim().ToUpper());
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    regAfectados = db.Execute("UPD_ORDEN_GLOBAL_SALDO", parametros, commandType: CommandType.StoredProcedure);
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
                parametros.Add("@ID_ORDEN_SALDO", id);
                regAfectados = db.Execute("DEL_ORDEN_GLOBAL_SALDO", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }

    }
}
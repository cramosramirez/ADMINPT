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
    public class DbSOLICITANTE : DbBase
    {
        public List<SOLICITANTE> ObtenerLista()
        {
            List<SOLICITANTE> lista = new List<SOLICITANTE>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_SOLICITANTE", -1);
                lista = db.Query<SOLICITANTE>("SEL_SOLICITANTE", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public SOLICITANTE ObtenerPorId(long id)
        {
            List<SOLICITANTE> lista = new List<SOLICITANTE>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_SOLICITANTE", id);
                lista = db.Query<SOLICITANTE>("SEL_SOLICITANTE", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public int Agregar(SOLICITANTE entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@NOMBRE", entidad.NOMBRE.Trim().ToUpper());
                parametros.Add("@ESTADO", entidad.ESTADO);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                regAfectados = db.Execute("CRE_SOLICITANTE", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int Actualizar(SOLICITANTE entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_SOLICITANTE > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_SOLICITANTE", entidad.ID_SOLICITANTE);
                    parametros.Add("@NOMBRE", entidad.NOMBRE.Trim().ToUpper());
                    parametros.Add("@ESTADO", entidad.ESTADO);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    regAfectados = db.Execute("UPD_SOLICITANTE", parametros, commandType: CommandType.StoredProcedure);
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
                parametros.Add("@ID_SOLICITANTE", id);
                regAfectados = db.Execute("DEL_SOLICITANTE", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }

    }
}
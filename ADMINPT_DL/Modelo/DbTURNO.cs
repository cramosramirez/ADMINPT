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
    public class DbTURNO : DbBase
    {
        public List<TURNO> ObtenerLista()
        {
            List<TURNO> lista = new List<TURNO>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_TURNO", -1);
                lista = db.Query<TURNO>("SEL_TURNO", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public TURNO ObtenerPorId(long id)
        {
            List<TURNO> lista = new List<TURNO>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_TURNO", id);
                lista = db.Query<TURNO>("SEL_TURNO", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public int Agregar(TURNO entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@HORARIO", entidad.HORARIO.Trim().ToUpper());
                parametros.Add("@ESTADO", entidad.ESTADO);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                regAfectados = db.Execute("CRE_TURNO", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int Actualizar(TURNO entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_TURNO > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_TURNO", entidad.ID_TURNO);
                    parametros.Add("@HORARIO", entidad.HORARIO.Trim().ToUpper());
                    parametros.Add("@ESTADO", entidad.ESTADO);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    regAfectados = db.Execute("UPD_TURNO", parametros, commandType: CommandType.StoredProcedure);
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
                parametros.Add("@ID_TURNO", id);
                regAfectados = db.Execute("DEL_TURNO", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }

    }
}

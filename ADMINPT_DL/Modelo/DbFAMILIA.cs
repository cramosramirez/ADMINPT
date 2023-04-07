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
    public class DbFAMILIA : DbBase
    {
        public List<FAMILIA> ObtenerLista()
        {
            List<FAMILIA> lista = new List<FAMILIA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_FAMILIA", -1);
                lista = db.Query<FAMILIA>("SEL_FAMILIA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public FAMILIA ObtenerPorId(long id)
        {
            List<FAMILIA> lista = new List<FAMILIA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_FAMILIA", id);
                lista = db.Query<FAMILIA>("SEL_FAMILIA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public int Agregar(FAMILIA entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@NOMBRE_FAMILIA", entidad.NOMBRE_FAMILIA.Trim().ToUpper());
                parametros.Add("@ESTADO", entidad.ESTADO);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                regAfectados = db.Execute("CRE_FAMILIA", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int Actualizar(FAMILIA entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_FAMILIA > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_FAMILIA", entidad.ID_FAMILIA);
                    parametros.Add("@NOMBRE_FAMILIA", entidad.NOMBRE_FAMILIA.Trim().ToUpper());
                    parametros.Add("@ESTADO", entidad.ESTADO);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    regAfectados = db.Execute("UPD_FAMILIA", parametros, commandType: CommandType.StoredProcedure);
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
                parametros.Add("@ID_FAMILIA", id);
                regAfectados = db.Execute("DEL_FAMILIA", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }

    }
}
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
    public class DbTRANSPORTE : DbBase
    {
        public List<TRANSPORTE> ObtenerLista()
        {
            List<TRANSPORTE> lista = new List<TRANSPORTE>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_TRANSPORTE", -1);
                lista = db.Query<TRANSPORTE>("SEL_TRANSPORTE", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public TRANSPORTE ObtenerPorId(long id)
        {
            List<TRANSPORTE> lista = new List<TRANSPORTE>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_TRANSPORTE", id);
                lista = db.Query<TRANSPORTE>("SEL_TRANSPORTE", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public int Agregar(TRANSPORTE entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@NOMBRE", entidad.NOMBRE.Trim().ToUpper());
                parametros.Add("@ESTADO", entidad.ESTADO);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                regAfectados = db.Execute("CRE_TRANSPORTE", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int Actualizar(TRANSPORTE entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_TRANSPORTE > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_TRANSPORTE", entidad.ID_TRANSPORTE);
                    parametros.Add("@NOMBRE", entidad.NOMBRE.Trim().ToUpper());
                    parametros.Add("@ESTADO", entidad.ESTADO);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    regAfectados = db.Execute("UPD_TRANSPORTE", parametros, commandType: CommandType.StoredProcedure);
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
                parametros.Add("@ID_TRANSPORTE", id);
                regAfectados = db.Execute("DEL_TRANSPORTE", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }

    }
}
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
    public class DbESTADO_MOVIMIENTOS : DbBase
    {
        public List<ESTADO_MOVIMIENTOS> ObtenerLista()
        {
            List<ESTADO_MOVIMIENTOS> lista = new List<ESTADO_MOVIMIENTOS>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ESTADO", -1);
                lista = db.Query<ESTADO_MOVIMIENTOS>("SEL_ESTADO_MOVIMIENTOS", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public ESTADO_MOVIMIENTOS ObtenerPorId(long id)
        {
            List<ESTADO_MOVIMIENTOS> lista = new List<ESTADO_MOVIMIENTOS>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ESTADO", id);
                lista = db.Query<ESTADO_MOVIMIENTOS>("SEL_ESTADO_MOVIMIENTOS", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public int Agregar(ESTADO_MOVIMIENTOS entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@NOMBRE_ESTADO", entidad.NOMBRE_ESTADO.Trim().ToUpper());
                parametros.Add("@ESTADO", entidad.ESTADO);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                regAfectados = db.Execute("CRE_ESTADO_MOVIMIENTOS", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int Actualizar(ESTADO_MOVIMIENTOS entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_ESTADO > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_ESTADO", entidad.ID_ESTADO);
                    parametros.Add("@NOMBRE_ESTADO", entidad.NOMBRE_ESTADO.Trim().ToUpper());
                    parametros.Add("@ESTADO", entidad.ESTADO);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    regAfectados = db.Execute("UPD_ESTADO_MOVIMIENTOS", parametros, commandType: CommandType.StoredProcedure);
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
                parametros.Add("@ID_ESTADO", id);
                regAfectados = db.Execute("DEL_ESTADO_MOVIMIENTOS", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }

    }
}
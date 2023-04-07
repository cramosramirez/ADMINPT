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
    public class DbPRESENTACION_TRAS : DbBase
    {
        public List<PRESENTACION_TRAS> ObtenerLista()
        {
            List<PRESENTACION_TRAS> lista = new List<PRESENTACION_TRAS>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRESEN_TRAS", -1);
                lista = db.Query<PRESENTACION_TRAS>("SEL_PRESENTACION_TRAS", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public PRESENTACION_TRAS ObtenerPorId(long id)
        {
            List<PRESENTACION_TRAS> lista = new List<PRESENTACION_TRAS>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRESEN_TRAS", id);
                lista = db.Query<PRESENTACION_TRAS>("SEL_PRESENTACION_TRAS", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public List<PRESENTACION_TRAS> ObtenerPorIdProducto(int id)
        {
            List<PRESENTACION_TRAS> lista = new List<PRESENTACION_TRAS>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", id);
                lista = db.Query<PRESENTACION_TRAS>("SEL_PRESENTACIONT", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista;
            else
                return null;
        }
        public List<PRESENTACION_TRAS> ObtenerPorIdProductoALMAPAC(int id)
        {
            List<PRESENTACION_TRAS> lista = new List<PRESENTACION_TRAS>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", id);
                lista = db.Query<PRESENTACION_TRAS>("SEL_PRESENTACIONT_ALMAPAC", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista;
            else
                return null;
        }
        public int Agregar(PRESENTACION_TRAS entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@NOMBRE_PRESEN_TRAA", entidad.NOMBRE_PRESEN_TRAA.Trim().ToUpper());
                parametros.Add("@ESTADO", entidad.ESTADO);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                regAfectados = db.Execute("CRE_PRESENTACION_TRAS", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int Actualizar(PRESENTACION_TRAS entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_PRESEN_TRAS > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_PRESEN_TRAS", entidad.ID_PRESEN_TRAS);
                    parametros.Add("@NOMBRE_PRESEN_TRAA", entidad.NOMBRE_PRESEN_TRAA.Trim().ToUpper());
                    parametros.Add("@ESTADO", entidad.ESTADO);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    regAfectados = db.Execute("UPD_PRESENTACION_TRAS", parametros, commandType: CommandType.StoredProcedure);
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
                parametros.Add("@ID_PRESEN_TRAS", id);
                regAfectados = db.Execute("DEL_PRESENTACION_TRAS", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }

    }
}
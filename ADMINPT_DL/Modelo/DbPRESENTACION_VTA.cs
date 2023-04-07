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
    public class DbPRESENTACION_VTA : DbBase
    {

        public List<PRESENTACION_VTA> ObtenerLista()
        {
            List<PRESENTACION_VTA> lista = new List<PRESENTACION_VTA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRESEN_VTA", -1);
                lista = db.Query<PRESENTACION_VTA>("SEL_PRESENTACION_VTA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public PRESENTACION_VTA ObtenerPorId(long id)
        {
            List<PRESENTACION_VTA> lista = new List<PRESENTACION_VTA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRESEN_VTA", id);
                lista = db.Query<PRESENTACION_VTA>("SEL_PRESENTACION_VTA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public List<PRESENTACION_VTA> ObtenerPorIdProducto(int id)
        {
            List<PRESENTACION_VTA> lista = new List<PRESENTACION_VTA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", id);
                lista = db.Query<PRESENTACION_VTA>("SEL_PRESENTACIONV", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista;
            else
                return null;
        }

        public int Agregar(PRESENTACION_VTA entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@NOMBRE_PRESEN_VTA", entidad.NOMBRE_PRESEN_VTA.Trim().ToUpper());
                parametros.Add("@ESTADO", entidad.ESTADO);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                regAfectados = db.Execute("CRE_PRESENTACION_VTA", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int Actualizar(PRESENTACION_VTA entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_PRESEN_VTA > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_PRESEN_VTA", entidad.ID_PRESEN_VTA);
                    parametros.Add("@NOMBRE_PRESEN_VTA", entidad.NOMBRE_PRESEN_VTA.Trim().ToUpper());
                    parametros.Add("@ESTADO", entidad.ESTADO);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    regAfectados = db.Execute("UPD_PRESENTACION_VTA", parametros, commandType: CommandType.StoredProcedure);
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
                parametros.Add("@ID_PRESEN_VTA", id);
                regAfectados = db.Execute("DEL_PRESENTACION_VTA", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
    }
}

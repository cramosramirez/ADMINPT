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
    public class DbUNIDAD_MEDI_FAC : DbBase
    {
        public List<UNIDAD_MEDI_FAC> ObtenerLista()
        {
            List<UNIDAD_MEDI_FAC> lista = new List<UNIDAD_MEDI_FAC>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_UNIDAD_FAC", -1);
                lista = db.Query<UNIDAD_MEDI_FAC>("SEL_UNIDAD_MEDI_FAC", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public UNIDAD_MEDI_FAC ObtenerPorId(long id)
        {
            List<UNIDAD_MEDI_FAC> lista = new List<UNIDAD_MEDI_FAC>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_UNIDAD_FAC", id);
                lista = db.Query<UNIDAD_MEDI_FAC>("SEL_UNIDAD_MEDI_FAC", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public List<UNIDAD_MEDI_FAC> ObtenerPorIdProducto(int id)
        {
            List<UNIDAD_MEDI_FAC> lista = new List<UNIDAD_MEDI_FAC>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", id);
                lista = db.Query<UNIDAD_MEDI_FAC>("SEL_UNIDAD_MEDI_FAC_PRODUCTOS", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista;
            else
                return null;
        }
        public List<UNIDAD_MEDI_FAC> ObtenerPorIdProductoALMAPAC(int id)
        {
            List<UNIDAD_MEDI_FAC> lista = new List<UNIDAD_MEDI_FAC>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", id);
                lista = db.Query<UNIDAD_MEDI_FAC>("SEL_UNIDAD_MEDI_FAC_PRODUCTOS_ALMPAC", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista;
            else
                return null;
        }
        public int Agregar(UNIDAD_MEDI_FAC entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@NOMBRE_UNIDAD", entidad.NOMBRE_UNIDAD.Trim().ToUpper());
                parametros.Add("@FACTOR", entidad.FACTOR);
                parametros.Add("@ESTADO", entidad.ESTADO);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                regAfectados = db.Execute("CRE_UNIDAD_MEDI_FAC", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int Actualizar(UNIDAD_MEDI_FAC entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_UNIDAD_FAC > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_UNIDAD_FAC", entidad.ID_UNIDAD_FAC);
                    parametros.Add("@NOMBRE_UNIDAD", entidad.NOMBRE_UNIDAD.Trim().ToUpper());
                    parametros.Add("@FACTOR", entidad.FACTOR);
                    parametros.Add("@ESTADO", entidad.ESTADO);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    regAfectados = db.Execute("UPD_UNIDAD_MEDI_FAC", parametros, commandType: CommandType.StoredProcedure);
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
                parametros.Add("@ID_UNIDAD_FAC", id);
                regAfectados = db.Execute("DEL_UNIDAD_MEDI_FAC", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }

    }
}
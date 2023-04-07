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
    public class DbPRODUCTO_PRES_TRAS : DbBase
    {
        public List<PRODUCTO_PRES_TRAS> ObtenerLista()
        {
            List<PRODUCTO_PRES_TRAS> lista = new List<PRODUCTO_PRES_TRAS>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PROD_PRES_TRAS", -1);
                lista = db.Query<PRODUCTO_PRES_TRAS>("SEL_PRODUCTO_PRES_TRAS", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public PRODUCTO_PRES_TRAS ObtenerPorId(long id)
        {
            List<PRODUCTO_PRES_TRAS> lista = new List<PRODUCTO_PRES_TRAS>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PROD_PRES_TRAS", id);
                lista = db.Query<PRODUCTO_PRES_TRAS>("SEL_PRODUCTO_PRES_TRAS", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }

        public PRODUCTO_PRES_TRAS ObtenerPorIdProducto(long id)
        {
            List<PRODUCTO_PRES_TRAS> lista = new List<PRODUCTO_PRES_TRAS>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PROD_PRES_TRAS", id);
                lista = db.Query<PRODUCTO_PRES_TRAS>("SEL_PRESENTACION", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public int Agregar(PRODUCTO_PRES_TRAS entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", entidad.ID_PRODUCTO);
                parametros.Add("@ID_PRESEN_TRAS", entidad.ID_PRESEN_TRAS);
                parametros.Add("@ESTADO", entidad.ESTADO);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                regAfectados = db.Execute("CRE_PRODUCTO_PRES_TRAS", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int Actualizar(PRODUCTO_PRES_TRAS entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_PROD_PRES_TRAS > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_PROD_PRES_TRAS", entidad.ID_PROD_PRES_TRAS);
                    parametros.Add("@ID_PRODUCTO", entidad.ID_PRODUCTO);
                    parametros.Add("@ID_PRESEN_TRAS", entidad.ID_PRESEN_TRAS);
                    parametros.Add("@ESTADO", entidad.ESTADO);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    regAfectados = db.Execute("UPD_PRODUCTO_PRES_TRAS", parametros, commandType: CommandType.StoredProcedure);
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
                parametros.Add("@ID_PROD_PRES_TRAS", id);
                regAfectados = db.Execute("DEL_PRODUCTO_PRES_TRAS", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }

    }
}
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
   public class DbPRODUCTO: DbBase
    {
        public List<PRODUCTO> ObtenerLista()
        {
            List<PRODUCTO> lista = new List<PRODUCTO>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", -1);
                lista = db.Query<PRODUCTO>("SEL_PRODUCTO", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public List<PRODUCTO> ObtenerListaConsumo()
        {
            List<PRODUCTO> lista = new List<PRODUCTO>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", -1);
                lista = db.Query<PRODUCTO>("SEL_PRODUCTO_CONSUMA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public List<PRODUCTO> ObtenerListaTraslado()
        {
            List<PRODUCTO> lista = new List<PRODUCTO>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", -1);
                lista = db.Query<PRODUCTO>("SEL_PRODUCTO_TRASLADO", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public List<PRODUCTO> ObtenerListaTrasladoC5()
        {
            List<PRODUCTO> lista = new List<PRODUCTO>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", -1);
                lista = db.Query<PRODUCTO>("SEL_PRODUCTO_TRASLADOC5", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public List<PRODUCTO> ObtenerListaOrdenGlobal()
        {
            List<PRODUCTO> lista = new List<PRODUCTO>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", -1);
                lista = db.Query<PRODUCTO>("SEL_PRODUCTO_ORDENGLOBAL", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }

        public List<PRODUCTO> ObtenerListaVtaDizucar()
        {
            List<PRODUCTO> lista = new List<PRODUCTO>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", -1);
                lista = db.Query<PRODUCTO>("SEL_PRODUCTO_VTADIZUCAR", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public List<PRODUCTO> ObtenerListaAlmapac()
        {
            List<PRODUCTO> lista = new List<PRODUCTO>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_BODEP", 17);
                lista = db.Query<PRODUCTO>("SEL_PRODUCTO_ALMAPAC", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public List<PRODUCTO> ObtenerListaVtJiboa()
        {
            List<PRODUCTO> lista = new List<PRODUCTO>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", -1);
                lista = db.Query<PRODUCTO>("SEL_PRODUCTO_VTJIBOA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public List<PRODUCTO> ObtenerListaVtJiboaEmpacado()
        {
            List<PRODUCTO> lista = new List<PRODUCTO>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", -1);
                lista = db.Query<PRODUCTO>("SEL_PRODUCTO_VTJIBOAEMPACADA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }

        public PRODUCTO ObtenerPorId(long id)
        {
            List<PRODUCTO> lista = new List<PRODUCTO>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", id);
                lista = db.Query<PRODUCTO>("SEL_PRODUCTO", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public int Agregar(PRODUCTO entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@CODI_PRODUCTO", entidad.CODI_PRODUCTO.Trim().ToUpper());
                parametros.Add("@NOMBRE_PRODUCTO", entidad.NOMBRE_PRODUCTO.Trim().ToUpper());
                parametros.Add("@NOMBRE_KARDEX", entidad.NOMBRE_KARDEX.Trim().ToUpper());
                parametros.Add("@NOMBRE_VENTA", entidad.NOMBRE_VENTA.Trim().ToUpper());
                parametros.Add("@ID_TIPO_PROD", entidad.ID_TIPO_PROD);
                parametros.Add("@ID_UNIDAD_CONSAA", entidad.ID_UNIDAD_CONSAA);
                parametros.Add("@ID_UNIDAD_FAC", entidad.ID_UNIDAD_CONSAA);
                parametros.Add("@ID_MARCA", entidad.ID_UNIDAD_CONSAA);
                parametros.Add("@APLICA_VTA", entidad.APLICA_VTA);
                parametros.Add("@APLICA_TRAS", entidad.APLICA_TRAS);
                parametros.Add("@FACTOR", entidad.FACTOR);
                parametros.Add("@ESTADO", entidad.ESTADO);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                regAfectados = db.Execute("CRE_PRODUCTO", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int Actualizar(PRODUCTO entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_PRODUCTO > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_PRODUCTO", entidad.ID_PRODUCTO);
                    parametros.Add("@CODI_PRODUCTO", entidad.CODI_PRODUCTO.Trim().ToUpper());
                    parametros.Add("@NOMBRE_PRODUCTO", entidad.NOMBRE_PRODUCTO.Trim().ToUpper());
                    parametros.Add("@NOMBRE_KARDEX", entidad.NOMBRE_KARDEX.Trim().ToUpper());
                    parametros.Add("@NOMBRE_VENTA", entidad.NOMBRE_VENTA.Trim().ToUpper());
                    parametros.Add("@ID_TIPO_PROD", entidad.ID_TIPO_PROD);
                    parametros.Add("@ID_UNIDAD_CONSAA", entidad.ID_UNIDAD_CONSAA);
                    parametros.Add("@ID_UNIDAD_FAC", entidad.ID_UNIDAD_CONSAA);
                    parametros.Add("@ID_MARCA", entidad.ID_UNIDAD_CONSAA);
                    parametros.Add("@APLICA_VTA", entidad.APLICA_VTA);
                    parametros.Add("@APLICA_TRAS", entidad.APLICA_TRAS);
                    parametros.Add("@FACTOR", entidad.FACTOR);
                    parametros.Add("@ESTADO", entidad.ESTADO);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    regAfectados = db.Execute("UPD_PRODUCTO", parametros, commandType: CommandType.StoredProcedure);
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
                parametros.Add("@ID_PRODUCTO", id);
                regAfectados = db.Execute("DEL_PRODUCTO", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
    }
}

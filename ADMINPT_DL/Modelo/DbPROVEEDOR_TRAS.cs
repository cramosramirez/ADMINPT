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
    public class DbPROVEEDOR_TRAS : DbBase
    {
        public List<PROVEEDOR_TRAS> ObtenerLista()
        {
            List<PROVEEDOR_TRAS> lista = new List<PROVEEDOR_TRAS>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PROV_TRAS", -1);
                lista = db.Query<PROVEEDOR_TRAS>("SEL_PROVEEDOR_TRAS", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public PROVEEDOR_TRAS ObtenerPorId(long id)
        {
            List<PROVEEDOR_TRAS> lista = new List<PROVEEDOR_TRAS>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PROV_TRAS", id);
                lista = db.Query<PROVEEDOR_TRAS>("SEL_PROVEEDOR_TRAS", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public int Agregar(PROVEEDOR_TRAS entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@NOMBRE", entidad.NOMBRE.Trim().ToUpper());
                parametros.Add("@TRANSPORTE", entidad.TRANSPORTE.Trim().ToUpper());
                parametros.Add("@ESTADO", entidad.ESTADO);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                regAfectados = db.Execute("CRE_PROVEEDOR_TRAS", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int Actualizar(PROVEEDOR_TRAS entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_PROV_TRAS > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_PROV_TRAS", entidad.ID_PROV_TRAS);
                    parametros.Add("@NOMBRE", entidad.NOMBRE.Trim().ToUpper());
                    parametros.Add("@TRANSPORTE", entidad.TRANSPORTE.Trim().ToUpper());
                    parametros.Add("@ESTADO", entidad.ESTADO);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    regAfectados = db.Execute("UPD_PROVEEDOR_TRAS", parametros, commandType: CommandType.StoredProcedure);
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
                parametros.Add("@ID_PROV_TRAS", id);
                regAfectados = db.Execute("DEL_PROVEEDOR_TRAS", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using ADMINPT.DL.Entidades;

namespace ADMINPT.DL.Modelo
{
    public class DbCONTROL_TRASLADO : DbBase
    {
        public List<CONTROL_TRASLADO> ObtenerLista()
        {
            List<CONTROL_TRASLADO> lista = new List<CONTROL_TRASLADO>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_CONTROL_TRAS", -1);
                lista = db.Query<CONTROL_TRASLADO>("SEL_CONTROL_TRASLADO", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
    
        public CONTROL_TRASLADO ObtenerPorId(long id)
        {
            List<CONTROL_TRASLADO> lista = new List<CONTROL_TRASLADO>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_CONTROL_TRAS", id);
                lista = db.Query<CONTROL_TRASLADO>("SEL_CONTROL_TRASLADO", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public int Agregar(CONTROL_TRASLADO entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                regAfectados = db.Execute("CRE_CONTROL_TRASLADO", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int Actualizar(CONTROL_TRASLADO entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_CONTROL_TRAS > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_CONTROL_TRAS", entidad.ID_CONTROL_TRAS);
                    //parametros.Add("@NOMBRE", entidad.NOMBRE.Trim().ToUpper());
                    //parametros.Add("@DIRECCION", entidad.DIRECCION.Trim().ToUpper());
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    regAfectados = db.Execute("UPD_CONTROL_TRASLADO", parametros, commandType: CommandType.StoredProcedure);
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
                parametros.Add("@ID_CONTROL_TRAS", id);
                regAfectados = db.Execute("DEL_CONTROL_TRASLADO", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }

    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ADMINPT.DL.Modelo
//{
//    class DbCONTROL_TRASLADO
//    {
//    }
//}

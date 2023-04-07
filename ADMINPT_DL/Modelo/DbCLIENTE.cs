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
    public class DbCLIENTE : DbBase
    // public class DbCLIENTE : DbBase
    {
        public List<CLIENTE> ObtenerLista()
        {
            List<CLIENTE> lista = new List<CLIENTE>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_CLIENTE", -1);
                lista = db.Query<CLIENTE>("SEL_CLIENTE", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        
       
        //public BODEGA ObtenerPorId(long id)
        //{
        //    List<BODEGA> lista = new List<BODEGA>();
        //    using (var db = new SqlConnection(Conexion))
        //    {
        //        var parametros = new DynamicParameters();
        //        parametros.Add("@ID_BODEGA", id);
        //        lista = db.Query<BODEGA>("SEL_BODEGA", parametros, commandType: CommandType.StoredProcedure).ToList();
        //    }
        //    if (lista != null)
        //        return lista[0];
        //    else
        //        return null;
        //}
        //public int Agregar(BODEGA entidad)
        //{
        //    int regAfectados = 0;
        //    using (var db = new SqlConnection(Conexion))
        //    {
        //        var parametros = new DynamicParameters();
        //        parametros.Add("@NOMBRE", entidad.NOMBRE.Trim().ToUpper());
        //        parametros.Add("@DIRECCION", entidad.DIRECCION.Trim().ToUpper());
        //        parametros.Add("@ESTADO", entidad.ESTADO);
        //        parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
        //        parametros.Add("@FECHA_CREA", DateTime.Now);
        //        regAfectados = db.Execute("CRE_BODEGA", parametros, commandType: CommandType.StoredProcedure);
        //    }
        //    return regAfectados;
        //}
        //public int Actualizar(BODEGA entidad)
        //{
        //    int regAfectados = 0;

        //    if (entidad.ID_BODEGA > 0)
        //    {
        //        using (var db = new SqlConnection(Conexion))
        //        {
        //            var parametros = new DynamicParameters();
        //            parametros.Add("@ID_BODEGA", entidad.ID_BODEGA);
        //            parametros.Add("@NOMBRE", entidad.NOMBRE.Trim().ToUpper());
        //            parametros.Add("@DIRECCION", entidad.DIRECCION.Trim().ToUpper());
        //            parametros.Add("@ESTADO", entidad.ESTADO);
        //            parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
        //            parametros.Add("@FECHA_ACT", DateTime.Now);
        //            regAfectados = db.Execute("UPD_BODEGA", parametros, commandType: CommandType.StoredProcedure);
        //        }
        //    }
        //    else
        //    {
        //        regAfectados = Agregar(entidad);
        //    }
        //    return regAfectados;
        //}
        //public int Eliminar(int id)
        //{
        //    int regAfectados = 0;
        //    using (var db = new SqlConnection(Conexion))
        //    {
        //        var parametros = new DynamicParameters();
        //        parametros.Add("@ID_BODEGA", id);
        //        regAfectados = db.Execute("DEL_BODEGA", parametros, commandType: CommandType.StoredProcedure);
        //    }
        //    return regAfectados;
        //}

    }
}

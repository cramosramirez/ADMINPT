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
    public class DbZAFRA : DbBase
    {
        public List<ZAFRA> ObtenerLista()
        {
            List<ZAFRA> lista = new List<ZAFRA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ZAFRA", -1);
                lista = db.Query<ZAFRA>("SEL_ZAFRA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public List<ZAFRA> ObtenerListaActiva()
        {
            List<ZAFRA> lista = new List<ZAFRA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                lista = db.Query<ZAFRA>("SEL_ZAFRA_ACTUAL", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public List<ZAFRA> ObtenerListaActivaALMAPAC()
        {
            List<ZAFRA> lista = new List<ZAFRA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                lista = db.Query<ZAFRA>("SEL_ZAFRA_ACTUAL_ALMAPAC", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public List<ZAFRA> ObtenerListaProductActiva(long ID_PRODUCTO, string TIPO)
        {
            List<ZAFRA> lista = new List<ZAFRA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", ID_PRODUCTO);
                parametros.Add("@TIPO", TIPO);
                lista = db.Query<ZAFRA>("SEL_ZAFRA_PROD", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }

        public List<ZAFRA> ObtenerListaProductALMAPAC(long ID_PRODUCTO, string TIPO)
        {
            List<ZAFRA> lista = new List<ZAFRA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", ID_PRODUCTO);
                parametros.Add("@TIPO", TIPO);
                lista = db.Query<ZAFRA>("SEL_ZAFRA_ALMAPAC", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public ZAFRA ObtenerPorId(long id)
        {
            List<ZAFRA> lista = new List<ZAFRA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ZAFRA", id);
                lista = db.Query<ZAFRA>("SEL_ZAFRA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public int Agregar(ZAFRA entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@NOMBRE_ZAFRA", entidad.NOMBRE_ZAFRA.Trim().ToUpper());
                regAfectados = db.Execute("CRE_ZAFRA", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int Actualizar(ZAFRA entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_ZAFRA > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_ZAFRA", entidad.ID_ZAFRA);
                    parametros.Add("@NOMBRE_ZAFRA", entidad.NOMBRE_ZAFRA.Trim().ToUpper());
                    regAfectados = db.Execute("UPD_ZAFRA", parametros, commandType: CommandType.StoredProcedure);
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
                parametros.Add("@ID_ZAFRA", id);
                regAfectados = db.Execute("DEL_ZAFRA", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }

    }
}
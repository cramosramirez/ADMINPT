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
    public class DbMOVIMIENTO_ENCA : DbBase
    {
        public List<MOVIMIENTO_ENCA> ObtenerLista()
        {
            List<MOVIMIENTO_ENCA> lista = new List<MOVIMIENTO_ENCA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ENCA", -1);
                lista = db.Query<MOVIMIENTO_ENCA>("SEL_MOVIMIENTO_ENCA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public List<MOVIMIENTO_ENCA> ObtenerListaSali()
        {
            List<MOVIMIENTO_ENCA> lista = new List<MOVIMIENTO_ENCA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ENCA", -1);
                lista = db.Query<MOVIMIENTO_ENCA>("SEL_MOVIMIENTO_SALI", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public MOVIMIENTO_ENCA ObtenerPorId(long id)
        {
            List<MOVIMIENTO_ENCA> lista = new List<MOVIMIENTO_ENCA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ENCA", id);
                lista = db.Query<MOVIMIENTO_ENCA>("SEL_MOVIMIENTO_ENCA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public int Agregar(ref MOVIMIENTO_ENCA entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_BODEGA", entidad.ID_BODEGA);
                parametros.Add("@FECHA", entidad.FECHA);
                parametros.Add("@ID_ZAFRA_ACTUAL", entidad.ID_ZAFRA_ACTUAL);
                parametros.Add("@ID_ZAFRA_PROD", entidad.ID_ZAFRA_PROD);
                parametros.Add("@ID_DIA_ZAFRA", entidad.ID_DIA_ZAFRA);
                parametros.Add("@ID_TURNO", entidad.ID_TURNO);
                parametros.Add("@ID_TIPO_CONCEPTO", entidad.ID_TIPO_CONCEPTO);
                parametros.Add("@OBSERVACIONES", entidad.OBSERVACIONES);
                parametros.Add("@ID_BODEGA_TRAS", entidad.ID_BODEGA_TRAS);
                parametros.Add("@ID_ESTADO", entidad.ID_ESTADO);
               // parametros.Add("@CORR_BODEGA", entidad.CORR_BODEGA);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);

                parametros.Add("@ID", 0, DbType.Int32, ParameterDirection.Output);
                regAfectados = db.Execute("CRE_MOVIMIENTO_ENCA", parametros, commandType: CommandType.StoredProcedure);
                entidad.ID_ENCA = parametros.Get<int>("@ID");
            }
            return regAfectados;
        }
        public int Actualizar(ref MOVIMIENTO_ENCA entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_ENCA > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_ENCA", entidad.ID_ENCA);
                    parametros.Add("@ID_BODEGA", entidad.ID_BODEGA);
                    parametros.Add("@FECHA", entidad.FECHA);
                    parametros.Add("@ID_ZAFRA_ACTUAL", entidad.ID_ZAFRA_ACTUAL);
                    parametros.Add("@ID_ZAFRA_PROD", entidad.ID_ZAFRA_PROD);
                    parametros.Add("@ID_DIA_ZAFRA", entidad.ID_DIA_ZAFRA);
                    parametros.Add("@ID_TURNO", entidad.ID_TURNO);
                    parametros.Add("@ID_TIPO_CONCEPTO", entidad.ID_TIPO_CONCEPTO);
                    parametros.Add("@OBSERVACIONES", entidad.OBSERVACIONES);
                    parametros.Add("@ID_BODEGA_TRAS", entidad.ID_BODEGA_TRAS);
                    parametros.Add("@ID_ESTADO", entidad.ID_ESTADO);
                    parametros.Add("@CORR_BODEGA", entidad.CORR_BODEGA);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    regAfectados = db.Execute("UPD_MOVIMIENTO_ENCA", parametros, commandType: CommandType.StoredProcedure);
                }
            }
            else
            {
                regAfectados = Agregar(ref entidad);
            }
            return regAfectados;
        }
        public int Eliminar(int id)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ENCA", id);
                regAfectados = db.Execute("DEL_MOVIMIENTO_ENCA", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }

    }
}
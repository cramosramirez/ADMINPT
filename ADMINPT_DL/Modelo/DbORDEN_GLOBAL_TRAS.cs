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
    public class DbORDEN_GLOBAL_TRAS : DbBase
    {
        public List<ORDEN_GLOBAL_TRAS> ObtenerLista(long ID_BODEP)
        {
            List<ORDEN_GLOBAL_TRAS> lista = new List<ORDEN_GLOBAL_TRAS>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ORDEN_TRAS", -1);
                parametros.Add("@ID_BODEP", ID_BODEP);
                lista = db.Query<ORDEN_GLOBAL_TRAS>("SEL_ORDEN_GLOBAL_TRAS", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public List<ORDEN_GLOBAL_TRAS> ObtenerListaCb(long ID_BODEP)
        {
            List<ORDEN_GLOBAL_TRAS> lista = new List<ORDEN_GLOBAL_TRAS>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_BODEP", ID_BODEP);
                lista = db.Query<ORDEN_GLOBAL_TRAS>("CB_ORDEN_GLOBAL_TRAS", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public ORDEN_GLOBAL_TRAS ObtenerPorId(long id, long idbp)
        {
            List<ORDEN_GLOBAL_TRAS> lista = new List<ORDEN_GLOBAL_TRAS>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ORDEN_TRAS", id);
                parametros.Add("@ID_BODEP", idbp);
                lista = db.Query<ORDEN_GLOBAL_TRAS>("SEL_ORDEN_GLOBAL_TRAS", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public int Agregar(ORDEN_GLOBAL_TRAS entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@COD_CAPTURA", entidad.COD_CAPTURA);
                parametros.Add("@FECHA", entidad.FECHA);
                parametros.Add("@ID_SOLICITANTE", entidad.ID_SOLICITANTE);
                parametros.Add("@ID_BODEGAO", entidad.ID_BODEGAO);
                parametros.Add("@ID_BODEGAD", entidad.ID_BODEGAD);
                parametros.Add("@ID_TIPO_MOV", entidad.ID_TIPO_MOV);
                parametros.Add("@ID_CONCE", entidad.ID_CONCE);
                parametros.Add("@ID_ESPECI", entidad.ID_ESPECI);
                parametros.Add("@ID_REF", entidad.ID_REF);
                parametros.Add("@NUMREF", entidad.NUMREF);
                parametros.Add("@ID_ZAFRA_PROD", entidad.ID_ZAFRA_PROD);
                parametros.Add("@ID_PRODUCTO", entidad.ID_PRODUCTO);
                parametros.Add("@ASIGNACIONO", entidad.ASIGNACIONO);
                parametros.Add("@AMPLIACIONES", entidad.AMPLIACIONES);
                parametros.Add("@ASIGNACIONT", entidad.ASIGNACIONT);
                parametros.Add("@EJECUTADO", entidad.EJECUTADO);
                parametros.Add("@SALDO", entidad.SALDO);
                parametros.Add("@ESTADO", entidad.ESTADO);
                parametros.Add("@OBSERVACION", entidad.OBSERVACION.Trim().ToUpper());
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                parametros.Add("@ES_PROPIO", entidad.ES_PROPIO);
                parametros.Add("@ES_AJENO", entidad.ES_AJENO);
                parametros.Add("@ID_ESTADO", entidad.ID_ESTADO);
                regAfectados = db.Execute("CRE_ORDEN_GLOBAL_TRAS", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int Actualizar(ORDEN_GLOBAL_TRAS entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_ORDEN_TRAS > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_ORDEN_TRAS", entidad.ID_ORDEN_TRAS);
                    parametros.Add("@COD_CAPTURA", entidad.COD_CAPTURA);
                    parametros.Add("@FECHA", entidad.FECHA);
                    parametros.Add("@ID_SOLICITANTE", entidad.ID_SOLICITANTE);
                    parametros.Add("@ID_BODEGAO", entidad.ID_BODEGAO);
                    parametros.Add("@ID_BODEGAD", entidad.ID_BODEGAD);
                    parametros.Add("@ID_TIPO_MOV", entidad.ID_TIPO_MOV);
                    parametros.Add("@ID_CONCE", entidad.ID_CONCE);
                    parametros.Add("@ID_ESPECI", entidad.ID_ESPECI);
                    parametros.Add("@ID_REF", entidad.ID_REF);
                    parametros.Add("@NUMREF", entidad.NUMREF);
                    parametros.Add("@ID_ZAFRA_PROD", entidad.ID_ZAFRA_PROD);
                    parametros.Add("@ID_PRODUCTO", entidad.ID_PRODUCTO);
                    parametros.Add("@ASIGNACIONO", entidad.ASIGNACIONO);
                    parametros.Add("@AMPLIACIONES", entidad.AMPLIACIONES);
                    parametros.Add("@ASIGNACIONT", entidad.ASIGNACIONT);
                    parametros.Add("@EJECUTADO", entidad.EJECUTADO);
                    parametros.Add("@SALDO", entidad.SALDO);
                    parametros.Add("@ESTADO", entidad.ESTADO);
                    parametros.Add("@OBSERVACION", entidad.OBSERVACION.Trim().ToUpper());
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    parametros.Add("@ES_PROPIO", entidad.ES_PROPIO);
                    parametros.Add("@ES_AJENO", entidad.ES_AJENO);
                    parametros.Add("@ID_ESTADO", entidad.ID_ESTADO);
                    regAfectados = db.Execute("UPD_ORDEN_GLOBAL_TRAS", parametros, commandType: CommandType.StoredProcedure);
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
                parametros.Add("@ID_ORDEN_TRAS", id);
                regAfectados = db.Execute("DEL_ORDEN_GLOBAL_TRAS", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }

    }
}
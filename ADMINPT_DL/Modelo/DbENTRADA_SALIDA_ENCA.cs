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
    public class DbENTRADA_SALIDA_ENCA : DbBase
    {
        public List<ENTRADA_SALIDA_ENCA> ObtenerLista()
        {
            List<ENTRADA_SALIDA_ENCA> lista = new List<ENTRADA_SALIDA_ENCA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ES_ENCA", -1);
                lista = db.Query<ENTRADA_SALIDA_ENCA>("SEL_ENTRADA_SALIDA_ENCA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }

        public List<ENTRADA_SALIDA_ENCA> ObtenerListaEspecial()
        {
            List<ENTRADA_SALIDA_ENCA> lista = new List<ENTRADA_SALIDA_ENCA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ES_ENCA", -1);
                lista = db.Query<ENTRADA_SALIDA_ENCA>("SEL_ENTRADA_SALIDA_ENCA_ESPECIAL", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public List<ENTRADA_SALIDA_ENCA> ObtenerListaTraslado()
        {
            List<ENTRADA_SALIDA_ENCA> lista = new List<ENTRADA_SALIDA_ENCA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ES_ENCA", -1);
                lista = db.Query<ENTRADA_SALIDA_ENCA>("SEL_ENTRADA_SALIDA_ENCA_TRASLADO", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public List<ENTRADA_SALIDA_ENCA> ObtenerListaTrasladoCfExpres()
        {
            List<ENTRADA_SALIDA_ENCA> lista = new List<ENTRADA_SALIDA_ENCA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ES_ENCA", -1);
                lista = db.Query<ENTRADA_SALIDA_ENCA>("SEL_ENTRADA_SALIDA_ENCA_TRASLADO_T", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public List<ENTRADA_SALIDA_ENCA> ObtenerListaTrasladoInterno()
        {
            List<ENTRADA_SALIDA_ENCA> lista = new List<ENTRADA_SALIDA_ENCA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ES_ENCA", -1);
                lista = db.Query<ENTRADA_SALIDA_ENCA>("SEL_ENTRADA_SALIDA_ENCA_TRASLADO_INTERNO", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }

        public List<ENTRADA_SALIDA_ENCA> ObtenerListaVtacDizucar()
        {
            List<ENTRADA_SALIDA_ENCA> lista = new List<ENTRADA_SALIDA_ENCA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ES_ENCA", -1);
                lista = db.Query<ENTRADA_SALIDA_ENCA>("SEL_ENTRADA_SALIDA_ENCA_VTACDIZUCAR", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }

        public List<ENTRADA_SALIDA_ENCA> ObtenerListaVtJiboa()
        {
            List<ENTRADA_SALIDA_ENCA> lista = new List<ENTRADA_SALIDA_ENCA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ES_ENCA", -1);
                lista = db.Query<ENTRADA_SALIDA_ENCA>("SEL_ENTRADA_SALIDA_ENCA_VTJIBOA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }

        public List<ENTRADA_SALIDA_ENCA> ObtenerListaDespacho()
        {
            List<ENTRADA_SALIDA_ENCA> lista = new List<ENTRADA_SALIDA_ENCA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ES_ENCA", -1);
                lista = db.Query<ENTRADA_SALIDA_ENCA>("SEL_ENTRADA_SALIDA_ENCA_DESPACHO", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }

        public ENTRADA_SALIDA_ENCA ObtenerPorId(long id)
        {
            List<ENTRADA_SALIDA_ENCA> lista = new List<ENTRADA_SALIDA_ENCA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ES_ENCA", id);
                lista = db.Query<ENTRADA_SALIDA_ENCA>("SEL_ENTRADA_SALIDA_ENCA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }

        public ENTRADA_SALIDA_ENCA ObtenerNDoc(long id, long idbg)
        {
            List<ENTRADA_SALIDA_ENCA> lista = new List<ENTRADA_SALIDA_ENCA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_TIPO", id);
                parametros.Add("@ID_BODEP", idbg);
                lista = db.Query<ENTRADA_SALIDA_ENCA>("VIEW_DOCUMENTO_NUMERACION", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public ENTRADA_SALIDA_ENCA ObtenerPorIdT(long id)
        {
            List<ENTRADA_SALIDA_ENCA> lista = new List<ENTRADA_SALIDA_ENCA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ES_ENCA", id);
                lista = db.Query<ENTRADA_SALIDA_ENCA>("SEL_ENTRADA_SALIDA_ENCA_T", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public int Agregar(ref ENTRADA_SALIDA_ENCA entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@COD_CAPTURA", entidad.COD_CAPTURA);
                parametros.Add("@FECHA", entidad.FECHA);
                parametros.Add("@ES_PROPIO", entidad.ES_PROPIO);
                parametros.Add("@ES_AJENO", entidad.ES_AJENO);
                parametros.Add("@ID_ZAFRA_PROD", entidad.ID_ZAFRA_PROD);
                parametros.Add("@ID_ZAFRA_ACTUAL", entidad.ID_ZAFRA_ACTUAL);
                parametros.Add("@ID_TIPO_MOV", entidad.ID_TIPO_MOV);
                parametros.Add("@ID_CONCE", entidad.ID_CONCE);
                parametros.Add("@ID_ESPECI", entidad.ID_ESPECI);
                parametros.Add("@ID_BODEGAO", entidad.ID_BODEGAO);
                parametros.Add("@ID_BODEGAD", entidad.ID_BODEGAD);
                // parametros.Add("@REFERENCIA_DETA", entidad.REFERENCIA_DETA);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                parametros.Add("@NUM_DOC", entidad.NUM_DOC);
                parametros.Add("@ID_ESTADO", entidad.ID_ESTADO);
                parametros.Add("@ID_ORDEN_TRAS", entidad.ID_ORDEN_TRAS);

                parametros.Add("@ID_PROV_TRAS", entidad.ID_PROV_TRAS);
                parametros.Add("@ID_TRANSPORTE", entidad.ID_TRANSPORTE);
                parametros.Add("@MOTORISTA", entidad.MOTORISTA);
                parametros.Add("@NIT", entidad.NIT);
                parametros.Add("@PLACA_CABEZAL", entidad.PLACA_CABEZAL);
                parametros.Add("@PLACA_REMOLQUE", entidad.PLACA_REMOLQUE);
                parametros.Add("@CONTENEDOR", entidad.CONTENEDOR);
                parametros.Add("@MARCHAMOS", entidad.MARCHAMOS);
                parametros.Add("@OBSERVACION", entidad.OBSERVACION);
                parametros.Add("@NFORMULARIO", entidad.NFORMULARIO);
                parametros.Add("@ID", 0, DbType.Int32, ParameterDirection.Output);
                regAfectados = db.Execute("CRE_ENTRADA_SALIDA_ENCA", parametros, commandType: CommandType.StoredProcedure);
                entidad.ID_ES_ENCA = parametros.Get<int>("@ID");

            }
            return regAfectados;
        }
        public int Actualizar(ref ENTRADA_SALIDA_ENCA entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_ES_ENCA > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_ES_ENCA", entidad.ID_ES_ENCA);
                    parametros.Add("@COD_CAPTURA", entidad.COD_CAPTURA);
                    parametros.Add("@FECHA", entidad.FECHA);
                    parametros.Add("@ES_PROPIO", entidad.ES_PROPIO);
                    parametros.Add("@ES_AJENO", entidad.ES_AJENO);
                    parametros.Add("@ID_ZAFRA_PROD", entidad.ID_ZAFRA_PROD);
                    parametros.Add("@ID_ZAFRA_ACTUAL", entidad.ID_ZAFRA_ACTUAL);
                    parametros.Add("@ID_TIPO_MOV", entidad.ID_TIPO_MOV);
                    parametros.Add("@ID_CONCE", entidad.ID_CONCE);
                    parametros.Add("@ID_ESPECI", entidad.ID_ESPECI);
                    parametros.Add("@ID_BODEGAO", entidad.ID_BODEGAO);
                    parametros.Add("@ID_BODEGAD", entidad.ID_BODEGAD);
                    //parametros.Add("@REFERENCIA_DETA", entidad.REFERENCIA_DETA);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    parametros.Add("@NUM_DOC", entidad.NUM_DOC);
                    parametros.Add("@ID_ESTADO", entidad.ID_ESTADO);
                    parametros.Add("@ID_ORDEN_TRAS", entidad.ID_ORDEN_TRAS);

                    parametros.Add("@ID_PROV_TRAS", entidad.ID_PROV_TRAS);
                    parametros.Add("@ID_TRANSPORTE", entidad.ID_TRANSPORTE);
                    parametros.Add("@MOTORISTA", entidad.MOTORISTA);
                    parametros.Add("@NIT", entidad.NIT);
                    parametros.Add("@PLACA_CABEZAL", entidad.PLACA_CABEZAL);
                    parametros.Add("@PLACA_REMOLQUE", entidad.PLACA_REMOLQUE);
                    parametros.Add("@CONTENEDOR", entidad.CONTENEDOR);
                    parametros.Add("@MARCHAMOS", entidad.MARCHAMOS);
                    parametros.Add("@OBSERVACION", entidad.OBSERVACION);
                    parametros.Add("@NFORMULARIO", entidad.NFORMULARIO);
                    regAfectados = db.Execute("UPD_ENTRADA_SALIDA_ENCA", parametros, commandType: CommandType.StoredProcedure);
                }
            }
            else
            {
                regAfectados = Agregar(ref entidad);
            }
            return regAfectados;
        }


        public int AgregarEspecial(ref ENTRADA_SALIDA_ENCA entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@COD_CAPTURA", entidad.COD_CAPTURA);
                parametros.Add("@FECHA", entidad.FECHA);
                parametros.Add("@ES_PROPIO", entidad.ES_PROPIO);
                parametros.Add("@ES_AJENO", entidad.ES_AJENO);
                parametros.Add("@ID_ZAFRA_PROD", entidad.ID_ZAFRA_PROD);
                parametros.Add("@ID_ZAFRA_ACTUAL", entidad.ID_ZAFRA_ACTUAL);
                parametros.Add("@ID_TIPO_MOV", entidad.ID_TIPO_MOV);
                parametros.Add("@ID_CONCE", entidad.ID_CONCE);
                parametros.Add("@ID_ESPECI", entidad.ID_ESPECI);
                parametros.Add("@ID_BODEGAO", entidad.ID_BODEGAO);
                parametros.Add("@ID_BODEGAD", entidad.ID_BODEGAD);
                // parametros.Add("@REFERENCIA_DETA", entidad.REFERENCIA_DETA);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                parametros.Add("@NUM_DOC", entidad.NUM_DOC);
                parametros.Add("@ID_ESTADO", entidad.ID_ESTADO);
                parametros.Add("@ID_ORDEN_TRAS", entidad.ID_ORDEN_TRAS);

                parametros.Add("@ID_PROV_TRAS", entidad.ID_PROV_TRAS);
                parametros.Add("@ID_TRANSPORTE", entidad.ID_TRANSPORTE);
                parametros.Add("@MOTORISTA", entidad.MOTORISTA);
                parametros.Add("@NIT", entidad.NIT);
                parametros.Add("@PLACA_CABEZAL", entidad.PLACA_CABEZAL);
                parametros.Add("@PLACA_REMOLQUE", entidad.PLACA_REMOLQUE);
                parametros.Add("@CONTENEDOR", entidad.CONTENEDOR);
                parametros.Add("@MARCHAMOS", entidad.MARCHAMOS);
                parametros.Add("@OBSERVACION", entidad.OBSERVACION);
                parametros.Add("@NFORMULARIO", entidad.NFORMULARIO);
                parametros.Add("@NFORMULARIO", entidad.NFORMULARIO);
                parametros.Add("@ID_BODEP", entidad.ID_BODEP);
                parametros.Add("@ID", 0, DbType.Int32, ParameterDirection.Output);
                regAfectados = db.Execute("CRE_ENTRADA_SALIDA_ENCA_ESPECIAL", parametros, commandType: CommandType.StoredProcedure);
                entidad.ID_ES_ENCA = parametros.Get<int>("@ID");

            }
            return regAfectados;
        }
        public int ActualizarEspecial(ref ENTRADA_SALIDA_ENCA entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_ES_ENCA > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_ES_ENCA", entidad.ID_ES_ENCA);
                    parametros.Add("@COD_CAPTURA", entidad.COD_CAPTURA);
                    parametros.Add("@FECHA", entidad.FECHA);
                    parametros.Add("@ES_PROPIO", entidad.ES_PROPIO);
                    parametros.Add("@ES_AJENO", entidad.ES_AJENO);
                    parametros.Add("@ID_ZAFRA_PROD", entidad.ID_ZAFRA_PROD);
                    parametros.Add("@ID_ZAFRA_ACTUAL", entidad.ID_ZAFRA_ACTUAL);
                    parametros.Add("@ID_TIPO_MOV", entidad.ID_TIPO_MOV);
                    parametros.Add("@ID_CONCE", entidad.ID_CONCE);
                    parametros.Add("@ID_ESPECI", entidad.ID_ESPECI);
                    parametros.Add("@ID_BODEGAO", entidad.ID_BODEGAO);
                    parametros.Add("@ID_BODEGAD", entidad.ID_BODEGAD);
                    //parametros.Add("@REFERENCIA_DETA", entidad.REFERENCIA_DETA);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    parametros.Add("@NUM_DOC", entidad.NUM_DOC);
                    parametros.Add("@ID_ESTADO", entidad.ID_ESTADO);
                    parametros.Add("@ID_ORDEN_TRAS", entidad.ID_ORDEN_TRAS);

                    parametros.Add("@ID_PROV_TRAS", entidad.ID_PROV_TRAS);
                    parametros.Add("@ID_TRANSPORTE", entidad.ID_TRANSPORTE);
                    parametros.Add("@MOTORISTA", entidad.MOTORISTA);
                    parametros.Add("@NIT", entidad.NIT);
                    parametros.Add("@PLACA_CABEZAL", entidad.PLACA_CABEZAL);
                    parametros.Add("@PLACA_REMOLQUE", entidad.PLACA_REMOLQUE);
                    parametros.Add("@CONTENEDOR", entidad.CONTENEDOR);
                    parametros.Add("@MARCHAMOS", entidad.MARCHAMOS);
                    parametros.Add("@OBSERVACION", entidad.OBSERVACION);
                    parametros.Add("@NFORMULARIO", entidad.NFORMULARIO);
                    parametros.Add("@ID_BODEP", entidad.ID_BODEP);
                    regAfectados = db.Execute("UPD_ENTRADA_SALIDA_ENCA_ESPECIAL", parametros, commandType: CommandType.StoredProcedure);
                }
            }
            else
            {
                regAfectados = AgregarEspecial(ref entidad);
            }
            return regAfectados;
        }

        public int AgregarTraslado(ref ENTRADA_SALIDA_ENCA entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@COD_CAPTURA", entidad.COD_CAPTURA);
                parametros.Add("@FECHA", entidad.FECHA);
                parametros.Add("@ES_PROPIO", entidad.ES_PROPIO);
                parametros.Add("@ES_AJENO", entidad.ES_AJENO);
                parametros.Add("@ID_ZAFRA_PROD", entidad.ID_ZAFRA_PROD);
                parametros.Add("@ID_ZAFRA_ACTUAL", entidad.ID_ZAFRA_ACTUAL);
                parametros.Add("@ID_TIPO_MOV", entidad.ID_TIPO_MOV);
                parametros.Add("@ID_CONCE", entidad.ID_CONCE);
                parametros.Add("@ID_ESPECI", entidad.ID_ESPECI);
                parametros.Add("@ID_BODEGAO", entidad.ID_BODEGAO);
                parametros.Add("@ID_BODEGAD", entidad.ID_BODEGAD);
                // parametros.Add("@REFERENCIA_DETA", entidad.REFERENCIA_DETA);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                parametros.Add("@NUM_DOC", entidad.NUM_DOC);
                parametros.Add("@ID_ESTADO", entidad.ID_ESTADO);
                parametros.Add("@ID_ORDEN_TRAS", entidad.ID_ORDEN_TRAS);

                parametros.Add("@ID_PROV_TRAS", entidad.ID_PROV_TRAS);
                parametros.Add("@ID_TRANSPORTE", entidad.ID_TRANSPORTE);
                parametros.Add("@MOTORISTA", entidad.MOTORISTA);
                parametros.Add("@NIT", entidad.NIT);
                parametros.Add("@PLACA_CABEZAL", entidad.PLACA_CABEZAL);
                parametros.Add("@PLACA_REMOLQUE", entidad.PLACA_REMOLQUE);
                parametros.Add("@CONTENEDOR", entidad.CONTENEDOR);
                parametros.Add("@MARCHAMOS", entidad.MARCHAMOS);
                parametros.Add("@OBSERVACION", entidad.OBSERVACION);
                parametros.Add("@NFORMULARIO", entidad.NFORMULARIO);
                parametros.Add("@ID_BODEP", entidad.ID_BODEP);
                parametros.Add("@ID", 0, DbType.Int32, ParameterDirection.Output);
                regAfectados = db.Execute("CRE_ENTRADA_SALIDA_ENCA_TRASLADO", parametros, commandType: CommandType.StoredProcedure);
                entidad.ID_ES_ENCA = parametros.Get<int>("@ID");

            }
            return regAfectados;
        }
        public int ActualizarTraslado(ref ENTRADA_SALIDA_ENCA entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_ES_ENCA > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_ES_ENCA", entidad.ID_ES_ENCA);
                    parametros.Add("@COD_CAPTURA", entidad.COD_CAPTURA);
                    parametros.Add("@FECHA", entidad.FECHA);
                    parametros.Add("@ES_PROPIO", entidad.ES_PROPIO);
                    parametros.Add("@ES_AJENO", entidad.ES_AJENO);
                    parametros.Add("@ID_ZAFRA_PROD", entidad.ID_ZAFRA_PROD);
                    parametros.Add("@ID_ZAFRA_ACTUAL", entidad.ID_ZAFRA_ACTUAL);
                    parametros.Add("@ID_TIPO_MOV", entidad.ID_TIPO_MOV);
                    parametros.Add("@ID_CONCE", entidad.ID_CONCE);
                    parametros.Add("@ID_ESPECI", entidad.ID_ESPECI);
                    parametros.Add("@ID_BODEGAO", entidad.ID_BODEGAO);
                    parametros.Add("@ID_BODEGAD", entidad.ID_BODEGAD);
                    //parametros.Add("@REFERENCIA_DETA", entidad.REFERENCIA_DETA);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    parametros.Add("@NUM_DOC", entidad.NUM_DOC);
                    parametros.Add("@ID_ESTADO", entidad.ID_ESTADO);
                    parametros.Add("@ID_ORDEN_TRAS", entidad.ID_ORDEN_TRAS);

                    parametros.Add("@ID_PROV_TRAS", entidad.ID_PROV_TRAS);
                    parametros.Add("@ID_TRANSPORTE", entidad.ID_TRANSPORTE);
                    parametros.Add("@MOTORISTA", entidad.MOTORISTA);
                    parametros.Add("@NIT", entidad.NIT);
                    parametros.Add("@PLACA_CABEZAL", entidad.PLACA_CABEZAL);
                    parametros.Add("@PLACA_REMOLQUE", entidad.PLACA_REMOLQUE);
                    parametros.Add("@CONTENEDOR", entidad.CONTENEDOR);
                    parametros.Add("@MARCHAMOS", entidad.MARCHAMOS);
                    parametros.Add("@OBSERVACION", entidad.OBSERVACION);
                    parametros.Add("@NFORMULARIO", entidad.NFORMULARIO);
                    parametros.Add("@ID_BODEP", entidad.ID_BODEP);
                    regAfectados = db.Execute("UPD_ENTRADA_SALIDA_ENCA_TRASLADO", parametros, commandType: CommandType.StoredProcedure);
                }
            }
            else
            {
                regAfectados = AgregarTraslado(ref entidad);
            }
            return regAfectados;
        }

        public int AgregarTrasladoExpres(ref ENTRADA_SALIDA_ENCA entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@COD_CAPTURA", entidad.COD_CAPTURA);
                parametros.Add("@FECHA", entidad.FECHA);
                parametros.Add("@ES_PROPIO", entidad.ES_PROPIO);
                parametros.Add("@ES_AJENO", entidad.ES_AJENO);
                parametros.Add("@ID_ZAFRA_PROD", entidad.ID_ZAFRA_PROD);
                parametros.Add("@ID_ZAFRA_ACTUAL", entidad.ID_ZAFRA_ACTUAL);
                parametros.Add("@ID_TIPO_MOV", entidad.ID_TIPO_MOV);
                parametros.Add("@ID_CONCE", entidad.ID_CONCE);
                parametros.Add("@ID_ESPECI", entidad.ID_ESPECI);
                parametros.Add("@ID_BODEGAO", entidad.ID_BODEGAO);
                parametros.Add("@ID_BODEGAD", entidad.ID_BODEGAD);
                // parametros.Add("@REFERENCIA_DETA", entidad.REFERENCIA_DETA);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                parametros.Add("@NUM_DOC", entidad.NUM_DOC);
                parametros.Add("@ID_ESTADO", entidad.ID_ESTADO);
                parametros.Add("@ID_ORDEN_TRAS", entidad.ID_ORDEN_TRAS);

                parametros.Add("@ID_PROV_TRAS", entidad.ID_PROV_TRAS);
                parametros.Add("@ID_TRANSPORTE", entidad.ID_TRANSPORTE);
                parametros.Add("@MOTORISTA", entidad.MOTORISTA);
                parametros.Add("@NIT", entidad.NIT);
                parametros.Add("@PLACA_CABEZAL", entidad.PLACA_CABEZAL);
                parametros.Add("@PLACA_REMOLQUE", entidad.PLACA_REMOLQUE);
                parametros.Add("@CONTENEDOR", entidad.CONTENEDOR);
                parametros.Add("@MARCHAMOS", entidad.MARCHAMOS);
                parametros.Add("@OBSERVACION", entidad.OBSERVACION);
                parametros.Add("@NFORMULARIO", entidad.NFORMULARIO);
                parametros.Add("@ID_BODEP", entidad.ID_BODEP);
                parametros.Add("@ID", 0, DbType.Int32, ParameterDirection.Output);
                regAfectados = db.Execute("CRE_ENTRADA_SALIDA_ENCA_TRASLADO_EXPRES", parametros, commandType: CommandType.StoredProcedure);
                entidad.ID_ES_ENCA = parametros.Get<int>("@ID");

            }
            return regAfectados;
        }
        public int ActualizarTrasladoExpres(ref ENTRADA_SALIDA_ENCA entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_ES_ENCA > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_ES_ENCA", entidad.ID_ES_ENCA);
                    parametros.Add("@COD_CAPTURA", entidad.COD_CAPTURA);
                    parametros.Add("@FECHA", entidad.FECHA);
                    parametros.Add("@ES_PROPIO", entidad.ES_PROPIO);
                    parametros.Add("@ES_AJENO", entidad.ES_AJENO);
                    parametros.Add("@ID_ZAFRA_PROD", entidad.ID_ZAFRA_PROD);
                    parametros.Add("@ID_ZAFRA_ACTUAL", entidad.ID_ZAFRA_ACTUAL);
                    parametros.Add("@ID_TIPO_MOV", entidad.ID_TIPO_MOV);
                    parametros.Add("@ID_CONCE", entidad.ID_CONCE);
                    parametros.Add("@ID_ESPECI", entidad.ID_ESPECI);
                    parametros.Add("@ID_BODEGAO", entidad.ID_BODEGAO);
                    parametros.Add("@ID_BODEGAD", entidad.ID_BODEGAD);
                    //parametros.Add("@REFERENCIA_DETA", entidad.REFERENCIA_DETA);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    parametros.Add("@NUM_DOC", entidad.NUM_DOC);
                    parametros.Add("@ID_ESTADO", entidad.ID_ESTADO);
                    parametros.Add("@ID_ORDEN_TRAS", entidad.ID_ORDEN_TRAS);

                    parametros.Add("@ID_PROV_TRAS", entidad.ID_PROV_TRAS);
                    parametros.Add("@ID_TRANSPORTE", entidad.ID_TRANSPORTE);
                    parametros.Add("@MOTORISTA", entidad.MOTORISTA);
                    parametros.Add("@NIT", entidad.NIT);
                    parametros.Add("@PLACA_CABEZAL", entidad.PLACA_CABEZAL);
                    parametros.Add("@PLACA_REMOLQUE", entidad.PLACA_REMOLQUE);
                    parametros.Add("@CONTENEDOR", entidad.CONTENEDOR);
                    parametros.Add("@MARCHAMOS", entidad.MARCHAMOS);
                    parametros.Add("@OBSERVACION", entidad.OBSERVACION);
                    parametros.Add("@NFORMULARIO", entidad.NFORMULARIO);
                    parametros.Add("@ID_BODEP", entidad.ID_BODEP);
                    regAfectados = db.Execute("UPD_ENTRADA_SALIDA_ENCA_TRASLADO", parametros, commandType: CommandType.StoredProcedure);
                }
            }
            else
            {
                regAfectados = AgregarTrasladoExpres(ref entidad);
            }
            return regAfectados;
        }

        public int AgregarVtaDizucar(ref ENTRADA_SALIDA_ENCA entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@COD_CAPTURA", entidad.COD_CAPTURA);
                parametros.Add("@FECHA", entidad.FECHA);
                parametros.Add("@ES_PROPIO", entidad.ES_PROPIO);
                parametros.Add("@ES_AJENO", entidad.ES_AJENO);
                parametros.Add("@ID_ZAFRA_PROD", entidad.ID_ZAFRA_PROD);
                parametros.Add("@ID_ZAFRA_ACTUAL", entidad.ID_ZAFRA_ACTUAL);
                parametros.Add("@ID_TIPO_MOV", entidad.ID_TIPO_MOV);
                parametros.Add("@ID_CONCE", entidad.ID_CONCE);
                parametros.Add("@ID_ESPECI", entidad.ID_ESPECI);
                parametros.Add("@ID_BODEGAO", entidad.ID_BODEGAO);
                parametros.Add("@ID_BODEGAD", entidad.ID_BODEGAD);
                // parametros.Add("@REFERENCIA_DETA", entidad.REFERENCIA_DETA);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                parametros.Add("@NUM_DOC", entidad.NUM_DOC);
                parametros.Add("@ID_ESTADO", entidad.ID_ESTADO);
                parametros.Add("@ID_ORDEN_TRAS", entidad.ID_ORDEN_TRAS);

                parametros.Add("@ID_PROV_TRAS", entidad.ID_PROV_TRAS);
                parametros.Add("@ID_TRANSPORTE", entidad.ID_TRANSPORTE);
                parametros.Add("@MOTORISTA", entidad.MOTORISTA);
                parametros.Add("@NIT", entidad.NIT);
                parametros.Add("@PLACA_CABEZAL", entidad.PLACA_CABEZAL);
                parametros.Add("@PLACA_REMOLQUE", entidad.PLACA_REMOLQUE);
                parametros.Add("@CONTENEDOR", entidad.CONTENEDOR);
                parametros.Add("@MARCHAMOS", entidad.MARCHAMOS);
                parametros.Add("@OBSERVACION", entidad.OBSERVACION);
                parametros.Add("@NFORMULARIO", entidad.NFORMULARIO);
                parametros.Add("@ID_TIPO", entidad.ID_TIPO);
                parametros.Add("@ID_BODEP", entidad.ID_BODEP);
                parametros.Add("@ID", 0, DbType.Int32, ParameterDirection.Output);
                regAfectados = db.Execute("CRE_ENTRADA_SALIDA_ENCA_VTADIZUCAR", parametros, commandType: CommandType.StoredProcedure);
                entidad.ID_ES_ENCA = parametros.Get<int>("@ID");

            }
            return regAfectados;
        }
        public int ActualizarVtaDizucar(ref ENTRADA_SALIDA_ENCA entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_ES_ENCA > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_ES_ENCA", entidad.ID_ES_ENCA);
                    parametros.Add("@COD_CAPTURA", entidad.COD_CAPTURA);
                    parametros.Add("@FECHA", entidad.FECHA);
                    parametros.Add("@ES_PROPIO", entidad.ES_PROPIO);
                    parametros.Add("@ES_AJENO", entidad.ES_AJENO);
                    parametros.Add("@ID_ZAFRA_PROD", entidad.ID_ZAFRA_PROD);
                    parametros.Add("@ID_ZAFRA_ACTUAL", entidad.ID_ZAFRA_ACTUAL);
                    parametros.Add("@ID_TIPO_MOV", entidad.ID_TIPO_MOV);
                    parametros.Add("@ID_CONCE", entidad.ID_CONCE);
                    parametros.Add("@ID_ESPECI", entidad.ID_ESPECI);
                    parametros.Add("@ID_BODEGAO", entidad.ID_BODEGAO);
                    parametros.Add("@ID_BODEGAD", entidad.ID_BODEGAD);
                    //parametros.Add("@REFERENCIA_DETA", entidad.REFERENCIA_DETA);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    parametros.Add("@NUM_DOC", entidad.NUM_DOC);
                    parametros.Add("@ID_ESTADO", entidad.ID_ESTADO);
                    parametros.Add("@ID_ORDEN_TRAS", entidad.ID_ORDEN_TRAS);

                    parametros.Add("@ID_PROV_TRAS", entidad.ID_PROV_TRAS);
                    parametros.Add("@ID_TRANSPORTE", entidad.ID_TRANSPORTE);
                    parametros.Add("@MOTORISTA", entidad.MOTORISTA);
                    parametros.Add("@NIT", entidad.NIT);
                    parametros.Add("@PLACA_CABEZAL", entidad.PLACA_CABEZAL);
                    parametros.Add("@PLACA_REMOLQUE", entidad.PLACA_REMOLQUE);
                    parametros.Add("@CONTENEDOR", entidad.CONTENEDOR);
                    parametros.Add("@MARCHAMOS", entidad.MARCHAMOS);
                    parametros.Add("@OBSERVACION", entidad.OBSERVACION);
                    parametros.Add("@NFORMULARIO", entidad.NFORMULARIO);
                    parametros.Add("@ID_BODEP", entidad.ID_BODEP);
                    regAfectados = db.Execute("UPD_ENTRADA_SALIDA_ENCA_VTADIZUCAR", parametros, commandType: CommandType.StoredProcedure);
                }
            }
            else
            {
                regAfectados = AgregarVtaDizucar(ref entidad);
            }
            return regAfectados;
        }

        public int AgregarVtaJiboa(ref ENTRADA_SALIDA_ENCA entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@COD_CAPTURA", entidad.COD_CAPTURA);
                parametros.Add("@FECHA", entidad.FECHA);
                parametros.Add("@ES_PROPIO", entidad.ES_PROPIO);
                parametros.Add("@ES_AJENO", entidad.ES_AJENO);
                parametros.Add("@ID_ZAFRA_PROD", entidad.ID_ZAFRA_PROD);
                parametros.Add("@ID_ZAFRA_ACTUAL", entidad.ID_ZAFRA_ACTUAL);
                parametros.Add("@ID_TIPO_MOV", entidad.ID_TIPO_MOV);
                parametros.Add("@ID_CONCE", entidad.ID_CONCE);
                parametros.Add("@ID_ESPECI", entidad.ID_ESPECI);
                parametros.Add("@ID_BODEGAO", entidad.ID_BODEGAO);
                parametros.Add("@ID_BODEGAD", entidad.ID_BODEGAD);
                // parametros.Add("@REFERENCIA_DETA", entidad.REFERENCIA_DETA);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                parametros.Add("@NUM_DOC", entidad.NUM_DOC);
                parametros.Add("@ID_ESTADO", entidad.ID_ESTADO);
                parametros.Add("@ID_ORDEN_TRAS", entidad.ID_ORDEN_TRAS);

                parametros.Add("@ID_PROV_TRAS", entidad.ID_PROV_TRAS);
                parametros.Add("@ID_TRANSPORTE", entidad.ID_TRANSPORTE);
                parametros.Add("@MOTORISTA", entidad.MOTORISTA);
                parametros.Add("@NIT", entidad.NIT);
                parametros.Add("@PLACA_CABEZAL", entidad.PLACA_CABEZAL);
                parametros.Add("@PLACA_REMOLQUE", entidad.PLACA_REMOLQUE);
                parametros.Add("@CONTENEDOR", entidad.CONTENEDOR);
                parametros.Add("@MARCHAMOS", entidad.MARCHAMOS);
                parametros.Add("@OBSERVACION", entidad.OBSERVACION);
                parametros.Add("@NFORMULARIO", entidad.NFORMULARIO);
                parametros.Add("@ENCCLIENTE", entidad.ENCCLIENTE);
                parametros.Add("@ENCNIT", entidad.ENCNIT);
                parametros.Add("@ENCNRC", entidad.ENCNRC);
                parametros.Add("@ENCDEPARTAMENTO", entidad.ENCDEPARTAMENTO);
                parametros.Add("@ENCMUNICIPIO", entidad.ENCMUNICIPIO);
                parametros.Add("@ENCGIRO", entidad.ENCGIRO);
                parametros.Add("@ENCDIRECCION", entidad.ENCDIRECCION);
                parametros.Add("@ID_TIPO", entidad.ID_TIPO);
                parametros.Add("@ID_BODEP", entidad.ID_BODEP);
                parametros.Add("@ID_FMPAGO", entidad.ID_FMPAGO);
                parametros.Add("@EFECTIVO", entidad.EFECTIVO);
                parametros.Add("@CHEQUE", entidad.CHEQUE);
                parametros.Add("@NOTAABONO", entidad.NOTAABONO);
                parametros.Add("@TOTAL", entidad.TOTAL);
                parametros.Add("@NCUENTA", entidad.NCUENTA);
                parametros.Add("@NCHEQUE", entidad.NCHEQUE);
                parametros.Add("@BANCO", entidad.BANCO);
                parametros.Add("@MCHEQUE", entidad.MCHEQUE);
                parametros.Add("@MNOTAABONO", entidad.MNOTAABONO);
                parametros.Add("@ID", 0, DbType.Int32, ParameterDirection.Output);
                regAfectados = db.Execute("CRE_ENTRADA_SALIDA_ENCA_VJIBOA", parametros, commandType: CommandType.StoredProcedure);
                entidad.ID_ES_ENCA = parametros.Get<int>("@ID");

            }
            return regAfectados;
        }
        public int ActualizarVtaJiboa(ref ENTRADA_SALIDA_ENCA entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_ES_ENCA > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_ES_ENCA", entidad.ID_ES_ENCA);
                    parametros.Add("@COD_CAPTURA", entidad.COD_CAPTURA);
                    parametros.Add("@FECHA", entidad.FECHA);
                    parametros.Add("@ES_PROPIO", entidad.ES_PROPIO);
                    parametros.Add("@ES_AJENO", entidad.ES_AJENO);
                    parametros.Add("@ID_ZAFRA_PROD", entidad.ID_ZAFRA_PROD);
                    parametros.Add("@ID_ZAFRA_ACTUAL", entidad.ID_ZAFRA_ACTUAL);
                    parametros.Add("@ID_TIPO_MOV", entidad.ID_TIPO_MOV);
                    parametros.Add("@ID_CONCE", entidad.ID_CONCE);
                    parametros.Add("@ID_ESPECI", entidad.ID_ESPECI);
                    parametros.Add("@ID_BODEGAO", entidad.ID_BODEGAO);
                    parametros.Add("@ID_BODEGAD", entidad.ID_BODEGAD);
                    //parametros.Add("@REFERENCIA_DETA", entidad.REFERENCIA_DETA);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    parametros.Add("@NUM_DOC", entidad.NUM_DOC);
                    parametros.Add("@ID_ESTADO", entidad.ID_ESTADO);
                    parametros.Add("@ID_ORDEN_TRAS", entidad.ID_ORDEN_TRAS);

                    parametros.Add("@ID_PROV_TRAS", entidad.ID_PROV_TRAS);
                    parametros.Add("@ID_TRANSPORTE", entidad.ID_TRANSPORTE);
                    parametros.Add("@MOTORISTA", entidad.MOTORISTA);
                    parametros.Add("@NIT", entidad.NIT);
                    parametros.Add("@PLACA_CABEZAL", entidad.PLACA_CABEZAL);
                    parametros.Add("@PLACA_REMOLQUE", entidad.PLACA_REMOLQUE);
                    parametros.Add("@CONTENEDOR", entidad.CONTENEDOR);
                    parametros.Add("@MARCHAMOS", entidad.MARCHAMOS);
                    parametros.Add("@OBSERVACION", entidad.OBSERVACION);
                    parametros.Add("@NFORMULARIO", entidad.NFORMULARIO);
                    parametros.Add("@ENCCLIENTE", entidad.ENCCLIENTE);
                    parametros.Add("@ENCNIT", entidad.ENCNIT);
                    parametros.Add("@ENCNRC", entidad.ENCNRC);
                    parametros.Add("@ENCDEPARTAMENTO", entidad.ENCDEPARTAMENTO);
                    parametros.Add("@ENCMUNICIPIO", entidad.ENCMUNICIPIO);
                    parametros.Add("@ENCGIRO", entidad.ENCGIRO);
                    parametros.Add("@ENCDIRECCION", entidad.ENCDIRECCION);
                    regAfectados = db.Execute("UPD_ENTRADA_SALIDA_ENCA_VJIBOA", parametros, commandType: CommandType.StoredProcedure);
                }
            }
            else
            {
                regAfectados = AgregarVtaJiboa(ref entidad);
            }
            return regAfectados;
        }

        public int ActualizarDespacho(ENTRADA_SALIDA_ENCA entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_ES_ENCA > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_ES_ENCA", entidad.ID_ES_ENCA);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_CREA);                  
                    parametros.Add("@FECHADESPACHO", entidad.FECHADESPACHO);
                    parametros.Add("@ID_ESTIBA", entidad.ID_ESTIBA);
                    parametros.Add("@TENDIDO", entidad.TENDIDO);
                    parametros.Add("@FECHA_PRODUCCION", entidad.FECHA_PRODUCCION);
                    parametros.Add("@FECHA_PRODUCCION1", entidad.FECHA_PRODUCCION1);
                    parametros.Add("@COLOR", entidad.COLOR);
                    parametros.Add("@ID_ZAFRA_PROD", entidad.ID_ZAFRA_PROD);
                    parametros.Add("@OBSERVACION", entidad.OBSERVACION);
                    regAfectados = db.Execute("UPD_ENTRADA_SALIDA_ENCA_DESPACHO", parametros, commandType: CommandType.StoredProcedure);
                }
            }

            return regAfectados;
        }


        public int AgregarTrasladoCfExpres(ref ENTRADA_SALIDA_ENCA entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@COD_CAPTURA", entidad.COD_CAPTURA);
                parametros.Add("@FECHA", entidad.FECHA);
                parametros.Add("@ES_PROPIO", entidad.ES_PROPIO);
                parametros.Add("@ES_AJENO", entidad.ES_AJENO);
                parametros.Add("@ID_ZAFRA_PROD", entidad.ID_ZAFRA_PROD);
                parametros.Add("@ID_ZAFRA_ACTUAL", entidad.ID_ZAFRA_ACTUAL);
                parametros.Add("@ID_TIPO_MOV", entidad.ID_TIPO_MOV);
                parametros.Add("@ID_CONCE", entidad.ID_CONCE);
                parametros.Add("@ID_ESPECI", entidad.ID_ESPECI);
                parametros.Add("@ID_BODEGAO", entidad.ID_BODEGAO);
                parametros.Add("@ID_BODEGAD", entidad.ID_BODEGAD);
                // parametros.Add("@REFERENCIA_DETA", entidad.REFERENCIA_DETA);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                parametros.Add("@NUM_DOC", entidad.NUM_DOC);
                parametros.Add("@ID_ESTADO", entidad.ID_ESTADO);
                parametros.Add("@ID_ORDEN_TRAS", entidad.ID_ORDEN_TRAS);

                parametros.Add("@ID_PROV_TRAS", entidad.ID_PROV_TRAS);
                parametros.Add("@ID_TRANSPORTE", entidad.ID_TRANSPORTE);
                parametros.Add("@MOTORISTA", entidad.MOTORISTA);
                parametros.Add("@NIT", entidad.NIT);
                parametros.Add("@PLACA_CABEZAL", entidad.PLACA_CABEZAL);
                parametros.Add("@PLACA_REMOLQUE", entidad.PLACA_REMOLQUE);
                parametros.Add("@CONTENEDOR", entidad.CONTENEDOR);
                parametros.Add("@MARCHAMOS", entidad.MARCHAMOS);
                parametros.Add("@OBSERVACION", entidad.OBSERVACION);
                parametros.Add("@NFORMULARIO", entidad.NFORMULARIO);

                parametros.Add("@ID", 0, DbType.Int32, ParameterDirection.Output);
                regAfectados = db.Execute("CRE_ENTRADA_SALIDA_ENCA_TRASLADO_T", parametros, commandType: CommandType.StoredProcedure);
                entidad.ID_ES_ENCA = parametros.Get<int>("@ID");

            }
            return regAfectados;
        }
        public int ActualizarTrasladoCfExpres(ref ENTRADA_SALIDA_ENCA entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_ES_ENCA > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_ES_ENCA", entidad.ID_ES_ENCA);
                    parametros.Add("@COD_CAPTURA", entidad.COD_CAPTURA);
                    parametros.Add("@FECHA", entidad.FECHA);
                    parametros.Add("@ES_PROPIO", entidad.ES_PROPIO);
                    parametros.Add("@ES_AJENO", entidad.ES_AJENO);
                    parametros.Add("@ID_ZAFRA_PROD", entidad.ID_ZAFRA_PROD);
                    parametros.Add("@ID_ZAFRA_ACTUAL", entidad.ID_ZAFRA_ACTUAL);
                    parametros.Add("@ID_TIPO_MOV", entidad.ID_TIPO_MOV);
                    parametros.Add("@ID_CONCE", entidad.ID_CONCE);
                    parametros.Add("@ID_ESPECI", entidad.ID_ESPECI);
                    parametros.Add("@ID_BODEGAO", entidad.ID_BODEGAO);
                    parametros.Add("@ID_BODEGAD", entidad.ID_BODEGAD);
                    //parametros.Add("@REFERENCIA_DETA", entidad.REFERENCIA_DETA);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    parametros.Add("@NUM_DOC", entidad.NUM_DOC);
                    parametros.Add("@ID_ESTADO", entidad.ID_ESTADO);
                    parametros.Add("@ID_ORDEN_TRAS", entidad.ID_ORDEN_TRAS);

                    parametros.Add("@ID_PROV_TRAS", entidad.ID_PROV_TRAS);
                    parametros.Add("@ID_TRANSPORTE", entidad.ID_TRANSPORTE);
                    parametros.Add("@MOTORISTA", entidad.MOTORISTA);
                    parametros.Add("@NIT", entidad.NIT);
                    parametros.Add("@PLACA_CABEZAL", entidad.PLACA_CABEZAL);
                    parametros.Add("@PLACA_REMOLQUE", entidad.PLACA_REMOLQUE);
                    parametros.Add("@CONTENEDOR", entidad.CONTENEDOR);
                    parametros.Add("@MARCHAMOS", entidad.MARCHAMOS);
                    parametros.Add("@OBSERVACION", entidad.OBSERVACION);
                    parametros.Add("@NFORMULARIO", entidad.NFORMULARIO);
                    regAfectados = db.Execute("UPD_ENTRADA_SALIDA_ENCA_T", parametros, commandType: CommandType.StoredProcedure);
                }
            }
            else
            {
                regAfectados = AgregarTrasladoCfExpres(ref entidad);
            }
            return regAfectados;
        }

        public int Eliminar(int id)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ENTRADA_SALIDA_ENCA", id);
                regAfectados = db.Execute("DEL_ENTRADA_SALIDA_ENCA", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
    }
}
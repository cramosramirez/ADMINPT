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
    public class DbENTRADA_SALIDA_DETA : DbBase
    {
        public List<ENTRADA_SALIDA_DETA> ObtenerLista()
        {
            List<ENTRADA_SALIDA_DETA> lista = new List<ENTRADA_SALIDA_DETA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ENTRADA_SALIDA_DETA", -1);
                lista = db.Query<ENTRADA_SALIDA_DETA>("SEL_ENTRADA_SALIDA_DETA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public ENTRADA_SALIDA_DETA ObtenerPorId(long id)
        {
            List<ENTRADA_SALIDA_DETA> lista = new List<ENTRADA_SALIDA_DETA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ES_ENCA", id);
                lista = db.Query<ENTRADA_SALIDA_DETA>("SEL_ENTRADA_SALIDA_DETA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public ENTRADA_SALIDA_DETA ObtenerPorIdT(long id)
        {
            List<ENTRADA_SALIDA_DETA> lista = new List<ENTRADA_SALIDA_DETA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ES_ENCA", id);
                lista = db.Query<ENTRADA_SALIDA_DETA>("SEL_ENTRADA_SALIDA_DETA_T", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public ENTRADA_SALIDA_DETA ObtenerPorIdEnc(long id)
        {
            List<ENTRADA_SALIDA_DETA> lista = new List<ENTRADA_SALIDA_DETA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ES_ENCA ", id);
                lista = db.Query<ENTRADA_SALIDA_DETA>("SEL_ENTRADA_SALIDA_DETA_ENCA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public ENTRADA_SALIDA_DETA ObtenerPorIdEncT(long id)
        {
            List<ENTRADA_SALIDA_DETA> lista = new List<ENTRADA_SALIDA_DETA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ES_ENCA ", id);
                lista = db.Query<ENTRADA_SALIDA_DETA>("SEL_ENTRADA_SALIDA_DETA_ENCA_T", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public int Agregar(ENTRADA_SALIDA_DETA entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ES_ENCA", entidad.ID_ES_ENCA);
                parametros.Add("@ID_PRODUCTO", entidad.ID_PRODUCTO);
                parametros.Add("@ID_PRESEN_TRAS", entidad.ID_PRESEN_TRAS);
                parametros.Add("@ID_UNIDAD_FAC", entidad.ID_UNIDAD_FAC);
                parametros.Add("@CANTIDAD", entidad.CANTIDAD);
                parametros.Add("@FACTOR", entidad.FACTOR);
                parametros.Add("@REFERENCIA_DETA", entidad.REFERENCIA_DETA);               
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                parametros.Add("@FACTORKG", entidad.FACTORKG);
                regAfectados = db.Execute("CRE_ENTRADA_SALIDA_DETA", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int Actualizar(ENTRADA_SALIDA_DETA entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_ES_DETA > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_ES_DETA", entidad.ID_ES_DETA);
                    parametros.Add("@ID_ES_ENCA", entidad.ID_ES_ENCA);
                    parametros.Add("@ID_PRODUCTO", entidad.ID_PRODUCTO);
                    parametros.Add("@ID_PRESEN_TRAS", entidad.ID_PRESEN_TRAS);
                    parametros.Add("@ID_UNIDAD_FAC", entidad.ID_UNIDAD_FAC);
                    parametros.Add("@CANTIDAD", entidad.CANTIDAD);
                    parametros.Add("@FACTOR", entidad.FACTOR);
                    parametros.Add("@REFERENCIA_DETA", entidad.REFERENCIA_DETA);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    parametros.Add("@FACTORKG", entidad.FACTORKG);
                    regAfectados = db.Execute("UPD_ENTRADA_SALIDA_DETA", parametros, commandType: CommandType.StoredProcedure);
                }
            }
            else
            {
                regAfectados = Agregar(entidad);
            }
            return regAfectados;
        }

        public int AgregarEspecial(ENTRADA_SALIDA_DETA entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ES_ENCA", entidad.ID_ES_ENCA);
                parametros.Add("@ID_PRODUCTO", entidad.ID_PRODUCTO);
                parametros.Add("@ID_PRESEN_TRAS", entidad.ID_PRESEN_TRAS);
                parametros.Add("@ID_UNIDAD_FAC", entidad.ID_UNIDAD_FAC);
                parametros.Add("@CANTIDAD", entidad.CANTIDAD);
                parametros.Add("@FACTOR", entidad.FACTOR);
                parametros.Add("@REFERENCIA_DETA", entidad.REFERENCIA_DETA);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                parametros.Add("@FACTORKG", entidad.FACTORKG);
                parametros.Add("@ID_BODEP", entidad.ID_BODEP);
                regAfectados = db.Execute("CRE_ENTRADA_SALIDA_DETA_ESPECIAL", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int ActualizarEspecial(ENTRADA_SALIDA_DETA entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_ES_DETA > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_ES_DETA", entidad.ID_ES_DETA);
                    parametros.Add("@ID_ES_ENCA", entidad.ID_ES_ENCA);
                    parametros.Add("@ID_PRODUCTO", entidad.ID_PRODUCTO);
                    parametros.Add("@ID_PRESEN_TRAS", entidad.ID_PRESEN_TRAS);
                    parametros.Add("@ID_UNIDAD_FAC", entidad.ID_UNIDAD_FAC);
                    parametros.Add("@CANTIDAD", entidad.CANTIDAD);
                    parametros.Add("@FACTOR", entidad.FACTOR);
                    parametros.Add("@REFERENCIA_DETA", entidad.REFERENCIA_DETA);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    parametros.Add("@FACTORKG", entidad.FACTORKG);
                    parametros.Add("@ID_BODEP", entidad.ID_BODEP);
                    regAfectados = db.Execute("UPD_ENTRADA_SALIDA_DETA_ESPECIAL", parametros, commandType: CommandType.StoredProcedure);
                }
            }
            else
            {
                regAfectados = AgregarEspecial(entidad);
            }
            return regAfectados;
        }

        public int AgregarTraslado(ENTRADA_SALIDA_DETA entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ES_ENCA", entidad.ID_ES_ENCA);
                parametros.Add("@ID_PRODUCTO", entidad.ID_PRODUCTO);
                parametros.Add("@ID_PRESEN_TRAS", entidad.ID_PRESEN_TRAS);
                parametros.Add("@ID_UNIDAD_FAC", entidad.ID_UNIDAD_FAC);
                parametros.Add("@CANTIDAD", entidad.CANTIDAD);
                parametros.Add("@FACTOR", entidad.FACTOR);
                parametros.Add("@REFERENCIA_DETA", entidad.REFERENCIA_DETA);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                parametros.Add("@FACTORKG", entidad.FACTORKG);
                parametros.Add("@ID_BODEP", entidad.ID_BODEP);
                regAfectados = db.Execute("CRE_ENTRADA_SALIDA_DETA_TRASLADO", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int ActualizarTraslado(ENTRADA_SALIDA_DETA entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_ES_DETA > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_ES_DETA", entidad.ID_ES_DETA);
                    parametros.Add("@ID_ES_ENCA", entidad.ID_ES_ENCA);
                    parametros.Add("@ID_PRODUCTO", entidad.ID_PRODUCTO);
                    parametros.Add("@ID_PRESEN_TRAS", entidad.ID_PRESEN_TRAS);
                    parametros.Add("@ID_UNIDAD_FAC", entidad.ID_UNIDAD_FAC);
                    parametros.Add("@CANTIDAD", entidad.CANTIDAD);
                    parametros.Add("@FACTOR", entidad.FACTOR);
                    parametros.Add("@REFERENCIA_DETA", entidad.REFERENCIA_DETA);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    parametros.Add("@FACTORKG", entidad.FACTORKG);
                    parametros.Add("@ID_BODEP", entidad.ID_BODEP);
                    regAfectados = db.Execute("UPD_ENTRADA_SALIDA_DETA_TRASLADO", parametros, commandType: CommandType.StoredProcedure);
                }
            }
            else
            {
                regAfectados = AgregarTraslado(entidad);
            }
            return regAfectados;
        }

        public int AgregarTrasladoExpres(ENTRADA_SALIDA_DETA entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ES_ENCA", entidad.ID_ES_ENCA);
                parametros.Add("@ID_PRODUCTO", entidad.ID_PRODUCTO);
                parametros.Add("@ID_PRESEN_TRAS", entidad.ID_PRESEN_TRAS);
                parametros.Add("@ID_UNIDAD_FAC", entidad.ID_UNIDAD_FAC);
                parametros.Add("@CANTIDAD", entidad.CANTIDAD);
                parametros.Add("@FACTOR", entidad.FACTOR);
                parametros.Add("@REFERENCIA_DETA", entidad.REFERENCIA_DETA);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                parametros.Add("@FACTORKG", entidad.FACTORKG);
                parametros.Add("@ID_BODEP", entidad.ID_BODEP);
                regAfectados = db.Execute("CRE_ENTRADA_SALIDA_DETA_TRASLADO_EXPRES", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int ActualizarTrasladoExpres(ENTRADA_SALIDA_DETA entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_ES_DETA > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_ES_DETA", entidad.ID_ES_DETA);
                    parametros.Add("@ID_ES_ENCA", entidad.ID_ES_ENCA);
                    parametros.Add("@ID_PRODUCTO", entidad.ID_PRODUCTO);
                    parametros.Add("@ID_PRESEN_TRAS", entidad.ID_PRESEN_TRAS);
                    parametros.Add("@ID_UNIDAD_FAC", entidad.ID_UNIDAD_FAC);
                    parametros.Add("@CANTIDAD", entidad.CANTIDAD);
                    parametros.Add("@FACTOR", entidad.FACTOR);
                    parametros.Add("@REFERENCIA_DETA", entidad.REFERENCIA_DETA);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    parametros.Add("@FACTORKG", entidad.FACTORKG);
                    parametros.Add("@ID_BODEP", entidad.ID_BODEP);
                    regAfectados = db.Execute("UPD_ENTRADA_SALIDA_DETA_TRASLADO", parametros, commandType: CommandType.StoredProcedure);
                }
            }
            else
            {
                regAfectados = AgregarTrasladoExpres(entidad);
            }
            return regAfectados;
        }

        public int AgregarVtaDizucar(ENTRADA_SALIDA_DETA entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ES_ENCA", entidad.ID_ES_ENCA);
                parametros.Add("@ID_PRODUCTO", entidad.ID_PRODUCTO);
                parametros.Add("@ID_PRESEN_TRAS", entidad.ID_PRESEN_TRAS);
                parametros.Add("@ID_UNIDAD_FAC", entidad.ID_UNIDAD_FAC);
                parametros.Add("@CANTIDAD", entidad.CANTIDAD);
                parametros.Add("@FACTOR", entidad.FACTOR);
                parametros.Add("@REFERENCIA_DETA", entidad.REFERENCIA_DETA);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                parametros.Add("@FACTORKG", entidad.FACTORKG);
                parametros.Add("@ID_BODEP", entidad.ID_BODEP);
                regAfectados = db.Execute("CRE_ENTRADA_SALIDA_DETA_VTADIZUCAR", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int ActualizarVtaDizucar(ENTRADA_SALIDA_DETA entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_ES_DETA > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_ES_DETA", entidad.ID_ES_DETA);
                    parametros.Add("@ID_ES_ENCA", entidad.ID_ES_ENCA);
                    parametros.Add("@ID_PRODUCTO", entidad.ID_PRODUCTO);
                    parametros.Add("@ID_PRESEN_TRAS", entidad.ID_PRESEN_TRAS);
                    parametros.Add("@ID_UNIDAD_FAC", entidad.ID_UNIDAD_FAC);
                    parametros.Add("@CANTIDAD", entidad.CANTIDAD);
                    parametros.Add("@FACTOR", entidad.FACTOR);
                    parametros.Add("@REFERENCIA_DETA", entidad.REFERENCIA_DETA);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    parametros.Add("@FACTORKG", entidad.FACTORKG);
                    parametros.Add("@ID_BODEP", entidad.ID_BODEP);
                    regAfectados = db.Execute("UPD_ENTRADA_SALIDA_DETA_VTADIZUCAR", parametros, commandType: CommandType.StoredProcedure);
                }
            }
            else
            {
                regAfectados = AgregarVtaDizucar(entidad);
            }
            return regAfectados;
        }

        public int AgregarVtaJiboa(ENTRADA_SALIDA_DETA entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ES_ENCA", entidad.ID_ES_ENCA);
                parametros.Add("@ID_PRODUCTO", entidad.ID_PRODUCTO);
                parametros.Add("@ID_PRESEN_TRAS", entidad.ID_PRESEN_TRAS);
                parametros.Add("@ID_UNIDAD_FAC", entidad.ID_UNIDAD_FAC);
                parametros.Add("@CANTIDAD", entidad.CANTIDAD);
                parametros.Add("@FACTOR", entidad.FACTOR);
                parametros.Add("@REFERENCIA_DETA", entidad.REFERENCIA_DETA);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                parametros.Add("@FACTORKG", entidad.FACTORKG);
                parametros.Add("@ID_BODEP", entidad.ID_BODEP);
                regAfectados = db.Execute("CRE_ENTRADA_SALIDA_DETA_VJIBOA", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int ActualizarVtaJiboa(ENTRADA_SALIDA_DETA entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_ES_DETA > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_ES_DETA", entidad.ID_ES_DETA);
                    parametros.Add("@ID_ES_ENCA", entidad.ID_ES_ENCA);
                    parametros.Add("@ID_PRODUCTO", entidad.ID_PRODUCTO);
                    parametros.Add("@ID_PRESEN_TRAS", entidad.ID_PRESEN_TRAS);
                    parametros.Add("@ID_UNIDAD_FAC", entidad.ID_UNIDAD_FAC);
                    parametros.Add("@CANTIDAD", entidad.CANTIDAD);
                    parametros.Add("@FACTOR", entidad.FACTOR);
                    parametros.Add("@REFERENCIA_DETA", entidad.REFERENCIA_DETA);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    parametros.Add("@FACTORKG", entidad.FACTORKG);
                    parametros.Add("@ID_BODEP", entidad.ID_BODEP);
                    regAfectados = db.Execute("UPD_ENTRADA_SALIDA_DETA_VJIBOA", parametros, commandType: CommandType.StoredProcedure);
                }
            }
            else
            {
                regAfectados = AgregarVtaJiboa(entidad);
            }
            return regAfectados;
        }


        public int AgregarTrasladoCfExpres(ENTRADA_SALIDA_DETA entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ES_ENCA", entidad.ID_ES_ENCA);
                parametros.Add("@ID_PRODUCTO", entidad.ID_PRODUCTO);
                parametros.Add("@ID_PRESEN_TRAS", entidad.ID_PRESEN_TRAS);
                parametros.Add("@ID_UNIDAD_FAC", entidad.ID_UNIDAD_FAC);
                parametros.Add("@CANTIDAD", entidad.CANTIDAD);
                parametros.Add("@FACTOR", entidad.FACTOR);
                parametros.Add("@REFERENCIA_DETA", entidad.REFERENCIA_DETA);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                parametros.Add("@FACTORKG", entidad.FACTORKG);

                regAfectados = db.Execute("CRE_ENTRADA_SALIDA_DETA_TRASLADO_T", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int ActualizarTrasladoCfExpres(ENTRADA_SALIDA_DETA entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_ES_DETA > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_ES_DETA", entidad.ID_ES_DETA);
                    parametros.Add("@ID_ES_ENCA", entidad.ID_ES_ENCA);
                    parametros.Add("@ID_PRODUCTO", entidad.ID_PRODUCTO);
                    parametros.Add("@ID_PRESEN_TRAS", entidad.ID_PRESEN_TRAS);
                    parametros.Add("@ID_UNIDAD_FAC", entidad.ID_UNIDAD_FAC);
                    parametros.Add("@CANTIDAD", entidad.CANTIDAD);
                    parametros.Add("@FACTOR", entidad.FACTOR);
                    parametros.Add("@REFERENCIA_DETA", entidad.REFERENCIA_DETA);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    parametros.Add("@FACTORKG", entidad.FACTORKG);
                    regAfectados = db.Execute("UPD_ENTRADA_SALIDA_DETA_T", parametros, commandType: CommandType.StoredProcedure);
                }
            }
            else
            {
                regAfectados = AgregarTrasladoCfExpres(entidad);
            }
            return regAfectados;
        }

        public int Eliminar(int id)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_ENTRADA_SALIDA_DETA", id);
                regAfectados = db.Execute("DEL_ENTRADA_SALIDA_DETA", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
    }
}
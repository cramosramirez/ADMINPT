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
    public class DbKARDEX : DbBase
    {
        public List<KARDEX> ObtenerLista()
        {
            List<KARDEX> lista = new List<KARDEX>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_KARDEX", -1);
                lista = db.Query<KARDEX>("SEL_KARDEX", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public KARDEX ObtenerPorId(long id)
        {
            List<KARDEX> lista = new List<KARDEX>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_KARDEX", id);
                lista = db.Query<KARDEX>("SEL_KARDEX", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public List<KARDEX> ObtenerPorIdBodega(long ID_PRODUCTO)
        {

            List<KARDEX> lista = new List<KARDEX>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", ID_PRODUCTO);
                lista = db.Query<KARDEX>("SEL_KARDEX_BODEGA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
    }
        public List<KARDEX> ObtenerPorIdBodegaOT(long ID_PRODUCTO)
        {

            List<KARDEX> lista = new List<KARDEX>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", ID_PRODUCTO);
                lista = db.Query<KARDEX>("SEL_KARDEX_BODEGA_TO", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public KARDEX ObtenerPorIdBodegaExist(long ID_PRODUCTO, long ID_ZAFRA_PROD,long ID_BODEGA,DateTime FECHA)
        {
            List<KARDEX> lista = new List<KARDEX>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", ID_PRODUCTO);
                parametros.Add("@ID_ZAFRA_PROD", ID_ZAFRA_PROD);
                parametros.Add("@ID_BODEGA", ID_BODEGA);
                parametros.Add("@FECHA", FECHA);
                lista = db.Query<KARDEX>("SEL_KARDEX_BODEGA_EXIST", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }

        public int Agregar(KARDEX entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
              //  parametros.Add("@ID_KARDEX", entidad.ID_KARDEX);
                //parametros.Add("@ID_BODEGA", entidad.ID_BODEGA);
                //parametros.Add("@FECHA", entidad.FECHA);
                //parametros.Add("@ID_ZAFRA", entidad.ID_ZAFRA);
                //parametros.Add("@ID_TIPO_CONCEPTO", entidad.ID_TIPO_CONCEPTO);
                //parametros.Add("@ID_PRODUCTO", entidad.ID_PRODUCTO);
                //parametros.Add("@REFERENCIA", entidad.REFERENCIA);
                //parametros.Add("@ID_PRESEN_TRAS", entidad.ID_PRESEN_TRAS);
                //parametros.Add("@ID_PRESEN_VTA", entidad.ID_PRESEN_VTA);
                //parametros.Add("@ID_UNIDAD_CONSAA", entidad.ID_UNIDAD_CONSAA);
                //parametros.Add("@ID_UNIDAD_FAC", entidad.ID_UNIDAD_FAC);
                //parametros.Add("@FACTOR_QQ", entidad.FACTOR_QQ);
                //parametros.Add("@FACTOR_KG", entidad.FACTOR_KG);
                //parametros.Add("@SDOINI_QQ", entidad.SDOINI_QQ);
                //parametros.Add("@SDOINI_KG", entidad.SDOINI_KG);
                //parametros.Add("@ENTRADA_QQ", entidad.ENTRADA_QQ);
                //parametros.Add("@ENTRADA_KG", entidad.ENTRADA_KG);
                //parametros.Add("@SALIDA_QQ", entidad.SALIDA_QQ);
                //parametros.Add("@SALIDA_KG", entidad.SALIDA_KG);
                //parametros.Add("@SDOFIN_QQ", entidad.SDOFIN_QQ);
                //parametros.Add("@SDOFIN_KG", entidad.SDOFIN_KG);
                //parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                //parametros.Add("@FECHA_CREA", entidad.FECHA_CREA);
                regAfectados = db.Execute("CRE_KARDEX", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int Actualizar(KARDEX entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_KARDEX > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    //parametros.Add("@ID_KARDEX", entidad.ID_KARDEX);
                    //parametros.Add("@ID_BODEGA", entidad.ID_BODEGA);
                    //parametros.Add("@FECHA", entidad.FECHA);
                    //parametros.Add("@ID_ZAFRA", entidad.ID_ZAFRA);
                    //parametros.Add("@ID_TIPO_CONCEPTO", entidad.ID_TIPO_CONCEPTO);
                    //parametros.Add("@ID_PRODUCTO", entidad.ID_PRODUCTO);
                    //parametros.Add("@REFERENCIA", entidad.REFERENCIA);
                    //parametros.Add("@ID_PRESEN_TRAS", entidad.ID_PRESEN_TRAS);
                    //parametros.Add("@ID_PRESEN_VTA", entidad.ID_PRESEN_VTA);
                    //parametros.Add("@ID_UNIDAD_CONSAA", entidad.ID_UNIDAD_CONSAA);
                    //parametros.Add("@ID_UNIDAD_FAC", entidad.ID_UNIDAD_FAC);
                    //parametros.Add("@FACTOR_QQ", entidad.FACTOR_QQ);
                    //parametros.Add("@FACTOR_KG", entidad.FACTOR_KG);
                    //parametros.Add("@SDOINI_QQ", entidad.SDOINI_QQ);
                    //parametros.Add("@SDOINI_KG", entidad.SDOINI_KG);
                    //parametros.Add("@ENTRADA_QQ", entidad.ENTRADA_QQ);
                    //parametros.Add("@ENTRADA_KG", entidad.ENTRADA_KG);
                    //parametros.Add("@SALIDA_QQ", entidad.SALIDA_QQ);
                    //parametros.Add("@SALIDA_KG", entidad.SALIDA_KG);
                    //parametros.Add("@SDOFIN_QQ", entidad.SDOFIN_QQ);
                    //parametros.Add("@SDOFIN_KG", entidad.SDOFIN_KG);
                    //parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    //parametros.Add("@FECHA_ACT", entidad.FECHA_ACT);
                    regAfectados = db.Execute("UPD_KARDEX", parametros, commandType: CommandType.StoredProcedure);
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
                //parametros.Add("@ID_KARDEX", id);
                regAfectados = db.Execute("DEL_KARDEX", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }

    }
}

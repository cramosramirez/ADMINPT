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
    public class DbEXISTENCIA : DbBase
    {
        public List<EXISTENCIA> ObtenerLista()
        {
            List<EXISTENCIA> lista = new List<EXISTENCIA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_EXISTENCIA", -1);
                lista = db.Query<EXISTENCIA>("SEL_EXISTENCIA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public EXISTENCIA ObtenerPorId(long id)
        {
            List<EXISTENCIA> lista = new List<EXISTENCIA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_EXISTENCIA", id);
                lista = db.Query<EXISTENCIA>("SEL_EXISTENCIA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public int Agregar(EXISTENCIA entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                //  parametros.Add("@ID_EXISTENCIA", entidad.ID_EXISTENCIA);
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
                regAfectados = db.Execute("CRE_EXISTENCIA", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int Actualizar(EXISTENCIA entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_EXISTENCIA > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    //parametros.Add("@ID_EXISTENCIA", entidad.ID_EXISTENCIA);
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
                    regAfectados = db.Execute("UPD_EXISTENCIA", parametros, commandType: CommandType.StoredProcedure);
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
                //parametros.Add("@ID_EXISTENCIA", id);
                regAfectados = db.Execute("DEL_EXISTENCIA", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }

    }
}
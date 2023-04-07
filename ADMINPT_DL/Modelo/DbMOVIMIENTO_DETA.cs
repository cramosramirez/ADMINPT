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
    public class DbMOVIMIENTO_DETA : DbBase
    {
        public List<MOVIMIENTO_DETA> ObtenerLista()
        {
            List<MOVIMIENTO_DETA> lista = new List<MOVIMIENTO_DETA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_DETA", -1);
                lista = db.Query<MOVIMIENTO_DETA>("SEL_MOVIMIENTO_DETA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public MOVIMIENTO_DETA ObtenerPorId(long id)
        {
            List<MOVIMIENTO_DETA> lista = new List<MOVIMIENTO_DETA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_DETA", id);
                lista = db.Query<MOVIMIENTO_DETA>("SEL_MOVIMIENTO_DETA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public int Agregar(MOVIMIENTO_DETA entidad)
        {
            int regAfectados = 0;
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                //parametros.Add("@ID_ENCA", entidad.ID_ENCA);
                parametros.Add("@ID_PRODUCTO", entidad.ID_PRODUCTO);
                parametros.Add("@ID_TIPO_CONCEPTO", entidad.ID_TIPO_CONCEPTO);
                parametros.Add("@ID_PRESEN_TRAS", entidad.ID_PRESEN_TRAS);
                parametros.Add("@ID_PRESEN_VTA", entidad.ID_PRESEN_VTA);
                parametros.Add("@ID_UNIDAD_CONSAA", entidad.ID_UNIDAD_CONSAA);
                parametros.Add("@ID_UNIDAD_FAC", entidad.ID_UNIDAD_FAC);
                //parametros.Add("@REFERENCIA_DETA", entidad.REFERENCIA_DETA); //System.Guid.NewGuid()
                parametros.Add("@FACTOR_QQ", entidad.FACTOR_QQ);
                parametros.Add("@FACTOR_KG", entidad.FACTOR_KG);
                parametros.Add("@TARIMA", entidad.TARIMA);
                parametros.Add("@SACOS", entidad.SACOS);
                parametros.Add("@QUINTALES", entidad.QUINTALES);
                parametros.Add("@KILOGRAMOS", entidad.KILOGRAMOS);
                parametros.Add("@GALONES", entidad.GALONES);
                parametros.Add("@USUARIO_CREA", "admin"); //parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                regAfectados = db.Execute("CRE_MOVIMIENTO_DETA", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }
        public int Actualizar(MOVIMIENTO_DETA entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_DETA > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_DETA", entidad.ID_DETA);
                    parametros.Add("@ID_ENCA", entidad.ID_ENCA);
                    parametros.Add("@ID_PRODUCTO", entidad.ID_PRODUCTO);
                    parametros.Add("@ID_TIPO_CONCEPTO", entidad.ID_TIPO_CONCEPTO);
                    parametros.Add("@ID_PRESEN_TRAS", entidad.ID_PRESEN_TRAS);
                    parametros.Add("@ID_PRESEN_VTA", entidad.ID_PRESEN_VTA);
                    parametros.Add("@ID_UNIDAD_CONSAA", entidad.ID_UNIDAD_CONSAA);
                    parametros.Add("@ID_UNIDAD_FAC", entidad.ID_UNIDAD_FAC);
                    parametros.Add("@REFERENCIA_DETA", entidad.REFERENCIA_DETA);
                    parametros.Add("@FACTOR_QQ", entidad.FACTOR_QQ);
                    parametros.Add("@FACTOR_KG", entidad.FACTOR_KG);
                    parametros.Add("@TARIMA", entidad.TARIMA);
                    parametros.Add("@SACOS", entidad.SACOS);
                    parametros.Add("@QUINTALES", entidad.QUINTALES);
                    parametros.Add("@KILOGRAMOS", entidad.KILOGRAMOS);
                    parametros.Add("@GALONES", entidad.GALONES);
                    parametros.Add("@USUARIO_ACT", "admin"); // parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                 regAfectados = db.Execute("UPD_MOVIMIENTO_DETA", parametros, commandType: CommandType.StoredProcedure);
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
                parametros.Add("@ID_DETA", id);
                regAfectados = db.Execute("DEL_MOVIMIENTO_DETA", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }

    }
}
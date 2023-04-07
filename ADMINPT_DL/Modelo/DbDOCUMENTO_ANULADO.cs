
    

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
        public class DbDOCUMENTO_ANULADO : DbBase
        {
            public List<DOCUMENTO_ANULADO> ObtenerLista()
            {
                List<DOCUMENTO_ANULADO> lista = new List<DOCUMENTO_ANULADO>();
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_DOCUMENTO_ANULADO", -1);
                    lista = db.Query<DOCUMENTO_ANULADO>("SEL_DOCUMENTO_ANULADO", parametros, commandType: CommandType.StoredProcedure).ToList();
                }
                return lista;
            }
            public DOCUMENTO_ANULADO ObtenerPorId(long id)
            {
                List<DOCUMENTO_ANULADO> lista = new List<DOCUMENTO_ANULADO>();
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_DOCUMENTO_ANULADO", id);
                    lista = db.Query<DOCUMENTO_ANULADO>("SEL_DOCUMENTO_ANULADO", parametros, commandType: CommandType.StoredProcedure).ToList();
                }
                if (lista != null)
                    return lista[0];
                else
                    return null;
            }
            public int Agregar(DOCUMENTO_ANULADO entidad)
            {
                int regAfectados = 0;
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    //parametros.Add("@HORARIO", entidad.HORARIO.Trim().ToUpper());
                    //parametros.Add("@ESTADO", entidad.ESTADO);
                    parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                    parametros.Add("@FECHA_CREA", DateTime.Now);
                    regAfectados = db.Execute("CRE_DOCUMENTO_ANULADO", parametros, commandType: CommandType.StoredProcedure);
                }
                return regAfectados;
            }
            public int Actualizar(DOCUMENTO_ANULADO entidad)
            {
                int regAfectados = 0;

                if (entidad.ID_DOCUMENTO_ANUL > 0)
                {
                    using (var db = new SqlConnection(Conexion))
                    {
                        var parametros = new DynamicParameters();
                        parametros.Add("@ID_DOCUMENTO_ANULADO", entidad.ID_DOCUMENTO_ANUL);
                        //parametros.Add("@HORARIO", entidad.HORARIO.Trim().ToUpper());
                        //parametros.Add("@ESTADO", entidad.ESTADO);
                        parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                        parametros.Add("@FECHA_ACT", DateTime.Now);
                        regAfectados = db.Execute("UPD_DOCUMENTO_ANULADO", parametros, commandType: CommandType.StoredProcedure);
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
                    parametros.Add("@ID_DOCUMENTO_ANULADO", id);
                    regAfectados = db.Execute("DEL_DOCUMENTO_ANULADO", parametros, commandType: CommandType.StoredProcedure);
                }
                return regAfectados;
            }

        }
    }
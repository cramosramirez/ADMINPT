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
    public class DbBODEGA: DbBase
    {
        public List<BODEGA> ObtenerLista()
        {
            List<BODEGA> lista = new List<BODEGA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_BODEGA", -1);
                lista = db.Query<BODEGA>("SEL_BODEGA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public List<BODEGA> ObtenerListaBodegaOrigen(long ID_BODEP, long ID_PRODUCTO)
        {
            List<BODEGA> lista = new List<BODEGA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_BODEP", ID_BODEP);
                parametros.Add("@ID_PRODUCTO", ID_PRODUCTO);
                lista = db.Query<BODEGA>("SEL_PRODUCTO_BODE_ORIGEN", parametros, commandType: CommandType.StoredProcedure).ToList();                
            }
            return lista;
        }
        public List<BODEGA> ObtenerListaBodegaOrigenP(long ID_BODEP, long ID_PRODUCTO)
        {
            List<BODEGA> lista = new List<BODEGA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_BODEP", ID_BODEP);
                parametros.Add("@ID_PRODUCTO", ID_PRODUCTO);
                lista = db.Query<BODEGA>("SEL_PRODUCTO_BODE_ORIGENP", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }

        public List<BODEGA> ObtenerListaBodegaDestino(long ID_BODEP, long ID_PRODUCTO)
        {
            List<BODEGA> lista = new List<BODEGA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_BODEP", ID_BODEP);
                parametros.Add("@ID_PRODUCTO", ID_PRODUCTO);
                lista = db.Query<BODEGA>("SEL_PRODUCTO_BODE_DESTINO", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }

        public List<BODEGA> ObtenerListaBodegaDestinoP(long ID_BODEP, long ID_PRODUCTO)
        {
            List<BODEGA> lista = new List<BODEGA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_BODEP", ID_BODEP);
                parametros.Add("@ID_PRODUCTO", ID_PRODUCTO);
                lista = db.Query<BODEGA>("SEL_PRODUCTO_BODE_DESTINOP", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }


        public List<BODEGA> ObtenerListaBodegaOrdenG()
        {
            List<BODEGA> lista = new List<BODEGA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_BODEGA", -1);
                lista = db.Query<BODEGA>("SEL_BODEGAOG", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return lista;
        }
        public BODEGA ObtenerPorId(long id)
        {
            List<BODEGA> lista = new List<BODEGA>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_BODEGA", id);
                lista = db.Query<BODEGA>("SEL_BODEGA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista[0];
            else
                return null;
        }
        public int Agregar(BODEGA entidad)
        {
            int regAfectados = 0;            
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();                
                parametros.Add("@NOMBRE", entidad.NOMBRE.Trim().ToUpper());
                parametros.Add("@DIRECCION", entidad.DIRECCION.Trim().ToUpper());
                parametros.Add("@ESTADO", entidad.ESTADO);
                parametros.Add("@USUARIO_CREA", entidad.USUARIO_CREA);
                parametros.Add("@FECHA_CREA", DateTime.Now);
                regAfectados = db.Execute("CRE_BODEGA", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }   
        public int Actualizar(BODEGA entidad)
        {
            int regAfectados = 0;

            if (entidad.ID_BODEGA > 0)
            {
                using (var db = new SqlConnection(Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@ID_BODEGA", entidad.ID_BODEGA);
                    parametros.Add("@NOMBRE", entidad.NOMBRE.Trim().ToUpper());
                    parametros.Add("@DIRECCION", entidad.DIRECCION.Trim().ToUpper());
                    parametros.Add("@ESTADO", entidad.ESTADO);
                    parametros.Add("@USUARIO_ACT", entidad.USUARIO_ACT);
                    parametros.Add("@FECHA_ACT", DateTime.Now);
                    regAfectados = db.Execute("UPD_BODEGA", parametros, commandType: CommandType.StoredProcedure);
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
                parametros.Add("@ID_BODEGA", id);
                regAfectados = db.Execute("DEL_BODEGA", parametros, commandType: CommandType.StoredProcedure);
            }
            return regAfectados;
        }

    }
}

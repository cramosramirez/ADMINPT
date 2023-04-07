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
    public class DbCONCEPTO_MOVI : DbBase
    {
        public List<CONCEPTO_MOVI> ObtenerPorIdTM(int ID_PRODUCTO, int ID_TIPO_MOV)
        {
            List<CONCEPTO_MOVI> lista = new List<CONCEPTO_MOVI>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", ID_PRODUCTO);
                parametros.Add("@ID_TIPO_MOV", ID_TIPO_MOV);
                lista = db.Query<CONCEPTO_MOVI>("SEL_CONCEPTO_MOVI", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista;
            else
                return null;
        }
        public List<CONCEPTO_MOVI> ObtenerPorIdTMEspcial(int ID_PRODUCTO , int ID_TIPO_MOV )
        {
            List<CONCEPTO_MOVI> lista = new List<CONCEPTO_MOVI>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", ID_PRODUCTO);
                parametros.Add("@ID_TIPO_MOV", ID_TIPO_MOV);                
                lista = db.Query<CONCEPTO_MOVI>("SEL_CONCEPTO_MOVI_ESPECIAL", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista;
            else
                return null;
        }

        public List<CONCEPTO_MOVI> ObtenerPorIdTMTraslado(int ID_PRODUCTO, int ID_TIPO_MOV)
        {
            List<CONCEPTO_MOVI> lista = new List<CONCEPTO_MOVI>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", ID_PRODUCTO);
                parametros.Add("@ID_TIPO_MOV", ID_TIPO_MOV);
                lista = db.Query<CONCEPTO_MOVI>("SEL_CONCEPTO_MOVI_TRASLADO", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista;
            else
                return null;
        }
        public List<CONCEPTO_MOVI> ObtenerPorIdTMVtExterior(int ID_PRODUCTO, int ID_TIPO_MOV)
        {
            List<CONCEPTO_MOVI> lista = new List<CONCEPTO_MOVI>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", ID_PRODUCTO);
                parametros.Add("@ID_TIPO_MOV", ID_TIPO_MOV);
                lista = db.Query<CONCEPTO_MOVI>("SEL_CONCEPTO_MOVI_VENT_EXTERIOR", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista;
            else
                return null;
        }
        public List<CONCEPTO_MOVI> ObtenerPorIdTMVtIng(int ID_PRODUCTO, int ID_TIPO_MOV)
        {
            List<CONCEPTO_MOVI> lista = new List<CONCEPTO_MOVI>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", ID_PRODUCTO);
                parametros.Add("@ID_TIPO_MOV", ID_TIPO_MOV);
                lista = db.Query<CONCEPTO_MOVI>("SEL_CONCEPTO_MOVI_VENT_INGENIOS", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista;
            else
                return null;
        }

        public List<CONCEPTO_MOVI> ObtenerPorIdTMVzaDizucar(int ID_PRODUCTO, int ID_TIPO_MOV)
        {
            List<CONCEPTO_MOVI> lista = new List<CONCEPTO_MOVI>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", ID_PRODUCTO);
                parametros.Add("@ID_TIPO_MOV", ID_TIPO_MOV);
                lista = db.Query<CONCEPTO_MOVI>("SEL_CONCEPTO_MOVI_VTADIZUCAR", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista;
            else
                return null;
        }


        public List<CONCEPTO_MOVI> ObtenerPorIdTMVJiboa(int ID_PRODUCTO, int ID_TIPO_MOV)
        {
            List<CONCEPTO_MOVI> lista = new List<CONCEPTO_MOVI>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", ID_PRODUCTO);
                parametros.Add("@ID_TIPO_MOV", ID_TIPO_MOV);
                lista = db.Query<CONCEPTO_MOVI>("SEL_CONCEPTO_MOVI_VJIBOA", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista;
            else
                return null;
        }

        public List<CONCEPTO_MOVI> ObtenerPorIdTMConfi(int ID_PRODUCTO, int ID_TIPO_MOV)
        {
            List<CONCEPTO_MOVI> lista = new List<CONCEPTO_MOVI>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", ID_PRODUCTO);
                parametros.Add("@ID_TIPO_MOV", ID_TIPO_MOV);
                lista = db.Query<CONCEPTO_MOVI>("SEL_CONCEPTO_MOVI_CONFIG", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista;
            else
                return null;
        }

        public List<CONCEPTO_MOVI> ObtenerPorIdTMProduc(int ID_PRODUCTO, int ID_TIPO_MOV)
        {
            List<CONCEPTO_MOVI> lista = new List<CONCEPTO_MOVI>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", ID_PRODUCTO);
                parametros.Add("@ID_TIPO_MOV", ID_TIPO_MOV);
                lista = db.Query<CONCEPTO_MOVI>("SEL_CONCEPTO_MOVI_PRODUCION", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista;
            else
                return null;
        }

        public List<CONCEPTO_MOVI> ObtenerPorIdTMConsumo(int ID_PRODUCTO, int ID_TIPO_MOV)
        {
            List<CONCEPTO_MOVI> lista = new List<CONCEPTO_MOVI>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", ID_PRODUCTO);
                parametros.Add("@ID_TIPO_MOV", ID_TIPO_MOV);
                lista = db.Query<CONCEPTO_MOVI>("SEL_CONCEPTO_MOVI_CONSUMO", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista;
            else
                return null;
        }
        public List<CONCEPTO_MOVI> ObtenerPorIdTMDonacion(int ID_PRODUCTO, int ID_TIPO_MOV)
        {
            List<CONCEPTO_MOVI> lista = new List<CONCEPTO_MOVI>();
            using (var db = new SqlConnection(Conexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ID_PRODUCTO", ID_PRODUCTO);
                parametros.Add("@ID_TIPO_MOV", ID_TIPO_MOV);
                lista = db.Query<CONCEPTO_MOVI>("SEL_CONCEPTO_MOVI_DONACION", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            if (lista != null)
                return lista;
            else
                return null;
        }

        //public List<CONCEPTO_MOVI> ObtenerPorId(int id)
        //{
        //    List<CONCEPTO_MOVI> lista = new List<CONCEPTO_MOVI>();
        //    using (var db = new SqlConnection(Conexion))
        //    {
        //        var parametros = new DynamicParameters();
        //        parametros.Add("@ID_TIPO_MOV", id);
        //        lista = db.Query<CONCEPTO_MOVI>("SEL_CONCEPTO_MOVI", parametros, commandType: CommandType.StoredProcedure).ToList();
        //    }
        //    if (lista != null)
        //        return lista;
        //    else
        //        return null;
        //}

    }
}




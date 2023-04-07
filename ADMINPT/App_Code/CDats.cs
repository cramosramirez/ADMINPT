using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT
{
    public class CDats
    {
        private const string TipoAlgoritmo = "SHA1";
        public static string CifrarClave(string clave)
        {
            HashAlgorithm algoritmo = HashAlgorithm.Create(TipoAlgoritmo);
            byte[] result = null;

            if (algoritmo != null)
                result = algoritmo.ComputeHash(Encoding.UTF8.GetBytes(clave));
            return Convert.ToBase64String(result);
        }
        public static DataTable VIEW_ID_ENTRADA_SALIDA_ENCA(object FECHA, object NUM_DOC)
        {
            SqlDataAdapter Da = new SqlDataAdapter("VIEW_ID_ENTRADA_SALIDA_ENCA", Conn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@FECHA", FECHA);
            Da.SelectCommand.Parameters.AddWithValue("@NUM_DOC", NUM_DOC);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable SEL_ENTRADA_SALIDA_DETA(object ID_ES_ENCA)
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_ENTRADA_SALIDA_DETA", Conn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_ES_ENCA", ID_ES_ENCA);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _VIEW_MOVIMIENTOS_WINDOWS(object MOV)
        {
            SqlDataAdapter Da = new SqlDataAdapter("VIEW_MOVIMIENTOS_WINDOWS", Conn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@MOV", MOV);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _SEL_ENTRADA_SALIDA_ENCA_TRASLADO_T(object ID_ES_ENCA)
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_ENTRADA_SALIDA_ENCA_TRASLADO_T", Conn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_ES_ENCA", ID_ES_ENCA);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _SEL_ENTRADA_SALIDA_DETA_ENCA_T(object ID_ES_ENCA)
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_ENTRADA_SALIDA_DETA_ENCA_T", Conn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_ES_ENCA", ID_ES_ENCA);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _SEL_TARIMA(object ID_TARIMA)
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_TARIMA", Conn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_TARIMA", ID_TARIMA);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _SEL_TARIMAPROD(object CODREF)
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_TARIMAPROD", Conn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@CODREF", CODREF);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _SEL_FECHA_MOVIMIENTO()
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_FECHA_MOVIMIENTO", Conn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _SEL_FECHA_PRODUCCION()
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_FECHA_PRODUCCION", Conn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _CB_PRODUCTO_PRODUCIONDT()
        {
            SqlDataAdapter Da = new SqlDataAdapter("CB_PRODUCTO_PRODUCIONDT", Conn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _CB_TIPOS_GENERALES(object IDETP, object IDMOD)
        {
            SqlDataAdapter Da = new SqlDataAdapter("CB_TIPOS_GENERALES", Conn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@IDETP", IDETP);
            Da.SelectCommand.Parameters.AddWithValue("@IDMOD", IDMOD);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _CB_TURNO()
        {
            SqlDataAdapter Da = new SqlDataAdapter("CB_TURNO", Conn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            //Da.SelectCommand.Parameters.AddWithValue("@ID_TURNO", ID_TURNO);
            //Da.SelectCommand.Parameters.AddWithValue("@HORARIO", IDMOD);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _CB_PRODUCTO_ENT_SAL_RPT()
        {
            SqlDataAdapter Da = new SqlDataAdapter("CB_PRODUCTO_ENT_SAL_RPT", Conn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            //Da.SelectCommand.Parameters.AddWithValue("@ID_TURNO", ID_TURNO);
            //Da.SelectCommand.Parameters.AddWithValue("@HORARIO", IDMOD);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _CB_BODEGA_DESTINO_RPT()
        {
            SqlDataAdapter Da = new SqlDataAdapter("CB_BODEGA_DESTINO_RPT", Conn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            //Da.SelectCommand.Parameters.AddWithValue("@ID_TURNO", ID_TURNO);
            //Da.SelectCommand.Parameters.AddWithValue("@HORARIO", IDMOD);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }

        public static DataTable _VIEW_CANTTRASDCE5(object FECHA, object ID_PRODUCTO, object ID_ZAFRA_PROD)
        {
            SqlDataAdapter Da = new SqlDataAdapter("VIEW_CANTTRASDCE5", Conn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@FECHA", FECHA);
            Da.SelectCommand.Parameters.AddWithValue("@ID_PRODUCTO", ID_PRODUCTO);
            Da.SelectCommand.Parameters.AddWithValue("@ID_ZAFRA_PROD", ID_ZAFRA_PROD);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }

        public static DataTable _VIEW_PRODUCTO_ENTSALID(object FECHA,object NUM_DOC, object ID_BODEGAO)
        {
            SqlDataAdapter Da = new SqlDataAdapter("VIEW_PRODUCTO_ENTSALID", Conn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@FECHA", FECHA);
            Da.SelectCommand.Parameters.AddWithValue("@NUM_DOC", NUM_DOC);
            Da.SelectCommand.Parameters.AddWithValue("@ID_BODEGAO", ID_BODEGAO);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }

        public static DataTable _CB_ZAFRA()
        {
            SqlDataAdapter Da = new SqlDataAdapter("CB_ZAFRA", Conn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _CB_ZAFRA_ACTIVA()
        {
            SqlDataAdapter Da = new SqlDataAdapter("CB_ZAFRA_ACT", Conn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_EMPRESA", 1);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _SEL_CLIENTE_EXPORTACION(object ID_CLIENTEEXP)
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_CLIENTE_EXPORTACION", Conn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_CLIENTEEXP", ID_CLIENTEEXP);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }

        public static DataTable _SEL_CLIENTE_INGENIOS(object ID_CLIENTEING)
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_CLIENTE_INGENIOS", Conn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_CLIENTEING", ID_CLIENTEING);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _VIEW_BASCULA_DETA_ES(object ID_ES_ENCA)
        {
            SqlDataAdapter Da = new SqlDataAdapter("VIEW_BASCULA_DETA_ES", Conn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_ES_ENCA", ID_ES_ENCA);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
    }
}
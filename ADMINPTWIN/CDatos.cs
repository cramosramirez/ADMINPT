using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPTWIN
{
    public class CDatos
    {
        public static DataTable _SEL_ESTADO_MOVIMIENTOS(object ID_ESTADO)
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_ESTADO_MOVIMIENTOS", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_ESTADO", ID_ESTADO);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _VIEW_DOCUMENTO_NUMERACION(object ID_TIPO, object ID_BODEP)
        {
            SqlDataAdapter Da = new SqlDataAdapter("VIEW_DOCUMENTO_NUMERACION", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_TIPO", ID_TIPO);
            Da.SelectCommand.Parameters.AddWithValue("@ID_BODEP", ID_BODEP);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _SEL_PRODUCTO(object ID_PRODUCTO)
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_PRODUCTO", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_PRODUCTO", ID_PRODUCTO);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _SEL_ZAFRA(object ID_ZAFRA)
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_ZAFRA", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_ZAFRA", ID_ZAFRA);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _SEL_ZAFRA_ACTUAL()
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_ZAFRA_ACTUAL", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _SEL_TIPO_MOVIMIENTO(object ID_TIPO_MOV)
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_TIPO_MOVIMIENTO", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_TIPO_MOV", ID_TIPO_MOV);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _SEL_CONCEPTO_MOVI(object ID_PRODUCTO, object ID_TIPO_MOV)
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_CONCEPTO_MOVI", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_PRODUCTO", ID_PRODUCTO);
            Da.SelectCommand.Parameters.AddWithValue("@ID_TIPO_MOV", ID_TIPO_MOV);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _SEL_ESPECI_MOV(object ID_CONCE )
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_ESPECI_MOV", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_CONCE", ID_CONCE);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _SEL_BODEGAO(object ID_PRODUCTO)
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_KARDEX_BODEGA", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_PRODUCTO", ID_PRODUCTO);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _SEL_BODEGAS(object ID_BODEGA)
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_BODEGAD", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_BODEGA", ID_BODEGA);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }

        public static DataTable _SEL_ENTRADA_SALIDA_ENCA(object ID_ES_ENCA)
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_ENTRADA_SALIDA_ENCA", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_ES_ENCA", ID_ES_ENCA);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _SEL_ENTRADA_SALIDA_DETA(object ID_ES_ENCA)
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_ENTRADA_SALIDA_DETA", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_ES_ENCA", ID_ES_ENCA);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _SEL_BASCULA_ENCA_ES(object ID_ES_ENCA)
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_BASCULA_ENCA_ES", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_ES_ENCA", ID_ES_ENCA);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _SEL_BASCULA_DETA_ES(object ID_BASCULAENCA)
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_BASCULA_DETA_ES", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_BASCULAENCA", ID_BASCULAENCA);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _SEL_ORDEN_GLOBAL_TRAS(object ID_ORDEN_TRAS, object ID_BODEP)
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_ORDEN_GLOBAL_TRAS", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_ORDEN_TRAS", ID_ORDEN_TRAS);
            Da.SelectCommand.Parameters.AddWithValue("@ID_BODEP", ID_BODEP);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }

        public static DataTable _SEL_ENTRADA_SALIDA_ENCA_TRASLADO_T(object ID_ES_ENCA)
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_ENTRADA_SALIDA_ENCA_TRASLADO_T", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_ES_ENCA", ID_ES_ENCA);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _SEL_ENTRADA_SALIDA_DETA_ENCA_T(object ID_ES_ENCA)
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_ENTRADA_SALIDA_DETA_ENCA_T", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_ES_ENCA", ID_ES_ENCA);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _SEL_TARIMA(object ID_TARIMA)
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_TARIMA", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_TARIMA", ID_TARIMA);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _SEL_EQUIPO_MEDICION(object ID_TIPO_LECTURA)
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_EQUIPO_MEDICION", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_TIPO_LECTURA", ID_TIPO_LECTURA);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _VEW_BASCULA_CONTROL_SALDO(object ID_PRODUCTO, object FECHA, object ID_ZAFRA_PROD)
        {
            SqlDataAdapter Da = new SqlDataAdapter("VEW_BASCULA_CONTROL_SALDO", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_PRODUCTO", ID_PRODUCTO);
            Da.SelectCommand.Parameters.AddWithValue("@FECHA", FECHA);
            Da.SelectCommand.Parameters.AddWithValue("@ID_ZAFRA_PROD", ID_ZAFRA_PROD);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }

        public static DataTable _VIEW_MOVIMIENTOS_WINDOWS(object MOV)
        {
            SqlDataAdapter Da = new SqlDataAdapter("VIEW_MOVIMIENTOS_WINDOWS", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@MOV", MOV);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _SEL_TURNO(object ID_TURNO)
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_TURNO", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_TURNO", ID_TURNO);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        
        public static DataTable _SEL_MOTORISTA_CAMION()
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_MOTORISTA_CAMION", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _SEL_MOTORISTA_CAMION_PLACA(object ID_MTPROD)
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_MOTORISTA_CAMION_PLACA", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_MTPROD", ID_MTPROD);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _SEL_FECHA_MOVIMIENTO()
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_FECHA_MOVIMIENTO", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _SEL_FECHA_PRODUCCION()
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_FECHA_PRODUCCION", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _SEL_DOC_PRODUCCION_ACTUAL(Object FECHA)
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_DOC_PRODUCCION_ACTUAL", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@FECHA", FECHA);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }

        public static DataTable _SEL_ENTRADA_SALIDA_ENCA_PRODUCCION(object ID_ES_ENCA)
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_ENTRADA_SALIDA_ENCA_PRODUCCION", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_ES_ENCA", ID_ES_ENCA);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _SEL_ENTRADA_SALIDA_DETA_PRODUCCION(object ID_ES_ENCA)
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_ENTRADA_SALIDA_DETA_PRODUCCION", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_ES_ENCA", ID_ES_ENCA);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }

        public static DataTable _SEL_BASCULA_ENCA_ES_PRODUCCION(object ID_ES_ENCA)
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_BASCULA_ENCA_ES_PRODUCCION", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_ES_ENCA", ID_ES_ENCA);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }
        public static DataTable _SEL_BASCULA_DETA_ES_PRODUCCION(object ID_BASCULAENCA)
        {
            SqlDataAdapter Da = new SqlDataAdapter("SEL_BASCULA_DETA_ES_PRODUCCION", Cnn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_BASCULAENCA", ID_BASCULAENCA);
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Da = null;
            return datos;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles.movimientos_bulto
{
    public partial class UcMantEliminarProduccion : System.Web.UI.UserControl
    {
        private void Inicializar()
        {
            UCEncabezado.Titulo = "ELIMINAR INGRESO DE PRODUCCION ";
            UCBarraNavegacion.btn_nuevo.Visible = false;
            FechaDoc();
            SdsListProd.DataBind();
        }
        protected void Page_Init(object sender, EventArgs e)
        { Inicializar(); }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void FechaDoc()
        {
            try
            {

                Conn.cn.Close();
                Conn.cn.Open();
                DataTable Dt;
                Dt = CDats._SEL_FECHA_PRODUCCION();
                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                    dteFecha.Value = Convert.ToDateTime(row["FECHA"].ToString());

                }
                else
                {
                    dteFecha.Text = string.Empty;
                }

                Conn.cn.Close();

            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (System.Data.SqlClient.SqlException ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {

            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {

            }
            finally
            {
                Conn.cn.Close();
                if (Convert.ToInt16(Session["FECHAHB"]) == 1) { dteFecha.ClientEnabled = true; }
                else { dteFecha.ClientEnabled = false; }

            }
        }
    }
}
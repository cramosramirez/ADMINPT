using ADMINPT.controles.movimiento_traslado.traslados;
using DevExpress.XtraReports.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace ADMINPT.controles.Facturado
{
    public partial class UcViewDetalleVenta : System.Web.UI.UserControl
    {
        private void Inicializar()
        {
            UCEncabezado.Titulo = "DETALLE DE VENTA";
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_reporte.Visible = true;
            txt_fechad.Date = DateTime.Now;
            txt_fechah.Date = DateTime.Now;
            SdsListBgasOrigen.DataBind();
            cb_bodegaO.DataBind();
            var ibog = 0;
            ibog = Convert.ToInt32(Session["ID_BODEP"]);
            if (ibog == 0)
            { cb_bodegaO.Enabled = true; }
            else { cb_bodegaO.Value = ibog; }
            EncaFact();
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            Inicializar();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            UCBarraNavegacion.Nuevo_Click += _btn_nuevo_Click;
            UCBarraNavegacion.Reporte_Click += _btn_reporte_Click;
            UCBarraNavegacion.Salir_Click += _btn_salir_Click;
            if (Page.IsPostBack)
            {
                EncaFact();
            }
        }
        protected void _btn_nuevo_Click(object sender, EventArgs e)
        {
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_reporte.Visible = true;
            txt_fechad.Date = DateTime.Now;
            txt_fechah.Date = DateTime.Now;
            SdsListBgasOrigen.DataBind();
            cb_bodegaO.DataBind();
            var ibog = 0;
            ibog = Convert.ToInt32(Session["ID_BODEP"]);
            cb_bodegaO.Value = ibog;

        }
        protected void _btn_salir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
        protected void _btn_reporte_Click(object sender, EventArgs e)
        {
            try
            {
                EncaFact();
                sdListcpt.DataBind();
                Dgv_list2.DataBind();
                llenarReporteNotas();
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void EncaFact()
        {
            DataSet DS_DTG = new DataSet();
            DataSet DS_DT = new DataSet("DS_DT");
            DataTable DT = DS_DT.Tables.Add("DT");
            Session["DS_DT"] = null;
            try
            {
                string SALF;
                SALF = Convert.ToString(txt_fechah.Date.ToString("MM/dd/yyyy"));

                OleDbDataAdapter Dadapter;
                Conn.cnph.Close();
                Conn.cnph.Open();
                System.Data.OleDb.OleDbCommand Comando = new System.Data.OleDb.OleDbCommand("select distinc  a.numero,a.valortot, IIF(a.anulado =(.F.),'ACTIVA',IIF(a.anulado =(.T.),'ANULADA','')) AS anulado " +
                    " from facturas a  where    a.fecha={" + SALF + "}; delete=si", Conn.cnph);
                // " SUBS(a.tipofact,1,2)=='" + Convert.ToString(cbxTipoDocument.SelectedItem.Value) + "' and  val(a.Numero)= " + txt_ndocument.Text + "  and a.fecha={" + SALF + "}", Conn.cnph);
                Comando.CommandType = CommandType.Text;
                Dadapter = new OleDbDataAdapter(Comando);
                Dadapter.Fill(DS_DTG);
                DT.Columns.Add("numero", Type.GetType("System.String"));
                DT.Columns.Add("valortot", Type.GetType("System.Single"));
                DT.Columns.Add("anulado", Type.GetType("System.String"));
                DT.Clear();
                if (DS_DTG.Tables.Count != 0)
                {
                    foreach (DataTable table in DS_DTG.Tables)
                    {
                      
                        foreach (DataRow dr in table.Rows)
                        {
                            DT.Rows.Add(Convert.ToString(dr["numero"]), Convert.ToDouble(dr["valortot"].ToString()), Convert.ToString(dr["anulado"]) );
                            Dgv_list.DataSource = null;
                    Dgv_list.DataSource = DS_DT;
                    Dgv_list.DataBind();
                    }
                }
               }
                               
                Conn.cnph.Close();
            }
            catch (System.Data.OleDb.OleDbException sqlEx)
            {
                //lbl_mensaje.Text = sqlEx.Message;
                //lbl_mensaje.Visible = true;
            }
            catch (Exception ex)
            {
                //lbl_mensaje.Text = ex.Message;
                //lbl_mensaje.Visible = true;
            }
            finally
            {
                Conn.cnph.Close();
            }
        }

        public void llenarReporteNotas()
        {
            if(Convert.ToInt32(cb_Reporte.SelectedItem.Value)==1 )
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptDetalleVenta(Convert.ToInt32(cb_bodegaO.Value), Convert.ToDateTime(txt_fechad.Text), Convert.ToDateTime(txt_fechah.Text),Convert.ToString(Session["USUARIO"])));
                
            Facturado.OpenReport(cachedReportSourceKardex);
        }
            else if (Convert.ToInt32(cb_Reporte.SelectedItem.Value) == 2)
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptResumenVenta(Convert.ToInt32(cb_bodegaO.Value), Convert.ToDateTime(txt_fechad.Text), Convert.ToDateTime(txt_fechah.Text), Convert.ToString(Session["USUARIO"])));
                Facturado.OpenReport(cachedReportSourceKardex);
            }
            else if (Convert.ToInt32(cb_Reporte.SelectedItem.Value) == 3)
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptResumenVentatpProducto(Convert.ToInt32(cb_bodegaO.Value), Convert.ToDateTime(txt_fechad.Text), Convert.ToDateTime(txt_fechah.Text), Convert.ToString(Session["USUARIO"])));
                Facturado.OpenReport(cachedReportSourceKardex);
            }
            else if (Convert.ToInt32(cb_Reporte.SelectedItem.Value) == 4)
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptVtMelazaAcumulado(Convert.ToInt32(cb_bodegaO.Value), Convert.ToDateTime(txt_fechad.Text), Convert.ToDateTime(txt_fechah.Text)));
                Facturado.OpenReport(cachedReportSourceKardex);
            }
        }
    }
}
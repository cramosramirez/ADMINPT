using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using DevExpress.XtraReports.Web;
using ADMINPT.controles.movimiento_traslado.traslados;
using ADMINPT.controles.movimientos_bulto.dsproduccion;

namespace ADMINPT.controles.reporte
{
    public partial class UcVisorReporte : System.Web.UI.UserControl
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
           
                UCBarraNavegacion.Salir_Click += _btn_salir_Click;
                //UCBarraNavegacion.Reporte_Click += _btn_reporte_Click;
                UCBarraNavegacion.btn_guardar.Visible = false;
                UCBarraNavegacion.btn_nuevo.Visible = false;
                UCBarraNavegacion.btn_atras.Visible = false;

                if (!IsPostBack)
                {

                    if (Convert.ToString(Request.QueryString["mv"]) == "1") 
                        {
                         llenarReporteNotas();
                        }
                    else
                       {
                        llenarReporteGeneral();
                       }
                }
                else
                {
                    if (Convert.ToString(Request.QueryString["mv"]) == "1") 
                       {
                         llenarReporteNotas();
                       }
                       else 
                       {
                         llenarReporteGeneral();
                       }
                }
           
        }
        protected void _btn_salir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
        //protected void _btn_reporte_Click(object sender, EventArgs e)
        //{
        //    if (Convert.ToString(Request.QueryString["rpt"]) == "1")
        //    {
        //        Response.Redirect("~/forms/wfMantENTRADA_SALIDA_DESPACHO.aspx");
        //    }
        //    if (Convert.ToString(Request.QueryString["rpt"]) == "2")
        //    {
        //        Response.Redirect("~/forms/wfMantENTRADA_SALIDA_DESPACHO.aspx");
        //    }
        //    if (Convert.ToString(Request.QueryString["rpt"]) == "3")
        //    {
        //        Response.Redirect("~/forms/wfKARDEX.aspx");
        //    }
        //    if (Convert.ToString(Request.QueryString["rpt"]) == "4")
        //    {
        //        Response.Redirect("~/forms/wfEXISTENCIA.aspx");
        //    }
        //}
        public void llenarReporteNotas()
        {
            if (Convert.ToString(Request.QueryString["rpt"]) == "1")
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptNotaDizucar(Convert.ToInt32(Request.QueryString["id"])));
                UCReporte.dv_Reporte.OpenReport(cachedReportSourceKardex);
                UCReporte.dv_Reporte.Visible = true;
                Session["ID_ES_ENCA"] = 0;
            }

            if (Convert.ToString(Request.QueryString["rpt"]) == "2")
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptNotaMelaza(Convert.ToInt32(Request.QueryString["id"])));
                UCReporte.dv_Reporte.OpenReport(cachedReportSourceKardex);
                UCReporte.dv_Reporte.Visible = true;
                Session["ID_ES_ENCA"] = 0;
            }
            if (Convert.ToString(Request.QueryString["rpt"]) == "5")
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptNotaVJiboa(Convert.ToInt32(Request.QueryString["id"])));
                UCReporte.dv_Reporte.OpenReport(cachedReportSourceKardex);
                UCReporte.dv_Reporte.Visible = true;
                Session["ID_ES_ENCA"] = 0;
            }
            if (Convert.ToString(Request.QueryString["rpt"]) == "6")
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptNotaExpress(Convert.ToInt32(Request.QueryString["id"])));
                UCReporte.dv_Reporte.OpenReport(cachedReportSourceKardex);
                UCReporte.dv_Reporte.Visible = true;
                Session["ID_ES_ENCA"] = 0;
            }
        }
     
        
        
        public void llenarReporteGeneral()
        {
            try
            {

           
            if (Convert.ToString(Request.QueryString["rpt"]) == "3")
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptKardex());
                UCReporte.dv_Reporte.OpenReport(cachedReportSourceKardex);
                UCReporte.dv_Reporte.Visible = true;
                Session["ID_ES_ENCA"] = 0;
            }
            if (Convert.ToString(Request.QueryString["rpt"]) == "4")
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptExistencia());
                UCReporte.dv_Reporte.OpenReport(cachedReportSourceKardex);
                UCReporte.dv_Reporte.Visible = true;
                Session["ID_ES_ENCA"] = 0;
            }
            if (Convert.ToString(Request.QueryString["rpt"]) == "5")
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptKardexZ());
                UCReporte.dv_Reporte.OpenReport(cachedReportSourceKardex);
                UCReporte.dv_Reporte.Visible = true;
                Session["ID_ES_ENCA"] = 0;
            }
            if (Convert.ToString(Request.QueryString["rpt"]) == "6")
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptProduccionTarima(Convert.ToInt32(Request.QueryString["id"]), Convert.ToDateTime(Request.QueryString["f"]), Convert.ToString(Request.QueryString["h"])));
                UCReporte.dv_Reporte.OpenReport(cachedReportSourceKardex);
                UCReporte.dv_Reporte.Visible = true;
                Session["ID_ES_ENCA"] = 0;
            }
            if (Convert.ToString(Request.QueryString["rpt"]) == "7")
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptProducJumboBulto(Convert.ToString(Request.QueryString["h"]), Convert.ToDateTime(Request.QueryString["f"]),Convert.ToInt32(Request.QueryString["id"])));
                UCReporte.dv_Reporte.OpenReport(cachedReportSourceKardex);
                UCReporte.dv_Reporte.Visible = true;
                Session["ID_ES_ENCA"] = 0;
            }
            if (Convert.ToString(Request.QueryString["rpt"]) == "8")
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptProduccionMelaza(Convert.ToInt32(Request.QueryString["id"]), Convert.ToDateTime(Request.QueryString["f"]) ));
                UCReporte.dv_Reporte.OpenReport(cachedReportSourceKardex);
                UCReporte.dv_Reporte.Visible = true;
                Session["ID_ES_ENCA"] = 0;
            }
            if (Convert.ToString(Request.QueryString["rpt"]) == "9")
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptMoviTrasladosDiariosP(Convert.ToInt32(Request.QueryString["id"]), Convert.ToDateTime(Request.QueryString["f"]), Convert.ToDateTime(Request.QueryString["f"]), Convert.ToString(Request.QueryString["cn"]), Convert.ToInt32(Request.QueryString["bd"])));
                UCReporte.dv_Reporte.OpenReport(cachedReportSourceKardex);
                UCReporte.dv_Reporte.Visible = true;
                Session["ID_ES_ENCA"] = 0;
            }
            if (Convert.ToString(Request.QueryString["rpt"]) == "10")
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptMoviVentasDiariosP(Convert.ToInt32(Request.QueryString["id"]), Convert.ToDateTime(Request.QueryString["f"]), Convert.ToDateTime(Request.QueryString["f"]), Convert.ToString(Request.QueryString["cn"])));
                UCReporte.dv_Reporte.OpenReport(cachedReportSourceKardex);
                UCReporte.dv_Reporte.Visible = true;
                Session["ID_ES_ENCA"] = 0;
            }
             if (Convert.ToString(Request.QueryString["rpt"]) == "11")
             {
                    var cachedReportSourceKardex = new CachedReportSourceWeb(new RptMoviVentasDiariosPCriterios(Convert.ToInt32(Request.QueryString["id"]), Convert.ToDateTime(Request.QueryString["f"]), Convert.ToDateTime(Request.QueryString["f"]), Convert.ToString(Request.QueryString["cn"]),Convert.ToInt32(Request.QueryString["P"])));
                    UCReporte.dv_Reporte.OpenReport(cachedReportSourceKardex);
                    UCReporte.dv_Reporte.Visible = true;
                    Session["ID_ES_ENCA"] = 0;
            }
                if (Convert.ToString(Request.QueryString["rpt"]) == "12")
                {
                    var cachedReportSourceKardex = new CachedReportSourceWeb(new RptMoviVentasDiariosPCriteriosEMP(Convert.ToInt32(Request.QueryString["id"]), Convert.ToDateTime(Request.QueryString["f"]), Convert.ToDateTime(Request.QueryString["f"]), Convert.ToString(Request.QueryString["cn"]), Convert.ToInt32(Request.QueryString["P"])));
                    UCReporte.dv_Reporte.OpenReport(cachedReportSourceKardex);
                    UCReporte.dv_Reporte.Visible = true;
                    Session["ID_ES_ENCA"] = 0;
                }

                if (Convert.ToString(Request.QueryString["rpt"]) == "13") //reporte de cruda movimientos 
                {
                    var cachedReportSourceKardex = new CachedReportSourceWeb(new Rpt_ProdCrudaCamion(Convert.ToInt32(Request.QueryString["id"]), Convert.ToDateTime(Request.QueryString["f"]),  Convert.ToString(Request.QueryString["h"])));
                    UCReporte.dv_Reporte.OpenReport(cachedReportSourceKardex);
                    UCReporte.dv_Reporte.Visible = true;
                    Session["ID_ES_ENCA"] = 0;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
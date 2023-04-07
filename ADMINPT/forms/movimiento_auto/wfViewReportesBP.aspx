<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewReportesBP.aspx.cs" Inherits="ADMINPT.forms.movimiento_auto.wfViewReportesBP" %>
  <%@ Register Assembly="DevExpress.XtraReports.v20.1.Web.WebForms, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script>
    function Init(s, e) {
        // s.GetReportPreview().zoom(0.9);
        s.GetReportPreview().zoom(DevExpress.Reporting.Viewer.ZoomAutoBy.PageWidth);
    }
      </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
  <table style="width: 100%;">
    <tr>
        <td>
<dx:ASPxWebDocumentViewer ID="Produccion" runat="server" EnableViewState="true" >
     <ClientSideEvents Init="Init"/>
</dx:ASPxWebDocumentViewer>
</td>
    </tr>
</table>
     <dx:ASPxLoadingPanel ID="ldnPanel" runat="server" Text="Procesando Datos..." ClientInstanceName="ldnPanel" Theme="MaterialCompact" 
        Modal="True">
    </dx:ASPxLoadingPanel>
</asp:Content>


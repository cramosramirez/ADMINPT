<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCReporte.ascx.cs" Inherits="ADMINPT.controles.UCReporte" %>

<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraReports.v20.1.Web.WebForms, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<style type="text/css">
    .formLayout {
        max-width: 1300px;
        margin: auto;
    }
</style>
<br />
<table style="width: 100%; padding: initial;">
    <tr>
        <td>
            <dx:ASPxWebDocumentViewer ID="_dv_Reporte" runat="server" Visible="true">
            </dx:ASPxWebDocumentViewer>
        </td>
    </tr>
</table>
<br />
 <dx:ASPxLoadingPanel ID="ldnPanel" runat="server" Text="Procesando Datos..." ClientInstanceName="ldnPanel" Theme="MaterialCompact" 
        Modal="True">
    </dx:ASPxLoadingPanel>








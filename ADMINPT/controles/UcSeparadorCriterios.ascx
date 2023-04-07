<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcSeparadorCriterios.ascx.cs" Inherits="ADMINPT.controles.UcSeparadorCriterios" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%--<link href="../Content/tabla.css" rel="stylesheet" />
<link href="../Content/uc.css" rel="stylesheet" />--%>
<link href="../css/ResponsiveLayout.css" rel="stylesheet" />
<style type="text/css">
    .lbSeparadorCriterio {
        height: 16px;
    }
</style>
<table class="auto-style1">
    <tr id="_Cont_SepradorBarraNavegacion" runat="server" visible="true">
        <td class="lbSeparadorCriterio">
            <dx:ASPxLabel ID="_lbl_tituloBarraNavegacion" runat="server" Text=""></dx:ASPxLabel>
          <%--  <hr style="width: 800%"/>--%>
        </td>
   </tr>
</table>


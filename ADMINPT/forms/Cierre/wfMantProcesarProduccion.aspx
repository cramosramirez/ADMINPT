<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantProcesarProduccion.aspx.cs" Inherits="ADMINPT.forms.Cierre.wfMantProcesarProduccion" %>

<%@ Register Src="~/controles/cierreDiario/UcMantProduciones.ascx" TagPrefix="uc1" TagName="UcMantProduciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../../css/sweetalert.css" rel="stylesheet" />
     <script src="../../Scripts/sweetalert.min.js"></script>
    <script src="../../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantProduciones runat="server" id="UcMantProduciones" />
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantProduccionTarima_Exportacion.aspx.cs" Inherits="ADMINPT.forms.wfMantProduccionTarima_Exportacion" %>

<%@ Register Src="~/controles/movimientos_bulto/UcMantProduccionExport.ascx" TagPrefix="uc1" TagName="UcMantProduccionExport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:ucmantproduccionexport runat="server" id="UcMantProduccionExport" />
</asp:Content>

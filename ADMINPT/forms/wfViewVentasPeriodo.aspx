<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewVentasPeriodo.aspx.cs" Inherits="ADMINPT.forms.wfViewVentasPeriodo" %>

<%@ Register Src="~/controles/movimiento_vtjiboa/UcViewMovientosVentaPeriodo.ascx" TagPrefix="uc1" TagName="UcViewMovientosVentaPeriodo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewMovientosVentaPeriodo runat="server" ID="UcViewMovientosVentaPeriodo" />
</asp:Content>

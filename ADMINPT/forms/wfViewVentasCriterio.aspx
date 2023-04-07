<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewVentasCriterio.aspx.cs" Inherits="ADMINPT.forms.wfViewVentasCriterio" %>

<%@ Register Src="~/controles/movimiento_vtjiboa/UcViewMovientosVentaCriterio.ascx" TagPrefix="uc1" TagName="UcViewMovientosVentaCriterio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewMovientosVentaCriterio runat="server" ID="UcViewMovientosVentaCriterio" />
</asp:Content>

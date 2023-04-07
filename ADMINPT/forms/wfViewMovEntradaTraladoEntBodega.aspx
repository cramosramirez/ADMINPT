<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewMovEntradaTraladoEntBodega.aspx.cs" Inherits="ADMINPT.forms.wfViewMovEntradaTraladoEntBodega" %>

<%@ Register Src="~/controles/controlesReportes/UcViewMovEntradaTraladoEntBodega.ascx" TagPrefix="uc1" TagName="UcViewMovEntradaTraladoEntBodega" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewMovEntradaTraladoEntBodega runat="server" ID="UcViewMovEntradaTraladoEntBodega" />
</asp:Content>

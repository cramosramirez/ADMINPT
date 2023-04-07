<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewMovSalidaTraladoEntBodega.aspx.cs" Inherits="ADMINPT.forms.wfViewMovSalidaTraladoEntBodega" %>

<%@ Register Src="~/controles/controlesReportes/UcVieMovSalidaTraladoEntBodega.ascx" TagPrefix="uc1" TagName="UcVieMovSalidaTraladoEntBodega" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcVieMovSalidaTraladoEntBodega runat="server" id="UcVieMovSalidaTraladoEntBodega" />
</asp:Content>

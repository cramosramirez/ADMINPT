<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewTrasladosPeriodo.aspx.cs" Inherits="ADMINPT.forms.wfViewTrasladosPeriodo" %>

<%@ Register Src="~/controles/movimiento_traslado/UcViewMovientosPeriodo.ascx" TagPrefix="uc1" TagName="UcViewMovientosPeriodo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewMovientosPeriodo runat="server" ID="UcViewMovientosPeriodo" />
</asp:Content>

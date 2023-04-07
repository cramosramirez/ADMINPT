<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewMovSalidad.aspx.cs" Inherits="ADMINPT.forms.wfViewMovSalidad" %>

<%@ Register Src="~/controles/Facturado/UcViewMovientosSalida.ascx" TagPrefix="uc1" TagName="UcViewMovientosSalida" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewMovientosSalida runat="server" id="UcViewMovientosSalida" />
</asp:Content>

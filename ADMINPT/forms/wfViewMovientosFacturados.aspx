<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewMovientosFacturados.aspx.cs" Inherits="ADMINPT.forms.wfViewMovientosFacturados" %>

<%@ Register Src="~/controles/Facturado/UcViewFacturado.ascx" TagPrefix="uc1" TagName="UcViewFacturado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewFacturado runat="server" id="UcViewFacturado" />
</asp:Content>

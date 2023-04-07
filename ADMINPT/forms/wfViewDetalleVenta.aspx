<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewDetalleVenta.aspx.cs" Inherits="ADMINPT.forms.wfViewDetalleVenta" %>

<%@ Register Src="~/controles/Facturado/UcViewDetalleVenta.ascx" TagPrefix="uc1" TagName="UcViewDetalleVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:ucviewdetalleventa runat="server" id="UcViewDetalleVenta" />
</asp:Content>

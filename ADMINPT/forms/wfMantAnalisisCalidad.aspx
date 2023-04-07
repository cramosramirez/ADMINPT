<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantAnalisisCalidad.aspx.cs" Inherits="ADMINPT.forms.wfMantAnalisisCalidad" %>

<%@ Register Src="~/controles/movimiento_traslado/UcMantConsumoCalidad.ascx" TagPrefix="uc1" TagName="UcMantConsumoCalidad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:ucmantconsumocalidad runat="server" id="UcMantConsumoCalidad" />
</asp:Content>

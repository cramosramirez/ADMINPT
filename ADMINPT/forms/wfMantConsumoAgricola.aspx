<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantConsumoAgricola.aspx.cs" Inherits="ADMINPT.forms.wfMantConsumoAgricola" %>

<%@ Register Src="~/controles/movimiento_traslado/UcMantConsumo.ascx" TagPrefix="uc1" TagName="UcMantConsumo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantConsumo runat="server" id="UcMantConsumo" />
</asp:Content>

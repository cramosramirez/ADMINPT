<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewTrasladosCriterios.aspx.cs" Inherits="ADMINPT.forms.wfViewTrasladosCriterios" %>

<%@ Register Src="~/controles/movimiento_traslado/UcViewMovientosCriterios.ascx" TagPrefix="uc1" TagName="UcViewMovientosCriterios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewMovientosCriterios runat="server" id="UcViewMovientosCriterios" />
</asp:Content>

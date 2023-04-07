<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfCONTROL_TRASLADO.aspx.cs" Inherits="ADMINPT.forms.wfCONTROL_TRASLADO" %>

<%@ Register Src="~/controles/control_traslado/UcMantCONTROL_TRASLADO.ascx" TagPrefix="uc1" TagName="UcMantCONTROL_TRASLADO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantCONTROL_TRASLADO runat="server" ID="UcMantCONTROL_TRASLADO" />
</asp:Content>

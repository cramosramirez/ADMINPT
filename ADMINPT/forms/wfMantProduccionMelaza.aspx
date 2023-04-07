<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantProduccionMelaza.aspx.cs" Inherits="ADMINPT.forms.wfMantProduccionMelaza" %>

<%@ Register Src="~/controles/movimientos_bulto/UcMantProduccionMelaza.ascx" TagPrefix="uc1" TagName="UcMantProduccionMelaza" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantProduccionMelaza runat="server" ID="UcMantProduccionMelaza" />
</asp:Content>

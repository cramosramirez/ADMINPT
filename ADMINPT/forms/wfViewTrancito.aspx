<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewTrancito.aspx.cs" Inherits="ADMINPT.forms.wfViewTrancito" %>

<%@ Register Src="~/controles/movimientos_registroTraslado/UcViewTransito.ascx" TagPrefix="uc1" TagName="UcViewTransito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewTransito runat="server" ID="UcViewTransito" />
</asp:Content>

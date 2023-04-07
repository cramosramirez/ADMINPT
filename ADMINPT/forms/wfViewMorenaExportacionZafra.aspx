<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewMorenaExportacionZafra.aspx.cs" Inherits="ADMINPT.forms.wfViewMorenaExportacionZafra" %>

<%@ Register Src="~/controles/KardexZafra/UcViewMorenaExportacion.ascx" TagPrefix="uc1" TagName="UcViewMorenaExportacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewMorenaExportacion runat="server" ID="UcViewMorenaExportacion" />
</asp:Content>

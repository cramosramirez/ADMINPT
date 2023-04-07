<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewMelazaFiscal.aspx.cs" Inherits="ADMINPT.forms.wfViewMelazaFiscal" %>

<%@ Register Src="~/controles/KardexFiscal/UcViewMelaza.ascx" TagPrefix="uc1" TagName="UcViewMelaza" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewMelaza runat="server" id="UcViewMelaza" />
</asp:Content>

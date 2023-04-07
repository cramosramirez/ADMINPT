<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewCrudoFiscal.aspx.cs" Inherits="ADMINPT.forms.wfViewCrudoFiscal" %>

<%@ Register Src="~/controles/KardexFiscal/UcViewCrudo.ascx" TagPrefix="uc1" TagName="UcViewCrudo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewCrudo runat="server" id="UcViewCrudo" />
</asp:Content>

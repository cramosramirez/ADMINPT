<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewBlancaJumboZafra.aspx.cs" Inherits="ADMINPT.forms.wfViewBlancaJumboZafra" %>

<%@ Register Src="~/controles/KardexZafra/UcViewBlancoJumbo.ascx" TagPrefix="uc1" TagName="UcViewBlancoJumbo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewBlancoJumbo runat="server" ID="UcViewBlancoJumbo" />
</asp:Content>

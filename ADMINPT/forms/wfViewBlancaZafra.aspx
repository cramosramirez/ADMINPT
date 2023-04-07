<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewBlancaZafra.aspx.cs" Inherits="ADMINPT.forms.wfViewBlancaZafra" %>

<%@ Register Src="~/controles/KardexZafra/UcViewBlanco.ascx" TagPrefix="uc1" TagName="UcViewBlanco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewBlanco runat="server" ID="UcViewBlanco" />
</asp:Content>

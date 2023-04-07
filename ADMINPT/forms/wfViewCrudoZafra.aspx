<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewCrudoZafra.aspx.cs" Inherits="ADMINPT.forms.wfViewCrudoZafra" %>

<%@ Register Src="~/controles/KardexZafra/UcViewCrudo.ascx" TagPrefix="uc1" TagName="UcViewCrudo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewCrudo runat="server" ID="UcViewCrudo" />
</asp:Content>

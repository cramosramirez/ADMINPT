<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewMovientos.aspx.cs" Inherits="ADMINPT.forms.wfViewMovientos" %>

<%@ Register Src="~/controles/Facturado/UcViewMovientos.ascx" TagPrefix="uc1" TagName="UcViewMovientos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewMovientos runat="server" ID="UcViewMovientos" />
</asp:Content>

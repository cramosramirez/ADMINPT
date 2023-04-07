<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantEliminar.aspx.cs" Inherits="ADMINPT.forms.wfMantEliminar" %>

<%@ Register Src="~/controles/Facturado/UcMantEliminar.ascx" TagPrefix="uc1" TagName="UcMantEliminar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantEliminar runat="server" ID="UcMantEliminar" />
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantOtrosIngresos.aspx.cs" Inherits="ADMINPT.forms.wfMantOtrosIngresos" %>

<%@ Register Src="~/controles/movimiento_esp/UcMantOtrosIngresos.ascx" TagPrefix="uc1" TagName="UcMantOtrosIngresos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantOtrosIngresos runat="server" ID="UcMantOtrosIngresos" />
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantPreciosPH.aspx.cs" Inherits="ADMINPT.forms.wfMantPreciosPH" %>

<%@ Register Src="~/controles/movimiento_vtjiboa/UcMantPrecioPH.ascx" TagPrefix="uc1" TagName="UcMantPrecioPH" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantPrecioPH runat="server" id="UcMantPrecioPH" />
</asp:Content>

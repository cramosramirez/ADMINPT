<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantDonaciones.aspx.cs" Inherits="ADMINPT.forms.wfMantDonaciones" %>

<%@ Register Src="~/controles/movimiento_vtjiboaEmp/UcDonacion.ascx" TagPrefix="uc1" TagName="UcDonacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:ucdonacion runat="server" id="UcDonacion" />
</asp:Content>

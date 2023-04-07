<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantENTRADA_SALIDA_VTJIBOAEMP.aspx.cs" Inherits="ADMINPT.forms.wfMantENTRADA_SALIDA_VTJIBOAEMP" %>

<%@ Register Src="~/controles/movimiento_vtjiboaEmp/UcMantENTRADA_SALIDA_VTJIBOAEMP.ascx" TagPrefix="uc1" TagName="UcMantENTRADA_SALIDA_VTJIBOAEMP" %>
<%@ Register Src="~/controles/movimiento_vtjiboaEmp/UcVentaEmpacada.ascx" TagPrefix="uc1" TagName="UcVentaEmpacada" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
   <%-- <uc1:UcMantENTRADA_SALIDA_VTJIBOAEMP runat="server" ID="UcMantENTRADA_SALIDA_VTJIBOAEMP" />--%>
    <uc1:UcVentaEmpacada runat="server" id="UcVentaEmpacada" />

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfCONTROL_TRASLADODIZUCAR.aspx.cs" Inherits="ADMINPT.forms.wfCONTROL_TRASLADODIZUCAR" %>

<%@ Register Src="~/controles/movimiento_traslado/UcMantENTRADA_SALIDA_TRASLADODIZUCAR.ascx" TagPrefix="uc1" TagName="UcMantENTRADA_SALIDA_TRASLADODIZUCAR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantENTRADA_SALIDA_TRASLADODIZUCAR runat="server" id="UcMantENTRADA_SALIDA_TRASLADODIZUCAR" />
</asp:Content>

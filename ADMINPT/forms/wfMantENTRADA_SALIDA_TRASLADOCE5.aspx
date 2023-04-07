<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantENTRADA_SALIDA_TRASLADOCE5.aspx.cs" Inherits="ADMINPT.forms.wfMantENTRADA_SALIDA_TRASLADOCE5" %>

<%@ Register Src="~/controles/movimiento_traslado/UcMantENTRADA_SALIDA_TRASLADOCE5.ascx" TagPrefix="uc1" TagName="UcMantENTRADA_SALIDA_TRASLADOCE5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantENTRADA_SALIDA_TRASLADOCE5 runat="server" ID="UcMantENTRADA_SALIDA_TRASLADOCE5" />
</asp:Content>

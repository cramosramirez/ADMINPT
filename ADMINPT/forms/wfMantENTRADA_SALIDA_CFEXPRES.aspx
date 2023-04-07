<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantENTRADA_SALIDA_CFEXPRES.aspx.cs" Inherits="ADMINPT.forms.wfMantENTRADA_SALIDA_CFEXPRES" %>

<%@ Register Src="~/controles/movimientoConfigExpress/UcMantENTRADA_SALIDA_CFEXPRES.ascx" TagPrefix="uc1" TagName="UcMantENTRADA_SALIDA_CFEXPRES" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantENTRADA_SALIDA_CFEXPRES runat="server" ID="UcMantENTRADA_SALIDA_CFEXPRES" />
</asp:Content>

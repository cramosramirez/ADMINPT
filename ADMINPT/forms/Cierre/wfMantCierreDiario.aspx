<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantCierreDiario.aspx.cs" Inherits="ADMINPT.forms.wfMantCierreDiario" %>

<%@ Register Src="~/controles/cierreDiario/UcMantCierreDiario.ascx" TagPrefix="uc1" TagName="UcMantCierreDiario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
    <link href="../../css/sweetalert.css" rel="stylesheet" />
     <script src="../../Scripts/sweetalert.min.js"></script>
    <script src="../../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">

    <uc1:UcMantCierreDiario runat="server" id="UcMantCierreDiario" />
</asp:Content>

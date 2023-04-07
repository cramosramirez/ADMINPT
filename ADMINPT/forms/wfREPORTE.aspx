<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfREPORTE.aspx.cs" Inherits="ADMINPT.forms.wfREPORTE" %>

<%@ Register Src="~/controles/reporte/UcVisorReporte.ascx" TagPrefix="uc1" TagName="UcVisorReporte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcVisorReporte runat="server" id="UcVisorReporte" />
</asp:Content>

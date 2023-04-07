<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantEliminarCierre.aspx.cs" Inherits="ADMINPT.forms.Cierre.wfMantEliminarCierre" %>

<%@ Register Src="~/controles/cierreDiario/UcMantEliminarCierre.ascx" TagPrefix="uc1" TagName="UcMantEliminarCierre" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <link href="../../css/sweetalert.css" rel="stylesheet" />
     <script src="../../Scripts/sweetalert.min.js"></script>
    <script src="../../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantEliminarCierre runat="server" id="UcMantEliminarCierre" />
</asp:Content>

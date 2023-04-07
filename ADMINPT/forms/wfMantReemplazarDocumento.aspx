<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantReemplazarDocumento.aspx.cs" Inherits="ADMINPT.forms.wfMantReemplazarDocumento" %>

<%@ Register Src="~/controles/Facturado/UcMantReemplazarDocumento.ascx" TagPrefix="uc1" TagName="UcMantReemplazarDocumento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantReemplazarDocumento runat="server" ID="UcMantReemplazarDocumento" />
</asp:Content>

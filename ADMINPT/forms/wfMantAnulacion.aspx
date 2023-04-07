<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantAnulacion.aspx.cs" Inherits="ADMINPT.forms.wfMantAnulacion" %>

<%@ Register Src="~/controles/Facturado/UcMantAnulacion.ascx" TagPrefix="uc1" TagName="UcMantAnulacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
    <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantAnulacion runat="server" ID="UcMantAnulacion" />
</asp:Content>

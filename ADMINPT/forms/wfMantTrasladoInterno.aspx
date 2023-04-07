<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantTrasladoInterno.aspx.cs" Inherits="ADMINPT.forms.wfMantTrasladoInterno" %>

<%@ Register Src="~/controles/movimientos_bulto/UcMantTrasladoInterno.ascx" TagPrefix="uc1" TagName="UcMantTrasladoInterno" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantTrasladoInterno runat="server" ID="UcMantTrasladoInterno" />
</asp:Content>

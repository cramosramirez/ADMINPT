<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantTrasladoaCE5.aspx.cs" Inherits="ADMINPT.forms.wfMantTrasladoaCE5" %>

<%@ Register Src="~/controles/movimientos_bulto/UcMantTrasladoCE5.ascx" TagPrefix="uc1" TagName="UcMantTrasladoCE5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantTrasladoCE5 runat="server" ID="UcMantTrasladoCE5" />
</asp:Content>

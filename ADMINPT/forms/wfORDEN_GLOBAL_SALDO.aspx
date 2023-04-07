<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfORDEN_GLOBAL_SALDO.aspx.cs" Inherits="ADMINPT.forms.wfORDEN_GLOBAL_SALDO" %>

<%@ Register Src="~/controles/orden_global_saldo/UcMantORDEN_GLOBAL_SALDO.ascx" TagPrefix="uc1" TagName="UcMantORDEN_GLOBAL_SALDO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantORDEN_GLOBAL_SALDO runat="server" id="UcMantORDEN_GLOBAL_SALDO" />
</asp:Content>

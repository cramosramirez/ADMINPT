<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfKARDEX.aspx.cs" Inherits="ADMINPT.forms.wfKARDEX" %>

<%@ Register Src="~/controles/kardex/UcMantKARDEX.ascx" TagPrefix="uc1" TagName="UcMantKARDEX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantKARDEX runat="server" id="UcMantKARDEX" />
</asp:Content>

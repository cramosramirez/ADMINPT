<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantPlacaMarchamos.aspx.cs" Inherits="ADMINPT.forms.Bascula.wfMantPlacaMarchamos" %>

<%@ Register Src="~/Bascula/ucMantPlacaMarchamos.ascx" TagPrefix="uc1" TagName="ucMantPlacaMarchamos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../../css/sweetalert.css" rel="stylesheet" />
     <script src="../../Scripts/sweetalert.min.js"></script>
    <script src="../../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:ucMantPlacaMarchamos runat="server" id="ucMantPlacaMarchamos" />
</asp:Content>

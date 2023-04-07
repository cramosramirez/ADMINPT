<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewMorenaLocalZafra.aspx.cs" Inherits="ADMINPT.forms.wfViewMorenaLocalZafra" %>

<%@ Register Src="~/controles/KardexZafra/UcViewMorenaLocal.ascx" TagPrefix="uc1" TagName="UcViewMorenaLocal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewMorenaLocal runat="server" ID="UcViewMorenaLocal" />
</asp:Content>

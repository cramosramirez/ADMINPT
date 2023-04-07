<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewMorenaLocalFiscal.aspx.cs" Inherits="ADMINPT.forms.wfViewMorenaLocalFiscal" %>

<%@ Register Src="~/controles/KardexFiscal/UcViewMorenaLocal.ascx" TagPrefix="uc1" TagName="UcViewMorenaLocal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewMorenaLocal runat="server" id="UcViewMorenaLocal" />
</asp:Content>

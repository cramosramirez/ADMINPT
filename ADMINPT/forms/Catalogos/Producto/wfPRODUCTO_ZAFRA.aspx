<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfPRODUCTO_ZAFRA.aspx.cs" Inherits="ADMINPT.forms.wfPRODUCTO_ZAFRA" %>

<%@ Register Src="~/controles/producto_zafra/UcVistaPRODUCTO_ZAFRA.ascx" TagPrefix="uc1" TagName="UcVistaPRODUCTO_ZAFRA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcVistaPRODUCTO_ZAFRA runat="server" id="UcVistaPRODUCTO_ZAFRA" />
</asp:Content>

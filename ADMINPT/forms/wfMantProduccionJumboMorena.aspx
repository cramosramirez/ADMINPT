<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantProduccionJumboMorena.aspx.cs" Inherits="ADMINPT.forms.wfMantProduccionJumboMorena" %>

<%@ Register Src="~/controles/movimientos_bulto/UcMantProduccionJumboMorena.ascx" TagPrefix="uc1" TagName="UcMantProduccionJumboMorena" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantProduccionJumboMorena runat="server" id="UcMantProduccionJumboMorena" />
</asp:Content>

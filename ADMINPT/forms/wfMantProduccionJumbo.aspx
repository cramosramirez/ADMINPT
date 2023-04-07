<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantProduccionJumbo.aspx.cs" Inherits="ADMINPT.forms.wfMantProduccionJumbo" %>

<%@ Register Src="~/controles/movimientos_bulto/UcMantProduccionJumbo.ascx" TagPrefix="uc1" TagName="UcMantProduccionJumbo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantProduccionJumbo runat="server" id="UcMantProduccionJumbo" />
</asp:Content>

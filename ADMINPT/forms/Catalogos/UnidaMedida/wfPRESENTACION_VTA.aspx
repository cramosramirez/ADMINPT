<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfPRESENTACION_VTA.aspx.cs" Inherits="ADMINPT.forms.wfPRESENTACION_VTA" %>

<%@ Register Src="~/controles/presentacion_vta/UcMantPRESENTACION_VTA.ascx" TagPrefix="uc1" TagName="UcMantPRESENTACION_VTA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantPRESENTACION_VTA runat="server" ID="UcMantPRESENTACION_VTA" />
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfPROVEEDOR_TRAS.aspx.cs" Inherits="ADMINPT.forms.wfPROVEEDOR_TRAS" %>

<%@ Register Src="~/controles/proveedor_tras/UcMantPROVEEDOR_TRAS.ascx" TagPrefix="uc1" TagName="UcMantPROVEEDOR_TRAS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantPROVEEDOR_TRAS runat="server" id="UcMantPROVEEDOR_TRAS" />
</asp:Content>

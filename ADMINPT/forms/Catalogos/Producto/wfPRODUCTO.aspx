<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfPRODUCTO.aspx.cs" Inherits="ADMINPT.forms.wfPRODUCTO" %>
<%@ Register Src="~/controles/producto/UcMantPRODUCTO.ascx" TagPrefix="uc1" TagName="UcMantPRODUCTO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantPRODUCTO runat="server" id="UcMantPRODUCTO1" />
</asp:Content>

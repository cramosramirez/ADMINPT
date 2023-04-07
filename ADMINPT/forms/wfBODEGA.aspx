<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfBODEGA.aspx.cs" Inherits="ADMINPT.forms.wfBODEGA" %>

<%@ Register Src="~/controles/bodega/UcMantBODEGA.ascx" TagPrefix="uc1" TagName="UcMantBODEGA" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantBODEGA runat="server" ID="UcMantBODEGA" />
</asp:Content>

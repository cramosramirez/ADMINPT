<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewMovIngProd.aspx.cs" Inherits="ADMINPT.forms.wfViewMovIngProd" %>

<%@ Register Src="~/controles/controlesReportes/UcViewMovIngProd.ascx" TagPrefix="uc1" TagName="UcViewMovIngProd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewMovIngProd runat="server" id="UcViewMovIngProd" />
</asp:Content>

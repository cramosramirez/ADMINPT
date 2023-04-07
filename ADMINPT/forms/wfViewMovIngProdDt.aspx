<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewMovIngProdDt.aspx.cs" Inherits="ADMINPT.forms.wfViewMovIngProdDt" %>

<%@ Register Src="~/controles/controlesReportes/UcViewMovIngProdDt.ascx" TagPrefix="uc1" TagName="UcViewMovIngProdDt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewMovIngProdDt runat="server" id="UcViewMovIngProdDt" />
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewNotas.aspx.cs" Inherits="ADMINPT.forms.wfViewNotas" %>

<%@ Register Src="~/controles/Facturado/UcViewNotas.ascx" TagPrefix="uc1" TagName="UcViewNotas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewNotas runat="server" id="UcViewNotas" />
</asp:Content>

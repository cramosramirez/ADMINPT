<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMARCA.aspx.cs" Inherits="ADMINPT.forms.wfMARCA" %>

<%@ Register Src="~/controles/marca/UcMantMARCA.ascx" TagPrefix="uc1" TagName="UcMantMARCA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantMARCA runat="server" id="UcMantMARCA" />
</asp:Content>

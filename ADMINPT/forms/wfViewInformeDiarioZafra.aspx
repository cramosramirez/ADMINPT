<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewInformeDiarioZafra.aspx.cs" Inherits="ADMINPT.forms.wfViewInformeDiarioZafra" %>

<%@ Register Src="~/RptDia/UcRptDia.ascx" TagPrefix="uc1" TagName="UcRptDia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcRptDia runat="server" ID="UcRptDia" />
</asp:Content>

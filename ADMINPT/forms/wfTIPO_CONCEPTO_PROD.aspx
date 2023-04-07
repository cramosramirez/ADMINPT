<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfTIPO_CONCEPTO_PROD.aspx.cs" Inherits="ADMINPT.forms.wfTIPO_CONCEPTO_PROD" %>

<%@ Register Src="~/controles/tipo_concepto_prod/UcMantTIPO_CONCEPTO_PROD.ascx" TagPrefix="uc1" TagName="UcMantTIPO_CONCEPTO_PROD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantTIPO_CONCEPTO_PROD runat="server" ID="UcMantTIPO_CONCEPTO_PROD" />
</asp:Content>

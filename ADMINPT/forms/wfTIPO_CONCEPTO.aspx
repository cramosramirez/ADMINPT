<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfTIPO_CONCEPTO.aspx.cs" Inherits="ADMINPT.forms.wfTIPO_CONCEPTO" %>

<%@ Register Src="~/controles/tipo_concepto/UcMantTIPO_CONCEPTO.ascx" TagPrefix="uc1" TagName="UcMantTIPO_CONCEPTO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantTIPO_CONCEPTO runat="server" id="UcMantTIPO_CONCEPTO" />
</asp:Content>

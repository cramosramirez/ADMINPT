<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfTRANSPORTE.aspx.cs" Inherits="ADMINPT.forms.wfTRANSPORTE" %>

<%@ Register Src="~/controles/transporte/UcMantTRANSPORTE.ascx" TagPrefix="uc1" TagName="UcMantTRANSPORTE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantTRANSPORTE runat="server" ID="UcMantTRANSPORTE" />
</asp:Content>

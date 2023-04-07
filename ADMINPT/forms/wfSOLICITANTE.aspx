<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfSOLICITANTE.aspx.cs" Inherits="ADMINPT.forms.wfSOLICITANTE" %>

<%@ Register Src="~/controles/solicitante/UcMantSOLICITANTE.ascx" TagPrefix="uc1" TagName="UcMantSOLICITANTE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantSOLICITANTE runat="server" id="UcMantSOLICITANTE" />
</asp:Content>

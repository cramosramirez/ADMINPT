<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewVentaBM.aspx.cs" Inherits="ADMINPT.forms.ReportesBodegaJiboa.VentaBM.wfViewVentaBM" %>

<%@ Register Src="~/controles/ReportesBodegaJiboa/VentaBM/UcViewVentaBM.ascx" TagPrefix="uc1" TagName="UcViewVentaBM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <link href="../../../css/sweetalert.css" rel="stylesheet" />
     <script src="../../../Scripts/sweetalert.min.js"></script>
    <script src="../../../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewVentaBM runat="server" ID="UcViewVentaBM" />
</asp:Content>

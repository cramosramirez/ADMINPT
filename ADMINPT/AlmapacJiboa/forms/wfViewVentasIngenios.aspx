<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewVentasIngenios.aspx.cs" Inherits="ADMINPT.AlmapacJiboa.forms.wfViewVentasIngenios" %>

<%@ Register Src="~/AlmapacJiboa/View/UcVentasIngenios.ascx" TagPrefix="uc1" TagName="UcVentasIngenios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="../../css/sweetalert.css" rel="stylesheet" />
     <script src="../../Scripts/sweetalert.min.js"></script>
    <script src="../../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcVentasIngenios runat="server" id="UcVentasIngenios" />
</asp:Content>

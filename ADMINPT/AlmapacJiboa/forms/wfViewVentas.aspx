<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewVentas.aspx.cs" Inherits="ADMINPT.AlmapacJiboa.forms.wfViewVentas" %>

<%@ Register Src="~/AlmapacJiboa/View/UcVentas.ascx" TagPrefix="uc1" TagName="UcVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="../../css/sweetalert.css" rel="stylesheet" />
     <script src="../../Scripts/sweetalert.min.js"></script>
    <script src="../../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcVentas runat="server" id="UcVentas" />
</asp:Content>

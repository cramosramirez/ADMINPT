<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewCompras.aspx.cs" Inherits="ADMINPT.AlmapacJiboa.forms.wfViewCompras" %>

<%@ Register Src="~/AlmapacJiboa/View/UcCompras.ascx" TagPrefix="uc1" TagName="UcCompras" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <link href="../../css/sweetalert.css" rel="stylesheet" />
     <script src="../../Scripts/sweetalert.min.js"></script>
    <script src="../../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcCompras runat="server" id="UcCompras" />
</asp:Content>

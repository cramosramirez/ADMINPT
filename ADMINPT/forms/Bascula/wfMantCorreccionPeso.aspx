<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantCorreccionPeso.aspx.cs" Inherits="ADMINPT.forms.Bascula.wfMantCorreccionPeso" %>

<%@ Register Src="~/Bascula/ucMantCorrecionPesos.ascx" TagPrefix="uc1" TagName="ucMantCorrecionPesos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../../css/sweetalert.css" rel="stylesheet" />
     <script src="../../Scripts/sweetalert.min.js"></script>
    <script src="../../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:ucMantCorrecionPesos runat="server" id="ucMantCorrecionPesos" />
</asp:Content>

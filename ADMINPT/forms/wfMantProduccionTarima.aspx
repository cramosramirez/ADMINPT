﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantProduccionTarima.aspx.cs" Inherits="ADMINPT.forms.wfMantProduccionTarima" %>

<%@ Register Src="~/controles/movimientos_bulto/UcMantProduccion.ascx" TagPrefix="uc1" TagName="UcMantProduccion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantProduccion runat="server" ID="UcMantProduccion" />
</asp:Content>

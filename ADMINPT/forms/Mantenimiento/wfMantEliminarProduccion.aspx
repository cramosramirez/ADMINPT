<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantEliminarProduccion.aspx.cs" Inherits="ADMINPT.forms.Mantenimiento.wfMantEliminarProduccion" %>

<%@ Register Src="~/controles/movimientos_bulto/UcMantEliminarProduccion.ascx" TagPrefix="uc1" TagName="UcMantEliminarProduccion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="../../css/sweetalert.css" rel="stylesheet" />
     <script src="../../Scripts/sweetalert.min.js"></script>
    <script src="../../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantEliminarProduccion runat="server" ID="UcMantEliminarProduccion" />
</asp:Content>

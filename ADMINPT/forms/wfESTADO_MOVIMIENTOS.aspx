<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfESTADO_MOVIMIENTOS.aspx.cs" Inherits="ADMINPT.forms.wfESTADO_MOVIMIENTOS" %>

<%@ Register Src="~/controles/estado_movimientos/UcMantESTADO_MOVIMIENTOS.ascx" TagPrefix="uc1" TagName="UcMantESTADO_MOVIMIENTOS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantESTADO_MOVIMIENTOS runat="server" id="UcMantESTADO_MOVIMIENTOS" />
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantProduccionTarima_SC25kg.aspx.cs" Inherits="ADMINPT.forms.wfMantProduccionTarima_SC25kg" %>

<%@ Register Src="~/controles/movimientos_bulto/UcMantProduccionSC25KG.ascx" TagPrefix="uc1" TagName="UcMantProduccionSC25KG" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:ucmantproduccionsc25kg runat="server" id="UcMantProduccionSC25KG" />
</asp:Content>

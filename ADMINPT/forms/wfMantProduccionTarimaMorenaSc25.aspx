<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantProduccionTarimaMorenaSc25.aspx.cs" Inherits="ADMINPT.forms.wfMantProduccionTarimaMorenaSc25" %>

<%@ Register Src="~/controles/movimientos_bulto/UcMantProduccionMorenaSc25kg.ascx" TagPrefix="uc1" TagName="UcMantProduccionMorenaSc25kg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantProduccionMorenaSc25kg runat="server" ID="UcMantProduccionMorenaSc25kg" />
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantProduccionCrudo.aspx.cs" Inherits="ADMINPT.forms.wfMantProduccionCrudo" %>

<%@ Register Src="~/controles/movimientos_bulto/UcMantProduccionCruda.ascx" TagPrefix="uc1" TagName="UcMantProduccionCruda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantProduccionCruda runat="server" ID="UcMantProduccionCruda" />
</asp:Content>

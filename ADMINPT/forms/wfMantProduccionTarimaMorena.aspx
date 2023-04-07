<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantProduccionTarimaMorena.aspx.cs" Inherits="ADMINPT.forms.wfMantProduccionTarimaMorena" %>

<%@ Register Src="~/controles/movimientos_bulto/UcMantProduccionMorena.ascx" TagPrefix="uc1" TagName="UcMantProduccionMorena" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantProduccionMorena runat="server" id="UcMantProduccionMorena" />
</asp:Content>

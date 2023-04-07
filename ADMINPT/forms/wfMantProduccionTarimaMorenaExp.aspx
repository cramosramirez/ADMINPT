<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantProduccionTarimaMorenaExp.aspx.cs" Inherits="ADMINPT.forms.wfMantProduccionTarimaMorenaExp" %>

<%@ Register Src="~/controles/movimientos_bulto/UcMantProduccionMorena_Exp.ascx" TagPrefix="uc1" TagName="UcMantProduccionMorena_Exp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantProduccionMorena_Exp runat="server" ID="UcMantProduccionMorena_Exp" />
</asp:Content>

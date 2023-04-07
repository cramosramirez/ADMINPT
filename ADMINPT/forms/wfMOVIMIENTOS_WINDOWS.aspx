<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMOVIMIENTOS_WINDOWS.aspx.cs" Inherits="ADMINPT.forms.wfMOVIMIENTOS_WINDOWS" %>

<%@ Register Src="~/controles/movimientos_windows/UcVistaMOVIMIENTOS_WINDOWS.ascx" TagPrefix="uc1" TagName="UcVistaMOVIMIENTOS_WINDOWS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcVistaMOVIMIENTOS_WINDOWS runat="server" id="UcVistaMOVIMIENTOS_WINDOWS" />
</asp:Content>

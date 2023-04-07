<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfPRESENTACION_TRAS.aspx.cs" Inherits="ADMINPT.forms.wfPRESENTACION_TRAS" %>

<%@ Register Src="~/controles/presentacion_tras/UCMantPRESENTACION_TRAS.ascx" TagPrefix="uc1" TagName="UCMantPRESENTACION_TRAS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UCMantPRESENTACION_TRAS runat="server" id="UCMantPRESENTACION_TRAS" />
</asp:Content>

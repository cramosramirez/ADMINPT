<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfORDEN_GLOBAL_TRAS.aspx.cs" Inherits="ADMINPT.forms.wfORDEN_GLOBAL_TRAS" %>

<%@ Register Src="~/controles/orden_global_tras/UCMantORDEN_GLOBAL_TRAS.ascx" TagPrefix="uc1" TagName="UCMantORDEN_GLOBAL_TRAS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UCMantORDEN_GLOBAL_TRAS runat="server" id="UCMantORDEN_GLOBAL_TRAS" />
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfPRODUCTO_PRES_VTA.aspx.cs" Inherits="ADMINPT.forms.wfPRODUCTO_PRES_VTA" %>

<%@ Register Src="~/controles/producto_pres_vta/UcMantPRODUCTO_PRES_VTA.ascx" TagPrefix="uc1" TagName="UcMantPRODUCTO_PRES_VTA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantPRODUCTO_PRES_VTA runat="server" id="UcMantPRODUCTO_PRES_VTA" />
</asp:Content>

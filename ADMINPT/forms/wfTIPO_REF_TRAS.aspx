<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfTIPO_REF_TRAS.aspx.cs" Inherits="ADMINPT.forms.wfTIPO_REF_TRAS" %>

<%@ Register Src="~/controles/tipo_ref_tras/UcMantTIPO_REF_TRAS.ascx" TagPrefix="uc1" TagName="UcMantTIPO_REF_TRAS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantTIPO_REF_TRAS runat="server" id="UcMantTIPO_REF_TRAS" />
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfTURNO.aspx.cs" Inherits="ADMINPT.forms.wfTURNO" %>

<%@ Register Src="~/controles/turno/UcMantTURNO.ascx" TagPrefix="uc1" TagName="UcMantTURNO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantTURNO runat="server" id="UcMantTURNO" />
</asp:Content>

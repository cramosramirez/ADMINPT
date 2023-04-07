<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfFAMILIA.aspx.cs" Inherits="ADMINPT.forms.wfFAMILIA" %>

<%@ Register Src="~/controles/familia/UCMantFAMILIA.ascx" TagPrefix="uc1" TagName="UCMantFAMILIA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UCMantFAMILIA runat="server" ID="UCMantFAMILIA" />
</asp:Content>

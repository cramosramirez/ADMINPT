<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfUNIDAD_MEDI_FAC.aspx.cs" Inherits="ADMINPT.forms.wfUNIDAD_MEDI_FAC" %>

<%@ Register Src="~/controles/unidad_medi_fac/UCMantUNIDAD_MEDI_FAC.ascx" TagPrefix="uc1" TagName="UCMantUNIDAD_MEDI_FAC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UCMantUNIDAD_MEDI_FAC runat="server" id="UCMantUNIDAD_MEDI_FAC" />
</asp:Content>

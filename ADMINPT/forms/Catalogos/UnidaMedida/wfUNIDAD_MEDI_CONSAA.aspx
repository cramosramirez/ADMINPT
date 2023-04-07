<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfUNIDAD_MEDI_CONSAA.aspx.cs" Inherits="ADMINPT.forms.wfUNIDAD_MEDI_CONSAA" %>

<%@ Register Src="~/controles/unidad_medi_consaa/UCMantUNIDAD_MEDI_CONSAA.ascx" TagPrefix="uc1" TagName="UCMantUNIDAD_MEDI_CONSAA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UCMantUNIDAD_MEDI_CONSAA runat="server" id="UCMantUNIDAD_MEDI_CONSAA" />
</asp:Content>

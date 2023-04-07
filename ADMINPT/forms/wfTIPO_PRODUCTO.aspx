<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfTIPO_PRODUCTO.aspx.cs" Inherits="ADMINPT.forms.wfTIPO_PRODUCTO" %>


<%@ Register Src="~/controles/tipo_producto/UcMantTIPO_PRODUCTO.ascx" TagPrefix="uc1" TagName="UcMantTIPO_PRODUCTO" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantTIPO_PRODUCTO runat="server" ID="UcMantTIPO_PRODUCTO1" />
</asp:Content>

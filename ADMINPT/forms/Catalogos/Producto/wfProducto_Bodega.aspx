<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfProducto_Bodega.aspx.cs" Inherits="ADMINPT.forms.Catalogos.Producto.wfProducto_Bodega" %>

<%@ Register Src="~/controles/producto/UcMantProductoBodega.ascx" TagPrefix="uc1" TagName="UcMantProductoBodega" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantProductoBodega runat="server" ID="UcMantProductoBodega" />
</asp:Content>

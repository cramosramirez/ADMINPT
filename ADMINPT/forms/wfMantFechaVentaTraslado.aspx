<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantFechaVentaTraslado.aspx.cs" Inherits="ADMINPT.forms.wfMantFechaVentaTraslado" %>

<%@ Register Src="~/controles/cierreDiario/UcFechaVentaTransdo.ascx" TagPrefix="uc1" TagName="UcFechaVentaTransdo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcFechaVentaTransdo runat="server" ID="UcFechaVentaTransdo" />
</asp:Content>

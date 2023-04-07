<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantFechaProduccion.aspx.cs" Inherits="ADMINPT.forms.wfMantFechaProduccion" %>

<%@ Register Src="~/controles/cierreDiario/UcFechaProduccion.ascx" TagPrefix="uc1" TagName="UcFechaProduccion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcFechaProduccion runat="server" id="UcFechaProduccion" />
</asp:Content>

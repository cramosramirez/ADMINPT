<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewVentaMelaza.aspx.cs" Inherits="ADMINPT.forms.ReportesBodegaJiboa.Melaza.wfViewVentaMelaza" %>

<%@ Register Src="~/controles/ReportesBodegaJiboa/Melaza/UcViewVentaMelaza.ascx" TagPrefix="uc1" TagName="UcViewVentaMelaza" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewVentaMelaza runat="server" id="UcViewVentaMelaza" />
</asp:Content>

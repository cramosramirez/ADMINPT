<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewTrasladoMelazaIngresos.aspx.cs" Inherits="ADMINPT.forms.ReportesBodegaJiboa.Melaza.wfViewTrasladoMelazaIngresos" %>

<%@ Register Src="~/controles/ReportesBodegaJiboa/Melaza/UcViewTrasladoMelazaIngreso.ascx" TagPrefix="uc1" TagName="UcViewTrasladoMelazaIngreso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewTrasladoMelazaIngreso runat="server" ID="UcViewTrasladoMelazaIngreso" />
</asp:Content>

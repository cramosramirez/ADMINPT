<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantNivel.aspx.cs" Inherits="ADMINPT.forms.ReportesBodegaJiboa.Melaza.TanqueNivel.wfMantNivel" %>

<%@ Register Src="~/controles/ReportesBodegaJiboa/Melaza/TanqueNivel/UcMantNivel.ascx" TagPrefix="uc1" TagName="UcMantNivel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantNivel runat="server" id="UcMantNivel" />
</asp:Content>

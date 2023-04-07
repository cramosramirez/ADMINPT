<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewTrasladoMelaza.aspx.cs" Inherits="ADMINPT.forms.Conta.wfViewTrasladoMelaza" %>

<%@ Register Src="~/controles/conta_rpt/UcViewTrasladoMelaza.ascx" TagPrefix="uc1" TagName="UcViewTrasladoMelaza" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewTrasladoMelaza runat="server" id="UcViewTrasladoMelaza" />
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewTrasladoMorenojblocal.aspx.cs" Inherits="ADMINPT.forms.Conta.wfViewTrasladoMorenojblocal" %>

<%@ Register Src="~/controles/conta_rpt/UcViewTrasladoMorenajblocal.ascx" TagPrefix="uc1" TagName="UcViewTrasladoMorenajblocal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewTrasladoMorenajblocal runat="server" id="UcViewTrasladoMorenajblocal" />
</asp:Content>

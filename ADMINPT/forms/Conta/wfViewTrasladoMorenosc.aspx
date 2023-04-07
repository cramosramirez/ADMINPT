<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewTrasladoMorenosc.aspx.cs" Inherits="ADMINPT.forms.Conta.wfViewTrasladoMorenosc" %>

<%@ Register Src="~/controles/conta_rpt/UcViewTrasladoMorenasc.ascx" TagPrefix="uc1" TagName="UcViewTrasladoMorenasc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:ucviewtrasladomorenasc runat="server" id="UcViewTrasladoMorenasc" />
</asp:Content>

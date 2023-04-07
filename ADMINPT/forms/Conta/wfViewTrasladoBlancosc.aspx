<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewTrasladoBlancosc.aspx.cs" Inherits="ADMINPT.forms.Conta.wfViewTrasladoBlancosc" %>

<%@ Register Src="~/controles/conta_rpt/UcViewTrasladoBlancosc.ascx" TagPrefix="uc1" TagName="UcViewTrasladoBlancosc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewTrasladoBlancosc runat="server" ID="UcViewTrasladoBlancosc" />
</asp:Content>

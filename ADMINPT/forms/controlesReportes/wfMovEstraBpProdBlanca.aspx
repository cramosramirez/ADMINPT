<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMovEstraBpProdBlanca.aspx.cs" Inherits="ADMINPT.forms.controlesReportes.wfMovEstraBpProdBlanca" %>

<%@ Register Src="~/controles/controlesReportes/UcViewMovEstraBpProdBlanca.ascx" TagPrefix="uc1" TagName="UcViewMovEstraBpProdBlanca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewMovEstraBpProdBlanca runat="server" id="UcViewMovEstraBpProdBlanca" />
</asp:Content>

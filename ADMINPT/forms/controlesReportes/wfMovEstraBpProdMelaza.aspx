<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMovEstraBpProdMelaza.aspx.cs" Inherits="ADMINPT.forms.controlesReportes.wfMovEstraBpProdMelaza" %>

<%@ Register Src="~/controles/controlesReportes/UcViewMovEstraBpProdMelaza.ascx" TagPrefix="uc1" TagName="UcViewMovEstraBpProdMelaza" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewMovEstraBpProdMelaza runat="server" id="UcViewMovEstraBpProdMelaza" />
</asp:Content>

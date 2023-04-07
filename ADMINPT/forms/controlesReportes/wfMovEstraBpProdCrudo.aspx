<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMovEstraBpProdCrudo.aspx.cs" Inherits="ADMINPT.forms.controlesReportes.wfMovEstraBpProdCrudo" %>

<%@ Register Src="~/controles/controlesReportes/UcViewMovEstraBpProdCrudo.ascx" TagPrefix="uc1" TagName="UcViewMovEstraBpProdCrudo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewMovEstraBpProdCrudo runat="server" id="UcViewMovEstraBpProdCrudo" />
</asp:Content>

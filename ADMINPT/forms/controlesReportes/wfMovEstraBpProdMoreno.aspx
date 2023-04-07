<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMovEstraBpProdMoreno.aspx.cs" Inherits="ADMINPT.forms.controlesReportes.wfMovEstraBpProdMoreno" %>

<%@ Register Src="~/controles/controlesReportes/UcViewMovEstraBpProdMoreno.ascx" TagPrefix="uc1" TagName="UcViewMovEstraBpProdMoreno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewMovEstraBpProdMoreno runat="server" id="UcViewMovEstraBpProdMoreno" />
</asp:Content>

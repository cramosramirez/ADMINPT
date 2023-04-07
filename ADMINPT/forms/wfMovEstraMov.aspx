<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMovEstraMov.aspx.cs" Inherits="ADMINPT.forms.wfMovEstraMov" %>

<%@ Register Src="~/controles/controlesReportes/UcViewMovEstraMovi.ascx" TagPrefix="uc1" TagName="UcViewMovEstraMovi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewMovEstraMovi runat="server" ID="UcViewMovEstraMovi" />
</asp:Content>

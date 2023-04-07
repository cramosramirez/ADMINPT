<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMovEstra.aspx.cs" Inherits="ADMINPT.forms.wfMovEstra" %>

<%@ Register Src="~/controles/controlesReportes/UcViewMovEstra.ascx" TagPrefix="uc1" TagName="UcViewMovEstra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewMovEstra runat="server" id="UcViewMovEstra" />
</asp:Content>


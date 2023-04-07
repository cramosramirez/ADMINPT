<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMovEstraPrest.aspx.cs" Inherits="ADMINPT.forms.wfMovEstraPrest" %>

<%@ Register Src="~/controles/controlesReportes/UcViewMovEstraPrest.ascx" TagPrefix="uc1" TagName="UcViewMovEstraPrest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewMovEstraPrest runat="server" id="UcViewMovEstraPrest" />
</asp:Content>

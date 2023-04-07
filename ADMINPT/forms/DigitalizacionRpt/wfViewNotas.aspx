<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewNotas.aspx.cs" Inherits="ADMINPT.forms.DigitalizacionRpt.wfViewNotas" %>

<%@ Register Src="~/controles/DigitalizacionRpt/UcViewNotas.ascx" TagPrefix="uc1" TagName="UcViewNotas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewNotas runat="server" id="UcViewNotas" />
</asp:Content>

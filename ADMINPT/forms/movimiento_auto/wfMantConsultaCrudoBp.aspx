<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantConsultaCrudoBp.aspx.cs" Inherits="ADMINPT.forms.movimiento_auto.wfMantConsultaCrudoBp" %>

<%@ Register Src="~/controles/movimiento_auto/UcMantConsultaCrudoBp.ascx" TagPrefix="uc1" TagName="UcMantConsultaCrudoBp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantConsultaCrudoBp runat="server" ID="UcMantConsultaCrudoBp" />
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfConsultaDoc.aspx.cs" Inherits="ADMINPT.forms.DigitalizacionRpt.wfConsultaDoc" %>

<%@ Register Src="~/controles/DigitalizacionRpt/UcConsultaDoc.ascx" TagPrefix="uc1" TagName="UcConsultaDoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcConsultaDoc runat="server" id="UcConsultaDoc" />
</asp:Content>

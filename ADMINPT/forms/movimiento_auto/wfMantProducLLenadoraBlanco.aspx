<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantProducLLenadoraBlanco.aspx.cs" Inherits="ADMINPT.forms.movimiento_auto.wfMantProducLLenadoraBlanco" %>

<%@ Register Src="~/controles/movimiento_auto/UcMantProducLLenadoraBlanco.ascx" TagPrefix="uc1" TagName="UcMantProducLLenadoraBlanco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantProducLLenadoraBlanco runat="server" id="UcMantProducLLenadoraBlanco" />
</asp:Content>

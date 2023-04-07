<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantProduccionCrudoBp.aspx.cs" Inherits="ADMINPT.forms.wfMantProduccionCrudoBp" %>

<%@ Register Src="~/controles/movimiento_auto/UcMantProduccionCrudoBp.ascx" TagPrefix="uc1" TagName="UcMantProduccionCrudoBp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantProduccionCrudoBp runat="server" id="UcMantProduccionCrudoBp" />
</asp:Content>

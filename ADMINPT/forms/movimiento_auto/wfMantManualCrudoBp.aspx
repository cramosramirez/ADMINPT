<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantManualCrudoBp.aspx.cs" Inherits="ADMINPT.forms.movimiento_auto.wfMantManualCrudoBp" %>

<%@ Register Src="~/controles/movimiento_auto/UcMantManualCrudoBp.ascx" TagPrefix="uc1" TagName="UcMantManualCrudoBp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMantManualCrudoBp runat="server" ID="UcMantManualCrudoBp" />
</asp:Content>


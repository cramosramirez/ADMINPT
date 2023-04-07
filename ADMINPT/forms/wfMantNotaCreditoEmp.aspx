<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantNotaCreditoEmp.aspx.cs" Inherits="ADMINPT.forms.wfMantNotaCreditoEmp" %>

<%@ Register Src="~/controles/movimiento_vtjiboaEmp/UcNotaCreditoEmpacado.ascx" TagPrefix="uc1" TagName="UcNotaCreditoEmpacado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcNotaCreditoEmpacado runat="server" id="UcNotaCreditoEmpacado" />
</asp:Content>

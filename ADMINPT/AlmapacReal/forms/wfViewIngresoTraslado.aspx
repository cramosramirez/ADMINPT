<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewIngresoTraslado.aspx.cs" Inherits="ADMINPT.AlmapacReal.forms.wfViewIngresoTraslado" %>

<%@ Register Src="~/AlmapacReal/View/UcIngresosJiboa.ascx" TagPrefix="uc1" TagName="UcIngresosJiboa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcIngresosJiboa runat="server" id="UcIngresosJiboa" />
</asp:Content>

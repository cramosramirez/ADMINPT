<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfViewMomvimientos.aspx.cs" Inherits="ADMINPT.AlmapacReal.forms.wfViewMomvimientos" %>

<%@ Register Src="~/AlmapacReal/View/UcMovimientos.ascx" TagPrefix="uc1" TagName="UcMovimientos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcMovimientos runat="server" id="UcMovimientos" />
</asp:Content>

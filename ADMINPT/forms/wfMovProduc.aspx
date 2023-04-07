<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMovProduc.aspx.cs" Inherits="ADMINPT.forms.wfMovProduc" %>

<%@ Register Src="~/controles/controlesReportes/UcViewMovProduc.ascx" TagPrefix="uc1" TagName="UcViewMovProduc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">

    <uc1:UcViewMovProduc runat="server" id="UcViewMovProduc" />
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMovEntSal.aspx.cs" Inherits="ADMINPT.forms.wfMovEntSal" %>

<%@ Register Src="~/controles/controlesReportes/UcViewMovEntSal.ascx" TagPrefix="uc1" TagName="UcViewMovEntSal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:UcViewMovEntSal runat="server" id="UcViewMovEntSal" />
</asp:Content>

﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfEXISTENCIA.aspx.cs" Inherits="ADMINPT.forms.wfEXISTENCIA" %>

<%@ Register Src="~/controles/KardexZafra/UcViewExistencias.ascx" TagPrefix="uc1" TagName="UcViewExistencias" %>


<%--<%@ Register Src="~/controles/existencia/UcMantEXISTENCIA.ascx" TagPrefix="uc1" TagName="UcMantEXISTENCIA" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
   <%-- <uc1:UcMantEXISTENCIA runat="server" id="UcMantEXISTENCIA" />--%><uc1:UcViewExistencias runat="server" id="UcViewExistencias" />
</asp:Content>

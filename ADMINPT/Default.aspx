<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADMINPT.Default" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    .center {
  display: block;
  margin-left: auto;
  margin-right: auto;
  width: 50%;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <dx:ASPxImage ID="img_principal" runat="server" ImageUrl="~/imagenes/inicio.jpg" Width="50%" ClientVisible="true" CssClass="center"  ShowLoadingImage="true">
    </dx:ASPxImage>
    <dx:ASPxImage ID="img_adminpt" runat="server" ImageUrl="~/imagenes/logo.png" Width="50%"  ClientVisible="false" ShowLoadingImage="true"  CssClass="center">
    </dx:ASPxImage>
     <dx:ASPxImage ID="img_injiboa1" runat="server" ImageUrl="~/imagenes/injiboa1.jpg" Width="50%"  ClientVisible="false" ShowLoadingImage="true"  CssClass="center">
    </dx:ASPxImage>
     <dx:ASPxImage ID="img_almaconsa" runat="server" ImageUrl="~/imagenes/ALMACONSA.jpg" Width="50%"  ClientVisible="false" ShowLoadingImage="true"  CssClass="center">
    </dx:ASPxImage>
     <dx:ASPxImage ID="img_almapac" runat="server" ImageUrl="~/imagenes/ALMAPAC.jpg" Width="50%"  ClientVisible="false" ShowLoadingImage="true"  CssClass="center">
    </dx:ASPxImage>
</asp:Content>

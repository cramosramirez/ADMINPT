<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfMantCosumoInterno.aspx.cs" Inherits="ADMINPT.forms.wfMantCosumoInterno" %>

<%@ Register Src="~/controles/movimiento_vtjiboaEmp/UcCosumoInterno.ascx" TagPrefix="uc1" TagName="UcCosumoInterno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="../css/sweetalert.css" rel="stylesheet" />
     <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/sweetalert.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <uc1:uccosumointerno runat="server" id="UcCosumoInterno" />
</asp:Content>

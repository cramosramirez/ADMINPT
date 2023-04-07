<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantBODEGA.ascx.cs" Inherits="ADMINPT.controles.bodega.UcMantBODEGA" %>
<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/bodega/UcListaBODEGA.ascx" TagPrefix="uc1" TagName="UcListaBODEGA" %>
<%@ Register Src="~/controles/bodega/UcVistaBODEGA.ascx" TagPrefix="uc1" TagName="UcVistaBODEGA" %>

<uc1:UCBarraOpciones runat="server" ID="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada" />
<uc1:UCEncabezado runat="server" ID="UCEncabezado" />
<uc1:UcListaBODEGA runat="server" id="UcListaBODEGA" OnEditando="UCListaBODEGA_Editando" PermitirEditar="true" />
<uc1:UcVistaBODEGA runat="server" id="UcVistaBODEGA" />

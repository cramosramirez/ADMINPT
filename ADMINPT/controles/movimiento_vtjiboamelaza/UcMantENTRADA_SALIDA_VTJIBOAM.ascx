<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantENTRADA_SALIDA_VTJIBOAM.ascx.cs" Inherits="ADMINPT.controles.movimiento_vtjiboamelaza.UcMantENTRADA_SALIDA_VTJIBOAM" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/movimiento_vtjiboamelaza/UcListaENTRADA_SALIDA_ENCA_VTJIBOAM.ascx" TagPrefix="uc1" TagName="UcListaENTRADA_SALIDA_ENCA_VTJIBOAM" %>
<%@ Register Src="~/controles/movimiento_vtjiboamelaza/UcVistaENTRADA_SALIDA_ENCA_VTJIBOAM.ascx" TagPrefix="uc1" TagName="UcVistaENTRADA_SALIDA_ENCA_VTJIBOAM" %>



<%@ Register Src="~/controles/UCBarraNavegacion.ascx" TagPrefix="uc1" TagName="UCBarraNavegacion" %>

<uc1:UCBarraNavegacion runat="server" id="UCBarraNavegacion" />
<uc1:ucBarraopciones runat="server" id="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada" Visible="false" />
<uc1:UCEncabezado runat="server" id="UCEncabezado" />
<uc1:UcListaENTRADA_SALIDA_ENCA_VTJIBOAM runat="server" id="UcListaENTRADA_SALIDA_ENCA_VTJIBOAM" />
<uc1:UcVistaENTRADA_SALIDA_ENCA_VTJIBOAM runat="server" id="UcVistaENTRADA_SALIDA_ENCA_VTJIBOAM" />
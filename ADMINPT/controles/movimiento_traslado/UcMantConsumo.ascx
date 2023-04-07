<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantConsumo.ascx.cs" Inherits="ADMINPT.controles.movimiento_traslado.UcMantConsumo" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/movimiento_traslado/UcListaENTRADA_SALIDA_ENCA_TRASLADO.ascx" TagPrefix="uc1" TagName="UcListaENTRADA_SALIDA_ENCA_TRASLADO" %>
<%@ Register Src="~/controles/UCBarraNavegacion.ascx" TagPrefix="uc1" TagName="UCBarraNavegacion" %>
<%@ Register Src="~/controles/movimiento_traslado/UcConsumoAgricola.ascx" TagPrefix="uc1" TagName="UcConsumoAgricola" %>



<uc1:UCBarraNavegacion runat="server" ID="UCBarraNavegacion" />
<uc1:ucBarraopciones runat="server" id="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada" Visible="false"   />
<uc1:UCEncabezado runat="server" id="UCEncabezado" />
<uc1:UcListaENTRADA_SALIDA_ENCA_TRASLADO runat="server" id="UcListaENTRADA_SALIDA_ENCA_TRASLADO" />
<uc1:UcConsumoAgricola runat="server" id="UcConsumoAgricola" />

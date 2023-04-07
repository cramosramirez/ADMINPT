<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantENTRADA_SALIDA_ESP.ascx.cs" Inherits="ADMINPT.controles.movimiento_esp.UcMantENTRADA_SALIDA_ESP" %>

<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/movimiento_esp/UcVistaENTRADA_SALIDA_ENCA_ESP.ascx" TagPrefix="uc1" TagName="UcVistaENTRADA_SALIDA_ENCA_ESP" %>
<%@ Register Src="~/controles/movimiento_esp/UcListaENTRADA_SALIDA_ENCA_ESP.ascx" TagPrefix="uc1" TagName="UcListaENTRADA_SALIDA_ENCA_ESP" %>

<%@ Register Src="~/controles/UCBarraNavegacion.ascx" TagPrefix="uc1" TagName="UCBarraNavegacion" %>

<uc1:UCBarraNavegacion runat="server" id="UCBarraNavegacion" />
<uc1:ucBarraopciones runat="server" id="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada" Visible="false" />
<uc1:UCEncabezado runat="server" id="UCEncabezado" />
<uc1:UcListaENTRADA_SALIDA_ENCA_ESP runat="server" ID="UcListaENTRADA_SALIDA_ENCA_ESP" OnEditando="UcListaENTRADA_SALIDA_ENCA_ESP_Editando" PermitirEditar="true" />
<uc1:UcVistaENTRADA_SALIDA_ENCA_ESP runat="server" id="UcVistaENTRADA_SALIDA_ENCA_ESP" />

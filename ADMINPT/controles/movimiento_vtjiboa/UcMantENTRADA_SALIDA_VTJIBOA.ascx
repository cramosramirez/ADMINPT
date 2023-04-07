<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantENTRADA_SALIDA_VTJIBOA.ascx.cs" Inherits="ADMINPT.controles.movimiento_vtjiboa.UcMantENTRADA_SALIDA_VTJIBOA" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/movimiento_vtjiboa/UcListaENTRADA_SALIDA_ENCA_VTJIBOA.ascx" TagPrefix="uc1" TagName="UcListaENTRADA_SALIDA_ENCA_VTJIBOA" %>
<%@ Register Src="~/controles/movimiento_vtjiboa/UcVistaENTRADA_SALIDA_ENCA_VTJIBOA.ascx" TagPrefix="uc1" TagName="UcVistaENTRADA_SALIDA_ENCA_VTJIBOA" %>



<%@ Register Src="~/controles/UCBarraNavegacion.ascx" TagPrefix="uc1" TagName="UCBarraNavegacion" %>

<uc1:UCBarraNavegacion runat="server" id="UCBarraNavegacion" />
<uc1:ucBarraopciones runat="server" id="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada" Visible="false" />
<uc1:UCEncabezado runat="server" id="UCEncabezado" />
<uc1:UcListaENTRADA_SALIDA_ENCA_VTJIBOA runat="server" id="UcListaENTRADA_SALIDA_ENCA_VTJIBOA" />
<uc1:UcVistaENTRADA_SALIDA_ENCA_VTJIBOA runat="server" id="UcVistaENTRADA_SALIDA_ENCA_VTJIBOA" />

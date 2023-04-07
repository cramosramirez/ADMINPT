<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantENTRADA_SALIDA_EXPRES.ascx.cs" Inherits="ADMINPT.controles.movimientoExpress.UcMantENTRADA_SALIDA_EXPRES" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/UCBarraNavegacion.ascx" TagPrefix="uc1" TagName="UCBarraNavegacion" %>
<%@ Register Src="~/controles/movimientoExpress/UcListaENTRADA_SALIDA_ENCA_EXPRES.ascx" TagPrefix="uc1" TagName="UcListaENTRADA_SALIDA_ENCA_EXPRES" %>
<%@ Register Src="~/controles/movimientoExpress/UcVistaENTRADA_SALIDA_ENCA_EXPRES.ascx" TagPrefix="uc1" TagName="UcVistaENTRADA_SALIDA_ENCA_EXPRES" %>





<uc1:UCBarraNavegacion runat="server" ID="UCBarraNavegacion" />
<uc1:ucBarraopciones runat="server" id="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada" Visible="false"   />
<uc1:UCEncabezado runat="server" id="UCEncabezado" />
<uc1:UcListaENTRADA_SALIDA_ENCA_EXPRES runat="server" id="UcListaENTRADA_SALIDA_ENCA_EXPRES" />
<uc1:UcVistaENTRADA_SALIDA_ENCA_EXPRES runat="server" id="UcVistaENTRADA_SALIDA_ENCA_EXPRES" />

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantENTRADA_SALIDA_VTADIZUCAR.ascx.cs" Inherits="ADMINPT.controles.movimento_vtadizucar.UcMantENTRADA_SALIDA_VTADIZUCAR" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/movimento_vtadizucar/UcListaENTRADA_SALIDA_ENCA_VTADIZUCAR.ascx" TagPrefix="uc1" TagName="UcListaENTRADA_SALIDA_ENCA_VTADIZUCAR" %>
<%@ Register Src="~/controles/movimento_vtadizucar/UcVistaENTRADA_SALIDA_ENCA_VTADIZUCAR.ascx" TagPrefix="uc1" TagName="UcVistaENTRADA_SALIDA_ENCA_VTADIZUCAR" %>


<%@ Register Src="~/controles/UCBarraNavegacion.ascx" TagPrefix="uc1" TagName="UCBarraNavegacion" %>

<uc1:UCBarraNavegacion runat="server" id="UCBarraNavegacion" />
<uc1:ucBarraopciones runat="server" id="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada" Visible="false" />
<uc1:UCEncabezado runat="server" id="UCEncabezado" />
<uc1:UcListaENTRADA_SALIDA_ENCA_VTADIZUCAR runat="server" id="UcListaENTRADA_SALIDA_ENCA_VTADIZUCAR" />
<uc1:UcVistaENTRADA_SALIDA_ENCA_VTADIZUCAR runat="server" id="UcVistaENTRADA_SALIDA_ENCA_VTADIZUCAR" />

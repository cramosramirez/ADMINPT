<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantENTRADA_SALIDA.ascx.cs" Inherits="ADMINPT.controles.movimiento.UcMantENTRADA_SALIDA" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/movimiento/UcVistaENTRADA_SALIDA_ENCA.ascx" TagPrefix="uc1" TagName="UcVistaENTRADA_SALIDA_ENCA" %>
<%@ Register Src="~/controles/movimiento/UcListaENTRADA_SALIDA_ENCA.ascx" TagPrefix="uc1" TagName="UcListaENTRADA_SALIDA_ENCA" %>

<uc1:ucBarraopciones runat="server" id="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada"  />
<uc1:UCEncabezado runat="server" id="UCEncabezado" />
<uc1:UcListaENTRADA_SALIDA_ENCA runat="server" ID="UcListaENTRADA_SALIDA_ENCA" OnEditando="UcListaENTRADA_SALIDA_ENCA_Editando" PermitirEditar="true" />
<uc1:UcVistaENTRADA_SALIDA_ENCA runat="server" id="UcVistaENTRADA_SALIDA_ENCA" />










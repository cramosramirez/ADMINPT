<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantENTRADA_SALIDA_VTJIBOAEMP.ascx.cs" Inherits="ADMINPT.controles.movimiento_vtjiboaEmp.UcMantENTRADA_SALIDA_VTJIBOAEMP" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/UCBarraNavegacion.ascx" TagPrefix="uc1" TagName="UCBarraNavegacion" %>
<%@ Register Src="~/controles/movimiento_vtjiboaEmp/UcListaENTRADA_SALIDA_ENCA_VTJIBOAEMP.ascx" TagPrefix="uc1" TagName="UcListaENTRADA_SALIDA_ENCA_VTJIBOAEMP" %>
<%@ Register Src="~/controles/movimiento_vtjiboaEmp/UcVistaENTRADA_SALIDA_ENCA_VTJIBOAEMP.ascx" TagPrefix="uc1" TagName="UcVistaENTRADA_SALIDA_ENCA_VTJIBOAEMP" %>



<uc1:UCBarraNavegacion runat="server" id="UCBarraNavegacion" />
<uc1:ucBarraopciones runat="server" id="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada" Visible="false" />
<uc1:UCEncabezado runat="server" id="UCEncabezado" />
<uc1:UcListaENTRADA_SALIDA_ENCA_VTJIBOAEMP runat="server" id="UcListaENTRADA_SALIDA_ENCA_VTJIBOAEMP" />
<uc1:UcVistaENTRADA_SALIDA_ENCA_VTJIBOAEMP runat="server" id="UcVistaENTRADA_SALIDA_ENCA_VTJIBOAEMP" />

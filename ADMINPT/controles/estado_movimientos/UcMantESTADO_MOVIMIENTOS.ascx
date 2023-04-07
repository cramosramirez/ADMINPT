<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantESTADO_MOVIMIENTOS.ascx.cs" Inherits="ADMINPT.controles.estado_movimientos.UcMantESTADO_MOVIMIENTOS" %>

<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/ESTADO_MOVIMIENTOS/UcVistaESTADO_MOVIMIENTOS.ascx" TagPrefix="uc1" TagName="UcVistaESTADO_MOVIMIENTOS" %>
<%@ Register Src="~/controles/ESTADO_MOVIMIENTOS/UcListaESTADO_MOVIMIENTOS.ascx" TagPrefix="uc1" TagName="UcListaESTADO_MOVIMIENTOS" %>

<uc1:UCBarraOpciones runat="server" ID="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada" />
<uc1:UCEncabezado runat="server" ID="UCEncabezado" />
<uc1:UcVistaESTADO_MOVIMIENTOS runat="server" id="UcVistaESTADO_MOVIMIENTOS" />
<uc1:UcListaESTADO_MOVIMIENTOS runat="server" id="UcListaESTADO_MOVIMIENTOS" OnEditando="UcListaESTADO_MOVIMIENTOS_Editando" PermitirEditar="true" />

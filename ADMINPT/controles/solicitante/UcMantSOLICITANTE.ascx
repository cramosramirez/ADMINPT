<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantSOLICITANTE.ascx.cs" Inherits="ADMINPT.controles.solicitante.UcMantSOLICITANTE" %>
<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/SOLICITANTE/UcVistaSOLICITANTE.ascx" TagPrefix="uc1" TagName="UcVistaSOLICITANTE" %>
<%@ Register Src="~/controles/SOLICITANTE/UcListaSOLICITANTE.ascx" TagPrefix="uc1" TagName="UcListaSOLICITANTE" %>

<uc1:UCBarraOpciones runat="server" ID="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada" />
<uc1:UCEncabezado runat="server" ID="UCEncabezado" />
<uc1:UcVistaSOLICITANTE runat="server" id="UcVistaSOLICITANTE" />
<uc1:UcListaSOLICITANTE runat="server" id="UcListaSOLICITANTE" OnEditando="UcListaSOLICITANTE_Editando" PermitirEditar="true" />

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantORDEN_GLOBAL_SALDO.ascx.cs" Inherits="ADMINPT.controles.orden_global_saldo.UcMantORDEN_GLOBAL_SALDO" %>

<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/ORDEN_GLOBAL_SALDO/UcListaORDEN_GLOBAL_SALDO.ascx" TagPrefix="uc1" TagName="UcListaORDEN_GLOBAL_SALDO" %>
<%@ Register Src="~/controles/ORDEN_GLOBAL_SALDO/UcVistaORDEN_GLOBAL_SALDO.ascx" TagPrefix="uc1" TagName="UcVistaORDEN_GLOBAL_SALDO" %>

<%@ Register Src="~/controles/UCBarraNavegacion.ascx" TagPrefix="uc1" TagName="UCBarraNavegacion" %>


<uc1:UCBarraNavegacion runat="server" ID="UCBarraNavegacion" />
<uc1:ucBarraopciones runat="server" id="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada" Visible="false"   />
<uc1:UCEncabezado runat="server" id="UCEncabezado" />
<uc1:UcListaORDEN_GLOBAL_SALDO runat="server" id="UcListaORDEN_GLOBAL_SALDO" OnEditando="UCListaORDEN_GLOBAL_SALDO_Editando" PermitirEditar="false" />
<uc1:UcVistaORDEN_GLOBAL_SALDO runat="server" id="UcVistaORDEN_GLOBAL_SALDO" />
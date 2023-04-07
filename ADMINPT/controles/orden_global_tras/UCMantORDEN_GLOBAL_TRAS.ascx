<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCMantORDEN_GLOBAL_TRAS.ascx.cs" Inherits="ADMINPT.controles.orden_global_tras.UCMantORDEN_GLOBAL_TRAS" %>

<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/ORDEN_GLOBAL_TRAS/UcListaORDEN_GLOBAL_TRAS.ascx" TagPrefix="uc1" TagName="UcListaORDEN_GLOBAL_TRAS" %>
<%@ Register Src="~/controles/ORDEN_GLOBAL_TRAS/UcVistaORDEN_GLOBAL_TRAS.ascx" TagPrefix="uc1" TagName="UcVistaORDEN_GLOBAL_TRAS" %>

<uc1:UCBarraOpciones runat="server" ID="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada" />
<uc1:UCEncabezado runat="server" ID="UCEncabezado" />
<uc1:UcListaORDEN_GLOBAL_TRAS runat="server" id="UcListaORDEN_GLOBAL_TRAS" OnEditando="UCListaORDEN_GLOBAL_TRAS_Editando" PermitirEditar="false" />
<uc1:UcVistaORDEN_GLOBAL_TRAS runat="server" id="UcVistaORDEN_GLOBAL_TRAS" />
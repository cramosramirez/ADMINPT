<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCMantPRESENTACION_TRAS.ascx.cs" Inherits="ADMINPT.controles.presentacion_tras.UCMantPRESENTACION_TRAS" %>
<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/presentacion_tras/UCListaPRESENTACION_TRAS.ascx" TagPrefix="uc1" TagName="UCListaPRESENTACION_TRAS" %>
<%@ Register Src="~/controles/presentacion_tras/UCVistaPRESENTACION_TRAS.ascx" TagPrefix="uc1" TagName="UCVistaPRESENTACION_TRAS" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>


<uc1:ucBarraopciones runat="server" id="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada"  />
<uc1:UCEncabezado runat="server" id="UCEncabezado" />
<uc1:UCListaPRESENTACION_TRAS runat="server" id="UCListaPRESENTACION_TRAS1" OnEditando="UCListaPRESENTACION_TRAS1_Editando" PermitirEditar="true" />
<uc1:UCVistaPRESENTACION_TRAS runat="server" Id="UCVistaPRESENTACION_TRAS1" />
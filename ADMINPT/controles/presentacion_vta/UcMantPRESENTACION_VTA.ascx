<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantPRESENTACION_VTA.ascx.cs" Inherits="ADMINPT.controles.presentacion_vta.UcMantPRESENTACION_VTA" %>
<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/presentacion_vta/UcListaPRESENTACION_VTA.ascx" TagPrefix="uc1" TagName="UcListaPRESENTACION_VTA" %>
<%@ Register Src="~/controles/presentacion_vta/UcVistaPRESENTACION_VTA.ascx" TagPrefix="uc1" TagName="UcVistaPRESENTACION_VTA" %>


<uc1:UCBarraOpciones runat="server" ID="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada" />
<uc1:UCEncabezado runat="server" ID="UCEncabezado" />
<uc1:UcListaPRESENTACION_VTA runat="server" id="UcListaPRESENTACION_VTA" OnEditando="UcListaPRESENTACION_VTA_Editando" PermitirEditar="true" />
<uc1:UcVistaPRESENTACION_VTA runat="server" id="UcVistaPRESENTACION_VTA" />

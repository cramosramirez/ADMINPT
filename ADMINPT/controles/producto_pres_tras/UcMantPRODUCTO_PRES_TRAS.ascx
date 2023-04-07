<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantPRODUCTO_PRES_TRAS.ascx.cs" Inherits="ADMINPT.controles.producto_pres_tras.UcMantPRODUCTO_PRES_TRAS" %>
<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/producto_pres_tras/UcListaPRODUCTO_PRES_TRAS.ascx" TagPrefix="uc1" TagName="UcListaPRODUCTO_PRES_TRAS" %>
<%@ Register Src="~/controles/producto_pres_tras/UcVistaPRODUCTO_PRES_TRAS.ascx" TagPrefix="uc1" TagName="UcVistaPRODUCTO_PRES_TRAS" %>

<uc1:UCBarraOpciones runat="server" ID="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada" />
<uc1:UCEncabezado runat="server" ID="UCEncabezado" />
<uc1:UcListaPRODUCTO_PRES_TRAS runat="server" id="UcListaPRODUCTO_PRES_TRAS" OnEditando="UcListaPRODUCTO_PRES_TRAS_Editando" PermitirEditar="true" />
<uc1:UcVistaPRODUCTO_PRES_TRAS runat="server" id="UcVistaPRODUCTO_PRES_TRAS" />

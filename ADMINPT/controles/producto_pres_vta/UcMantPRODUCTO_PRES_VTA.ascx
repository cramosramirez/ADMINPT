<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantPRODUCTO_PRES_VTA.ascx.cs" Inherits="ADMINPT.controles.producto_pres_vta.UcMantPRODUCTO_PRES_VTA" %>
<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/producto_pres_vta/UcListaPRODUCTO_PRES_VTA.ascx" TagPrefix="uc1" TagName="UcListaPRODUCTO_PRES_VTA" %>
<%@ Register Src="~/controles/producto_pres_vta/UcVistaPRODUCTO_PRES_VTA.ascx" TagPrefix="uc1" TagName="UcVistaPRODUCTO_PRES_VTA" %>



<uc1:UCBarraOpciones runat="server" ID="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada" />
<uc1:UCEncabezado runat="server" ID="UCEncabezado" />
<uc1:UcListaPRODUCTO_PRES_VTA runat="server" id="UcListaPRODUCTO_PRES_VTA" OnEditando="UcListaPRODUCTO_PRES_VTA_Editando" PermitirEditar="true" />
<uc1:UcVistaPRODUCTO_PRES_VTA runat="server" id="UcVistaPRODUCTO_PRES_VTA" />

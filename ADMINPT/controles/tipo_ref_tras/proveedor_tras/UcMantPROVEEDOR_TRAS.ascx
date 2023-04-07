<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantPROVEEDOR_TRAS.ascx.cs" Inherits="ADMINPT.controles.proveedor_tras.UcMantPROVEEDOR_TRAS" %>

<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/PROVEEDOR_TRAS/UcVistaPROVEEDOR_TRAS.ascx" TagPrefix="uc1" TagName="UcVistaPROVEEDOR_TRAS" %>
<%@ Register Src="~/controles/PROVEEDOR_TRAS/UcListaPROVEEDOR_TRAS.ascx" TagPrefix="uc1" TagName="UcListaPROVEEDOR_TRAS" %>

<uc1:UCBarraOpciones runat="server" ID="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada" />
<uc1:UCEncabezado runat="server" ID="UCEncabezado" />
<uc1:UcVistaPROVEEDOR_TRAS runat="server" id="UcVistaPROVEEDOR_TRAS" />
<uc1:UcListaPROVEEDOR_TRAS runat="server" id="UcListaPROVEEDOR_TRAS" OnEditando="UcListaPROVEEDOR_TRAS_Editando" PermitirEditar="true" />

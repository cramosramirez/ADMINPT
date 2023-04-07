<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantPRODUCTO.ascx.cs" Inherits="ADMINPT.controles.producto.UcMantPRODUCTO" %>
<%@ Register Src="~/controles/producto/UcListaPRODUCTO.ascx" TagPrefix="uc1" TagName="UcListaPRODUCTO" %>
<%@ Register Src="~/controles/producto/UcVistaPRODUCTO.ascx" TagPrefix="uc1" TagName="UcVistaPRODUCTO" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>

<uc1:ucBarraopciones runat="server" id="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada"  />
<uc1:UCEncabezado runat="server" id="UCEncabezado" />
<uc1:UcListaPRODUCTO runat="server" id="UcListaPRODUCTO1" OnEditando="UcListaPRODUCTO1_Editando" PermitirEditar="true" />
<uc1:UcVistaPRODUCTO runat="server" id="UcVistaPRODUCTO1" />
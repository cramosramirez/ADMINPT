<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantTIPO_CONCEPTO_PROD.ascx.cs" Inherits="ADMINPT.controles.tipo_concepto_prod.UcMantTIPO_CONCEPTO_PROD" %>

<%@ Register Src="~/controles/TIPO_CONCEPTO_PROD/UcListaTIPO_CONCEPTO_PROD.ascx" TagPrefix="uc1" TagName="UcListaTIPO_CONCEPTO_PROD" %>
<%@ Register Src="~/controles/TIPO_CONCEPTO_PROD/UcVistaTIPO_CONCEPTO_PROD.ascx" TagPrefix="uc1" TagName="UcVistaTIPO_CONCEPTO_PROD" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>

<uc1:ucBarraopciones runat="server" id="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada"  />
<uc1:UCEncabezado runat="server" id="UCEncabezado" />
<uc1:UcListaTIPO_CONCEPTO_PROD runat="server" id="UcListaTIPO_CONCEPTO_PROD1" OnEditando="UcListaTIPO_CONCEPTO_PROD1_Editando" PermitirEditar="true" />
<uc1:UcVistaTIPO_CONCEPTO_PROD runat="server" id="UcVistaTIPO_CONCEPTO_PROD1" />
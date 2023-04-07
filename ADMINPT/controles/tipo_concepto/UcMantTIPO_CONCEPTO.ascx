<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantTIPO_CONCEPTO.ascx.cs" Inherits="ADMINPT.controles.tipo_concepto.UcMantTIPO_CONCEPTO" %>
<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/TIPO_CONCEPTO/UcListaTIPO_CONCEPTO.ascx" TagPrefix="uc1" TagName="UcListaTIPO_CONCEPTO" %>
<%@ Register Src="~/controles/TIPO_CONCEPTO/UcVistaTIPO_CONCEPTO.ascx" TagPrefix="uc1" TagName="UcVistaTIPO_CONCEPTO" %>


<uc1:UCBarraOpciones runat="server" ID="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada" />
<uc1:UCEncabezado runat="server" ID="UCEncabezado" />
<uc1:UcListaTIPO_CONCEPTO runat="server" id="UcListaTIPO_CONCEPTO" OnEditando="UCListaTIPO_CONCEPTO_Editando" PermitirEditar="true" />
<uc1:UcVistaTIPO_CONCEPTO runat="server" id="UcVistaTIPO_CONCEPTO" />

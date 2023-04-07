<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantTRANSPORTE.ascx.cs" Inherits="ADMINPT.controles.transporte.UcMantTRANSPORTE" %>

<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/TRANSPORTE/UcVistaTRANSPORTE.ascx" TagPrefix="uc1" TagName="UcVistaTRANSPORTE" %>
<%@ Register Src="~/controles/TRANSPORTE/UcListaTRANSPORTE.ascx" TagPrefix="uc1" TagName="UcListaTRANSPORTE" %>

<uc1:UCBarraOpciones runat="server" ID="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada" />
<uc1:UCEncabezado runat="server" ID="UCEncabezado" />
<uc1:UcVistaTRANSPORTE runat="server" id="UcVistaTRANSPORTE" />
<uc1:UcListaTRANSPORTE runat="server" id="UcListaTRANSPORTE" OnEditando="UcListaTRANSPORTE_Editando" PermitirEditar="true" />
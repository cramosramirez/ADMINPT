<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantTURNO.ascx.cs" Inherits="ADMINPT.controles.turno.UcMantTURNO" %>

<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/TURNO/UcListaTURNO.ascx" TagPrefix="uc1" TagName="UcListaTURNO" %>
<%@ Register Src="~/controles/TURNO/UcVistaTURNO.ascx" TagPrefix="uc1" TagName="UcVistaTURNO" %>


<uc1:UCBarraOpciones runat="server" ID="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada" />
<uc1:UCEncabezado runat="server" ID="UCEncabezado" />
<uc1:UcListaTURNO runat="server" id="UcListaTURNO" OnEditando="UCListaTURNO_Editando" PermitirEditar="true" />
<uc1:UcVistaTURNO runat="server" id="UcVistaTURNO" />

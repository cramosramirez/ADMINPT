<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCMantFAMILIA.ascx.cs" Inherits="ADMINPT.controles.familia.UCMantFAMILIA" %>
<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/familia/UCListaFAMILIA.ascx" TagPrefix="uc1" TagName="UCListaFAMILIA" %>
<%@ Register Src="~/controles/familia/UCVistaFAMILIA.ascx" TagPrefix="uc1" TagName="UCVistaFAMILIA" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>


<uc1:ucBarraopciones runat="server" id="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada"  />
<uc1:UCEncabezado runat="server" id="UCEncabezado" />
<uc1:UCListaFAMILIA runat="server" id="UCListaFAMILIA1" OnEditando="UCListaFAMILIA1_Editando" PermitirEditar="true" />
<uc1:UCVistaFAMILIA runat="server" Id="UCVistaFAMILIA1" />

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantKARDEX.ascx.cs" Inherits="ADMINPT.controles.kardex.UcMantKARDEX" %>

<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/kardex/UcListaKARDEX.ascx" TagPrefix="uc1" TagName="UcListaKARDEX" %>
<%@ Register Src="~/controles/kardex/UcVistaKARDEX.ascx" TagPrefix="uc1" TagName="UcVistaKARDEX" %>
<%@ Register Src="~/controles/UCBarraNavegacion.ascx" TagPrefix="uc1" TagName="UCBarraNavegacion" %>

<uc1:UCBarraNavegacion runat="server" ID="UCBarraNavegacion" />


<uc1:UCBarraOpciones runat="server" ID="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada"  Visible="false"/>
<uc1:UCEncabezado runat="server" id="UCEncabezado" />
<uc1:UcListaKARDEX runat="server" id="UcListaKARDEX" PermitirEditar="false"  />
<uc1:UcVistaKARDEX runat="server" id="UcVistaKARDEX" />

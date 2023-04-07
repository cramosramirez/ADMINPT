<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantCONTROL_TRASLADO.ascx.cs" Inherits="ADMINPT.controles.control_traslado.UcMantCONTROL_TRASLADO" %>


<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/CONTROL_TRASLADO/UcListaCONTROL_TRASLADO.ascx" TagPrefix="uc1" TagName="UcListaCONTROL_TRASLADO" %>
<%@ Register Src="~/controles/CONTROL_TRASLADO/UcVistaCONTROL_TRASLADO.ascx" TagPrefix="uc1" TagName="UcVistaCONTROL_TRASLADO" %>
<%@ Register Src="~/controles/UCBarraNavegacion.ascx" TagPrefix="uc1" TagName="UCBarraNavegacion" %>

<uc1:UCBarraNavegacion runat="server" ID="UCBarraNavegacion" />
<uc1:UCBarraOpciones runat="server" ID="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada"  Visible="false"/>
<uc1:UCEncabezado runat="server" id="UCEncabezado" />
<uc1:UcListaCONTROL_TRASLADO runat="server" id="UcListaCONTROL_TRASLADO" PermitirEditar="true" />
<uc1:UcVistaCONTROL_TRASLADO runat="server" id="UcVistaCONTROL_TRASLADO" />

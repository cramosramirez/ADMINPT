<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantEXISTENCIA.ascx.cs" Inherits="ADMINPT.controles.existencia.UcMantEXISTENCIA" %>

<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/EXISTENCIA/UcListaEXISTENCIA.ascx" TagPrefix="uc1" TagName="UcListaEXISTENCIA" %>
<%@ Register Src="~/controles/EXISTENCIA/UcVistaEXISTENCIA.ascx" TagPrefix="uc1" TagName="UcVistaEXISTENCIA" %>
<%@ Register Src="~/controles/UCBarraNavegacion.ascx" TagPrefix="uc1" TagName="UCBarraNavegacion" %>

<uc1:UCBarraNavegacion runat="server" ID="UCBarraNavegacion" />
<uc1:UCBarraOpciones runat="server" ID="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada"  Visible="false"/>
<uc1:UCEncabezado runat="server" id="UCEncabezado" />


<uc1:UcListaEXISTENCIA runat="server" id="UcListaEXISTENCIA" PermitirEditar="false"  />
<uc1:UcVistaEXISTENCIA runat="server" id="UcVistaEXISTENCIA" />

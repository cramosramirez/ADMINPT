<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcVisorReporte.ascx.cs" Inherits="ADMINPT.controles.reporte.UcVisorReporte" %>
<%@ Register Src="~/controles/UCBarraNavegacion.ascx" TagPrefix="uc1" TagName="UCBarraNavegacion" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/UCReporte.ascx" TagPrefix="uc1" TagName="UCReporte" %>

<uc1:UCBarraNavegacion runat="server" id="UCBarraNavegacion" />
<uc1:UCEncabezado runat="server" id="UCEncabezado" />
<uc1:UCReporte runat="server" id="UCReporte" />

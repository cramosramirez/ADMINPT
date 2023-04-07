<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantMARCA.ascx.cs" Inherits="ADMINPT.controles.marca.UcMantMARCA" %>
<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/marca/UcListaMARCA.ascx" TagPrefix="uc1" TagName="UcListaMARCA" %>
<%@ Register Src="~/controles/marca/UcVistaMARCA.ascx" TagPrefix="uc1" TagName="UcVistaMARCA" %>



<uc1:UCBarraOpciones runat="server" ID="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada" />
<uc1:UCEncabezado runat="server" ID="UCEncabezado" />
<uc1:UcListaMARCA runat="server" id="UcListaMARCA" OnEditando="UcListaMARCA_Editando" PermitirEditar="true" />
<uc1:UcVistaMARCA runat="server" id="UcVistaMARCA" />

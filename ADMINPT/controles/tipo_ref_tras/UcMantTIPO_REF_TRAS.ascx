<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantTIPO_REF_TRAS.ascx.cs" Inherits="ADMINPT.controles.tipo_ref_tras.UcMantTIPO_REF_TRAS" %>
<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/tipo_ref_tras/UcVistaTIPO_REF_TRAS.ascx" TagPrefix="uc1" TagName="UcVistaTIPO_REF_TRAS" %>
<%@ Register Src="~/controles/tipo_ref_tras/UcListaTIPO_REF_TRAS.ascx" TagPrefix="uc1" TagName="UcListaTIPO_REF_TRAS" %>

<uc1:UCBarraOpciones runat="server" ID="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada" />
<uc1:UCEncabezado runat="server" ID="UCEncabezado" />
<uc1:UcVistaTIPO_REF_TRAS runat="server" id="UcVistaTIPO_REF_TRAS" />
<uc1:UcListaTIPO_REF_TRAS runat="server" id="UcListaTIPO_REF_TRAS" OnEditando="UcListaTIPO_REF_TRAS_Editando" PermitirEditar="true" />



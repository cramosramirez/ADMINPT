<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCMantUNIDAD_MEDI_FAC.ascx.cs" Inherits="ADMINPT.controles.unidad_medi_fac.UCMantUNIDAD_MEDI_FAC" %>
<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/UNIDAD_MEDI_FAC/UCListaUNIDAD_MEDI_FAC.ascx" TagPrefix="uc1" TagName="UCListaUNIDAD_MEDI_FAC" %>
<%@ Register Src="~/controles/UNIDAD_MEDI_FAC/UCVistaUNIDAD_MEDI_FAC.ascx" TagPrefix="uc1" TagName="UCVistaUNIDAD_MEDI_FAC" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>


<uc1:ucBarraopciones runat="server" id="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada"  />
<uc1:UCEncabezado runat="server" id="UCEncabezado" />
<uc1:UCListaUNIDAD_MEDI_FAC runat="server" id="UCListaUNIDAD_MEDI_FAC1" OnEditando="UCListaUNIDAD_MEDI_FAC1_Editando" PermitirEditar="true" />
<uc1:UCVistaUNIDAD_MEDI_FAC runat="server" Id="UCVistaUNIDAD_MEDI_FAC1" />
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCMantUNIDAD_MEDI_CONSAA.ascx.cs" Inherits="ADMINPT.controles.unidad_medi_consaa.UCMantUNIDAD_MEDI_CONSAA" %>
<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/UNIDAD_MEDI_CONSAA/UCListaUNIDAD_MEDI_CONSAA.ascx" TagPrefix="uc1" TagName="UCListaUNIDAD_MEDI_CONSAA" %>
<%@ Register Src="~/controles/UNIDAD_MEDI_CONSAA/UCVistaUNIDAD_MEDI_CONSAA.ascx" TagPrefix="uc1" TagName="UCVistaUNIDAD_MEDI_CONSAA" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>


<uc1:ucBarraopciones runat="server" id="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada"  />
<uc1:UCEncabezado runat="server" id="UCEncabezado" />
<uc1:UCListaUNIDAD_MEDI_CONSAA runat="server" id="UCListaUNIDAD_MEDI_CONSAA1" OnEditando="UCListaUNIDAD_MEDI_CONSAA1_Editando" PermitirEditar="true" />
<uc1:UCVistaUNIDAD_MEDI_CONSAA runat="server" Id="UCVistaUNIDAD_MEDI_CONSAA1" />
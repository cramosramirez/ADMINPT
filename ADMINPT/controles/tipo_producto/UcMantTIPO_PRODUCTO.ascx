<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantTIPO_PRODUCTO.ascx.cs" Inherits="ADMINPT.controles.tipo_producto.UcMantTIPO_PRODUCTO" %>
<%@ Register Src="~/controles/tipo_producto/UcListaTIPO_PRODUCTO.ascx" TagPrefix="uc1" TagName="UcListaTIPO_PRODUCTO" %>
<%@ Register Src="~/controles/tipo_producto/UcVistaTIPO_PRODUCTO.ascx" TagPrefix="uc1" TagName="UcVistaTIPO_PRODUCTO" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>

<uc1:ucBarraopciones runat="server" id="UCBarraOpciones" OnOpcionSeleccionada="UCBarraOpciones_OpcionSeleccionada"  />
<uc1:UCEncabezado runat="server" id="UCEncabezado" />
<uc1:UcListaTIPO_PRODUCTO runat="server" id="UcListaTIPO_PRODUCTO1" OnEditando="UcListaTIPO_PRODUCTO1_Editando" PermitirEditar="true" />
<uc1:UcVistaTIPO_PRODUCTO runat="server" id="UcVistaTIPO_PRODUCTO1" />

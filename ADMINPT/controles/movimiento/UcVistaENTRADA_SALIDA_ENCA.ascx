<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcVistaENTRADA_SALIDA_ENCA.ascx.cs" Inherits="ADMINPT.controles.movimiento.UcVistaENTRADA_SALIDA_ENCA" %>

<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/controles/movimiento/UcListaENTRADA_SALIDA_DETA.ascx" TagPrefix="uc1" TagName="UcListaENTRADA_SALIDA_DETA" %>

<script type="text/javascript">
    function roundToTwo(num) {
        return +(Math.round(num + "e+2") + "e-2");
    }
    function _cantidaitem(s, e) {
        var fqq = (speFACTORQQ.GetText());
        var fkg = (speFACTORKG.GetText());
        var sac = (speSACOS.GetText());

        if (fqq === '' || sac === '') { speQuintales.SetText(0); }
        else { speQuintales.SetText(roundToTwo(fqq * sac, 2)); }

        if (fkg === '' || sac === '') { speKilogramos.SetText(0); }
        else { speKilogramos.SetText(roundToTwo(fkg * sac, 2)); }

    }
</script>
<style type="text/css">
    .formLayout {
        max-width: 1300px;
        margin: auto;
    }

    .wrapfly {
        white-space: normal;
        word-wrap: normal
    }
</style>
<dx:ASPxLabel ID="lbl_mensaje" runat="server" Text="" ForeColor="Red" Visible="false"></dx:ASPxLabel>
<dx:ASPxFormLayout ID="formLayout" runat="server" Theme="Default">
    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
    <Items>
        <dx:LayoutGroup Caption="Información del Movimiento" ColCount="1" GroupBoxDecoration="HeadingLine" UseDefaultPaddings="false" Paddings-PaddingTop="0px">
            <Paddings PaddingTop="0px"></Paddings>
            <Items>
                <dx:LayoutItem Caption="" ShowCaption="False" CaptionSettings-HorizontalAlign="Right">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <table class="tablaVista" id="conttb" runat="server">
                                <tr>
                                    <td class="filaVista">
                                        <dx:ASPxLabel runat="server" ID="ASPxLabel8" Text="Orden Traslado:"></dx:ASPxLabel>
                                    </td>
                                    <td class="filaVista">
                                        <dx:ASPxComboBox ID="cbxORDEN_GLOBAL_TRAS" runat="server" AutoPostBack="true" TextField="NUMREF" ValueField="ID_ORDEN_TRAS" ValueType="System.Int32" OnTextChanged="cbxORDEN_GLOBAL_TRAS_TextChanged">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
<%--                                            <ValidationSettings Display="Dynamic">
                                                <RequiredField IsRequired="True" ErrorText="Orden Traslado" />
                                            </ValidationSettings>--%>
                                        </dx:ASPxComboBox>
                                    </td>
                                </tr>
                                <tr>
 <td class="filaVista">
                                        <dx:ASPxLabel runat="server" ID="ASPxLabel4" Text="Captura Código:"></dx:ASPxLabel>
                                    </td>
                                    <td class="filaVista">
                                        <dx:ASPxTextBox ID="txt_CodCaptura" runat="server" ClientEnabled="true" OnTextChanged="txt_CodCaptura_TextChanged"  Width="50%" AutoPostBack="true">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td  class="filaVista">
                                         <dx:ASPxLabel runat="server" ID="ASPxLabel6" Text="Nº Documento:"></dx:ASPxLabel>

                                    </td>
                                    <td  class="filaVista">
                                        <dx:ASPxTextBox ID="txt_ndocument" runat="server" ClientEnabled="False" Width="50%">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                            </DisabledStyle>
                                        </dx:ASPxTextBox>
                                    </td>
<td class="filaVista">
                                        <dx:ASPxLabel runat="server" ID="ASPxLabel13" Text="Estado:"></dx:ASPxLabel>
                                    </td>
                                    <td class="filaVista">
                                        <dx:ASPxComboBox ID="cbxestado" runat="server" TextField="NOMBRE_ESTADO" ValueField="ID_ESTADO" ValueType="System.Int32" AutoPostBack="false" ClientEnabled="false">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                            <ValidationSettings Display="Dynamic">
                                                <RequiredField IsRequired="True" ErrorText="Estado Requerido!!" />
                                            </ValidationSettings>
                                        </dx:ASPxComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="filaVista">
                                        <dx:ASPxLabel runat="server" ID="ASPxLabel23" Text="Nº de registro (id):"></dx:ASPxLabel>
                                    </td>
                                    <td class="filaVista">
                                        <dx:ASPxTextBox ID="txtIdentificador" runat="server" ClientEnabled="false">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td class="filaVista">
                                        <dx:ASPxLabel runat="server" ID="ASPxLabel22" Text="Fecha:"></dx:ASPxLabel>
                                    </td>
                                    <td class="filaVista">
                                        <dx:ASPxDateEdit ID="dteFecha" runat="server" EditFormat="Custom" EditFormatString="dd/MM/yyyy">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                            <ValidationSettings Display="Dynamic">
                                                <RequiredField IsRequired="True" ErrorText="Fecha" />
                                            </ValidationSettings>
                                        </dx:ASPxDateEdit>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="filaVista">
                                        <dx:ASPxLabel runat="server" ID="ASPxLabel2" Text="Producto:"></dx:ASPxLabel>
                                    </td>
                                    <td class="filaVista" colspan="4">
                                        <dx:ASPxComboBox ID="cbxProducto"  Font-Bold ="true"   runat="server" TextField="NOMBRE_KARDEX" ValueField="ID_PRODUCTO" ValueType="System.Int32" AutoPostBack="true" OnTextChanged="cbxProducto_TextChanged" Width="97%">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                            <ValidationSettings Display="Dynamic">
                                                <RequiredField IsRequired="True" ErrorText="Zafra Actual" />
                                            </ValidationSettings>
                                        </dx:ASPxComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="filaVista">
                                        <dx:ASPxLabel runat="server" ID="ASPxLabel24" Text="Tipo Inventario:"></dx:ASPxLabel>
                                    </td>
                                    <td class="filaVista">
                                        <dx:ASPxRadioButton ID="rb_propio" runat="server" Text="Propio" TextAlign="right" TextSpacing="5px" Width="50%" Checked="true" GroupName="tpi"></dx:ASPxRadioButton>
                                    </td>
                                    <td class="filaVista">
                                        <dx:ASPxRadioButton ID="rb_Ajeno" runat="server" Text="Ajeno" TextAlign="right" TextSpacing="5px" Width="50%" GroupName="tpi"></dx:ASPxRadioButton>
                                    </td>
                                    <td class="filaVista">
                                        <dx:ASPxLabel ID="lbGuid" runat="server" Text="" ClientVisible="false"></dx:ASPxLabel>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="filaVista">
                                        <dx:ASPxLabel runat="server" ID="ASPxLabel5" Text="Presentacion:"></dx:ASPxLabel>
                                    </td>
                                    <td class="filaVista">
                                        <dx:ASPxComboBox ID="cbxPrestanciontras" runat="server" TextField="NOMBRE_PRESEN_TRAA" ValueField="ID_PRESEN_TRAS" ValueType="System.Int32">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                            <ValidationSettings Display="Dynamic">
                                                <RequiredField IsRequired="True" ErrorText="Dia Zafra" />
                                            </ValidationSettings>
                                        </dx:ASPxComboBox>
                                    </td>
                                    <td class="filaVista">
                                        <dx:ASPxLabel runat="server" ID="ASPxLabel14" Text="Unidad:"></dx:ASPxLabel>
                                    </td>
                                    <td class="filaVista">
                                        <dx:ASPxComboBox ID="cbxUnidad" runat="server" TextField="NOMBRE_UNIDAD" ValueField="ID_UNIDAD_FAC" ValueType="System.Int32" >
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                            <ValidationSettings Display="Dynamic">
                                                <RequiredField IsRequired="True" ErrorText="Tipo producto" />
                                            </ValidationSettings>
                                        </dx:ASPxComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="filaVista">
                                        <dx:ASPxLabel runat="server" ID="ASPxLabel10" Text="Zafra del producto:"></dx:ASPxLabel>
                                    </td>
                                    <td class="filaVista">
                                        <dx:ASPxComboBox ID="cbxZafraProd" Font-Bold="true" ForeColor="Maroon"  runat="server" TextField="NOMBRE_ZAFRA" ValueField="ID_ZAFRA" ValueType="System.Int32">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                            <ValidationSettings Display="Dynamic">
                                                <RequiredField IsRequired="True" ErrorText="Zafra Produccion" />
                                            </ValidationSettings>
                                        </dx:ASPxComboBox>

                                    </td>
                                    <td class="filaVista">
                                        <dx:ASPxLabel runat="server" ID="ASPxLabel25" Text="Zafra en curso:"></dx:ASPxLabel>
                                    </td>
                                    <td class="filaVista">
                                        <dx:ASPxComboBox ID="cbxZafraActual" runat="server" TextField="NOMBRE_ZAFRA" ValueField="ID_ZAFRA" ValueType="System.Int32" ClientEnabled="false">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                            <ValidationSettings Display="Dynamic">
                                                <RequiredField IsRequired="True" ErrorText="Zafra Actual" />
                                            </ValidationSettings>
                                        </dx:ASPxComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="filaVista">
                                        <dx:ASPxLabel runat="server" ID="ASPxLabel12" Text="Tipo Movimiento:"></dx:ASPxLabel>
                                    </td>
                                    <td class="filaVista">
                                        <dx:ASPxComboBox ID="cbxtipoMovimiento" runat="server" TextField="NOMBRE_MOV" ValueField="ID_TIPO_MOV" ValueType="System.Int32" AutoPostBack="true" OnTextChanged="cbxtipoMovimiento_TextChanged">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                            <ValidationSettings Display="Dynamic">
                                                <RequiredField IsRequired="True" ErrorText="Tipo Movimiento" />
                                            </ValidationSettings>
                                        </dx:ASPxComboBox>
                                    </td>
                                    <td class="filaVista">
                                        <dx:ASPxLabel runat="server" ID="lblConceptoTM" Text="Concepto:"></dx:ASPxLabel>
                                    </td>
                                    <td class="filaVista">
                                        <dx:ASPxComboBox ID="cbxConceptoTM" runat="server" TextField="NOMBRE_CONCE" ValueField="ID_CONCE" ValueType="System.Int32" AutoPostBack="true" OnTextChanged="cbxConceptoTM_TextChanged">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                            <ValidationSettings Display="Dynamic">
                                                <RequiredField IsRequired="True" ErrorText="Dia Zafra" />
                                            </ValidationSettings>
                                        </dx:ASPxComboBox>
                                    </td>
                                    <td class="filaVista">
                                        <dx:ASPxLabel runat="server" ID="ASPxLabel27" Text="Especifico:"></dx:ASPxLabel>
                                    </td>
                                    <td class="filaVista">
                                        <dx:ASPxComboBox ID="cbxEspecifico" runat="server" TextField="NOMBRE_ESPECI" ValueField="ID_ESPECI" ValueType="System.Int32" AutoPostBack="true">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                            <ValidationSettings Display="Dynamic">
                                                <RequiredField IsRequired="True" ErrorText="Lista Especifico Requerido!!" />
                                            </ValidationSettings>
                                        </dx:ASPxComboBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="filaVista">
                                        <dx:ASPxLabel runat="server" ID="lbBodegadest" Text="Bodega Origen:"></dx:ASPxLabel>
                                    </td>
                                    <td class="filaVista">
                                        <dx:ASPxComboBox ID="cbxBodegaOrigen" runat="server" TextField="NOMBRE" ValueField="ID_BODEGA" ValueType="System.Int32" AutoPostBack="true" OnTextChanged="cbxBodegaOrigen_TextChanged">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                            <ValidationSettings Display="Dynamic">
                                                <RequiredField IsRequired="True" ErrorText="Zafra Actual" />
                                            </ValidationSettings>
                                        </dx:ASPxComboBox>
                                    </td>
                                    <td class="filaVista">
                                        <dx:ASPxLabel runat="server" ID="lblBodegaDestino" Text="Bodega Destino:"></dx:ASPxLabel>
                                    </td>
                                    <td class="filaVista">
                                        <dx:ASPxComboBox ID="cbxBodegaDestino" runat="server" TextField="NOMBRE" ValueField="ID_BODEGA" ValueType="System.Int32">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                            <ValidationSettings Display="Dynamic">
                                                <RequiredField IsRequired="True" ErrorText="Zafra Actual" />
                                            </ValidationSettings>
                                        </dx:ASPxComboBox>
                                    </td>
                                    <td class="filaVista">
                                        <dx:ASPxLabel runat="server" ID="ASPxLabel19" Text="Cantidad de producto:"></dx:ASPxLabel>
                                    </td>
                                    <td class="filaVista">
                                        <dx:ASPxSpinEdit ID="speCantidad" ClientInstanceName="speCantidad" runat="server" Number="0" OnValueChanged="speCantidad_ValueChanged" AutoPostBack="true"> 
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                            <ValidationSettings Display="Dynamic">
                                                <RequiredField IsRequired="True" ErrorText="Cantidad" />
                                            </ValidationSettings>
                                        </dx:ASPxSpinEdit>
                                        <dx:ASPxLabel ID="lblSaldo" runat="server" Text="" ForeColor="Green" Visible="true"></dx:ASPxLabel>
                                        <dx:ASPxLabel ID="lblPresentacion" runat="server" Text="" ForeColor="Green" Visible="false"></dx:ASPxLabel>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="filaVista"></td>
                                    <td class="filaVista"></td>
                                    <td class="filaVista">
                                        <dx:ASPxLabel runat="server" ID="ASPxLabel11" Text="Factor(qq/gal):"></dx:ASPxLabel>
                                    </td>
                                    <td class="filaVista">
                                        <dx:ASPxSpinEdit ID="speFactor" ClientInstanceName="speFactor" runat="server" Number="0">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                            <ValidationSettings Display="Dynamic">
                                                <RequiredField IsRequired="True" ErrorText="Factor" />
                                            </ValidationSettings>
                                        </dx:ASPxSpinEdit>
                                    </td>
                                    <td class="filaVista">
                                        <dx:ASPxLabel runat="server" ID="ASPxLabel3" Text="Factor(kg):"></dx:ASPxLabel>
                                    </td>
                                    <td class="filaVista">
                                        <dx:ASPxSpinEdit ID="speFactorKg" ClientInstanceName="speFactor" runat="server" Number="0">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                            <ValidationSettings Display="Dynamic">
                                                <RequiredField IsRequired="True" ErrorText="Factor" />
                                            </ValidationSettings>
                                        </dx:ASPxSpinEdit>
                                    </td>
                                </tr>
                                <tr>
                                                                        <td class="filaVista">
                                        <dx:ASPxLabel runat="server" ID="lblProveedorTrans" Text="Proveedor:"></dx:ASPxLabel>
                                    </td>
                                    <td class="filaVista">
                                        <dx:ASPxComboBox ID="cbxProveedorTrans" runat="server" TextField="NOMBRE" ValueField="ID_PROV_TRAS" ValueType="System.Int32" Width="100%">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
          <%--                                  <ValidationSettings Display="Dynamic">
                                                <RequiredField IsRequired="True" ErrorText="Dia Zafra" />
                                            </ValidationSettings>--%>
                                        </dx:ASPxComboBox>
                                    </td>
                                                                        <td class="filaVista">
                                        <dx:ASPxLabel runat="server" ID="lblTransporte" Text="Transporte:"></dx:ASPxLabel>
                                    </td>
                                    <td class="filaVista">
                                        <dx:ASPxComboBox ID="cbxTransporte" runat="server" TextField="NOMBRE" ValueField="ID_TRANSPORTE" ValueType="System.Int32" Width="100%">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
<%--                                            <ValidationSettings Display="Dynamic">
                                                <RequiredField IsRequired="True" ErrorText="Dia Zafra" />
                                            </ValidationSettings>--%>
                                        </dx:ASPxComboBox>
                                    </td>
                                     <td  class="filaVista">
                                         <dx:ASPxLabel runat="server" ID="lblMotoritsta" Text="Motorista:"></dx:ASPxLabel>

                                    </td>
                                    <td  class="filaVista">
                                        <dx:ASPxTextBox ID="txtMotoritsta" runat="server" ClientEnabled="true" Width="75%">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                            </DisabledStyle>
                                        </dx:ASPxTextBox>
                                    </td>
                                    </tr>
  <tr>
                               
                                <td  class="filaVista">
                                         <dx:ASPxLabel runat="server" ID="lblNitMotor" Text="Nit:"></dx:ASPxLabel>

                                    </td>
                                    <td  class="filaVista">
                                        <dx:ASPxTextBox ID="txtNitMotor" runat="server" ClientEnabled="true" Width="50%">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                            </DisabledStyle>
                                        </dx:ASPxTextBox>
                                    </td>
                                <td  class="filaVista">
                                         <dx:ASPxLabel runat="server" ID="lblplacaCabezal" Text="Placa Cabezal:"></dx:ASPxLabel>

                                    </td>
                                    <td  class="filaVista">
                                        <dx:ASPxTextBox ID="txtplacaCabezal" runat="server" ClientEnabled="true" Width="68%">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                            </DisabledStyle>
                                        </dx:ASPxTextBox>
                                    </td>
                                <td  class="filaVista">
                                         <dx:ASPxLabel runat="server" ID="lblPlacaRemolque" Text="Placa Remolque:"></dx:ASPxLabel>

                                    </td>
                                    <td  class="filaVista">
                                        <dx:ASPxTextBox ID="txtPlacaRemolque" runat="server" ClientEnabled="true" Width="75%">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                            </DisabledStyle>
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                <td  class="filaVista">
                                         <dx:ASPxLabel runat="server" ID="lblContenedor" Text="Contenedor:"></dx:ASPxLabel>

                                    </td>
                                    <td  class="filaVista">
                                        <dx:ASPxTextBox ID="txtContenedor" runat="server" ClientEnabled="true" Width="50%">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                            </DisabledStyle>
                                        </dx:ASPxTextBox>
                                    </td>
<td  class="filaVista">
                                         <dx:ASPxLabel runat="server" ID="lblMarchamos" Text="Marchamos:"></dx:ASPxLabel>

                                    </td>
                                    <td  class="filaVista">
                                        <dx:ASPxTextBox ID="txtMarchamos" runat="server" ClientEnabled="true" Width="50%">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                            </DisabledStyle>
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                <td class="filaVista">
                                         <dx:ASPxLabel runat="server" ID="ASPxLabel18" Text="Observación:"></dx:ASPxLabel>

                                    </td>
                                    <td  class="filaVista" colspan="5">
                                        <dx:ASPxTextBox ID="txtObservacion" runat="server" ClientEnabled="true" Width="50%">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                            </DisabledStyle>
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td  class="filaVista" colspan="2">
                                        <dx:ASPxButton ID="btnAgregarProductos" runat="server" Text="Agregar producto a la lista" Width="200px" OnClick="btnAgregarProductos_Click">
                                            <Image IconID="actions_add_16x16">
                                            </Image>
                                        </dx:ASPxButton>
                                        <dx:ASPxButton ID="btnAgregarProductos0" runat="server" OnClick="btnAgregarProductos_Click" Text="Quitar producto de la lista" Width="200px">
                                            <Image IconID="actions_cancel_16x16">
                                            </Image>
                                        </dx:ASPxButton>
                                    </td>
                                    <td>

                                    </td>
                                    <td  class="filaVista"></td>
                                    <td  class="filaVista"></td>
                                    <td  class="filaVista"></td>
                                </tr>

                            </table>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                </dx:LayoutItem>
            </Items>
        </dx:LayoutGroup>
    </Items>
</dx:ASPxFormLayout>

<uc1:UcListaENTRADA_SALIDA_DETA runat="server" ID="UcListaENTRADA_SALIDA_DETA" />

<%--ENCABEZADO--%>
<asp:ObjectDataSource ID="odsKARDEX_BODEGA" runat="server" SelectMethod="ObtenerPorIdBodega" TypeName="ADMINPT.BL.CKARDEX">
    <SelectParameters>
        <asp:Parameter Name="ID_PRODUCTO" DefaultValue="-1" Type="Int32" />
        <asp:Parameter Name="ID_ZAFRA_PROD" DefaultValue="-1" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsPROVEEDOR_TRAS" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CPROVEEDOR_TRAS"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsTRANSPORTE" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CTRANSPORTE"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsESTADO_MOVIMIENTOS" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CESTADO_MOVIMIENTOS"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsORDEN_GLOBAL_TRAS" runat="server" SelectMethod="ObtenerListaCb" TypeName="ADMINPT.BL.CORDEN_GLOBAL_TRAS"> <SelectParameters> <asp:SessionParameter Name="ID_BODEP" SessionField="ID_BODEP" Type="Int32" /> </SelectParameters> </asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsBODEGAOrigen" runat="server" SelectMethod="ObtenerListaBodegaOrigen" TypeName="ADMINPT.BL.CBODEGA"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsTIPO_MOVIMIENTO" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CTIPO_MOVIMIENTO"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsBODEGADestino" runat="server" SelectMethod="ObtenerListaBodegaDestino" TypeName="ADMINPT.BL.CBODEGA"></asp:ObjectDataSource>

<asp:ObjectDataSource ID="odsZAFRA_ACTUAL" runat="server" SelectMethod="ObtenerListaActiva" TypeName="ADMINPT.BL.CZAFRA"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsZAFRA_PROD" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CZAFRA"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsDIA_ZAFRA" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CDIA_ZAFRA"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsTURNO" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CTURNO"></asp:ObjectDataSource>
<%--DETALLE--%>
<asp:ObjectDataSource ID="odsPRODUCTO" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CPRODUCTO"></asp:ObjectDataSource>

<asp:ObjectDataSource ID="odsCTIPO_CONCEPTO_PRODdt" runat="server" SelectMethod="ObtenerPorIdProducto" TypeName="ADMINPT.BL.CTIPO_CONCEPTO">
    <SelectParameters>
        <asp:Parameter Name="id" DefaultValue="-1" Type="Int32" />
        <asp:Parameter Name="ent" DefaultValue="1" Type="Int32" />
        <asp:Parameter Name="sali" DefaultValue="0" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<%--<asp:ObjectDataSource ID="odsCONCEPTO_MOVI" runat="server" SelectMethod="ObtenerPorId" TypeName="ADMINPT.BL.CCONCEPTO_MOVI">
    <SelectParameters>
        <asp:Parameter Name="id" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>--%>

<asp:ObjectDataSource ID="odsCONCEPTO_MOVI" runat="server" SelectMethod="ObtenerPorIdTM" TypeName="ADMINPT.BL.CCONCEPTO_MOVI">
    <SelectParameters>
        <asp:Parameter Name="id" DefaultValue="-1" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="odsESPECI_MOV" runat="server" SelectMethod="ObtenerPorIdTC" TypeName="ADMINPT.BL.CESPECI_MOV">
    <SelectParameters>
        <asp:Parameter Name="id" DefaultValue="-1" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="odsPRESENTACION_TRAS" runat="server" SelectMethod="ObtenerPorIdProducto" TypeName="ADMINPT.BL.CPRESENTACION_TRAS">
    <SelectParameters>
        <asp:Parameter Name="id" DefaultValue="-1" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsPRESENTACION_VTA" runat="server" SelectMethod="ObtenerPorIdProducto" TypeName="ADMINPT.BL.CPRESENTACION_VTA">
    <SelectParameters>
        <asp:Parameter Name="id" DefaultValue="-1" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsUNIDAD_MEDI_CONSAA" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CUNIDAD_MEDI_CONSAA"></asp:ObjectDataSource>
<%--<asp:ObjectDataSource ID="odsUNIDAD_MEDI_FAC" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CUNIDAD_MEDI_FAC"></asp:ObjectDataSource>--%>
<asp:ObjectDataSource ID="odsUNIDAD_MEDI_FAC" runat="server" SelectMethod="ObtenerPorIdProducto" TypeName="ADMINPT.BL.CUNIDAD_MEDI_FAC">
    <SelectParameters>
        <asp:Parameter Name="id" DefaultValue="-1" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsBodegaOUser" runat="server" SelectMethod="ObtenerListaBodegaOrigen" TypeName="ADMINPT.BL.CBODEGA">
    <SelectParameters>
         <asp:SessionParameter Name="ID_BODEP" SessionField="ID_BODEP" Type="Int32" />
        <asp:Parameter Name="ID_PRODUCTO" DefaultValue="-1" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsBodegaDUser" runat="server" SelectMethod="ObtenerListaBodegaDestino" TypeName="ADMINPT.BL.CBODEGA">
    <SelectParameters>
         <asp:SessionParameter Name="ID_BODEP" SessionField="ID_BODEP" Type="Int32" />
        <asp:Parameter Name="ID_PRODUCTO" DefaultValue="-1" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcVistaENTRADA_SALIDA_ENCA_VTADIZUCAR.ascx.cs" Inherits="ADMINPT.controles.movimento_vtadizucar.UcVistaENTRADA_SALIDA_ENCA_VTADIZUCAR" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/controles/movimento_vtadizucar/UcListaENTRADA_SALIDA_DETA_VTADIZUCAR.ascx" TagPrefix="uc1" TagName="UcListaENTRADA_SALIDA_DETA_VTADIZUCAR" %>


<script type="text/javascript">
    function OnKeyPress(s, e) {
        var theEvent = e.htmlEvent || window.event;
        var key = theEvent.keyCode || theEvent.which;
        var txt = s.GetText();
        if (key != 8 || key != 13) txt += String.fromCharCode(key);
        var regex = /^[0-9]*\.?[0-9]*$/;
        if (!regex.test(txt)) {
            theEvent.returnValue = false;
            if (theEvent.preventDefault) theEvent.preventDefault();
        }
    }
    function changedupper(s, e) {
        s.SetText(s.GetText().toUpperCase());
    }
    function Numericint(s, e) {
        var theEvent = e.htmlEvent || window.event;
        var key = theEvent.keyCode || theEvent.which;
        key = String.fromCharCode(key);
        var regex = /[0-9]/;
        if (!regex.test(key)) {
            theEvent.returnValue = false;
            if (theEvent.preventDefault)
                theEvent.preventDefault();
        }
    }
    function roundToTwo(num) {
        return +(Math.round(num + "e+2") + "e-2");
    }
    function OnInit(s, e) {
        if (s.cp_SUBTOTALSummary != null) {
            var valor = parseFloat(s.cp_SUBTOTALSummary);
            if (valor != 0) { speCantidad.SetValue(valor); }
            else { speCantidad.SetValue('');}
            delete (s.cp_SUBTOTALSummary);
        }
    }
    function OnEndCallback(s, e) {
        if (s.cp_SUBTOTALSummary != null) {
            var valor = parseFloat(s.cp_SUBTOTALSummary);
            if (valor != 0) { speCantidad.SetValue(valor); }
            else { speCantidad.SetValue(''); }
            delete (s.cp_SUBTOTALSummary);
        }
    }
</script>
<style type="text/css">
    .formLayout {
        max-width: 1300px;
        margin: auto;
    }
</style>
<dx:ASPxLabel ID="lbl_mensaje" runat="server" Text="" ForeColor="Red" Visible="false"></dx:ASPxLabel>
<dx:ASPxLabel ID="lbGuid" runat="server" Text="" ClientVisible="false"></dx:ASPxLabel>
<dx:ASPxFormLayout runat="server" ID="formLayout" CssClass="formLayout">
    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="700" />
    <Items>
        <dx:LayoutGroup Caption="Información del Movimiento" ColCount="3" GroupBoxDecoration="HeadingLine" UseDefaultPaddings="false" Paddings-PaddingTop="2">
            <Paddings PaddingTop="2px"></Paddings>

            <GroupBoxStyle>
                <Caption Font-Bold="true" Font-Size="10" />
            </GroupBoxStyle>
            <Items>
                <dx:LayoutItem Caption="Orden Traslado" ColumnSpan="2" ClientVisible="false">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxORDEN_GLOBAL_TRAS" runat="server" AutoPostBack="true" TextField="NUMREF" ValueField="ID_ORDEN_TRAS" ValueType="System.Int32" OnTextChanged="cbxORDEN_GLOBAL_TRAS_TextChanged">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Estado" ColumnSpan="3" HorizontalAlign="Right" ClientVisible="false">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxestado" runat="server" TextField="NOMBRE_ESTADO" ValueField="ID_ESTADO" ValueType="System.Int32" AutoPostBack="false" ClientEnabled="false">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField  IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Nº Sistema(id)">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txtIdentificador" runat="server" ClientEnabled="false">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Fecha">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxDateEdit ID="dteFecha" runat="server" EditFormat="Custom" EditFormatString="dd/MM/yyyy">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxDateEdit>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Nº Documento" CaptionStyle-Font-Bold="true">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txt_ndocument" runat="server" AutoCompleteType="Disabled">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">

                                </DisabledStyle>
                                <ClientSideEvents KeyPress="function(s,e){ Numericint(s,e);}" />
                                <ValidationSettings Display="Dynamic">
<RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Producto" ColumnSpan="3" Width="100%" CaptionStyle-Font-Bold="true">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxProducto"    Font-Bold ="true"  runat="server" TextField="NOMBRE_KARDEX" ValueField="ID_PRODUCTO" ValueType="System.Int32" AutoPostBack="true" OnTextChanged="cbxProducto_TextChanged" Width="100%">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                   <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Tipo Inventario">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <table>
                                <tr>
                                    <td>
                                        <dx:ASPxRadioButton ID="rb_propio" runat="server" Text="Propio" TextAlign="right" TextSpacing="1px" Checked="true" GroupName="tpi" ClientEnabled="false"  ></dx:ASPxRadioButton>
                                    </td>
                                    <td>
                                        <dx:ASPxRadioButton ID="rb_Ajeno" runat="server" Text="Ajeno" TextAlign="right" TextSpacing="1px" GroupName="tpi" ClientEnabled="false"></dx:ASPxRadioButton>
                                    </td>
                                </tr>
                            </table>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Presentación">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxPrestanciontras" runat="server" TextField="NOMBRE_PRESEN_TRAA" ClientEnabled="false"   ValueField="ID_PRESEN_TRAS" ValueType="System.Int32">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Unidad">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxUnidad" runat="server" TextField="NOMBRE_UNIDAD" ClientEnabled="false"   ValueField="ID_UNIDAD_FAC" ValueType="System.Int32">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Factor(qq/gal)" ClientVisible="false">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxSpinEdit ID="speFactor" ClientInstanceName="speFactor" runat="server" Number="0">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxSpinEdit>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Factor(kg)" ClientVisible="false">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxSpinEdit ID="speFactorKg" ClientInstanceName="speFactor" runat="server" Number="0">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                   <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxSpinEdit>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="" ClientVisible="false">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Zafra del producto">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxZafraProd" Font-Bold="true" ForeColor="Maroon"    runat="server" TextField="NOMBRE_ZAFRA" ValueField="ID_ZAFRA" ValueType="System.Int32" AutoPostBack="true" OnTextChanged="cbxZafraProd_TextChanged">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Maroon"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Zafra en curso">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxZafraActual" runat="server" TextField="NOMBRE_ZAFRA" ValueField="ID_ZAFRA" ValueType="System.Int32" ClientEnabled="false">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Tipo Movimiento">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxtipoMovimiento" runat="server" TextField="NOMBRE_MOV" ClientEnabled="false"   ValueField="ID_TIPO_MOV" ValueType="System.Int32" AutoPostBack="true" OnTextChanged="cbxtipoMovimiento_TextChanged">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Concepto">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxConceptoTM" runat="server" TextField="NOMBRE_CONCE" ClientEnabled="false"   ValueField="ID_CONCE" ValueType="System.Int32" AutoPostBack="true" OnTextChanged="cbxConceptoTM_TextChanged">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Especifico">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxEspecifico" runat="server" TextField="NOMBRE_ESPECI" ClientEnabled="false"   ValueField="ID_ESPECI" ValueType="System.Int32" AutoPostBack="true">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Bodega Origen" ColumnSpan="2" CaptionStyle-Font-Bold="true">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxBodegaOrigen" runat="server" TextField="NOMBRE" ClientEnabled="false"   ValueField="ID_BODEGA" ValueType="System.Int32" AutoPostBack="true" OnTextChanged="cbxBodegaOrigen_TextChanged">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                   <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Total General" CaptionStyle-Font-Bold="true">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>                          
                            <dx:ASPxSpinEdit ID="speCantidad" ClientInstanceName="speCantidad" runat="server" Number="" ReadOnly="true" HorizontalAlign="Right" OnValueChanged="speCantidad_ValueChanged" AutoPostBack="false"   AllowMouseWheel="false"  DisplayFormatString="N2">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                                  <SpinButtons ShowIncrementButtons="false"></SpinButtons>
                            </dx:ASPxSpinEdit>
                        <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Disponible  " ForeColor="Black" Font-Bold="true"  Visible="true"></dx:ASPxLabel>
                           <dx:ASPxLabel ID="lblSaldo" runat="server" Text="" ForeColor="Green" Font-Bold="true" ></dx:ASPxLabel>
                            <dx:ASPxLabel ID="lblPresentacion" runat="server" Text="" ForeColor="Green" Visible="false"></dx:ASPxLabel>   
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
            </Items>
        </dx:LayoutGroup>
        <dx:LayoutGroup Caption="Información Bodega Destino" ColCount="3" GroupBoxDecoration="HeadingLine" UseDefaultPaddings="false" Paddings-PaddingTop="2">
            <Paddings PaddingTop="2px"></Paddings>
            <GroupBoxStyle>
                <Caption Font-Bold="true" Font-Size="10" />
            </GroupBoxStyle>
            <Items>
                <dx:LayoutItem Caption="Bodega Destino" CaptionStyle-Font-Bold="true">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxBodegaDestino" runat="server" TextField="NOMBRE" ClientEnabled="false"  ValueField="ID_BODEGA" ValueType="System.Int32" AutoPostBack="true" OnTextChanged="cbxBodegaDestino_TextChanged">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Nit">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txtNit" runat="server" ClientEnabled="false">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Nrc">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txtNrc" runat="server" ClientEnabled="false">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Departamento">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txtDepartamento" runat="server" ClientEnabled="false">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Municipio">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txtMunicipio" runat="server" ClientEnabled="false">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Giro" ColumnSpan="3">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txtGiro" runat="server" ClientEnabled="false">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Dirección" ColumnSpan="3">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txtDireccion" runat="server" ClientEnabled="false">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Cliente" CaptionStyle-Font-Bold="true">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxCliente" runat="server" TextField="NOMBRE" ValueField="ID_CLIENTE" ValueType="System.Int32">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>

                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="N° CCF/FA" CaptionStyle-Font-Bold="true">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txtCcf" runat="server"  AutoCompleteType="Disabled">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                              <ClientSideEvents KeyPress="function(s,e){ Numericint(s,e);}" />
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Cantida" CaptionStyle-Font-Bold="true">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txtCantidaCliente" runat="server"  AutoCompleteType="Disabled">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                                <ClientSideEvents KeyPress="function(s,e){ OnKeyPress(s,e);}" />
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="" ShowCaption="False" ColumnSpan="3" HorizontalAlign="Right">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <table>
                                <tr>
                                    <td>
                                        <dx:ASPxLabel ID="lbMensajeAgregar" runat="server" Text="" ForeColor="Red" Visible="false"></dx:ASPxLabel>
                                    </td>
                                    <td>&nbsp;&nbsp;</td>
                                    <td>
                                        <dx:ASPxButton ID="btAgregarCliente" runat="server" Text="Agregar" OnClick="btAgregarCliente_Click" CausesValidation="false" ></dx:ASPxButton>
                                    </td>
                                </tr>
                            </table>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="" ShowCaption="False" ColumnSpan="3">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxGridView ID="ListViewCliente" runat="server" DataSourceID="Sds_ENTRADA_SALIDA_CLIENTE" AutoGenerateColumns="False" KeyFieldName="ID_ES_CLIENTE"
                                OnCellEditorInitialize="ListViewCliente_CellEditorInitialize" OnSummaryDisplayText="ListViewCliente_SummaryDisplayText" OnDataBound="ListViewCliente_DataBound">
                                <Columns>
                                    <dx:GridViewCommandColumn ShowDeleteButton="true" ShowEditButton="false" ShowInCustomizationForm="True" VisibleIndex="0">
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn FieldName="ID_ES_CLIENTE" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="1" Visible="false">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ID_ES_ENCA" ShowInCustomizationForm="True" VisibleIndex="2" Visible="false">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataDateColumn FieldName="FECHA" ShowInCustomizationForm="True" VisibleIndex="2" Visible="false">
                                    </dx:GridViewDataDateColumn>
                                    <dx:GridViewDataTextColumn FieldName="NUM_DOC" ShowInCustomizationForm="True" VisibleIndex="3" Visible="false">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ID_CLIENTE" ShowInCustomizationForm="True" VisibleIndex="4" Visible="false">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="NOMCLIENTE" Caption="Cliente" ShowInCustomizationForm="True" VisibleIndex="4">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="CCF_FA" Caption="N° CCF/FA" ShowInCustomizationForm="True" VisibleIndex="5">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="CANTIDAD" Caption="Cantida" ShowInCustomizationForm="True" VisibleIndex="6">
                                    </dx:GridViewDataTextColumn>

                                </Columns>
                                <ClientSideEvents EndCallback="OnEndCallback" Init="OnInit" />
                                <TotalSummary>
                                    <dx:ASPxSummaryItem FieldName="CANTIDAD" Visible="false" SummaryType="Sum" ShowInColumn="TOTAL" Tag="Total" ShowInGroupFooterColumn="true" DisplayFormat="$: {0}" />
                                </TotalSummary>
                                <SettingsBehavior ConfirmDelete="true" EnableCustomizationWindow="true" EnableRowHotTrack="true" />
                                <SettingsText ConfirmDelete="¿Estás seguro de que quieres eliminar?" />
                            </dx:ASPxGridView>
                            <asp:SqlDataSource ID="Sds_ENTRADA_SALIDA_CLIENTE" runat="server"
                                ConnectionString="<%$ ConnectionStrings:cn %>"
                                DeleteCommand="DEL_ENTRADA_SALIDA_CLIENTE" DeleteCommandType="StoredProcedure"
                                SelectCommand="SEL_ENTRADA_SALIDA_CLIENTE" SelectCommandType="StoredProcedure">
                                <DeleteParameters>
                                    <asp:Parameter Name="ID_ES_CLIENTE" Type="Int32" />                                   
                                </DeleteParameters>

                                <SelectParameters>
                                    <asp:ControlParameter ControlID="dteFecha" Name="FECHA" PropertyName="Text" Type="DateTime" />
                                    <asp:ControlParameter ControlID="txt_ndocument" Name="NUM_DOC" PropertyName="Text" Type="String" />
                                </SelectParameters>

                            </asp:SqlDataSource>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
            </Items>
        </dx:LayoutGroup>
        <dx:LayoutGroup Caption="Información de Transporte" ColCount="3" GroupBoxDecoration="HeadingLine" UseDefaultPaddings="false" Paddings-PaddingTop="10">
            <Paddings PaddingTop="10px"></Paddings>
            <GroupBoxStyle>
                <Caption Font-Bold="true" Font-Size="10" />
            </GroupBoxStyle>
            <Items>
                <dx:LayoutItem Caption="Proveedor" ColumnSpan="2" CaptionStyle-Font-Bold="true">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxProveedorTrans" runat="server" TextField="NOMBRE" ValueField="ID_PROV_TRAS" ValueType="System.Int32" Width="100%">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Transporte" CaptionStyle-Font-Bold="true">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxTransporte" runat="server" TextField="NOMBRE" ValueField="ID_TRANSPORTE" ValueType="System.Int32" Width="100%">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Motorista" CaptionStyle-Font-Bold="true">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txtMotoritsta" runat="server" ClientEnabled="true"  AutoCompleteType="Disabled">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                                <ClientSideEvents ValueChanged="changedupper" />
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Licencia" CaptionStyle-Font-Bold="true">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txtNitMotor" runat="server" ClientEnabled="true"  AutoCompleteType="Disabled">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                                <%--<MaskSettings Mask="0000-000000-000-0"  />--%>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                 <dx:LayoutItem Caption="Observación" ColumnSpan="3">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txtObservacion" Height ="30px" runat="server"  AutoCompleteType="Disabled">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
            </Items>
        </dx:LayoutGroup>
        <dx:LayoutGroup Caption="Lista de Productos" ClientVisible ="false"  ColCount="3" GroupBoxDecoration="HeadingLine" UseDefaultPaddings="false" Paddings-PaddingTop="2">
            <Paddings PaddingTop="2px"></Paddings>

            <GroupBoxStyle>
                <Caption Font-Bold="true" Font-Size="10" />
            </GroupBoxStyle>
            <Items>
               
                <dx:LayoutItem Caption="">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxButton ID="btnAgregarProductos" runat="server" Text="Agregar producto a la lista" Width="200px" OnClick="btnAgregarProductos_Click">
                                <Image IconID="actions_add_16x16">
                                </Image>
                            </dx:ASPxButton>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxButton ID="btnAgregarProductos0" runat="server" OnClick="btnAgregarProductos_Click" Text="Quitar producto de la lista" Width="200px">
                                <Image IconID="actions_cancel_16x16">
                                </Image>
                            </dx:ASPxButton>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                
                <dx:LayoutItem Caption="" ShowCaption="False" ColumnSpan="3">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <uc1:UcListaENTRADA_SALIDA_DETA_VTADIZUCAR runat="server" ID="UcListaENTRADA_SALIDA_DETA_VTADIZUCAR" />
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
            </Items>
        </dx:LayoutGroup>
    </Items>
</dx:ASPxFormLayout>

<%--ENCABEZADO--%>
<asp:ObjectDataSource ID="odsKARDEX_BODEGA" runat="server" SelectMethod="ObtenerPorIdBodega" TypeName="ADMINPT.BL.CKARDEX">
    <SelectParameters>
        <asp:Parameter Name="ID_PRODUCTO" DefaultValue="-1" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsPROVEEDOR_TRAS" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CPROVEEDOR_TRAS"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsTRANSPORTE" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CTRANSPORTE"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsESTADO_MOVIMIENTOS" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CESTADO_MOVIMIENTOS"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsORDEN_GLOBAL_TRAS" runat="server" SelectMethod="ObtenerListaCb" TypeName="ADMINPT.BL.CORDEN_GLOBAL_TRAS"> <SelectParameters> <asp:SessionParameter Name="ID_BODEP" SessionField="ID_BODEP" Type="Int32" /> </SelectParameters> </asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsBODEGAOrigen" runat="server" SelectMethod="ObtenerListaBodegaOrigen" TypeName="ADMINPT.BL.CBODEGA"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsTIPO_MOVIMIENTO" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CTIPO_MOVIMIENTO"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsBODEGADestino" runat="server" SelectMethod="ObtenerPorIdBodega" TypeName="ADMINPT.BL.CKARDEX">
    <SelectParameters>
        <asp:Parameter Name="ID_PRODUCTO" DefaultValue="-1" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="odsZAFRA_ACTUAL" runat="server" SelectMethod="ObtenerListaActiva" TypeName="ADMINPT.BL.CZAFRA"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsZAFRA_PROD" runat="server" SelectMethod="ObtenerListaProductActiva" TypeName="ADMINPT.BL.CZAFRA">
    <SelectParameters>
        <asp:Parameter Name="ID_PRODUCTO" DefaultValue="-1" Type="Int32" />
         <asp:Parameter Name="TIPO" DefaultValue="V" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsDIA_ZAFRA" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CDIA_ZAFRA"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsTURNO" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CTURNO"></asp:ObjectDataSource>


<asp:ObjectDataSource ID="odsCLIENTE" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CCLIENTE"></asp:ObjectDataSource>


<%--DETALLE--%>
<asp:ObjectDataSource ID="odsPRODUCTO" runat="server" SelectMethod="ObtenerListaVtaDizucar" TypeName="ADMINPT.BL.CPRODUCTO"></asp:ObjectDataSource>

<asp:ObjectDataSource ID="odsCTIPO_CONCEPTO_PRODdt" runat="server" SelectMethod="ObtenerPorIdProducto" TypeName="ADMINPT.BL.CTIPO_CONCEPTO">
    <SelectParameters>
        <asp:Parameter Name="id" DefaultValue="-1" Type="Int32" />
        <asp:Parameter Name="ent" DefaultValue="1" Type="Int32" />
        <asp:Parameter Name="sali" DefaultValue="0" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>


<asp:ObjectDataSource ID="odsCONCEPTO_MOVI" runat="server" SelectMethod="ObtenerPorIdTMVzaDizucar" TypeName="ADMINPT.BL.CCONCEPTO_MOVI">
    <SelectParameters>
        <asp:Parameter Name="ID_PRODUCTO" DefaultValue="-1" Type="Int32" />
        <asp:Parameter Name="ID_TIPO_MOV" DefaultValue="-1" Type="Int32" />
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
<asp:ObjectDataSource ID="odsUNIDAD_MEDI_FAC" runat="server" SelectMethod="ObtenerPorIdProducto" TypeName="ADMINPT.BL.CUNIDAD_MEDI_FAC">
    <SelectParameters>
        <asp:Parameter Name="id" DefaultValue="-1" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsBodegaOUser" runat="server" SelectMethod="ObtenerListaBodegaOrigen" TypeName="ADMINPT.BL.CBODEGA">
    <SelectParameters>
         <%--<asp:SessionParameter Name="ID_BODEP" SessionField="ID_BODEP" Type="Int32" />--%>
        <asp:SessionParameter Name="ID_BODEP" SessionField="ID_BODEP" Type="Int32" />
        <asp:Parameter Name="ID_PRODUCTO" DefaultValue="-1" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsBodegaDUser" runat="server" SelectMethod="ObtenerListaBodegaDestino" TypeName="ADMINPT.BL.CBODEGA">
    <SelectParameters>
         <%--<asp:SessionParameter Name="ID_BODEP" SessionField="ID_BODEP" Type="Int32" />--%>
        <asp:SessionParameter Name="ID_BODEP" SessionField="ID_BODEP" Type="Int32" />
        <asp:Parameter Name="ID_PRODUCTO" DefaultValue="-1" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
 <dx:ASPxLoadingPanel ID="ldnPanel" runat="server" Text="Procesando Datos..." ClientInstanceName="ldnPanel" Theme="MaterialCompact" 
        Modal="True">
    </dx:ASPxLoadingPanel>
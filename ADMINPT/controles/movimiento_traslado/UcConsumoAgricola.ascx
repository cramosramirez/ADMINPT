<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcConsumoAgricola.ascx.cs" Inherits="ADMINPT.controles.movimiento_traslado.UcConsumoAgricola" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/controles/movimiento_traslado/UcListaENTRADA_SALIDA_DETA_TRASLADO.ascx" TagPrefix="uc1" TagName="UcListaENTRADA_SALIDA_DETA_TRASLADO" %>

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
          <dx:LayoutGroup Caption="Control de Saldo" Name="Saldo" ClientVisible="false"  ColCount="3" GroupBoxDecoration="Box" UseDefaultPaddings="false" Paddings-PaddingTop="2">
            <GroupBoxStyle>
                <Caption Font-Bold="true" Font-Size="10" />
            </GroupBoxStyle>
            <Items>
               <dx:LayoutItem Caption="Asignacion Total">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                       <dx:ASPxSpinEdit ID="txtAsignacionT" ClientInstanceName="txtAsignacionT" runat="server" Number="0" ClientEnabled="false">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                            <ValidationSettings Display="Dynamic">
                                                <RequiredField IsRequired="True" ErrorText="Cantidad" />
                                            </ValidationSettings>
                                        </dx:ASPxSpinEdit>
                         </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Ejecutado">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                       <dx:ASPxSpinEdit ID="txtEjecutado" ClientInstanceName="txtEjecutado" runat="server" Number="0" ClientEnabled="false">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                            <ValidationSettings Display="Dynamic">
                                                <RequiredField IsRequired="True" ErrorText="Cantidad" />
                                            </ValidationSettings>
                                        </dx:ASPxSpinEdit>
                         </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Saldo">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                       <dx:ASPxSpinEdit ID="txtSaldo" ClientInstanceName="txtSaldo" runat="server" Number="0" ClientEnabled="false">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                            <ValidationSettings Display="Dynamic">
                                                <RequiredField IsRequired="True" ErrorText="Cantidad" />
                                            </ValidationSettings>
                                        </dx:ASPxSpinEdit>
                         </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
            </Items>
        </dx:LayoutGroup>
        <dx:LayoutGroup Caption="Información del Movimiento" ColCount="3" GroupBoxDecoration="HeadingLine" UseDefaultPaddings="false" Paddings-PaddingTop="2">
            <GroupBoxStyle>
                <Caption Font-Bold="true" Font-Size="10" />
            </GroupBoxStyle>
            <Items>
                <dx:LayoutItem Caption="Orden Global Traslado" ColumnSpan="2" ClientVisible="false" CaptionStyle-Font-Bold="true" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxORDEN_GLOBAL_TRAS" runat="server" AutoPostBack="true" TextField="NOMBREDT" ValueField="ID_ORDEN_TRAS" ValueType="System.Int32" OnTextChanged="cbxORDEN_GLOBAL_TRAS_TextChanged" Border-BorderColor="#20c997">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ClearButton DisplayMode="Always"></ClearButton>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Estado" ClientVisible="false">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxestado" runat="server" TextField="NOMBRE_ESTADO" ValueField="ID_ESTADO" ValueType="System.Int32" AutoPostBack="false" ClientEnabled="false">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
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
                            <dx:ASPxDateEdit ID="dteFecha" runat="server" EditFormat="Custom" EditFormatString="dd/MM/yyyy" ClientEnabled="false">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxDateEdit>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Nº Documento" CaptionStyle-Font-Bold="true" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txt_ndocument" runat="server" AutoCompleteType="Disabled"   >
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
                <dx:LayoutItem Caption="Producto" ColumnSpan="3" Width="100%" CaptionStyle-Font-Bold="true" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxProducto"  Font-Bold ="true"   runat="server" TextField="NOMBRE_KARDEX" ValueField="ID_PRODUCTO" ValueType="System.Int32" AutoPostBack="true" OnTextChanged="cbxProducto_TextChanged"   >
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
                                        <dx:ASPxRadioButton ID="rb_propio" runat="server" Text="Propio" TextAlign="right" TextSpacing="1px" Checked="true" GroupName="tpi"></dx:ASPxRadioButton>
                                    </td><td>&nbsp; &nbsp; <td>
                                    <td>
                                        <dx:ASPxRadioButton ID="rb_Ajeno" runat="server" Text="Ajeno" TextAlign="right" TextSpacing="1px" GroupName="tpi"></dx:ASPxRadioButton>
                                    </td>
                                </tr>
                            </table>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Presentación">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxPrestanciontras" runat="server" TextField="NOMBRE_PRESEN_TRAA" ValueField="ID_PRESEN_TRAS" ValueType="System.Int32">
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
                            <dx:ASPxComboBox ID="cbxUnidad" runat="server" TextField="NOMBRE_UNIDAD" ValueField="ID_UNIDAD_FAC" ValueType="System.Int32">
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
                                <SpinButtons ShowIncrementButtons="false"></SpinButtons>
                            </dx:ASPxSpinEdit>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Factor(kg)"  ClientVisible="false">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxSpinEdit ID="speFactorKg" ClientInstanceName="speFactor" runat="server" Number="0">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                                <SpinButtons ShowIncrementButtons="false"></SpinButtons>
                            </dx:ASPxSpinEdit>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption=""  ClientVisible="false">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Zafra del producto">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxZafraProd" Font-Bold="true" ForeColor="Maroon"  runat="server" TextField="NOMBRE_ZAFRA" ValueField="ID_ZAFRA" ValueType="System.Int32" AutoPostBack="true" OnTextChanged="cbxZafraProd_TextChanged">
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
                            <dx:ASPxComboBox ID="cbxtipoMovimiento" runat="server" TextField="NOMBRE_MOV" ValueField="ID_TIPO_MOV" ValueType="System.Int32" AutoPostBack="true" OnTextChanged="cbxtipoMovimiento_TextChanged">
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
                            <dx:ASPxComboBox ID="cbxConceptoTM" runat="server" TextField="NOMBRE_CONCE" ValueField="ID_CONCE" ValueType="System.Int32" AutoPostBack="true" OnTextChanged="cbxConceptoTM_TextChanged">
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
                            <dx:ASPxComboBox ID="cbxEspecifico" runat="server" TextField="NOMBRE_ESPECI" ValueField="ID_ESPECI" ValueType="System.Int32" AutoPostBack="true">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                   <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Bodega Origen" ColumnSpan="2" CaptionStyle-Font-Bold="true" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxBodegaOrigen" runat="server" TextField="NOMBRE" ValueField="ID_BODEGA" ValueType="System.Int32" AutoPostBack="true" OnTextChanged="cbxBodegaOrigen_TextChanged"   >
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                   <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Cantidad" CaptionStyle-Font-Bold="true" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                             <dx:ASPxSpinEdit ID="speCantidad" ClientInstanceName="speCantidad" runat="server" Number="" DecimalPlaces="2" AllowMouseWheel="false" ReadOnly="false" OnValueChanged="speCantidad_ValueChanged" AutoPostBack="false" DisplayFormatString="N2"   >
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
        <dx:LayoutGroup Caption="Información Bodega Destino" ColCount="4" GroupBoxDecoration="HeadingLine" UseDefaultPaddings="false" Paddings-PaddingTop="2">
            <GroupBoxStyle>
                <Caption Font-Bold="true" Font-Size="10" />
            </GroupBoxStyle>
            <Items>
                <dx:LayoutItem Caption="Bodega Destino" ColumnSpan="2" CaptionStyle-Font-Bold="true" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxBodegaDestino" runat="server" TextField="NOMBRE" ValueField="ID_BODEGA" ValueType="System.Int32" AutoPostBack="true" OnTextChanged="cbxBodegaDestino_TextChanged"   >
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="N° Formulario" CaptionStyle-Font-Bold="true" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txtNFormulario" runat="server" AutoCompleteType="Disabled"   >
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                                <ClientSideEvents KeyPress="function(s,e){ Numericint(s,e);}" />
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Nit">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txtNit" runat="server" ClientEnabled="false">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                                <ClientSideEvents KeyPress="function(s,e){ Numericint(s,e);}" />
                               
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
                                <ClientSideEvents KeyPress="function(s,e){ Numericint(s,e);}" />
                               
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
                                <ClientSideEvents ValueChanged="changedupper" />
                               
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
                                <ClientSideEvents ValueChanged="changedupper" />
                                
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Giro" ColumnSpan="2">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txtGiro" runat="server" ClientEnabled="false">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                                <ClientSideEvents ValueChanged="changedupper" />
                               
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Dirección" ColumnSpan="2">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txtDireccion" runat="server" ClientEnabled="false">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                                <ClientSideEvents ValueChanged="changedupper" />
                                
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
            </Items>
        </dx:LayoutGroup>
        <dx:LayoutGroup Caption="Información de Transporte" ColCount="3" GroupBoxDecoration="HeadingLine" UseDefaultPaddings="false" Paddings-PaddingTop="10">
            <GroupBoxStyle>
                <Caption Font-Bold="true" Font-Size="10" />
            </GroupBoxStyle>
            <Items>
                <dx:LayoutItem Caption="Proveedor" ColumnSpan="2" CaptionStyle-Font-Bold="true" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxProveedorTrans" runat="server" TextField="NOMBRE" ValueField="ID_PROV_TRAS" ValueType="System.Int32" Width="100%"   >
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Transporte" CaptionStyle-Font-Bold="true" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxTransporte" runat="server" TextField="NOMBRE" ValueField="ID_TRANSPORTE" ValueType="System.Int32" Width="100%"   >
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Motorista" CaptionStyle-Font-Bold="true" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txtMotoritsta" runat="server" ClientEnabled="true" AutoCompleteType="Disabled"   >
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
                <dx:LayoutItem Caption="Licencia" CaptionStyle-Font-Bold="true" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txtNitMotor" runat="server" ClientEnabled="true" AutoCompleteType="Disabled"  >
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
                            <dx:ASPxTextBox ID="txtObservacion" Height="30px" runat="server">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                                <ClientSideEvents ValueChanged="changedupper" />
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
            </Items>
        </dx:LayoutGroup>
        <dx:LayoutGroup Caption="Lista de Productos" ClientVisible="false"  ColCount="3" GroupBoxDecoration="HeadingLine" UseDefaultPaddings="false" Paddings-PaddingTop="2">
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
                            <uc1:UcListaENTRADA_SALIDA_DETA_TRASLADO runat="server" ID="UcListaENTRADA_SALIDA_DETA_TRASLADO" />
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
<%--DETALLE--%>
<asp:ObjectDataSource ID="odsPRODUCTO" runat="server" SelectMethod="ObtenerListaConsumo" TypeName="ADMINPT.BL.CPRODUCTO"></asp:ObjectDataSource>

<asp:ObjectDataSource ID="odsCTIPO_CONCEPTO_PRODdt" runat="server" SelectMethod="ObtenerPorIdProducto" TypeName="ADMINPT.BL.CTIPO_CONCEPTO">
    <SelectParameters>
        <asp:Parameter Name="id" DefaultValue="-1" Type="Int32" />
        <asp:Parameter Name="ent" DefaultValue="1" Type="Int32" />
        <asp:Parameter Name="sali" DefaultValue="0" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>


<asp:ObjectDataSource ID="odsCONCEPTO_MOVI" runat="server" SelectMethod="ObtenerPorIdTMConsumo" TypeName="ADMINPT.BL.CCONCEPTO_MOVI">
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
<asp:ObjectDataSource ID="odsNDoc" runat="server" SelectMethod="ObtenerNDoc" TypeName="ADMINPT.BL.CENTRADA_SALIDA_ENCA">
    <SelectParameters>
        <asp:Parameter Name="id" DefaultValue="1" Type="Int32" />
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
 <dx:ASPxLoadingPanel ID="ldnPanel" runat="server" Text="Procesando Datos..." ClientInstanceName="ldnPanel" Theme="MaterialCompact" 
        Modal="True">
    </dx:ASPxLoadingPanel>
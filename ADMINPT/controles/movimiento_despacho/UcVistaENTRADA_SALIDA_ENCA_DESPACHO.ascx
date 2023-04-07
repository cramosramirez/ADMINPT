<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcVistaENTRADA_SALIDA_ENCA_DESPACHO.ascx.cs" Inherits="ADMINPT.controles.movimiento_despacho.UcVistaENTRADA_SALIDA_ENCA_DESPACHO" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/controles/movimiento_despacho/UcListaENTRADA_SALIDA_DETA_DESPACHO.ascx" TagPrefix="uc1" TagName="UcListaENTRADA_SALIDA_DETA_DESPACHO" %>
<%@ Register Src="~/controles/movimiento_despacho/UcListaENTRADA_SALIDA_DETA_VTJIBOAEMP.ascx" TagPrefix="uc1" TagName="UcListaENTRADA_SALIDA_DETA_VTJIBOAEMP" %>


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
        //if (s.cp_SUBTOTALSummary != null) {
        //    var valor = parseFloat(s.cp_SUBTOTALSummary);
        //    speCantidad.SetText(valor);
        //    delete (s.cp_SUBTOTALSummary);
        //}
    }
    function OnEndCallback(s, e) {
        //if (s.cp_SUBTOTALSummary != null) {
        //    var valor = parseFloat(s.cp_SUBTOTALSummary);
        //    speCantidad.SetText(valor);
        //    delete (s.cp_SUBTOTALSummary);
        //}
    }
</script>
<script type="text/javascript">
    function OnSelectedIndexChanged(s, e) {
        var items = listbox.GetSelectedItems();
        var text = "";
        var values = "";
        for (var i = 0; i < items.length; i++) {
            
            text += items[i].text + ";";
            values += items[i].value + ";";
        }
        cbxEstiba.SetText(text)
        cbxEstiba.SetKeyValue(values);
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
        <dx:LayoutGroup Caption="Buscar Documento por Codigo De Barras / N° (NR / CCF/ FA)" ClientVisible="true"  ColCount="3" GroupBoxDecoration="HeadingLine" UseDefaultPaddings="false" Paddings-PaddingTop="2">
            <Paddings PaddingTop="2px"></Paddings>
            <GroupBoxStyle>
                <Caption Font-Bold="true" Font-Size="10" />
            </GroupBoxStyle>
            <Items>  
                <dx:LayoutItem Caption="Bodega Origen" ColumnSpan="2" CaptionStyle-Font-Bold="false" ClientVisible="true">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                             <dx:ASPxComboBox ID="cb_bodegaO" ClientInstanceName="cb_bodegaO" runat="server" Enabled="false" DataSourceID="SdsListBgasOrigen" ValueField="ID_BODEGA" TextField="NOMBRE" 
                                        ValueType="System.Int32" AutoPostBack="true" DropDownStyle="DropDownList" TextFormatString="{0}" IncrementalFilteringMode="Contains">
                                      <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithText" ErrorText="requerido!!!" ErrorTextPosition="Right">
                                            <RequiredField ErrorText="requerido!!!" IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                             <asp:SqlDataSource ID="SdsListBgasOrigen" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>" SelectCommand="CB_BODEGAS_ORIGEN" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionStyle Font-Bold="True"></CaptionStyle>
                </dx:LayoutItem>
                   <dx:LayoutItem Caption="Fecha Decpacho" CaptionStyle-Font-Bold="true">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxDateEdit ID="txtFechaDespacho" runat="server" EditFormat="Custom" EditFormatString="dd/MM/yyyy" >
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxDateEdit>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Codigo de Barras" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txt_CodCaptura" runat="server" ClientEnabled="true" OnTextChanged="txt_CodCaptura_TextChanged"  Width="100%" AutoPostBack="true">
<DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                 </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                 <dx:LayoutItem Caption="N° (NR / CCF/ FA):" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txt_ndocbuscar" runat="server" ClientEnabled="true" OnTextChanged="txt_ndocbuscar_TextChanged"  Width="100%" AutoPostBack="true">
<DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                           </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
              
                </Items>
        </dx:LayoutGroup>
                <dx:LayoutGroup Caption="Información Complementaria" ClientVisible="true"  ColCount="3" GroupBoxDecoration="HeadingLine" UseDefaultPaddings="false" Paddings-PaddingTop="2">
            <Paddings PaddingTop="2px"></Paddings>
            <GroupBoxStyle>
                <Caption Font-Bold="true" Font-Size="10" />
            </GroupBoxStyle>
            <Items> 
                 <dx:LayoutItem Caption="¿Completar?" CaptionStyle-ForeColor="Red" CaptionStyle-Font-Bold="true">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <table>
                                <tr>
                                    <td>
                                        <dx:ASPxRadioButton ID="rdbinfs" runat="server" Text="Si" TextAlign="right" TextSpacing="1px" Checked="true" GroupName="inf" ClientEnabled="true"></dx:ASPxRadioButton>
                                    </td>
                                    <td> &nbsp; &nbsp; &nbsp; </td>
                                    <td>
                                        <dx:ASPxRadioButton ID="rdbinfn" runat="server" Text="No" TextAlign="right"  Checked="false" TextSpacing="1px" GroupName="inf" ClientEnabled="true" OnCheckedChanged="rdbinfn_CheckedChanged" AutoPostBack="true"></dx:ASPxRadioButton>
                                    </td>
                                </tr>
                            </table>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Estiba">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                              
                             <asp:SqlDataSource ID="SdsListEstiba" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>" SelectCommand="CB_ESTIBA" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
           
                            <dx:ASPxDropDownEdit ID="cbxEstiba" runat="server" ClientInstanceName="cbxEstiba" Width="100%" >
            <DropDownWindowTemplate>
                <dx:ASPxListBox ID="ASPxListBox1" runat="server"  ClientInstanceName="listbox" Width="90%"
                    DataSourceID="SdsListEstiba" SelectionMode="CheckColumn"
                    ValueField="ID_ESTIBA" TextField="NOMBRE"
                    ValueType="System.Int32">
                    <ClientSideEvents SelectedIndexChanged="OnSelectedIndexChanged" />
                </dx:ASPxListBox>
            </DropDownWindowTemplate>
        </dx:ASPxDropDownEdit>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                 <dx:LayoutItem Caption="Tendido">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                             <dx:ASPxTextBox ID="txt_tendido" runat="server" ClientEnabled="true" >
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                        </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>                 
                 <dx:LayoutItem Caption="Color">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                             <dx:ASPxTextBox ID="txt_color" runat="server" ClientEnabled="true" >
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                        </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Fecha Certificado 1">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxDateEdit ID="txt_fechaProduccion" runat="server" EditFormat="Custom" EditFormatString="dd/MM/yyyy" >
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                               
                            </dx:ASPxDateEdit>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Fecha Certificado 2">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxDateEdit ID="txt_fechaProduccion2" runat="server" EditFormat="Custom" EditFormatString="dd/MM/yyyy" >
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                
                            </dx:ASPxDateEdit>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                 <dx:LayoutItem Caption=""  >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                 <dx:LayoutItem Caption="Observación" ColumnSpan="3">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txtObservacion" Height ="30px" runat="server" ClientEnabled="true">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                            </dx:ASPxTextBox>
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
                <dx:LayoutItem Caption="Orden Traslado" ColumnSpan="2">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxORDEN_GLOBAL_TRAS" runat="server" AutoPostBack="true" ClientEnabled="false"
                                TextField="NUMREF" ValueField="ID_ORDEN_TRAS" ValueType="System.Int32" OnTextChanged="cbxORDEN_GLOBAL_TRAS_TextChanged">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Estado">
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
                <dx:LayoutItem Caption="Nº Documento">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txt_ndocument" runat="server" ClientEnabled="false">
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
                <dx:LayoutItem Caption="Producto" ColumnSpan="3" Width="100%"  ClientVisible="false">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxProducto"  Font-Bold ="true"   runat="server" TextField="NOMBRE_KARDEX" ValueField="ID_PRODUCTO" ValueType="System.Int32" AutoPostBack="true" OnTextChanged="cbxProducto_TextChanged" Width="100%" ClientEnabled="false">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="¿Zafra correcta?" CaptionStyle-ForeColor="Red" CaptionStyle-Font-Bold="true">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <table>
                                <tr>
                                    <td>
                                        <dx:ASPxRadioButton ID="rdbzfcs" runat="server" Text="Si" TextAlign="right" TextSpacing="1px" Checked="false" GroupName="zfc" ClientEnabled="true"></dx:ASPxRadioButton>
                                    </td>
                                    <td> &nbsp; &nbsp; &nbsp; </td>
                                    <td>
                                        <dx:ASPxRadioButton ID="rdbzfcn" runat="server" Text="No" TextAlign="right"  Checked="false" TextSpacing="1px" GroupName="zfc" ClientEnabled="true" OnCheckedChanged="rdbzfcn_CheckedChanged" AutoPostBack="true"></dx:ASPxRadioButton>
                                    </td>
                                </tr>
                            </table>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Tipo Inventario">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <table>
                                <tr>
                                    <td>
                                        <dx:ASPxRadioButton ID="rb_propio" runat="server" Text="Propio" TextAlign="right" TextSpacing="1px" Checked="true" GroupName="tpi" ClientEnabled="false"></dx:ASPxRadioButton>
                                    </td>
                                    <td>
                                        <dx:ASPxRadioButton ID="rb_Ajeno" runat="server" Text="Ajeno" TextAlign="right" TextSpacing="1px" GroupName="tpi" ClientEnabled="false"></dx:ASPxRadioButton>
                                    </td>
                                </tr>
                            </table>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption=""  >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Presentación"  ClientVisible="false">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxPrestanciontras" runat="server" TextField="NOMBRE_PRESEN_TRAA" ValueField="ID_PRESEN_TRAS" ValueType="System.Int32" ClientEnabled="false">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Unidad"  ClientVisible="false">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxUnidad" runat="server" TextField="NOMBRE_UNIDAD" ValueField="ID_UNIDAD_FAC" ValueType="System.Int32" ClientEnabled="false">
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
                            <dx:ASPxSpinEdit ID="speFactor" ClientInstanceName="speFactor" runat="server" Number="0" ClientEnabled="false">
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
                            <dx:ASPxSpinEdit ID="speFactorKg" ClientInstanceName="speFactor" runat="server" Number="0" ClientEnabled="false">
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
                            <dx:ASPxComboBox ID="cbxZafraProd" Font-Bold="true" ForeColor="Maroon"  runat="server" TextField="NOMBRE_ZAFRA" ValueField="ID_ZAFRA" ValueType="System.Int32" AutoPostBack="false" OnTextChanged="cbxZafraProd_TextChanged" ClientEnabled="false">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
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
                            <dx:ASPxComboBox ID="cbxtipoMovimiento" runat="server" TextField="NOMBRE_MOV" ValueField="ID_TIPO_MOV" ValueType="System.Int32" AutoPostBack="true" OnTextChanged="cbxtipoMovimiento_TextChanged" ClientEnabled="false">
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
                            <dx:ASPxComboBox ID="cbxConceptoTM" runat="server" TextField="NOMBRE_CONCE" ValueField="ID_CONCE" ValueType="System.Int32" AutoPostBack="true" OnTextChanged="cbxConceptoTM_TextChanged" ClientEnabled="false">
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
                            <dx:ASPxComboBox ID="cbxEspecifico" runat="server" TextField="NOMBRE_ESPECI" ValueField="ID_ESPECI" ValueType="System.Int32" AutoPostBack="true" ClientEnabled="false">
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
                            <dx:ASPxComboBox ID="cbxBodegaOrigen" runat="server" TextField="NOMBRE" ValueField="ID_BODEGA" ValueType="System.Int32" AutoPostBack="false" OnTextChanged="cbxBodegaOrigen_TextChanged" ClientEnabled="false">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Total Genaral" CaptionStyle-Font-Bold="true">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxSpinEdit ID="speCantidad" ClientInstanceName="speCantidad" runat="server" Number="" DecimalPlaces="2" ReadOnly="false" HorizontalAlign="Right" OnValueChanged="speCantidad_ValueChanged" AutoPostBack="true" ClientEnabled="false"  DisplayFormatString="N2">
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
          <dx:LayoutGroup Caption="Lista de Productos" ClientVisible="true"  ColCount="3" GroupBoxDecoration="HeadingLine" UseDefaultPaddings="false" Paddings-PaddingTop="2">
            <Paddings PaddingTop="2px"></Paddings>
            <GroupBoxStyle>
                <Caption Font-Bold="true" Font-Size="10" />
            </GroupBoxStyle>
            <Items>
                <dx:LayoutItem Caption="" ShowCaption="False" ColumnSpan="3">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                           <dx:ASPxGridView ID="gridListaup" runat="server" Theme="Moderno" KeyFieldName="ID_ES_DETA" AutoGenerateColumns="False"
    DataSourceID="Sds_lista" Width="100%" OnCustomUnboundColumnData="gridListaup_CustomUnboundColumnData" ClientVisible="false">
    <SettingsPager>
        <Summary AllPagesText="Pags: {0} - {1} ({2} registros)" 
            Text="Pag. {0} de {1} ({2} registros)" />
    </SettingsPager>
                                <SettingsCommandButton>
                                    <NewButton RenderMode="Image" Text="Nuevo">
                                        <Image IconID="miscellaneous_wizard_16x16"></Image>
                                    </NewButton>
                                    <EditButton RenderMode="Image" Text="Editar">
                                        <Image IconID="edit_edit_16x16"></Image>
                                    </EditButton>
                                    <DeleteButton RenderMode="Image" Text="Eliminar">
                                        <Image IconID="actions_cancel_16x16"></Image>
                                    </DeleteButton>
                                    <UpdateButton RenderMode="Image" Text="Guardar">
                                        <Image IconID="save_save_32x32"></Image>
                                    </UpdateButton>
                                    <CancelButton RenderMode="Image" Text="Cancelar">
                                        <Image IconID="history_undo_32x32"></Image>
                                    </CancelButton>
                                </SettingsCommandButton>
    <Columns>
        <dx:GridViewCommandColumn Caption="Editar" ShowEditButton="True" VisibleIndex="0" CellStyle-HorizontalAlign="Center" Width="40px" >            
        </dx:GridViewCommandColumn>
        <dx:GridViewDataTextColumn FieldName="ID_ES_DETA" ReadOnly="True" VisibleIndex="1" Visible="false">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="ID_ES_ENCA" VisibleIndex="2" Visible="false">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataDateColumn FieldName="FECHA" VisibleIndex="3" Visible="false">
        </dx:GridViewDataDateColumn>
        <dx:GridViewDataTextColumn FieldName="NUM_DOC" VisibleIndex="4" Visible="false">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="ID_PRODUCTO" VisibleIndex="5" Visible="false">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="NOMBRE_PRODUCTO" VisibleIndex="5" Caption="Producto" UnboundType="String" />
        <dx:GridViewDataTextColumn FieldName="ID_PRESEN_TRAS" VisibleIndex="6" Visible="false">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="NOMBRE_PRESEN_TRAA" VisibleIndex="6" Caption="Presentación" UnboundType="String" Visible="true" />  
        <dx:GridViewDataTextColumn FieldName="ID_UNIDAD_FAC" VisibleIndex="7" Visible="false">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="NOMBRE_UNIDAD" VisibleIndex="7" Caption="Unidad" UnboundType="String" Visible="true" />  
        <dx:GridViewDataTextColumn FieldName="CANTIDAD" VisibleIndex="8" Caption="Cantidad">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="FACTOR" VisibleIndex="9" Visible="false">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="REFERENCIA_DETA" VisibleIndex="10" Visible="false">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="USUARIO_CREA" VisibleIndex="11" Visible="false">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataDateColumn FieldName="FECHA_CREA" VisibleIndex="12" Visible="false">
        </dx:GridViewDataDateColumn>
        <dx:GridViewDataTextColumn FieldName="USUARIO_ACT" VisibleIndex="13" Visible="false">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataDateColumn FieldName="FECHA_ACT" VisibleIndex="14" Visible="false">
        </dx:GridViewDataDateColumn>
        <dx:GridViewDataTextColumn FieldName="FACTORKG" VisibleIndex="15" Visible="false">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="QUINTALES" VisibleIndex="16" Visible="false">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="KILOGRAMOS" VisibleIndex="17" Visible="false">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="GALONES" VisibleIndex="18" Visible="false">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="ID_BODEP" VisibleIndex="19" Visible="false">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="CANTIDA_RGTRASLADO" VisibleIndex="20" Visible="false">
        </dx:GridViewDataTextColumn>
    </Columns>
    <SettingsBehavior ConfirmDelete="true" EnableCustomizationWindow="true" EnableRowHotTrack="true" />
                                <SettingsText ConfirmDelete="¿Estás seguro de que quieres eliminar?" />
</dx:ASPxGridView>
<asp:SqlDataSource ID="Sds_lista" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>" 
    SelectCommand="SEL_ENTRADA_SALIDA_DETA" SelectCommandType="StoredProcedure"
    UpdateCommand="UPD_ENTRADA_SALIDA_DETA_CANT" UpdateCommandType="StoredProcedure">
    <SelectParameters>
        <asp:Parameter Name="ID_ES_ENCA" Type="Int32" />
    </SelectParameters>
    <UpdateParameters>
        <asp:Parameter Name="ID_ES_DETA" Type="Int32" />
        <asp:Parameter Name="ID_ES_ENCA" Type="Int32" />
        <asp:Parameter Name="CANTIDAD" Type="Decimal" />
    </UpdateParameters>
</asp:SqlDataSource>
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
                <dx:LayoutItem Caption="Bodega Destino">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxBodegaDestino" runat="server" TextField="NOMBRE"  ClientEnabled="false"
                                ValueField="ID_BODEGA" ValueType="System.Int32" AutoPostBack="true" OnTextChanged="cbxBodegaDestino_TextChanged">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Bodega Destino" />
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
                <dx:LayoutItem Caption="Cliente" Name="cdizucar" ClientVisible="false" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxCliente" runat="server" TextField="NOMBRE" ValueField="ID_CLIENTE" ValueType="System.Int32"  ClientEnabled="false">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>

                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="N° CCF/FA" Name="ccfdizucar" ClientVisible="false">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txtCcf" runat="server"  ClientEnabled="false">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                              <ClientSideEvents KeyPress="function(s,e){ Numericint(s,e);}" />
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Cantida" Name="cantdizucar" ClientVisible="false">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txtCantidaCliente" runat="server"  ClientEnabled="false">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                                <ClientSideEvents KeyPress="function(s,e){ OnKeyPress(s,e);}" />
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="" Name="opdizucar"  ShowCaption="False" ColumnSpan="3" HorizontalAlign="Right" ClientVisible="false">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <table>
                                <tr>
                                    <td>
                                        <dx:ASPxLabel ID="lbMensajeAgregar" runat="server" Text="" ForeColor="Red" Visible="false"></dx:ASPxLabel>
                                    </td>
                                    <td>&nbsp;&nbsp;</td>
                                    <td>
                                        <dx:ASPxButton ID="btAgregarCliente" runat="server" Text="Agregar" OnClick="btAgregarCliente_Click"  ClientEnabled="false"></dx:ASPxButton>
                                    </td>
                                </tr>
                            </table>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="" Name="dtdizucar" ShowCaption="False" ColumnSpan="3" ClientVisible="false">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxGridView ID="ListViewCliente" runat="server" DataSourceID="Sds_ENTRADA_SALIDA_CLIENTE" AutoGenerateColumns="False" KeyFieldName="ID_ES_CLIENTE"
                                OnCellEditorInitialize="ListViewCliente_CellEditorInitialize" OnSummaryDisplayText="ListViewCliente_SummaryDisplayText" OnDataBound="ListViewCliente_DataBound">
                                <Columns>
                                    <dx:GridViewCommandColumn ShowDeleteButton="false" ShowEditButton="false" ShowInCustomizationForm="True" VisibleIndex="0">
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
                                <%--<ClientSideEvents EndCallback="OnEndCallback" Init="OnInit" />--%>
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
                                    <asp:Parameter Name="ID_ES_ENCA" Type="Int32" />
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
        <dx:LayoutGroup Caption="Información de Transporte" Name="transporte" ClientVisible="false"  ColCount="3" GroupBoxDecoration="HeadingLine" UseDefaultPaddings="false" Paddings-PaddingTop="10">
            <Paddings PaddingTop="10px"></Paddings>
            <GroupBoxStyle>
                <Caption Font-Bold="true" Font-Size="10" />
            </GroupBoxStyle>
            <Items>
                <dx:LayoutItem Caption="Proveedor" ColumnSpan="2">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxProveedorTrans" runat="server" TextField="NOMBRE" ClientEnabled="false"
                                ValueField="ID_PROV_TRAS" ValueType="System.Int32" Width="100%">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Transporte">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxTransporte" runat="server" TextField="NOMBRE" ClientEnabled="false"
                                ValueField="ID_TRANSPORTE" ValueType="System.Int32" Width="100%">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Motorista">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txtMotoritsta" runat="server" ClientEnabled="false">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                                <ClientSideEvents ValueChanged="changedupper" />
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Nit">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txtNitMotor" runat="server" ClientEnabled="false">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                                 <ClientSideEvents KeyPress="function(s,e){ Numericint(s,e);}" />
                            </dx:ASPxTextBox>
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
<asp:ObjectDataSource ID="odsZAFRA_PROD" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CZAFRA"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsDIA_ZAFRA" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CDIA_ZAFRA"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsTURNO" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CTURNO"></asp:ObjectDataSource>


<asp:ObjectDataSource ID="odsCLIENTE" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CCLIENTE"></asp:ObjectDataSource>


<%--DETALLE--%>
<asp:ObjectDataSource ID="odsPRODUCTO" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CPRODUCTO"></asp:ObjectDataSource>

<asp:ObjectDataSource ID="odsCTIPO_CONCEPTO_PRODdt" runat="server" SelectMethod="ObtenerPorIdProducto" TypeName="ADMINPT.BL.CTIPO_CONCEPTO">
    <SelectParameters>
        <asp:Parameter Name="id" DefaultValue="-1" Type="Int32" />
        <asp:Parameter Name="ent" DefaultValue="1" Type="Int32" />
        <asp:Parameter Name="sali" DefaultValue="0" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>


<asp:ObjectDataSource ID="odsCONCEPTO_MOVI" runat="server" SelectMethod="ObtenerPorIdTM" TypeName="ADMINPT.BL.CCONCEPTO_MOVI">
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

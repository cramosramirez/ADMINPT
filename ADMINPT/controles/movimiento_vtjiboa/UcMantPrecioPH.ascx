<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantPrecioPH.ascx.cs" Inherits="ADMINPT.controles.movimiento_vtjiboa.UcMantPrecioPH" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/controles/movimiento_vtjiboaEmp/UcListaENTRADA_SALIDA_DETA_VTJIBOAEMP.ascx" TagPrefix="uc1" TagName="UcListaENTRADA_SALIDA_DETA_VTJIBOAEMP" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/UCBarraNavegacion.ascx" TagPrefix="uc1" TagName="UCBarraNavegacion" %>
<%@ Register Src="~/controles/movimiento_despacho/UcListaENTRADA_SALIDA_DETA_VTJIBOAEMP.ascx" TagPrefix="uc2" TagName="UcListaENTRADA_SALIDA_DETA_VTJIBOAEMP" %>



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
<uc1:UCBarraNavegacion runat="server" id="UCBarraNavegacion" />
<uc1:UCEncabezado runat="server" id="UCEncabezado" />

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
                                    <RequiredField IsRequired="True" ErrorText="Fecha" />
                                </ValidationSettings>
                            </dx:ASPxDateEdit>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                  <dx:LayoutItem Caption=""   >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                           
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                   <dx:LayoutItem Caption="Tipo Documento" CaptionStyle-Font-Bold="true">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxTipoDocument" runat="server" ValueType="System.String" AutoPostBack="true" OnTextChanged="cbxTipoDocument_TextChanged"  >
                                <Items>
                                    <dx:ListEditItem Text="FACTURA" Value="FA" />
                                    <dx:ListEditItem Text="CREDITO FISCAL" Value="CF" />                                    
                                </Items>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
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
                <dx:LayoutItem Caption="" ShowCaption="False">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxButton ID="btImportar" runat="server" Text="Importar de PH" CausesValidation="false" OnClick="btImportar_Click"  AutoPostBack="false">
                                <Image IconID="actions_converttorange_16x16">
                                </Image>
                                <ClientSideEvents Click="function(s, e) {ldnPanel.Show(); e.processOnServer = true;}" />
                            </dx:ASPxButton>
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
               
                <dx:LayoutItem Caption="" ClientVisible="false" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                             <dx:ASPxSpinEdit ID="speCantidad" ClientInstanceName="speCantidad" runat="server" Number="" DecimalPlaces="2" ReadOnly="false" HorizontalAlign="Right"  AutoPostBack="true" ClientEnabled="false"  DisplayFormatString="N2">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>                                
                                <SpinButtons ShowIncrementButtons="false"></SpinButtons>
                            </dx:ASPxSpinEdit>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                 <dx:LayoutItem Caption="Fecha Decpacho" ClientVisible="true" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxDateEdit ID="txtFechaDespacho" runat="server" EditFormat="Custom" EditFormatString="dd/MM/yyyy" ClientEnabled="false" >
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>                               
                            </dx:ASPxDateEdit>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="" ShowCaption="False" ColumnSpan="3">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <uc2:UcListaENTRADA_SALIDA_DETA_VTJIBOAEMP runat="server" ID="UcListaENTRADA_SALIDA_DETA_VTJIBOAEMP" PermitirEditar="true" />
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
            </Items>
        </dx:LayoutGroup>
        <dx:LayoutGroup Caption="Información de Pago" ColCount="3" GroupBoxDecoration="HeadingLine" UseDefaultPaddings="false" Paddings-PaddingTop="2">
            <Paddings PaddingTop="2px"></Paddings>

            <GroupBoxStyle>
                <Caption Font-Bold="true" Font-Size="10" />
            </GroupBoxStyle>
            <Items>            
                 <dx:LayoutItem Caption="Forma de Pago"   >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cb_fmpago" ClientInstanceName="cb_bodegaO" runat="server"  DataSourceID="SdsListFormaPagos" ValueField="ID_FMPAGO" TextField="NOMBRE" 
                                        ValueType="System.Int32" AutoPostBack="true" DropDownStyle="DropDownList" TextFormatString="{0}" IncrementalFilteringMode="Contains">
                                      <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithText" ErrorText="requerido!!!" ErrorTextPosition="Right">
                                            <RequiredField ErrorText="requerido!!!" IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                             <asp:SqlDataSource ID="SdsListFormaPagos" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>" SelectCommand="CB_FORMA_PAGO" SelectCommandType="StoredProcedure"></asp:SqlDataSource>          
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Total"   >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                           <dx:ASPxTextBox ID="txtTotal" runat="server" AutoCompleteType="Disabled" ClientEnabled="true">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                               <ClientSideEvents KeyPress="function(s,e){ OnKeyPress(s,e);}" />                               
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption=""   >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                           
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                  <dx:LayoutItem Caption="Efectivo"   >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txtEfectivo" runat="server" AutoCompleteType="Disabled">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                               <ClientSideEvents KeyPress="function(s,e){ OnKeyPress(s,e);}" />                               
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                 <dx:LayoutItem Caption="Cheque"   >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                             <dx:ASPxTextBox ID="txtCheque" runat="server" AutoCompleteType="Disabled">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                               <ClientSideEvents KeyPress="function(s,e){ OnKeyPress(s,e);}" />                               
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                 <dx:LayoutItem Caption="Nota de Abono"  >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                             <dx:ASPxTextBox ID="txtNotaAbono" runat="server" AutoCompleteType="Disabled">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                               <ClientSideEvents KeyPress="function(s,e){ OnKeyPress(s,e);}" />                               
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                  <dx:LayoutItem Caption=""   >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                           
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                 <dx:LayoutItem Caption="Monto de Cheque"   >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                             <dx:ASPxTextBox ID="txtmCheque" runat="server" AutoCompleteType="Disabled">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                               <ClientSideEvents KeyPress="function(s,e){ OnKeyPress(s,e);}" />                               
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                 <dx:LayoutItem Caption="Monto de Nota de Abono"  >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                             <dx:ASPxTextBox ID="txtmNotaAbono" runat="server" AutoCompleteType="Disabled">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                               <ClientSideEvents KeyPress="function(s,e){ OnKeyPress(s,e);}" />                               
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Banco"   >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                           <dx:ASPxTextBox ID="txtBanco"  runat="server">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="N° Cheque"   >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                           <dx:ASPxTextBox ID="txtNCheque"  runat="server">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="N° Cuenta"   >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                           <dx:ASPxTextBox ID="txtNCuenta"  runat="server">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
            </Items>
        </dx:LayoutGroup>
      
    </Items>
</dx:ASPxFormLayout>
 <dx:ASPxLoadingPanel ID="ldnPanel" runat="server" Text="Importando Datos..." ClientInstanceName="ldnPanel" Theme="MaterialCompact" 
        Modal="True">
    </dx:ASPxLoadingPanel>

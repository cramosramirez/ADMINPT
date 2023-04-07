<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcNotaCreditoEmpacado.ascx.cs" Inherits="ADMINPT.controles.movimiento_vtjiboaEmp.UcNotaCreditoEmpacado" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/controles/movimiento_vtjiboaEmp/UcListaENTRADA_SALIDA_DETA_VTJIBOAEMP.ascx" TagPrefix="uc1" TagName="UcListaENTRADA_SALIDA_DETA_VTJIBOAEMP" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/UCBarraOpciones.ascx" TagPrefix="uc1" TagName="UCBarraOpciones" %>
<%@ Register Src="~/controles/UCBarraNavegacion.ascx" TagPrefix="uc1" TagName="UCBarraNavegacion" %>


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
                <dx:LayoutItem Caption="Bodega Origen" ColumnSpan="3" CaptionStyle-Font-Bold="false" ClientVisible="true">
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
                 
                 <dx:LayoutItem Caption="Fecha">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxDateEdit ID="dteFecha" runat="server" EditFormat="Custom" EditFormatString="dd/MM/yyyy"  ClientEnabled="false">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Fecha" />
                                </ValidationSettings>
                            </dx:ASPxDateEdit>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                 <dx:LayoutItem Caption="Tipo Documento" CaptionStyle-Font-Bold="true">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxTipoDocument" runat="server" ValueType="System.String" AutoPostBack="true"   >
                                <Items>
                                    <dx:ListEditItem Text="NOTA DE CREDITO" Value="4" Selected="true" />  
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
                </Items>
            </dx:LayoutGroup>
          <dx:LayoutGroup Caption="Información del Documento Anular" ColCount="3" GroupBoxDecoration="HeadingLine" UseDefaultPaddings="false" Paddings-PaddingTop="2">
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
                            <dx:ASPxDateEdit ID="dteFecha1" runat="server" EditFormat="Custom" EditFormatString="dd/MM/yyyy"  ClientEnabled="false" AutoPostBack="true" OnValueChanged="dteFecha1_ValueChanged">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Fecha" />
                                </ValidationSettings>
                            </dx:ASPxDateEdit>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                 <%--<dx:LayoutItem Caption="Tipo Documento" CaptionStyle-Font-Bold="true">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxTipoDocument1" runat="server" ValueType="System.String" AutoPostBack="true" OnTextChanged="cbxTipoDocument1_TextChanged"   >
                                <Items>
                                    <dx:ListEditItem Text="FACTURA" Value="2"  /> 
                                     <dx:ListEditItem Text="CREDITO FISCAL" Value="3"  /> 
                                </Items>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>--%>
                <dx:LayoutItem Caption="Nº Documento" CaptionStyle-Font-Bold="true">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txt_ndocument1" runat="server" AutoCompleteType="Disabled" OnTextChanged="txt_ndocument1_TextChanged" AutoPostBack="true">
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
                </Items>
            </dx:LayoutGroup>
        </Items>
        </dx:ASPxFormLayout>
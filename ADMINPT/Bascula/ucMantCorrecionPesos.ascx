<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMantCorrecionPesos.ascx.cs" Inherits="ADMINPT.Bascula.ucMantCorrecionPesos" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
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
</script>

<style type="text/css">
    .formLayout {
        max-width: 1300px;
        margin: auto;
    }
</style>

<uc1:UCBarraNavegacion runat="server" id="UCBarraNavegacion" />
<uc1:UCEncabezado runat="server" id="UCEncabezado" />
<dx:ASPxFormLayout ID="ASPxFormLayout1" Width="100%" runat="server" CssClass="formLayout">
    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="700" />
    <Items>
          <dx:LayoutGroup Caption="Datos de Producción" Name="Saldo"   ColCount="2" GroupBoxDecoration="Box" UseDefaultPaddings="false" Paddings-PaddingTop="2">
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
                 <dx:LayoutItem Caption="">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer> 
                            <dx:ASPxTextBox ID="txtIdentificadorDt" runat="server" ClientEnabled="false" ClientVisible="false">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Fecha">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxDateEdit ID="dteFecha" runat="server" AutoPostBack="true" EditFormat="Custom" EditFormatString="dd/MM/yyyy" ClientEnabled="false" >
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxDateEdit>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                 <dx:LayoutItem Caption="Nº Documento" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txt_ndocument" runat="server" AutoCompleteType="Disabled" AutoPostBack="true" OnTextChanged="txt_ndocument_TextChanged"   >
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                                <ClientSideEvents KeyPress="function(s,e){ Numericint(s,e);}" />                               
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Producto" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txt_prod" runat="server" AutoCompleteType="Disabled"    >
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                                <ClientSideEvents KeyPress="function(s,e){ Numericint(s,e);}" />                                
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                 <dx:LayoutItem Caption="" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxLabel ID="lbProd" runat="server" Text="" ClientVisible="false" ></dx:ASPxLabel>
                    </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                 <dx:LayoutItem Caption="Peso Tarima" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                           <dx:ASPxTextBox ID="txt_tarima" runat="server" AutoCompleteType="Disabled" AutoPostBack="true" OnTextChanged="txt_tarima_TextChanged"   >
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                                <ClientSideEvents KeyPress="function(s,e){ Numericint(s,e);}" />                                
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Factor" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txt_factor" runat="server" AutoCompleteType="Disabled" ClientEnabled="false"   >
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                                <ClientSideEvents KeyPress="function(s,e){ Numericint(s,e);}" />                                
                            </dx:ASPxTextBox>
                            
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                 <dx:LayoutItem Caption="Tara" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txt_tara" runat="server" AutoCompleteType="Disabled" AutoPostBack="true" OnTextChanged="txt_tara_TextChanged"   >
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                                <ClientSideEvents KeyPress="function(s,e){ Numericint(s,e);}" />                                
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Fecha Lee Tara" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                           <dx:ASPxDateEdit ID="txt_ftara" runat="server" DisplayFormatString="dd/MM/yyyy HH:mm" EditFormatString="dd/MM/yyyy HH:mm">  
   <ClearButton DisplayMode="Always"></ClearButton>
                               <TimeSectionProperties Visible="true"></TimeSectionProperties>  
</dx:ASPxDateEdit>  
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                 <dx:LayoutItem Caption="Bruto" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                           <dx:ASPxTextBox ID="txt_bruto" runat="server" AutoCompleteType="Disabled" AutoPostBack="true" OnTextChanged="txt_bruto_TextChanged"   >
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                                <ClientSideEvents KeyPress="function(s,e){ Numericint(s,e);}" />                                
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Fecha Lee Bruto" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                          <dx:ASPxDateEdit ID="txt_fbruto" runat="server" DisplayFormatString="dd/MM/yyyy HH:mm" EditFormatString="dd/MM/yyyy HH:mm">  
    <ClearButton DisplayMode="Always"></ClearButton>
                              <TimeSectionProperties Visible="true"></TimeSectionProperties>  
</dx:ASPxDateEdit>  
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                 <dx:LayoutItem Caption="Neto" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txt_neto" runat="server" AutoCompleteType="Disabled" ClientEnabled="false"   >
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                                <ClientSideEvents KeyPress="function(s,e){ Numericint(s,e);}" />                                
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Kilogramos" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txt_kilogramos" runat="server" AutoCompleteType="Disabled" ClientEnabled="false"   >
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                                <ClientSideEvents KeyPress="function(s,e){ Numericint(s,e);}" />                                
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Quintales" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txt_quintales" runat="server" AutoCompleteType="Disabled" ClientEnabled="false"   >
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                                <ClientSideEvents KeyPress="function(s,e){ Numericint(s,e);}" />                                
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Galones" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txt_galones" runat="server" AutoCompleteType="Disabled" ClientEnabled="false"   >
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

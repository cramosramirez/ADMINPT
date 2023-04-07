<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantReemplazarDocumento.ascx.cs" Inherits="ADMINPT.controles.Facturado.UcMantReemplazarDocumento" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraReports.v20.1.Web.WebForms, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/controles/UCBarraNavegacion.ascx" TagPrefix="uc1" TagName="UCBarraNavegacion" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>

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
<uc1:UCBarraNavegacion runat="server" id="UCBarraNavegacion" />
<uc1:UCEncabezado runat="server" id="UCEncabezado" />
  <dx:ASPxFormLayout ID="FtListEmpresa" CssClass="modal-content" runat="server">
            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
            <Items>
                <dx:LayoutGroup Caption="Anular Documento" ColumnCount="3"  GroupBoxDecoration="Box"
                    UseDefaultPaddings="false" Paddings-PaddingTop="3">
                    <Paddings PaddingTop="3px"></Paddings>
                    <GroupBoxStyle>
                        <Caption CssClass="title" />
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
                        <dx:LayoutItem Caption="Fecha Documento" CaptionSettings-HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit ID="txt_fechad" ClientInstanceName="txt_fechad" runat="server"   >
                                        <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                        <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithText" ErrorText="requerido!!!" ErrorTextPosition="Right">
                                            <RequiredField ErrorText="requerido!!!" IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="N° (NR / CCF/ FA)" CaptionSettings-HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtNDocumento" runat="server" AutoPostBack="true" OnTextChanged="txtNDocumento_TextChanged"  AutoCompleteType="Disabled">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                                <ClientSideEvents KeyPress="function(s,e){ Numericint(s,e);}" />
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Producto" CaptionSettings-HorizontalAlign="Right" >
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtProducto" runat="server" Enabled="false"  Width="100%">
                                                    <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                           
                                                </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                        </dx:LayoutItem>
                            <dx:LayoutItem Caption="" ColumnSpan="3" FieldName="btctHabilitar" Name="btctHabilitar" CaptionSettings-HorizontalAlign="Right"  ClientVisible="true">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxButton ID="bt_habilitar" runat="server" Text="Habilitar" OnClick="bt_habilitar_Click" Theme="iOS" >
                                        <Image IconID="grid_wordwrap_16x16">
                                        </Image>
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
                <dx:LayoutGroup Caption="Documento Reemplaza en Bascula" ColumnCount="3"  GroupBoxDecoration="Box"
                    UseDefaultPaddings="false" Paddings-PaddingTop="3">
                    <Paddings PaddingTop="3px"></Paddings>
                    <GroupBoxStyle>
                        <Caption CssClass="title" />
                    </GroupBoxStyle>
                    <Items>  
                        <dx:LayoutItem Caption="Fecha Documento" CaptionSettings-HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit ID="txt_fechar" ClientInstanceName="txt_fechad" runat="server"   >
                                        <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                        <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithText" ErrorText="requerido!!!" ErrorTextPosition="Right">
                                            <RequiredField ErrorText="requerido!!!" IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="N° (NR / CCF/ FA)" CaptionSettings-HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtNDocumentor" runat="server" AutoPostBack="true" OnTextChanged="txtNDocumentor_TextChanged"  AutoCompleteType="Disabled">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                                <ClientSideEvents KeyPress="function(s,e){ Numericint(s,e);}" />
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Producto"  CaptionSettings-HorizontalAlign="Right" >
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                     <dx:ASPxTextBox ID="txtProducto2" runat="server"  Enabled="false" Width="100%">
                                                    <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                           
                                                </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                        </dx:LayoutItem>
                         <dx:LayoutItem Caption="Observación"   CaptionSettings-HorizontalAlign="Right" ColumnSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxMemo ID="txtObservacion" runat="server" Height="30px" >
                                        <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                                    </dx:ASPxMemo>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
            </Items>
        </dx:ASPxFormLayout>

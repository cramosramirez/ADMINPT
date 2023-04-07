<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcViewDetalleVenta.ascx.cs" Inherits="ADMINPT.controles.Facturado.UcViewDetalleVenta" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraReports.v20.1.Web.WebForms, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/controles/UCBarraNavegacion.ascx" TagPrefix="uc1" TagName="UCBarraNavegacion" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>


<uc1:UCBarraNavegacion runat="server" ID="UCBarraNavegacion" />
<uc1:UCEncabezado runat="server" ID="UCEncabezado" />
<dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server"></dx:ASPxFormLayout>
<dx:ASPxFormLayout ID="FtListEmpresa" CssClass="modal-content" runat="server">
    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
    <Items>
        <dx:LayoutGroup Caption="" ColumnCount="2" ShowCaption="false" GroupBoxDecoration="Box"
            UseDefaultPaddings="false" Paddings-PaddingTop="3">
            <Paddings PaddingTop="3px"></Paddings>
            <GroupBoxStyle>
                <Caption CssClass="title" />
            </GroupBoxStyle>
            <Items>
                <dx:LayoutItem Caption="Reporte" ColumnSpan="2" CaptionSettings-HorizontalAlign="Right">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cb_Reporte" runat="server" ValueType="System.String">
                                <Items>
                                    <dx:ListEditItem Text="DETALLE DE VENTA" Value="1" Selected="true" />
                                    <dx:ListEditItem Text="RESUMEN POR FORMA DE PAGO" Value="2" />
                                    <dx:ListEditItem Text="RESUMEN POR TIPO DE PRODUCTO" Value="3" />
                                    <dx:ListEditItem Text="VENTA DE MELAZA" Value="4" />
                                </Items>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Bodega" ColumnSpan="2" ClientVisible="true" CaptionSettings-HorizontalAlign="Right">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cb_bodegaO" ClientInstanceName="cb_bodegaO" runat="server" DataSourceID="SdsListBgasOrigen" ValueField="ID_BODEGA" TextField="NOMBRE"
                                ValueType="System.Int32" AutoPostBack="true" DropDownStyle="DropDownList" TextFormatString="{0}" IncrementalFilteringMode="Contains">
                                <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithText" ErrorText="requerido!!!" ErrorTextPosition="Right">
                                    <RequiredField ErrorText="requerido!!!" IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                            <asp:SqlDataSource ID="SdsListBgasOrigen" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>" SelectCommand="CB_BODEGAS_ORIGEN" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>


                    <CaptionSettings HorizontalAlign="Right"></CaptionSettings>


                </dx:LayoutItem>

                <dx:LayoutItem Caption="Fecha Desde" CaptionSettings-HorizontalAlign="Right">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxDateEdit ID="txt_fechad" ClientInstanceName="txt_fechad" runat="server">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithText" ErrorText="requerido!!!" ErrorTextPosition="Right">
                                    <RequiredField ErrorText="requerido!!!" IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxDateEdit>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Hasta" CaptionSettings-HorizontalAlign="Right">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxDateEdit ID="txt_fechah" ClientInstanceName="txt_fechah" runat="server">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithText" ErrorText="requerido!!!" ErrorTextPosition="Right">
                                    <RequiredField ErrorText="requerido!!!" IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxDateEdit>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                </dx:LayoutItem>

                <dx:LayoutItem Caption="" CaptionSettings-HorizontalAlign="Right">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxGridView ID="Dgv_list" runat="server" Caption="Facturación PH" Width="100%" AutoGenerateColumns="false">
                                <Columns>
                                    <dx:GridViewDataColumn FieldName="numero" Caption="N° Doc" />
                                    <dx:GridViewDataTextColumn FieldName="valortot" Caption="Facturado">
                                        <PropertiesTextEdit DisplayFormatString="c" />
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataColumn FieldName="anulado" Caption="Estado" GroupIndex="0" />
                                </Columns>
                                <Settings ShowFooter="true" />
                                <TotalSummary>
                                    <dx:ASPxSummaryItem FieldName="numero" SummaryType="Count" />
                                    <dx:ASPxSummaryItem FieldName="valortot" SummaryType="Sum" />
                                </TotalSummary>
                                <Settings ShowGroupPanel="True" ShowFooter="True" />
                                <GroupSummary>
                                    <dx:ASPxSummaryItem FieldName="anulado" SummaryType="Count" />
                                    <dx:ASPxSummaryItem FieldName="valortot" SummaryType="Sum" />
                                </GroupSummary>
                            </dx:ASPxGridView>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="" CaptionSettings-HorizontalAlign="Right">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxGridView ID="Dgv_list2" runat="server" DataSourceID="sdListcpt" Caption="Facturación CPT" Width="100%" AutoGenerateColumns="false">
                                <Columns>
                                    <dx:GridViewDataColumn FieldName="NREMISION" Caption="N° Doc" />
                                    <dx:GridViewDataTextColumn FieldName="TOTA" Caption="Facturado">
                                        <PropertiesTextEdit DisplayFormatString="c" />
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataColumn FieldName="ANULADO" Caption="Estado" GroupIndex="0" />
                                </Columns>
                                <Settings ShowFooter="true" />
                                <TotalSummary>
                                    <dx:ASPxSummaryItem FieldName="NREMISION" SummaryType="Count" />
                                    <dx:ASPxSummaryItem FieldName="TOTA" SummaryType="Sum" />
                                </TotalSummary>
                                <Settings ShowGroupPanel="True" ShowFooter="True" />
                                <GroupSummary>
                                    <dx:ASPxSummaryItem FieldName="ANULADO" SummaryType="Count" />
                                    <dx:ASPxSummaryItem FieldName="TOTA" SummaryType="Sum" />
                                </GroupSummary>
                            </dx:ASPxGridView>
                            <asp:SqlDataSource ID="sdListcpt" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>" SelectCommand="VIEW_FACTURADO_CPT" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txt_fechah" DbType="Date" Name="FECHA" PropertyName="Value" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                </dx:LayoutItem>
            </Items>
        </dx:LayoutGroup>
    </Items>
</dx:ASPxFormLayout>
<dx:ASPxLoadingPanel ID="ldnPanel" runat="server" Text="Procesando Datos..." ClientInstanceName="ldnPanel" Theme="MaterialCompact"
    Modal="True">
</dx:ASPxLoadingPanel>
<script>
    function Init(s, e) {
        // s.GetReportPreview().zoom(0.9);
        s.GetReportPreview().zoom(DevExpress.Reporting.Viewer.ZoomAutoBy.PageWidth);
    }
</script>
<table style="width: 100%;">
    <tr>
        <td>
            <dx:ASPxWebDocumentViewer ID="Facturado" runat="server" EnableViewState="true">
                <ClientSideEvents Init="Init" />
            </dx:ASPxWebDocumentViewer>
        </td>
    </tr>
</table>

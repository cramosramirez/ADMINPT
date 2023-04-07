<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcConsultaDoc.ascx.cs" Inherits="ADMINPT.controles.DigitalizacionRpt.UcConsultaDoc" %>

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
                <dx:LayoutItem Caption="" ShowCaption="False" CaptionSettings-HorizontalAlign="Right" ColumnSpan="2">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxRadioButtonList ID="rdOpciones" runat="server" ValueType="System.String" RepeatDirection="Horizontal" SelectedIndex="0">
                                <Items>
                                    <dx:ListEditItem Selected="True" Text="Traslado Externo" Value="1" />
                                    <dx:ListEditItem Text="Venta de Jiboa" Value="2" />
                                    <dx:ListEditItem Text="Traslado - Dizucar Central" Value="3" />
                                    <%--            <dx:ListEditItem Text="Venta de Melaza Jiboa" Value="4" />--%>
                                </Items>
                            </dx:ASPxRadioButtonList>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                </dx:LayoutItem>

                <dx:LayoutItem Caption="Fecha Inicial" CaptionSettings-HorizontalAlign="Right">
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
                <dx:LayoutItem Caption="Fecha Final" CaptionSettings-HorizontalAlign="Right">
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
            </Items>
        </dx:LayoutGroup>
    </Items>
</dx:ASPxFormLayout>
<dx:ASPxGridView ID="Dgv_List" ClientInstanceName="Dgv_List" runat="server" AutoGenerateColumns="False"
    KeyFieldName="ID_ES_ENCA" Font-Size="X-Small">
    <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true"
        AllowHideDataCellsByColumnMinWidth="true">
    </SettingsAdaptivity>
    <SettingsCommandButton>
        <NewButton RenderMode="Image" Text="Nuevo">
            <Image IconID="miscellaneous_newwizard_16x16gray"></Image>
        </NewButton>
        <EditButton RenderMode="Image" Text="Editar">
            <Image IconID="edit_edit_16x16gray"></Image>
        </EditButton>
        <DeleteButton RenderMode="Image" Text="Eliminar">
            <Image IconID="actions_cancel_16x16gray"></Image>
        </DeleteButton>
        <UpdateButton RenderMode="Image" Text="Guardar">
            <Image IconID="save_save_32x32gray"></Image>
        </UpdateButton>
        <CancelButton RenderMode="Image" Text="Cancelar">
            <Image IconID="history_undo_32x32gray"></Image>
        </CancelButton>
    </SettingsCommandButton>
    <SettingsLoadingPanel Text="Cargando&amp;hellip;" />
    <SettingsPager>
        <Summary AllPagesText="Pags: {0} - {1} ({2} registros)"
            Text="Pag. {0} de {1} ({2} registros)" />
        <PageSizeItemSettings Items="5, 10, 30" Visible="True">
        </PageSizeItemSettings>
    </SettingsPager>
    <SettingsText GroupPanel="Arrastre la columna aqui para agrupar"
        EmptyDataRow="No existen registros para mostrar" />
    <Settings ShowFilterRow="false" ShowHeaderFilterButton="false" ShowFooter="True" />
    <SettingsBehavior EnableRowHotTrack="True" AllowFocusedRow="True" />
    <SettingsSearchPanel Visible="true" />
    <Toolbars>
        <dx:GridViewToolbar>
            <SettingsAdaptivity Enabled="true" EnableCollapseRootItemsToIcons="true" />
            <Items>
                <dx:GridViewToolbarItem Command="ExportToPdf" />
                <dx:GridViewToolbarItem Command="ExportToXls" />
                <dx:GridViewToolbarItem Command="ExportToXlsx" />
            </Items>
        </dx:GridViewToolbar>
    </Toolbars>
    <Columns>
<%--        <dx:GridViewCommandColumn ShowDeleteButton="false" ShowEditButton="True" ShowNewButtonInHeader="false" VisibleIndex="0" Width="5px">
        </dx:GridViewCommandColumn>--%>
        <dx:GridViewDataHyperLinkColumn FieldName="HLC_REPORTE" UnboundType="String" UnboundExpression="'?id='+[ID_ES_ENCA]+'&mv='+5+'&tp='+[TIPO]+'&tpd='+[ID_TIPO]" ShowInCustomizationForm="True" VisibleIndex="2" Visible="true" Width="5px" HeaderStyle-HorizontalAlign="Center" Caption="Reporte">
            <Settings AllowAutoFilter="false" />
            <PropertiesHyperLinkEdit TextField="ID_ES_ENCA" ImageUrl="~/Imagenes/Reporte.png" DisplayFormatString="Open <b>{0}<b/>" NavigateUrlFormatString="~/forms/DigitalizacionRpt/wfViewNotas.aspx{0}" Target="_blank"></PropertiesHyperLinkEdit>
            <HeaderStyle HorizontalAlign="Center" />
        </dx:GridViewDataHyperLinkColumn>
        <dx:GridViewDataTextColumn FieldName="ID_ES_ENCA" Caption="ID" ShowInCustomizationForm="True" VisibleIndex="1" Visible="false" Width="5px">
            <EditFormSettings Visible="False" />
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataDateColumn FieldName="FECHA" Caption="Fecha" ShowInCustomizationForm="True" VisibleIndex="2" Width="5px" Visible="true">
        </dx:GridViewDataDateColumn>
        <dx:GridViewDataTextColumn FieldName="ID_TIPO" Caption="Id Tipo Doc" ShowInCustomizationForm="True" VisibleIndex="3" Width="5px" Visible="false">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="TIPO_DOC" Caption="Tipo Documento" ShowInCustomizationForm="True" VisibleIndex="3" Width="5px" Visible="true">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="NUM_DOC" Caption="NDocumento" ShowInCustomizationForm="True" VisibleIndex="4" Width="5px" Visible="true">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="NOM_PRODUCTO" Caption="Producto" ShowInCustomizationForm="True" VisibleIndex="5" Width="60px" Visible="true">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="CONCEPTO" Caption="Concepto" ShowInCustomizationForm="True" VisibleIndex="6" Width="20px" Visible="true">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="ESPECIFICO" Caption="Especifico" ShowInCustomizationForm="True" VisibleIndex="7" Width="20px" Visible="true">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="TIPO" Caption="ID" ShowInCustomizationForm="True" VisibleIndex="1" Visible="false" Width="5px">
            <EditFormSettings Visible="False" />
        </dx:GridViewDataTextColumn>
<%--        <dx:GridViewCommandColumn Name="delete" Caption=" " ShowDeleteButton="True" ShowInCustomizationForm="True" VisibleIndex="8" Width="30px" Visible="false">
        </dx:GridViewCommandColumn>--%>
    </Columns>
    <SettingsEditing EditFormColumnCount="1" Mode="PopupEditForm" />
    <SettingsPopup>
        <EditForm AllowResize="true" Modal="true" HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter" />
    </SettingsPopup>
    <Settings ShowFilterRow="false" ShowFilterRowMenu="true" ShowGroupPanel="false" ShowFooter="True" />
    <SettingsPager PageSize="5">
        <PageSizeItemSettings Visible="true" Items="5, 10, 30" />
    </SettingsPager>
    <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG" Landscape="true" />
    <GroupSummary>
        <dx:ASPxSummaryItem SummaryType="Count" />
    </GroupSummary>
    <Styles Header-BackColor="#f0f0f0" Header-Font-Bold="true">
        <Header BackColor="#F0F0F0" Font-Bold="True">
        </Header>
    </Styles>
</dx:ASPxGridView>


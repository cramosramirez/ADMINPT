<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantNivel.ascx.cs" Inherits="ADMINPT.controles.ReportesBodegaJiboa.Melaza.TanqueNivel.UcMantNivel" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraReports.v20.1.Web.WebForms, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/UCCriterios.ascx" TagPrefix="uc1" TagName="UCCriterios" %>
<%@ Register Src="~/controles/UcSeparadorCriterios.ascx" TagPrefix="uc1" TagName="UcSeparadorCriterios" %>
<%@ Register Src="~/controles/UCBarraNavegacion.ascx" TagPrefix="uc1" TagName="UCBarraNavegacion" %>


<uc1:UCBarraNavegacion runat="server" id="UCBarraNavegacion" />
<uc1:UCEncabezado runat="server" ID="UCEncabezado" />
<uc1:UCCriterios runat="server" ID="UCCriterios" />
<uc1:UcSeparadorCriterios runat="server" ID="UcSeparadorCriterios" />



<%--<uc1:UCEncabezado runat="server" ID="UCEncabezado" />
<uc1:UCCriterios runat="server" ID="UCCriterios" />
<uc1:UcSeparadorCriterios runat="server" ID="UcSeparadorCriterios" />--%>



<table border="0" class="tb">
    <tr id="_Cont_ListAprobacionPlan" runat="server" visible="true">
        <td class="td">
            <dx:ASPxGridView ID="dgvNivel" ClientInstanceName="dgvNivel" runat="server" AutoGenerateColumns="False"
                DataSourceID="Sds_Lista" KeyFieldName="ID_TANQUE_NVL" Width="100%" OnRowValidating="dgvNivel_RowValidating" OnInitNewRow="dgvNivel_InitNewRow" OnStartRowEditing="dgvNivel_StartRowEditing">
                <%--<SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true"
                                    AllowHideDataCellsByColumnMinWidth="true">
                                </SettingsAdaptivity>--%>
                <SettingsDataSecurity AllowInsert="true" AllowDelete="true" AllowEdit="true" />
                <Settings ShowFilterRow="true" ShowHeaderFilterButton="false" ShowFooter="True" ShowTitlePanel="true" />
                <SettingsBehavior ConfirmDelete="true" EnableCustomizationWindow="true" EnableRowHotTrack="true" />
                <SettingsText ConfirmDelete="¿Estás seguro de que quieres eliminar?" />
                <SettingsPager>
                    <Summary AllPagesText="Pags: {0} - {1} ({2} registros)"
                        Text="Pag. {0} de {1} ({2} registros)" />
                    <PageSizeItemSettings Items="5, 10, 30" Visible="True">
                    </PageSizeItemSettings>
                </SettingsPager>
                <SettingsEditing EditFormColumnCount="1" Mode="PopupEditForm" />
                <Settings ShowFooter="true" />
                <SettingsBehavior EnableRowHotTrack="True" AllowFocusedRow="True" />
                <SettingsCommandButton>
                    <NewButton RenderMode="Image" Text="Nuevo">
                        <Image IconID="miscellaneous_wizard_32x32"></Image>
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
                <SettingsPopup>
                    <EditForm AllowResize="true" Modal="true" HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter" />
                </SettingsPopup>
                <SettingsSearchPanel Visible="false" />
                <SettingsLoadingPanel Text="Cargando&amp;hellip;" />
                <SettingsText GroupPanel="Arrastre la columna aqui para agrupar"
                    EmptyDataRow="No existen registros para mostrar" />
                <EditFormLayoutProperties>
                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="600" />
                    <Items>
                        <dx:GridViewColumnLayoutItem ColumnName="ID_ZAFRA" Caption="Zafra" CaptionSettings-HorizontalAlign="Right" HorizontalAlign="Left">
                            <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                        </dx:GridViewColumnLayoutItem>

                        <dx:GridViewColumnLayoutItem ColumnName="ID_TANQUE" Caption="Tanque" CaptionSettings-HorizontalAlign="Right" HorizontalAlign="Left">
                            <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                        </dx:GridViewColumnLayoutItem>

                        <dx:GridViewColumnLayoutItem ColumnName="FECHA" Caption="Fecha" CaptionSettings-HorizontalAlign="Right" HorizontalAlign="Left">
                            <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                        </dx:GridViewColumnLayoutItem>

                        <dx:GridViewColumnLayoutItem ColumnName="HORA" Caption="Hora" CaptionSettings-HorizontalAlign="Right" HorizontalAlign="Left">
                            <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                        </dx:GridViewColumnLayoutItem>

                        <dx:GridViewColumnLayoutItem ColumnName="NIVEL" Caption="Nivel" CaptionSettings-HorizontalAlign="Right" HorizontalAlign="Left">
                            <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                        </dx:GridViewColumnLayoutItem>

                        <dx:GridViewColumnLayoutItem ColumnName="TEMP1" Caption="Temperatura 1" CaptionSettings-HorizontalAlign="Right" HorizontalAlign="Left">
                            <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                        </dx:GridViewColumnLayoutItem>

                        <dx:GridViewColumnLayoutItem ColumnName="TEMP2" Caption="Temperatura 2" CaptionSettings-HorizontalAlign="Right" HorizontalAlign="Left">
                            <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                        </dx:GridViewColumnLayoutItem>

                        <%--                        <dx:GridViewColumnLayoutItem ColumnName="PROMEDIO" Caption="Promedio" CaptionSettings-HorizontalAlign="Right" HorizontalAlign="Left">
                            <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                        </dx:GridViewColumnLayoutItem>--%>

                        <dx:GridViewColumnLayoutItem ColumnName="ESTADO" Caption="Estado" CaptionSettings-HorizontalAlign="Right" HorizontalAlign="Left">
                            <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                        </dx:GridViewColumnLayoutItem>

                        <dx:EditModeCommandLayoutItem HorizontalAlign="Right" Paddings-PaddingBottom="0" Visible="true">
                            <Paddings PaddingBottom="0px"></Paddings>
                        </dx:EditModeCommandLayoutItem>
                    </Items>
                </EditFormLayoutProperties>
                <Columns>
                    <%--                            <dx:GridViewDataHyperLinkColumn FieldName="HLC_EDIT" UnboundType="String" UnboundExpression="'?id='+[ID_TANQUE_NVL]+'&mv='+1" ShowInCustomizationForm="True" VisibleIndex="1" Visible="true" Width="5%" HeaderStyle-HorizontalAlign="Center" Caption="Editar">
                                <Settings AllowAutoFilter="false" />
                                <PropertiesHyperLinkEdit TextField="ID_TANQUE_NVL" ImageUrl="~/Imagenes/General/Editar.png" Style-HorizontalAlign="Center" DisplayFormatString="Open <b>{0}<b/>" NavigateUrlFormatString="~/WFormsPresupuesto/Aprobacion/AprobacionPlan.aspx{0}"></PropertiesHyperLinkEdit>
                                <HeaderStyle HorizontalAlign="center" />
                            </dx:GridViewDataHyperLinkColumn>--%>

                    <dx:GridViewCommandColumn ShowDeleteButton="false" ShowNewButtonInHeader="true" ShowNewButton="false" ShowEditButton="true" VisibleIndex="0">
                    </dx:GridViewCommandColumn>

                    <dx:GridViewDataTextColumn FieldName="ID_TANQUE_NVL" Caption="Id" ReadOnly="True" VisibleIndex="1" Visible="false">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataComboBoxColumn FieldName="ID_ZAFRA" Caption="Zafra" ShowInCustomizationForm="True" VisibleIndex="2" EditFormSettings-Visible="true">
                        <PropertiesComboBox DataSourceID="Sds_ListaZafra" TextField="NOMBRE_ZAFRA" ValueField="ID_ZAFRA">
                        </PropertiesComboBox>

                        <EditFormSettings Visible="True"></EditFormSettings>

                        <CellStyle HorizontalAlign="Left">
                        </CellStyle>
                    </dx:GridViewDataComboBoxColumn>

                    <dx:GridViewDataComboBoxColumn FieldName="ID_TANQUE" Caption="Tanque" ShowInCustomizationForm="True" VisibleIndex="3" EditFormSettings-Visible="true">
                        <PropertiesComboBox DataSourceID="Sds_ListaTanque" TextField="NOMBRE" ValueField="ID_TANQUE">
                        </PropertiesComboBox>
                        <EditFormSettings Visible="True"></EditFormSettings>
                    </dx:GridViewDataComboBoxColumn>

                    <dx:GridViewDataDateColumn FieldName="FECHA" Caption="Fecha" VisibleIndex="4" EditFormSettings-Visible="true" PropertiesDateEdit-DisplayFormatString="dd/MM/yyyy">
                        <EditFormSettings Visible="True">
                        </EditFormSettings>
                    </dx:GridViewDataDateColumn>

                    <dx:GridViewDataTextColumn FieldName="HORA" Caption="Hora" VisibleIndex="5" Visible="true">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataSpinEditColumn Caption="Nivel" FieldName="NIVEL" VisibleIndex="6">
                        <PropertiesSpinEdit DisplayFormatString="g">
                        </PropertiesSpinEdit>
                        <EditFormSettings Visible="True" />
                        <CellStyle HorizontalAlign="Left">
                        </CellStyle>
                    </dx:GridViewDataSpinEditColumn>

                    <dx:GridViewDataTextColumn Caption="Temperatura 1" FieldName="TEMP1" VisibleIndex="7">
                        <PropertiesTextEdit ClientInstanceName="TEMP1">
                        </PropertiesTextEdit>

                        <CellStyle HorizontalAlign="Left">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Temperatura 2" FieldName="TEMP2" VisibleIndex="8">
                        <%--                        <PropertiesTextEdit  ClientInstanceName="TEMP2">
                            <ClientSideEvents KeyPress="function(s,e){ OnKeyPress(s,e);}" ValueChanged="function(s,e){var total = (s.GetValue()+TEMP1.GetValue())/2; PROMEDIO.SetValue(total);}" />
                        </PropertiesTextEdit>--%>
                        <EditFormSettings Visible="True" />
                        <CellStyle HorizontalAlign="Left">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Promedio" FieldName="PROMEDIO" VisibleIndex="9" ReadOnly="false">
                        <PropertiesTextEdit ClientInstanceName="PROMEDIO">
                        </PropertiesTextEdit>
                        <EditFormSettings Visible="True" />
                        <CellStyle HorizontalAlign="Left">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataCheckColumn FieldName="ESTADO" Caption="Estado" VisibleIndex="10" Visible="true" EditFormSettings-Visible="true">
                        <EditFormSettings Visible="True"></EditFormSettings>
                    </dx:GridViewDataCheckColumn>
                    <dx:GridViewCommandColumn Name="delete" Caption=" " Width="30" ShowDeleteButton="True" ShowInCustomizationForm="True" VisibleIndex="11" Visible="true">
                    </dx:GridViewCommandColumn>
                </Columns>
                <TotalSummary>
                    <dx:ASPxSummaryItem FieldName="ID_TANQUE_NVL" SummaryType="Count" />
                    <%--<dx:ASPxSummaryItem FieldName="VALOR" SummaryType="Sum" />--%>
                </TotalSummary>
                <Styles Header-BackColor="#f0f0f0" Header-Font-Bold="true">
                    <Header BackColor="#F0F0F0" Font-Bold="True">
                    </Header>
                </Styles>

            </dx:ASPxGridView>
            <asp:SqlDataSource ID="Sds_Lista" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>"
                SelectCommand="SEL_TANQUE_NIVEL" SelectCommandType="StoredProcedure"
                DeleteCommand="DEL_TANQUE_NIVEL" DeleteCommandType="StoredProcedure"
                InsertCommand="CRE_TANQUE_NIVEL" InsertCommandType="StoredProcedure"
                UpdateCommand="UPD_TANQUE_NIVEL" UpdateCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter Name="ID_TANQUE_NVL" DefaultValue="-1" DbType="Int32" />
                </SelectParameters>
                <DeleteParameters>
                    <asp:Parameter Name="ID_TANQUE_NVL" DbType="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="ID_ZAFRA" DbType="Int32" />
                    <asp:Parameter Name="ID_TANQUE" DbType="Int32" />
                    <asp:Parameter Name="FECHA" DbType="Date" />
                    <asp:Parameter Name="HORA" DbType="Time" />
                    <asp:Parameter Name="NIVEL" DbType="Double" />
                    <asp:Parameter Name="TEMP1" DbType="Double" />
                    <asp:Parameter Name="TEMP2" DbType="Double" />
                    <%--<asp:Parameter Name="PROMEDIO" DbType="Double" />--%>
                    <asp:Parameter Name="ESTADO" DbType="Boolean" />
                    <asp:SessionParameter SessionField="USUARIO" Name="USUARIO_CREA" DbType="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="ID_TANQUE_NVL" DbType="Int32" />
                    <asp:Parameter Name="ID_ZAFRA" DbType="Int32" />
                    <asp:Parameter Name="ID_TANQUE" DbType="Int32" />
                    <asp:Parameter Name="FECHA" DbType="Date" />
                    <asp:Parameter Name="HORA" DbType="Time" />
                    <asp:Parameter Name="NIVEL" DbType="Double" />
                    <asp:Parameter Name="TEMP1" DbType="Double" />
                    <asp:Parameter Name="TEMP2" DbType="Double" />
                    <%--                    <asp:Parameter Name="PROMEDIO" DbType="Double" />--%>
                    <asp:Parameter Name="ESTADO" DbType="Boolean" />
                    <asp:SessionParameter SessionField="USUARIO" Name="USUARIO_ACT" DbType="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="Sds_ListaZafra" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>"
                SelectCommand="CB_ZAFRA_ACT" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter Name="ID_EMPRESA" DefaultValue="1" DbType="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="Sds_ListaTanque" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>"
                SelectCommand="SEL_TANQUE" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter Name="ID_TANQUE" DefaultValue="-1" DbType="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <%--                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server"></dx:ASPxGridViewExporter>--%>
        </td>
    </tr>
</table>
<script>
    function Init(s, e) {
        // s.GetReportPreview().zoom(0.9);
        s.GetReportPreview().zoom(DevExpress.Reporting.Viewer.ZoomAutoBy.PageWidth);
    }
</script>
<table style="width: 100%;">
    <tr>
        <td>
            <dx:ASPxWebDocumentViewer ID="BodeRpt" runat="server" EnableViewState="false">
                <ClientSideEvents Init="Init" />
            </dx:ASPxWebDocumentViewer>
        </td>
    </tr>
</table>


<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantCierreDiario.ascx.cs" Inherits="ADMINPT.controles.cierreDiario.UcMantCierreDiario" %>

<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraReports.v20.1.Web.WebForms, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/controles/UCBarraNavegacion.ascx" TagPrefix="uc1" TagName="UCBarraNavegacion" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>


<uc1:UCBarraNavegacion runat="server" ID="UCBarraNavegacion" />
<uc1:UCEncabezado runat="server" ID="UCEncabezado" />
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
                <dx:LayoutItem Caption="Bodega Origen">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                             <dx:ASPxComboBox ID="cb_bodegaO" ClientInstanceName="cb_bodegaO" runat="server" Enabled="false"  DataSourceID="SdsListBgasOrigen" ValueField="ID_BODEGA" TextField="NOMBRE" 
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
                <dx:LayoutItem Caption="Zafra en curso">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cb_zafra" ClientInstanceName="cb_zafra" runat="server"  DataSourceID="sdscb_zafra" ValueField="ID_ZAFRA" TextField="NOMBRE_ZAFRA" 
                                        ValueType="System.String" AutoPostBack="true" DropDownStyle="DropDownList" TextFormatString="{0}" IncrementalFilteringMode="Contains">
                                      <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithText" ErrorText="requerido!!!" ErrorTextPosition="Right">
                                            <RequiredField ErrorText="requerido!!!" IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                             <asp:SqlDataSource ID="sdscb_zafra" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>"
                                 SelectCommand="CB_ZAFRA_ACT_cierre" SelectCommandType="StoredProcedure">
                                 <SelectParameters>
                                     <asp:Parameter Name="ID_EMPRESA" Type="Int16" DefaultValue="1" />
                                 </SelectParameters>
                             </asp:SqlDataSource>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionStyle Font-Bold="True"></CaptionStyle>
                </dx:LayoutItem>
                 <dx:LayoutItem Caption="Año" CaptionSettings-HorizontalAlign="Right">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txt_anio" runat="server" Text="" Enabled="false" >
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Fecha" CaptionSettings-HorizontalAlign="Right">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxDateEdit ID="txt_fechad" ClientInstanceName="txt_fechad" runat="server" AutoPostBack="true" OnValueChanged="txt_fechad_ValueChanged" >
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
                <dx:LayoutGroup Caption="Datos Dia Cerrado" ColumnCount="1" GroupBoxDecoration="HeadingLine" Paddings-PaddingTop="3" ShowCaption="true" UseDefaultPaddings="false">
                    <Paddings PaddingTop="3px"></Paddings>
<%--                    <GroupBoxStyle>
                        <Caption CssClass="title" />
                    </GroupBoxStyle>--%>
                    <Items>
                        <dx:LayoutItem Caption="" ShowCaption="False" CaptionSettings-HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxGridView ID="Dgv_List" runat="server" AutoGenerateColumns="False" DataSourceID="SdsListCierre" KeyFieldName="ID_CDIA" Settings-HorizontalScrollBarMode="Visible">
                                        <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true"
                                            AllowHideDataCellsByColumnMinWidth="true">
                                        </SettingsAdaptivity>
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
                                        <Columns>
                                            <dx:GridViewDataTextColumn FieldName="ID_CDIA" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="0" Visible="false">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="ID_BODEP" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="1" Visible="false">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataDateColumn FieldName="ANIOFISCAL" Caption="Año Fiscal" Width="200" ShowInCustomizationForm="True" VisibleIndex="2">
                                            </dx:GridViewDataDateColumn > 
                                            <dx:GridViewDataDateColumn FieldName="NOMBRE_ZAFRA" Caption="zafra" Width="200" ShowInCustomizationForm="True" VisibleIndex="3">
                                            </dx:GridViewDataDateColumn > 
                                            <dx:GridViewDataDateColumn FieldName="DIAZAFRA" Caption="Dia Zafra" Width="200" ShowInCustomizationForm="True" VisibleIndex="4">
                                            </dx:GridViewDataDateColumn >   
                                            <dx:GridViewDataDateColumn FieldName="FECHA" Caption="Cierre a la fecha" Width="200" ShowInCustomizationForm="True" VisibleIndex="5">
                                            </dx:GridViewDataDateColumn >
                                            <dx:GridViewDataTextColumn FieldName="USU_CREA" Caption="Usuario que realizó el Cierre" Width="100%" ShowInCustomizationForm="True" VisibleIndex="6">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="FECHA_CREA" Caption="Momento en que se realizó el Cierre" Width="250" ShowInCustomizationForm="True" VisibleIndex="7">
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                    </dx:ASPxGridView>
                                    <asp:SqlDataSource ID="SdsListCierre" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>" SelectCommand="SEL_CIERRE_DIARIO" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="cb_bodegaO" Name="ID_BODEP" PropertyName="Value" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right" />
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
    </Items>
</dx:ASPxFormLayout>




<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantProductoBodega.ascx.cs" Inherits="ADMINPT.controles.producto.UcMantProductoBodega" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraReports.v20.1.Web.WebForms, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/controles/UCBarraNavegacion.ascx" TagPrefix="uc1" TagName="UCBarraNavegacion" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>


<uc1:UCBarraNavegacion runat="server" id="UCBarraNavegacion" />
<uc1:UCEncabezado runat="server" id="UCEncabezado" />
<dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server"></dx:ASPxFormLayout>
  <dx:ASPxFormLayout ID="FtListEmpresa" CssClass="modal-content" runat="server">
            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
            <Items>
                <dx:LayoutGroup Caption="" ColumnCount="3" ShowCaption="false" GroupBoxDecoration="Box"
                    UseDefaultPaddings="false" Paddings-PaddingTop="3">
                    <Paddings PaddingTop="3px"></Paddings>
                    <GroupBoxStyle>
                        <Caption CssClass="title" />
                    </GroupBoxStyle>
                    <Items>                     
                        <dx:LayoutItem Caption="" ShowCaption="False"  CaptionSettings-HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                   <dx:ASPxGridView ID="dxgvLista" runat="server" AutoGenerateColumns="False" EnableCallbacks="false" 
                                DataSourceID="sdsLista" KeyFieldName="ID_PRO_BODE"  >
                                <SettingsCommandButton>
                                    <NewButton RenderMode="Image">
                                        <Image IconID="miscellaneous_wizard_16x16"></Image>
                                    </NewButton>
                                    <EditButton RenderMode="Image">
                                        <Image IconID="edit_edit_16x16"></Image>
                                    </EditButton>
                                    <DeleteButton RenderMode="Image">
                                        <Image IconID="actions_cancel_16x16"></Image>
                                    </DeleteButton>
                                    <UpdateButton RenderMode="Image" Text="Guaradar">
                                        <Image IconID="save_save_16x16"></Image>
                                    </UpdateButton>
                                    <CancelButton RenderMode="Image">
                                        <Image IconID="history_undo_16x16"></Image>
                                    </CancelButton>
                                </SettingsCommandButton>
                                <SettingsPopup>
                                    <EditForm HorizontalAlign="Center" AllowResize="True" Modal="True" />
                                </SettingsPopup>
                                <SettingsLoadingPanel Text="Cargando&amp;hellip;" />
                                <SettingsPager>
                                    <Summary AllPagesText="Pags: {0} - {1} ({2} registros)"
                                        Text="Pag. {0} de {1} ({2} registros)" />
                                </SettingsPager>
                                <SettingsText GroupPanel="Arrastre la columna aqui para agrupar"
                                    EmptyDataRow="No existen registros para mostrar" />                             
                                <SettingsEditing EditFormColumnCount="1" Mode="PopupEditForm" />
                               <Settings ShowFilterRow="false" ShowHeaderFilterButton="false"  />
                                <SettingsBehavior EnableRowHotTrack="false" AllowFocusedRow="false"  />
                                        <SettingsSearchPanel Visible="true" />
                                <Columns>
                                    <dx:GridViewCommandColumn ShowInCustomizationForm="True" ShowNewButtonInHeader="True" VisibleIndex="0" ShowEditButton="True">
                                    </dx:GridViewCommandColumn>
                                     <dx:GridViewBandColumn  Caption="Producto Bodega Principal" >
                                         <Columns>
                                    <dx:GridViewDataTextColumn FieldName="ID_PRO_BODE" Caption="Id" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="1" >
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataComboBoxColumn FieldName="ID_PRODUCTO" Caption="Producto" ShowInCustomizationForm="True" VisibleIndex="2" >
                                         <PropertiesComboBox DataSourceID="sdsCbProduc" TextField="NOMBRE_KARDEX" ValueField="ID_PRODUCTO" DropDownStyle="DropDownList">  
                                         </PropertiesComboBox>  
                                        <EditFormSettings Visible="true" />
                                    </dx:GridViewDataComboBoxColumn>                                       
                                    <dx:GridViewDataComboBoxColumn FieldName="ID_BODEGA" Caption="Bodega" ShowInCustomizationForm="True" VisibleIndex="3" >
                                         <PropertiesComboBox DataSourceID="sdsCbBode" TextField="NOMBRE" ValueField="ID_BODEGA" DropDownStyle="DropDownList">  
                                         </PropertiesComboBox>
                                        <EditFormSettings Visible="true" />
                                    </dx:GridViewDataComboBoxColumn>
                                    <dx:GridViewDataCheckColumn FieldName="ESTADO"  Caption="Estado" ShowInCustomizationForm="True" VisibleIndex="10" PropertiesCheckEdit-ValueType="System.Boolean">
                                      <Settings AllowHeaderFilter="False" />
                                      <PropertiesCheckEdit ValueChecked="True" ValueUnchecked="False" />
                                    </dx:GridViewDataCheckColumn>
                                    <dx:GridViewCommandColumn Name="delete" Caption=" " ShowDeleteButton="True" ShowInCustomizationForm="True" VisibleIndex="10">
                                    </dx:GridViewCommandColumn>
                                             </Columns> 
                                             </dx:GridViewBandColumn>
                                </Columns>
                                <SettingsEditing Mode="PopupEditForm"></SettingsEditing>
                                <SettingsPopup EditForm-Modal="true"></SettingsPopup>
                                <StylesPopup>
                                    <EditForm ModalBackground-BackColor="Silver">
                                        <ModalBackground BackColor="Silver"></ModalBackground>
                                    </EditForm>
                                </StylesPopup>
                            </dx:ASPxGridView>
                            <asp:SqlDataSource ID="sdsLista" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>" 
                                SelectCommand="VIEW_PRODUCTO_BODE" SelectCommandType="StoredProcedure" 
                                InsertCommand="CRE_PRODUCTO_BODE" InsertCommandType="StoredProcedure"  
                                 DeleteCommand="DEL_PRODUCTO_BODE" DeleteCommandType="StoredProcedure" 
                               UpdateCommand="UPD_PRODUCTO_BODE" UpdateCommandType="StoredProcedure" >
                               <DeleteParameters>
                                    <asp:Parameter Name="ID_PRO_BODE" Type="Int32" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="ID_PRODUCTO" Type="Int32" />
                                    <asp:Parameter Name="ID_BODEGA" Type="Int32" />
                                    <asp:Parameter Name="ESTADO" Type="Boolean" /> 
                                </InsertParameters>  
                                 <UpdateParameters>
                                     <asp:Parameter Name="ID_PRO_BODE" Type="Int32" />
                                      <asp:Parameter Name="ID_PRODUCTO" Type="Int32" />
                                    <asp:Parameter Name="ID_BODEGA" Type="Int32" />
                                    <asp:Parameter Name="ESTADO" Type="Boolean" /> 
                                 </UpdateParameters>
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="sdsCbEmp" runat="server"   ConnectionString="<%$ ConnectionStrings:cn %>" 
                               SelectCommand="CB_EMPRESA" SelectCommandType="StoredProcedure" >
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="sdsCbProduc" runat="server"   ConnectionString="<%$ ConnectionStrings:cn %>" 
                               SelectCommand="CB_PRODUCTO" SelectCommandType="StoredProcedure" >
                            </asp:SqlDataSource>
                           <asp:SqlDataSource ID="sdsCbBode" runat="server"   ConnectionString="<%$ ConnectionStrings:cn %>" 
                               SelectCommand="CB_BODEACT" SelectCommandType="StoredProcedure" >
                            </asp:SqlDataSource>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                        </dx:LayoutItem>
             
                        <dx:LayoutItem Caption="" ShowCaption="False"  CaptionSettings-HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                   <dx:ASPxGridView ID="dxgvListaOrigen" runat="server" AutoGenerateColumns="False" EnableCallbacks="false" 
                                DataSourceID="sdsLista" KeyFieldName="ID_PRO_BODE"  >
                                <SettingsCommandButton>
                                    <NewButton RenderMode="Image">
                                        <Image IconID="miscellaneous_wizard_16x16"></Image>
                                    </NewButton>
                                    <EditButton RenderMode="Image">
                                        <Image IconID="edit_edit_16x16"></Image>
                                    </EditButton>
                                    <DeleteButton RenderMode="Image">
                                        <Image IconID="actions_cancel_16x16"></Image>
                                    </DeleteButton>
                                    <UpdateButton RenderMode="Image" Text="Guaradar">
                                        <Image IconID="save_save_16x16"></Image>
                                    </UpdateButton>
                                    <CancelButton RenderMode="Image">
                                        <Image IconID="history_undo_16x16"></Image>
                                    </CancelButton>
                                </SettingsCommandButton>
                                <SettingsPopup>
                                    <EditForm HorizontalAlign="Center" AllowResize="True" Modal="True" />
                                </SettingsPopup>
                                <SettingsLoadingPanel Text="Cargando&amp;hellip;" />
                                <SettingsPager>
                                    <Summary AllPagesText="Pags: {0} - {1} ({2} registros)"
                                        Text="Pag. {0} de {1} ({2} registros)" />
                                </SettingsPager>
                                <SettingsText GroupPanel="Arrastre la columna aqui para agrupar"
                                    EmptyDataRow="No existen registros para mostrar" />                             
                                <SettingsEditing EditFormColumnCount="1" Mode="PopupEditForm" />
                                <Settings ShowFilterRow="false" ShowHeaderFilterButton="false"  />
                                <SettingsBehavior EnableRowHotTrack="false" AllowFocusedRow="false"  />
                                        <SettingsSearchPanel Visible="true" />
                                <Columns>
                                    <dx:GridViewCommandColumn ShowInCustomizationForm="True" ShowNewButtonInHeader="True" VisibleIndex="0" ShowEditButton="True">
                                    </dx:GridViewCommandColumn>
                                     <dx:GridViewBandColumn  Caption="Producto Bodega Origen" >
                                         <Columns>
                                    <dx:GridViewDataTextColumn FieldName="ID_PRO_BODE" Caption="Id" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="1" >
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataComboBoxColumn FieldName="ID_PRODUCTO" Caption="Producto" ShowInCustomizationForm="True" VisibleIndex="2" >
                                         <PropertiesComboBox DataSourceID="sdsCbProduc" TextField="NOMBRE_KARDEX" ValueField="ID_PRODUCTO" DropDownStyle="DropDownList">  
                                         </PropertiesComboBox>  
                                        <EditFormSettings Visible="true" />
                                    </dx:GridViewDataComboBoxColumn>                                       
                                    <dx:GridViewDataComboBoxColumn FieldName="ID_BODEGA" Caption="Bodega" ShowInCustomizationForm="True" VisibleIndex="3" >
                                         <PropertiesComboBox DataSourceID="sdsCbBode" TextField="NOMBRE" ValueField="ID_BODEGA" DropDownStyle="DropDownList">  
                                         </PropertiesComboBox>
                                        <EditFormSettings Visible="true" />
                                    </dx:GridViewDataComboBoxColumn>
                                    <dx:GridViewDataCheckColumn FieldName="ESTADO"  Caption="Estado" ShowInCustomizationForm="True" VisibleIndex="10" PropertiesCheckEdit-ValueType="System.Boolean">
                                      <Settings AllowHeaderFilter="False" />
                                      <PropertiesCheckEdit ValueChecked="True" ValueUnchecked="False" />
                                    </dx:GridViewDataCheckColumn>
                                    <dx:GridViewCommandColumn Name="delete" Caption=" " ShowDeleteButton="True" ShowInCustomizationForm="True" VisibleIndex="10">
                                    </dx:GridViewCommandColumn>
                                              </Columns> 
                                             </dx:GridViewBandColumn>
                                </Columns>
                                <SettingsEditing Mode="PopupEditForm"></SettingsEditing>
                                <SettingsPopup EditForm-Modal="true"></SettingsPopup>
                                <StylesPopup>
                                    <EditForm ModalBackground-BackColor="Silver">
                                        <ModalBackground BackColor="Silver"></ModalBackground>
                                    </EditForm>
                                </StylesPopup>
                            </dx:ASPxGridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>" 
                                SelectCommand="VIEW_PRODUCTO_BODE" SelectCommandType="StoredProcedure" 
                                InsertCommand="CRE_PRODUCTO_BODE" InsertCommandType="StoredProcedure"  
                                 DeleteCommand="DEL_PRODUCTO_BODE" DeleteCommandType="StoredProcedure" 
                               UpdateCommand="UPD_PRODUCTO_BODE" UpdateCommandType="StoredProcedure" >
                               <DeleteParameters>
                                    <asp:Parameter Name="ID_PRO_BODE" Type="Int32" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="ID_PRODUCTO" Type="Int32" />
                                    <asp:Parameter Name="ID_BODEGA" Type="Int32" />
                                    <asp:Parameter Name="ESTADO" Type="Boolean" /> 
                                </InsertParameters>  
                                 <UpdateParameters>
                                     <asp:Parameter Name="ID_PRO_BODE" Type="Int32" />
                                      <asp:Parameter Name="ID_PRODUCTO" Type="Int32" />
                                    <asp:Parameter Name="ID_BODEGA" Type="Int32" />
                                    <asp:Parameter Name="ESTADO" Type="Boolean" /> 
                                 </UpdateParameters>
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server"   ConnectionString="<%$ ConnectionStrings:cn %>" 
                               SelectCommand="CB_EMPRESA" SelectCommandType="StoredProcedure" >
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource3" runat="server"   ConnectionString="<%$ ConnectionStrings:cn %>" 
                               SelectCommand="CB_PRODUCTO" SelectCommandType="StoredProcedure" >
                            </asp:SqlDataSource>
                           <asp:SqlDataSource ID="SqlDataSource4" runat="server"   ConnectionString="<%$ ConnectionStrings:cn %>" 
                               SelectCommand="CB_BODEACT" SelectCommandType="StoredProcedure" >
                            </asp:SqlDataSource>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                        </dx:LayoutItem>

                         <dx:LayoutItem Caption="" ShowCaption="False"  CaptionSettings-HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                   <dx:ASPxGridView ID="dxgvListaDestino" runat="server" AutoGenerateColumns="False" EnableCallbacks="false" 
                                DataSourceID="sdsLista" KeyFieldName="ID_PRO_BODE" >
                                <SettingsCommandButton>
                                    <NewButton RenderMode="Image">
                                        <Image IconID="miscellaneous_wizard_16x16"></Image>
                                    </NewButton>
                                    <EditButton RenderMode="Image">
                                        <Image IconID="edit_edit_16x16"></Image>
                                    </EditButton>
                                    <DeleteButton RenderMode="Image">
                                        <Image IconID="actions_cancel_16x16"></Image>
                                    </DeleteButton>
                                    <UpdateButton RenderMode="Image" Text="Guaradar">
                                        <Image IconID="save_save_16x16"></Image>
                                    </UpdateButton>
                                    <CancelButton RenderMode="Image">
                                        <Image IconID="history_undo_16x16"></Image>
                                    </CancelButton>
                                </SettingsCommandButton>
                                <SettingsPopup>
                                    <EditForm HorizontalAlign="Center" AllowResize="True" Modal="True" />
                                </SettingsPopup>
                                <SettingsLoadingPanel Text="Cargando&amp;hellip;" />
                                <SettingsPager>
                                    <Summary AllPagesText="Pags: {0} - {1} ({2} registros)"
                                        Text="Pag. {0} de {1} ({2} registros)" />
                                </SettingsPager>
                                <SettingsText GroupPanel="Arrastre la columna aqui para agrupar"
                                    EmptyDataRow="No existen registros para mostrar" />                             
                                <SettingsEditing EditFormColumnCount="1" Mode="PopupEditForm" />
                                <Settings ShowFilterRow="false" ShowHeaderFilterButton="false"  />
                                <SettingsBehavior EnableRowHotTrack="false" AllowFocusedRow="false"  />
                                        <SettingsSearchPanel Visible="true" />
                                <Columns>
                                    <dx:GridViewCommandColumn ShowInCustomizationForm="True" ShowNewButtonInHeader="True" VisibleIndex="0" ShowEditButton="True">
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewBandColumn  Caption="Producto Bodega Destino" >
                                        <Columns>
                                    <dx:GridViewDataTextColumn FieldName="ID_PRO_BODE" Caption="Id" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="1" >
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataComboBoxColumn FieldName="ID_PRODUCTO" Caption="Producto" ShowInCustomizationForm="True" VisibleIndex="2" >
                                         <PropertiesComboBox DataSourceID="sdsCbProduc" TextField="NOMBRE_KARDEX" ValueField="ID_PRODUCTO" DropDownStyle="DropDownList">  
                                         </PropertiesComboBox>  
                                        <EditFormSettings Visible="true" />
                                    </dx:GridViewDataComboBoxColumn>                                       
                                    <dx:GridViewDataComboBoxColumn FieldName="ID_BODEGA" Caption="Bodega" ShowInCustomizationForm="True" VisibleIndex="3" >
                                         <PropertiesComboBox DataSourceID="sdsCbBode" TextField="NOMBRE" ValueField="ID_BODEGA" DropDownStyle="DropDownList">  
                                         </PropertiesComboBox>
                                        <EditFormSettings Visible="true" />
                                    </dx:GridViewDataComboBoxColumn>
                                    <dx:GridViewDataCheckColumn FieldName="ESTADO"  Caption="Estado" ShowInCustomizationForm="True" VisibleIndex="10" PropertiesCheckEdit-ValueType="System.Boolean">
                                      <Settings AllowHeaderFilter="False" />
                                      <PropertiesCheckEdit ValueChecked="True" ValueUnchecked="False" />
                                    </dx:GridViewDataCheckColumn>
                                    <dx:GridViewCommandColumn Name="delete" Caption=" " ShowDeleteButton="True" ShowInCustomizationForm="True" VisibleIndex="10">
                                    </dx:GridViewCommandColumn>
                                            </Columns>
                                    </dx:GridViewBandColumn>
                                </Columns>
                                <SettingsEditing Mode="PopupEditForm"></SettingsEditing>
                                <SettingsPopup EditForm-Modal="true"></SettingsPopup>
                                <StylesPopup>
                                    <EditForm ModalBackground-BackColor="Silver">
                                        <ModalBackground BackColor="Silver"></ModalBackground>
                                    </EditForm>
                                </StylesPopup>
                            </dx:ASPxGridView>
                            <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>" 
                                SelectCommand="VIEW_PRODUCTO_BODE" SelectCommandType="StoredProcedure" 
                                InsertCommand="CRE_PRODUCTO_BODE" InsertCommandType="StoredProcedure"  
                                 DeleteCommand="DEL_PRODUCTO_BODE" DeleteCommandType="StoredProcedure" 
                               UpdateCommand="UPD_PRODUCTO_BODE" UpdateCommandType="StoredProcedure" >
                               <DeleteParameters>
                                    <asp:Parameter Name="ID_PRO_BODE" Type="Int32" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="ID_PRODUCTO" Type="Int32" />
                                    <asp:Parameter Name="ID_BODEGA" Type="Int32" />
                                    <asp:Parameter Name="ESTADO" Type="Boolean" /> 
                                </InsertParameters>  
                                 <UpdateParameters>
                                     <asp:Parameter Name="ID_PRO_BODE" Type="Int32" />
                                      <asp:Parameter Name="ID_PRODUCTO" Type="Int32" />
                                    <asp:Parameter Name="ID_BODEGA" Type="Int32" />
                                    <asp:Parameter Name="ESTADO" Type="Boolean" /> 
                                 </UpdateParameters>
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource6" runat="server"   ConnectionString="<%$ ConnectionStrings:cn %>" 
                               SelectCommand="CB_EMPRESA" SelectCommandType="StoredProcedure" >
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource7" runat="server"   ConnectionString="<%$ ConnectionStrings:cn %>" 
                               SelectCommand="CB_PRODUCTO" SelectCommandType="StoredProcedure" >
                            </asp:SqlDataSource>
                           <asp:SqlDataSource ID="SqlDataSource8" runat="server"   ConnectionString="<%$ ConnectionStrings:cn %>" 
                               SelectCommand="CB_BODEACT" SelectCommandType="StoredProcedure" >
                            </asp:SqlDataSource>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                        </dx:LayoutItem>

                    </Items>
                </dx:LayoutGroup>
            </Items>
        </dx:ASPxFormLayout>

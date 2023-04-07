<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantEliminarProduccion.ascx.cs" Inherits="ADMINPT.controles.movimientos_bulto.UcMantEliminarProduccion" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>
<%@ Register Src="~/controles/UCBarraNavegacion.ascx" TagPrefix="uc1" TagName="UCBarraNavegacion" %>


<uc1:UCBarraNavegacion runat="server" id="UCBarraNavegacion" />
<uc1:UCEncabezado runat="server" id="UCEncabezado" />
<dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" CssClass="formLayout">
    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="700" />
    <Items>
          <dx:LayoutGroup Caption="Datos de Producción" Name="Saldo"   ColCount="2" GroupBoxDecoration="Box" UseDefaultPaddings="false" Paddings-PaddingTop="2">
<Paddings PaddingTop="2px"></Paddings>
            <GroupBoxStyle>
                <Caption Font-Bold="true" Font-Size="10" />
            </GroupBoxStyle>
            <Items>
 <dx:LayoutItem Caption="Fecha">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxDateEdit ID="dteFecha" runat="server" EditFormat="Custom" EditFormatString="dd/MM/yyyy" ClientEnabled="false" >
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxDateEdit>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                 <dx:LayoutItem Caption="Horario" CaptionStyle-Font-Bold="true" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                           <dx:ASPxComboBox ID="cbHorario" runat="server"  TextField="NOMBREDT" ValueField="ID_ORDEN_TRAS" ValueType="System.Int32" AutoPostBack="true"  Border-BorderColor="#20c997">
                              <Border BorderColor="#20C997"></Border>
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <Items>
                                    <dx:ListEditItem Text="06:00 A.M. A 02:00 P.M." Value="1" />
                                    <dx:ListEditItem Text="02:00 P.M. A 10:00 P.M." Value="2" />
                                    <dx:ListEditItem Text="10:00 P.M. A 06:00 A.M." Value="3" />
                                </Items>
                                <ClearButton DisplayMode="Always"></ClearButton>
                              
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>

<CaptionStyle Font-Bold="True"></CaptionStyle>
                </dx:LayoutItem>
                  <dx:LayoutItem Caption="Producto" ColumnSpan="2"  Width="100%" CaptionStyle-Font-Bold="true" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxProducto"   runat="server" DataSourceID="SdsListProd" TextField="NOMBRE_KARDEX" ValueField="ID_PRODUCTO" ValueType="System.Int32" AutoPostBack="true"    >
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                             <asp:SqlDataSource ID="SdsListProd" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>" SelectCommand="CB_PROD_PRODUCCIONF" SelectCommandType="StoredProcedure">
                                 <SelectParameters>
                                     <asp:ControlParameter ControlID="dteFecha" Name="FECHA" PropertyName="Value" Type="DateTime" />
                                 </SelectParameters>
                             </asp:SqlDataSource>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>

<CaptionStyle Font-Bold="True"></CaptionStyle>
                </dx:LayoutItem>
                 <dx:LayoutItem Caption=""  ColumnSpan="2" ShowCaption="False" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxGridView ID="Dgv_list" runat="server" DataSourceID="sdtListview" AutoGenerateColumns="False"
                                KeyFieldName="ID_ES_DETA;ID_ES_ENCA;FECHA">
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
                                    <dx:GridViewDataTextColumn FieldName="NRow" Caption="N°" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="0">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataDateColumn FieldName="FECHA" Name="FECHA" Caption="Fecha" ShowInCustomizationForm="True" VisibleIndex="1">
                                    </dx:GridViewDataDateColumn>
                                    <dx:GridViewDataTextColumn FieldName="ID_BODEGAO" Visible="false" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="2">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ID_BODEGAD" Visible="false" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="3">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="NOMBRE_PRODUCTO" Visible="false" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="4">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="TNOMBRE" Caption="Tarima" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="5">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="NOM_ZAFRA" Caption="Zafra" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="6">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="CANTIDAD" Caption="Cantidad" ShowInCustomizationForm="True" VisibleIndex="7">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="HORARIO" Caption="Horario" ShowInCustomizationForm="True" VisibleIndex="8">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTimeEditColumn FieldName="HORA" Caption="Hora" ShowInCustomizationForm="True" VisibleIndex="8">
                                    </dx:GridViewDataTimeEditColumn>
                                    <dx:GridViewDataTextColumn FieldName="ID_ES_ENCA" Name="ID_ES_ENCA"  ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="9">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ID_ES_DETA" Name="ID_ES_DETA" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="10">
                                    </dx:GridViewDataTextColumn>
                                 <dx:GridViewCommandColumn Name="delete" Caption=" " ShowDeleteButton="True" ShowInCustomizationForm="True" VisibleIndex="10">
                                    </dx:GridViewCommandColumn>                                            
                                </Columns>
                                <SettingsEditing Mode="PopupEditForm"></SettingsEditing>
                                <SettingsPopup EditForm-Modal="true"></SettingsPopup>
                                <StylesPopup>
                                    <EditForm ModalBackground-BackColor="Silver">
                                        <ModalBackground BackColor="Silver"></ModalBackground>
                                    </EditForm>
                                </StylesPopup>
                            </dx:ASPxGridView>
                            <asp:SqlDataSource ID="sdtListview" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>" 
                                SelectCommand="VIEW_DEL_PRODUCCION" SelectCommandType="StoredProcedure"
                                 DeleteCommand="DEL_PRODUCCION" DeleteCommandType="StoredProcedure" >
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="cbxProducto" Name="ID_PRODUCTO" PropertyName="Value" Type="Int32" />
                                    <asp:ControlParameter ControlID="dteFecha" DbType="Date" Name="FECHA" PropertyName="Value" />
                                    <asp:ControlParameter ControlID="cbHorario" Name="HORARIO" PropertyName="Value" Type="String" />
                                </SelectParameters>
                                <DeleteParameters>
                                    <asp:Parameter Name="ID_ES_DETA" Type="Int32" />
                                     <asp:Parameter Name="ID_ES_ENCA" Type="Int32" />
                                     <asp:Parameter Name="FECHA" Type="DateTime" />
                                     <asp:ControlParameter ControlID="cbxProducto" Name="ID_PRODUCTO" PropertyName="Value" Type="Int32" />
                                </DeleteParameters>
                            </asp:SqlDataSource>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                 </Items>
        </dx:LayoutGroup>
        </Items>
</dx:ASPxFormLayout>

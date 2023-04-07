<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcListaENTRADA_SALIDA_DETA_VTADIZUCAR.ascx.cs" Inherits="ADMINPT.controles.movimento_vtadizucar.UcListaENTRADA_SALIDA_DETA_VTADIZUCAR" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<dx:ASPxGridView ID="gridLista" runat="server" Theme="Moderno" KeyFieldName="ID_ES_DETA" OnInit="gridLista_Init" EnableCallBacks="false" 
    OnRowCommand="gridLista_RowCommand" OnCustomUnboundColumnData="gridLista_CustomUnboundColumnData" 
    OnRowDeleting="gridLista_RowDeleting" OnRowDeleted="gridLista_RowDeleted">
    <SettingsPager>
        <Summary AllPagesText="Pags: {0} - {1} ({2} registros)" 
            Text="Pag. {0} de {1} ({2} registros)" />
    </SettingsPager>
                                <SettingsCommandButton>
                                    <NewButton RenderMode="Image" Text="Nuevo">
                                        <Image IconID="miscellaneous_wizard_16x16"></Image>
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
    <Columns>
        <dx:GridViewCommandColumn ShowSelectCheckbox="True" Name="CheckSeleccionar" Caption=" " Width="10px" Visible="false" VisibleIndex="0" ShowDeleteButton="True" />
        <dx:GridViewDataTextColumn Visible="true" Caption="Editar" Name="Editar" CellStyle-HorizontalAlign="Center" Width="40px" VisibleIndex="1"  >
            <DataItemTemplate>
                <asp:ImageButton ID="lbtnEditar" runat="server" CommandName="Editar" ImageUrl="~/imagenes/Editar.png"  CommandArgument='<%# Bind("ID_ES_DETA") %>'></asp:ImageButton>                                
            </DataItemTemplate>

<CellStyle HorizontalAlign="Center"></CellStyle>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="ID_ES_DETA"  VisibleIndex="1" Width="20px" Caption="Identificador" Visible="false" />
        <dx:GridViewDataTextColumn FieldName="ID_PRODUCTO" VisibleIndex="2" Caption="IdProducto" Visible="false"/>
        <dx:GridViewDataTextColumn FieldName="NOMBRE_PRODUCTO" VisibleIndex="3" Caption="Producto" UnboundType="String" />
        <dx:GridViewDataTextColumn FieldName="ID_PRESEN_TRAS" VisibleIndex="4" Caption="IdPresenTras" Visible="false"/>
        <dx:GridViewDataTextColumn FieldName="NOMBRE_PRESEN_TRAA" VisibleIndex="5" Caption="Presentación" UnboundType="String" Visible="true" />  
        <dx:GridViewDataTextColumn FieldName="ID_UNIDAD_FAC" VisibleIndex="6" Caption="IdUnidad" Visible="false"/> 
        <dx:GridViewDataTextColumn FieldName="NOMBRE_UNIDAD" VisibleIndex="7" Caption="Unidad" UnboundType="String" Visible="true" />  
        <dx:GridViewDataTextColumn FieldName="CANTIDAD" VisibleIndex="8" Caption="Cantidad" Visible="true" />
        <dx:GridViewDataTextColumn FieldName="FACTOR" VisibleIndex="9" Caption="Factor" Visible="true" />
        <dx:GridViewDataTextColumn FieldName="REFERENCIA_DETA" VisibleIndex="10" Caption="Factor" Visible="false" />
         
        
   </Columns>
                                <SettingsBehavior ConfirmDelete="true" EnableCustomizationWindow="true" EnableRowHotTrack="true" />
                                <SettingsText ConfirmDelete="¿Estás seguro de que quieres eliminar?" />
</dx:ASPxGridView>

<asp:ObjectDataSource ID="odsLista" runat="server" SelectMethod="ObtenerLista"  TypeName="ADMINPT.BL.CMOVIMIENTO_ENCA">    
</asp:ObjectDataSource>
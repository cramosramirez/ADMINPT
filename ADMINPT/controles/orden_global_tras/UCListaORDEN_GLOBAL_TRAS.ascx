<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCListaORDEN_GLOBAL_TRAS.ascx.cs" Inherits="ADMINPT.controles.orden_global_tras.UCListaORDEN_GLOBAL_TRAS" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<dx:ASPxGridView ID="gridLista" runat="server" Theme="Moderno" KeyFieldName="ID_ORDEN_TRAS" Width="100%" Font-Size ="X-Small"
    OnInit="gridLista_Init" DataSourceID="odsLista" OnRowCommand="gridLista_RowCommand" OnCustomUnboundColumnData="gridLista_CustomUnboundColumnData">
    <SettingsPager>
        <Summary AllPagesText="Pags: {0} - {1} ({2} registros)" 
            Text="Pag. {0} de {1} ({2} registros)" />
    </SettingsPager>
    <Columns>
        <dx:GridViewCommandColumn ShowSelectCheckbox="True" Name="CheckSeleccionar" Caption=" " Width="10px" Visible="false" VisibleIndex="0" />
        <dx:GridViewDataTextColumn Visible="true" Caption="Editar" Name="Editar" CellStyle-HorizontalAlign="Center" Width="40px" VisibleIndex="1"  >
            <DataItemTemplate>
                <asp:ImageButton ID="lbtnEditar" runat="server" CommandName="Editar" ImageUrl="~/imagenes/Editar.png"  CommandArgument='<%# Bind("ID_ORDEN_TRAS") %>'></asp:ImageButton>                                
            </DataItemTemplate>
        </dx:GridViewDataTextColumn>
         <dx:GridViewDataCheckColumn FieldName="AC" VisibleIndex="2" Caption="Activa" UnboundType="Boolean" HeaderStyle-HorizontalAlign="Center" />
         <dx:GridViewDataCheckColumn FieldName="FN" VisibleIndex="3" Caption="Finalizada" UnboundType="Boolean" HeaderStyle-HorizontalAlign="Center" />
        <dx:GridViewDataTextColumn FieldName="ID_ORDEN_TRAS" ReadOnly="True" VisibleIndex="4" Width="20px" Caption="Nº Sistema(id)" />
        <dx:GridViewDataDateColumn Caption="Fecha" FieldName="FECHA" VisibleIndex="4">
            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy">
            </PropertiesDateEdit>
        </dx:GridViewDataDateColumn>
        <dx:GridViewDataTextColumn FieldName="TPREF" VisibleIndex="5" Caption="Tipo Referencia" UnboundType="String" />
         <dx:GridViewDataTextColumn FieldName="NUMREF" ReadOnly="True" VisibleIndex="6" Caption="N°"  />
        <dx:GridViewDataTextColumn FieldName="BODEGAO" VisibleIndex="7" Caption="Bodega Origen" UnboundType="String" />
        <dx:GridViewDataTextColumn FieldName="PRODUCTO" VisibleIndex="8" Caption="Producto" UnboundType="String" />
        <dx:GridViewDataTextColumn FieldName="BODEGAD" VisibleIndex="9" Caption="Bodega Destino" UnboundType="String" />
        <dx:GridViewDataTextColumn FieldName="ASIGNACIONO" ReadOnly="True" VisibleIndex="10" Caption="Asignacion Original"   />
        <dx:GridViewDataTextColumn FieldName="AMPLIACIONES" ReadOnly="True" VisibleIndex="11" Caption="Ampliaciones"   />
        <dx:GridViewDataTextColumn FieldName="ASIGNACIONT" ReadOnly="True" VisibleIndex="12" Caption="Asignacion Total"   />
        <dx:GridViewDataTextColumn FieldName="EJECUTADO" ReadOnly="True" VisibleIndex="13" Caption="Ejecutado"   />
        <dx:GridViewDataTextColumn FieldName="SALDO" ReadOnly="True" VisibleIndex="14" Caption="Saldo"   />

        <dx:GridViewDataCheckColumn FieldName="ESTADO" VisibleIndex="19"  Visible="false"  />
        <dx:GridViewDataTextColumn FieldName="ID_REF" ReadOnly="True" VisibleIndex="20" Caption="" Visible="false"  />
        <dx:GridViewDataTextColumn FieldName="ID_BODEGAO" ReadOnly="True" VisibleIndex="20" Caption="" Visible="false"  />
        <dx:GridViewDataTextColumn FieldName="ID_PRODUCTO" ReadOnly="True" VisibleIndex="20" Caption="" Visible="false"  />
        <dx:GridViewDataTextColumn FieldName="ID_BODEGAD" ReadOnly="True" VisibleIndex="20" Caption="" Visible="false"  />
    </Columns>
</dx:ASPxGridView>

<asp:ObjectDataSource ID="odsLista" runat="server" SelectMethod="ObtenerLista"  TypeName="ADMINPT.BL.CORDEN_GLOBAL_TRAS">    
    <SelectParameters>
        <%-- <asp:Parameter Name="ID_ORDEN_TRAS" DefaultValue="-1" Type="Int32" />--%>
         <asp:SessionParameter Name="ID_BODEP" SessionField="ID_BODEP" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
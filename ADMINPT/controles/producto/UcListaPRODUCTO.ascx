<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcListaPRODUCTO.ascx.cs" Inherits="ADMINPT.controles.producto.UcListaPRODUCTO" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<dx:ASPxGridView ID="gridLista" runat="server" Theme="Moderno" KeyFieldName="ID_PRODUCTO" Width="100%" OnInit="gridLista_Init" OnRowCommand="gridLista_RowCommand" OnCustomUnboundColumnData="gridLista_CustomUnboundColumnData"  >
    <SettingsPager>
        <Summary AllPagesText="Pags: {0} - {1} ({2} registros)" 
            Text="Pag. {0} de {1} ({2} registros)" />
    </SettingsPager>
    <Columns>
        <dx:GridViewCommandColumn ShowSelectCheckbox="True" Name="CheckSeleccionar" Caption=" " Width="10px" Visible="false" VisibleIndex="0" />
        <dx:GridViewDataTextColumn Visible="true" Caption="Editar" Name="Editar" CellStyle-HorizontalAlign="Center" Width="20px" VisibleIndex="1"  >
            <DataItemTemplate>
                <asp:ImageButton ID="lbtnEditar" runat="server" CommandName="Editar" ImageUrl="~/imagenes/Editar.png"  CommandArgument='<%# Bind("ID_PRODUCTO") %>'></asp:ImageButton>                                
            </DataItemTemplate>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="ID_PRODUCTO" ReadOnly="True" VisibleIndex="2" Width="20px" Caption="Identificador" />
        <dx:GridViewDataTextColumn FieldName="CODI_PRODUCTO" VisibleIndex="2" Caption="Código"/>
        <dx:GridViewDataTextColumn FieldName="NOMBRE_PRODUCTO" VisibleIndex="3" Caption="Nombre producto" />        
        <dx:GridViewDataTextColumn FieldName="NOMBRE_KARDEX" VisibleIndex="4" Caption="Nombre en kardex" />  
        <dx:GridViewDataTextColumn FieldName="NOMBRE_VENTA" VisibleIndex="5" Caption="Nombre de venta" />  
        <dx:GridViewDataTextColumn FieldName="TIPO_PRODUCTO" VisibleIndex="6" Caption="Tipo producto" UnboundType="String" />  
        <dx:GridViewDataTextColumn FieldName="UNIDAD_CONSAA" VisibleIndex="7" Caption="Unidad según CONSAA" UnboundType="String" />  
        <dx:GridViewDataTextColumn FieldName="UNIDAD_FAC" VisibleIndex="8" Caption="Unidad para Fact." UnboundType="String" /> 
        <dx:GridViewDataTextColumn FieldName="MARCA" VisibleIndex="9" Caption="Marca" UnboundType="String" /> 
        <dx:GridViewDataCheckColumn FieldName="APLICA_VTA" VisibleIndex="10" Caption="Aplica Vta." /> 
        <dx:GridViewDataCheckColumn FieldName="APLICA_TRAS" VisibleIndex="11" Caption="Aplica Tras." /> 
    </Columns>
</dx:ASPxGridView>

<asp:ObjectDataSource ID="odsLista" runat="server" SelectMethod="ObtenerLista"  TypeName="ADMINPT.BL.CPRODUCTO">    
</asp:ObjectDataSource>
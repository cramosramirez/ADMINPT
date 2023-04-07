<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcListaENTRADA_SALIDA_ENCA_VTADIZUCAR.ascx.cs" Inherits="ADMINPT.controles.movimento_vtadizucar.UcListaENTRADA_SALIDA_ENCA_VTADIZUCAR" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<dx:ASPxGridView ID="gridLista" runat="server" Theme="Moderno" KeyFieldName="ID_ES_ENCA" OnInit="gridLista_Init" OnRowCommand="gridLista_RowCommand" OnCustomUnboundColumnData="gridLista_CustomUnboundColumnData" AutoGenerateColumns="False"  >
    <SettingsPager>
        <Summary AllPagesText="Pags: {0} - {1} ({2} registros)" 
            Text="Pag. {0} de {1} ({2} registros)" />
    </SettingsPager>
    <Columns>
        <dx:GridViewCommandColumn ShowSelectCheckbox="True" Name="CheckSeleccionar" Caption=" " Width="10px" Visible="false" VisibleIndex="0" />
        <dx:GridViewDataTextColumn Visible="true" Caption="Editar" Name="Editar" CellStyle-HorizontalAlign="Center" Width="40px" VisibleIndex="1"  >
            <DataItemTemplate>
                <asp:ImageButton ID="lbtnEditar" runat="server" CommandName="Editar" ImageUrl="~/imagenes/Editar.png"  CommandArgument='<%# Bind("ID_ES_ENCA") %>'></asp:ImageButton>                                
            </DataItemTemplate>

<CellStyle HorizontalAlign="Center"></CellStyle>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="ID_ES_ENCA" ReadOnly="True" VisibleIndex="2" Width="20px" Caption="Identificador" />

         <dx:GridViewDataTextColumn FieldName="ID_BODEGAO" VisibleIndex="5" Caption="IdBodega" Visible="false"/>
         <dx:GridViewDataTextColumn FieldName="ID_BODEGAD" VisibleIndex="5" Caption="IdBodega" Visible="false"/>
        <dx:GridViewDataTextColumn FieldName="NOMBRE_BODEGA" VisibleIndex="6" Caption="Bodega" UnboundType="String"/>

        <dx:GridViewDataTextColumn FieldName="ID_PRODUCTO" VisibleIndex="7" Caption="Identificador" Visible="false"  />
        <dx:GridViewDataTextColumn FieldName="NOMBRE_PRODUCTO" VisibleIndex="8" Caption="Producto" UnboundType="String"/>
        <dx:GridViewDataTextColumn FieldName="ID_ZAFRA_ACTUAL" VisibleIndex="3" Caption="IdZafra" Visible="False"/>
         <dx:GridViewDataDateColumn Caption="Fecha" FieldName="FECHA" VisibleIndex="4">
            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy">
            </PropertiesDateEdit>
        </dx:GridViewDataDateColumn>
        <dx:GridViewDataTextColumn FieldName="NOMBRE_ZAFRA" VisibleIndex="4" Caption="Zafra" UnboundType="String"/>

        <dx:GridViewDataTextColumn FieldName="ID_TIPO_MOV" VisibleIndex="5" Caption="IdTM" Visible="false"/> 
        <dx:GridViewDataTextColumn FieldName="NOMBRE_MOV" VisibleIndex="6" Caption="Tipo Movimiento" UnboundType="String" Visible="true" /> 

        <dx:GridViewDataTextColumn FieldName="ID_ESPECI" VisibleIndex="7" Caption="IdEspecifi" Visible="false"/> 
        <dx:GridViewDataTextColumn FieldName="NOMBRE_ESPECI" VisibleIndex="8" Caption="Especifico" UnboundType="String" Visible="true" />  

        <dx:GridViewDataTextColumn FieldName="NUM_DOC" VisibleIndex="9" Caption="# Documento" UnboundType="String" Visible="true" />         
        
        <dx:GridViewDataTextColumn FieldName="CANTIDAD" VisibleIndex="9" Caption="Cantidad" UnboundType="String" Visible="true" />


   </Columns>
</dx:ASPxGridView>

<asp:ObjectDataSource ID="odsLista" runat="server" SelectMethod="ObtenerListaVtacDizucar"  TypeName="ADMINPT.BL.CENTRADA_SALIDA_ENCA">    
</asp:ObjectDataSource>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcListaPRODUCTO_PRES_VTA.ascx.cs" Inherits="ADMINPT.controles.producto_pres_vta.UcListaPRODUCTO_PRES_VTA" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<dx:ASPxGridView ID="gridLista" runat="server" Theme="Moderno" KeyFieldName="ID_PROD_PRES_VTA" Width="100%" OnInit="gridLista_Init"
    OnRowCommand="gridLista_RowCommand" OnCustomUnboundColumnData="gridLista_CustomUnboundColumnData"  >
    <SettingsPager>
        <Summary AllPagesText="Pags: {0} - {1} ({2} registros)" 
            Text="Pag. {0} de {1} ({2} registros)" />
    </SettingsPager>
    <Columns>
        <dx:GridViewCommandColumn ShowSelectCheckbox="True" Name="CheckSeleccionar" Caption=" " Width="10px" Visible="false" VisibleIndex="0" />
        <dx:GridViewDataTextColumn Visible="true" Caption="Editar" Name="Editar" CellStyle-HorizontalAlign="Center" Width="40px" VisibleIndex="1"  >
            <DataItemTemplate>
                <asp:ImageButton ID="lbtnEditar" runat="server" CommandName="Editar" ImageUrl="~/imagenes/Editar.png"  CommandArgument='<%# Bind("ID_PROD_PRES_VTA") %>'></asp:ImageButton>                                
            </DataItemTemplate>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="ID_PROD_PRES_VTA" ReadOnly="True" VisibleIndex="2" Width="20px" Caption="Identificador" />
        <dx:GridViewDataTextColumn FieldName="ID_PRODUCTO" VisibleIndex="2" Caption="Identificador" Visible="false"  />
        <dx:GridViewDataTextColumn FieldName="NOMBRE_PRODUCTO" VisibleIndex="2" Caption="Producto"  UnboundType="String"   />
        <dx:GridViewDataTextColumn FieldName="ID_PRESEN_VTA" VisibleIndex="3" Caption="Identificador"  Visible="false" />
        <dx:GridViewDataTextColumn FieldName="NOMBRE_PRESEN_VTA" VisibleIndex="3" Caption="Presentación"  UnboundType="String"  />
        <dx:GridViewDataCheckColumn FieldName="ESTADO" VisibleIndex="4" Caption="Activo" HeaderStyle-HorizontalAlign="Center"  />
    </Columns>
</dx:ASPxGridView>

<asp:ObjectDataSource ID="odsLista" runat="server" SelectMethod="ObtenerLista"  TypeName="ADMINPT.BL.CPRODUCTO_PRES_VTA">    
</asp:ObjectDataSource>
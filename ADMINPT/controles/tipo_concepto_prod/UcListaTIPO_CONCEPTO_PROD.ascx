<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcListaTIPO_CONCEPTO_PROD.ascx.cs" Inherits="ADMINPT.controles.tipo_concepto_prod.UcListaTIPO_CONCEPTO_PROD" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<dx:ASPxGridView ID="gridLista" runat="server" Theme="Moderno" KeyFieldName="ID_CONCEPTO_PROD" Width="100%" OnInit="gridLista_Init" OnRowCommand="gridLista_RowCommand" OnCustomUnboundColumnData="gridLista_CustomUnboundColumnData"  >
    <SettingsPager>
        <Summary AllPagesText="Pags: {0} - {1} ({2} registros)" 
            Text="Pag. {0} de {1} ({2} registros)" />
    </SettingsPager>
    <Columns>
        <dx:GridViewCommandColumn ShowSelectCheckbox="True" Name="CheckSeleccionar" Caption=" " Width="10px" Visible="false" VisibleIndex="0" />
        <dx:GridViewDataTextColumn Visible="true" Caption="Editar" Name="Editar" CellStyle-HorizontalAlign="Center" Width="20px" VisibleIndex="1"  >
            <DataItemTemplate>
                <asp:ImageButton ID="lbtnEditar" runat="server" CommandName="Editar" ImageUrl="~/imagenes/Editar.png"  CommandArgument='<%# Bind("ID_CONCEPTO_PROD") %>'></asp:ImageButton>                                
            </DataItemTemplate>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="ID_CONCEPTO_PROD" ReadOnly="True" VisibleIndex="2" Width="20px" Caption="Identificador" />
        <dx:GridViewDataTextColumn FieldName="NOMBRE_CONCEPTO" VisibleIndex="3" Caption="Tipo Concepto" UnboundType="String" />  
        <dx:GridViewDataTextColumn FieldName="NOMBRE_TIPO" VisibleIndex="4" Caption="Tipo Producto" UnboundType="String" />  
        <dx:GridViewDataCheckColumn FieldName="ESTADO" VisibleIndex="5" Caption="Estado" /> 
    </Columns>
</dx:ASPxGridView>

<asp:ObjectDataSource ID="odsLista" runat="server" SelectMethod="ObtenerLista"  TypeName="ADMINPT.BL.CTIPO_CONCEPTO_PROD">    
</asp:ObjectDataSource>
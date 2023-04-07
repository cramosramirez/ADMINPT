<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcListaPROVEEDOR_TRAS.ascx.cs" Inherits="ADMINPT.controles.proveedor_tras.UcListaPROVEEDOR_TRAS" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<dx:ASPxGridView ID="gridLista" runat="server" Theme="Moderno" KeyFieldName="ID_PROV_TRAS" Width="100%"
    OnInit="gridLista_Init" OnRowCommand="gridLista_RowCommand">

    <SettingsSearchPanel Visible="True" />
    <SettingsLoadingPanel Text="Cargando&amp;hellip;" />
    <SettingsPager>
        <Summary AllPagesText="Pags: {0} - {1} ({2} registros)"
            Text="Pag. {0} de {1} ({2} registros)" />
        <PageSizeItemSettings Items="5, 10, 30" Visible="True">
        </PageSizeItemSettings>
    </SettingsPager>
    <SettingsText GroupPanel="Arrastre la columna aqui para agrupar"
        EmptyDataRow="No existen registros para mostrar" />

    <SettingsBehavior EnableRowHotTrack="True" AllowFocusedRow="True" />
    <Columns>
        <dx:GridViewCommandColumn ShowSelectCheckbox="True" Name="CheckSeleccionar" Caption=" " Width="10px" Visible="false" VisibleIndex="0" />
        <dx:GridViewDataTextColumn Visible="true" Caption="Editar" Name="Editar" CellStyle-HorizontalAlign="Center" Width="40px" VisibleIndex="1">
            <DataItemTemplate>
                <asp:ImageButton ID="lbtnEditar" runat="server" CommandName="Editar" ImageUrl="~/imagenes/Editar.png" CommandArgument='<%# Bind("ID_PROV_TRAS") %>'></asp:ImageButton>
            </DataItemTemplate>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="ID_PROV_TRAS" ReadOnly="True" VisibleIndex="2" Width="20px" Caption="Identificador" />
        <dx:GridViewDataTextColumn FieldName="NOMBRE" VisibleIndex="3" Caption="Nombre" />
        <dx:GridViewDataTextColumn FieldName="TRANSPORTE" VisibleIndex="4" Caption="Transporte" />
        <dx:GridViewDataCheckColumn FieldName="ESTADO" VisibleIndex="5" Caption="Activo" HeaderStyle-HorizontalAlign="Center" />
    </Columns>
</dx:ASPxGridView>

<asp:ObjectDataSource ID="odsLista" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CPROVEEDOR_TRAS"></asp:ObjectDataSource>

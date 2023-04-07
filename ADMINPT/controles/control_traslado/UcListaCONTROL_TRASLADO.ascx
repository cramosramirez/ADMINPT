<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcListaCONTROL_TRASLADO.ascx.cs" Inherits="ADMINPT.controles.control_traslado.UcListaCONTROL_TRASLADO" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<style type="text/css">
    .gridLista {
        max-width: 1300px;
        margin: auto;
    }

    .wrapfly {
        white-space: normal;
        word-wrap: normal
    }
</style>
<dx:ASPxGridView ID="gridLista" runat="server" Theme="Moderno" KeyFieldName="ID_CONTROL_TRAS" Width="100%" OnInit="gridLista_Init" OnRowCommand="gridLista_RowCommand" OnCustomUnboundColumnData="gridLista_CustomUnboundColumnData" Font-Size="X-Small">
    <SettingsPager>
        <Summary AllPagesText="Pags: {0} - {1} ({2} registros)"
            Text="Pag. {0} de {1} ({2} registros)" />
    </SettingsPager>
  <Toolbars>
                    <dx:GridViewToolbar>
                        <SettingsAdaptivity Enabled="true" EnableCollapseRootItemsToIcons="true" />
                        <Items>
                            <dx:GridViewToolbarItem Command="ExportToPdf" />
                            <dx:GridViewToolbarItem Command="ExportToXls" />
                            <dx:GridViewToolbarItem Command="ExportToXlsx" />
                        </Items>
                    </dx:GridViewToolbar>
                </Toolbars>
    <Columns>
        <dx:GridViewCommandColumn ShowSelectCheckbox="True" Name="CheckSeleccionar" Caption=" " Width="10px" Visible="false" VisibleIndex="0"/>
        <dx:GridViewDataTextColumn Visible="true" Caption="Editar" Name="Editar" CellStyle-HorizontalAlign="Center" Width="5%" VisibleIndex="1">
            <DataItemTemplate>
                <asp:ImageButton ID="lbtnEditar" runat="server" CommandName="Editar" ImageUrl="~/imagenes/Editar.png" CommandArgument='<%# Bind("ID_CONTROL_TRAS") %>'></asp:ImageButton>
            </DataItemTemplate>
        </dx:GridViewDataTextColumn>

        <dx:GridViewDataTextColumn FieldName="ID_CONTROL_TRAS" ReadOnly="True" VisibleIndex="2" Caption="Identificador" Visible="true" Width="5%"/>
        <dx:GridViewDataTextColumn FieldName="NUM_DOC" ReadOnly="True" VisibleIndex="2" Caption="Documento" Visible="true" Width="5%"/>
        <dx:GridViewDataTextColumn FieldName="ID_ORDEN_TRAS" ReadOnly="True" VisibleIndex="2" Caption="Orden Traslado" Visible="true" Width="5%"/>
        <dx:GridViewDataTextColumn FieldName="NOM_ESTADO" ReadOnly="True" VisibleIndex="2"  Caption="Estado" Visible="true" Width="5%"/>
        <dx:GridViewDataTextColumn FieldName="NOM_UNIDAD" ReadOnly="True" VisibleIndex="2"  Caption="Unidad" Visible="true" Width="5%"/>
        <dx:GridViewDataTextColumn FieldName="PLACA_CABEZAL" ReadOnly="True" VisibleIndex="2" Caption="Placa" Visible="true" Width="5%"/>
        <dx:GridViewDataTextColumn FieldName="CANTIDAD" ReadOnly="True" VisibleIndex="2"  Caption="Cantidad" Visible="true" Width="5%"/>
        <dx:GridViewDataTextColumn FieldName="BODEGA_DESTINO" ReadOnly="True" VisibleIndex="2" Caption="Bodega Destino" Visible="true" Width="10%"/>
        <dx:GridViewDataTextColumn FieldName="NOM_ZAFRA" ReadOnly="True" VisibleIndex="2" Caption="Zafra" Visible="true" Width="10%"/>
        <dx:GridViewDataTextColumn FieldName="PRESENACION_TRAS" ReadOnly="True" VisibleIndex="2" Caption="Presentacion" Visible="true" Width="10%"/>
        <dx:GridViewDataTextColumn FieldName="NOM_PRODUCTO" ReadOnly="True" VisibleIndex="2"  Caption="Producto" Visible="true" Width="10%"/>

    </Columns>
                <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG" Landscape="true" />
</dx:ASPxGridView>

<asp:ObjectDataSource ID="odsLista" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CCONTROL_TRASLADO"></asp:ObjectDataSource>

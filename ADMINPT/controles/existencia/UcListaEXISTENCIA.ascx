<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcListaEXISTENCIA.ascx.cs" Inherits="ADMINPT.controles.existencia.UcListaEXISTENCIA" %>

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

<dx:ASPxGridView ID="gridLista" runat="server" Theme="Moderno" KeyFieldName="ID_EXISTENCIA" Width="100%" OnInit="gridLista_Init" OnRowCommand="gridLista_RowCommand" OnCustomUnboundColumnData="gridLista_CustomUnboundColumnData" Font-Size="X-Small">
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
        <dx:GridViewDataTextColumn Visible="true" Caption="Editar" Name="Editar" CellStyle-HorizontalAlign="Center" Width="20px" VisibleIndex="1">
            <DataItemTemplate>
                <asp:ImageButton ID="lbtnEditar" runat="server" CommandName="Editar" ImageUrl="~/imagenes/Editar.png" CommandArgument='<%# Bind("ID_EXISTENCIA") %>'></asp:ImageButton>
            </DataItemTemplate>
        </dx:GridViewDataTextColumn>

        <dx:GridViewBandColumn Caption="GENERALES" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true">
            <Columns>
        <dx:GridViewDataTextColumn FieldName="ID_EXISTENCIA" ReadOnly="True" VisibleIndex="2" Width="20px" Caption="Identificador" Visible="true" />
        <dx:GridViewDataTextColumn FieldName="ID_KARDEX" ReadOnly="True" VisibleIndex="2" Width="20px" Caption="Identificador" Visible="false" />

        <dx:GridViewDataTextColumn FieldName="ID_ZAFRA" VisibleIndex="3" Caption="IdZafra" Visible="false" />
        <dx:GridViewDataTextColumn FieldName="NOMBRE_ZAFRA" VisibleIndex="4" Caption="Zafra" UnboundType="String" />


        <dx:GridViewDataTextColumn FieldName="ID_BODEGA" VisibleIndex="5" Caption="IdBodega" Visible="false" />
        <dx:GridViewDataTextColumn FieldName="NOMBRE_BODEGA" VisibleIndex="6" Caption="Bodega" UnboundType="String" />

        <dx:GridViewDataTextColumn FieldName="ID_PRODUCTO" VisibleIndex="7" Caption="Identificador" Visible="false" />
        <dx:GridViewDataTextColumn FieldName="NOMBRE_PRODUCTO" VisibleIndex="8" Caption="Producto" UnboundType="String" />


        <dx:GridViewDataTextColumn FieldName="ID_PRESEN_TRAS" VisibleIndex="9" Caption="IdpresTras" Visible="false" />
        <dx:GridViewDataTextColumn FieldName="PRESENACION_TRAS" VisibleIndex="10" Caption="Presentacion"/>

        <dx:GridViewDataTextColumn FieldName="ID_UNIDAD_FAC" VisibleIndex="11" Caption="IdUnidad" Visible="false" />
        <dx:GridViewDataTextColumn FieldName="NOM_UNIDAD" VisibleIndex="12" Caption="Unidad"/>
        <dx:GridViewDataTextColumn FieldName="CANTIDAD" VisibleIndex="13" Caption="Cantidad" />
        <dx:GridViewDataTextColumn FieldName="FACTOR_QQ" VisibleIndex="14" Caption="Factor QQ" Visible="false" />
        <dx:GridViewDataTextColumn FieldName="FACTOR_KG" VisibleIndex="15" Caption="Factor KG" Visible="false" />
        <dx:GridViewDataTextColumn FieldName="SDOINI_QQ" VisibleIndex="16" Caption="SDO Inicial QQ" Visible="false" PropertiesTextEdit-DisplayFormatString="N2" />
        <dx:GridViewDataTextColumn FieldName="SDOINI_KG" VisibleIndex="17" Caption="SDO Inicial KG" Visible="false" PropertiesTextEdit-DisplayFormatString="N2" />
                    </Columns>
        </dx:GridViewBandColumn>
        
        <dx:GridViewBandColumn Caption="ENTRADAS"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="ENTRADA_QQ" VisibleIndex="17" Caption="QQ" PropertiesTextEdit-DisplayFormatString="N2" />
                <dx:GridViewDataTextColumn FieldName="ENTRADA_KG" VisibleIndex="18" Caption="KG" PropertiesTextEdit-DisplayFormatString="N2" />
                <dx:GridViewDataTextColumn FieldName="ENTRADA_GAL" VisibleIndex="18" Caption="GAL" PropertiesTextEdit-DisplayFormatString="N2" />
            </Columns>
        </dx:GridViewBandColumn>

        <dx:GridViewBandColumn Caption="SALIDAS" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="SALIDA_QQ" VisibleIndex="19" Caption="QQ" PropertiesTextEdit-DisplayFormatString="N2" />
                <dx:GridViewDataTextColumn FieldName="SALIDA_KG" VisibleIndex="20" Caption="KG" PropertiesTextEdit-DisplayFormatString="N2" />
                <dx:GridViewDataTextColumn FieldName="SALIDA_GAL" VisibleIndex="20" Caption="GAL" PropertiesTextEdit-DisplayFormatString="N2" />
            </Columns>
        </dx:GridViewBandColumn>
        <dx:GridViewBandColumn Caption="SALDOS" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="SDOFIN_QQ" VisibleIndex="21" Caption="Final QQ" PropertiesTextEdit-DisplayFormatString="N2" />
                <dx:GridViewDataTextColumn FieldName="SDOFIN_KG" VisibleIndex="22" Caption="Final KG" PropertiesTextEdit-DisplayFormatString="N2" />
                <dx:GridViewDataTextColumn FieldName="SDOFIN_GAL" VisibleIndex="22" Caption="Final GAL" PropertiesTextEdit-DisplayFormatString="N2" />
            </Columns>
        </dx:GridViewBandColumn>
    </Columns>
                <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG" Landscape="true" />
</dx:ASPxGridView>

<asp:ObjectDataSource ID="odsLista" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CEXISTENCIA"></asp:ObjectDataSource>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcVistaPRODUCTO_ZAFRA.ascx.cs" Inherits="ADMINPT.controles.producto_zafra.UcVistaPRODUCTO_ZAFRA" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/controles/UCBarraNavegacion.ascx" TagPrefix="uc1" TagName="UCBarraNavegacion" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>


<link href="../../Content/uc.css" rel="stylesheet" type="text/css" />
<script src="../../Scripts/uppercase.js"></script>
<script type="text/javascript">
    function OnKeyPress(s, e) {
        var theEvent = e.htmlEvent || window.event;
        var key = theEvent.keyCode || theEvent.which;
        var txt = s.GetText();
        if (key != 8 || key != 13) txt += String.fromCharCode(key);
        var regex = /^[0-9]*\.?[0-9]*$/;
        if (!regex.test(txt)) {
            theEvent.returnValue = false;
            if (theEvent.preventDefault) theEvent.preventDefault();
        }
    }
    function changedupper(s, e) {
        s.SetText(s.GetText().toUpperCase());
    }
    function Numericint(s, e) {
        var theEvent = e.htmlEvent || window.event;
        var key = theEvent.keyCode || theEvent.which;
        key = String.fromCharCode(key);
        var regex = /[0-9]/;
        if (!regex.test(key)) {
            theEvent.returnValue = false;
            if (theEvent.preventDefault)
                theEvent.preventDefault();
        }
    }
    function Numericint_(s, e) {
        var theEvent = e.htmlEvent || window.event;
        var key = theEvent.keyCode || theEvent.which;
        key = String.fromCharCode(key);
        var regex = /[0-9]-/;
        if (!regex.test(key)) {
            theEvent.returnValue = false;
            if (theEvent.preventDefault)
                theEvent.preventDefault();
        }
    }
    function UpdateGridHeight() {
        Dgv_List.SetHeight(0);
        var containerHeight = ASPxClientUtils.GetDocumentClientHeight();
        if (document.body.scrollHeight > containerHeight)
            containerHeight = document.body.scrollHeight;
        Dgv_List.SetHeight(containerHeight);
    }
    window.addEventListener('resize', function (evt) {
        if (ASPxClientUtils && !ASPxClientUtils.androidPlatform)
            return;
        var activeElement = document.activeElement;
        if (activeElement && (activeElement.tagName === "INPUT" || activeElement.tagName === "TEXTAREA") && activeElement.scrollIntoViewIfNeeded)
            window.setTimeout(function () { activeElement.scrollIntoViewIfNeeded(); }, 0);
    });
    var visibleIndex;
    function OnCustomButtonClick(s, e) {
        elem = document.getElementById("tabla1");
        elem.style.display = "block";

        elem1 = document.getElementById("tabla2");
        elem1.style.display = "none";

        visibleIndex = e.visibleIndex;

        popup.Show();
        popup.BringToFront();
    }
    function OnClickYes(s, e) {
        Dgv_List.DeleteRow(visibleIndex);
        popup.Hide();
    }
    function OnClickNo(s, e) {
        popup.Hide();
    }
    function OnCallbackError(s, e) {
        elem = document.getElementById("tabla1");
        elem.style.display = "none";
        elem1 = document.getElementById("tabla2");
        elem1.style.display = "block";
        e.handled = true;
        var theoriginal = document.getElementById('ori');
        var thereplacement = document.createElement('p');
        thereplacement.style.color = "red";
        thereplacement.style.fontSize = "12px";
        thereplacement.style.fontWeight = "bold";
        thereplacement.appendChild(document.createTextNode(e.message));
        theoriginal.replaceChild(thereplacement, theoriginal.lastChild);
        //ShowMessage(e.message, "success");;
    }
    function onItemFiltering(s, e) {
        if (!e.isFit)
            e.isFit = toLatin(e.item.text).indexOf(toLatin(e.filter)) > -1;
    }
    function onCustomHighlighting(s, e) {
        e.highlighting = new RegExp(toLatin(e.filter)
            .replace(/u/gi, "(u|\u00fc)")
            .replace(/a/gi, "(a|\u00e4)")
            .replace(/o/gi, "(o|\u00f6)")
            , "gi");
    }
    function toLatin(text) {
        return text
            .replace(/\u00fc/gi, "u")
            .replace(/\u00e4/gi, "a")
            .replace(/\u00f6/gi, "o")
            .toLowerCase();
    }
</script>
<uc1:UCBarraNavegacion runat="server" ID="UCBarraNavegacion" />
<dx:ASPxLabel ID="lblMensaje" runat="server" Text="" ForeColor="Blue" Visible="false"></dx:ASPxLabel>

<%--<asp:UpdatePanel ID="UpList" runat="server">
    <ContentTemplate>--%>
<uc1:UCEncabezado runat="server" ID="UCEncabezado" />

<dx:ASPxFormLayout ID="FtListEmpresa" runat="server" CssClass="modal-content">
    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
    <Items>
        <dx:LayoutGroup Caption="Control Movimientos" ColumnCount="1" GroupBoxDecoration="HeadingLine" Paddings-PaddingTop="3" ShowCaption="true" UseDefaultPaddings="false" Name="EncIngreso" ClientVisible="true">
            <Paddings PaddingTop="3px"></Paddings>
            <GroupBoxStyle>
                <Caption CssClass="title" />
            </GroupBoxStyle>
            <Items>
                <dx:LayoutItem Caption="Codigo" CaptionSettings-HorizontalAlign="Right">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxTextBox ID="txt_cod" runat="server" Enabled="false" Text="0"></dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings HorizontalAlign="Right" />
                </dx:LayoutItem>

                <dx:LayoutItem Caption="Producto" CaptionSettings-HorizontalAlign="Right">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxComboBox ID="cb_producto" ClientInstanceName="cb_producto" runat="server" DataSourceID="sdscb_producto" ValueField="ID_PRODUCTO" TextField="NOMBRE_KARDEX"
                                ValueType="System.String" AutoPostBack="false" DropDownStyle="DropDownList" TextFormatString="{1}" IncrementalFilteringMode="Contains">
                                <Columns>
                                    <dx:ListBoxColumn Caption="Código" FieldName="ID_PRODUCTO" Name="ID_PRODUCTO" Width="10px" />
                                    <dx:ListBoxColumn Caption="Producto" FieldName="NOMBRE_KARDEX" Name="NOMBRE_KARDEX" Width="150px" />
       <%--                             <dx:ListBoxColumn Caption="Presentacion" FieldName="NOMBRE_PRESEN_TRAA" Name="NOMBRE_PRESEN_TRAA" Width="100px" />
                                    <dx:ListBoxColumn Caption="Unidad" FieldName="NOMBRE_UNIDAD" Name="NOMBRE_UNIDAD" Width="75px" />
                                    <dx:ListBoxColumn Caption="Bodega Origen" FieldName="BODEGA_ORIGEN" Name="BODEGA_ORIGEN" Width="150px" />
                                    <dx:ListBoxColumn Caption="Bodega Destino" FieldName="BODEGA_DESTINO" Name="BODEGA_ORIGEN" Width="200px" />--%>
                                </Columns>
                            </dx:ASPxComboBox>
                            <asp:SqlDataSource ID="sdscb_producto" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>"
                                SelectCommand="CB_PRODUCTO" SelectCommandType="StoredProcedure">
                            </asp:SqlDataSource>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Zafra Translado" CaptionSettings-HorizontalAlign="Right">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxComboBox ID="cb_zafraTraslado" ClientInstanceName="cb_zafraTraslado" runat="server" DataSourceID="sdscb_zafraTraslados" ValueField="ID_ZAFRA" TextField="NOMBRE_ZAFRA"
                                ValueType="System.String" AutoPostBack="false" DropDownStyle="DropDownList" TextFormatString="{1}" IncrementalFilteringMode="Contains">
                                <Columns>
                                    <dx:ListBoxColumn Caption="Código" FieldName="ID_ZAFRA" Name="ID_ZAFRA" Width="10px" />
                                    <dx:ListBoxColumn Caption="Producto" FieldName="NOMBRE_ZAFRA" Name="NOMBRE_ZAFRA" Width="150px" />
   <%--                                 <dx:ListBoxColumn Caption="Presentacion" FieldName="NOMBRE_PRESEN_TRAA" Name="NOMBRE_PRESEN_TRAA" Width="100px" />
                                    <dx:ListBoxColumn Caption="Unidad" FieldName="NOMBRE_UNIDAD" Name="NOMBRE_UNIDAD" Width="75px" />
                                    <dx:ListBoxColumn Caption="Bodega Origen" FieldName="BODEGA_ORIGEN" Name="BODEGA_ORIGEN" Width="150px" />
                                    <dx:ListBoxColumn Caption="Bodega Destino" FieldName="BODEGA_DESTINO" Name="BODEGA_ORIGEN" Width="200px" />--%>
                                </Columns>
                            </dx:ASPxComboBox>
                            <asp:SqlDataSource ID="sdscb_zafraTraslados" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>"
                                SelectCommand="CB_ZAFRA" SelectCommandType="StoredProcedure">
                            </asp:SqlDataSource>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Zafra Venta" CaptionSettings-HorizontalAlign="Right">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxComboBox ID="cb_zafraVenta" ClientInstanceName="cb_zafraVenta" runat="server" DataSourceID="sdscb_zafraVenta" ValueField="ID_ZAFRA" TextField="NOMBRE_ZAFRA"
                                ValueType="System.String" AutoPostBack="false" DropDownStyle="DropDownList" TextFormatString="{1}" IncrementalFilteringMode="Contains">
                                <Columns>
                                    <dx:ListBoxColumn Caption="Código" FieldName="ID_ZAFRA" Name="ID_ZAFRA" Width="10px" />
                                    <dx:ListBoxColumn Caption="Producto" FieldName="NOMBRE_ZAFRA" Name="NOMBRE_ZAFRA" Width="150px" />
   <%--                                 <dx:ListBoxColumn Caption="Presentacion" FieldName="NOMBRE_PRESEN_TRAA" Name="NOMBRE_PRESEN_TRAA" Width="100px" />
                                    <dx:ListBoxColumn Caption="Unidad" FieldName="NOMBRE_UNIDAD" Name="NOMBRE_UNIDAD" Width="75px" />
                                    <dx:ListBoxColumn Caption="Bodega Origen" FieldName="BODEGA_ORIGEN" Name="BODEGA_ORIGEN" Width="150px" />
                                    <dx:ListBoxColumn Caption="Bodega Destino" FieldName="BODEGA_DESTINO" Name="BODEGA_ORIGEN" Width="200px" />--%>
                                </Columns>
                            </dx:ASPxComboBox>
                            <asp:SqlDataSource ID="sdscb_zafraVenta" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>"
                                SelectCommand="CB_ZAFRA" SelectCommandType="StoredProcedure">
                            </asp:SqlDataSource>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Zafra Produccion" CaptionSettings-HorizontalAlign="Right">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxComboBox ID="cb_zafraProduccion" ClientInstanceName="cb_zafraProduccion" runat="server" DataSourceID="sdscb_zafraProduccion" ValueField="ID_ZAFRA" TextField="NOMBRE_ZAFRA"
                                ValueType="System.String" AutoPostBack="false" DropDownStyle="DropDownList" TextFormatString="{1}" IncrementalFilteringMode="Contains">
                                <Columns>
                                    <dx:ListBoxColumn Caption="Código" FieldName="ID_ZAFRA" Name="ID_ZAFRA" Width="10px" />
                                    <dx:ListBoxColumn Caption="Producto" FieldName="NOMBRE_ZAFRA" Name="NOMBRE_ZAFRA" Width="150px" />
   <%--                                 <dx:ListBoxColumn Caption="Presentacion" FieldName="NOMBRE_PRESEN_TRAA" Name="NOMBRE_PRESEN_TRAA" Width="100px" />
                                    <dx:ListBoxColumn Caption="Unidad" FieldName="NOMBRE_UNIDAD" Name="NOMBRE_UNIDAD" Width="75px" />
                                    <dx:ListBoxColumn Caption="Bodega Origen" FieldName="BODEGA_ORIGEN" Name="BODEGA_ORIGEN" Width="150px" />
                                    <dx:ListBoxColumn Caption="Bodega Destino" FieldName="BODEGA_DESTINO" Name="BODEGA_ORIGEN" Width="200px" />--%>
                                </Columns>
                            </dx:ASPxComboBox>
                            <asp:SqlDataSource ID="sdscb_zafraProduccion" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>"
                                SelectCommand="CB_ZAFRA" SelectCommandType="StoredProcedure">
                            </asp:SqlDataSource>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                </dx:LayoutItem>
            </Items>
        </dx:LayoutGroup>

    </Items>
</dx:ASPxFormLayout>

                 <dx:ASPxGridView ID="Dgv_List" ClientInstanceName="Dgv_List" runat="server" AutoGenerateColumns="False"
                                DataSourceID="sds_ListM" KeyFieldName="ID_PROZAFRA" Width="100%">
                                <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true"
                                    AllowHideDataCellsByColumnMinWidth="true">
                                </SettingsAdaptivity>
                                <SettingsCommandButton>
                                    <NewButton RenderMode="Image" Text="Nuevo">
                                        <Image IconID="miscellaneous_newwizard_16x16gray"></Image>
                                    </NewButton>
                                    <EditButton RenderMode="Image" Text="Editar">
                                        <Image IconID="edit_edit_16x16gray"></Image>
                                    </EditButton>
                                    <DeleteButton RenderMode="Image" Text="Eliminar">
                                        <Image IconID="actions_cancel_16x16gray"></Image>
                                    </DeleteButton>
                                    <UpdateButton RenderMode="Image" Text="Guardar">
                                        <Image IconID="save_save_32x32gray"></Image>
                                    </UpdateButton>
                                    <CancelButton RenderMode="Image" Text="Cancelar">
                                        <Image IconID="history_undo_32x32gray"></Image>
                                    </CancelButton>
                                </SettingsCommandButton>
                                <SettingsLoadingPanel Text="Cargando&amp;hellip;" />
                                <SettingsPager>
                                    <Summary AllPagesText="Pags: {0} - {1} ({2} registros)"
                                        Text="Pag. {0} de {1} ({2} registros)" />
                                    <PageSizeItemSettings Items="5, 10, 30" Visible="True">
                                    </PageSizeItemSettings>
                                </SettingsPager>
                                <SettingsText GroupPanel="Arrastre la columna aqui para agrupar"
                                    EmptyDataRow="No existen registros para mostrar" />
                                <Settings ShowFilterRow="false" ShowHeaderFilterButton="false" ShowFooter="True" />
                                <SettingsBehavior EnableRowHotTrack="True" AllowFocusedRow="True" />
                                <SettingsSearchPanel Visible="True" />
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
                                    <dx:GridViewCommandColumn ShowDeleteButton="false" ShowEditButton="false" ShowNewButtonInHeader="false" VisibleIndex="0" Width="5px">
                                    </dx:GridViewCommandColumn>

                                    <dx:GridViewDataTextColumn FieldName="ID_PROZAFRA" Caption="IdTrn" ShowInCustomizationForm="True" VisibleIndex="2" Visible="false" Width="10px">
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataTextColumn>


                                    <dx:GridViewDataComboBoxColumn FieldName="ID_PRODUCTO" Caption="Turno" ShowInCustomizationForm="True" VisibleIndex="12" Width="80px" Visible="TRUE">
                                        <PropertiesComboBox DataSourceID="Sds_ListaProducto" TextField="NOMBRE_KARDEX" ValueField="ID_PRODUCTO">
                                        </PropertiesComboBox>
                                    </dx:GridViewDataComboBoxColumn>

                                    <dx:GridViewDataComboBoxColumn FieldName="ID_ZAFRA_TRASLADO" Caption="Zafra Traslado" ShowInCustomizationForm="True" VisibleIndex="13" Width="30px" Visible="TRUE">
                                        <PropertiesComboBox DataSourceID="Sds_ListaZafraTraslado" TextField="NOMBRE_ZAFRA" ValueField="ID_ZAFRA">
                                        </PropertiesComboBox>
                                    </dx:GridViewDataComboBoxColumn>

                                    <dx:GridViewDataComboBoxColumn FieldName="ID_ZAFRA_VENTA" Caption="Zafra Venta" ShowInCustomizationForm="True" VisibleIndex="13" Width="30px" Visible="TRUE">
                                        <PropertiesComboBox DataSourceID="Sds_ListaZafraVenta" TextField="NOMBRE_ZAFRA" ValueField="ID_ZAFRA">
                                        </PropertiesComboBox>
                                    </dx:GridViewDataComboBoxColumn>

                                    <dx:GridViewDataComboBoxColumn FieldName="ID_ZAFRA_PRODUCCION" Caption="Zafra Produccion" ShowInCustomizationForm="True" VisibleIndex="13" Width="30px" Visible="TRUE">
                                        <PropertiesComboBox DataSourceID="Sds_ListaZafraProduccion" TextField="NOMBRE_ZAFRA" ValueField="ID_ZAFRA">
                                        </PropertiesComboBox>
                                    </dx:GridViewDataComboBoxColumn>

                                    <dx:GridViewCommandColumn Name="delete" Caption=" " ShowDeleteButton="True" ShowInCustomizationForm="True" VisibleIndex="14" Width="15px" Visible="true">
                                    </dx:GridViewCommandColumn>
                                </Columns>
                                <SettingsEditing EditFormColumnCount="1" Mode="PopupEditForm" />
                                <SettingsPopup>
                                    <EditForm AllowResize="true" Modal="true" HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter" />
                                </SettingsPopup>
                                <Settings ShowFilterRow="True" ShowFilterRowMenu="true" ShowGroupPanel="True" ShowFooter="True" />
                                <SettingsPager PageSize="5">
                                    <PageSizeItemSettings Visible="true" Items="5, 10, 30" />
                                </SettingsPager>
                                <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG" Landscape="true" />
                                <GroupSummary>
                                    <dx:ASPxSummaryItem SummaryType="Count" />
                                </GroupSummary>
                                <Styles Header-BackColor="#f0f0f0" Header-Font-Bold="true">
                                    <Header BackColor="#F0F0F0" Font-Bold="True">
                                    </Header>
                                </Styles>
    
    <SettingsBehavior ConfirmDelete="true" EnableCustomizationWindow="true" EnableRowHotTrack="true" />
    <SettingsText ConfirmDelete="¿Estás seguro de que quieres eliminar?" />
                            </dx:ASPxGridView>
                            <asp:SqlDataSource ID="sds_ListM" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>"
                                SelectCommand="LIST_PRODUCTO_ZAFRA" SelectCommandType="StoredProcedure"
                                DeleteCommand="DEL_PRODUCTO_ZAFRA" DeleteCommandType="StoredProcedure">
    <%--                            <SelectParameters>
                                    <asp:SessionParameter Name="ID_EMPRESA" SessionField="ID_EMPRESA" Type="Int32" />
                                    <asp:ControlParameter ControlID="cb_zafra" Name="ID_ZAFRAS" PropertyName="Value" Type="Int32" />
                                    <asp:ControlParameter ControlID="cb_diazafra" Name="DIAZAFRA" PropertyName="Value" Type="Int32" />
                                    <asp:ControlParameter ControlID="cb_turno" Name="ID_TURNO" PropertyName="Value" Type="Int32" />
                                </SelectParameters>--%>
                                <DeleteParameters>
                                    <asp:Parameter Name="ID_PROZAFRA" Type="Int32" />
                                </DeleteParameters>
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="Sds_ListaProducto" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>"
                                SelectCommand="CB_PRODUCTO" SelectCommandType="StoredProcedure">
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="Sds_ListaZafraTraslado" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>"
                                SelectCommand="CB_ZAFRA" SelectCommandType="StoredProcedure">
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="Sds_ListaZafraVenta" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>"
                                SelectCommand="CB_ZAFRA" SelectCommandType="StoredProcedure">
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="Sds_ListaZafraProduccion" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>"
                                SelectCommand="CB_ZAFRA" SelectCommandType="StoredProcedure">
                            </asp:SqlDataSource>

<%--    </ContentTemplate>
</asp:UpdatePanel>--%>
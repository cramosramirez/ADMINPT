<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantConsultaCrudoBp.ascx.cs" Inherits="ADMINPT.controles.movimiento_auto.UcMantConsultaCrudoBp" %>

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
                <dx:LayoutGroup Caption="Ingreso de Azucar" ColumnCount="3" GroupBoxDecoration="HeadingLine" Paddings-PaddingTop="3" ShowCaption="true" UseDefaultPaddings="false" Name="EncIngreso" ClientVisible="true">
                    <Paddings PaddingTop="3px"></Paddings>
<%--                    <GroupBoxStyle>
                        <Caption CssClass="title" />
                    </GroupBoxStyle>--%>
                    <Items>
                        <dx:LayoutItem Caption="Codigo" CaptionSettings-HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txt_cod" runat="server" Enabled="false" Text="0"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right" />
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Zafra Actual" CaptionSettings-HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxComboBox ID="cb_zafraact" ClientInstanceName="cb_zafra" runat="server" DataSourceID="sdscb_zafraact" ValueField="ID_ZAFRAS" TextField="NOMBRE_ZAFRA"
                                        ValueType="System.String" AutoPostBack="true" DropDownStyle="DropDownList" TextFormatString="{0}" IncrementalFilteringMode="Contains">
                                    </dx:ASPxComboBox>
                                    <asp:SqlDataSource ID="sdscb_zafraact" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>"
                                        SelectCommand="CB_ZAFRA_ACT_BP" SelectCommandType="StoredProcedure">
<%--                                        <SelectParameters>
                                            <asp:SessionParameter Name="ID_EMPRESA" SessionField="ID_EMPRESA" Type="Int32" />
                                        </SelectParameters>--%>
                                    </asp:SqlDataSource>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Fecha Banda" CaptionSettings-HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxComboBox ID="cb_diazafra" ClientInstanceName="cb_diazafra" runat="server" DataSourceID="sdscb_Diazafraact" ValueField="DIAZAFRA" TextField="FECHA"
                                        ValueType="System.String" AutoPostBack="true" DropDownStyle="DropDownList" TextFormatString="{1}" IncrementalFilteringMode="Contains" OnTextChanged="cb_diazafra_TextChanged">
<Columns>
                                            <dx:ListBoxColumn Caption="Código" FieldName="DIAZAFRA" Name="DIAZAFRA" Width="100px" />
                                            <dx:ListBoxColumn Caption="Fecha" FieldName="FECHA" Name="FECHA" Width="250px" />
                                        </Columns>
                                    </dx:ASPxComboBox>
                                    <asp:SqlDataSource ID="sdscb_Diazafraact" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>"
                                        SelectCommand="CB_DIAZAFRA" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                  <%--          <asp:SessionParameter Name="ID_EMPRESA" SessionField="ID_EMPRESA" Type="Int32" />--%>
                                            <asp:ControlParameter ControlID="cb_zafraact" Name="ID_ZAFRAS" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Concepto" CaptionSettings-HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxComboBox ID="cb_concepto" runat="server" DataSourceID="sdscb_concepto" ValueField="ID_CONCEPTOES" TextField="NOMBRE"
                                        ValueType="System.String" AutoPostBack="true" DropDownStyle="DropDownList" TextFormatString="{0}" IncrementalFilteringMode="Contains">

                                    </dx:ASPxComboBox>
                                    <asp:SqlDataSource ID="sdscb_concepto" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>"
                                        SelectCommand="CB_CONCEPTO_ENTRADA" SelectCommandType="StoredProcedure">
         <%--                               <SelectParameters>
                                            <asp:SessionParameter Name="ID_EMPRESA" SessionField="ID_EMPRESA" Type="Int32" />
                                        </SelectParameters>--%>
                                    </asp:SqlDataSource>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right" />
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Producto" CaptionSettings-HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxComboBox ID="cb_articulo" runat="server" DataSourceID="sdscb_articulo" ValueField="ID_ARTICULO"
                                        DropDownStyle="DropDownList" ValueType="System.Int32" EnableSynchronization="False"
                                        IncrementalFilteringMode="Contains" TextFormatString="{1}" EnableCallbackMode="true" CallbackPageSize="15" OnCustomFiltering="Unnamed_CustomFiltering">
                                        <Columns>
                                            <dx:ListBoxColumn Caption="Código" FieldName="CODREF" Name="CODREF" Width="100px" />
                                            <dx:ListBoxColumn Caption="Nombre" FieldName="NOMBRE" Name="NOMBRE" Width="250px" />
                                        </Columns>
<%--                                        <ClearButton DisplayMode="Always"></ClearButton>
                                        <ItemStyle>
                                            <SelectedStyle BackColor="#ffcc99">
                                            </SelectedStyle>
                                        </ItemStyle>--%>
                                        <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                    </dx:ASPxComboBox>
                                    <asp:SqlDataSource ID="sdscb_articulo" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>"
                                        SelectCommand="CB_ARTICULO_AUTO" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:Parameter Name="ID_PRODUCTO" DbType="Int32" DefaultValue="2" />
                                            <asp:Parameter Name="ID_TIPO_BASCULA" DbType="Int32" DefaultValue="1" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right" />
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Zafra Produccion" CaptionSettings-HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxComboBox ID="cb_zafra" ClientInstanceName="cb_zafra" runat="server" DataSourceID="sdscb_zafra" ValueField="ID_ZAFRAS" TextField="NOMBRE_ZAFRA"
                                        ValueType="System.String" AutoPostBack="true" DropDownStyle="DropDownList" TextFormatString="{0}" IncrementalFilteringMode="Contains">
                                    </dx:ASPxComboBox>
                                    <asp:SqlDataSource ID="sdscb_zafra" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>"
                                        SelectCommand="CB_ZAFRA_BP" SelectCommandType="StoredProcedure">
<%--                                        <SelectParameters>
                                            <asp:SessionParameter Name="ID_EMPRESA" SessionField="ID_EMPRESA" Type="Int32" />
                                        </SelectParameters>--%>
                                    </asp:SqlDataSource>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Turno" CaptionSettings-HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxComboBox ID="cb_turno" ClientInstanceName="cb_turno" runat="server" DataSourceID="sdscb_turno" ValueField="ID_TURNO" TextField="TURNO"
                                        ValueType="System.String" AutoPostBack="true" DropDownStyle="DropDownList" TextFormatString="{0}" IncrementalFilteringMode="Contains" OnTextChanged="cb_turno_TextChanged">
                                    </dx:ASPxComboBox>
                                    <asp:SqlDataSource ID="sdscb_turno" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>"
                                        SelectCommand="CB_TURNO_BP" SelectCommandType="StoredProcedure">
<%--                                        <SelectParameters>
                                            <asp:SessionParameter Name="ID_EMPRESA" SessionField="ID_EMPRESA" Type="Int32" />
                                        </SelectParameters>--%>
                                    </asp:SqlDataSource>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right" />
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Tipo Bascula" CaptionSettings-HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxComboBox ID="cb_TipoBascula" ClientInstanceName="cb_TipoBascula" runat="server" DataSourceID="sdscb_TipoBascula" ValueField="ID_TIPO_BASCULA" TextField="NOMBRE"
                                        ValueType="System.String" AutoPostBack="true" DropDownStyle="DropDownList" TextFormatString="{0}" IncrementalFilteringMode="Contains">
                                    </dx:ASPxComboBox>
                                    <asp:SqlDataSource ID="sdscb_TipoBascula" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>"
                                        SelectCommand="SEL_TIPO_BASCULA" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="1" Type="Int32" Name="ID_TIPO_BASCULA" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right" />
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Factor QQ" CaptionSettings-HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txt_factorq" Text="46" runat="server" ReadOnly="true">
                                        <ClientSideEvents KeyPress="OnKeyPress" />
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right" />
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Factor K" CaptionSettings-HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txt_factork" Text="50" runat="server" ReadOnly="true">
                                        <ClientSideEvents KeyPress="OnKeyPress" />
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right" />
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Tarima" CaptionSettings-HorizontalAlign="Right" ClientVisible="false">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txt_tarima" runat="server" OnTextChanged="txt_tarima_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled">
                                        <ClientSideEvents KeyPress="OnKeyPress" />
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right" />
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Sacos" CaptionSettings-HorizontalAlign="Right" ClientVisible="false">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txt_sacos" runat="server" OnTextChanged="txt_sacos_TextChanged" AutoPostBack="true" DisplayFormatString="N2" AutoCompleteType="Disabled" ClientVisible="false">
                                        <ClientSideEvents KeyPress="OnKeyPress" />
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right" />
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Quintales" CaptionSettings-HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txt_quintales" runat="server" Enabled="false" DisplayFormatString="N2" Font-Bold="true">
                                        <ClientSideEvents KeyPress="OnKeyPress" />
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right" />
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Kilogramos" CaptionSettings-HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txt_kilogramos" runat="server" Enabled="false" DisplayFormatString="N2" Font-Bold="true">
                                        <ClientSideEvents KeyPress="OnKeyPress" />
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right" />
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Descargas" CaptionSettings-HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txt_totalDescargas" runat="server" Enabled="false" DisplayFormatString="N2" Font-Bold="true">
                                        <ClientSideEvents KeyPress="OnKeyPress" />
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right" />
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="ID Inicial" CaptionSettings-HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                   <dx:ASPxSpinEdit ID="se_IdInicial" runat="server" Enabled="false" AllowMouseWheel="false" OnValueChanged="se_IdInicial_ValueChanged" AutoPostBack="true">
                                   </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right" />
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="ID Final" CaptionSettings-HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                   <dx:ASPxSpinEdit ID="se_IdFinal" runat="server" Enabled="false" AllowMouseWheel="false" OnValueChanged="se_IdFinal_ValueChanged"  AutoPostBack="true">
                                   </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right" />
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Observacion" ColumnSpan="3" Width="100%" CaptionSettings-HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxMemo ID="txt_observacion" runat="server" Height="30px">
                                        <ClientSideEvents ValueChanged="changedupper" />
                                    </dx:ASPxMemo>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right" />
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
                <dx:LayoutGroup Caption="Listado de Ingreso" ColumnCount="1" GroupBoxDecoration="HeadingLine" Paddings-PaddingTop="3" ShowCaption="true" UseDefaultPaddings="false">
            <Paddings PaddingTop="3px"></Paddings>
            <GroupBoxStyle>
                <Caption CssClass="title" />
            </GroupBoxStyle>
            <Items>
                <dx:LayoutItem Caption="" ShowCaption="False" CaptionSettings-HorizontalAlign="Right">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxGridView ID="Dgv_ListM" ClientInstanceName="Dgv_ListM" runat="server" AutoGenerateColumns="False"
                                DataSourceID="sds_ListM" KeyFieldName="ID_CTURNO;Id" Font-Size="X-Small">
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
                                    <dx:GridViewCommandColumn ShowDeleteButton="false" ShowEditButton="True" ShowNewButtonInHeader="false" VisibleIndex="0" Width="10px">
                                    </dx:GridViewCommandColumn>

                                    <dx:GridViewDataTextColumn FieldName="ID_CTURNO" Caption="IdTrn" ShowInCustomizationForm="True" VisibleIndex="2" Visible="false" Width="10px">
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataTextColumn>

                                    <dx:GridViewDataTextColumn FieldName="Id" Caption="Id" ShowInCustomizationForm="True" VisibleIndex="2" Visible="true" Width="50PX">
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataTextColumn>

                                    <dx:GridViewDataTextColumn FieldName="ID_EMPRESA" Caption="ID_EMPRESA" ShowInCustomizationForm="True" VisibleIndex="2" Visible="false" Width="5px">
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataTextColumn>

                                    <dx:GridViewDataTextColumn FieldName="AcumGeneral" Caption="Acum General" ShowInCustomizationForm="True" VisibleIndex="3" Width="15px" Visible="true">
                                        <PropertiesTextEdit DisplayFormatString="n2"></PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ConsGeneral" Caption="Cons General" ShowInCustomizationForm="True" VisibleIndex="4" Width="15px" Visible="true">
                                        <PropertiesTextEdit DisplayFormatString="n2"></PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="AcumTurno" Caption="Acum turno" ShowInCustomizationForm="True" VisibleIndex="5" Width="30px" Visible="true">
                                        <PropertiesTextEdit DisplayFormatString="n2"></PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ConsTurno" Caption="Cons Turno" ShowInCustomizationForm="True" VisibleIndex="6" Width="15px" Visible="true">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Descarga" Caption="Descarga" ShowInCustomizationForm="True" VisibleIndex="7" Width="30px" Visible="true">
                                        <PropertiesTextEdit DisplayFormatString="n2"></PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="DescargaQQ" Caption="DescargaQQ" ShowInCustomizationForm="True" VisibleIndex="7" Width="30px" Visible="true">
                                        <PropertiesTextEdit DisplayFormatString="n2"></PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ConfDescarga" Caption="Conf Descarga" ShowInCustomizationForm="True" VisibleIndex="8" Width="20px" Visible="true">
                                        <PropertiesTextEdit DisplayFormatString="n2"></PropertiesTextEdit>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataDateColumn FieldName="Fecha" Caption="Fecha" ShowInCustomizationForm="True" VisibleIndex="9" Width="30px" Visible="true">
                                    </dx:GridViewDataDateColumn>
                                    <dx:GridViewDataTextColumn FieldName="Hora" Caption="Observaciones" ShowInCustomizationForm="True" VisibleIndex="10" Width="30px" Visible="true">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Bascula" Caption="Bascula" ShowInCustomizationForm="True" VisibleIndex="11" Width="30px" Visible="true">
                                    </dx:GridViewDataTextColumn>

                                    <dx:GridViewDataComboBoxColumn FieldName="ID_TURNO" Caption="Turno" ShowInCustomizationForm="True" VisibleIndex="12" Width="80px" Visible="TRUE">
                                        <PropertiesComboBox DataSourceID="Sds_ListaTurno" TextField="TURNO" ValueField="ID_TURNO">
                                        </PropertiesComboBox>
                                    </dx:GridViewDataComboBoxColumn>

                                    <dx:GridViewDataComboBoxColumn FieldName="DIAZAFRA" Caption="Dia Zafra" ShowInCustomizationForm="True" VisibleIndex="13" Width="30px" Visible="TRUE">
                                        <PropertiesComboBox DataSourceID="Sds_ListaDiaZafra" TextField="FECHA" ValueField="DIAZAFRA">
                                        </PropertiesComboBox>
                                    </dx:GridViewDataComboBoxColumn>
                                    <dx:GridViewCommandColumn Name="delete" Caption=" " ShowDeleteButton="True" ShowInCustomizationForm="True" VisibleIndex="14" Width="30px" Visible="false">
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
                            </dx:ASPxGridView>
                            <asp:SqlDataSource ID="sds_ListM" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>"
                                SelectCommand="LIST_REPORTES_BP_HIST" SelectCommandType="StoredProcedure"
                                DeleteCommand="DEL_REPORTES_BP" DeleteCommandType="StoredProcedure"
                                UpdateCommand="UPD_REPORTES_BP" UpdateCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:SessionParameter Name="ID_EMPRESA" SessionField="ID_EMPRESA" Type="Int32" />
                                    <asp:ControlParameter ControlID="cb_zafra" Name="ID_ZAFRAS" PropertyName="Value" Type="Int32" />
                                    <asp:ControlParameter ControlID="cb_diazafra" Name="DIAZAFRA" PropertyName="Value" Type="Int32" />
                                    <asp:ControlParameter ControlID="cb_turno" Name="ID_TURNO" PropertyName="Value" Type="Int32" />
                                </SelectParameters>
                                <DeleteParameters>
                                    <asp:SessionParameter Name="ID_EMPRESA" SessionField="ID_EMPRESA" Type="Int32" />
                                    <asp:Parameter Name="ID_CTURNO" Type="Int32" />
                                    <asp:Parameter Name="Id" Type="Int32" />
                                </DeleteParameters>
                                <UpdateParameters>
                                    <asp:SessionParameter Name="ID_EMPRESA" SessionField="ID_EMPRESA" Type="Int32" />
                                    <asp:Parameter Name="ID_CTURNO" Type="Int32" />
                                    <asp:Parameter Name="Id" Type="Int32" />
                                    <asp:Parameter Name="ID_TURNO" Type="Int32" />
                                    <asp:Parameter Name="DIAZAFRA" Type="Int32" />
                                    <asp:ControlParameter ControlID="cb_zafraact" Name="ID_ZAFRAS" PropertyName="Value" Type="Int32" />
                                </UpdateParameters>
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="Sds_ListaTurno" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>"
                                SelectCommand="CB_TURNO_BP" SelectCommandType="StoredProcedure">
<%--                                <SelectParameters>
                                 <asp:SessionParameter Name="ID_EMPRESA" SessionField="ID_EMPRESA" Type="Int32" />
                                </SelectParameters>--%>
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="Sds_ListaDiaZafra" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>"
                                SelectCommand="CB_DIAZAFRA" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                     <%--            <asp:SessionParameter Name="ID_EMPRESA" SessionField="ID_EMPRESA" Type="Int32" />--%>
                                  <asp:ControlParameter ControlID="cb_zafraact" Name="ID_ZAFRAS" PropertyName="Value" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings HorizontalAlign="Right" />
                </dx:LayoutItem>
            </Items>
        </dx:LayoutGroup>
    </Items>
</dx:ASPxFormLayout>
<%--    </ContentTemplate>
</asp:UpdatePanel>--%>
 <dx:ASPxLoadingPanel ID="ldnPanel" runat="server" Text="Procesando Datos..." ClientInstanceName="ldnPanel" Theme="MaterialCompact" 
        Modal="True">
    </dx:ASPxLoadingPanel>
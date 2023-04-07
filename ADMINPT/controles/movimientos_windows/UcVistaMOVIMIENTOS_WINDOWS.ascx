<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcVistaMOVIMIENTOS_WINDOWS.ascx.cs" Inherits="ADMINPT.controles.movimientos_windows.UcVistaMOVIMIENTOS_WINDOWS" %>

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

                <dx:LayoutItem Caption="Produccion Tarima" CaptionSettings-HorizontalAlign="Right">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxComboBox ID="cb_produccionTarima" ClientInstanceName="cb_zafra" runat="server" DataSourceID="sdscb_produccionTarima" ValueField="ID_ES_ENCA" TextField="NOMBRE_KARDEX"
                                ValueType="System.Int32" AutoPostBack="false" DropDownStyle="DropDownList" TextFormatString="{1}" IncrementalFilteringMode="Contains">
                                <Columns>
                                    <dx:ListBoxColumn Caption="Código" FieldName="ID_ES_ENCA" Name="ID_ES_ENCA" Width="10px" />
                                    <dx:ListBoxColumn Caption="Producto" FieldName="NOMBRE_PRODUCTODT" Name="NOMBRE_PRODUCTODT" Width="150px" />
                            </Columns>
                            </dx:ASPxComboBox>
                            <asp:SqlDataSource ID="sdscb_produccionTarima" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>"
                                SelectCommand="CB_ENTRADA_SALIDA_DETA_T" SelectCommandType="StoredProcedure">
                               <SelectParameters>
                                  <asp:Parameter Name="TPMOV" Type="Int32" DefaultValue="1" />
                                 </SelectParameters>
                            </asp:SqlDataSource>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Produccion Jumbo" CaptionSettings-HorizontalAlign="Right">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxComboBox ID="cb_produccionJumbo" ClientInstanceName="cb_zafra" runat="server" DataSourceID="sdscb_produccionJumbo" ValueField="ID_ES_ENCA" TextField="NOMBRE_KARDEX"
                                ValueType="System.Int32" AutoPostBack="false" DropDownStyle="DropDownList" TextFormatString="{1}" IncrementalFilteringMode="Contains">
                                <Columns>
                                    <dx:ListBoxColumn Caption="Código" FieldName="ID_ES_ENCA" Name="ID_ES_ENCA" Width="10px" />
                                    <dx:ListBoxColumn Caption="Producto" FieldName="NOMBRE_PRODUCTODT" Name="NOMBRE_PRODUCTODT" Width="150px" />
                             </Columns>
                            </dx:ASPxComboBox>
                            <asp:SqlDataSource ID="sdscb_produccionJumbo" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>"
                                SelectCommand="CB_ENTRADA_SALIDA_DETA_T" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                  <asp:Parameter Name="TPMOV" Type="Int32" DefaultValue="2" />
                                 </SelectParameters>
                            </asp:SqlDataSource>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Produccion Cruda a Granel" CaptionSettings-HorizontalAlign="Right">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxComboBox ID="cb_produccionCruada" ClientInstanceName="cb_zafra" runat="server" DataSourceID="sdscb_produccionCruda" ValueField="ID_ES_ENCA" TextField="NOMBRE_KARDEX"
                                ValueType="System.Int32" AutoPostBack="false" DropDownStyle="DropDownList" TextFormatString="{1}" IncrementalFilteringMode="Contains">
                                <Columns>
                                    <dx:ListBoxColumn Caption="Código" FieldName="ID_ES_ENCA" Name="ID_ES_ENCA" Width="10px" />
                                    <dx:ListBoxColumn Caption="Producto" FieldName="NOMBRE_PRODUCTODT" Name="NOMBRE_PRODUCTODT" Width="150px" />
                            </Columns>
                            </dx:ASPxComboBox>
                            <asp:SqlDataSource ID="sdscb_produccionCruda" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>"
                                SelectCommand="CB_ENTRADA_SALIDA_DETA_T" SelectCommandType="StoredProcedure">
                               <SelectParameters>
                                  <asp:Parameter Name="TPMOV" Type="Int32" DefaultValue="3" />
                                 </SelectParameters>
                            </asp:SqlDataSource>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Produccion Melaza" CaptionSettings-HorizontalAlign="Right">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxComboBox ID="cb_produccionMelaza" ClientInstanceName="cb_zafra" runat="server" DataSourceID="sdscb_produccionMelaza" ValueField="ID_ES_ENCA" TextField="NOMBRE_KARDEX"
                                ValueType="System.Int32" AutoPostBack="false" DropDownStyle="DropDownList" TextFormatString="{1}" IncrementalFilteringMode="Contains">
                                <Columns>
                                    <dx:ListBoxColumn Caption="Código" FieldName="ID_ES_ENCA" Name="ID_ES_ENCA" Width="10px" />
                                    <dx:ListBoxColumn Caption="Producto" FieldName="NOMBRE_PRODUCTODT" Name="NOMBRE_PRODUCTODT" Width="150px" />
                            </Columns>
                            </dx:ASPxComboBox>
                            <asp:SqlDataSource ID="sdscb_produccionMelaza" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>"
                                SelectCommand="CB_ENTRADA_SALIDA_DETA_T" SelectCommandType="StoredProcedure">
                               <SelectParameters>
                                  <asp:Parameter Name="TPMOV" Type="Int32" DefaultValue="4" />
                                 </SelectParameters>
                            </asp:SqlDataSource>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Translado CE5 Dizucar" CaptionSettings-HorizontalAlign="Right">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxComboBox ID="cb_transladoCe5Dizucar" ClientInstanceName="cb_zafra" runat="server" DataSourceID="sdscb_transladoCe5Dizucar" ValueField="ID_ES_ENCA" TextField="NOMBRE_KARDEX"
                                ValueType="System.Int32" AutoPostBack="false" DropDownStyle="DropDownList" TextFormatString="{1}" IncrementalFilteringMode="Contains">
                                <Columns>
                                    <dx:ListBoxColumn Caption="Código" FieldName="ID_ES_ENCA" Name="ID_ES_ENCA" Width="10px" />
                                    <dx:ListBoxColumn Caption="Producto" FieldName="NOMBRE_PRODUCTODT" Name="NOMBRE_PRODUCTODT" Width="150px" />
                                  </Columns>
                            </dx:ASPxComboBox>
                            <asp:SqlDataSource ID="sdscb_transladoCe5Dizucar" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>"
                                SelectCommand="CB_ENTRADA_SALIDA_DETA_T" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                  <asp:Parameter Name="TPMOV" Type="Int32" DefaultValue="5" />
                                 </SelectParameters>
                            </asp:SqlDataSource>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                </dx:LayoutItem>
            <%--    <dx:LayoutItem Caption="Translado Interno" CaptionSettings-HorizontalAlign="Right">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxComboBox ID="cb_transladoInterno" ClientInstanceName="cb_zafra" runat="server" DataSourceID="sdscb_transladoInterno" ValueField="ID_ES_ENCA" TextField="NOMBRE_KARDEX"
                                ValueType="System.String" AutoPostBack="false" DropDownStyle="DropDownList" TextFormatString="{1}" IncrementalFilteringMode="Contains">
                                <Columns>
                                    <dx:ListBoxColumn Caption="Código" FieldName="ID_ES_ENCA" Name="ID_ES_ENCA" Width="10px" />
                                    <dx:ListBoxColumn Caption="Producto" FieldName="NOMBRE_PRODUCTODT" Name="NOMBRE_PRODUCTODT" Width="150px" />
                             </Columns>
                            </dx:ASPxComboBox>
                            <asp:SqlDataSource ID="sdscb_transladoInterno" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>"
                                SelectCommand="CB_ENTRADA_SALIDA_DETA_T" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                  <asp:Parameter Name="TPMOV" Type="Int32" DefaultValue="6" />
                                 </SelectParameters>
                            </asp:SqlDataSource>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                </dx:LayoutItem>--%>
            </Items>
        </dx:LayoutGroup>

    </Items>
</dx:ASPxFormLayout>
<%--    </ContentTemplate>
</asp:UpdatePanel>--%>

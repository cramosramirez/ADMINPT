<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcFechaVentaTransdo.ascx.cs" Inherits="ADMINPT.controles.cierreDiario.UcFechaVentaTransdo" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraReports.v20.1.Web.WebForms, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/controles/UCBarraNavegacion.ascx" TagPrefix="uc1" TagName="UCBarraNavegacion" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>


<uc1:UCBarraNavegacion runat="server" ID="UCBarraNavegacion" />
<uc1:UCEncabezado runat="server" ID="UCEncabezado" />
<dx:ASPxFormLayout ID="FtListEmpresa" CssClass="modal-content" runat="server">
    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
    <Items>
        <dx:LayoutGroup Caption="" ColumnCount="2" ShowCaption="false" GroupBoxDecoration="Box"
            UseDefaultPaddings="false" Paddings-PaddingTop="3">
            <Paddings PaddingTop="3px"></Paddings>
            <GroupBoxStyle>
                <Caption CssClass="title" />
            </GroupBoxStyle>
            <Items>
                <dx:LayoutItem Caption="Bodega Origen">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                             <dx:ASPxComboBox ID="cb_bodegaO" ClientInstanceName="cb_bodegaO" runat="server" Enabled="false"  DataSourceID="SdsListBgasOrigen" ValueField="ID_BODEGA" TextField="NOMBRE" 
                                        ValueType="System.Int32" AutoPostBack="true" DropDownStyle="DropDownList" TextFormatString="{0}" IncrementalFilteringMode="Contains">
                                      <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithText" ErrorText="requerido!!!" ErrorTextPosition="Right">
                                            <RequiredField ErrorText="requerido!!!" IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                             <asp:SqlDataSource ID="SdsListBgasOrigen" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>" SelectCommand="CB_BODEGAS_ORIGEN" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionStyle Font-Bold="True"></CaptionStyle>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Zafra en curso">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cb_zafra" ClientInstanceName="cb_zafra" runat="server"  DataSourceID="sdscb_zafra" ValueField="ID_ZAFRA" TextField="NOMBRE_ZAFRA" Enabled="false"
                                        ValueType="System.String"  DropDownStyle="DropDownList" TextFormatString="{0}" IncrementalFilteringMode="Contains">
                                      <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithText" ErrorText="requerido!!!" ErrorTextPosition="Right">
                                            <RequiredField ErrorText="requerido!!!" IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                             <asp:SqlDataSource ID="sdscb_zafra" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>"
                                 SelectCommand="CB_ZAFRA_ACT" SelectCommandType="StoredProcedure">
                                 <SelectParameters>
                                     <asp:Parameter Name="ID_EMPRESA" Type="Int16" DefaultValue="1" />
                                 </SelectParameters>
                             </asp:SqlDataSource>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionStyle Font-Bold="True"></CaptionStyle>
                </dx:LayoutItem>                 
                <dx:LayoutItem Caption="Fecha" CaptionSettings-HorizontalAlign="Right">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxDateEdit ID="txt_fecha" ClientInstanceName="txt_fecha" runat="server" Enabled="false"  >
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithText" ErrorText="requerido!!!" ErrorTextPosition="Right">
                                    <RequiredField ErrorText="requerido!!!" IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxDateEdit>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                </dx:LayoutItem>               
            </Items>
        </dx:LayoutGroup>     
          <dx:LayoutGroup Caption="Detalle Cierre" ColumnCount="2" ShowCaption="false" GroupBoxDecoration="Box"
            UseDefaultPaddings="false" Paddings-PaddingTop="3">
            <Paddings PaddingTop="3px"></Paddings>
            <GroupBoxStyle>
                <Caption CssClass="title" />
            </GroupBoxStyle>
            <Items>
                <dx:LayoutItem Caption="" ShowCaption="False">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxGridView ID="dgvList" runat="server" AutoGenerateColumns="False" DataSourceID="sqList" Caption="FECHAS"  KeyFieldName="ID_FECHAMOVI">
                                <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                                <SettingsSearchPanel Visible="False" />
                                <Columns>
                                    <dx:GridViewDataTextColumn FieldName="ID_FECHAMOVI" Caption="Id" ReadOnly="True" Visible="false"  ShowInCustomizationForm="True" VisibleIndex="0">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataDateColumn FieldName="FECHA" Caption="Fecha" ShowInCustomizationForm="True" VisibleIndex="1">
                                    </dx:GridViewDataDateColumn>
                                    <dx:GridViewDataCheckColumn FieldName="ACTIVA" Caption="Activo" ShowInCustomizationForm="True" VisibleIndex="2">
                                    </dx:GridViewDataCheckColumn>
                                </Columns>
                            </dx:ASPxGridView>
                                   <asp:SqlDataSource ID="sqList" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>" SelectCommand="VIEW_FECHA_MOVIMIENTO" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                   </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                </dx:LayoutItem>               
            </Items>
        </dx:LayoutGroup> 

    </Items>
</dx:ASPxFormLayout>

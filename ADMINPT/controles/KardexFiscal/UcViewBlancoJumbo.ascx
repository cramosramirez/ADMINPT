<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcViewBlancoJumbo.ascx.cs" Inherits="ADMINPT.controles.KardexFiscal.UcViewBlancoJumbo" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraReports.v20.1.Web.WebForms, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/controles/UCBarraNavegacion.ascx" TagPrefix="uc1" TagName="UCBarraNavegacion" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>


<uc1:UCBarraNavegacion runat="server" id="UCBarraNavegacion" />

<uc1:UCEncabezado runat="server" id="UCEncabezado" />
<dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server"></dx:ASPxFormLayout>
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
                
                        <dx:LayoutItem Caption="Bodega Origen" ColumnSpan="2" CaptionStyle-Font-Bold="false" ClientVisible="true">
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
                        <dx:LayoutItem Caption="Fecha De" CaptionSettings-HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit ID="txt_fechad" ClientInstanceName="txt_fechad" runat="server"   >
                                        <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                        <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithText" ErrorText="requerido!!!" ErrorTextPosition="Right">
                                            <RequiredField ErrorText="requerido!!!" IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                        </dx:LayoutItem>
                    <dx:LayoutItem Caption="Fecha Hasta" CaptionSettings-HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit ID="txt_fechah" ClientInstanceName="txt_fechah" runat="server"   >
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
            </Items>
        </dx:ASPxFormLayout>
 <dx:ASPxLoadingPanel ID="ldnPanel" runat="server" Text="Procesando Datos..." ClientInstanceName="ldnPanel" Theme="MaterialCompact" 
        Modal="True">
    </dx:ASPxLoadingPanel>
   <script>
    function Init(s, e) {
        // s.GetReportPreview().zoom(0.9);
        s.GetReportPreview().zoom(DevExpress.Reporting.Viewer.ZoomAutoBy.PageWidth);
    }
   </script>
<table style="width: 100%;">
    <tr>
        <td>
<dx:ASPxWebDocumentViewer ID="Facturado" runat="server" EnableViewState="true" >
     <ClientSideEvents Init="Init"/>
</dx:ASPxWebDocumentViewer>
</td>
    </tr>
</table>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcViewMovientosDizucarPeriodo.ascx.cs" Inherits="ADMINPT.controles.movimiento_traslado.UcViewMovientosDizucarPeriodo" %>
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
                        <dx:LayoutItem Caption="Bodega Origen" ColumnSpan="2" CaptionStyle-Font-Bold="true" ClientVisible="true">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                             <dx:ASPxComboBox ID="cb_bodega" runat="server" ValueType="System.Int32" Enabled="false" >
                                                            <Items>
                                                                <dx:ListEditItem Text="INJIBOA 1" Value="29" Selected="true"/>                                                                
                                                                <dx:ListEditItem Text="ALMACONSA" Value="16" />
                                                            </Items>
                                  <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithText" ErrorText="requerido!!!" ErrorTextPosition="Right">
                                    <RequiredField ErrorText="requerido!!!" IsRequired="True" />
                                </ValidationSettings>
                                                        </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>

                    <CaptionStyle Font-Bold="True"></CaptionStyle>
                </dx:LayoutItem>
                        <dx:LayoutItem Caption="Moviento" ColumnSpan="2" CaptionStyle-Font-Bold="true" ClientVisible="true">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                             <dx:ASPxComboBox ID="cb_movimiento" runat="server" ValueType="System.Int32" >
                                                            <Items>
                                                                <dx:ListEditItem Text="Despacho Venta - Dizucar Central" Value="27" Selected="true"/>                                                                
                                                                <dx:ListEditItem Text="Traslado - Dizucar Central" Value="18" />
                                                                <dx:ListEditItem Text="Traslado - Dizucar CE#5" Value="13" />
                                                            </Items>
                                  <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithText" ErrorText="requerido!!!" ErrorTextPosition="Right">
                                    <RequiredField ErrorText="requerido!!!" IsRequired="True" />
                                </ValidationSettings>
                                                        </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>

                    <CaptionStyle Font-Bold="True"></CaptionStyle>
                </dx:LayoutItem>
                   <dx:LayoutItem Caption="Fecha Desde" CaptionSettings-HorizontalAlign="Right">
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
                   <dx:LayoutItem Caption="Hasta" CaptionSettings-HorizontalAlign="Right" >
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
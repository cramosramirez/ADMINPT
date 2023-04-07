<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcViewNotas.ascx.cs" Inherits="ADMINPT.controles.Facturado.UcViewNotas" %>
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
                       <dx:LayoutItem Caption="" ShowCaption="False"  CaptionSettings-HorizontalAlign="Right" ColumnSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxRadioButtonList ID="rdOpciones" runat="server" ValueType="System.String" RepeatDirection="Horizontal" SelectedIndex="0">
                                        <Items>
                                            <dx:ListEditItem Selected="True" Text="Traslado Externo" Value="1" />
                                            <dx:ListEditItem Text="Venta de Azucar Jiboa" Value="2" />
                                            <dx:ListEditItem Text="Venta de Azucar Jiboa Empacada" Value="3" />
                                            <dx:ListEditItem Text="Venta de Melaza Jiboa" Value="4" />
                                            <dx:ListEditItem Text="Traslado - Dizucar Central" Value="5" />
                                        </Items>
                                    </dx:ASPxRadioButtonList>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                        </dx:LayoutItem>
                        
                        <dx:LayoutItem Caption="Fecha" CaptionSettings-HorizontalAlign="Right">
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
                   <dx:LayoutItem Caption="N° Documento" CaptionSettings-HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtNDocumento" runat="server"  AutoCompleteType="Disabled">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black">
                                </DisabledStyle>
                                <ClientSideEvents KeyPress="function(s,e){ Numericint(s,e);}" />
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                                    </dx:ASPxTextBox>
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
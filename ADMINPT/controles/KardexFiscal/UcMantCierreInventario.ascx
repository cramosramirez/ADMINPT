<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantCierreInventario.ascx.cs" Inherits="ADMINPT.controles.KardexFiscal.UcMantCierreInventario" %>
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
                
                        
                        <dx:LayoutItem Caption="Fecha de Cierre" CaptionSettings-HorizontalAlign="Right">
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
                                    <dx:ASPxDateEdit ID="txt_fechah" ClientInstanceName="txt_fechah" runat="server">
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
   
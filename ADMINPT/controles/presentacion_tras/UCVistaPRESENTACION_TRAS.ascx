<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCVistaPRESENTACION_TRAS.ascx.cs" Inherits="ADMINPT.controles.presentacion_tras.UCVistaPRESENTACION_TRAS" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" Theme="Moderno" Width="100%">
    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit">
    </SettingsAdaptivity>
    <Items>
        <dx:LayoutGroup ColCount="5" Caption="Datos de Presentacion Traslado"  Name="lgPRESENTACION_TRAS" GroupBoxDecoration="HeadingLine">
            <Items>
            <dx:LayoutItem Caption="" ColSpan="1" Name="">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">                        
                        <table class="tablaVista" >
                            <tr>
                                <td class="filaVista" ><dx:ASPxLabel runat="server" ID="lblPRESENTACION_TRAS" Text="Identificador:" ></dx:ASPxLabel></td>
                                <td class="filaVista">
                                    <dx:ASPxTextBox ID="txtIdentificador" runat="server" ClientEnabled="false"  >
                                        <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle> 
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="filaVista"><dx:ASPxLabel runat="server" ID="ASPxLabel1" Text="Nombre:" ></dx:ASPxLabel></td>
                                <td class="filaVista">
                                    <dx:ASPxTextBox ID="txtNOMBRE_PRESEN_TRAA" runat="server" Width="400px" >
                                        <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                        <ValidationSettings Display="Dynamic">
                                            <RequiredField IsRequired="True" ErrorText="Presentacion Traslado es requerido" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="filaVista"><dx:ASPxLabel runat="server" ID="ASPxLabel3" Text="Activo" ></dx:ASPxLabel></td>
                                <td class="filaVista">
                                    <dx:ASPxCheckBox ID="chkESTADO" runat="server"></dx:ASPxCheckBox>
                                </td>
                            </tr>
                        </table>                          
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>                
            </dx:LayoutItem>  
            </Items>
        </dx:LayoutGroup>
    </Items>
</dx:ASPxFormLayout>
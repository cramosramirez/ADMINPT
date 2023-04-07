<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcVistaEXISTENCIA.ascx.cs" Inherits="ADMINPT.controles.existencia.UcVistaEXISTENCIA" %>

<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" Theme="Moderno" Width="100%">
    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit">
    </SettingsAdaptivity>
    <Items>
        <dx:LayoutGroup ColCount="1" Caption="Datos de Producto"  Name="lgPRODUCTO" GroupBoxDecoration="HeadingLine" Width="100%">
            <Items>
            <dx:LayoutItem Caption="" Name="">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">                        
                        <table class="tablaVista">
                            <tr>
                                <td class="filaVista" ><dx:ASPxLabel runat="server" ID="lblPRODUCTO" Text="Identificador:" ></dx:ASPxLabel></td>
                                <td class="filaVista">
                                    <dx:ASPxTextBox ID="txtIdentificador" runat="server" ClientEnabled="false"  >
                                        <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle> 
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                             <tr>                     
                                <td class="filaVista">
                                    <dx:ASPxCheckBox ID="chkESTADO" runat="server" TextAlign="Left" Text="Activo" />
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
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcVistaTURNO.ascx.cs" Inherits="ADMINPT.controles.turno.UcVistaTURNO" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" Theme="Moderno" Width="100%">
    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit">
    </SettingsAdaptivity>
    <Items>
        <dx:LayoutGroup ColCount="5" Caption="Datos de Turno"  Name="lgTURNO" GroupBoxDecoration="HeadingLine">
            <Items>
            <dx:LayoutItem Caption="" ColSpan="1" Name="">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">                        
                        <table class="tablaVista" >
                            <tr>
                                <td class="filaVista" ><dx:ASPxLabel runat="server" ID="lblTURNO" Text="Identificador:" ></dx:ASPxLabel></td>
                                <td class="filaVista">
                                    <dx:ASPxTextBox ID="txtIdentificador" runat="server" ClientEnabled="false"  >
                                        <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle> 
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="filaVista"><dx:ASPxLabel runat="server" ID="ASPxLabel1" Text="Horario:" ></dx:ASPxLabel></td>
                                <td class="filaVista" >
                                    <dx:ASPxTextBox ID="txtHorario" runat="server" Width="400px" >
                                        <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                        <ValidationSettings Display="Dynamic">
                                            <RequiredField IsRequired="True" ErrorText="Horario es requerido" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                 <td class="filaVista" ><dx:ASPxLabel runat="server" ID="ASPxLabel3" Text="Activo:" ></dx:ASPxLabel></td>
                                <td class="filaVista">
                                    <dx:ASPxCheckBox ID="ckEstado" runat="server" Checked="True" CheckState="Unchecked" ValueType="System.Boolean"><DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle></dx:ASPxCheckBox>
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
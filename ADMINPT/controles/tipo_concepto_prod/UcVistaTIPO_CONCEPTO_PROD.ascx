<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcVistaTIPO_CONCEPTO_PROD.ascx.cs" Inherits="ADMINPT.controles.tipo_concepto_prod.UcVistaTIPO_CONCEPTO_PROD" %>

<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" Theme="Moderno" Width="100%">
    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit">
    </SettingsAdaptivity>
    <Items>
        <dx:LayoutGroup ColCount="5" Caption="Datos de Tipo Movimiento Producto"  Name="lgTIPO_CONCEPTO_PROD" GroupBoxDecoration="HeadingLine" Width="100%">
            <Items>
            <dx:LayoutItem Caption="" Name="">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">                        
                        <table class="tablaVista">
                            <tr>
                                <td class="filaVista" ><dx:ASPxLabel runat="server" ID="lblTIPO_CONCEPTO_PROD" Text="Identificador:" ></dx:ASPxLabel></td>
                                <td class="filaVista">
                                    <dx:ASPxTextBox ID="txtIdentificador" runat="server" ClientEnabled="false"  >
                                        <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle> 
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="filaVista" ><dx:ASPxLabel runat="server" ID="ASPxLabel5" Text="Tipo Concepto" ></dx:ASPxLabel></td>
                                <td>
                                    <dx:ASPxComboBox ID="cbxTipoConcepto" runat="server" Width="300px" TextField="NOMBRE_CONCEPTO" ValueField="ID_TIPO_CONCEPTO" ValueType="System.Int32">
                                        <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                        <ValidationSettings Display="Dynamic">
                                            <RequiredField IsRequired="True" ErrorText="Tipo Concepto" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </td>
                                </tr>
                            <tr>
                                <td class="filaVista" ><dx:ASPxLabel runat="server" ID="ASPxLabel6" Text="Tipo Producto:" ></dx:ASPxLabel></td>
                                <td>
                                    <dx:ASPxComboBox ID="cbxTipoProducto" runat="server" Width="300px" TextField="NOMBRE_TIPO" ValueField="ID_TIPO_PROD" ValueType="System.Int32">
                                        <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                        <ValidationSettings Display="Dynamic">
                                            <RequiredField IsRequired="True" ErrorText="Tipo Producto" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </td>
                            </tr>
                             <tr>
                                 <td class="filaVista" ><dx:ASPxLabel runat="server" ID="ASPxLabel3" Text="Activo:" ></dx:ASPxLabel></td>
                                <td class="filaVista">
                                    <dx:ASPxCheckBox ID="chkESTADO" runat="server" Checked="True" CheckState="Unchecked" ValueType="System.Boolean"><DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle></dx:ASPxCheckBox>
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
<asp:ObjectDataSource ID="odsTIPO_CONCEPTO" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CTIPO_CONCEPTO"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsTIPO_PRODUCTO" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CTIPO_PRODUCTO"></asp:ObjectDataSource>

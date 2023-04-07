<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcVistaPRODUCTO.ascx.cs" Inherits="ADMINPT.controles.producto.UcVistaPRODUCTO" %>
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
                                <td class="filaVista"><dx:ASPxLabel runat="server" ID="ASPxLabel1" Text="Código:" ></dx:ASPxLabel></td>
                                <td class="filaVista">
                                    <dx:ASPxTextBox ID="txtCODI_PRODUCTO" runat="server" Width="200px" >
                                        <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                        <ValidationSettings Display="Dynamic">
                                            <RequiredField IsRequired="True" ErrorText="Nombre tipo" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                               <td class="filaVista" ><dx:ASPxLabel runat="server" ID="ASPxLabel3" Text="Nombre producto:" ></dx:ASPxLabel></td>
                                <th class="filaVista" colspan="3">
                                    <dx:ASPxTextBox ID="txtNOMBRE_PRODUCTO" runat="server" Width="100%" >
                                        <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                        <ValidationSettings Display="Dynamic">
                                            <RequiredField IsRequired="True" ErrorText="Nombre Producto" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </th>
                            </tr>    
                            <tr>
                               <td class="filaVista" ><dx:ASPxLabel runat="server" ID="ASPxLabel2" Text="Nombre en kardex:" ></dx:ASPxLabel></td>
                                <th class="filaVista" colspan="3">
                                    <dx:ASPxTextBox ID="txtNOMBRE_KARDEX" runat="server" Width="100%" >
                                        <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                        <ValidationSettings Display="Dynamic">
                                            <RequiredField IsRequired="True" ErrorText="Nombre kardex" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </th>
                            </tr>   
                            <tr>
                               <td class="filaVista" ><dx:ASPxLabel runat="server" ID="ASPxLabel4" Text="Nombre para venta:" ></dx:ASPxLabel></td>
                                <th class="filaVista" colspan="3">
                                    <dx:ASPxTextBox ID="txtNOMBRE_VENTA" runat="server" Width="100%" >
                                        <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                        <ValidationSettings Display="Dynamic">
                                            <RequiredField IsRequired="True" ErrorText="Nombre Venta" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </th>
                            </tr>   
                            <tr>
                                <td class="filaVista" ><dx:ASPxLabel runat="server" ID="ASPxLabel5" Text="Tipo de producto:" ></dx:ASPxLabel></td>
                                <td>
                                    <dx:ASPxComboBox ID="cbxTIPO_PRODUCTO" runat="server" Width="100%" TextField="NOMBRE_TIPO" ValueField="ID_TIPO_PROD" ValueType="System.Int32">
                                        <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                        <ValidationSettings Display="Dynamic">
                                            <RequiredField IsRequired="True" ErrorText="Tipo producto" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </td>
                                <td class="filaVista" ><dx:ASPxLabel runat="server" ID="ASPxLabel6" Text="Unidad para CONSAA:" ></dx:ASPxLabel></td>
                                <td>
                                    <dx:ASPxComboBox ID="cbxUNIDAD_MEDI_CONSAA" runat="server" Width="100%" TextField="NOMBRE_UNIDAD" ValueField="ID_UNIDAD_CONSAA" ValueType="System.Int32">
                                        <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                        <ValidationSettings Display="Dynamic">
                                            <RequiredField IsRequired="True" ErrorText="Tipo producto" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="filaVista" ><dx:ASPxLabel runat="server" ID="ASPxLabel7" Text="Unidad para facturación:" ></dx:ASPxLabel></td>
                                <td>
                                    <dx:ASPxComboBox ID="cbxUNIDAD_MEDI_FAC" runat="server" Width="100%" TextField="NOMBRE_UNIDAD" ValueField="ID_UNIDAD_FAC" ValueType="System.Int32">
                                        <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                        <ValidationSettings Display="Dynamic">
                                            <RequiredField IsRequired="True" ErrorText="Tipo producto" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </td>
                                <td class="filaVista" ><dx:ASPxLabel runat="server" ID="ASPxLabel8" Text="Marca:" ></dx:ASPxLabel></td>
                                <td>
                                    <dx:ASPxComboBox ID="cbxMARCA" runat="server" Width="100%" TextField="NOMBRE_MARCA" ValueField="ID_MARCA" ValueType="System.Int32">
                                        <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                        <ValidationSettings Display="Dynamic">
                                            <RequiredField IsRequired="True" ErrorText="Tipo producto" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="filaVista">
                                    <dx:ASPxCheckBox ID="chkAPLICA_VTA" runat="server" TextAlign="Left" Text="Aplica para venta" />
                                </td>
                                <td class="filaVista">
                                    <dx:ASPxCheckBox ID="chkAPLICA_TRAS" runat="server" TextAlign="Left" Text="Aplica para traslado" />
                                </td>
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
<asp:ObjectDataSource ID="odsTIPO_PRODUCTO" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CTIPO_PRODUCTO"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsUNIDAD_MEDI_CONSAA" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CUNIDAD_MEDI_CONSAA"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsUNIDAD_MEDI_FAC" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CUNIDAD_MEDI_FAC"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsMARCA" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CMARCA"></asp:ObjectDataSource>

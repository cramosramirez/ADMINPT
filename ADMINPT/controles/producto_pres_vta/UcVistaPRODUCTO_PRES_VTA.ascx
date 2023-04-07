﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcVistaPRODUCTO_PRES_VTA.ascx.cs" Inherits="ADMINPT.controles.producto_pres_vta.UcVistaPRODUCTO_PRES_VTA" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" Theme="Moderno" Width="100%">
    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit">
    </SettingsAdaptivity>
    <Items>
        <dx:LayoutGroup ColCount="5" Caption="Datos de Producto Presentación de Venta"  Name="lgProductoPresVenta" GroupBoxDecoration="HeadingLine">
            <Items>
            <dx:LayoutItem Caption="" ColSpan="1" Name="">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">                        
                        <table class="tablaVista" >
                            <tr>
                                <td class="filaVista" ><dx:ASPxLabel runat="server" ID="lblProductoPresVenta" Text="Identificador:" ></dx:ASPxLabel></td>
                                <td class="filaVista">
                                    <dx:ASPxTextBox ID="txtIdentificador" runat="server" ClientEnabled="false" TabIndex="1"  >
                                        <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle> 
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="filaVista"><dx:ASPxLabel runat="server" ID="ASPxLabel1" Text="Producto:" ></dx:ASPxLabel></td>
                                <td class="filaVista" >
                                    <dx:ASPxComboBox ID="cbProducto" runat="server" Width="100%" TextField="NOMBRE_KARDEX" ValueField="ID_PRODUCTO" ValueType="System.Int32">
                                        <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                    </dx:ASPxComboBox>
                                </td>
                            </tr>    
                            <tr>
                                <td class="filaVista"><dx:ASPxLabel runat="server" ID="ASPxLabel2" Text="Presentación:" ></dx:ASPxLabel></td>
                                <td class="filaVista" >
                                    <dx:ASPxComboBox ID="cbPresentacionvta" runat="server" Width="100%" TextField="NOMBRE_PRESEN_VTA" ValueField="ID_PRESEN_VTA" ValueType="System.Int32">
                                        <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                    </dx:ASPxComboBox>
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
<asp:ObjectDataSource ID="odsPRODUCTO" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CPRODUCTO"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsPRESENTACION_VTA" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CPRESENTACION_VTA"></asp:ObjectDataSource>


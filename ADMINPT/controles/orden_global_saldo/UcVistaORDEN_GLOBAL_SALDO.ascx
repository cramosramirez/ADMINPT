<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcVistaORDEN_GLOBAL_SALDO.ascx.cs" Inherits="ADMINPT.controles.orden_global_saldo.UcVistaORDEN_GLOBAL_SALDO" %>


<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<style type="text/css">
    .formLayout {
        max-width: 1300px;
        margin: auto;
    }

    .wrapfly {
        white-space: normal;
        word-wrap: normal
    }
</style>
<dx:ASPxLabel ID="lbl_mensaje" runat="server" Text="" ForeColor="Red" Visible="false"></dx:ASPxLabel>
<dx:ASPxFormLayout ID="formLayout" runat="server" Theme="Default">
   <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
    <Items>
        <dx:LayoutGroup Caption="Información de Ordenes de Traslados" ColCount="3" GroupBoxDecoration="HeadingLine" UseDefaultPaddings="false" Paddings-PaddingTop="0px">
<Paddings PaddingTop="0px"></Paddings>
            <Items>
               
                <dx:LayoutItem Caption="Nº Sistema(id)">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxTextBox ID="txtIdentificador" runat="server" ClientEnabled="false">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Fecha">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxDateEdit ID="dteFecha" runat="server" EditFormat="Custom" EditFormatString="dd/MM/yyyy">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxDateEdit>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                      <dx:LayoutItem Caption=""  >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>  
                <dx:LayoutItem Caption="Orden Traslado" ColumnSpan="3">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxORDEN_GLOBAL_TRAS" runat="server" AutoPostBack="true" TextField="NOMBREDT" ValueField="ID_ORDEN_TRAS" ValueType="System.Int32" OnTextChanged="cbxORDEN_GLOBAL_TRAS_TextChanged">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ClearButton DisplayMode="Always"></ClearButton>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem> 
                  <dx:LayoutItem Caption="Solicitante" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>                         
                            <dx:ASPxComboBox ID="cbxSolicitante" runat="server" TextField="NOMBRE" ValueField="ID_SOLICITANTE" ValueType="System.Int32" ClientEnabled="false">
                                 <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>         
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                            </ValidationSettings>
                                        </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Referencia">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                           <dx:ASPxComboBox ID="cbxTIPO_REF_TRAS" runat="server" TextField="NOMBRE" ValueField="ID_REF" ValueType="System.Int32" AutoPostBack="true" OnTextChanged="cbxTIPO_REF_TRAS_TextChanged" ClientEnabled="false">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                            <ValidationSettings Display="Dynamic">
                                                <RequiredField IsRequired="True" ErrorText="Lista Especifico Requerido!!" />
                                            </ValidationSettings>
                                        </dx:ASPxComboBox>                                        
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
              <dx:LayoutItem Caption="#Referencia">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                          <dx:ASPxTextBox ID="txtDocumento" runat="server"   AutoPostBack="false" Text="0" AutoCompleteType="Disabled" ClientEnabled="false">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                        </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>                
                <dx:LayoutItem Caption="Producto" ColumnSpan="3" Width="100%">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxProducto"  Font-Bold ="true"   runat="server" TextField="NOMBRE_KARDEX" ValueField="ID_PRODUCTO" ValueType="System.Int32" AutoPostBack="true" OnTextChanged="cbxProducto_TextChanged" ClientEnabled="false">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Tipo Inventario">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <table>
                                <tr>
                                    <td>
                                        <dx:ASPxRadioButton ID="rb_propio" runat="server" ClientEnabled="false" Text="Propio" TextAlign="right" TextSpacing="1px" Checked="true" GroupName="tpi"></dx:ASPxRadioButton>
                                    </td>
                                    <td>
                                        <dx:ASPxRadioButton ID="rb_Ajeno" runat="server" Text="Ajeno" ClientEnabled="false" TextAlign="right" TextSpacing="1px" GroupName="tpi"></dx:ASPxRadioButton>
                                    </td>
                                </tr>
                            </table>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Presentación">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxPrestanciontras" runat="server" TextField="NOMBRE_PRESEN_TRAA" ValueField="ID_PRESEN_TRAS" ValueType="System.Int32" ClientEnabled="false">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Unidad" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxUnidad" runat="server" ClientEnabled="false" TextField="NOMBRE_UNIDAD" ValueField="ID_UNIDAD_FAC" ValueType="System.Int32">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Factor(qq/gal)" ClientVisible ="false" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxSpinEdit ID="speFactor" ClientInstanceName="speFactor" runat="server" Number="0">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                                <SpinButtons ShowIncrementButtons="false"></SpinButtons>
                            </dx:ASPxSpinEdit>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Factor(kg)" ClientVisible ="false" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxSpinEdit ID="speFactorKg" ClientInstanceName="speFactor" runat="server" Number="0">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                                <SpinButtons ShowIncrementButtons="false"></SpinButtons>
                            </dx:ASPxSpinEdit>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="" ClientVisible ="false" >
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Zafra del producto">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxZafraProd" Font-Bold="true" ForeColor="Maroon"  runat="server" ClientEnabled="false" TextField="NOMBRE_ZAFRA" ValueField="ID_ZAFRA" ValueType="System.Int32" AutoPostBack="true" OnTextChanged="cbxZafraProd_TextChanged">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Zafra en curso">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxZafraActual" runat="server"  TextField="NOMBRE_ZAFRA" ValueField="ID_ZAFRA" ValueType="System.Int32" ClientEnabled="false">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Tipo Movimiento">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxtipoMovimiento" runat="server" ClientEnabled="false" TextField="NOMBRE_MOV" ValueField="ID_TIPO_MOV" ValueType="System.Int32" AutoPostBack="true" OnTextChanged="cbxtipoMovimiento_TextChanged">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Concepto">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxConceptoTM" runat="server" ClientEnabled="false" TextField="NOMBRE_CONCE" ValueField="ID_CONCE" ValueType="System.Int32" AutoPostBack="true" OnTextChanged="cbxConceptoTM_TextChanged">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                   <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Especifico">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxEspecifico" runat="server" ClientEnabled="false" TextField="NOMBRE_ESPECI" ValueField="ID_ESPECI" ValueType="System.Int32" AutoPostBack="true">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                   <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Bodega Origen" ColumnSpan="2">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxBodegaOrigen" runat="server" ClientEnabled="false" TextField="NOMBRE" ValueField="ID_BODEGA" ValueType="System.Int32" AutoPostBack="true" OnTextChanged="cbxBodegaOrigen_TextChanged">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                   <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Bodega Destino" ColumnSpan="2">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxComboBox ID="cbxBodegaDestino" runat="server" ClientEnabled="false" TextField="NOMBRE" ValueField="ID_BODEGA" ValueType="System.Int32" AutoPostBack="true" OnTextChanged="cbxBodegaDestino_TextChanged">
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                
                 <dx:LayoutItem Caption="Nueva Ampliacion">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                            <dx:ASPxSpinEdit ID="speCantidad" ClientInstanceName="speCantidad" runat="server" Number="0" ReadOnly="false"  AutoPostBack ="true"  >
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                                <SpinButtons ShowIncrementButtons="false"></SpinButtons>
                                <%--<ClientSideEvents KeyPress="OnKeyPress" NumberChanged  ="_Cantidad" />--%>
                            </dx:ASPxSpinEdit>
                            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Disponible  " ForeColor="Green" Visible="true"></dx:ASPxLabel>
                            <dx:ASPxLabel ID="lblSaldo" runat="server" Text="" ForeColor="Green" Visible="true"></dx:ASPxLabel>
                            <dx:ASPxLabel ID="lblPresentacion" runat="server" Text="" ForeColor="Green" Visible="false"></dx:ASPxLabel>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>

                 <dx:LayoutItem Caption="Asignacion Original">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                       <dx:ASPxSpinEdit ID="txtAsignacionO" ClientInstanceName="txtAsignacionO" runat="server" Number="0" ClientEnabled="false">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                            <ValidationSettings Display="Dynamic">
                                                <RequiredField IsRequired="True" ErrorText="Cantidad" />
                                            </ValidationSettings>
                                        </dx:ASPxSpinEdit>
                         </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Ampliaciones">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                       <dx:ASPxSpinEdit ID="txtAmpliaciones" ClientInstanceName="txtAmpliaciones" runat="server" Number="0" ClientEnabled="false">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                            <ValidationSettings Display="Dynamic">
                                                <RequiredField IsRequired="True" ErrorText="Cantidad" />
                                            </ValidationSettings>
                                        </dx:ASPxSpinEdit>
                         </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                 <dx:LayoutItem Caption="Asignacion Total">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                       <dx:ASPxSpinEdit ID="txtAsignacionT" ClientInstanceName="txtAsignacionT" runat="server" Number="0" ClientEnabled="false">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                            <ValidationSettings Display="Dynamic">
                                                <RequiredField IsRequired="True" ErrorText="Cantidad" />
                                            </ValidationSettings>
                                        </dx:ASPxSpinEdit>
                         </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                 <dx:LayoutItem Caption="Ejecutado">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                       <dx:ASPxSpinEdit ID="txtEjecutado" ClientInstanceName="txtEjecutado" runat="server" Number="0" ClientEnabled="false">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                            <ValidationSettings Display="Dynamic">
                                                <RequiredField IsRequired="True" ErrorText="Cantidad" />
                                            </ValidationSettings>
                                        </dx:ASPxSpinEdit>
                         </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Saldo">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                       <dx:ASPxSpinEdit ID="txtSaldo" ClientInstanceName="txtSaldo" runat="server" Number="0" ClientEnabled="false">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                            <ValidationSettings Display="Dynamic">
                                                <RequiredField IsRequired="True" ErrorText="Cantidad" />
                                            </ValidationSettings>
                                        </dx:ASPxSpinEdit>
                         </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Activo">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                        <dx:ASPxCheckBox ID="ckEstado" runat="server" Checked="True" CheckState="checked" ValueType="System.Boolean">
                                            <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                        </dx:ASPxCheckBox>
                         </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Observación" ColumnSpan ="2">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer>
                        <dx:ASPxMemo ID="txtObservacion" runat="server" Height="35px" Width="100%"></dx:ASPxMemo>
                         </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
               
            </Items>
        </dx:LayoutGroup>
    </Items>
</dx:ASPxFormLayout>

<%--ENCABEZADO--%>
<asp:ObjectDataSource ID="odsKARDEX_BODEGA" runat="server" SelectMethod="ObtenerPorIdBodega" TypeName="ADMINPT.BL.CKARDEX">
    <SelectParameters>
        <asp:Parameter Name="ID_PRODUCTO" DefaultValue="-1" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsPROVEEDOR_TRAS" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CPROVEEDOR_TRAS"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsTRANSPORTE" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CTRANSPORTE"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsESTADO_MOVIMIENTOS" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CESTADO_MOVIMIENTOS"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsORDEN_GLOBAL_TRAS" runat="server" SelectMethod="ObtenerListaCb" TypeName="ADMINPT.BL.CORDEN_GLOBAL_TRAS"> <SelectParameters> <asp:SessionParameter Name="ID_BODEP" SessionField="ID_BODEP" Type="Int32" /> </SelectParameters> </asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsBODEGAOrigen" runat="server" SelectMethod="ObtenerListaBodegaOrigen" TypeName="ADMINPT.BL.CBODEGA"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsTIPO_MOVIMIENTO" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CTIPO_MOVIMIENTO"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsBODEGADestino" runat="server" SelectMethod="ObtenerPorIdBodegaOT" TypeName="ADMINPT.BL.CKARDEX">
    <SelectParameters>
        <asp:Parameter Name="ID_PRODUCTO" DefaultValue="-1" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="odsZAFRA_ACTUAL" runat="server" SelectMethod="ObtenerListaActiva" TypeName="ADMINPT.BL.CZAFRA"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsZAFRA_PROD" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CZAFRA"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsDIA_ZAFRA" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CDIA_ZAFRA"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsTURNO" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CTURNO"></asp:ObjectDataSource>
<%--DETALLE--%>
<asp:ObjectDataSource ID="odsPRODUCTO" runat="server" SelectMethod="ObtenerListaTraslado" TypeName="ADMINPT.BL.CPRODUCTO"></asp:ObjectDataSource>

<asp:ObjectDataSource ID="odsCTIPO_CONCEPTO_PRODdt" runat="server" SelectMethod="ObtenerPorIdProducto" TypeName="ADMINPT.BL.CTIPO_CONCEPTO">
    <SelectParameters>
        <asp:Parameter Name="id" DefaultValue="-1" Type="Int32" />
        <asp:Parameter Name="ent" DefaultValue="1" Type="Int32" />
        <asp:Parameter Name="sali" DefaultValue="0" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>


<asp:ObjectDataSource ID="odsCONCEPTO_MOVI" runat="server" SelectMethod="ObtenerPorIdTMTraslado" TypeName="ADMINPT.BL.CCONCEPTO_MOVI">
    <SelectParameters>
        <asp:Parameter Name="ID_PRODUCTO" DefaultValue="-1" Type="Int32" />
        <asp:Parameter Name="ID_TIPO_MOV" DefaultValue="-1" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="odsESPECI_MOV" runat="server" SelectMethod="ObtenerPorIdTC" TypeName="ADMINPT.BL.CESPECI_MOV">
    <SelectParameters>
        <asp:Parameter Name="id" DefaultValue="-1" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="odsPRESENTACION_TRAS" runat="server" SelectMethod="ObtenerPorIdProducto" TypeName="ADMINPT.BL.CPRESENTACION_TRAS">
    <SelectParameters>
        <asp:Parameter Name="id" DefaultValue="-1" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsPRESENTACION_VTA" runat="server" SelectMethod="ObtenerPorIdProducto" TypeName="ADMINPT.BL.CPRESENTACION_VTA">
    <SelectParameters>
        <asp:Parameter Name="id" DefaultValue="-1" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsUNIDAD_MEDI_CONSAA" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CUNIDAD_MEDI_CONSAA"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsUNIDAD_MEDI_FAC" runat="server" SelectMethod="ObtenerPorIdProducto" TypeName="ADMINPT.BL.CUNIDAD_MEDI_FAC">
    <SelectParameters>
        <asp:Parameter Name="id" DefaultValue="-1" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="odsSOLICITANTE" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CSOLICITANTE"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsTIPO_REF_TRAS" runat="server" SelectMethod="ObtenerLista" TypeName="ADMINPT.BL.CTIPO_REF_TRAS"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsBodegaOUser" runat="server" SelectMethod="ObtenerListaBodegaOrigen" TypeName="ADMINPT.BL.CBODEGA">
    <SelectParameters>
         <asp:SessionParameter Name="ID_BODEP" SessionField="ID_BODEP" Type="Int32" />
        <asp:Parameter Name="ID_PRODUCTO" DefaultValue="-1" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsBodegaDUser" runat="server" SelectMethod="ObtenerListaBodegaDestino" TypeName="ADMINPT.BL.CBODEGA">
    <SelectParameters>
         <asp:SessionParameter Name="ID_BODEP" SessionField="ID_BODEP" Type="Int32" />
        <asp:Parameter Name="ID_PRODUCTO" DefaultValue="-1" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
 <dx:ASPxLoadingPanel ID="ldnPanel" runat="server" Text="Procesando Datos..." ClientInstanceName="ldnPanel" Theme="MaterialCompact" 
        Modal="True">
    </dx:ASPxLoadingPanel>
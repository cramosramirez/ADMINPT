<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcViewTransito.ascx.cs" Inherits="ADMINPT.controles.movimientos_registroTraslado.UcViewTransito" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraReports.v20.1.Web.WebForms, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/controles/UCBarraNavegacion.ascx" TagPrefix="uc1" TagName="UCBarraNavegacion" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>

    <script type="text/javascript">
        function ShowLoginWindow() {
            pcLogin.Show();
        }
        

    </script>
<dx:ASPxLabel ID="lbmensaje" runat="server" Text=""></dx:ASPxLabel>
<uc1:UCBarraNavegacion runat="server" id="UCBarraNavegacion" />
<uc1:UCEncabezado runat="server" id="UCEncabezado" />
<dx:ASPxGridView ID="gv" ClientInstanceName="gv" runat="server" AutoGenerateColumns="False" 
    DataSourceID="Sds_ListTrancito" Width="100%" KeyFieldName="FECHA;NUM_DOC;NOMBRE_KARDEX" OnRowCommand="gv_RowCommand" >
            <Columns>
            <dx:GridViewDataTextColumn  ShowInCustomizationForm="True" Width="50px" VisibleIndex="0">
        <DataItemTemplate>
         <dx:ASPxButton ID="btnAddBasket" runat="server" Text="Procesar" CommandName="AddBasket">
             <Image IconID="spreadsheet_tableconverttorange_16x16"></Image>
         </dx:ASPxButton>
        </DataItemTemplate>
        <EditFormSettings VisibleIndex="1" />
       </dx:GridViewDataTextColumn>
        <dx:GridViewDataDateColumn FieldName="FECHA" Caption="Fecha Documento" Width="50px" VisibleIndex="1">
        </dx:GridViewDataDateColumn>
        <dx:GridViewDataDateColumn FieldName="NUM_DOC"  Caption="N° Documento" Width="40px" VisibleIndex="2">
        </dx:GridViewDataDateColumn>
        <dx:GridViewDataTextColumn FieldName="NOMTRANSPORTE"  Caption="Proveedor Transporte"  Width="150px" ReadOnly="True" VisibleIndex="3">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="PLACA" ReadOnly="True"  Caption="Placa" Width="40px" VisibleIndex="4">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataDateColumn FieldName="FECHA_BRUTO" ReadOnly="True"  Caption="Fecha Salida" Width="50px" VisibleIndex="5">
        </dx:GridViewDataDateColumn>
        <dx:GridViewDataTextColumn FieldName="NOMBRE_KARDEX" Caption="Producto" Width="150px" VisibleIndex="6">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="CANTIDAD"  Caption="Cantida" ReadOnly="True" Width="50px" VisibleIndex="7" PropertiesTextEdit-DisplayFormatString="N2">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="QUINTALAES" Caption="Quintales" ReadOnly="True" Width="50px" VisibleIndex="8" PropertiesTextEdit-DisplayFormatString="N2">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="GALONES" ReadOnly="True" Caption="Galones" Width="50px" VisibleIndex="10" PropertiesTextEdit-DisplayFormatString="N2">
        </dx:GridViewDataTextColumn>
      
    </Columns>
     <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="400" />
        <SettingsPager Mode="ShowPager" />
    
</dx:ASPxGridView>
<asp:SqlDataSource ID="Sds_ListTrancito" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>" 
    SelectCommand="VIEW_PRODUCTO_ENTRANSITO" SelectCommandType="StoredProcedure">
    <SelectParameters>
        <asp:SessionParameter Name="ID_BODEGAD" SessionField="ID_BODEP" Type="Int32" />
    </SelectParameters>
</asp:SqlDataSource>
  <dx:ASPxPopupControl ID="pcLogin" runat="server" Width="500" CloseAction="CloseButton" CloseOnEscape="true" Modal="True" Theme="Moderno"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcLogin"
        HeaderText="Registro de Ingreso" AllowDragging="True" PopupAnimationType="None" EnableViewState="False" AutoUpdatePosition="true">
       <%-- <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup'); tbLogin.Focus(); }" />--%>
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <dx:ASPxPanel ID="Panel1" runat="server" DefaultButton="btOK" Theme="Moderno">
                    <PanelCollection>
                        <dx:PanelContent runat="server">
                            <dx:ASPxFormLayout runat="server" ID="ASPxFormLayout1" Width="100%" Height="100%" Theme="Moderno" ColCount="3" ColumnCount="3">
                                <Items>
                                   
                                    <dx:LayoutItem Caption="Fecha Documento">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>                                               
                                               <dx:ASPxDateEdit ID="txtfechadoc" runat="server" EditFormat="Custom" EditFormatString="dd/MM/yyyy"  ReadOnly="true" >
                                                   <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                          <ValidationSettings EnableCustomValidation="True" ValidationGroup="entryGroup" SetFocusOnError="True"
                                                        ErrorDisplayMode="Text" ErrorTextPosition="Bottom">
                                                        <RequiredField ErrorText="." IsRequired="True" />
                                                        <ErrorFrameStyle Font-Size="10px">
                                                            <ErrorTextPaddings PaddingLeft="0px" />
                                                        </ErrorFrameStyle>
                                                    </ValidationSettings>
                                               </dx:ASPxDateEdit>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="N° Documento">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>  
                                                <dx:ASPxTextBox ID="txtndoc"  runat="server"  ReadOnly="true">
                                                    <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                                       <ValidationSettings EnableCustomValidation="True" ValidationGroup="entryGroup" SetFocusOnError="True"
                                                        ErrorDisplayMode="Text" ErrorTextPosition="Bottom">
                                                        <RequiredField ErrorText="." IsRequired="True" />
                                                        <ErrorFrameStyle Font-Size="10px">
                                                            <ErrorTextPaddings PaddingLeft="0px" />
                                                        </ErrorFrameStyle>
                                                    </ValidationSettings>
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>   
                                    <dx:LayoutItem Caption="Cantida">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>  
                                                <dx:ASPxTextBox ID="txtcantida" runat="server" ReadOnly="true">
                                                    <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                                   <ValidationSettings EnableCustomValidation="True" ValidationGroup="entryGroup" SetFocusOnError="True"
                                                        ErrorDisplayMode="Text" ErrorTextPosition="Bottom">
                                                        <RequiredField ErrorText="." IsRequired="True" />
                                                        <ErrorFrameStyle Font-Size="10px">
                                                            <ErrorTextPaddings PaddingLeft="0px" />
                                                        </ErrorFrameStyle>
                                                    </ValidationSettings>
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>  
                                     <dx:LayoutItem Caption="Producto" ColumnSpan="3" >
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>  
                                                <dx:ASPxTextBox ID="txtProducto" runat="server" ReadOnly="true" Width="100%">
                                                    <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                           <ValidationSettings EnableCustomValidation="True" ValidationGroup="entryGroup" SetFocusOnError="True"
                                                        ErrorDisplayMode="Text" ErrorTextPosition="Bottom">
                                                        <RequiredField ErrorText="." IsRequired="True" />
                                                        <ErrorFrameStyle Font-Size="10px">
                                                            <ErrorTextPaddings PaddingLeft="0px" />
                                                        </ErrorFrameStyle>
                                                    </ValidationSettings>
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>  
                                    <dx:LayoutItem Caption="Fecha Ingreso">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer> 
                                                <dx:ASPxDateEdit ID="txtfechaing" runat="server" EditFormat="Custom" EditFormatString="dd/MM/yyyy" ReadOnly="true" >
                                                    <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                           <ValidationSettings EnableCustomValidation="True" ValidationGroup="entryGroup" SetFocusOnError="True"
                                                        ErrorDisplayMode="Text" ErrorTextPosition="Bottom">
                                                        <RequiredField ErrorText="." IsRequired="True" />
                                                        <ErrorFrameStyle Font-Size="10px">
                                                            <ErrorTextPaddings PaddingLeft="0px" />
                                                        </ErrorFrameStyle>
                                                    </ValidationSettings>
                                                </dx:ASPxDateEdit>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>    
                                    <dx:LayoutItem Caption="Cantidad Ingreso">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>                                                
                                                <dx:ASPxTextBox ID="txtcantidaing" runat="server" >
                                                    <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                           <ValidationSettings EnableCustomValidation="True" ValidationGroup="entryGroup" SetFocusOnError="True"
                                                        ErrorDisplayMode="Text" ErrorTextPosition="Bottom">
                                                        <RequiredField ErrorText="." IsRequired="True" />
                                                        <ErrorFrameStyle Font-Size="10px">
                                                            <ErrorTextPaddings PaddingLeft="0px" />
                                                        </ErrorFrameStyle>
                                                    </ValidationSettings>
                                                </dx:ASPxTextBox>                                                
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem> 
                                    <dx:LayoutItem Caption="Observación" ColumnSpan="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>   
                                                <dx:ASPxMemo ID="observacion" runat="server" Height="71px" Width="100%"></dx:ASPxMemo>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem> 
                                    <dx:LayoutItem ShowCaption="False" Paddings-PaddingTop="19" ColSpan="2" ColumnSpan="2">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxButton ID="bt_guardar" runat="server" Text="Guardar"  Width="80px"  Style="float: left; margin-right: 8px" Theme="Moderno" OnClick="bt_guardar_Click" AutoPostBack="true" >
                                                   <ClientSideEvents Click="function(s, e) { if(ASPxClientEdit.ValidateGroup('entryGroup')) pcLogin.Hide(); }" />
                                               <Image IconID="data_exportmodeldifferences_32x32">
                                                            </Image>
                                                    </dx:ASPxButton>
                                                <dx:ASPxButton ID="btCancel" runat="server" Text="Cancel" Width="80px" AutoPostBack="False" Style="float: left; margin-right: 8px" Theme="Moderno">
                                                    <ClientSideEvents Click="function(s, e) { pcLogin.Hide(); }" />
                                                     <Image IconID="spreadsheet_unfreezepanes_32x32">
                                                            </Image>
                                                </dx:ASPxButton>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

<Paddings PaddingTop="19px"></Paddings>
                                    </dx:LayoutItem>
                                </Items>
                            </dx:ASPxFormLayout>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>                
            </dx:PopupControlContentControl>
        </ContentCollection>
        <HeaderImage IconID="actions_converttorange_32x32">
        </HeaderImage>
        <ContentStyle>
            <Paddings PaddingBottom="5px" />
        </ContentStyle>
    </dx:ASPxPopupControl>


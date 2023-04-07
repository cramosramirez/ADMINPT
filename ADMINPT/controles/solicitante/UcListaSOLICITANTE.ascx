<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcListaSOLICITANTE.ascx.cs" Inherits="ADMINPT.controles.solicitante.UcListaSOLICITANTE" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<dx:ASPxGridView ID="gridLista" runat="server" Theme="Moderno" KeyFieldName="ID_SOLICITANTE" Width="100%"
    OnInit="gridLista_Init" OnRowCommand="gridLista_RowCommand"  >
    <SettingsPager>
        <Summary AllPagesText="Pags: {0} - {1} ({2} registros)" 
            Text="Pag. {0} de {1} ({2} registros)" />
    </SettingsPager>
    <Columns>
        <dx:GridViewCommandColumn ShowSelectCheckbox="True" Name="CheckSeleccionar" Caption=" " Width="10px" Visible="false" VisibleIndex="0" />
        <dx:GridViewDataTextColumn Visible="true" Caption="Editar" Name="Editar" CellStyle-HorizontalAlign="Center" Width="40px" VisibleIndex="1"  >
            <DataItemTemplate>
                <asp:ImageButton ID="lbtnEditar" runat="server" CommandName="Editar" ImageUrl="~/imagenes/Editar.png"  CommandArgument='<%# Bind("ID_SOLICITANTE") %>'></asp:ImageButton>                                
            </DataItemTemplate>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="ID_SOLICITANTE" ReadOnly="True" VisibleIndex="2" Width="20px" Caption="Identificador" />
        <dx:GridViewDataTextColumn FieldName="NOMBRE" VisibleIndex="2" Caption="Nombre" />
        <dx:GridViewDataCheckColumn FieldName="ESTADO" VisibleIndex="4" Caption="Activo" HeaderStyle-HorizontalAlign="Center" />
    </Columns>
</dx:ASPxGridView>

<asp:ObjectDataSource ID="odsLista" runat="server" SelectMethod="ObtenerLista"  TypeName="ADMINPT.BL.CSOLICITANTE">    
</asp:ObjectDataSource>

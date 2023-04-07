<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCBarraOpciones.ascx.cs" Inherits="ADMINPT.controles.UCBarraOpciones" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<div>     
        <dx:ASPxMenu ID="mDinamico" runat="server" ShowAsToolbar="True" ShowPopOutImages="True" OnItemClick="mDinamico_ItemClick" Theme="iOS"  >               
            <Items>
                <dx:MenuItem GroupName="General" Name="mitemNuevo" Text="Nuevo" ClientVisible="false" >                        
                    <Image AlternateText="Nuevo" IconID="actions_new_16x16" ></Image>                        
                </dx:MenuItem>                
                <dx:MenuItem GroupName="General" Name="mitemGuardar" Text="Guardar" ClientVisible="false">
                    <Image AlternateText="Guardar" IconID="save_save_16x16">
                    </Image>
                </dx:MenuItem> 
                <dx:MenuItem GroupName="General" Name="mitemEliminar" Text="Eliminar" ClientVisible="false">
                    <Image AlternateText="Eliminar" IconID="edit_delete_16x16">
                    </Image>
                </dx:MenuItem>
                <dx:MenuItem GroupName="General" Name="mitemCancelar" Text="Cancelar" ClientVisible="false">
                    <Image AlternateText="Cancelar" IconID="actions_reset_16x16">
                    </Image>
                </dx:MenuItem>
            </Items>
        </dx:ASPxMenu>
</div>
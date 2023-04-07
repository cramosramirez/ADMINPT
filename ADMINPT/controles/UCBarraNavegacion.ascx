<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCBarraNavegacion.ascx.cs" Inherits="ADMINPT.controles.UCBarraNavegacion" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
    <table class="tb">
        <tr>
            <td>
                <dx:ASPxButton ID="_btn_nuevo" runat="server" Text="Nuevo" AutoPostBack="true" OnClick="_btn_nuevo_Click">
                    <Image IconID="actions_new_16x16">
                    </Image>
                </dx:ASPxButton>
                <dx:ASPxButton ID="_btn_guardar" runat="server" Text="Guardar" AutoPostBack="true" OnClick="_btn_guardar_Click" Visible="false">
                    <Image IconID="save_save_16x16">
                    </Image>
                </dx:ASPxButton>
                <dx:ASPxButton ID="_btn_eliminar" runat="server" Text="Eliminar" AutoPostBack="true" Visible="false" OnClick="_btn_eliminar_Click">
                    <Image IconID="actions_close_16x16">
                    </Image>
                </dx:ASPxButton>
                <dx:ASPxButton ID="_btn_cancelar" runat="server" Text="Cancelar" AutoPostBack="true" Visible="false"  CausesValidation="False" UseSubmitBehavior="false" OnClick="_btn_cancelar_Click">
                    <Image IconID="save_saveandclose_16x16">
                    </Image>
                </dx:ASPxButton>
                <dx:ASPxButton ID="_btn_atras" runat="server" Text="Atras" Autoposback="true" Visible="false"  CausesValidation="False" UseSubmitBehavior="false" OnClick="_btn_atras_Click">
                    <Image IconID="navigation_backward_16x16gray">
                    </Image>
                </dx:ASPxButton>
                <dx:ASPxButton ID="_btn_reporte" runat="server" Text="Ver Reporte" AutoPostBack="true" Visible="false" CausesValidation="False" UseSubmitBehavior="false"  OnClick="_btn_reporte_Click">
                    <Image IconID="richedit_header_16x16">
                    </Image>
                     <ClientSideEvents Click="function(s, e) {ldnPanel.Show(); e.processOnServer = true;}" />
                </dx:ASPxButton>
                <dx:ASPxButton ID="_btn_reporteConta" runat="server" Text="Ver Reporte" AutoPostBack="true" Visible="false" OnClick="_btn_reporteConta_Click">
                    <Image IconID="reports_groupheader_16x16">
                    </Image>
                </dx:ASPxButton>
                <dx:ASPxButton ID="_btn_fijarTurno" runat="server" Text="Fijar Turno" Autoposback="true" Visible="false" OnClick="_btn_fijarTurno_Click">
                     <Image IconID="scheduling_switchtimescalesto_16x16">
                    </Image>
                </dx:ASPxButton>
                <dx:ASPxButton ID="_btn_actualizarTurno" runat="server" Text="Actualizar Turno" Autoposback="true" Visible="false" OnClick="_btn_actualizarTurno_Click">
                    <Image IconID="actions_refresh2_16x16">
                    </Image>
                </dx:ASPxButton>
                <dx:ASPxButton ID="_btn_buscar" runat="server" Text="buscar" AutoPostBack="true" Visible="false" OnClick="_btn_buscar_Click">
                    <Image IconID="find_find_16x16">
                    </Image>
                </dx:ASPxButton>
                <dx:ASPxButton ID="_btn_salir" runat="server" Text="Salir" AutoPostBack="true" CausesValidation="False" UseSubmitBehavior="false" OnClick="_btn_salir_Click">
                    <Image IconID="navigation_home_16x16">
                    </Image>
<%--                    <Image IconID="actions_cancel_16x16">
                    </Image>--%>
                </dx:ASPxButton>
            </td>
        </tr>
    </table>
   

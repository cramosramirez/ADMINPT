<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCriterios.ascx.cs" Inherits="ADMINPT.controles.UCCriterios" %>

<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<link href="../CSS/tabla.css" rel="stylesheet" />
<link href="../CSS/uc.css" rel="stylesheet" />
<table class="tb">
    <tbody>
        <tr id="_ContInventario" runat="server" visible="false">
            <td class="td">
                <dx:ASPxLabel ID="ASPxLabel3" runat="server" CssClass="label" Text="Bodega :"></dx:ASPxLabel>
            </td>
            <td class="td1">
                <dx:ASPxComboBox ID="_cbxBodegaOrigen" runat="server" TextField="NOMBRE" ValueField="ID_BODEGA" ValueType="System.Int32" AutoPostBack="true">
                    <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                    <ValidationSettings>
                        <RequiredField IsRequired="True" ErrorText="Zafra Actual" />
                    </ValidationSettings>
                </dx:ASPxComboBox>
            </td>
            <td class="td">
                <dx:ASPxLabel ID="ASPxLabel24" runat="server" CssClass="label" Text="Producto :"></dx:ASPxLabel>
            </td>
            <td class="td1">
                <dx:ASPxComboBox ID="_cbxProducto" runat="server" TextField="NOMBRE_KARDEX" ValueField="ID_PRODUCTO" ValueType="System.Int32" AutoPostBack="true" OnTextChanged="_cbxProducto_TextChanged" Width="97%">
                    <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                    <ValidationSettings>
                        <RequiredField IsRequired="True" ErrorText="Zafra Actual" />
                    </ValidationSettings>
                </dx:ASPxComboBox>
            </td>
            <td class="td">
                <dx:ASPxLabel ID="ASPxLabel1" runat="server" CssClass="label" Text="Presentacion :"></dx:ASPxLabel>
            </td>
            <td class="td1">
                <dx:ASPxComboBox ID="_cbxPrestanciontras" runat="server" TextField="NOMBRE_PRESEN_TRAA" ValueField="ID_PRESEN_TRAS" ValueType="System.Int32">
                    <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                    <ValidationSettings>
                        <RequiredField IsRequired="True" ErrorText="Dia Zafra" />
                    </ValidationSettings>
                </dx:ASPxComboBox>
            </td>
            <td class="td">
                <dx:ASPxLabel ID="ASPxLabel2" runat="server" CssClass="label" Text="Unidad :"></dx:ASPxLabel>
            </td>
            <td class="td1">
                <dx:ASPxComboBox ID="_cbxUnidad" runat="server" TextField="NOMBRE_UNIDAD" ValueField="ID_UNIDAD_FAC" ValueType="System.Int32">
                    <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                    <ValidationSettings>
                        <RequiredField IsRequired="True" ErrorText="Tipo producto" />
                    </ValidationSettings>
                </dx:ASPxComboBox>
            </td>
            <td class="td">
                <dx:ASPxLabel ID="ASPxLabel4" runat="server" CssClass="label" Text="Reporte :"></dx:ASPxLabel>
            </td>
            <td class="td1">
                <dx:ASPxComboBox ID="_cbxTipoReporte" runat="server" TextField="NOMBRE_UNIDAD" ValueField="ID_UNIDAD_FAC" ValueType="System.Int32">
                    <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                    <ValidationSettings>
                        <RequiredField IsRequired="True" ErrorText="Tipo producto" />
                    </ValidationSettings>
                </dx:ASPxComboBox>
            </td>
        </tr>
<tr id="_ContFechas" runat="server" visible="false">
            <td class="td">
                <dx:ASPxLabel ID="ASPxLabel5" runat="server" CssClass="label" Text="Fecha Inicial :"></dx:ASPxLabel>
            </td>
            <td class="td1">
                            <dx:ASPxDateEdit ID="_dteFechaInicial" runat="server" EditFormat="Custom" EditFormatString="dd/MM/yyyy" ClientEnabled="true" >
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxDateEdit>
            </td>
            <td class="td">
                <dx:ASPxLabel ID="ASPxLabel6" runat="server" CssClass="label" Text="Fecha Final :"></dx:ASPxLabel>
            </td>
            <td class="td1">
                            <dx:ASPxDateEdit ID="_dteFechaFinal" runat="server" EditFormat="Custom" EditFormatString="dd/MM/yyyy" ClientEnabled="true" >
                                <DisabledStyle BackColor="WhiteSmoke" ForeColor="Black"></DisabledStyle>
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="Requerido !!!" />
                                </ValidationSettings>
                            </dx:ASPxDateEdit>
            </td>
        </tr>

    </tbody>
</table>

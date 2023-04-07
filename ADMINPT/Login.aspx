<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ADMINPT.Login" %>

<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="css/sweetalert.css" rel="stylesheet" />
     <script src="Scripts/sweetalert.min.js"></script>
    <script src="Scripts/sweetalert.js"></script>
    <link href="css/ResponsiveLayout.css" rel="stylesheet" />
    <link rel="stylesheet" href= 
"https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"> 
        
    <script src= 
"https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"> 
    </script> 
        
    <script src= 
"https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"> 
    </script> 
        
    <script src= 
"https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"> 
    </script> 
      
    <style type="text/css">
        h1 {
            color:green;
        }
        .xyz {
            background-size: auto;
            text-align: center;
            padding-top: 100px;
        }
        .btn-circle.btn-sm {
            width: 30px;
            height: 30px;
            padding: 6px 0px;
            border-radius: 15px;
            font-size: 8px;
            text-align: center;
        }
        .btn-circle.btn-md {
            width: 50px;
            height: 50px;
            padding: 7px 10px;
            border-radius: 25px;
            font-size: 10px;
            text-align: center;
        }
        .btn-circle.btn-xl {
            width: 100px;
            height: 100px;
            padding: 10px 16px;
            border-radius: 35px;
            font-size: 12px;
            text-align: center;
        }
    </style>
     <script type="text/javascript">
        function ShowLoginWindow() {
            pcLogin.Show();
        }
        
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
           <table border="0" class="tb">
        <tr>
           <td class="td">
 
            <dx:ASPxFormLayout ID="Lista"  runat="server" Theme="Moderno">
                <Items>
                    <dx:LayoutGroup Caption="SISTEMA DE ADMINISTRACION DE PRODUCTO TERMINADO" ShowCaption="true" GroupBoxDecoration="Box"
                        UseDefaultPaddings="false" Paddings-PaddingTop="3">
                       <Paddings PaddingTop="3px"></Paddings>
                        <GroupBoxStyle>
                            <Caption CssClass="title" />
                        </GroupBoxStyle>
                        <Items>
                            <dx:LayoutItem Caption="Mensaje:" ShowCaption="False" Name="lymensaje" CaptionSettings-HorizontalAlign="Right">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer runat="server">
                                        <dx:ASPxLabel ID="lb_msj" runat="server" Text="" ForeColor="Red"></dx:ASPxLabel>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                                <CaptionSettings HorizontalAlign="Right"></CaptionSettings>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="datos" ShowCaption="False">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer runat="server">
                                        <div align='center'>
                                    <table runat="server" id="tbcont">
                                        <tr>
                                            <td colspan="3">
                                           <dx:ASPxButton ID="btadminpt" runat="server" Text="ADMIN-PT 1" OnClick="btadminpt_ServerClick" Theme="Office365" ImagePosition="Bottom">
                                                     <Image Url="~/imagenes/logo.png" Width="810px"  Height="250px">
                                                     </Image>
                                                 </dx:ASPxButton> 
                                                </td>
                                       </tr>
                                        <tr>
                                            <td >
                                           <dx:ASPxButton ID="btinjiboa1" runat="server" Text="INJIBOA 1" OnClick="btinjiboa1_ServerClick" Theme="Office365" ImagePosition="Bottom">
                                                     <Image Url="~/imagenes/injiboa1.jpg" Width="250px"  Height="150px">
                                                     </Image>
                                                 </dx:ASPxButton> 
                                                </td>
                                                                                 
                                             <td >                                                 
                                                  <dx:ASPxButton ID="btalmaconsa" runat="server" Text="ALMACONSA" OnClick="btalmaconsa_ServerClick" Theme="Office365" ImagePosition="Bottom">
                                                     <Image Url="~/imagenes/ALMACONSA.jpg" Width="250px" Height="150px">
                                                     </Image>
                                                 </dx:ASPxButton> 
                                                 </td>
                                            
                                            <td >
                                                 <dx:ASPxButton ID="btalmapac" runat="server" Text="ALMAPAC" OnClick="btalmapac_ServerClick" Theme="Office365" ImagePosition="Bottom">
                                                     <Image Url="~/imagenes/ALMAPAC.jpg" Width="250px" Height="150px">
                                                     </Image>
                                                 </dx:ASPxButton> 
                                             </td>
                                       </tr>
                                            
                                        
                                    </table>
                                                  </div>
                                        </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                        </Items>
                    </dx:LayoutGroup>                  
                </Items>
            </dx:ASPxFormLayout>
        
    </td>
        </tr>
    </table>
    <dx:ASPxPopupControl ID="pcLogin" runat="server" Width="500" CloseAction="CloseButton" CloseOnEscape="true" Modal="True" Theme="Moderno"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcLogin"
        HeaderText="Iniciar Sesión" AllowDragging="True" PopupAnimationType="None" EnableViewState="False" AutoUpdatePosition="true">
       <%-- <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup'); tbLogin.Focus(); }" />--%>
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <dx:ASPxPanel ID="Panel1" runat="server" DefaultButton="btOK" Theme="Moderno">
                    <PanelCollection>
                        <dx:PanelContent runat="server">
                            <dx:ASPxFormLayout runat="server" ID="ASPxFormLayout1" Width="100%" Height="100%" Theme="Moderno" ColCount="2" ColumnCount="2">
                                <Items>
                                    <dx:LayoutItem ShowCaption="False" ColSpan="1" RowSpan="2">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxImage ID="ASPxFormLayout1_E1" runat="server" Width="100px"  ImageUrl="~/imagenes/login.png">
                                                </dx:ASPxImage>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Usuario">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>                                               
                                                <dx:ASPxTextBox ID="txt_user" runat="server" AutoCompleteType="Disabled" Width="100%" MaxLength="20" Theme="Moderno">
                                                    <ValidationSettings EnableCustomValidation="True" ValidationGroup="entryGroup" SetFocusOnError="True"
                                                        ErrorDisplayMode="Text" ErrorTextPosition="Bottom" CausesValidation="True">
                                                        <RequiredField ErrorText="Nombre de usuario requerido" IsRequired="True" />
                                                        <RegularExpression ErrorText="Necesario iniciar sesión" />
                                                        <ErrorFrameStyle Font-Size="10px">
                                                            <ErrorTextPaddings PaddingLeft="0px" />
                                                        </ErrorFrameStyle>
                                                    </ValidationSettings>
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Contraseña">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>                                                
                                                <dx:ASPxTextBox ID="txt_pass" runat="server" Width="100%" Password="true" MaxLength="12" Theme="Moderno">
                                                    <ValidationSettings EnableCustomValidation="True" ValidationGroup="entryGroup" SetFocusOnError="True"
                                                        ErrorDisplayMode="Text" ErrorTextPosition="Bottom">
                                                        <RequiredField ErrorText="Se requiere contraseña" IsRequired="True" />
                                                        <ErrorFrameStyle Font-Size="10px">
                                                            <ErrorTextPaddings PaddingLeft="0px" />
                                                        </ErrorFrameStyle>
                                                    </ValidationSettings>
                                                </dx:ASPxTextBox>
                                                <dx:ASPxComboBox ID="cb_bodega" runat="server" ValueType="System.Int32" ClientVisible="false" >
                                                            <Items>
                                                                <dx:ListEditItem Text="ADMIN-PT" Value="0" />
                                                                <dx:ListEditItem Text="INJIBOA - 1" Value="29" />
                                                                <dx:ListEditItem Text="ALMACONSA" Value="16" />
                                                                <dx:ListEditItem Text="ALMAPAC" Value="17" />
                                                                <dx:ListEditItem Text="ALMAPAC - REAL" Value="30" />
                                                            </Items>
                                                        </dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>                                   
                                    <dx:LayoutItem ShowCaption="False" Paddings-PaddingTop="19" ColSpan="2" ColumnSpan="2">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxButton ID="bt_login" runat="server" Text="Inicio sesión" OnClick="bt_login_Click" Width="80px"  Style="float: left; margin-right: 8px" Theme="Moderno" >
                                                    <ClientSideEvents Click="function(s, e) { if(ASPxClientEdit.ValidateGroup('entryGroup')) pcLogin.Hide(); }" />
                                               <Image IconID="richedit_reviewers_svg_16x16">
                                                            </Image>
                                                    </dx:ASPxButton>
                                                <dx:ASPxButton ID="btCancel" runat="server" Text="Cancel" Width="80px" AutoPostBack="False" Style="float: left; margin-right: 8px" Theme="Moderno">
                                                    <ClientSideEvents Click="function(s, e) { pcLogin.Hide(); }" />
                                                     <Image IconID="richedit_unprotectdocument_svg_16x16">
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
        <HeaderImage IconID="richedit_encryptdocument_svg_16x16">
        </HeaderImage>
        <ContentStyle>
            <Paddings PaddingBottom="5px" />
        </ContentStyle>
    </dx:ASPxPopupControl>
</asp:Content>

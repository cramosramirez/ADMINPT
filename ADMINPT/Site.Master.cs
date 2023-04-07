using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public enum MessageType { success, Error, Info, Warning };
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // El código siguiente ayuda a proteger frente a ataques XSRF
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Utilizar el token Anti-XSRF de la cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generar un nuevo token Anti-XSRF y guardarlo en la cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }
        protected void master_Page_PreLoad(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
               
                // Establecer token Anti-XSRF
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validar el token Anti-XSRF
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Error de validación del token Anti-XSRF.");
                }
            }
        }
        protected void modulos_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
        {

            if (lb_iduser.Text != string.Empty)
            {
                if (e.Item.Name == "Facturacion") { Session["ID_MODULO"] = 1; Response.Redirect("~/Default.aspx"); } //Response.Redirect(Request.RawUrl, true); sqd_listmenu.DataBind(); ASPxMenu1.DataBind(); }
                if (e.Item.Name == "Bascula") { Session["ID_MODULO"] = 2; Response.Redirect("~/Default.aspx"); } //Response.Redirect(Request.RawUrl, true); sqd_listmenu.DataBind(); ASPxMenu1.DataBind(); }
                if (e.Item.Name == "Bodega") { Session["ID_MODULO"] = 3; Response.Redirect("~/Default.aspx"); } // Response.Redirect(Request.RawUrl, true); sqd_listmenu.DataBind(); ASPxMenu1.DataBind(); }
                if (e.Item.Name == "configuracion") { Session["ID_MODULO"] = 4; Response.Redirect("~/Default.aspx"); } // Response.Redirect(Request.RawUrl, true); sqd_listmenu.DataBind(); ASPxMenu1.DataBind(); }
            }
        }
        public void SpEnProc()
        {
            Conn.cn.Close();
            Conn.cn.Open();
            var Dt = new DataTable();
            SqlDataAdapter Dadapter;
            var iniciar = new SqlCommand("VIEW_ENPROCESO", Conn.cn);
            iniciar.CommandType = CommandType.StoredProcedure;
            //iniciar.Parameters.AddWithValue("@USUARIO", txt_user.Text);
            //iniciar.Parameters.AddWithValue("@CLAVE", txt_pass.Text);
            Dadapter = new SqlDataAdapter(iniciar);
            Dadapter.Fill(Dt);
            if (Dt.Rows.Count > 0)
            {
                DataRow row = Dt.Rows[0];
                lblEnproc.Text = row["NRW"].ToString();
            }
            else
            { lblEnproc.Text = "0"; }
            Conn.cn.Close();
        }
        public void SpFact()        {
          
                Conn.cn.Close();
                Conn.cn.Open();
                var Dt = new DataTable();
                SqlDataAdapter Dadapter;
                var iniciar = new SqlCommand("VIEW_FACTURADO", Conn.cn);
                iniciar.CommandType = CommandType.StoredProcedure;
                //iniciar.Parameters.AddWithValue("@USUARIO", txt_user.Text);
                //iniciar.Parameters.AddWithValue("@CLAVE", txt_pass.Text);
                Dadapter = new SqlDataAdapter(iniciar);
                Dadapter.Fill(Dt);
                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                    lblFact.Text = row["NRW"].ToString();
                }
                else
                {

                    lblFact.Text = "0";

                }
                Conn.cn.Close();
           
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
            try
            {
                lb_idemp.Text = Convert.ToString(Session["ID_EMPRESA"]);
                lb_iduser.Text = Convert.ToString(Session["ID_MENUPERFIL"]);
                Lb_user.Text = Convert.ToString(Session["USUARIO"]);

                lbtt.Text = "ADMIN-PT - " + Convert.ToString(Session["BODEP"]);

                // mostrar menu 
                if (Lb_user.Text == "")
                {
                    
                    Lb_user.Visible = false;
                    hl_fin.Visible = false;
                    hl_inicio.Visible = true;
                    //modulos.ClientVisible = true;
                    // BuildMenu(ASPxMenu1, opmenu)
                    lbtt.Text = "ADMIN-PT";
                    btfacturado.Visible = false;
                    btprocesocarga.Visible = false;
                }
                else
                {
                    if(Convert.ToString(Session["BODEP"])== "ADMIN-PT")
                    { lbtt.Text = "ADMIN-PT - " + Convert.ToString(Session["BODEP"]); }
                    else { lbtt.Text = "ADMIN-PT - " + Convert.ToString(Session["BODEP"]); }
                    
                   
                    BuildMenu(mMain, sqd_listmenu);
                    
                    lb_iduser.Visible = false;
                    Lb_user.Visible = true;
                    hl_fin.Visible = true;
                    hl_inicio.Visible = false;
                    lb_iduser.Visible = false;
                    SpEnProc();
                    SpFact();
                    btfacturado.Visible = true;
                    btprocesocarga.Visible = true;
                }
                //ERPConn.cn.Close();
                //ERPConn.cn.Open();
                //DataTable Dt = new DataTable();
                //SqlDataAdapter Dadapter;
                //var iniciar = new SqlCommand("VIEW_EMPRESABANER", ERPConn.cn);
                //iniciar.CommandType = CommandType.StoredProcedure;
                //iniciar.Parameters.AddWithValue("@ID_EMPRESA", Convert.ToInt32(Session["ID_EMPRESA"]));
                //Dadapter = new SqlDataAdapter(iniciar);
                //Dadapter.Fill(Dt);
                //if (Dt.Rows.Count > 0)
                //{
                //    DataRow row = Dt.Rows[0];
                //    Session["baner"] = row["NOMBRE_BANER"].ToString();
                //    Session["direcc"] = row["DIRECCION"].ToString();
                //}
                //else
                //{
                //    Session["baner"] = null;
                //    Session["direcc"] = null;
                //}
                //ERPConn.cn.Close();
            }
            catch (System.Data.SqlClient.SqlException)
            {
            }
            // lb_msj.Text = "Mensaje :" + (sqlEx.Message)
#pragma warning disable CS0168 // La variable 'sqlEx' se ha declarado pero nunca se usa
            catch (Exception sqlEx)
#pragma warning restore CS0168 // La variable 'sqlEx' se ha declarado pero nunca se usa
            {
            }
            // lb_msj.Text = "Mensaje :" + (ex.Message)
            finally
            {
                Conn.cn.Close();
                //Lb_Baner.Text = Convert.ToString(Session["baner"]);
                //Lb_Direcc.Text = Convert.ToString(Session["direcc"]);
            }

        }
        protected void hl_fin_Click(object sender, EventArgs e)
        {
            lb_idemp.Text = string.Empty;
            lb_iduser.Text = string.Empty;
            Lb_user.Text = string.Empty;
            Session["ID_EMPRESA"] = null;
            Session["ID_MENUPERFIL"] = null;
            Session["USUARIO"] = null;
            Session["ID_BODEP"] = null;
            Session["BODEP"] = null;
            Session.Clear();
            Session.Abandon();
            hl_inicio.Visible = true;
            hl_fin.Visible = false;
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            lbtt.Text = "ADMIN-PT";
            Response.Redirect("~/Login.aspx");
        }
        protected void BuildMenu(DevExpress.Web.ASPxMenu menu, SqlDataSource dataSource)
        {
            // Get DataView
            DataSourceSelectArguments arg = new DataSourceSelectArguments();
            DataView dataView = dataSource.Select(arg) as DataView;
            dataView.Sort = "ParentID";

            // Build Menu Items
            Dictionary<string, DevExpress.Web.MenuItem> menuItems = new Dictionary<string, DevExpress.Web.MenuItem>();

            for (int i = 0; i <= dataView.Count - 1; i++)
            {
                DataRow row = dataView[i].Row;
                DevExpress.Web.MenuItem item = CreateMenuItem(row);
                string itemID = row["ID_MENU"].ToString();
                string parentID = row["ParentID"].ToString();

                if (menuItems.ContainsKey(parentID))
                    menuItems[parentID].Items.Add(item);
                else if (parentID == "0")
                    menu.Items.Add(item);
                menuItems.Add(itemID, item);
            }
        }
        private DevExpress.Web.MenuItem CreateMenuItem(DataRow row)
        {
            DevExpress.Web.MenuItem ret = new DevExpress.Web.MenuItem();
            ret.Text = row["Text"].ToString();
            ret.NavigateUrl = row["NavigateUrl"].ToString();
            return ret;
        }
    }
}

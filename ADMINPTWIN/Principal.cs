using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADMINPTWIN
{
    public partial class Principal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Principal()
        {
            InitializeComponent();
        }
        private void Logins()
        {
            //var frm = new Login();
            //frm.StartPosition = FormStartPosition.Manual;
            //frm.Location = new Point(this.Location.X + (this.Width - frm.Width) / 2, this.Location.Y + (this.Height - frm.Height) / 2);
            //frm.Show(this);
            Cont_login.Location = new Point(this.Location.X + (this.Width - Cont_login.Width) / 2, this.Location.Y + (this.Height - Cont_login.Height) / 2);
            Cont_login.Show();
        }

        private Boolean ActivarForm(Form Formulario)
        {

            foreach (Control control in this.Controls)
            {
                if (control.HasChildren)//porque el mdi es un contenedor.
                {
                    foreach (Control controlChild in control.Controls)
                    {
                        if (controlChild.GetType() == Formulario.GetType())
                        {
                            if (((Form)controlChild).WindowState == FormWindowState.Minimized)
                            {
                                ((Form)controlChild).WindowState = FormWindowState.Normal;


                            }
                        ((Form)controlChild).BringToFront();
                            return true;

                        }
                    }
                }

            }
            return false;
        }

        private void mostrar(Form frm)
        {
            bool encontrado = false;
            foreach (Form form in this.MdiChildren)
            {
                if (form.Name.Equals(frm))
                {
                    encontrado = true;
                    form.Activate();
                }

            }

            if (!encontrado)
            {
                frm.MdiParent = this;
                frm.Dock = DockStyle.Fill;
                frm.Show();
                frm.BringToFront();
            }

        }
        private void Principal_Load(object sender, EventArgs e)
        {
            Rectangle resolutionRect = System.Windows.Forms.Screen.FromControl(this).Bounds;
            if (this.Width >= resolutionRect.Width || this.Height >= resolutionRect.Height)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            Refresh();
            try
            {
                if (LoginInfo.USUARIO == string.Empty)
                {
                    Logins();
                   
                }
                else
                {
                    //Cont_login.Visible = false;
                   
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btLogin_Click_1(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToString(txtUsiario.Text) == "")
                {
                    MessageBox.Show("Usauario Requerido !!!", "Mensaje", MessageBoxButtons.OK,
MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else if (Convert.ToString(txtPass.Text) == "")
                {
                    MessageBox.Show("Contraseña Requerida !!!", "Mensaje", MessageBoxButtons.OK,
    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    Cnn.cn.Close();
                    Cnn.cn.Open();
                    var Dt = new DataTable();
                    SqlDataAdapter Dadapter;
                    var iniciar = new SqlCommand("VIEW_INICIOSESIONwin", Cnn.cn);
                    iniciar.CommandType = CommandType.StoredProcedure;
                    iniciar.Parameters.AddWithValue("@USUARIO", txtUsiario.Text);
                    iniciar.Parameters.AddWithValue("@CLAVE", txtPass.Text);
                    Dadapter = new SqlDataAdapter(iniciar);
                    Dadapter.Fill(Dt);
                    if (Dt.Rows.Count > 0)
                    {
                        DataRow row = Dt.Rows[0];


                        LoginInfo.ID_MENUPERFIL = Convert.ToInt32(row["ID_MENUPERFIL"].ToString());
                        LoginInfo.USUARIO = row["NOMBRE"].ToString();
                        txt_nombre.Caption = row["NOMBRE"].ToString();
                        txt_id.Caption = Convert.ToString(row["ID_MENUPERFIL"].ToString());

                        LoginInfo.rimp= Convert.ToInt32(row["RIMP"].ToString());
                        LoginInfo.capm= Convert.ToInt32(row["CAPM"].ToString());
                        txt_rimp.Caption = Convert.ToString(row["RIMP"].ToString());
                         txt_capm.Caption = Convert.ToString(row["CAPM"].ToString());
                    }
                    else
                    {

                        MessageBox.Show("Usuario ó Contraseña Incoirrecta !!!", "Mensaje", MessageBoxButtons.OK,
MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        LoginInfo.ID_MENUPERFIL = 0;
                        LoginInfo.USUARIO = string.Empty;
                        txt_nombre.Caption = string.Empty;
                        txt_id.Caption = string.Empty;


                    }
                    Cnn.cn.Close();
                }

            }
            catch (System.Data.SqlClient.SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "Mensaje", MessageBoxButtons.OK,
   MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            catch (Exception sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "Mensaje", MessageBoxButtons.OK,
   MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();
                if (LoginInfo.USUARIO != string.Empty)
                {
                    cont_Bascula.Visible = true;
                    btBascula.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    Cont_login.Visible = false;
                    OpcionesVew();
                }


            }
        }

        private void btCancelar_Click_1(object sender, EventArgs e)
        {
            LoginInfo.ID_MENUPERFIL = 0;
            LoginInfo.USUARIO = string.Empty;
            txtUsiario.Text = string.Empty;
            txtPass.Text = string.Empty;
            Cont_login.Visible = false;
        }

        private void OpcionesVew()
        {
            try
            {
                DataTable Dt = new DataTable();
                SqlDataAdapter Dadapter;
                Cnn.cn.Close();
                Cnn.cn.Open();
                var Comando = new SqlCommand("VIEW_LISTMENUWIN_OPCION", Cnn.cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@ID_MENUPERFIL", txt_id.Caption);
                Dadapter = new SqlDataAdapter(Comando);
                Dadapter.Fill(Dt);
                foreach (DataRow row in Dt.Rows)
                {
                    if ((ContBascula.Name== row["OPC_WINFORMS"].ToString()))
                    {
                        ContBascula.Visible = true;
                    }

                    if ((ContPtarima.Name == row["OPC_WINFORMS"].ToString()))
                    {
                        ContPtarima.Visible = true;
                    }

                    if ((ContPJumbo.Name == row["OPC_WINFORMS"].ToString()))
                    {
                        ContPJumbo.Visible = true;
                    }

                    if ((ContTInterno.Name == row["OPC_WINFORMS"].ToString()))
                    {
                        ContTInterno.Visible = true;
                    }

                    if ((ContTCE5.Name == row["OPC_WINFORMS"].ToString()))
                    {
                        ContTCE5.Visible = true;
                    }

                    if ((ContAsignacionDoc.Name == row["OPC_WINFORMS"].ToString()))
                    {
                        ContAsignacionDoc.Visible = true;
                    }

                    if ((ContReporteProduccion.Name == row["OPC_WINFORMS"].ToString()))
                    {
                        ContReporteProduccion.Visible = true;
                    }

                    if ((ContReporteMov.Name == row["OPC_WINFORMS"].ToString()))
                    {
                        ContReporteMov.Visible = true;
                    }

                    if ((ContCorreccionPesos.Name == row["OPC_WINFORMS"].ToString()))
                    {
                        ContCorreccionPesos.Visible = true;
                    }

                    //if ((bt_planillapagorenta.Name == row["OPC_WINFORMS"].ToString()))
                    //{
                    //    bt_planillapagorenta.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    //}

                   

                }

                Cnn.cn.Close();
            }
            catch (System.Data.SqlClient.SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "Mensaje", MessageBoxButtons.OK,
   MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            catch (Exception sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "Mensaje", MessageBoxButtons.OK,
   MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();
            }

        }

        private void btBascula_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Form frm = new Bascula.Bascula();
            //mostrar(frm);
            Bascula.Bascula childForm = new Bascula.Bascula();
            if (ActivarForm(childForm) == true)
            {
                childForm = null;
            }
            else
            {
                childForm.MdiParent = this;
                childForm.WindowState = FormWindowState.Maximized;
                childForm.Show();
            }

        }  

        private void btTrasladoInterno_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //TrasladoExpress.TrasladoCE5Dizucar _TInterno = new TrasladoExpress.TrasladoCE5Dizucar();
            //mostrar(_TInterno);
            TrasladoExpress.TrasladoCE5Dizucar childForm = new TrasladoExpress.TrasladoCE5Dizucar();
            if (ActivarForm(childForm) == true)
            {
                childForm = null;
            }
            else
            {
                childForm.MdiParent = this;
                childForm.WindowState = FormWindowState.Maximized;
                childForm.Show();
            }
        }

        private void btAsignarDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TrasladoExpress.AsignacionDocumento childForm = new TrasladoExpress.AsignacionDocumento();
            // mostrar(_AsigDoc);
            if (ActivarForm(childForm) == true)
            {
                childForm = null;
            }
            else
            {
                childForm.MdiParent = this;
                childForm.WindowState = FormWindowState.Maximized;
                childForm.Show();
            }
        }

        private void btIngesoTarimas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TrasladoExpress.ProduccionTarimas childForm = new TrasladoExpress.ProduccionTarimas();
            // mostrar(_IPT);
            if (ActivarForm(childForm) == true)
            {
                childForm = null;
            }
            else
            {
                childForm.MdiParent = this;
                childForm.WindowState = FormWindowState.Maximized;
                childForm.Show();
            }
        }

        private void btIngresosJumbos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TrasladoExpress.ProduccionJumbos childForm = new TrasladoExpress.ProduccionJumbos();
            // mostrar(_IPJ);
            if (ActivarForm(childForm) == true)
            {
                childForm = null;
            }
            else
            {
                childForm.MdiParent = this;
                childForm.WindowState = FormWindowState.Maximized;
                childForm.Show();
            }
        }

        private void btReporte_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TrasladoExpress.ReportesProduccion childForm = new TrasladoExpress.ReportesProduccion();
            //mostrar(_RP);
            if (ActivarForm(childForm) == true)
            {
                childForm = null;
            }
            else
            {
                childForm.MdiParent = this;
                childForm.WindowState = FormWindowState.Maximized;
                childForm.Show();
            }
        }

        private void btTInternoBodega_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TrasladoExpress.TrasladoInterno childForm = new TrasladoExpress.TrasladoInterno();
            // mostrar(_TInterno);
            if (ActivarForm(childForm) == true)
            {
                childForm = null;
            }
            else
            {
                childForm.MdiParent = this;
                childForm.WindowState = FormWindowState.Maximized;
                childForm.Show();
            }
        }

        private void btReportemovimento_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Bascula.Movientos_Bascula childForm = new Bascula.Movientos_Bascula();
            // mostrar(MB);
            if (ActivarForm(childForm) == true)
            {
                childForm = null;
            }
            else
            {
                childForm.MdiParent = this;
                childForm.WindowState = FormWindowState.Maximized;
                childForm.Show();
            }
        }

        private void btCorreccionBascula_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Bascula.CorrecionBascula childForm = new Bascula.CorrecionBascula();
            // mostrar(CB);
            if (ActivarForm(childForm) == true)
            {
                childForm = null;
            }
            else
            {
                childForm.MdiParent = this;
                childForm.WindowState = FormWindowState.Maximized;
                childForm.Show();
            }
        }

        private void btBasculaProducion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Bascula.BasculaProduccion childForm = new Bascula.BasculaProduccion();
          //  mostrar(frm);
            if (ActivarForm(childForm) == true)
            {
                childForm = null;
            }
            else
            {
                childForm.MdiParent = this;
                childForm.WindowState = FormWindowState.Maximized;
                childForm.Show();
            }
        }
    }
}

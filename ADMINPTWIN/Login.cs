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
    public partial class Login : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void txtPass_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToString(txtUsiario.Text) == "")
                {
                    MessageBox.Show("Usauario Requerido !!!", "Mensaje", MessageBoxButtons.OK,
MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else if (Convert.ToString(txtPass.Text) == "") {
                    MessageBox.Show("Contraseña Requerida !!!", "Mensaje", MessageBoxButtons.OK,
    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    Cnn.cn.Close();
                    Cnn.cn.Open();
                    var Dt = new DataTable();
                    SqlDataAdapter Dadapter;
                    var iniciar = new SqlCommand("VIEW_INICIOSESION", Cnn.cn);
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
                    }
                    else
                    {

                        MessageBox.Show("Usuario ó Contraseña Incoirrecta !!!", "Mensaje", MessageBoxButtons.OK,
MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        LoginInfo.ID_MENUPERFIL = 0;
                        LoginInfo.USUARIO = string.Empty;
                       

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
                   
                    this.Close();
                }


            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            LoginInfo.ID_MENUPERFIL = 0;
            LoginInfo.USUARIO = string.Empty;
            txtUsiario.Text = string.Empty;
            txtPass.Text = string.Empty;
            this.Close();
        }
    }
}

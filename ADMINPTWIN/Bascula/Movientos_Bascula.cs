using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADMINPTWIN.Bascula
{
    public partial class Movientos_Bascula : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Movientos_Bascula()
        {
            InitializeComponent();
        }
        int _op = 0;
        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void Producto()
        {
            try
            {
                Cnn.cn.Close();
                Cnn.cn.Open();
                DataTable dt = new DataTable();
                dt = CDatos._SEL_PRODUCTO(Convert.ToInt32(-1));
                DataRow dr = dt.NewRow();
                dr["NOMBRE_PRODUCTO"] = "-- TODOS --";
                dr["ID_PRODUCTO"] = 0;
                dt.Rows.InsertAt(dr, 0);
                cbProducto.DataSource = dt;
                cbProducto.DisplayMember = "NOMBRE_PRODUCTO";
                cbProducto.ValueMember = "ID_PRODUCTO";
                
                cbProducto.Refresh();
                cbProducto.SelectedIndex = 0;
                Cnn.cn.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();
            }
        }

        private void IdBodegas()
        {
            try
            {
                
                Cnn.cn.Close();
                Cnn.cn.Open();
                DataTable dt = new DataTable();
                dt = CDatos._SEL_BODEGAS(Convert.ToInt32(-1));
                DataRow dr = dt.NewRow();
                dr["NOMBRE"] = "-- TODOS --";
                dr["ID_BODEGA"] = 0;
                dt.Rows.InsertAt(dr, 0);
                cbDestino.DataSource = dt;
                cbDestino.DisplayMember = "NOMBRE";
                cbDestino.ValueMember = "ID_BODEGA";
                cbDestino.Refresh();
                Cnn.cn.Close();
            }
            
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();
            }
        }
        private void Movientos_Bascula_Load(object sender, EventArgs e)
        {
            cbHorario.SelectedIndex = 0;
            Producto();
            IdBodegas();
            txtFecha.DateTime  = DateTime.Now;
            txtFechah.DateTime = DateTime.Now;
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            if (rdTraslado.Checked == false && rdVentaJiboa.Checked == false && rdDizucar.Checked == false)
            {
                MessageBox.Show("Seleccionar Tipo Movimento", "Mensaje", MessageBoxButtons.OK,
                   MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            }
            else
            {
                Reportes.Bascula.Rpt_MovimientosBascula ReportT = new Reportes.Bascula.Rpt_MovimientosBascula(Convert.ToDateTime(txtFecha.Text), Convert.ToDateTime(txtFechah.Text), Convert.ToString(cbHorario.Text), Convert.ToInt32(_op), Convert.ToInt32(cbProducto.SelectedValue), Convert.ToInt32(cbDestino.SelectedValue));
                Reportes.Visor form = new Reportes.Visor();
                form._view_documento.DocumentSource = ReportT;
                form.Show();
            }
        }

        private void cbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cbProducto_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void rdTraslado_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTraslado.Checked == true)
            { 
            rdVentaJiboa.Checked = false;
            rdDizucar.Checked = false;
            rdTraslado.Checked = true;
            _op = 12;
            }
        }

        private void rdVentaJiboa_CheckedChanged(object sender, EventArgs e)
        {
            if (rdVentaJiboa.Checked == true)
            {
                rdTraslado.Checked = false;
            rdDizucar.Checked = false;
            rdVentaJiboa.Checked = true;
            _op = 14;
        }
        }

        private void rdDizucar_CheckedChanged(object sender, EventArgs e)
        {
                if (rdDizucar.Checked == true)
                {
                    rdTraslado.Checked = false;
            rdVentaJiboa.Checked = false;
            rdDizucar.Checked = true;
            _op = 16;
        }
            }
        }
}

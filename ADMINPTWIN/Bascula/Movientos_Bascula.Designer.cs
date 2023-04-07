
namespace ADMINPTWIN.Bascula
{
    partial class Movientos_Bascula
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Movientos_Bascula));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.rdDizucar = new System.Windows.Forms.RadioButton();
            this.rdVentaJiboa = new System.Windows.Forms.RadioButton();
            this.rdTraslado = new System.Windows.Forms.RadioButton();
            this.cbDestino = new System.Windows.Forms.ComboBox();
            this.btImprimir = new DevExpress.XtraEditors.SimpleButton();
            this.cbHorario = new System.Windows.Forms.ComboBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cbProducto = new System.Windows.Forms.ComboBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtFechah = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtFecha = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechah.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechah.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFecha.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 1;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.TabletOffice;
            this.ribbonControl1.Size = new System.Drawing.Size(1210, 58);
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AutoSize = true;
            this.groupControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.rdDizucar);
            this.groupControl1.Controls.Add(this.rdVentaJiboa);
            this.groupControl1.Controls.Add(this.rdTraslado);
            this.groupControl1.Controls.Add(this.cbDestino);
            this.groupControl1.Controls.Add(this.btImprimir);
            this.groupControl1.Controls.Add(this.cbHorario);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.cbProducto);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtFechah);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtFecha);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 58);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1210, 194);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Informacion del Movimiento";
            this.groupControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(5, 36);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(123, 18);
            this.labelControl6.TabIndex = 59;
            this.labelControl6.Text = "Tipo Movimiento :";
            // 
            // rdDizucar
            // 
            this.rdDizucar.AutoSize = true;
            this.rdDizucar.Location = new System.Drawing.Point(390, 38);
            this.rdDizucar.Name = "rdDizucar";
            this.rdDizucar.Size = new System.Drawing.Size(91, 17);
            this.rdDizucar.TabIndex = 58;
            this.rdDizucar.Text = "Venta Dizucar";
            this.rdDizucar.UseVisualStyleBackColor = true;
            this.rdDizucar.CheckedChanged += new System.EventHandler(this.rdDizucar_CheckedChanged);
            // 
            // rdVentaJiboa
            // 
            this.rdVentaJiboa.AutoSize = true;
            this.rdVentaJiboa.Location = new System.Drawing.Point(269, 37);
            this.rdVentaJiboa.Name = "rdVentaJiboa";
            this.rdVentaJiboa.Size = new System.Drawing.Size(90, 17);
            this.rdVentaJiboa.TabIndex = 57;
            this.rdVentaJiboa.Text = "Venta Directa";
            this.rdVentaJiboa.UseVisualStyleBackColor = true;
            this.rdVentaJiboa.CheckedChanged += new System.EventHandler(this.rdVentaJiboa_CheckedChanged);
            // 
            // rdTraslado
            // 
            this.rdTraslado.AutoSize = true;
            this.rdTraslado.Location = new System.Drawing.Point(134, 38);
            this.rdTraslado.Name = "rdTraslado";
            this.rdTraslado.Size = new System.Drawing.Size(107, 17);
            this.rdTraslado.TabIndex = 56;
            this.rdTraslado.Text = "Traslado Externo";
            this.rdTraslado.UseVisualStyleBackColor = true;
            this.rdTraslado.CheckedChanged += new System.EventHandler(this.rdTraslado_CheckedChanged);
            // 
            // cbDestino
            // 
            this.cbDestino.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbDestino.FormattingEnabled = true;
            this.cbDestino.Location = new System.Drawing.Point(134, 143);
            this.cbDestino.Name = "cbDestino";
            this.cbDestino.Size = new System.Drawing.Size(354, 21);
            this.cbDestino.TabIndex = 55;
            // 
            // btImprimir
            // 
            this.btImprimir.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.btImprimir.Appearance.Options.UseFont = true;
            this.btImprimir.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btImprimir.ImageOptions.SvgImage")));
            this.btImprimir.Location = new System.Drawing.Point(523, 110);
            this.btImprimir.Name = "btImprimir";
            this.btImprimir.Size = new System.Drawing.Size(122, 43);
            this.btImprimir.TabIndex = 54;
            this.btImprimir.Text = "Reporte";
            this.btImprimir.Click += new System.EventHandler(this.btImprimir_Click);
            // 
            // cbHorario
            // 
            this.cbHorario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbHorario.FormattingEnabled = true;
            this.cbHorario.Items.AddRange(new object[] {
            "-- TODOS --",
            "06:00 A.M. A 02:00 P.M.",
            "02:00 P.M. A 10:00 P.M.",
            "10:00 P.M. A 06:00 A.M.",
            "08:00 A.M. A 05:00 P.M."});
            this.cbHorario.Location = new System.Drawing.Point(134, 89);
            this.cbHorario.Name = "cbHorario";
            this.cbHorario.Size = new System.Drawing.Size(354, 21);
            this.cbHorario.TabIndex = 28;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(66, 142);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(62, 18);
            this.labelControl5.TabIndex = 25;
            this.labelControl5.Text = "Destino :";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(57, 119);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(71, 18);
            this.labelControl3.TabIndex = 23;
            this.labelControl3.Text = "Producto :";
            // 
            // cbProducto
            // 
            this.cbProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbProducto.FormattingEnabled = true;
            this.cbProducto.Location = new System.Drawing.Point(134, 116);
            this.cbProducto.Name = "cbProducto";
            this.cbProducto.Size = new System.Drawing.Size(354, 21);
            this.cbProducto.TabIndex = 22;
            this.cbProducto.SelectedIndexChanged += new System.EventHandler(this.cbProducto_SelectedIndexChanged);
            this.cbProducto.TextChanged += new System.EventHandler(this.cbProducto_TextChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(68, 89);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 18);
            this.labelControl2.TabIndex = 20;
            this.labelControl2.Text = "Horario :";
            // 
            // txtFechah
            // 
            this.txtFechah.EditValue = null;
            this.txtFechah.Location = new System.Drawing.Point(372, 59);
            this.txtFechah.MenuManager = this.ribbonControl1;
            this.txtFechah.Name = "txtFechah";
            this.txtFechah.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.txtFechah.Properties.Appearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.txtFechah.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.txtFechah.Properties.Appearance.Options.UseBackColor = true;
            this.txtFechah.Properties.Appearance.Options.UseBorderColor = true;
            this.txtFechah.Properties.Appearance.Options.UseFont = true;
            this.txtFechah.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtFechah.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFechah.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFechah.Size = new System.Drawing.Size(116, 22);
            this.txtFechah.TabIndex = 19;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(269, 60);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(97, 18);
            this.labelControl1.TabIndex = 18;
            this.labelControl1.Text = "Fecha Hasta :";
            // 
            // txtFecha
            // 
            this.txtFecha.EditValue = null;
            this.txtFecha.Location = new System.Drawing.Point(134, 61);
            this.txtFecha.MenuManager = this.ribbonControl1;
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.txtFecha.Properties.Appearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.txtFecha.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.txtFecha.Properties.Appearance.Options.UseBackColor = true;
            this.txtFecha.Properties.Appearance.Options.UseBorderColor = true;
            this.txtFecha.Properties.Appearance.Options.UseFont = true;
            this.txtFecha.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFecha.Size = new System.Drawing.Size(116, 22);
            this.txtFecha.TabIndex = 17;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(25, 62);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(103, 18);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "Fecha Desde :";
            // 
            // Movientos_Bascula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 450);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.ribbonControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("Movientos_Bascula.IconOptions.Icon")));
            this.Name = "Movientos_Bascula";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Movientos_Bascula";
            this.Load += new System.EventHandler(this.Movientos_Bascula_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechah.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechah.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFecha.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.DateEdit txtFecha;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit txtFechah;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.ComboBox cbProducto;
        private System.Windows.Forms.ComboBox cbHorario;
        private DevExpress.XtraEditors.SimpleButton btImprimir;
        private System.Windows.Forms.ComboBox cbDestino;
        private System.Windows.Forms.RadioButton rdDizucar;
        private System.Windows.Forms.RadioButton rdVentaJiboa;
        private System.Windows.Forms.RadioButton rdTraslado;
        private DevExpress.XtraEditors.LabelControl labelControl6;
    }
}
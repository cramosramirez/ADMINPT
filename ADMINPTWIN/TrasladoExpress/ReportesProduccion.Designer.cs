
namespace ADMINPTWIN.TrasladoExpress
{
    partial class ReportesProduccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportesProduccion));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cb_Horario = new System.Windows.Forms.ComboBox();
            this.labelControl31 = new DevExpress.XtraEditors.LabelControl();
            this.btcerrar = new DevExpress.XtraEditors.SimpleButton();
            this.cbProducto = new System.Windows.Forms.ComboBox();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtFecha = new DevExpress.XtraEditors.DateEdit();
            this.cbZafraProducto = new System.Windows.Forms.ComboBox();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
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
            this.ribbonControl1.OptionsMenuMinWidth = 385;
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.TabletOffice;
            this.ribbonControl1.Size = new System.Drawing.Size(1612, 58);
            this.ribbonControl1.Click += new System.EventHandler(this.ribbonControl1_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.cbZafraProducto);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Controls.Add(this.cb_Horario);
            this.groupControl1.Controls.Add(this.labelControl31);
            this.groupControl1.Controls.Add(this.btcerrar);
            this.groupControl1.Controls.Add(this.cbProducto);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtFecha);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 58);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1612, 696);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Informacion de Traslado Interno Producción";
            // 
            // cb_Horario
            // 
            this.cb_Horario.FormattingEnabled = true;
            this.cb_Horario.Location = new System.Drawing.Point(177, 36);
            this.cb_Horario.Name = "cb_Horario";
            this.cb_Horario.Size = new System.Drawing.Size(323, 21);
            this.cb_Horario.TabIndex = 70;
            // 
            // labelControl31
            // 
            this.labelControl31.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.labelControl31.Appearance.Options.UseFont = true;
            this.labelControl31.Location = new System.Drawing.Point(109, 35);
            this.labelControl31.Name = "labelControl31";
            this.labelControl31.Size = new System.Drawing.Size(60, 18);
            this.labelControl31.TabIndex = 69;
            this.labelControl31.Text = "Horario :";
            // 
            // btcerrar
            // 
            this.btcerrar.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.btcerrar.Appearance.Options.UseFont = true;
            this.btcerrar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btcerrar.ImageOptions.SvgImage")));
            this.btcerrar.Location = new System.Drawing.Point(716, 36);
            this.btcerrar.Name = "btcerrar";
            this.btcerrar.Size = new System.Drawing.Size(138, 54);
            this.btcerrar.TabIndex = 68;
            this.btcerrar.Text = "Cerrar";
            this.btcerrar.Click += new System.EventHandler(this.btcerrar_Click);
            // 
            // cbProducto
            // 
            this.cbProducto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProducto.Font = new System.Drawing.Font("Arial", 10F);
            this.cbProducto.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbProducto.FormattingEnabled = true;
            this.cbProducto.Location = new System.Drawing.Point(177, 63);
            this.cbProducto.Name = "cbProducto";
            this.cbProducto.Size = new System.Drawing.Size(323, 24);
            this.cbProducto.TabIndex = 38;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(100, 65);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(71, 18);
            this.labelControl6.TabIndex = 37;
            this.labelControl6.Text = "Producto :";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.Location = new System.Drawing.Point(529, 36);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(181, 52);
            this.simpleButton1.TabIndex = 9;
            this.simpleButton1.Text = "Movimientos \r\nProducción";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(119, 93);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 18);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Fecha :";
            // 
            // txtFecha
            // 
            this.txtFecha.EditValue = null;
            this.txtFecha.Location = new System.Drawing.Point(177, 93);
            this.txtFecha.MenuManager = this.ribbonControl1;
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.txtFecha.Properties.Appearance.Options.UseFont = true;
            this.txtFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFecha.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtFecha.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtFecha.Properties.EditFormat.FormatString = "";
            this.txtFecha.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtFecha.Properties.Mask.EditMask = "";
            this.txtFecha.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtFecha.Size = new System.Drawing.Size(323, 24);
            this.txtFecha.TabIndex = 3;
            // 
            // cbZafraProducto
            // 
            this.cbZafraProducto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbZafraProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbZafraProducto.Font = new System.Drawing.Font("Arial", 10F);
            this.cbZafraProducto.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbZafraProducto.FormattingEnabled = true;
            this.cbZafraProducto.Location = new System.Drawing.Point(177, 123);
            this.cbZafraProducto.Name = "cbZafraProducto";
            this.cbZafraProducto.Size = new System.Drawing.Size(136, 24);
            this.cbZafraProducto.TabIndex = 72;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(36, 123);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(133, 18);
            this.labelControl9.TabIndex = 71;
            this.labelControl9.Text = "Zafra de Producto :";
            // 
            // ReportesProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1612, 754);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "ReportesProduccion";
            this.Ribbon = this.ribbonControl1;
            this.Text = "AsignacionDocumento";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReportesProduccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFecha.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit txtFecha;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.ComboBox cbProducto;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton btcerrar;
        private System.Windows.Forms.ComboBox cb_Horario;
        private DevExpress.XtraEditors.LabelControl labelControl31;
        private System.Windows.Forms.ComboBox cbZafraProducto;
        private DevExpress.XtraEditors.LabelControl labelControl9;
    }
}
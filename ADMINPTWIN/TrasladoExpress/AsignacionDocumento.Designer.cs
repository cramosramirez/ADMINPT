
namespace ADMINPTWIN.TrasladoExpress
{
    partial class AsignacionDocumento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsignacionDocumento));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtFecha = new DevExpress.XtraEditors.DateEdit();
            this.btcerrar = new DevExpress.XtraEditors.SimpleButton();
            this.cbProducto = new System.Windows.Forms.ComboBox();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.btReporte = new DevExpress.XtraEditors.SimpleButton();
            this.btAplicar = new DevExpress.XtraEditors.SimpleButton();
            this.btImprimirNota = new DevExpress.XtraEditors.SimpleButton();
            this.btAsignarnota = new DevExpress.XtraEditors.SimpleButton();
            this.txtNota = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btViewCE5 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.gvLista = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.NRow = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ID_BASCONTROL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ID_ES_ENCA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ID_BASCULAENCA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FECHA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ID_BODEGAO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NOMBRE_PRODUCTO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ID_BODEGAD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NUM_DOC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TNOMBRE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CANTIDAD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbZafraProducto = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNota.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.groupControl1.Controls.Add(this.txtFecha);
            this.groupControl1.Controls.Add(this.btcerrar);
            this.groupControl1.Controls.Add(this.cbProducto);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.btReporte);
            this.groupControl1.Controls.Add(this.btAplicar);
            this.groupControl1.Controls.Add(this.btImprimirNota);
            this.groupControl1.Controls.Add(this.btAsignarnota);
            this.groupControl1.Controls.Add(this.txtNota);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.btViewCE5);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.gvLista);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 58);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1612, 696);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Informacion de Traslado Interno";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(31, 92);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(133, 18);
            this.labelControl9.TabIndex = 69;
            this.labelControl9.Text = "Zafra de Producto :";
            // 
            // txtFecha
            // 
            this.txtFecha.EditValue = null;
            this.txtFecha.Location = new System.Drawing.Point(172, 66);
            this.txtFecha.MenuManager = this.ribbonControl1;
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFecha.Size = new System.Drawing.Size(136, 20);
            this.txtFecha.TabIndex = 68;
            // 
            // btcerrar
            // 
            this.btcerrar.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.btcerrar.Appearance.Options.UseFont = true;
            this.btcerrar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btcerrar.ImageOptions.SvgImage")));
            this.btcerrar.Location = new System.Drawing.Point(920, 36);
            this.btcerrar.Name = "btcerrar";
            this.btcerrar.Size = new System.Drawing.Size(116, 52);
            this.btcerrar.TabIndex = 67;
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
            this.cbProducto.Location = new System.Drawing.Point(172, 36);
            this.cbProducto.Name = "cbProducto";
            this.cbProducto.Size = new System.Drawing.Size(323, 24);
            this.cbProducto.TabIndex = 38;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(95, 38);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(71, 18);
            this.labelControl6.TabIndex = 37;
            this.labelControl6.Text = "Producto :";
            // 
            // btReporte
            // 
            this.btReporte.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.btReporte.Appearance.Options.UseFont = true;
            this.btReporte.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btReporte.ImageOptions.SvgImage")));
            this.btReporte.Location = new System.Drawing.Point(784, 36);
            this.btReporte.Name = "btReporte";
            this.btReporte.Size = new System.Drawing.Size(130, 52);
            this.btReporte.TabIndex = 11;
            this.btReporte.Text = "Reporte";
            this.btReporte.Click += new System.EventHandler(this.btReporte_Click);
            // 
            // btAplicar
            // 
            this.btAplicar.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.btAplicar.Appearance.Options.UseFont = true;
            this.btAplicar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btAplicar.ImageOptions.SvgImage")));
            this.btAplicar.Location = new System.Drawing.Point(501, 139);
            this.btAplicar.Name = "btAplicar";
            this.btAplicar.Size = new System.Drawing.Size(115, 38);
            this.btAplicar.TabIndex = 10;
            this.btAplicar.Text = "Aplicar";
            this.btAplicar.Click += new System.EventHandler(this.btAplicar_Click);
            // 
            // btImprimirNota
            // 
            this.btImprimirNota.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.btImprimirNota.Appearance.Options.UseFont = true;
            this.btImprimirNota.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btImprimirNota.ImageOptions.SvgImage")));
            this.btImprimirNota.Location = new System.Drawing.Point(622, 141);
            this.btImprimirNota.Name = "btImprimirNota";
            this.btImprimirNota.Size = new System.Drawing.Size(181, 38);
            this.btImprimirNota.TabIndex = 8;
            this.btImprimirNota.Text = "Imprimir Nota";
            this.btImprimirNota.Click += new System.EventHandler(this.btImprimirNota_Click);
            // 
            // btAsignarnota
            // 
            this.btAsignarnota.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.btAsignarnota.Appearance.Options.UseFont = true;
            this.btAsignarnota.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btAsignarnota.ImageOptions.SvgImage")));
            this.btAsignarnota.Location = new System.Drawing.Point(314, 139);
            this.btAsignarnota.Name = "btAsignarnota";
            this.btAsignarnota.Size = new System.Drawing.Size(181, 38);
            this.btAsignarnota.TabIndex = 7;
            this.btAsignarnota.Text = "Asignar Documento";
            this.btAsignarnota.Click += new System.EventHandler(this.btAsignarnota_Click);
            // 
            // txtNota
            // 
            this.txtNota.Location = new System.Drawing.Point(172, 147);
            this.txtNota.MenuManager = this.ribbonControl1;
            this.txtNota.Name = "txtNota";
            this.txtNota.Properties.Appearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.txtNota.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.txtNota.Properties.Appearance.Options.UseBorderColor = true;
            this.txtNota.Properties.Appearance.Options.UseFont = true;
            this.txtNota.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtNota.Size = new System.Drawing.Size(136, 22);
            this.txtNota.TabIndex = 6;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(34, 149);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(132, 18);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "N° Nota Remision :";
            // 
            // btViewCE5
            // 
            this.btViewCE5.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.btViewCE5.Appearance.Options.UseFont = true;
            this.btViewCE5.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btViewCE5.ImageOptions.SvgImage")));
            this.btViewCE5.Location = new System.Drawing.Point(516, 36);
            this.btViewCE5.Name = "btViewCE5";
            this.btViewCE5.Size = new System.Drawing.Size(245, 52);
            this.btViewCE5.TabIndex = 4;
            this.btViewCE5.Text = "Mostras Movimientos \r\nDizucar CE #5";
            this.btViewCE5.Click += new System.EventHandler(this.btView_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(114, 66);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 18);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Fecha :";
            // 
            // gvLista
            // 
            this.gvLista.Location = new System.Drawing.Point(34, 264);
            this.gvLista.MainView = this.gridView1;
            this.gvLista.MenuManager = this.ribbonControl1;
            this.gvLista.Name = "gvLista";
            this.gvLista.Size = new System.Drawing.Size(1223, 455);
            this.gvLista.TabIndex = 1;
            this.gvLista.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.NRow,
            this.ID_BASCONTROL,
            this.ID_ES_ENCA,
            this.ID_BASCULAENCA,
            this.FECHA,
            this.ID_BODEGAO,
            this.NOMBRE_PRODUCTO,
            this.ID_BODEGAD,
            this.NUM_DOC,
            this.TNOMBRE,
            this.CANTIDAD});
            this.gridView1.GridControl = this.gvLista;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // NRow
            // 
            this.NRow.Caption = "#";
            this.NRow.FieldName = "NRow";
            this.NRow.Name = "NRow";
            this.NRow.OptionsColumn.ReadOnly = true;
            this.NRow.Visible = true;
            this.NRow.VisibleIndex = 0;
            this.NRow.Width = 43;
            // 
            // ID_BASCONTROL
            // 
            this.ID_BASCONTROL.Caption = "Nº Sistema(id)";
            this.ID_BASCONTROL.FieldName = "ID_BASCONTROL";
            this.ID_BASCONTROL.Name = "ID_BASCONTROL";
            this.ID_BASCONTROL.OptionsColumn.ReadOnly = true;
            // 
            // ID_ES_ENCA
            // 
            this.ID_ES_ENCA.Caption = "Id Movimiento";
            this.ID_ES_ENCA.FieldName = "ID_ES_ENCA";
            this.ID_ES_ENCA.Name = "ID_ES_ENCA";
            this.ID_ES_ENCA.OptionsColumn.ReadOnly = true;
            // 
            // ID_BASCULAENCA
            // 
            this.ID_BASCULAENCA.Caption = "Id Basculo";
            this.ID_BASCULAENCA.FieldName = "ID_BASCULAENCA";
            this.ID_BASCULAENCA.Name = "ID_BASCULAENCA";
            this.ID_BASCULAENCA.OptionsColumn.ReadOnly = true;
            // 
            // FECHA
            // 
            this.FECHA.Caption = "Fecha";
            this.FECHA.FieldName = "FECHA";
            this.FECHA.Name = "FECHA";
            this.FECHA.OptionsColumn.ReadOnly = true;
            this.FECHA.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.FECHA.Visible = true;
            this.FECHA.VisibleIndex = 1;
            this.FECHA.Width = 86;
            // 
            // ID_BODEGAO
            // 
            this.ID_BODEGAO.Caption = "Bodega Origen";
            this.ID_BODEGAO.FieldName = "ID_BODEGAO";
            this.ID_BODEGAO.Name = "ID_BODEGAO";
            this.ID_BODEGAO.OptionsColumn.ReadOnly = true;
            this.ID_BODEGAO.Visible = true;
            this.ID_BODEGAO.VisibleIndex = 2;
            this.ID_BODEGAO.Width = 259;
            // 
            // NOMBRE_PRODUCTO
            // 
            this.NOMBRE_PRODUCTO.Caption = "Producto";
            this.NOMBRE_PRODUCTO.FieldName = "NOMBRE_PRODUCTO";
            this.NOMBRE_PRODUCTO.Name = "NOMBRE_PRODUCTO";
            this.NOMBRE_PRODUCTO.OptionsColumn.ReadOnly = true;
            this.NOMBRE_PRODUCTO.Visible = true;
            this.NOMBRE_PRODUCTO.VisibleIndex = 3;
            this.NOMBRE_PRODUCTO.Width = 259;
            // 
            // ID_BODEGAD
            // 
            this.ID_BODEGAD.Caption = "Bodega Destino";
            this.ID_BODEGAD.FieldName = "ID_BODEGAD";
            this.ID_BODEGAD.Name = "ID_BODEGAD";
            this.ID_BODEGAD.OptionsColumn.ReadOnly = true;
            this.ID_BODEGAD.Visible = true;
            this.ID_BODEGAD.VisibleIndex = 4;
            this.ID_BODEGAD.Width = 259;
            // 
            // NUM_DOC
            // 
            this.NUM_DOC.Caption = "N°Documento";
            this.NUM_DOC.FieldName = "NUM_DOC";
            this.NUM_DOC.Name = "NUM_DOC";
            this.NUM_DOC.OptionsColumn.ReadOnly = true;
            this.NUM_DOC.Visible = true;
            this.NUM_DOC.VisibleIndex = 5;
            this.NUM_DOC.Width = 86;
            // 
            // TNOMBRE
            // 
            this.TNOMBRE.Caption = "Tarima";
            this.TNOMBRE.FieldName = "TNOMBRE";
            this.TNOMBRE.Name = "TNOMBRE";
            this.TNOMBRE.OptionsColumn.ReadOnly = true;
            this.TNOMBRE.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TNOMBRE", "Total")});
            this.TNOMBRE.Visible = true;
            this.TNOMBRE.VisibleIndex = 6;
            this.TNOMBRE.Width = 100;
            // 
            // CANTIDAD
            // 
            this.CANTIDAD.Caption = "Cantidad";
            this.CANTIDAD.FieldName = "CANTIDAD";
            this.CANTIDAD.Name = "CANTIDAD";
            this.CANTIDAD.OptionsColumn.ReadOnly = true;
            this.CANTIDAD.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CANTIDAD", "", "")});
            this.CANTIDAD.Visible = true;
            this.CANTIDAD.VisibleIndex = 7;
            this.CANTIDAD.Width = 100;
            // 
            // cbZafraProducto
            // 
            this.cbZafraProducto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbZafraProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbZafraProducto.Font = new System.Drawing.Font("Arial", 10F);
            this.cbZafraProducto.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbZafraProducto.FormattingEnabled = true;
            this.cbZafraProducto.Location = new System.Drawing.Point(172, 92);
            this.cbZafraProducto.Name = "cbZafraProducto";
            this.cbZafraProducto.Size = new System.Drawing.Size(136, 24);
            this.cbZafraProducto.TabIndex = 70;
            // 
            // AsignacionDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1612, 754);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "AsignacionDocumento";
            this.Ribbon = this.ribbonControl1;
            this.Text = "AsignacionDocumento";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AsignacionDocumento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNota.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btViewCE5;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl gvLista;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn ID_BASCONTROL;
        private DevExpress.XtraGrid.Columns.GridColumn ID_BASCULAENCA;
        private DevExpress.XtraGrid.Columns.GridColumn ID_ES_ENCA;
        private DevExpress.XtraGrid.Columns.GridColumn FECHA;
        private DevExpress.XtraGrid.Columns.GridColumn NUM_DOC;
        private DevExpress.XtraGrid.Columns.GridColumn CANTIDAD;
        private DevExpress.XtraGrid.Columns.GridColumn NRow;
        private DevExpress.XtraGrid.Columns.GridColumn ID_BODEGAO;
        private DevExpress.XtraGrid.Columns.GridColumn NOMBRE_PRODUCTO;
        private DevExpress.XtraGrid.Columns.GridColumn ID_BODEGAD;
        private DevExpress.XtraEditors.TextEdit txtNota;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btImprimirNota;
        private DevExpress.XtraEditors.SimpleButton btAsignarnota;
        private DevExpress.XtraEditors.SimpleButton btReporte;
        private DevExpress.XtraEditors.SimpleButton btAplicar;
        private DevExpress.XtraGrid.Columns.GridColumn TNOMBRE;
        private System.Windows.Forms.ComboBox cbProducto;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton btcerrar;
        private DevExpress.XtraEditors.DateEdit txtFecha;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private System.Windows.Forms.ComboBox cbZafraProducto;
    }
}
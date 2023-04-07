
namespace ADMINPTWIN.Reportes.Bascula
{
    partial class TARIMA_BARRA
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraPrinting.BarCode.EAN128Generator eaN128Generator1 = new DevExpress.XtraPrinting.BarCode.EAN128Generator();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrBarCode1 = new DevExpress.XtraReports.UI.XRBarCode();
            this.dsReportes1 = new ADMINPTWIN.Reportes.Bascula.DsReportes();
            this.rPT_MOVIMIENTOS_BASCULATableAdapter = new ADMINPTWIN.Reportes.Bascula.DsReportesTableAdapters.RPT_MOVIMIENTOS_BASCULATableAdapter();
            this.seL_TARIMATableAdapter1 = new ADMINPTWIN.Reportes.Bascula.DsReportesTableAdapters.SEL_TARIMATableAdapter();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this.dsReportes1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrBarCode1});
            this.Detail.HeightF = 129.542F;
            this.Detail.Name = "Detail";
            // 
            // xrBarCode1
            // 
            this.xrBarCode1.AutoModule = true;
            this.xrBarCode1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ID_TARIMA]")});
            this.xrBarCode1.LocationFloat = new DevExpress.Utils.PointFloat(21.875F, 0F);
            this.xrBarCode1.Module = 3F;
            this.xrBarCode1.Name = "xrBarCode1";
            this.xrBarCode1.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100F);
            this.xrBarCode1.SizeF = new System.Drawing.SizeF(332.2917F, 105.5836F);
            this.xrBarCode1.Symbology = eaN128Generator1;
            // 
            // dsReportes1
            // 
            this.dsReportes1.DataSetName = "DsReportes";
            this.dsReportes1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rPT_MOVIMIENTOS_BASCULATableAdapter
            // 
            this.rPT_MOVIMIENTOS_BASCULATableAdapter.ClearBeforeFill = true;
            // 
            // seL_TARIMATableAdapter1
            // 
            this.seL_TARIMATableAdapter1.ClearBeforeFill = true;
            // 
            // PageHeader
            // 
            this.PageHeader.HeightF = 41.66667F;
            this.PageHeader.Name = "PageHeader";
            // 
            // PageFooter
            // 
            this.PageFooter.Name = "PageFooter";
            // 
            // TARIMA_BARRA
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.PageHeader,
            this.PageFooter});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.dsReportes1});
            this.DataAdapter = this.seL_TARIMATableAdapter1;
            this.DataMember = "SEL_TARIMA";
            this.DataSource = this.dsReportes1;
            this.Font = new System.Drawing.Font("Verdana", 12F);
            this.Version = "20.1";
            ((System.ComponentModel.ISupportInitialize)(this.dsReportes1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DsReportes dsReportes1;
        private DsReportesTableAdapters.RPT_MOVIMIENTOS_BASCULATableAdapter rPT_MOVIMIENTOS_BASCULATableAdapter;
        private DsReportesTableAdapters.SEL_TARIMATableAdapter seL_TARIMATableAdapter1;
        private DevExpress.XtraReports.UI.XRBarCode xrBarCode1;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
    }
}

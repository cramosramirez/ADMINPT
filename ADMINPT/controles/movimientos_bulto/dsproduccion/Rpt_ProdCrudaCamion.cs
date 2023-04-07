using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT.controles.movimientos_bulto.dsproduccion
{
    public partial class Rpt_ProdCrudaCamion : DevExpress.XtraReports.UI.XtraReport
    {
        public Rpt_ProdCrudaCamion( int ID_BODEP, DateTime FECHA, string HORARIO)
        {
            InitializeComponent();
            rPT_PROD_CRUDA_DIATableAdapter.Fill(dstProdCrudaCamion1.RPT_PROD_CRUDA_DIA, ID_BODEP, FECHA, HORARIO);
        }

    }
}

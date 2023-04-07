using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT.controles.movimientos_bulto.dsproduccion
{
    public partial class Rpt_ProdCrudaCamionF : DevExpress.XtraReports.UI.XtraReport
    {
        public Rpt_ProdCrudaCamionF( int ID_BODEP, DateTime FECHA, DateTime FECHAH, string HORARIO)
        {
            InitializeComponent();
         rpT_PROD_CRUDA_DIA_FTableAdapter1.Fill(dstProdCrudaCamion1.RPT_PROD_CRUDA_DIA_F, ID_BODEP, FECHA,FECHAH , HORARIO);
        }

    }
}

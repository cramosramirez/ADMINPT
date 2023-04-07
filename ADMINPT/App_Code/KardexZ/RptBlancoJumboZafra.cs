﻿using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT
{
    public partial class RptBlancoJumboZafra : DevExpress.XtraReports.UI.XtraReport
    {
        public RptBlancoJumboZafra(DateTime FECHAD, DateTime FECHAH, int ID_BODEP, int ID_ZAFRA_PROD, int ID_PRODUCTO)
        {
            InitializeComponent();
            rpT_KARDEX_BLANCO_JUMBO_ZTableAdapter1.Fill(ds_KardexZafra1.RPT_KARDEX_BLANCO_JUMBO_Z, FECHAD, FECHAH, ID_BODEP, ID_ZAFRA_PROD, ID_PRODUCTO);
        }

    }
}

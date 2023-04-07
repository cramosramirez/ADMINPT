﻿using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT
{
    public partial class RptMorenoLocalZafra : DevExpress.XtraReports.UI.XtraReport
    {
        public RptMorenoLocalZafra(DateTime FECHAD, DateTime FECHAH, int ID_BODEP, int ID_ZAFRA_PROD, int ID_PRODUCTO)
        {
            InitializeComponent();
            rpT_KARDEX_MORENALOCAL_ZTableAdapter1.Fill(ds_KardexZafra1.RPT_KARDEX_MORENALOCAL_Z, FECHAD, FECHAH, ID_BODEP, ID_ZAFRA_PROD, ID_PRODUCTO);
        }

    }
}

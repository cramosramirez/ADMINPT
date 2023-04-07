﻿using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT.RptDia
{
    public partial class RptMovDiaZafra : DevExpress.XtraReports.UI.XtraReport
    {
        public RptMovDiaZafra(int ID_BODEP,int  ID_ZAFRA,DateTime FECHA)
        {
            InitializeComponent();
            rPT_EST_5_EXIST_PT_BODEGA_ZAFRA_DIARIO_MOV_INVENTTableAdapter.Fill(dstRptDia1.RPT_EST_5_EXIST_PT_BODEGA_ZAFRA_DIARIO_MOV_INVENT,ID_BODEP,ID_ZAFRA,FECHA);
        }

    }
}

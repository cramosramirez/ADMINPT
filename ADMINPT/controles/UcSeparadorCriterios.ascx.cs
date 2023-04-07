using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles
{
    public partial class UcSeparadorCriterios : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public System.Web.UI.HtmlControls.HtmlTableRow Cont_SepradorBarraNavegacion
        {
            get { return _Cont_SepradorBarraNavegacion; }
            set { _Cont_SepradorBarraNavegacion = value; }
        }

        public DevExpress.Web.ASPxLabel lbl_tituloBarraNavegacion
        {
            get { return _lbl_tituloBarraNavegacion; }
            set { _lbl_tituloBarraNavegacion = value; }
        }
    }
}
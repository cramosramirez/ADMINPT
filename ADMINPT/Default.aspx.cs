using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			// Generate a random value between 1 and 9
			int caseSwitch = Convert.ToInt32(Session["ID_BODEP"]);
			switch (caseSwitch)
			{
				case 0:
					img_adminpt.ClientVisible = true;
					img_principal.ClientVisible = false;
					break;
				case 29:
					img_injiboa1.ClientVisible = true;
					img_principal.ClientVisible = false;
					break;
				case 16:
					img_almaconsa.ClientVisible = true;
					img_principal.ClientVisible = false;
					break;
				case 17:
					img_almapac.ClientVisible = true;
					img_principal.ClientVisible = false;
					break;
				default:
					img_principal.ClientVisible = true;
					break;
			}
		}
	}
}
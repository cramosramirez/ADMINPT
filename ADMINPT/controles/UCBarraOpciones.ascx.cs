using ADMINPT.DL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles
{
    public partial class UCBarraOpciones : System.Web.UI.UserControl
    {

        public static class NombreBotonesMantenimiento{
            public static string Nuevo = "Nuevo";
            public static string Guardar = "Guardar";
            public static string Cancelar = "Cancelar";
            public static string Eliminar = "Eliminar";
        }

        public event Action<string> OpcionSeleccionada;        
        private List<OpcionBarra> mListaOpcionesBarra = new List<OpcionBarra>();

        public Boolean ModoMantenimiento
        {
            get
            {
                if (ViewState["ModoMantenimiento"] == null) { return true; } else { return Convert.ToBoolean(ViewState["ModoMantenimiento"]); }
            }
            set
            {
                if (ViewState["ModoMantenimiento"] == null)
                {
                    ViewState.Add("ModoMantenimiento", value);
                }
                else
                {
                    ViewState["ModoMantenimiento"] = value;
                }               
            }
        }

        public void CrearOpcion(string CommandName, string AlternateText, Boolean CausesValidation, string ImageUrl, string AtributoKey = "", string AtributoValue = "", Boolean EsIconID = false)
        {
            if (!EsIconID)
            {
                OpcionBarra[] mEntidad = new OpcionBarra[0];
                mEntidad[0].CommandName = CommandName;
                mEntidad[0].AlternateText = AlternateText;
                mEntidad[0].CausesValidation = CausesValidation;
                mEntidad[0].ImageUrl = ImageUrl;
                mEntidad[0].AtributoKey = AtributoKey;
                mEntidad[0].AtributoValue = AtributoValue;
                //mEntidad[0].CausesValidation = true;
                OpcionBarra Result = mListaOpcionesBarra.Find(delegate (OpcionBarra a) { return a.CommandName == CommandName; });
                if (Result == null) { mListaOpcionesBarra.Add(Result);}
            }
            else
            {
                OpcionBarra[] mEntidad = new OpcionBarra[0];
                mEntidad[0].CommandName = CommandName;
                mEntidad[0].AlternateText = AlternateText;
                mEntidad[0].CausesValidation = CausesValidation;
                mEntidad[0].IconID = ImageUrl;
                mEntidad[0].AtributoKey = AtributoKey;
                mEntidad[0].AtributoValue = AtributoValue;
                //mEntidad[0].CausesValidation = true;
                OpcionBarra Result = mListaOpcionesBarra.Find(delegate (OpcionBarra a) { return a.CommandName == CommandName; });
                if (Result == null) { mListaOpcionesBarra.Add(Result); }
            }
        }

        public void VerOpcion(string CommandName, Boolean EsVisible) {
            foreach (DevExpress.Web.MenuItem lmenu in mDinamico.Items)
            {
                if (lmenu.Name == CommandName) { lmenu.ClientVisible = EsVisible; }
            }
        }

        public void CargarOpciones() {
            mDinamico.Items.Clear();
            if (ModoMantenimiento)
            {
                CargarOpcionesMantto(); 
            }
                
            foreach (OpcionBarra lOpcion in mListaOpcionesBarra)
            {
                DevExpress.Web.MenuItem lMenu = new DevExpress.Web.MenuItem();
                if (lOpcion.IconID != string.Empty)
                {
                    lMenu.Image.IconID = lOpcion.IconID;
                }
                else
                {
                    lMenu.Image.Url = lOpcion.ImageUrl;
                }
                lMenu.Image.AlternateText = lOpcion.AlternateText;
                lMenu.Name = lOpcion.CommandName;
                lMenu.Text = lOpcion.AlternateText;
                lMenu.ClientVisible = false;
                mDinamico.Items.Add(lMenu);
            }
        }

        private void CargarOpcionesMantto()
        {
            DevExpress.Web.MenuItem lMenu;
            // Opcion Nuevo
            lMenu = new DevExpress.Web.MenuItem();
            lMenu.Image.IconID = "actions_new_16x16";
            lMenu.Image.AlternateText = NombreBotonesMantenimiento.Nuevo;  
            lMenu.Name = NombreBotonesMantenimiento.Nuevo;
            lMenu.Text = NombreBotonesMantenimiento.Nuevo;
            lMenu.ClientVisible = false;
            mDinamico.Items.Add(lMenu);

            // Opcion Guardar
            lMenu = new DevExpress.Web.MenuItem();
            lMenu.Image.IconID = "save_save_16x16";
            lMenu.Image.AlternateText = NombreBotonesMantenimiento.Guardar;
            lMenu.Name = NombreBotonesMantenimiento.Guardar;
            lMenu.Text = NombreBotonesMantenimiento.Guardar;
                        lMenu.ClientVisible = false;
            mDinamico.Items.Add(lMenu);

            // Opcion Eliminar
            lMenu = new DevExpress.Web.MenuItem();
            lMenu.Image.IconID = "edit_delete_16x16";
            lMenu.Image.AlternateText = NombreBotonesMantenimiento.Eliminar;
            lMenu.Name = NombreBotonesMantenimiento.Eliminar;
            lMenu.Text = NombreBotonesMantenimiento.Eliminar;
            
            lMenu.ClientVisible = false;
            mDinamico.Items.Add(lMenu);

            // Opcion Cancelar
            lMenu = new DevExpress.Web.MenuItem();
            lMenu.Image.IconID = "actions_reset_16x16";
            lMenu.Image.AlternateText = NombreBotonesMantenimiento.Cancelar;
            lMenu.Name = NombreBotonesMantenimiento.Cancelar;
            lMenu.Text = NombreBotonesMantenimiento.Cancelar;
            lMenu.ClientVisible = false; 
            mDinamico.Items.Add(lMenu);
        }

         protected void mDinamico_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
        {
           
                OpcionSeleccionada(e.Item.Name);
           
            
        }
    }
}
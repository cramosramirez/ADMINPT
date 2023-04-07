﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADMINPT.BL;
using ADMINPT.DL.Modelo;

namespace ADMINPT.controles.kardex
{
     public partial class UcVistaKARDEX : System.Web.UI.UserControl
    {
        #region "Propiedades"

        private CKARDEX Controlador = new CKARDEX();
        public int Identificador
        {
            get
            {
                if (ViewState["Identificador"] == null) { return 0; } else { return Convert.ToInt32(ViewState["Identificador"]); }
            }
            set
            {
                if (ViewState["Identificador"] == null)
                    ViewState.Add("Identificador", value);
                else
                    ViewState["Identificador"] = value;
                Nuevo();
                if (value > 0)
                {
                    CargarVista();
                }
            }
        }

        private void CargarListas()
        {
            //odsMARCA.DataBind();
            //cbxMARCA.DataSourceID = "odsMARCA";
            //cbxMARCA.DataBind();
        }
        private void CargarVista()
        {

            ModoEdicion(true);
            KARDEX Entidad = Controlador.ObtenerPorId(Identificador);
            if (Entidad != null)
            {
                txtIdentificador.Text = Entidad.ID_KARDEX.ToString();
                //chkESTADO.Checked = Entidad.ESTADO;
            }
        }
        private void ModoEdicion(Boolean esEdicion)
        {
            txtIdentificador.ClientEnabled = false;
            chkESTADO.ClientEnabled = esEdicion;
        }

        public string Actualizar()
        {
            string Result = "";
            KARDEX Entidad = new KARDEX();
            if (Identificador > 0)
            {
                Entidad = Controlador.ObtenerPorId(Identificador);
                Entidad.USUARIO_ACT = CUTILERIAS.ObtenerUsuario();
            }
            else
            {
                Entidad.USUARIO_CREA = CUTILERIAS.ObtenerUsuario();
            }
            // Seteando la entidad con los campos de la vista y actualizando mediante el controlador

            //Entidad.ESTADO = chkESTADO.Checked;

            Controlador.Actualizar(Entidad);
            Result = Controlador.sError;

            return Result;
        }

        public string Eliminar()
        {
            string Result = "";
            if (Identificador > 0)
            {
                Controlador.Eliminar(Identificador);
                Result = Controlador.sError;
            }
            return Result;
        }

        private void Nuevo()
        {
            CargarListas();
            txtIdentificador.Text = "";
        }
        #endregion

        #region "Atributos"
        public DevExpress.Web.ASPxTextBox txt_Identificador
        {
            get { return txtIdentificador; }
            set { txtIdentificador = value; }
        }
        #endregion
    }
}

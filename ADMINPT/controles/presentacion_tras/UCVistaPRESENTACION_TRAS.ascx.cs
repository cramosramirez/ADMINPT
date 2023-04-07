﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADMINPT.BL;
using ADMINPT.DL.Modelo;

namespace ADMINPT.controles.presentacion_tras
{
    public partial class UCVistaPRESENTACION_TRAS : System.Web.UI.UserControl
    {
        #region "Propiedades"

        private CPRESENTACION_TRAS Controlador = new CPRESENTACION_TRAS();
        public int Identificador
        {
            get
            {
                if (ViewState["Identificador"] == null) { return 0; } else { return Convert.ToInt32(ViewState["Identificador"]); }
            }
            set
            {
                if (ViewState["Identificador"] == null)
                {
                    ViewState.Add("Identificador", value);
                }
                else
                {
                    ViewState["Identificador"] = value;
                }
                Nuevo();
                if (value > 0)
                {
                    CargarVista();
                }
            }
        }

        private void CargarVista()
        {

            ModoEdicion(true);
            PRESENTACION_TRAS Entidad = Controlador.ObtenerPorId(Identificador);
            if (Entidad != null)
            {
                txtIdentificador.Text = Entidad.ID_PRESEN_TRAS.ToString();
                txtNOMBRE_PRESEN_TRAA.Text = Entidad.NOMBRE_PRESEN_TRAA;
                chkESTADO.Value = Entidad.ESTADO;
            }
        }

        private void ModoEdicion(Boolean esEdicion)
        {
            txtIdentificador.ClientEnabled = false;
            txtNOMBRE_PRESEN_TRAA.ClientEnabled = esEdicion;
            chkESTADO.ClientEnabled = esEdicion;
        }

        public string Actualizar()
        {
            string Result = "";
            PRESENTACION_TRAS Entidad = new PRESENTACION_TRAS();
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
            Entidad.NOMBRE_PRESEN_TRAA = txtNOMBRE_PRESEN_TRAA.Text;
            Entidad.ESTADO = Convert.ToBoolean(chkESTADO.Value);
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
            txtIdentificador.Text = "";
            txtNOMBRE_PRESEN_TRAA.Text = "";
            chkESTADO.Checked = true;
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
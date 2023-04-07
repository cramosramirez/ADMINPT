using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using ADMINPT.BL;
using ADMINPT.DL;
using ADMINPT.DL.Entidades;

namespace ADMINPT
{
    public class cENT_SAL_PRODcache
    {
        //private HttpSessionState _SESION;
        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        //public ENTRADA_SALIDA_DETA ObtenerLista(string nombreSesion_uclistaENT_SAL_PROD)
        //{
        //    try
        //    {
        //        listaENT_SAL_PROD lista;
        //        _SESION = HttpContext.Current.Session;
        //        if (_SESION(nombreSesion_uclistaENT_SAL_PROD) == null)
        //            return new listaENT_SAL_PROD();
        //        lista = _SESION(nombreSesion_uclistaENT_SAL_PROD) as listaENT_SAL_PROD;

        //        return lista;
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionManager.Publish(ex);
        //        return null/* TODO Change to default(_) if this is not a reference type */;
        //    }
        //}
    }
}
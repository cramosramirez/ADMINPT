<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMantProduccionCrudoBsp.ascx.cs" Inherits="ADMINPT.controles.movimiento_banda.UcMantProduccionCrudoBsp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/controles/UCBarraNavegacion.ascx" TagPrefix="uc1" TagName="UCBarraNavegacion" %>
<%@ Register Src="~/controles/UCEncabezado.ascx" TagPrefix="uc1" TagName="UCEncabezado" %>


<link href="../../Content/uc.css" rel="stylesheet" type="text/css" />
<script src="../../Scripts/uppercase.js"></script>
<script type="text/javascript">
    function OnKeyPress(s, e) {
        var theEvent = e.htmlEvent || window.event;
        var key = theEvent.keyCode || theEvent.which;
        var txt = s.GetText();
        if (key != 8 || key != 13) txt += String.fromCharCode(key);
        var regex = /^[0-9]*\.?[0-9]*$/;
        if (!regex.test(txt)) {
            theEvent.returnValue = false;
            if (theEvent.preventDefault) theEvent.preventDefault();
        }
    }
    function changedupper(s, e) {
        s.SetText(s.GetText().toUpperCase());
    }
    function Numericint(s, e) {
        var theEvent = e.htmlEvent || window.event;
        var key = theEvent.keyCode || theEvent.which;
        key = String.fromCharCode(key);
        var regex = /[0-9]/;
        if (!regex.test(key)) {
            theEvent.returnValue = false;
            if (theEvent.preventDefault)
                theEvent.preventDefault();
        }
    }
    function Numericint_(s, e) {
        var theEvent = e.htmlEvent || window.event;
        var key = theEvent.keyCode || theEvent.which;
        key = String.fromCharCode(key);
        var regex = /[0-9]-/;
        if (!regex.test(key)) {
            theEvent.returnValue = false;
            if (theEvent.preventDefault)
                theEvent.preventDefault();
        }
    }
    function UpdateGridHeight() {
        Dgv_List.SetHeight(0);
        var containerHeight = ASPxClientUtils.GetDocumentClientHeight();
        if (document.body.scrollHeight > containerHeight)
            containerHeight = document.body.scrollHeight;
        Dgv_List.SetHeight(containerHeight);
    }
    window.addEventListener('resize', function (evt) {
        if (ASPxClientUtils && !ASPxClientUtils.androidPlatform)
            return;
        var activeElement = document.activeElement;
        if (activeElement && (activeElement.tagName === "INPUT" || activeElement.tagName === "TEXTAREA") && activeElement.scrollIntoViewIfNeeded)
            window.setTimeout(function () { activeElement.scrollIntoViewIfNeeded(); }, 0);
    });
    var visibleIndex;
    function OnCustomButtonClick(s, e) {
        elem = document.getElementById("tabla1");
        elem.style.display = "block";

        elem1 = document.getElementById("tabla2");
        elem1.style.display = "none";

        visibleIndex = e.visibleIndex;

        popup.Show();
        popup.BringToFront();
    }
    function OnClickYes(s, e) {
        Dgv_List.DeleteRow(visibleIndex);
        popup.Hide();
    }
    function OnClickNo(s, e) {
        popup.Hide();
    }
    function OnCallbackError(s, e) {
        elem = document.getElementById("tabla1");
        elem.style.display = "none";
        elem1 = document.getElementById("tabla2");
        elem1.style.display = "block";
        e.handled = true;
        var theoriginal = document.getElementById('ori');
        var thereplacement = document.createElement('p');
        thereplacement.style.color = "red";
        thereplacement.style.fontSize = "12px";
        thereplacement.style.fontWeight = "bold";
        thereplacement.appendChild(document.createTextNode(e.message));
        theoriginal.replaceChild(thereplacement, theoriginal.lastChild);
        //ShowMessage(e.message, "success");;
    }
    function onItemFiltering(s, e) {
        if (!e.isFit)
            e.isFit = toLatin(e.item.text).indexOf(toLatin(e.filter)) > -1;
    }
    function onCustomHighlighting(s, e) {
        e.highlighting = new RegExp(toLatin(e.filter)
            .replace(/u/gi, "(u|\u00fc)")
            .replace(/a/gi, "(a|\u00e4)")
            .replace(/o/gi, "(o|\u00f6)")
            , "gi");
    }
    function toLatin(text) {
        return text
            .replace(/\u00fc/gi, "u")
            .replace(/\u00e4/gi, "a")
            .replace(/\u00f6/gi, "o")
            .toLowerCase();
    }
</script>
<uc1:UCBarraNavegacion runat="server" ID="UCBarraNavegacion" />






<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VisualizadorCrystal.aspx.cs" Inherits="Reportes_VisualizadorCrystal" Culture="es-MX" UICulture="es-MX" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ OutputCache Duration="3" VaryByParam="none" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Reportes</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="formReportes" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div>
       
                <br />
          
        <CR:CrystalReportViewer ID="CR_Reportes" runat="server" AutoDataBind="true" />
       
    </div>
    
    </form>
</body>
</html>

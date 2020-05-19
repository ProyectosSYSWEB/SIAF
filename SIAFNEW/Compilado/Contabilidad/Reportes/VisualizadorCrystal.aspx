<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisualizadorCrystal.aspx.cs" Inherits="SAF.Reportes.VisualizadorCrystal" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        
        <CR:CrystalReportViewer ID="CR_Reportes" runat="server" AutoDataBind="true" />
    </div>
    </form>
</body>
</html>

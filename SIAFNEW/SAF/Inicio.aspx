﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="SAF.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 150px;
            height: 140px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <div class="row">
        <div class="col-sm-4">
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">
                        <img src="images/presupuesto.png" class="auto-style2" />Movimientos</h5>
                    <p class="card-text"></p>
                    <a href="Default.aspx?mnu=MOV" class="btn btn-warning btn-rounded">Continuar</a>
                </div>
            </div>
        </div>

        <div class="col-sm-4">
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">
                        <img src="images/pres6.png" class="auto-style2" />
                        Reportes

                    </h5>
                    <p class="card-text">
                        <%--Presupuestos por fuente de financiamiento, mensual, acumulado, por proyecto.--%>
            <br />
                    </p>
                    <a href="Default.aspx?mnu=REP" class="btn btn-warning btn-rounded">Continuar</a>
                </div>
            </div>
        </div>
        <div class="col-sm-4">
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">
                        <img src="images/pres7.png" class="auto-style2" /></h5>

                    <p class="card-text"></p>
                    <br />
                    <%--<a href="Presupuesto/Form/frmDashboard.aspx" class="btn btn-warning btn-rounded">Continuar</a>--%>
                </div>
            </div>
        </div>
    </div>
    <br />

    
    <asp:HiddenField ID="HiddenField1" runat="server" />

    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="HiddenField1" PopupControlID="Panel3" BackgroundCssClass="modalBackground_Proy">
    </ajaxToolkit:ModalPopupExtender>

    <%-- Inicia PopUP --%>


    <asp:Panel ID="Panel3" runat="server" CssClass="TituloModalPopupMsg" Width="400px">

        <asp:ImageButton ID="imgCerrar" ImageUrl="http://sysweb.unach.mx/resources/imagenes/cerrar.png" runat="server" Width="10px" CssClass="cerrar_pop" />

        <div class="titulo_pop">
            AVISO
            
        </div>
        <center>
                <br />
         <img src="http://sysweb.unach.mx/resources/imagenes/informacion.png"/>
             </center>

        <div class="info_pop gris_11px izquierda">
            <asp:UpdatePanel ID="UpdatePanel40" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lblMsg_Observaciones" runat="server" Text="Una mentalidad positiva te ayuda a triunfar. Piensa bien, para vivir mejor"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>

        <div class="esp_botones">
            <asp:Button ID="btnCancelar" runat="server" Text="Continuar" CssClass="btn2" OnClick="btnCancelar_Click" />
        </div>


    </asp:Panel>



</asp:Content>

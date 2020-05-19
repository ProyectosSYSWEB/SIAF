using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Data;
using System.Web.UI;
using CapaEntidad;
using CapaDatos;


namespace CapaNegocio
{
    public class CN_Poliza
    {
        public void PolizaConsultaGrid(ref Poliza ObjPoliza, String FechaInicial, String FechaFinal, String Buscar, String TipoUsu, ref List<Poliza> List)
        {
            try
            {
                CD_Poliza CDPoliza = new CD_Poliza();
                CDPoliza.PolizaConsultaGrid(ref ObjPoliza, FechaInicial, FechaFinal, Buscar, TipoUsu, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarPolizaSel(ref Poliza ObjPoliza, ref string Verificador)
        {
            try
            {
                CD_Poliza CDPoliza = new CD_Poliza();
                CDPoliza.ConsultarPolizaSel(ref ObjPoliza, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void PolizaInsertar(ref Poliza ObjPoliza, ref string Verificador)
        {
            try
            {
                CD_Poliza CDPoliza = new CD_Poliza();
                CDPoliza.PolizaInsertar(ref ObjPoliza,ref Verificador);                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void PolizaEditar(ref Poliza ObjPoliza, ref string Verificador)
        {
            try
            {
                CD_Poliza CDPoliza = new CD_Poliza();
                CDPoliza.PolizaEditar(ref ObjPoliza, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void PolizaEliminar(Poliza ObjPoliza, ref string Verificador)
        {
            try
            {
                CD_Poliza CDPoliza = new CD_Poliza();
                CDPoliza.PolizaEliminar(ObjPoliza, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void PolizaEliminarRegistro(Poliza ObjPoliza, ref string Verificador)
        {
            try
            {
                CD_Poliza CDPoliza = new CD_Poliza();
                CDPoliza.PolizaEliminarRegistro(ObjPoliza, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void PolizaCopiar(ref Poliza ObjPoliza, ref string Verificador)
        {
            try
            {
                CD_Poliza CDPoliza = new CD_Poliza();
                CDPoliza.PolizaCopiar(ref ObjPoliza, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class CN_CentrosContab
    {
        public void CContabGrid(ref CentrosContab objCentrosContab, ref List<CentrosContab> List)
        {
            try
            {
                CD_CentrosContab CD_CentrosContab = new CD_CentrosContab();
                CD_CentrosContab.CContabGrid(ref objCentrosContab, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void InsertarCentroContable(ref CentrosContab objCentrosContab, ref string Verificador)
        {
            try
            {
                CD_CentrosContab CD_CentrosContab = new CD_CentrosContab();
                CD_CentrosContab.InsertarCentroContable(ref objCentrosContab, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ObtenerDatosCContab(ref CentrosContab objCContab, ref string Verificador)
        {
            try
            {
                CD_CentrosContab CD_CentrosContab = new CD_CentrosContab();
                CD_CentrosContab.ObtenerDatosCContab(ref objCContab, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EditarCContab(ref CentrosContab objCContab, ref string Verificador)
        {
            try
            {
                CD_CentrosContab CD_CentrosContab = new CD_CentrosContab();
                CD_CentrosContab.EditarCContab(ref objCContab, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EliminarCContab( CentrosContab objCContab, ref string Verificador)
        {
            try
            {
                CD_CentrosContab CD_CentrosContab = new CD_CentrosContab();
                CD_CentrosContab.EliminarCContab(objCContab, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

//=========================CONTROL CIERRE DE LOS CENTROS CONTABLES=====================

        public void Control_CierreConsultaGrid(ref CentrosContab ObjControl_Cierre, ref List<CentrosContab> List)
        {
            try
            {

                CD_CentrosContab CDCentros_Contables = new CD_CentrosContab();
                CDCentros_Contables.Control_CierreConsultaGrid(ref ObjControl_Cierre, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Control_CierreEditar(ref CentrosContab ObjCentros_Contables, ref string Verificador)
        {
            CD_CentrosContab CDCentros_Contables = new CD_CentrosContab();
            CDCentros_Contables.Control_CierreEditar(ref ObjCentros_Contables, ref Verificador);
        }
        public void Control_CierreGral(ref CentrosContab ObjControl_Cierre, string Tipo, ref string Verificador)
        {
            CD_CentrosContab CDControl_Cierre = new CD_CentrosContab();
            CDControl_Cierre.Control_CierreGral(ref ObjControl_Cierre, Tipo, ref Verificador);
        }
    }
}

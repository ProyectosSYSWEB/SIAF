using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Pres_Plantilla
    {
        public void ConsultaGrid_Plantilla(ref Pres_Plantilla objPlantilla, ref List<Pres_Plantilla> List)
        {
            try
            {
                CD_Pres_Plantilla CDPlantilla = new CD_Pres_Plantilla();
                CDPlantilla.ConsultaGrid_Plantilla(ref objPlantilla, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultaGrid_Historico(ref Pres_Plantilla objPlantilla, ref List<Pres_Plantilla> List)
        {
            try
            {
                CD_Pres_Plantilla CDPlantilla = new CD_Pres_Plantilla();
                CDPlantilla.ConsultaGrid_Historico(ref objPlantilla, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultaGrid_Otr(ref Pres_Plantilla objPlantilla, ref List<Pres_Plantilla> List)
        {
            try
            {
                CD_Pres_Plantilla CDPlantilla = new CD_Pres_Plantilla();
                CDPlantilla.ConsultaGrid_Otr(ref objPlantilla, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultaGrid_New_Semestre(ref Pres_Plantilla objPlantilla, ref List<Pres_Plantilla> List)
        {
            try
            {
                CD_Pres_Plantilla CDPlantilla = new CD_Pres_Plantilla();
                CDPlantilla.ConsultaGrid_New_Semestre(ref objPlantilla, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Consultar_Plantilla(ref Pres_Plantilla objPlantilla, ref string Verificador)
        {
            try
            {
                CD_Pres_Plantilla CDPlantilla = new CD_Pres_Plantilla();
                CDPlantilla.Consultar_Plantilla(ref objPlantilla, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete_Plantilla(ref Pres_Plantilla objPlantilla, ref string Verificador)
        {
            try
            {
                CD_Pres_Plantilla CDPlantilla = new CD_Pres_Plantilla();
                CDPlantilla.Delete_Plantilla(ref objPlantilla, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete_OTR(ref Pres_Plantilla objPlantilla, ref string Verificador)
        {
            try
            {
                CD_Pres_Plantilla CDPlantilla = new CD_Pres_Plantilla();
                CDPlantilla.Delete_OTR(ref objPlantilla, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ins_otro_posterior(ref Pres_Plantilla objPlantilla, ref string Verificador)
        {
            try
            {
                CD_Pres_Plantilla CDPlantilla = new CD_Pres_Plantilla();
                CDPlantilla.ins_otro_posterior(ref objPlantilla, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Insertar_DPP_Otr(ref Pres_Plantilla objplantilla, ref string Verificador)
        {
            try
            {
                CD_Pres_Plantilla CDPlantillas = new CD_Pres_Plantilla();
                CDPlantillas.Insertar_DPP_Otr(ref objplantilla, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Sel_Valida_Cierre(ref Pres_Plantilla objplantilla, ref string Verificador)
        {
            try
            {
                CD_Pres_Plantilla CDPlantillas = new CD_Pres_Plantilla();
                CDPlantillas.Sel_Valida_Cierre(ref objplantilla, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void cerrar_plantilla(ref Pres_Plantilla objplantilla, ref string Verificador)
        {
            try
            {
                CD_Pres_Plantilla CDPlantillas = new CD_Pres_Plantilla();
                CDPlantillas.cerrar_plantilla(ref objplantilla, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Insertar_Plantilla(ref Pres_Plantilla objplantilla, ref string Verificador)
        {
            try
            {
                CD_Pres_Plantilla CDPlantillas = new CD_Pres_Plantilla();
                CDPlantillas.Insertar_Plantilla(ref objplantilla, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update_Plantilla(ref Pres_Plantilla objplantilla, ref string Verificador)
        {
            try
            {

                CD_Pres_Plantilla CDPlantillas = new CD_Pres_Plantilla();
                CDPlantillas.Update_Plantilla(ref objplantilla, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Insertar_New_Plantilla (ref Pres_Plantilla objplantilla, ref string Verificador)
        {
            try
            {
                CD_Pres_Plantilla CDPlantillas = new CD_Pres_Plantilla();
                CDPlantillas.Insertar_New_Plantilla(ref objplantilla, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultaGrid_cierre_dep(ref Pres_Plantilla objPlantilla, ref List<Pres_Plantilla> List)
        {
            try
            {
                CD_Pres_Plantilla CDPlantilla = new CD_Pres_Plantilla();
                CDPlantilla.ConsultaGrid_cierre_dep(ref objPlantilla, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultaGrid_Monitor(ref Pres_Plantilla objPlantilla, ref List<Pres_Plantilla> List)
        {
            try
            {
                CD_Pres_Plantilla CDPlantilla = new CD_Pres_Plantilla();
                CDPlantilla.ConsultaGrid_Monitor(ref objPlantilla, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

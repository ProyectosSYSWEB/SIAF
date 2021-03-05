using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Presupuesto
    {
        public void PresupuestoConsultaGrid(ref Presupues ObjPresupuesto, ref List<Presupues> List)
        {
            try
            {
                CD_Presupuesto DatosPresupuesto = new CD_Presupuesto();
                DatosPresupuesto.PresupuestoConsultaGrid(ref ObjPresupuesto, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertarEstructuraProg(Presupues ObjPresupuesto, ref string Verificador)
        {
            try
            {
                CD_Presupuesto DatosPresupuesto = new CD_Presupuesto();
                DatosPresupuesto.InsertarEstructuraProgramatica(ObjPresupuesto, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

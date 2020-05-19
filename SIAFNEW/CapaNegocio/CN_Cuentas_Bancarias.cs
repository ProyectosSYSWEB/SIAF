using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Cuentas_Bancarias
    {
        public void Cuentas_BancariasConsultaGrid(ref Cuentas_Bancarias ObjCuentas_Bancarias, ref List<Cuentas_Bancarias> List)
        {
            try
            {               
                CD_Cuentas_Bancarias CDCuentas_Bancarias = new CD_Cuentas_Bancarias();
                CDCuentas_Bancarias.Cuentas_BancariasConsultaGrid(ref ObjCuentas_Bancarias, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Cuentas_BancariasInsertar(Cuentas_Bancarias ObjCuentas_Bancarias, ref string Verificador)
        {
            try
            {
                CD_Cuentas_Bancarias CDCuentas_Bancarias = new CD_Cuentas_Bancarias();
                CDCuentas_Bancarias.Cuentas_BancariasInsertar(ObjCuentas_Bancarias, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Cuentas_BancariasEditar(Cuentas_Bancarias ObjCuentas_Bancarias, ref string Verificador)
        {
            try
            {
                CD_Cuentas_Bancarias CDCuentas_Bancarias = new CD_Cuentas_Bancarias();
                CDCuentas_Bancarias.Cuentas_BancariasEditar(ObjCuentas_Bancarias, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Cuentas_BancariasSelect(ref Cuentas_Bancarias ObjCuentas_Bancarias, ref string Verificador)
        {
            try
            {
                CD_Cuentas_Bancarias CDCuentas_Bancarias = new CD_Cuentas_Bancarias();
                CDCuentas_Bancarias.Cuentas_BancariasSelect(ref ObjCuentas_Bancarias, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

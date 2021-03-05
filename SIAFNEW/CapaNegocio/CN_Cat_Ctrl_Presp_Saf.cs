using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class CN_Cat_Ctrl_Presp_Saf
    {
        public void ObtenerDatosCodProg(string Id, ref Cat_Ctrl_Presp_Saf objCodProg, ref string Verificador)
        {
            try
            {
                CD_Cat_Ctrl_Presp_Saf CD_Cat_Pres = new CD_Cat_Ctrl_Presp_Saf();
                CD_Cat_Pres.ObtenerDatosCodProg(Id, ref objCodProg, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertarCodigoProg(Cat_Ctrl_Presp_Saf objCodProg, ref string Verificador)
        {
            try
            {
                CD_Cat_Ctrl_Presp_Saf CD_Cat_Pres = new CD_Cat_Ctrl_Presp_Saf();
                CD_Cat_Pres.InsertarCodigoProg(objCodProg, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
    }
}

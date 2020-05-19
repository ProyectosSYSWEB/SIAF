using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public  class CN_Titulares
    {
        public void ConsultarTitulares(ref Titulares ObjTitulares, string buscar, ref List<Titulares> List)
        {
            try
            {

                CD_Titulares CDTitulares = new CD_Titulares();
                CDTitulares.ConsultarTitulares(ref ObjTitulares, buscar, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void update_Titulares(ref Titulares objTitulares, ref string Verificador)
        {
            try
            {

                CD_Titulares CDinformativa = new CD_Titulares();
                CDinformativa.update_Titulares(ref objTitulares, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

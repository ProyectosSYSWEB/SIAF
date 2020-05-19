using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Usuario
    {
        public void ValidarUsuario(ref Usuario Usuario, ref string Verificador)
        {
            CD_Usuario CD_Usuario = new CD_Usuario();
            CD_Usuario.ValidarUsuario(ref Usuario, ref Verificador);
        }

        public void ObtenerUsuario(ref CapaEntidad.Usuario Usuario, ref string Verificador)
        {
            try
            {
                CapaDatos.CD_Usuario CD_Usuario = new CapaDatos.CD_Usuario();
                CD_Usuario.ObtenerUsuario(ref Usuario, ref Verificador);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void ValidarToken(ref CapaEntidad.Usuario Usuario, ref string Verificador)
        {
            try
            {
                CapaDatos.CD_Usuario CD_Usuario = new CapaDatos.CD_Usuario();
                CD_Usuario.ValidarToken(ref Usuario, ref Verificador);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Inserta_Token(ref Usuario objBasicos, ref string Verificador)
        {
            try
            {
                CD_Usuario CD_Usuario = new CD_Usuario();
                CD_Usuario.Inserta_Token(ref objBasicos, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Verificar_Correo_UNACH(ref Usuario objUsuario, ref string Verificador)
        {
            try
            {
                CD_Usuario CDUsuario = new CD_Usuario();
                CDUsuario.Verificar_Correo_UNACH(ref objUsuario, ref Verificador);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }



    }
}

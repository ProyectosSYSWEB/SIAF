﻿using System;
using CapaDatos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Adecuaciones
    {
        public void CapitulosGrid(Adecuaciones objAdecuacion, ref List<Adecuaciones> List)
        {
            try
            {
                CD_Adecuaciones CD_Adecuaciones = new CD_Adecuaciones();
                CD_Adecuaciones.AdecuacionesGrid(objAdecuacion, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ObtenerDatosCogidoAdecuaciones(ref Adecuaciones objAdecuacion, ref string Verificador)
        {
            try
            {
                CD_Adecuaciones CD_Adecuaciones = new CD_Adecuaciones();
                CD_Adecuaciones.ObtenerDatosCogidoAdecuaciones(ref objAdecuacion, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertarDocumentoAdecuacion(List<Adecuaciones> List, Adecuaciones objAdecuaciones, ref string Verificador)
        {
            try
            {
                CD_Adecuaciones CD_Adecuaciones = new CD_Adecuaciones();
                CD_Adecuaciones.InsertarDocumentoAdecuacion(List, objAdecuaciones, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

﻿using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class CN_Consultas
    {
        public void PolizaConsultaGrid( Consultas objConsultas, ref List<Consultas> List)
        {
            try
            {
                CD_Consultas CD_Consultas = new CD_Consultas();
                CD_Consultas.ConsultaCodProgGrid( objConsultas, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ConsultaDetalleDocumento(ref Consultas objConsultas, ref List<Consultas> List)
        {
            try
            {
                CD_Consultas CD_Consultas = new CD_Consultas();
                CD_Consultas.ConsultaDetalleDocumento(ref objConsultas, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

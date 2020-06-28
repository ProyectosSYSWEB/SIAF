﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Pres_Reportes
    {
        public void ConsultaGrid_Fuente_F(ref Pres_Reportes objReporte, ref List<Pres_Reportes> List)
        {
            try
            {
                CD_Pres_Reportes CDReportes = new CD_Pres_Reportes();
                CDReportes.ConsultaGrid_Fuente_F(ref objReporte, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultaGrid_Capitulo(ref Pres_Reportes objReporte, ref List<Pres_Reportes> List)
        {
            try
            {
                CD_Pres_Reportes CDReportes = new CD_Pres_Reportes();
                CDReportes.ConsultaGrid_Capitulo(ref objReporte, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultaGrid_Subprograma(ref Pres_Reportes objReporte, ref List<Pres_Reportes> List)
        {
            try
            {
                CD_Pres_Reportes CDReportes = new CD_Pres_Reportes();
                CDReportes.ConsultaGrid_Subprograma(ref objReporte, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarGrid_RP008(ref Pres_Reportes objReporte, ref List<Pres_Reportes> List,int Grid)
        {
            try
            {
                CD_Pres_Reportes CDReportes = new CD_Pres_Reportes();
                CDReportes.ConsultarGrid_RP008(ref objReporte, ref List, Grid);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

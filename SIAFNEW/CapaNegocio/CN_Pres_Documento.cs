using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
   public class CN_Pres_Documento
    {
        public void ConsultaGrid_Documentos(ref Pres_Documento objDocumento, ref List<Pres_Documento> List)
        {
            try
            {
                CD_Pres_Documento CDDocumento = new CD_Pres_Documento();
                CDDocumento.ConsultaGrid_Documentos(ref objDocumento, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarDocumentoSel(ref Pres_Documento objDocumento, ref string Verificador)
        {
            try
            {
                CD_Pres_Documento CDDocumento = new CD_Pres_Documento();
                CDDocumento.ConsultarDocumentoSel(ref objDocumento, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void InsertaDocumentoEncabezado(ref Pres_Documento objdocumento, ref string Verificador)
        {
            try
            {
                CD_Pres_Documento CDDocumento = new CD_Pres_Documento();
                CDDocumento.InsertaDocumentoEncabezado(ref objdocumento, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EditarDocumentoEncabezado(Pres_Documento objdocumento, ref string Verificador)
        {
            try
            {
                CD_Pres_Documento CDDocumento = new CD_Pres_Documento();
                CDDocumento.EditarDocumentoEncabezado(objdocumento, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EliminarDocumentoEncabezado(Pres_Documento objdocumento, ref string Verificador)
        {
            try
            {
                CD_Pres_Documento CDDocumento = new CD_Pres_Documento();
                CDDocumento.EliminarDocumentoEncabezado(objdocumento, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

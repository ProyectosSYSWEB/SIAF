using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Poliza_Conciliacion
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private int _Ejercicio;
        public int Ejercicio
        {
            get { return _Ejercicio; }
            set { _Ejercicio = value; }
        }

        private int _Centro_contable;
        public int Centro_contable
        {
            get { return _Centro_contable; }
            set { _Centro_contable = value; }
        }

        private string _Tipo;
        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        private string _DescTipo;
        public string DescTipo
        {
            get { return _DescTipo; }
            set { _DescTipo = value; }
        }

        private double _Importe;
        public double Importe
        {
            get { return _Importe; }
            set { _Importe = value; }
        }

        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private string _Concepto=string.Empty;
        public string Concepto
        {
            get { return _Concepto; }
            set { _Concepto = value; }
        }

        private string _Observaciones=string.Empty;
        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

        private string _Numero_Poliza="0";
        public string Numero_Poliza
        {
            get { return _Numero_Poliza; }
            set { _Numero_Poliza = value; }
        }

        private string _Numero_Cheque = "0";
        public string Numero_Cheque
        {
            get { return _Numero_Cheque; }
            set { _Numero_Cheque = value; }
        }

        private int _Cuenta_contable;
        public int Cuenta_contable
        {
            get { return _Cuenta_contable; }
            set { _Cuenta_contable = value; }
        }

        private string _Desc_Cuenta_Contable;
        public string Desc_Cuenta_Contable
        {
            get { return _Desc_Cuenta_Contable; }
            set { _Desc_Cuenta_Contable = value; }
        }


        private string _Fecha_inicial;
        public string Fecha_inicial
        {
            get { return _Fecha_inicial; }
            set { _Fecha_inicial = value; }
        }

        private string _Fecha_final;
        public string Fecha_final
        {
            get { return _Fecha_final; }
            set { _Fecha_final = value; }
        }

        private string _Fecha;
        public string Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private string _Elaboro_nombre;
        public string Elaboro_nombre
        {
            get { return _Elaboro_nombre; }
            set { _Elaboro_nombre = value; }
        }

        private string _Elaboro_puesto;
        public string Elaboro_puesto
        {
            get { return _Elaboro_puesto; }
            set { _Elaboro_puesto = value; }
        }

        private string _Vb_nombre;
        public string Vb_nombre
        {
            get { return _Vb_nombre; }
            set { _Vb_nombre = value; }
        }

        private string _Vb_puesto;
        public string Vb_puesto
        {
            get { return _Vb_puesto; }
            set { _Vb_puesto = value; }
        }

        private string _Nombre_archivo;
        public string Nombre_archivo
        {
            get { return _Nombre_archivo; }
            set { _Nombre_archivo = value; }
        }

        private string _Cuenta_Cheques;
        public string Cuenta_Cheques
        {
            get { return _Cuenta_Cheques; }
            set { _Cuenta_Cheques = value; }
        }


        private string _NumeroPoliza;
        public string NumeroPoliza
        {
            get { return _NumeroPoliza; }
            set { _NumeroPoliza = value; }
        }

        private int _IdPoliza;
        public int IdPoliza
        {
            get { return _IdPoliza; }
            set { _IdPoliza = value; }
        }

        private int _IdEnc;
        public int IdEnc
        {
            get { return _IdEnc; }
            set { _IdEnc = value; }
        }

        private int _IdPolizaDet;
        public int IdPolizaDet
        {
            get { return _IdPolizaDet; }
            set { _IdPolizaDet = value; }
        }

        private int _OrdenTipo;
        public int OrdenTipo
        {
            get { return _OrdenTipo; }
            set { _OrdenTipo = value; }
        }

        private string _CveTipo;
        public string CveTipo
        {
            get { return _CveTipo; }
            set { _CveTipo = value; }
        }

        //public List<Poliza_Conciliacion_Det> Poliza_Conciliacion_Det { get; set; }
        //public Poliza_Conciliacion_Adj Poliza_Conciliacion_Adj { get; set; }
        private string _NombreArchivoPDF = string.Empty;
        public string NombreArchivoPDF
        {
            get { return _NombreArchivoPDF.Trim(); }
            set { _NombreArchivoPDF = value.Trim(); }
        }

        private string _Ruta_PDF = string.Empty;
        public string Ruta_PDF
        {
            get { return _Ruta_PDF.Trim(); }
            set { _Ruta_PDF = value.Trim(); }
        }


    }
    //public class Poliza_Conciliacion_Det
    //{

    //    private int _Id;
    //    public int Id
    //    {
    //        get { return _Id; }
    //        set { _Id = value; }
    //    }

    //    private int _Id_Conciliacion;
    //    public int Id_Conciliacion
    //    {
    //        get { return _Id_Conciliacion; }
    //        set { _Id_Conciliacion = value; }
    //    }

    //    private int _Id_Poliza_Det;
    //    public int Id_Poliza_Det
    //    {
    //        get { return _Id_Poliza_Det; }
    //        set { _Id_Poliza_Det = value; }
    //    }

    //    private double _Importe;
    //    public double Importe
    //    {
    //        get { return _Importe; }
    //        set { _Importe = value; }
    //    }

    //}
    //public class Poliza_Conciliacion_Adj
    //{
    //    private string _NombreArchivoPDF = string.Empty;
    //    public string NombreArchivoPDF
    //    {
    //        get { return _NombreArchivoPDF.Trim(); }
    //        set { _NombreArchivoPDF = value.Trim(); }
    //    }

    //    private string _Ruta_PDF = string.Empty;
    //    public string Ruta_PDF
    //    {
    //        get { return _Ruta_PDF.Trim(); }
    //        set { _Ruta_PDF = value.Trim(); }
    //    }
    //}
}

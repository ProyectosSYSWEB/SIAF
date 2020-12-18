using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
   public class Pres_Documento
    {
        private int _Id;
        private string _Dependencia;
        private string _SuperTipo;
        private string _Tipo;
        private string _No_Documento;
        private string _Fecha;
        private string _Status;
        private string _Concepto;
        private double _Origen;
        private double _Destino;
        private string _Usuario;
        private string _P_Buscar;
        private string _Fecha_Inicial;
        private string _Fecha_Final;
        private string _Editor;
        private string _Folio;
        private string _Descripcion;
        private string _MotivoRechazo;
        private string _MotivoAutorizacion;
        private string _Cuenta;
        private string _NumeroCheque;
        private string _CedulaComprometido;
        private string _CedulaDevengado;
        private string _CedulaEjercido;
        private string _CedulaPagado;
        private string _PolizaComprometido;
        private string _PolizaEjercido;
        private string _PolizaPagado;
        private string _ClaveCuenta;
        private string _ClaveEvento;
        private string _KeyDocumento;
        private string _KeyPoliza;
        private string _KeyPoliza811;
        private string _Regulariza;
        private string _GeneracionSimultanea;
        private string _CentroContable;
        private string _MesAnio;
        private string _TipoCaptura;
        private string _Ejercicios;
        private string _Contabilizar;
        private string _PolizaDevengado;
        private string _ISR;
        private double _Importe_Cheque;
        private double _Importe_Operacion;



        private bool _Opcion_Eliminar;
        private bool _Opcion_Eliminar2;
        private bool _Opcion_Modificar;
        private bool _Opcion_Modificar2;
        private bool _Opcion_Copiar;
        private bool _Opcion_Copiar2;


        public double Importe_Operacion
        {
            get { return _Importe_Operacion; }
            set { _Importe_Operacion = value; }
        }
        public double Importe_Cheque
        {
            get { return _Importe_Cheque; }
            set { _Importe_Cheque = value; }
        }
        public string ISR
        {
            get { return _ISR; }
            set { _ISR = value; }
        }
        public string PolizaDevengado
        {
            get { return _PolizaDevengado; }
            set { _PolizaDevengado = value; }
        }
        public string Contabilizar
        {
            get { return _Contabilizar; }
            set { _Contabilizar = value; }
        }
        public string Ejercicios
        {
            get { return _Ejercicios; }
            set { _Ejercicios = value; }
        }
        public string TipoCaptura
        {
            get { return _TipoCaptura; }
            set { _TipoCaptura = value; }
        }
        public string MesAnio
        {
            get { return _MesAnio; }
            set { _MesAnio = value; }
        }
        public string CentroContable
        {
            get { return _CentroContable; }
            set { _CentroContable = value; }
        }
        public string GeneracionSimultanea
        {
            get { return _GeneracionSimultanea; }
            set { _GeneracionSimultanea = value; }
        }
        public string Regulariza
        {
            get { return _Regulariza; }
            set { _Regulariza = value; }
        }
        public string KeyPoliza811
        {
            get { return _KeyPoliza811; }
            set { _KeyPoliza811 = value; }
        }
        public string KeyPoliza
        {
            get { return _KeyPoliza; }
            set { _KeyPoliza = value; }
        }
        public string KeyDocumento
        {
            get { return _KeyDocumento; }
            set { _KeyDocumento = value; }
        }
        public string ClaveEvento
        {
            get { return _ClaveEvento; }
            set { _ClaveEvento = value; }
        }
        public string ClaveCuenta
        {
            get { return _ClaveCuenta; }
            set { _ClaveCuenta = value; }
        }
        public string PolizaPagado
        {
            get { return _PolizaPagado; }
            set { _PolizaPagado = value; }
        }
        public string PolizaEjercido
        {
            get { return _PolizaEjercido; }
            set { _PolizaEjercido = value; }
        }
        public string PolizaComprometida
        {
            get { return _PolizaComprometido; }
            set { _PolizaComprometido = value; }
        }
        public string CedulaPagado
        {
            get { return _CedulaPagado; }
            set { _CedulaPagado = value; }
        }
        public string CedulaDevengado
        {
            get { return _CedulaDevengado; }
            set { _CedulaDevengado = value; }
        }
        public string CedulaEjercido
        {
            get { return _CedulaEjercido; }
            set { _CedulaEjercido = value; }
        }
        public string CedulaComprometido
        {
            get { return _CedulaComprometido; }
            set { _CedulaComprometido = value; }
        }
        public string NumeroCheque
        {
            get { return _NumeroCheque; }
            set { _NumeroCheque = value; }
        }
        public string Cuenta
        {
            get { return _Cuenta; }
            set { _Cuenta = value; }
        }
        public string MotivoAutorizacion
        {
            get { return _MotivoAutorizacion; }
            set { _MotivoAutorizacion = value; }
        }
        public string MotivoRechazo
        {
            get { return _MotivoRechazo; }
            set { _MotivoRechazo = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public string Folio
        {
            get { return _Folio; }
            set { _Folio = value; }
        }
        public string Editor
        {
            get { return _Editor; }
            set { _Editor = value; }
        }
        public string Fecha_Final
        {
            get { return _Fecha_Final; }
            set { _Fecha_Final = value; }
        }
        public string Fecha_Inicial
        {
            get { return _Fecha_Inicial; }
            set { _Fecha_Inicial = value; }
        }
        public string P_Buscar
        {
            get { return _P_Buscar; }
            set { _P_Buscar = value; }
        }
        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public string Dependencia
        {
            get { return _Dependencia; }
            set { _Dependencia = value; }
        }
        public string SuperTipo
        {
            get { return _SuperTipo; }
            set { _SuperTipo = value; }
        }
        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }
        public string No_documento
        {
            get { return _No_Documento; }
            set { _No_Documento = value; }
        }
        public string Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        public string Concepto
        {
            get { return _Concepto; }
            set { _Concepto = value; }
        }
        public double Origen
        {
            get { return _Origen; }
            set { _Origen = value; }
        }
        public double Destino
        {
            get { return _Destino; }
            set { _Destino = value; }
        }
        public bool Opcion_Eliminar
        {
            get { return _Opcion_Eliminar; }
            set { _Opcion_Eliminar = value; }
        }
        public bool Opcion_Eliminar2
        {
            get { return _Opcion_Eliminar2; }
            set { _Opcion_Eliminar2 = value; }
        }
        public bool Opcion_Modificar
        {
            get { return _Opcion_Modificar; }
            set { _Opcion_Modificar = value; }
        }
        public bool Opcion_Modificar2
        {
            get { return _Opcion_Modificar2; }
            set { _Opcion_Modificar2 = value; }
        }
        public bool Opcion_Copiar
        {
            get { return _Opcion_Copiar; }
            set { _Opcion_Copiar = value; }
        }
        public bool Opcion_Copiar2
        {
            get { return _Opcion_Copiar2; }
            set { _Opcion_Copiar2 = value; }
        }
    }
}

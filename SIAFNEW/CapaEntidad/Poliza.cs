using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Poliza
    {
        private int _IdPoliza;
        private int _Ejercicio;
        private string _Numero_poliza;
        private string _Centro_contable;
        private string _Tipo;
        private string _Subsistema;
        private string _Concepto;
        private string _Fecha;
        private string _Mes_anio;
        private string _Status;
        private string _Tipo_captura;
        private string _Key_poliza;
        private string _Key_adecuacion;
        private string _Cheque_cuenta;
        private string _Cheque_numero;
        private string _Cedula_numero;
        private string _Beneficiario;
        private string _Alta_fecha;
        private string _Alta_usuario;
        private string _Modificacion_fecha;
        private string _Modificacion_usuario;
        private string _CFDI;
        private bool   _Opcion_Eliminar;
        private bool _Opcion_Eliminar2;
        private bool _Opcion_Modificar;
        private bool _Opcion_Modificar2;
        private bool _Opcion_Copiar;
        private bool _Opcion_Copiar2;
        private double _Cheque_importe;
        private double _Tot_Cargo;
        private double _Tot_Abono;
        private bool _Opcion_CFDI;
        private bool _Opcion_CFDI2;
        private bool _Tiene_CFDI;
        private int _Total_CFDI;
        public bool Opcion_CFDI
        {
            get { return _Opcion_CFDI; }
            set { _Opcion_CFDI = value; }
        }

        public bool Opcion_CFDI2
        {
            get { return _Opcion_CFDI2; }
            set { _Opcion_CFDI2 = value; }
        }

        public int IdPoliza
        {
            get { return _IdPoliza; }
            set { _IdPoliza = value; }
        }
        public int Ejercicio
        {
            get { return _Ejercicio; }
            set { _Ejercicio = value; }
        }
        public string Numero_poliza
        {
            get { return _Numero_poliza.Trim(); }
            set { _Numero_poliza = value.Trim(); }
        }
        public string Centro_contable
        {
            get { return _Centro_contable.Trim(); }
            set { _Centro_contable = value.Trim(); }
        }
        public string Tipo
        {
            get { return _Tipo.Trim(); }
            set { _Tipo = value.Trim(); }
        }
        public string Subsistema
        {
            get { return _Subsistema.Trim(); }
            set { _Subsistema = value.Trim(); }
        }
        public string Concepto
        {
            get { return _Concepto.Trim(); }
            set { _Concepto = value.Trim(); }
        }
        public string Fecha
        {
            get { return _Fecha.Trim(); }
            set { _Fecha = value.Trim(); }
        }
        public string Mes_anio
        {
            get { return _Mes_anio.Trim(); }
            set { _Mes_anio = value.Trim(); }
        }
        public string Status
        {
            get { return _Status.Trim(); }
            set { _Status = value.Trim(); }
        }
        public string Tipo_captura
        {
            get { return _Tipo_captura.Trim(); }
            set { _Tipo_captura = value.Trim(); }
        }
        public string Key_poliza
        {
            get { return _Key_poliza.Trim(); }
            set { _Key_poliza = value.Trim(); }
        }
        public string Key_adecuacion
        {
            get { return _Key_adecuacion.Trim(); }
            set { _Key_adecuacion = value.Trim(); }
        }
        public string Cheque_cuenta
        {
            get { return _Cheque_cuenta.Trim(); }
            set { _Cheque_cuenta = value.Trim(); }
        }
        public string Cheque_numero
        {
            get { return _Cheque_numero.Trim(); }
            set { _Cheque_numero = value.Trim(); }
        }
        public string Cedula_numero
        {
            get { return _Cedula_numero.Trim(); }
            set { _Cedula_numero = value.Trim(); }
        }
        public string Beneficiario
        {
            get { return _Beneficiario.Trim(); }
            set { _Beneficiario = value.Trim(); }
        }
        public string Alta_fecha
        {
            get { return _Alta_fecha.Trim(); }
            set { _Alta_fecha = value.Trim(); }
        }
        public string Alta_usuario
        {
            get { return _Alta_usuario.Trim(); }
            set { _Alta_usuario = value.Trim(); }
        }
        public string Modificacion_fecha
        {
            get { return _Modificacion_fecha.Trim(); }
            set { _Modificacion_fecha = value.Trim(); }
        }
        public string Modificacion_usuario
        {
            get { return _Modificacion_usuario.Trim(); }
            set { _Modificacion_usuario = value.Trim(); }
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
        public double Cheque_importe
        {
            get { return _Cheque_importe; }
            set { _Cheque_importe = value; }
        }
        public double Tot_Cargo
        {
            get { return _Tot_Cargo; }
            set { _Tot_Cargo = value; }
        }
        public double Tot_Abono
        {
            get { return _Tot_Abono; }
            set { _Tot_Abono = value; }
        }
        public string CFDI
        {
            get { return _CFDI.Trim(); }
            set { _CFDI = value.Trim(); }
        }

        public bool Tiene_CFDI
        {
            get { return _Tiene_CFDI; }
            set { _Tiene_CFDI = value; }
        }

        public int Total_CFDI
        {
            get { return _Total_CFDI; }
            set { _Total_CFDI = value; }
        }
    }
}

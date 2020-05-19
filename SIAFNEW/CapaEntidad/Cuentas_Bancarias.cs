using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Cuentas_Bancarias
    {
        private int _IdCuenta_Bancaria;
        public int IdCuenta_Bancaria
        {
            get { return _IdCuenta_Bancaria; }
            set { _IdCuenta_Bancaria = value; }
        }

        private int _Ejercicio;
        public int Ejercicio
        {
            get { return _Ejercicio; }
            set { _Ejercicio = value; }
        }

        private string _Clave;
        public string Clave
        {
            get { return _Clave; }
            set { _Clave = value; }
        }

        private string _Centro_Contable;
        public string Centro_Contable
        {
            get { return _Centro_Contable; }
            set { _Centro_Contable = value; }
        }

        private string _Dependencia;
        public string Dependencia
        {
            get { return _Dependencia; }
            set { _Dependencia = value; }
        }

        private string _Banco;
        public string Banco
        {
            get { return _Banco; }
            set { _Banco = value; }
        }

        private string _Cuenta_Bancaria;
        public string Cuenta_Bancaria
        {
            get { return _Cuenta_Bancaria; }
            set { _Cuenta_Bancaria = value; }
        }

        private string _Cuenta_Contable;
        public string Cuenta_Contable
        {
            get { return _Cuenta_Contable; }
            set { _Cuenta_Contable = value; }
        }

        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion.Trim();  }
            set { _Descripcion = value.Trim(); }
        }

        private string _Fecha_Apertura;
        public string Fecha_Apertura
        {
            get { return _Fecha_Apertura.Trim(); }
            set { _Fecha_Apertura = value.Trim(); }
        }

        private string _Localidad;
        public string Localidad
        {
            get { return _Localidad.Trim(); }
            set { _Localidad = value.Trim(); }
        }

        private char _Status;
        public char Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private string _Alta_Usuario;
        public string Alta_Usuario
        {
            get { return _Alta_Usuario.Trim(); }
            set { _Alta_Usuario = value.Trim(); }
        }

        private string _Alta_Fecha;
        public string Alta_Fecha
        {
            get { return _Alta_Fecha.Trim(); }
            set { _Alta_Fecha = value.Trim(); }
        }


    }
}

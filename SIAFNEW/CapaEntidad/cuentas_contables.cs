using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
   public class cuentas_contables
    {
        private string _numero_poliza;

        public string numero_poliza
        {
            get { return _numero_poliza; }
            set { _numero_poliza = value; }
        }
        private double _Tot_Abono;

        public double Tot_Abono
        {
            get { return _Tot_Abono; }
            set { _Tot_Abono = value; }
        }
        private double _Tot_Cargo;

        public double Tot_Cargo
        {
            get { return _Tot_Cargo; }
            set { _Tot_Cargo = value; }
        }
        private string _concepto;

        public string concepto
        {
            get { return _concepto; }
            set { _concepto = value; }
        }
        private string _fecha;

        public string fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        
        private int _IdPoliza;

        public int IdPoliza
        {
            get { return _IdPoliza; }
            set { _IdPoliza = value; }
        }
        private string _ejercicio;

        public string ejercicio
        {
            get { return _ejercicio; }
            set { _ejercicio = value; }
        }
        private string _buscar;

        public string buscar
        {
            get { return _buscar; }
            set { _buscar = value; }
        }
        private string _observaciones;

        public string observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }
        private string _centro_contable;

        public string centro_contable
        {
            get { return _centro_contable; }
            set { _centro_contable = value; }
        }
        private string _cuenta_mayor;

        public string cuenta_mayor
        {
            get { return _cuenta_mayor; }
            set { _cuenta_mayor = value; }
        }
        private string _id;

        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _descripcion;

        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private string _natura;

        public string natura
        {
            get { return _natura; }
            set { _natura = value; }
        }
        private bool _bandera;

        public bool bandera
        {
            get { return _bandera; }
            set { _bandera = value; }
        }
        private string _nivel;

        public string nivel
        {
            get { return _nivel; }
            set { _nivel = value; }
        }
        private string _cuenta_contable;

        public string cuenta_contable
        {
            get { return _cuenta_contable; }
            set { _cuenta_contable = value; }
        }
        private string _tipo;

        public string tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        private string _clasificacion;

        public string clasificacion
        {
            get { return _clasificacion; }
            set { _clasificacion = value; }
        }
        private string _status;

        public string status
        {
            get { return _status; }
            set { _status = value; }
        }
        private string _usuario;

        public string usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        private string _fecha_inicial;

        public string fecha_inicial
        {
            get { return _fecha_inicial; }
            set { _fecha_inicial = value; }
        }
        private string _fecha_final;

        public string fecha_final
        {
            get { return _fecha_final; }
            set { _fecha_final = value; }
        } 
   }

}

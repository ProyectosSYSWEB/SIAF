using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Consultas
    {
        private string _Centro_Contable;
        private string _Dependencia;
        private string _Partida;
        private string _Fuente;
        private string _Proyecto;
        private string _Codigo_Programatico;
        private string _Capitulo;
        private string _Subcapitulo;
        private string _Mes;
        //private string _Autorizado;
        //private string _Aumento;
        //private string _Disminucion;
        //private string _Ejercido;
        //private string _Modificado;
        //private string _Comprometido;
        //private string _Ministrado;
        //private string _Devengado;
        //private string _Pagado;
        private double _Autorizado;
        private double _Aumento;
        private double _Disminucion;
        private double _Ejercido;
        private double _Modificado;
        private double _Comprometido;
        private double _Ministrado;
        private double _Devengado;
        private double _Pagado;
        private string _Supertipo;
        private string _Id;
        private string _Folio;
        private string _Tipo;
        private string _Fecha;
        private string _Status;
        private string _Importe_Origen;
        private string _Importe_Destino;
        private string _Importe_Mensual;
        private string _Mes_Inicial;
        private string _Mes_Final;
        private string _Tipo_Evento;
        private string _Ejercido_01;
        private string _Ejercido_02;
        private string _Ejercido_03;
        private string _Ejercido_04;
        private string _Ejercido_05;
        private string _Ejercido_06;
        private string _Ejercido_07;
        private string _Ejercido_08;
        private string _Ejercido_09;
        private string _Ejercido_10;
        private string _Ejercido_11;
        private string _Ejercido_12;
        private string _Ejercido_Suma;
        private string _DependenciaIni;
        private string _DependenciaFin;

        public string Centro_Contable
        {
            get { return _Centro_Contable; }
            set { _Centro_Contable = value; }
        }       
        public string Dependencia
        {
            get { return _Dependencia; }
            set { _Dependencia = value; }
        }              
        public string Partida
        {
            get { return _Partida; }
            set { _Partida = value; }
        }
        public string Fuente
        {
            get { return _Fuente; }
            set { _Fuente = value; }
        }
        public string Proyecto
        {
            get { return _Proyecto; }
            set { _Proyecto = value; }
        }
        public string Codigo_Programatico
        {
            get { return _Codigo_Programatico; }
            set { _Codigo_Programatico = value; }
        }      
        public string Capitulo
        {
            get { return _Capitulo; }
            set { _Capitulo = value; }
        }
        public string Subcapitulo
        {
            get { return _Subcapitulo; }
            set { _Subcapitulo = value; }
        }
        public string Mes
        {
            get { return _Mes; }
            set { _Mes = value; }
        }
        public double Autorizado
        {
            get { return _Autorizado; }
            set { _Autorizado = value; }
        }
        public double Aumento
        {
            get { return _Aumento; }
            set { _Aumento = value; }
        }
        public double Disminucion
        {
            get { return _Disminucion; }
            set { _Disminucion = value; }
        }
        public double Ejercido
        {
            get { return _Ejercido; }
            set { _Ejercido = value; }
        }
        public double Modificado
        {
            get { return _Modificado; }
            set { _Modificado = value; }
        }
        public double Ministrado
        {
            get { return _Ministrado; }
            set { _Ministrado = value; }
        }

        public double Comprometido
        {
            get { return _Comprometido; }
            set { _Comprometido = value; }
        }

        public double Devengado
        {
            get { return _Devengado; }
            set { _Devengado = value; }
        }

        public double Pagado
        {
            get { return _Pagado; }
            set { _Pagado = value; }
        }

        //public string Autorizado
        //{
        //    get { return _Autorizado; }
        //    set { _Autorizado = value; }
        //}
        //public string Aumento
        //{
        //    get { return _Aumento; }
        //    set { _Aumento = value; }
        //}
        //public string Disminucion
        //{
        //    get { return _Disminucion; }
        //    set { _Disminucion = value; }
        //}
        //public string Ejercido
        //{
        //    get { return _Ejercido; }
        //    set { _Ejercido = value; }
        //}
        //public string Modificado
        //{
        //    get { return _Modificado; }
        //    set { _Modificado = value; }
        //}
        //public string Ministrado
        //{
        //    get { return _Ministrado; }
        //    set { _Ministrado = value; }
        //}

        //public string Comprometido
        //{
        //    get { return _Comprometido; }
        //    set { _Comprometido = value; }
        //}

        //public string Devengado
        //{
        //    get { return _Devengado; }
        //    set { _Devengado = value; }
        //}

        //public string Pagado
        //{
        //    get { return _Pagado; }
        //    set { _Pagado = value; }
        //}

        private string _Ejercicio;

        public string Ejercicio
        {
            get { return _Ejercicio; }
            set { _Ejercicio = value; }
        }

       

        
        public string Supertipo
        {
            get { return _Supertipo; }
            set { _Supertipo = value; }
        }
        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public string Folio
        {
            get { return _Folio; }
            set { _Folio = value; }
        }
        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
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
        public string Importe_Origen
        {
            get { return _Importe_Origen; }
            set { _Importe_Origen = value; }
        }
        public string Importe_Destino
        {
            get { return _Importe_Destino; }
            set { _Importe_Destino = value; }
        }
        public string Importe_Mensual
        {
            get { return _Importe_Mensual; }
            set { _Importe_Mensual = value; }
        }
        public string Mes_Inicial
        {
            get { return _Mes_Inicial; }
            set { _Mes_Inicial = value; }
        }
        public string Mes_Final
        {
            get { return _Mes_Final; }
            set { _Mes_Final = value; }
        }

        public string Tipo_Evento
        {
            get { return _Tipo_Evento; }
            set { _Tipo_Evento = value; }
        }

        public string Ejercido_01
        {
            get { return _Ejercido_01; }
            set { _Ejercido_01 = value; }
        }
        public string Ejercido_02
        {
            get { return _Ejercido_02; }
            set { _Ejercido_02 = value; }
        }
        public string Ejercido_03
        {
            get { return _Ejercido_03; }
            set { _Ejercido_03 = value; }
        }
        public string Ejercido_04
        {
            get { return _Ejercido_04; }
            set { _Ejercido_04 = value; }
        }
        public string Ejercido_05
        {
            get { return _Ejercido_05; }
            set { _Ejercido_05 = value; }
        }
        public string Ejercido_06
        {
            get { return _Ejercido_06; }
            set { _Ejercido_06 = value; }
        }
        public string Ejercido_07
        {
            get { return _Ejercido_07; }
            set { _Ejercido_07 = value; }
        }
        public string Ejercido_08
        {
            get { return _Ejercido_08; }
            set { _Ejercido_08 = value; }
        }
        public string Ejercido_09
        {
            get { return _Ejercido_09; }
            set { _Ejercido_09 = value; }
        }
            public string Ejercido_10
        {
            get { return _Ejercido_10; }
            set { _Ejercido_10 = value; }
        }
        public string Ejercido_11
        {
            get { return _Ejercido_11; }
            set { _Ejercido_11 = value; }
        }
        public string Ejercido_12
        {
            get { return _Ejercido_12; }
            set { _Ejercido_12 = value; }
        }
        public string EjercidoSuma
        {
            get { return _Ejercido_Suma; }
            set { _Ejercido_Suma = value; }
        }
        public string DependenciaIni
        {
            get { return _DependenciaIni; }
            set { _DependenciaIni = value; }
        }
        public string DependenciaFin
        {
            get { return _DependenciaFin; }
            set { _DependenciaFin = value; }
        }
    }
}

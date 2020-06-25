using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public  class Pres_Nomina
    {
        private string _Buscar;
        private string _Nombre;
        private string _RFC;
        private string _Plaza;
        private string _Categoria;
        private string _Nomina;
        private string _Fecha_Ingreso;
        private string _Tipo_Personal;
        private string _Nomina_Ini;
        private string _Nomina_Fin;
        private string _Ejercicio;
        private string _Periodo;

        public string Periodo
        {
            get { return _Periodo; }
            set { _Periodo = value; }
        }
        public string Ejercicio
        {
            get { return _Ejercicio; }
            set { _Ejercicio = value; }
        }
        public string Nomina_Fin
        {
            get { return _Nomina_Fin; }
            set { _Nomina_Fin = value; }
        }
        public string Nomina_Ini
        {
            get { return _Nomina_Ini; }
            set { _Nomina_Ini = value; }
        }
        public string Tipo_Personal
        {
            get { return _Tipo_Personal; }
            set { _Tipo_Personal = value; }
        }
        public string Fecha_Ingreso
        {
            get { return _Fecha_Ingreso; }
            set { _Fecha_Ingreso = value; }
        }
        public string Nomina
        {
            get { return _Nomina; }
            set { _Nomina = value; }
        }
        public string Categoria
        {
            get { return _Categoria; }
            set { _Categoria = value; }
        }
        public string Plaza
        {
            get { return _Plaza; }
            set { _Plaza = value; }
        }
        public string RFC
        {
            get { return _RFC; }
            set { _RFC = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public string Buscar
        {
            get { return _Buscar; }
            set { _Buscar = value; }
        }
    }
}

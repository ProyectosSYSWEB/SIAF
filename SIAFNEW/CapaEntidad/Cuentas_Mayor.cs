using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public  class Cuentas_Mayor
    {
        private string _id;

        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _id_padre;

        public string id_padre
        {
            get { return _id_padre; }
            set { _id_padre = value; }
        }
        private string _tipo;

        public string tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        private string _descripcion;

        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private string _naturaleza;

        public string naturaleza
        {
            get { return _naturaleza; }
            set { _naturaleza = value; }
        }
        private string _nivel;

        public string nivel
        {
            get { return _nivel; }
            set { _nivel = value; }
        }
        private string _nivel_des;

        public string nivel_des
        {
            get { return _nivel_des; }
            set { _nivel_des = value; }
        }
        private string _clave;

        public string clave
        {
            get { return _clave; }
            set { _clave = value; }
        }
        private string _rubro;

        public string rubro
        {
            get { return _rubro; }
            set { _rubro = value; }
        }
        private string _estado_financiero;

        public string estado_financiero
        {
            get { return _estado_financiero; }
            set { _estado_financiero = value; }
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
    }
}

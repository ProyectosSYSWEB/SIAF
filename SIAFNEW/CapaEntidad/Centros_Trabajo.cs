using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
   public class Centros_Trabajo
    {
        private string _id;
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _centro_contable;
        public string centro_contable
        {
            get { return _centro_contable; }
            set { _centro_contable = value; }
        }

        private string _status;
        public string status
        {
            get { return _status; }
            set { _status = value; }
        }

        private string _clave;
        public string clave
        {
            get { return _clave; }
            set { _clave = value; }
        }

        private string _descripcion;
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private string _dependencia;
        public string dependencia
        {
            get { return _dependencia; }
            set { _dependencia = value; }
        }

        private string _max_id;
        public string max_id
        {
            get { return _max_id; }
            set { _max_id = value; }
        }

    }
}

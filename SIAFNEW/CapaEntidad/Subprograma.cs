using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Subprograma
    {
        private string _NivAcad;

        public string NivAcad
        {
            get { return _NivAcad; }
            set { _NivAcad = value; }
        }
        private string _Subprog;

        public string Subprog
        {
            get { return _Subprog; }
            set { _Subprog = value; }
        }

        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private string _Estatus;

        public string Estatus
        {
            get { return _Estatus; }
            set { _Estatus = value; }
        }

        private string _Programa;

        public string Programa
        {
            get { return _Programa; }
            set { _Programa = value; }
        }

        private string _Tipo;

        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        private string _Status;

        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }


    }
}

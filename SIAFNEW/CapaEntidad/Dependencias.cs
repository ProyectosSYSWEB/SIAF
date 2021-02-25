using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Dependencias
    {
        private string _C_Contab;

        public string C_Contab
        {
            get { return _C_Contab; }
            set { _C_Contab = value; }
        }

        private string _Depend;

        public string Depend
        {
            get { return _Depend; }
            set { _Depend = value; }
        }

        private string _Descrip;

        public string Descrip
        {
            get { return _Descrip; }
            set { _Descrip = value; }
        }

        private string _Administ;

        public string Administ
        {
            get { return _Administ; }
            set { _Administ = value; }
        }

        private string _Titular;

        public string Titular
        {
            get { return _Titular; }
            set { _Titular = value; }
        }

        private string _Titular_Puesto;

        public string Titular_Puesto
        {
            get { return _Titular_Puesto; }
            set { _Titular_Puesto = value; }
        }

        private string _Titular_Ant;

        public string Titular_Ant
        {
            get { return _Titular_Ant; }
            set { _Titular_Ant = value; }
        }

        private string _Titular_Puesto_Ant;

        public string Titular_Puesto_Ant
        {
            get { return _Titular_Puesto_Ant; }
            set { _Titular_Puesto_Ant = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidad
{
    public class Usuario
    {

        private string _Nombre;
        private string _Password;
        private string _TipoUsu;
        private string _CUsuario;
        private string _Dependencia;
        private string _Token;
        private string _Status;
        private string _Correo_UNACH;

        public string Correo_UNACH
        {
            get { return _Correo_UNACH; }
            set { _Correo_UNACH = value; }
        }

        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        public string Token
        {
            get { return _Token; }
            set { _Token = value; }
        }

        public string Dependencia
        {
            get { return _Dependencia; }
            set { _Dependencia = value; }
        }
        public string CUsuario
        {
            get { return _CUsuario; }
            set { _CUsuario = value; }
        }
        public string Nombre
        {
            get { return _Nombre.Trim(); }
            set { _Nombre = value.Trim(); }
        }
        public string Password
        {
            get { return _Password.Trim(); }
            set { _Password = value.Trim(); }
        }
        public string TipoUsu
        {
            get { return _TipoUsu.Trim(); }
            set { _TipoUsu = value.Trim(); }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Titulares
    {
        private string _Id;
        private string _Responsable;
        private string _Administrador;
        private string _Id_Responsable;
        private string _Id_Administrador;
        private string _Dependencia;
        private string _Puesto_Resp;
        private string _Puesto_Admin;



        public string Puesto_Resp
        {
            get { return _Puesto_Resp; }
            set { _Puesto_Resp = value; }
        }
        public string Puesto_Admin
        {
            get { return _Puesto_Admin; }
            set { _Puesto_Admin = value; }
        }
        public string Dependencia
        {
            get { return _Dependencia; }
            set { _Dependencia = value; }
        }
        public string Id_Administrador
        {
            get { return _Id_Administrador; }
            set { _Id_Administrador = value; }
        }
        public string Id_Responsable
        {
            get { return _Id_Responsable; }
            set { _Id_Responsable = value; }
        }
        public string Administrador
        {
            get { return _Administrador; }
            set { _Administrador = value; }
        }
        public string Responsable
        {
            get { return _Responsable; }
            set { _Responsable = value; }
        }
        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
    }
}

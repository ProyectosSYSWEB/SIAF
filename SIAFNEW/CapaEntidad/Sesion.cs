using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Sesion
    {
        private string _Usu_Nombre;
        private string _CUsuario;
        private string _Usu_TipoUsu;
        private string _Usu_Dependencia;
        private string _Usu_Ejercicio;
        private string _Usu_Programa;
        private string _Titular;
        private int _Row;
        private int _Columna;
        private string _Usu_Rep;
        private int _Editar;
        private string _ip;
        private string _mac_address;
        private string _id_sistema;
        private bool _Modifica_Ejercicio;
        private string _Status;
        private string _Correo_UNACH;
        private string _Nombre_Completo;

        public string Nombre_Completo
        {
            get { return _Nombre_Completo; }
            set { _Nombre_Completo = value; }
        }
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

        public string id_sistema
        {
            get { return _id_sistema; }
            set { _id_sistema = value; }
        }
        public string mac_address
        {
            get { return _mac_address; }
            set { _mac_address = value; }
        }
        public string ip
        {
            get { return _ip; }
            set { _ip = value; }
        }
        public int Row
        {
            get { return _Row; }
            set { _Row = value; }
        }
        public int Columna //Columna
        {
            get { return _Columna; }
            set { _Columna = value; }
        }
        public int Editar
        {
            get { return _Editar; }
            set { _Editar = value; }
        }
        public string Titular
        {
            get { return _Titular; }
            set { _Titular = value; }
        }        
        public string Usu_Ejercicio
        {
            get { return _Usu_Ejercicio.Trim(); }
            set { _Usu_Ejercicio = value.Trim(); }
        }
        public string Usu_Dependencia
        {
            get { return _Usu_Dependencia.Trim(); }
            set { _Usu_Dependencia = value.Trim(); }
        }
        public string Usu_Nombre
        {
            get { return _Usu_Nombre.Trim(); }
            set { _Usu_Nombre = value.Trim(); }
        }
        public string CUsuario
        {
            get { return _CUsuario.Trim(); }
            set { _CUsuario = value.Trim(); }
        }
        public string Usu_TipoUsu
        {
            get { return _Usu_TipoUsu.Trim(); }
            set { _Usu_TipoUsu = value.Trim(); }
        }
        public string Usu_Programa
        {
            get { return _Usu_Programa.Trim(); }
            set { _Usu_Programa = value.Trim(); }
        }
        public string Usu_Rep
        {
            get { return _Usu_Rep.Trim(); }
            set { _Usu_Rep = value.Trim(); }
        }
        public bool Modifica_Ejercicio
        {
            get { return _Modifica_Ejercicio; }
            set { _Modifica_Ejercicio = value; }
        }


    }
}

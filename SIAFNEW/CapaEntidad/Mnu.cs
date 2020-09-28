using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Mnu
    {
        private int _IdPadre;
        public int IdPadre
        {
            get { return _IdPadre; }
            set { _IdPadre = value; }
        }

        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Padre;
        public string Padre
        {
            get { return _Padre; }
            set { _Padre = value; }
        }

        private string _Clave;
        public string Clave
        {
            get { return _Clave; }
            set { _Clave = value; }
        }

        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private int _Nivel;
        public int Nivel
        {
            get { return _Nivel; }
            set { _Nivel = value; }
        }
        private string _Navigate_Url;
        public string Navigate_Url
        {
            get { return _Navigate_Url; }
            set { _Navigate_Url = value; }
        }
        private int _Id_Padre;
        public int Id_Padre
        {
            get { return _Id_Padre; }
            set { _Id_Padre = value; }
        }
        private string _NombreMenu;
        public string NombreMenu
        {
            get { return _NombreMenu; }
            set { _NombreMenu = value; }
        }

        private string _UsuarioNombre;
        public string UsuarioNombre
        {
            get { return _UsuarioNombre; }
            set { _UsuarioNombre = value; }
        }

        private int _Grupo;
        public int Grupo
        {
            get { return _Grupo; }
            set { _Grupo = value; }
        }

        private string _Ejercicio;
        public string Ejercicio
        {
            get { return _Ejercicio; }
            set { _Ejercicio = value; }
        }

    }
}

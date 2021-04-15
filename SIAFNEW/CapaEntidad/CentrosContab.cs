using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class CentrosContab
    {
        private string _C_Contab;

        public string C_Contab
        {
            get { return _C_Contab; }
            set { _C_Contab = value; }
        }

        private string _Descrip;

        public string Descrip
        {
            get { return _Descrip; }
            set { _Descrip = value; }
        }

        private string _Id;

        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Dependencia;

        public string Dependencia
        {
            get { return _Dependencia; }
            set { _Dependencia = value; }
        }

        private string _Director;

        public string Director
        {
            get { return _Director; }
            set { _Director = value; }
        }

        private string _Administrador;

        public string Administrador
        {
            get { return _Administrador; }
            set { _Administrador = value; }
        }

        private string _Saliente;

        public string Saliente
        {
            get { return _Saliente; }
            set { _Saliente = value; }
        }

        private string _Entrante;

        public string Entrante
        {
            get { return _Entrante; }
            set { _Entrante = value; }
        }

        private string _Ejercicio;

        public string Ejercicio
        {
            get { return _Ejercicio; }
            set { _Ejercicio = value; }
        }

        private int _Id_Control_Cierre;
        public int Id_Control_Cierre
        {
            get { return _Id_Control_Cierre; }
            set { _Id_Control_Cierre = value; }
        }

        private string _sistema;
        public string sistema
        {
            get { return _sistema; }
            set { _sistema = value; }
        }

        private string _Mes_anio;
        public string Mes_anio
        {
            get { return _Mes_anio.Trim(); }
            set { _Mes_anio = value.Trim(); }
        }

        private string _Cierre_Definitivo;
        public string Cierre_Definitivo
        {
            get { return _Cierre_Definitivo.Trim(); }
            set { _Cierre_Definitivo = value.Trim(); }
        }
    }
}

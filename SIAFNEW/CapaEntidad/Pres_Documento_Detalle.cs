using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Pres_Documento_Detalle
    {

        public int _Id_Documento;
        public int Id_Documento
        {
            get { return _Id_Documento; }
            set { _Id_Documento = value; }
        }

        public int _Id_Codigo_Prog;
        public int Id_Codigo_Prog
        {
            get { return _Id_Codigo_Prog; }
            set { _Id_Codigo_Prog = value; }
        }

        public string _Desc_Codigo_Prog;
        public string Desc_Codigo_Prog
        {
            get { return _Desc_Codigo_Prog; }
            set { _Desc_Codigo_Prog = value; }
        }

        public int _Consecutivo;
        public int Consecutivo
        {
            get { return _Consecutivo; }
            set { _Consecutivo = value; }
        }

        public string _Ur_clave;
        public string Ur_clave
        {
            get { return _Ur_clave; }
            set { _Ur_clave = value; }
        }

        public string _Tipo;
        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        public double _Importe_origen;
        public double Importe_origen
        {
            get { return _Importe_origen; }
            set { _Importe_origen = value; }
        }

        public double _Importe_disponible;
        public double Importe_disponible
        {
            get { return _Importe_disponible; }
            set { _Importe_disponible = value; }
        }


        public double _Importe_destino;
        public double Importe_destino
        {
            get { return _Importe_destino; }
            set { _Importe_destino = value; }
        }

        public double _Importe_mensual;
        public double Importe_mensual
        {
            get { return _Importe_mensual; }
            set { _Importe_mensual = value; }
        }

        public int _Mes_inicial;
        public int Mes_inicial
        {
            get { return _Mes_inicial; }
            set { _Mes_inicial = value; }
        }

        public int _Mes_final;
        public int Mes_final
        {
            get { return _Mes_final; }
            set { _Mes_final = value; }
        }

        public string _Cuenta_banco;
        public string Cuenta_banco
        {
            get { return _Cuenta_banco; }
            set { _Cuenta_banco = value; }
        }

        public string _Concepto;
        public string Concepto
        {
            get { return _Concepto; }
            set { _Concepto = value; }
        }

        public string _Referencia;
        public string Referencia
        {
            get { return _Referencia; }
            set { _Referencia = value; }
        }

        public string _Beneficiario_tipo;
        public string Beneficiario_tipo
        {
            get { return _Beneficiario_tipo; }
            set { _Beneficiario_tipo = value; }
        }

        public string _Beneficiario_nombre;
        public string Beneficiario_nombre
        {
            get { return _Beneficiario_nombre; }
            set { _Beneficiario_nombre = value; }
        }

        public string _Beneficiario_clave;
        public string Beneficiario_clave
        {
            get { return _Beneficiario_clave; }
            set { _Beneficiario_clave = value; }
        }

        private string _Desc_Partida;
        public string Desc_Partida
        {
            get { return _Desc_Partida; }
            set { _Desc_Partida = value; }
        }

    }
}

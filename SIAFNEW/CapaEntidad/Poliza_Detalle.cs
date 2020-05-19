using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Poliza_Detalle:Poliza
    {        
        private int _IdCuenta_Contable;
        private string _DescCuenta_Contable;
        private int _Numero_Movimiento;
        private double _Cargo;
        private double _Abono;

        public int IdCuenta_Contable
        {
            get { return _IdCuenta_Contable; }
            set { _IdCuenta_Contable = value; }
        }
        public string DescCuenta_Contable
        {
            get { return _DescCuenta_Contable.Trim(); }
            set { _DescCuenta_Contable = value.Trim(); }
        }
        public int Numero_Movimiento
        {
            get { return _Numero_Movimiento; }
            set { _Numero_Movimiento = value; }
        }
        public double Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }
        public double Abono
        {
            get { return _Abono; }
            set { _Abono = value; }
        }
    }
}

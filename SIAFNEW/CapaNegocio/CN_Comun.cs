using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Web.UI;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Comun
    {
        public void insertar_datos_sesion(ref Sesion objsesion, ref string Verificador)
        {
            try
            { 

                CD_Comun CDsesion = new CD_Comun();
                CDsesion.insertar_datos_sesion(ref objsesion, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref DropDownList DDL)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();
                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
        public void LlenaCombo(string SP, ref DropDownList DDL, string parametro1, string valor1)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro1, valor1);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();

                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaList(string SP, ref ListBox DDL, string parametro1, string parametro2, string valor1, string valor2)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro1, parametro2, valor1, valor2);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();

                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref DropDownList DDL, string parametro1, string parametro2, string valor1, string valor2)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro1, parametro2, valor1, valor2);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();

                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref DropDownList DDL, string parametro1, string parametro2, string parametro3, string valor1, string valor2, string valor3)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro1, parametro2, parametro3, valor1, valor2, valor3);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();

                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref DropDownList DDL, string parametro1, string parametro2, string parametro3, string parametro4, string valor1, string valor2, string valor3, string valor4)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro1, parametro2, parametro3, parametro4, valor1, valor2, valor3, valor4);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();

                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref DropDownList DDL, string parametro1, string parametro2, string parametro3, string parametro4, string parametro5, string valor1, string valor2, string valor3, string valor4, string valor5)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro1, parametro2, parametro3, parametro4, parametro5 , valor1, valor2, valor3, valor4,valor5);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();

                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref DropDownList DDL, string parametro1, string parametro2, string parametro3, string parametro4, string parametro5, string parametro6, string valor1, string valor2, string valor3, string valor4, string valor5, string valor6)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro1, parametro2, parametro3, parametro4, parametro5, parametro6, valor1, valor2, valor3, valor4, valor5, valor6);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();

                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }       
        public void LlenaCombo(string SP, ref DropDownList DDL, ref List<Comun> Etiquetas)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    Etiquetas = Lista;
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();
                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref DropDownList DDL, string parametro, string valor, ref List<Comun> Etiquetas)        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro, valor);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    Etiquetas = Lista;
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";

                    DDL.DataBind();
                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref DropDownList DDL, string parametro1, string parametro2, string valor1, string valor2, ref List<Comun> Etiquetas)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro1, parametro2, valor1, valor2);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    Etiquetas = Lista;
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";

                    DDL.DataBind();
                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref DropDownList DDL, string parametro1, string parametro2, string parametro3, string valor1, string valor2, string valor3, ref List<Comun> Etiquetas)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro1, parametro2, parametro3, valor1, valor2, valor3);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    Etiquetas = Lista;
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";

                    DDL.DataBind();
                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref DropDownList DDL, string parametro1, string parametro2, string parametro3, string parametro4, string valor1, string valor2, string valor3, string valor4, ref List<Comun> Etiquetas)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro1, parametro2, parametro3, parametro4, valor1, valor2, valor3, valor4);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    Etiquetas = Lista;
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";

                    DDL.DataBind();
                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref DropDownList DDL, string parametro1, string parametro2, string parametro3, string parametro4, string parametro5, string valor1, string valor2, string valor3, string valor4, string valor5, ref List<Comun> Etiquetas)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro1, parametro2, parametro3, parametro4,parametro5, valor1, valor2, valor3, valor4,valor5);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    Etiquetas = Lista;
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";

                    DDL.DataBind();
                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref ListBox DDL, string parametro1,  string valor1,  ref List<Comun> Etiquetas)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro1,  valor1);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    Etiquetas = Lista;
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";

                    DDL.DataBind();
                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref ListBox DDL, string parametro1, string parametro2, string valor1, string valor2, ref List<Comun> Etiquetas)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro1, parametro2, valor1, valor2);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    Etiquetas = Lista;
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";

                    DDL.DataBind();
                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCheckBoxList(string SP, ref CheckBoxList CBL, string[] parametros, string[] valores, ref List<Comun> Etiquetas)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametros, valores);
                CBL.Items.Clear();
                if (Lista.Count > 0)
                {
                    Etiquetas = Lista;
                    CBL.DataSource = Lista;
                    CBL.DataValueField = "IdStr";
                    CBL.DataTextField = "Descripcion";                    
                    CBL.DataBind();
                }
                else
                {
                    CBL.Items.Add("La opción no contiene datos");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
        public void LlenaCombo(string SP, string USERBD, string parametro1, string valor1, ref DropDownList DDL)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro1, valor1, USERBD);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();
                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, string USERBD, string parametro1, string parametro2, string valor1, string valor2, ref DropDownList DDL)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro1, parametro2, valor1, valor2, USERBD);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();

                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, string USERBD, string parametro1, string parametro2, string parametro3, string valor1, string valor2, string valor3, ref DropDownList DDL)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro1, parametro2, parametro3, valor1, valor2, valor3, USERBD);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();

                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, string USERBD, string parametro1, string parametro2, string parametro3, string parametro4, string valor1, string valor2, string valor3, string valor4, ref DropDownList DDL)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro1, parametro2, parametro3, parametro4, valor1, valor2, valor3, valor4, USERBD);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();

                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, string USERBD, string parametro1, string parametro2, string parametro3, string parametro4, string parametro5, string valor1, string valor2, string valor3, string valor4, string valor5, ref DropDownList DDL, ref List<Comun> Etiquetas)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro1, parametro2, parametro3, parametro4, parametro5, valor1, valor2, valor3, valor4, valor5, USERBD);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    Etiquetas = Lista;
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();

                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
        public void LlenaCombo(string SP, string USERBD, string usuario, ref DropDownList DDL)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, "P_usuario", usuario, USERBD);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();
                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, string USERBD,  ref DropDownList DDL)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, USERBD);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();
                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref DropDownList DDL, string[] parametros, string[] valores)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametros, valores);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();

                }
                else
                {
                    DDL.Items.Add("LA OPCIÓN NO CONTIENE DATOS.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref DropDownList DDL, string[] parametros, string[] valores, ref List<Comun> Etiquetas)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametros, valores);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    Etiquetas = Lista;
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();

                }
                else
                {
                    DDL.Items.Add("LA OPCIÓN NO CONTIENE DATOS.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void HideColumns(GridView grdView, Int32[] Columnas)
        {
            for (int i = 0; i < Columnas.Length; i++)
            {
                grdView.HeaderRow.Cells[Convert.ToInt32(Columnas.GetValue(i))].Visible = false;
                foreach (GridViewRow row in grdView.Rows)
                {
                    row.Cells[Convert.ToInt32(Columnas.GetValue(i))].Visible = false;
                }
            }
        }
        public void Limpiador_controles(Control control)
        {            
                var textbox = control as TextBox;
                if (textbox != null)
                {
                    textbox.Text = string.Empty;                    
                }
                //var dropDownList = control as DropDownList;
                //if (dropDownList != null)
                //{
                //    dropDownList.SelectedIndex = 0;
                //}

                foreach (Control childControl in control.Controls)
                {
                    Limpiador_controles(childControl);
                }                       
        }
        public void Inhabilitar_controles(Control control)
        {
            var textbox = control as TextBox;
            var ddl = control as DropDownList;
            
            if (textbox != null)
            {
                
                textbox.Enabled =false;
            }
            else if (ddl != null)
            {
                ddl.Enabled=false;
            }
            //var dropDownList = control as DropDownList;
            //if (dropDownList != null)
            //{
            //    dropDownList.SelectedIndex = 0;
            //}

            foreach (Control childControl in control.Controls)
            {
                Inhabilitar_controles(childControl);
            }
        }
        public void Habilitar_controles(Control control)
        {
            var textbox = control as TextBox;
            var ddl = control as DropDownList;

            if (textbox != null)
            {

                textbox.Enabled = true;
            }
            else if (ddl != null)
            {
                ddl.Enabled = true;
            }
            //var dropDownList = control as DropDownList;
            //if (dropDownList != null)
            //{
            //    dropDownList.SelectedIndex = 0;
            //}

            foreach (Control childControl in control.Controls)
            {
                Habilitar_controles(childControl);
            }
        }
        public void Monitor(string Usuario, string Sistema, string Centro_Contable, ref List<Comun> List)
        {
            try
            {
                CD_Comun CDMonitor = new CD_Comun();
                CDMonitor.Monitor(Usuario,Sistema,Centro_Contable,ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Monitor_Patrimonio(string Centro_Contable, ref List<Comun> List)
        {
            try
            {
                CD_Comun CDMonitor = new CD_Comun();
                CDMonitor.Monitor_Patrimonio(Centro_Contable, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Monitor_Estadistica(int Rango, ref List<Comun> List)
        {
            try
            {
                CD_Comun CDMonitor = new CD_Comun();
                CDMonitor.Monitor_Estadistica(Rango, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Monitor_EstadisticaPP(string Color, int Rango, ref List<Comun> List)
        {
            try
            {
                CD_Comun CDMonitor = new CD_Comun();
                CDMonitor.Monitor_EstadisticaPP(Color, Rango, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Estadisticas(string tipo, ref string[] datosX, ref int[] datosY)
        {
            try
            {
                CD_Comun CDMonitor = new CD_Comun();
                CDMonitor.Estadisticas(tipo, ref datosX, ref datosY);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Estadisticas_Presupuesto(string tipo, ref string[] datosX, ref int[] datosY)
        {
            try
            {
                CD_Comun CDMonitor = new CD_Comun();
                CDMonitor.Estadisticas_Presupuesto(tipo, ref datosX, ref datosY);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Estadisticas(int Rango, ref List<Comun> List)
        {
            try
            {
                CD_Comun CDMonitor = new CD_Comun();
                CDMonitor.Estadisticas(Rango, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //public void LlenaCombo(string SP, ref DropDownList DDL, string[] parametros, string[] valores)
        //{
        //    try
        //    {
        //        List<Comun> Lista = new List<Comun>();
        //        CD_Comun CDComun = new CD_Comun();
        //        CDComun.LlenaCombo(SP, ref Lista, parametros, valores);
        //        DDL.Items.Clear();
        //        if (Lista.Count > 0)
        //        {
        //            DDL.DataSource = Lista;
        //            DDL.DataValueField = "IdStr";
        //            DDL.DataTextField = "Descripcion";
        //            DDL.DataBind();

        //        }
        //        else
        //        {
        //            DDL.Items.Add("LA OPCIÓN NO CONTIENE DATOS.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        //private void VerificaFechas(TextBox txt)
        //{
        //    lblMsj.Text = string.Empty;
        //    DateTime fecha = Convert.ToDateTime(txt.Text);
        //    string Anio = fecha.ToString("yyyy");
        //    if (Anio != SesionUsu.Usu_Ejercicio)
        //    {
        //        txt.Text = string.Empty;
        //        lblMsj.Text = "Ejercicio incorrecto";
        //    }

        //}
        public void VerificaTextoMensajeError(ref string Mensaje)
        {
            Mensaje = Mensaje.Replace("\r", "");
            Mensaje = Mensaje.Replace("\n", "");
            Mensaje = Mensaje.Replace("'", "");
            if (Mensaje.Length >= 50)
                Mensaje.Substring(0, 45);

        }
    }
}

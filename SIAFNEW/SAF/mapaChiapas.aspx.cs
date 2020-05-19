using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAF
{
    public partial class mapaChiapas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (ImageMap1 e.PostBackValue == "TUXTLA")
                //{
                //    ModalPopupExtender1.Show();
                //}
            }

        }

        protected void ImageMap1_Click(object sender, ImageMapEventArgs e)
        {
            //if (e.PostBackValue == "TUXTLA")
            //{
            //    lblSede.Text = "";
            //    ModalPopupExtender1.Show();
            //}

            string Sede=e.PostBackValue;
            switch (Sede)
            {
                case "TUXTLA":
                    lblSede.Text = Sede;
                    ModalPopupExtender1.Show();
                    break;
                case "SAN CRISTOBAL":
                    lblSede.Text = Sede;
                    ModalPopupExtender1.Show();
                    break;
                case "COMITAN":
                    lblSede.Text = Sede;
                    ModalPopupExtender1.Show();
                    break;
                case "TAPACHULA":
                    lblSede.Text = Sede;
                    ModalPopupExtender1.Show();
                    break;
                default:
                    break;
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
        }
    }
}
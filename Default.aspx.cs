using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Usados_Certificados_Default : System.Web.UI.Page
{
    public string codigo_grupo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Cliente_Numero"] != null || Session["Cliente_Nombre"] != null)
            {
                codigo_grupo = Session["Cliente_Numero"].ToString().Trim();
                if (codigo_grupo == "TCL1") mnu_Usuario.Visible = true;
                if (codigo_grupo != "TCL1") mnu_Usuario.Visible = false;
            }
            else
            { Response.Write("../default.aspx"); }
        }
    }
}
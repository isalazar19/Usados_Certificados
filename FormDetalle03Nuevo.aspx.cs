using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Usados_Certificados_FormDetalle03Nuevo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["P36"] != null && Session["P37"] != null && Session["P38"] != null && Session["P39"] != null && Session["P40"] != null && Session["P41"] != null &&
                Session["P42"] != null && Session["P43"] != null && Session["P44"] != null)
            {
                DDL36.SelectedValue = Session["P36"].ToString(); DDL37.SelectedValue = Session["P37"].ToString(); DDL38.SelectedValue = Session["P38"].ToString();
                DDL39.SelectedValue = Session["P39"].ToString(); DDL40.SelectedValue = Session["P40"].ToString(); DDL41.SelectedValue = Session["P41"].ToString();
                DDL42.SelectedValue = Session["P42"].ToString(); DDL43.SelectedValue = Session["P43"].ToString(); DDL44.SelectedValue = Session["P44"].ToString();
                /* Comentarios */
                txtComentarios36.Value = Session["C36"].ToString(); txtComentarios37.Value = Session["C37"].ToString(); txtComentarios38.Value = Session["C38"].ToString();
                txtComentarios39.Value = Session["C39"].ToString(); txtComentarios40.Value = Session["C40"].ToString(); txtComentarios41.Value = Session["C41"].ToString();
                txtComentarios42.Value = Session["C42"].ToString(); txtComentarios43.Value = Session["C43"].ToString(); txtComentarios44.Value = Session["C44"].ToString();
            }
        }
    }

    #region botones
    protected void btn_Atras_Click(object sender, EventArgs e)
    {
        Session["botonAtras"] = "si";
        Session["P36"] = DDL36.SelectedValue.ToString(); Session["P37"] = DDL37.SelectedValue.ToString(); Session["P38"] = DDL38.SelectedValue.ToString();
        Session["P39"] = DDL39.SelectedValue.ToString(); Session["P40"] = DDL40.SelectedValue.ToString(); Session["P41"] = DDL41.SelectedValue.ToString();
        Session["P42"] = DDL42.SelectedValue.ToString(); Session["P43"] = DDL43.SelectedValue.ToString(); Session["P44"] = DDL44.SelectedValue.ToString();
        /* Comentarios */
        Session["C36"] = txtComentarios36.Value; Session["C37"] = txtComentarios37.Value; Session["C38"] = txtComentarios38.Value; 
        Session["C39"] = txtComentarios39.Value; Session["C40"] = txtComentarios40.Value; Session["C41"] = txtComentarios41.Value;
        Session["C42"] = txtComentarios42.Value; Session["C43"] = txtComentarios43.Value; Session["C44"] = txtComentarios44.Value;
        Response.Redirect("FormDetalle02Nuevo.aspx?pagina=2");
    }
    protected void btn_Siguiente_Click(object sender, EventArgs e)
    {
        if (DDL36.SelectedValue == "0" || DDL37.SelectedValue == "0" || DDL38.SelectedValue == "0" || DDL39.SelectedValue == "0" || DDL40.SelectedValue == "0" || DDL41.SelectedValue == "0" || 
            DDL42.SelectedValue == "0" || DDL43.SelectedValue == "0" || DDL44.SelectedValue == "0")
        { Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "MensajeValidaResultado();", true); return; }
        Session["P36"] = DDL36.SelectedValue.ToString(); Session["P37"] = DDL37.SelectedValue.ToString(); Session["P38"] = DDL38.SelectedValue.ToString();
        Session["P39"] = DDL39.SelectedValue.ToString(); Session["P40"] = DDL40.SelectedValue.ToString(); Session["P41"] = DDL41.SelectedValue.ToString();
        Session["P42"] = DDL42.SelectedValue.ToString(); Session["P43"] = DDL43.SelectedValue.ToString(); Session["P44"] = DDL44.SelectedValue.ToString();
        /* Comentarios */
        Session["C36"] = txtComentarios36.Value; Session["C37"] = txtComentarios37.Value; Session["C38"] = txtComentarios38.Value;
        Session["C39"] = txtComentarios39.Value; Session["C40"] = txtComentarios40.Value; Session["C41"] = txtComentarios41.Value;
        Session["C42"] = txtComentarios42.Value; Session["C43"] = txtComentarios43.Value; Session["C44"] = txtComentarios44.Value;
        Response.Redirect("FormDetalle04Nuevo.aspx?pagina=4");
    }
    #endregion
}
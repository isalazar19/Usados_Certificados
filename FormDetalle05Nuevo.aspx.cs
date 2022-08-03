using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Usados_Certificados_FormDetalle05Nuevo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["P75"] != null && Session["P76"] != null && Session["P77"] != null && Session["P78"] != null && Session["P79"] != null &&
                Session["P80"] != null && Session["P81"] != null && Session["P82"] != null && Session["P83"] != null && Session["P84"] != null)
            {
                DDL75.SelectedValue = Session["P75"].ToString(); DDL76.SelectedValue = Session["P76"].ToString(); DDL77.SelectedValue = Session["P77"].ToString(); DDL78.SelectedValue = Session["P78"].ToString(); DDL79.SelectedValue = Session["P79"].ToString();
                DDL80.SelectedValue = Session["P80"].ToString(); DDL81.SelectedValue = Session["P81"].ToString(); DDL82.SelectedValue = Session["P82"].ToString(); DDL83.SelectedValue = Session["P83"].ToString(); DDL84.SelectedValue = Session["P84"].ToString();
                /* Comentarios */
                txtComentarios75.Value = Session["C75"].ToString(); txtComentarios76.Value = Session["C76"].ToString(); txtComentarios77.Value = Session["C77"].ToString();
                txtComentarios78.Value = Session["C78"].ToString(); txtComentarios79.Value = Session["C79"].ToString(); txtComentarios80.Value = Session["C80"].ToString();
                txtComentarios81.Value = Session["C81"].ToString(); txtComentarios82.Value = Session["C82"].ToString(); txtComentarios83.Value = Session["C83"].ToString();
                txtComentarios84.Value = Session["C84"].ToString();
            }
        }
    }
    #region botones
    protected void btn_Atras_Click(object sender, EventArgs e)
    {
        Session["botonAtras"] = "si";
        Session["P75"] = DDL75.SelectedValue.ToString(); Session["P76"] = DDL76.SelectedValue.ToString(); Session["P77"] = DDL77.SelectedValue.ToString(); Session["P78"] = DDL78.SelectedValue.ToString(); Session["P79"] = DDL79.SelectedValue.ToString();
        Session["P80"] = DDL80.SelectedValue.ToString(); Session["P81"] = DDL81.SelectedValue.ToString(); Session["P82"] = DDL82.SelectedValue.ToString(); Session["P83"] = DDL83.SelectedValue.ToString(); Session["P84"] = DDL84.SelectedValue.ToString();
        /* Comentarios */
        Session["C75"] = txtComentarios75.Value; Session["C76"] = txtComentarios76.Value; Session["C77"] = txtComentarios77.Value; Session["C78"] = txtComentarios78.Value; Session["C79"] = txtComentarios79.Value;
        Session["C80"] = txtComentarios80.Value; Session["C81"] = txtComentarios81.Value; Session["C82"] = txtComentarios82.Value; Session["C83"] = txtComentarios83.Value; Session["C84"] = txtComentarios84.Value;
        Response.Redirect("FormDetalle04Nuevo.aspx?pagina=4");
    }
    protected void btn_Siguiente_Click(object sender, EventArgs e)
    {
        if (DDL75.SelectedValue == "0" || DDL76.SelectedValue == "0" || DDL77.SelectedValue == "0" || DDL78.SelectedValue == "0" || DDL79.SelectedValue == "0" || DDL80.SelectedValue == "0" || DDL81.SelectedValue == "0" ||
            DDL82.SelectedValue == "0" || DDL83.SelectedValue == "0" || DDL84.SelectedValue == "0")
        { Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "MensajeValidaResultado();", true); return; }
        Session["P75"] = DDL75.SelectedValue.ToString(); Session["P76"] = DDL76.SelectedValue.ToString(); Session["P77"] = DDL77.SelectedValue.ToString(); Session["P78"] = DDL78.SelectedValue.ToString(); Session["P79"] = DDL79.SelectedValue.ToString();
        Session["P80"] = DDL80.SelectedValue.ToString(); Session["P81"] = DDL81.SelectedValue.ToString(); Session["P82"] = DDL82.SelectedValue.ToString(); Session["P83"] = DDL83.SelectedValue.ToString(); Session["P84"] = DDL84.SelectedValue.ToString();
        /* Comentarios */
        Session["C75"] = txtComentarios75.Value; Session["C76"] = txtComentarios76.Value; Session["C77"] = txtComentarios77.Value; Session["C78"] = txtComentarios78.Value; Session["C79"] = txtComentarios79.Value;
        Session["C80"] = txtComentarios80.Value; Session["C81"] = txtComentarios81.Value; Session["C82"] = txtComentarios82.Value; Session["C83"] = txtComentarios83.Value; Session["C84"] = txtComentarios84.Value;
        Response.Redirect("FormDetalle06Nuevo.aspx?pagina=6");
    }
    #endregion
}
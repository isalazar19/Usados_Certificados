using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Usados_Certificados_FormDetalle02Nuevo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["P22"] != null && Session["P23"] != null && Session["P24"] != null && Session["P25"] != null && Session["P26"] != null && Session["P27"] != null && Session["P28"] != null &&
                Session["P29"] != null && Session["P30"] != null && Session["P31"] != null && Session["P32"] != null && Session["P33"] != null && Session["P34"] != null && Session["P35"] != null)
            {
                DDL22.SelectedValue = Session["P22"].ToString(); DDL23.SelectedValue = Session["P23"].ToString(); DDL24.SelectedValue = Session["P24"].ToString(); DDL25.SelectedValue = Session["P25"].ToString();
                DDL26.SelectedValue = Session["P26"].ToString(); DDL27.SelectedValue = Session["P27"].ToString(); DDL28.SelectedValue = Session["P28"].ToString(); DDL29.SelectedValue = Session["P29"].ToString();
                DDL30.SelectedValue = Session["P30"].ToString(); DDL31.SelectedValue = Session["P31"].ToString(); DDL32.SelectedValue = Session["P32"].ToString(); DDL33.SelectedValue = Session["P33"].ToString();
                DDL34.SelectedValue = Session["P34"].ToString(); DDL35.SelectedValue = Session["P35"].ToString();
                /* Comentarios */
                txtComentarios22.Value = Session["C22"].ToString(); txtComentarios23.Value = Session["C23"].ToString(); txtComentarios24.Value = Session["C24"].ToString();
                txtComentarios25.Value = Session["C25"].ToString(); txtComentarios26.Value = Session["C26"].ToString(); txtComentarios27.Value = Session["C27"].ToString();
                txtComentarios28.Value = Session["C28"].ToString(); txtComentarios29.Value = Session["C29"].ToString(); txtComentarios30.Value = Session["C30"].ToString();
                txtComentarios31.Value = Session["C31"].ToString(); txtComentarios32.Value = Session["C32"].ToString(); txtComentarios33.Value = Session["C33"].ToString();
                txtComentarios34.Value = Session["C34"].ToString(); txtComentarios35.Value = Session["C35"].ToString();
            }
        }
    }

    #region botones
    protected void btn_Atras_Click(object sender, EventArgs e)
    {
        Session["botonAtras"] = "si";
        Session["P22"] = DDL22.SelectedValue.ToString(); Session["P23"] = DDL23.SelectedValue.ToString(); Session["P24"] = DDL24.SelectedValue.ToString(); Session["P25"] = DDL25.SelectedValue.ToString();
        Session["P26"] = DDL26.SelectedValue.ToString(); Session["P27"] = DDL27.SelectedValue.ToString(); Session["P28"] = DDL28.SelectedValue.ToString(); Session["P29"] = DDL29.SelectedValue.ToString();
        Session["P30"] = DDL30.SelectedValue.ToString(); Session["P31"] = DDL31.SelectedValue.ToString(); Session["P32"] = DDL32.SelectedValue.ToString(); Session["P33"] = DDL33.SelectedValue.ToString();
        Session["P34"] = DDL34.SelectedValue.ToString(); Session["P35"] = DDL35.SelectedValue.ToString(); 
        /* Comentarios */
        Session["C22"] = txtComentarios22.Value; Session["C23"] = txtComentarios23.Value; Session["C24"] = txtComentarios24.Value; Session["C25"] = txtComentarios25.Value; Session["C26"] = txtComentarios26.Value; 
        Session["C27"] = txtComentarios27.Value; Session["C28"] = txtComentarios28.Value; Session["C29"] = txtComentarios29.Value; Session["C30"] = txtComentarios30.Value; Session["C31"] = txtComentarios31.Value;
        Session["C32"] = txtComentarios32.Value; Session["C33"] = txtComentarios33.Value; Session["C34"] = txtComentarios34.Value; Session["C35"] = txtComentarios35.Value;
        Response.Redirect("FormDetalle01Nuevo.aspx?pagina=1");
    }
    protected void btn_Siguiente_Click(object sender, EventArgs e)
    {
        if (DDL22.SelectedValue == "0" || DDL23.SelectedValue == "0" || DDL24.SelectedValue == "0" || DDL25.SelectedValue == "0" || DDL26.SelectedValue == "0" || DDL27.SelectedValue == "0" || DDL28.SelectedValue == "0" ||
            DDL29.SelectedValue == "0" || DDL30.SelectedValue == "0" || DDL31.SelectedValue == "0" || DDL32.SelectedValue == "0" || DDL33.SelectedValue == "0" || DDL34.SelectedValue == "0" || DDL35.SelectedValue == "0")
        { Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "MensajeValidaResultado();", true); return; }
        Session["P22"] = DDL22.SelectedValue.ToString(); Session["P23"] = DDL23.SelectedValue.ToString(); Session["P24"] = DDL24.SelectedValue.ToString(); Session["P25"] = DDL25.SelectedValue.ToString();
        Session["P26"] = DDL26.SelectedValue.ToString(); Session["P27"] = DDL27.SelectedValue.ToString(); Session["P28"] = DDL28.SelectedValue.ToString(); Session["P29"] = DDL29.SelectedValue.ToString();
        Session["P30"] = DDL30.SelectedValue.ToString(); Session["P31"] = DDL31.SelectedValue.ToString(); Session["P32"] = DDL32.SelectedValue.ToString(); Session["P33"] = DDL33.SelectedValue.ToString();
        Session["P34"] = DDL34.SelectedValue.ToString(); Session["P35"] = DDL35.SelectedValue.ToString();
        /* Comentarios */
        Session["C22"] = txtComentarios22.Value; Session["C23"] = txtComentarios23.Value; Session["C24"] = txtComentarios24.Value; Session["C25"] = txtComentarios25.Value; Session["C26"] = txtComentarios26.Value;
        Session["C27"] = txtComentarios27.Value; Session["C28"] = txtComentarios28.Value; Session["C29"] = txtComentarios29.Value; Session["C30"] = txtComentarios30.Value; Session["C31"] = txtComentarios31.Value;
        Session["C32"] = txtComentarios32.Value; Session["C33"] = txtComentarios33.Value; Session["C34"] = txtComentarios34.Value; Session["C35"] = txtComentarios35.Value;
        Response.Redirect("FormDetalle03Nuevo.aspx?pagina=3");
    }
    #endregion
}
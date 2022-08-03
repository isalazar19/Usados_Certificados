using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Usados_Certificados_FormDetalle04Nuevo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["P45"] != null && Session["P46"] != null && Session["P47"] != null && Session["P48"] != null && Session["P49"] != null &&
                Session["P50"] != null && Session["P51"] != null && Session["P52"] != null && Session["P53"] != null && Session["P54"] != null &&
                Session["P55"] != null && Session["P56"] != null && Session["P57"] != null && Session["P58"] != null && Session["P59"] != null &&
                Session["P60"] != null && Session["P61"] != null && Session["P62"] != null && Session["P63"] != null && Session["P64"] != null &&
                Session["P65"] != null && Session["P66"] != null && Session["P67"] != null && Session["P68"] != null && Session["P69"] != null &&
                Session["P70"] != null && Session["P71"] != null && Session["P72"] != null && Session["P73"] != null && Session["P74"] != null)
            {
                DDL45.SelectedValue = Session["P45"].ToString(); DDL46.SelectedValue = Session["P46"].ToString(); DDL47.SelectedValue = Session["P47"].ToString();
                DDL48.SelectedValue = Session["P48"].ToString(); DDL49.SelectedValue = Session["P49"].ToString(); DDL50.SelectedValue = Session["P50"].ToString();
                DDL51.SelectedValue = Session["P51"].ToString(); DDL52.SelectedValue = Session["P52"].ToString(); DDL53.SelectedValue = Session["P53"].ToString();
                DDL54.SelectedValue = Session["P54"].ToString(); DDL55.SelectedValue = Session["P55"].ToString(); DDL56.SelectedValue = Session["P56"].ToString();
                DDL57.SelectedValue = Session["P57"].ToString(); DDL58.SelectedValue = Session["P58"].ToString(); DDL59.SelectedValue = Session["P59"].ToString();
                DDL60.SelectedValue = Session["P60"].ToString(); DDL61.SelectedValue = Session["P61"].ToString(); DDL62.SelectedValue = Session["P62"].ToString();
                DDL63.SelectedValue = Session["P63"].ToString(); DDL64.SelectedValue = Session["P64"].ToString(); DDL65.SelectedValue = Session["P65"].ToString();
                DDL66.SelectedValue = Session["P66"].ToString(); DDL67.SelectedValue = Session["P67"].ToString(); DDL68.SelectedValue = Session["P68"].ToString();
                DDL69.SelectedValue = Session["P69"].ToString(); DDL70.SelectedValue = Session["P70"].ToString(); DDL71.SelectedValue = Session["P71"].ToString();
                DDL72.SelectedValue = Session["P72"].ToString(); DDL73.SelectedValue = Session["P73"].ToString(); DDL74.SelectedValue = Session["P74"].ToString();
                /* Comentarios */
                txtComentarios45.Value = Session["C45"].ToString(); txtComentarios46.Value = Session["C46"].ToString(); txtComentarios47.Value = Session["C47"].ToString();
                txtComentarios48.Value = Session["C48"].ToString(); txtComentarios49.Value = Session["C49"].ToString(); txtComentarios50.Value = Session["C50"].ToString();
                txtComentarios51.Value = Session["C51"].ToString(); txtComentarios52.Value = Session["C52"].ToString(); txtComentarios53.Value = Session["C53"].ToString();
                txtComentarios54.Value = Session["C54"].ToString(); txtComentarios55.Value = Session["C55"].ToString(); txtComentarios56.Value = Session["C56"].ToString();
                txtComentarios57.Value = Session["C57"].ToString(); txtComentarios58.Value = Session["C58"].ToString(); txtComentarios59.Value = Session["C59"].ToString();
                txtComentarios60.Value = Session["C60"].ToString(); txtComentarios61.Value = Session["C61"].ToString(); txtComentarios62.Value = Session["C62"].ToString();
                txtComentarios63.Value = Session["C63"].ToString(); txtComentarios64.Value = Session["C64"].ToString(); txtComentarios65.Value = Session["C65"].ToString();
                txtComentarios66.Value = Session["C66"].ToString(); txtComentarios67.Value = Session["C67"].ToString(); txtComentarios68.Value = Session["C68"].ToString();
                txtComentarios69.Value = Session["C69"].ToString(); txtComentarios70.Value = Session["C70"].ToString(); txtComentarios71.Value = Session["C71"].ToString();
                txtComentarios72.Value = Session["C72"].ToString(); txtComentarios73.Value = Session["C73"].ToString(); txtComentarios74.Value = Session["C74"].ToString();
            }
        }
    }

    #region botones
    protected void btn_Atras_Click(object sender, EventArgs e)
    {
        Session["botonAtras"] = "si";
        Session["P45"] = DDL45.SelectedValue.ToString(); Session["P46"] = DDL46.SelectedValue.ToString(); Session["P47"] = DDL47.SelectedValue.ToString(); Session["P48"] = DDL48.SelectedValue.ToString(); Session["P49"] = DDL49.SelectedValue.ToString();
        Session["P50"] = DDL50.SelectedValue.ToString(); Session["P51"] = DDL51.SelectedValue.ToString(); Session["P52"] = DDL52.SelectedValue.ToString(); Session["P53"] = DDL53.SelectedValue.ToString(); Session["P54"] = DDL54.SelectedValue.ToString();
        Session["P55"] = DDL55.SelectedValue.ToString(); Session["P56"] = DDL56.SelectedValue.ToString(); Session["P57"] = DDL57.SelectedValue.ToString(); Session["P58"] = DDL58.SelectedValue.ToString(); Session["P59"] = DDL59.SelectedValue.ToString();
        Session["P60"] = DDL60.SelectedValue.ToString(); Session["P61"] = DDL61.SelectedValue.ToString(); Session["P62"] = DDL62.SelectedValue.ToString(); Session["P63"] = DDL63.SelectedValue.ToString(); Session["P64"] = DDL64.SelectedValue.ToString();
        Session["P65"] = DDL65.SelectedValue.ToString(); Session["P66"] = DDL66.SelectedValue.ToString(); Session["P67"] = DDL67.SelectedValue.ToString(); Session["P68"] = DDL68.SelectedValue.ToString(); Session["P69"] = DDL69.SelectedValue.ToString();
        Session["P70"] = DDL70.SelectedValue.ToString(); Session["P71"] = DDL71.SelectedValue.ToString(); Session["P72"] = DDL72.SelectedValue.ToString(); Session["P73"] = DDL73.SelectedValue.ToString(); Session["P74"] = DDL74.SelectedValue.ToString();
        /* Comentarios */
        Session["C45"] = txtComentarios45.Value; Session["C46"] = txtComentarios46.Value; Session["C47"] = txtComentarios47.Value; Session["C48"] = txtComentarios48.Value; Session["C49"] = txtComentarios49.Value;
        Session["C50"] = txtComentarios50.Value; Session["C51"] = txtComentarios51.Value; Session["C52"] = txtComentarios52.Value; Session["C53"] = txtComentarios53.Value; Session["C54"] = txtComentarios54.Value;
        Session["C55"] = txtComentarios55.Value; Session["C56"] = txtComentarios56.Value; Session["C57"] = txtComentarios57.Value; Session["C58"] = txtComentarios58.Value; Session["C59"] = txtComentarios59.Value;
        Session["C60"] = txtComentarios60.Value; Session["C61"] = txtComentarios61.Value; Session["C62"] = txtComentarios62.Value; Session["C63"] = txtComentarios63.Value; Session["C64"] = txtComentarios64.Value;
        Session["C65"] = txtComentarios65.Value; Session["C66"] = txtComentarios66.Value; Session["C67"] = txtComentarios67.Value; Session["C68"] = txtComentarios63.Value; Session["C69"] = txtComentarios64.Value;
        Session["C70"] = txtComentarios70.Value; Session["C71"] = txtComentarios71.Value; Session["C72"] = txtComentarios72.Value; Session["C73"] = txtComentarios73.Value; Session["C74"] = txtComentarios74.Value;
        Response.Redirect("FormDetalle03Nuevo.aspx?pagina=3");
    }
    protected void btn_Siguiente_Click(object sender, EventArgs e)
    {
        if (DDL45.SelectedValue == "0" || DDL46.SelectedValue == "0" || DDL47.SelectedValue == "0" || DDL48.SelectedValue == "0" || DDL49.SelectedValue == "0" || DDL50.SelectedValue == "0" || DDL51.SelectedValue == "0" ||
            DDL52.SelectedValue == "0" || DDL53.SelectedValue == "0" || DDL54.SelectedValue == "0" || DDL55.SelectedValue == "0" || DDL56.SelectedValue == "0" || DDL57.SelectedValue == "0" || DDL58.SelectedValue == "0" ||
            DDL59.SelectedValue == "0" || DDL60.SelectedValue == "0" || DDL61.SelectedValue == "0" || DDL62.SelectedValue == "0" || DDL63.SelectedValue == "0" || DDL64.SelectedValue == "0" || DDL65.SelectedValue == "0" ||
            DDL66.SelectedValue == "0" || DDL67.SelectedValue == "0" || DDL68.SelectedValue == "0" || DDL69.SelectedValue == "0" || DDL70.SelectedValue == "0" || DDL71.SelectedValue == "0" || DDL72.SelectedValue == "0" ||
            DDL73.SelectedValue == "0" || DDL74.SelectedValue == "0")
        { Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "MensajeValidaResultado();", true); return; }
        Session["P45"] = DDL45.SelectedValue.ToString(); Session["P46"] = DDL46.SelectedValue.ToString(); Session["P47"] = DDL47.SelectedValue.ToString(); Session["P48"] = DDL48.SelectedValue.ToString(); Session["P49"] = DDL49.SelectedValue.ToString();
        Session["P50"] = DDL50.SelectedValue.ToString(); Session["P51"] = DDL51.SelectedValue.ToString(); Session["P52"] = DDL52.SelectedValue.ToString(); Session["P53"] = DDL53.SelectedValue.ToString(); Session["P54"] = DDL54.SelectedValue.ToString();
        Session["P55"] = DDL55.SelectedValue.ToString(); Session["P56"] = DDL56.SelectedValue.ToString(); Session["P57"] = DDL57.SelectedValue.ToString(); Session["P58"] = DDL58.SelectedValue.ToString(); Session["P59"] = DDL59.SelectedValue.ToString();
        Session["P60"] = DDL60.SelectedValue.ToString(); Session["P61"] = DDL61.SelectedValue.ToString(); Session["P62"] = DDL62.SelectedValue.ToString(); Session["P63"] = DDL63.SelectedValue.ToString(); Session["P64"] = DDL64.SelectedValue.ToString();
        Session["P65"] = DDL65.SelectedValue.ToString(); Session["P66"] = DDL66.SelectedValue.ToString(); Session["P67"] = DDL67.SelectedValue.ToString(); Session["P68"] = DDL68.SelectedValue.ToString(); Session["P69"] = DDL69.SelectedValue.ToString();
        Session["P70"] = DDL70.SelectedValue.ToString(); Session["P71"] = DDL71.SelectedValue.ToString(); Session["P72"] = DDL72.SelectedValue.ToString(); Session["P73"] = DDL73.SelectedValue.ToString(); Session["P74"] = DDL74.SelectedValue.ToString();
        /* Comentarios */
        Session["C45"] = txtComentarios45.Value; Session["C46"] = txtComentarios46.Value; Session["C47"] = txtComentarios47.Value; Session["C48"] = txtComentarios48.Value; Session["C49"] = txtComentarios49.Value;
        Session["C50"] = txtComentarios50.Value; Session["C51"] = txtComentarios51.Value; Session["C52"] = txtComentarios52.Value; Session["C53"] = txtComentarios53.Value; Session["C54"] = txtComentarios54.Value;
        Session["C55"] = txtComentarios55.Value; Session["C56"] = txtComentarios56.Value; Session["C57"] = txtComentarios57.Value; Session["C58"] = txtComentarios58.Value; Session["C59"] = txtComentarios59.Value;
        Session["C60"] = txtComentarios60.Value; Session["C61"] = txtComentarios61.Value; Session["C62"] = txtComentarios62.Value; Session["C63"] = txtComentarios63.Value; Session["C64"] = txtComentarios64.Value;
        Session["C65"] = txtComentarios65.Value; Session["C66"] = txtComentarios66.Value; Session["C67"] = txtComentarios67.Value; Session["C68"] = txtComentarios63.Value; Session["C69"] = txtComentarios64.Value;
        Session["C70"] = txtComentarios70.Value; Session["C71"] = txtComentarios71.Value; Session["C72"] = txtComentarios72.Value; Session["C73"] = txtComentarios73.Value; Session["C74"] = txtComentarios74.Value;
        Response.Redirect("FormDetalle05Nuevo.aspx?pagina=5");
    }
    #endregion
}
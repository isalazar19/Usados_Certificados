using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Usados_Certificados_FormDetalle01Nuevo : System.Web.UI.Page
{
    public string vLiteral = "";
    SqlConnection conSQL = new SqlConnection(ConfigurationManager.ConnectionStrings["SAP_WEBConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //cargar_tabla();
            if (Session["P1"] != null && Session["P2"] != null && Session["P3"] != null && Session["P4"] != null && Session["P5"] != null && Session["P6"] != null && Session["P7"] != null &&
                Session["P8"] != null && Session["P9"] != null && Session["P10"] != null && Session["P11"] != null && Session["P12"] != null && Session["P13"] != null && Session["P14"] != null &&
                Session["P15"] != null && Session["P16"] != null && Session["P17"] != null && Session["P18"] != null && Session["P19"] != null && Session["P20"] != null && Session["P21"] != null)
            {
                DDL1.SelectedValue = Session["P1"].ToString(); DDL2.SelectedValue = Session["P2"].ToString(); DDL3.SelectedValue = Session["P3"].ToString();
                DDL4.SelectedValue = Session["P4"].ToString(); DDL5.SelectedValue = Session["P5"].ToString(); DDL6.SelectedValue = Session["P6"].ToString();
                DDL7.SelectedValue = Session["P7"].ToString(); DDL8.SelectedValue = Session["P8"].ToString(); DDL9.SelectedValue = Session["P9"].ToString();
                DDL10.SelectedValue = Session["P10"].ToString(); DDL11.SelectedValue = Session["P11"].ToString(); DDL12.SelectedValue = Session["P12"].ToString();
                DDL13.SelectedValue = Session["P13"].ToString(); DDL14.SelectedValue = Session["P14"].ToString(); DDL15.SelectedValue = Session["P15"].ToString();
                DDL16.SelectedValue = Session["P16"].ToString(); DDL17.SelectedValue = Session["P17"].ToString(); DDL18.SelectedValue = Session["P18"].ToString();
                DDL19.SelectedValue = Session["P19"].ToString(); DDL20.SelectedValue = Session["P20"].ToString(); DDL21.SelectedValue = Session["P21"].ToString();
                /* Comentarios */
                txtComentarios1.Value = Session["C1"].ToString(); txtComentarios2.Value = Session["C2"].ToString(); txtComentarios3.Value = Session["C3"].ToString();
                txtComentarios4.Value = Session["C4"].ToString(); txtComentarios5.Value = Session["C5"].ToString(); txtComentarios6.Value = Session["C6"].ToString();
                txtComentarios7.Value = Session["C7"].ToString(); txtComentarios8.Value = Session["C8"].ToString(); txtComentarios9.Value = Session["C9"].ToString();
                txtComentarios10.Value = Session["C10"].ToString(); txtComentarios11.Value = Session["C11"].ToString(); txtComentarios12.Value = Session["C12"].ToString();
                txtComentarios13.Value = Session["C13"].ToString(); txtComentarios14.Value = Session["C14"].ToString(); txtComentarios15.Value = Session["C15"].ToString();
                txtComentarios16.Value = Session["C16"].ToString(); txtComentarios17.Value = Session["C17"].ToString(); txtComentarios18.Value = Session["C18"].ToString();
                txtComentarios19.Value = Session["C19"].ToString(); txtComentarios20.Value = Session["C20"].ToString(); txtComentarios21.Value = Session["C21"].ToString();
            }
        }
    }

    #region botones
    protected void btn_Atras_Click(object sender, EventArgs e)
    {
        Session["botonAtras"] = "si";
        Session["P1"] = DDL1.SelectedValue.ToString(); Session["P2"] = DDL2.SelectedValue.ToString(); Session["P3"] = DDL3.SelectedValue.ToString();
        Session["P4"] = DDL4.SelectedValue.ToString(); Session["P5"] = DDL5.SelectedValue.ToString(); Session["P6"] = DDL6.SelectedValue.ToString();
        Session["P7"] = DDL7.SelectedValue.ToString(); Session["P8"] = DDL8.SelectedValue.ToString(); Session["P9"] = DDL9.SelectedValue.ToString();
        Session["P10"] = DDL10.SelectedValue.ToString(); Session["P11"] = DDL11.SelectedValue.ToString(); Session["P12"] = DDL12.SelectedValue.ToString();
        Session["P13"] = DDL13.SelectedValue.ToString(); Session["P14"] = DDL14.SelectedValue.ToString(); Session["P15"] = DDL15.SelectedValue.ToString();
        Session["P16"] = DDL16.SelectedValue.ToString(); Session["P17"] = DDL17.SelectedValue.ToString(); Session["P18"] = DDL18.SelectedValue.ToString();
        Session["P19"] = DDL19.SelectedValue.ToString(); Session["P20"] = DDL20.SelectedValue.ToString(); Session["P21"] = DDL21.SelectedValue.ToString();
        /* Comentarios */
        Session["C1"] = txtComentarios1.Value; Session["C2"] = txtComentarios2.Value; Session["C3"] = txtComentarios3.Value; Session["C4"] = txtComentarios4.Value; Session["C5"] = txtComentarios5.Value; Session["C6"] = txtComentarios6.Value; Session["C7"] = txtComentarios7.Value;
        Session["C8"] = txtComentarios8.Value; Session["C9"] = txtComentarios9.Value; Session["C10"] = txtComentarios10.Value; Session["C11"] = txtComentarios11.Value; Session["C12"] = txtComentarios12.Value; Session["C13"] = txtComentarios13.Value; Session["C14"] = txtComentarios14.Value;
        Session["C15"] = txtComentarios15.Value; Session["C16"] = txtComentarios16.Value; Session["C17"] = txtComentarios17.Value; Session["C18"] = txtComentarios18.Value; Session["C19"] = txtComentarios19.Value; Session["C20"] = txtComentarios20.Value; Session["C21"] = txtComentarios21.Value;

        Response.Redirect("FormularioCertificacionNuevo.aspx?pagina=1");
    }
    protected void btn_Siguiente_Click(object sender, EventArgs e)
    {
        if (DDL1.SelectedValue == "0" || DDL2.SelectedValue == "0" || DDL3.SelectedValue == "0" || DDL4.SelectedValue == "0" || DDL5.SelectedValue == "0" || DDL6.SelectedValue == "0" || DDL7.SelectedValue == "0" ||
            DDL8.SelectedValue == "0" || DDL9.SelectedValue == "0" || DDL10.SelectedValue == "0" || DDL11.SelectedValue == "0" || DDL12.SelectedValue == "0" || DDL13.SelectedValue == "0" || DDL14.SelectedValue == "0" ||
            DDL15.SelectedValue == "0" || DDL16.SelectedValue == "0" || DDL17.SelectedValue == "0" || DDL18.SelectedValue == "0" || DDL19.SelectedValue == "0" || DDL20.SelectedValue == "0" || DDL21.SelectedValue == "0")
        { Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "MensajeValidaResultado();", true); return; }
        Session["P1"] = DDL1.SelectedValue.ToString(); Session["P2"] = DDL2.SelectedValue.ToString(); Session["P3"] = DDL3.SelectedValue.ToString();
        Session["P4"] = DDL4.SelectedValue.ToString(); Session["P5"] = DDL5.SelectedValue.ToString(); Session["P6"] = DDL6.SelectedValue.ToString();
        Session["P7"] = DDL7.SelectedValue.ToString(); Session["P8"] = DDL8.SelectedValue.ToString(); Session["P9"] = DDL9.SelectedValue.ToString();
        Session["P10"] = DDL10.SelectedValue.ToString(); Session["P11"] = DDL11.SelectedValue.ToString(); Session["P12"] = DDL12.SelectedValue.ToString();
        Session["P13"] = DDL13.SelectedValue.ToString(); Session["P14"] = DDL14.SelectedValue.ToString(); Session["P15"] = DDL15.SelectedValue.ToString();
        Session["P16"] = DDL16.SelectedValue.ToString(); Session["P17"] = DDL17.SelectedValue.ToString(); Session["P18"] = DDL18.SelectedValue.ToString();
        Session["P19"] = DDL19.SelectedValue.ToString(); Session["P20"] = DDL20.SelectedValue.ToString(); Session["P21"] = DDL21.SelectedValue.ToString();
        /* Comentarios */
        Session["C1"] = txtComentarios1.Value; Session["C2"] = txtComentarios2.Value; Session["C3"] = txtComentarios3.Value; Session["C4"] = txtComentarios4.Value; Session["C5"] = txtComentarios5.Value; Session["C6"] = txtComentarios6.Value; Session["C7"] = txtComentarios7.Value;
        Session["C8"] = txtComentarios8.Value; Session["C9"] = txtComentarios9.Value; Session["C10"] = txtComentarios10.Value; Session["C11"] = txtComentarios11.Value; Session["C12"] = txtComentarios12.Value; Session["C13"] = txtComentarios13.Value; Session["C14"] = txtComentarios14.Value;
        Session["C15"] = txtComentarios15.Value; Session["C16"] = txtComentarios16.Value; Session["C17"] = txtComentarios17.Value; Session["C18"] = txtComentarios18.Value; Session["C19"] = txtComentarios19.Value; Session["C20"] = txtComentarios20.Value; Session["C21"] = txtComentarios21.Value;

        Response.Redirect("FormDetalle02Nuevo.aspx?pagina=2");
    }
    #endregion

    #region ARMAR_PLANILLA
    protected void cargar_tabla()
    {
        vLiteral = vLiteral + "<table class='table' id='GridView1' style='border-collapse: collapse; width: 100%;' border='1' rules='all' cellspacing='0'>";
        vLiteral = vLiteral + "<tr>";
        vLiteral = vLiteral + "    <th style='background-color: Silver;' scope='col' colspan='2'>";
        vLiteral = vLiteral + "        (I) CONDICION, APARIENCIA EXTERIOR, ILUMINACIÓN E INDICADORES";
        vLiteral = vLiteral + "    </th>";
        vLiteral = vLiteral + "    <th style='background-color: Silver;' scope='col'>";
        vLiteral = vLiteral + "        Resultado";
        vLiteral = vLiteral + "    </th>";
        vLiteral = vLiteral + "    <th style='background-color: Silver;' scope='col'>";
        vLiteral = vLiteral + "        Comentarios";
        vLiteral = vLiteral + "    </th>";
        vLiteral = vLiteral + "</tr>";

        try
        {
            string SQL = "select id,pregunta from usados_cert_preguntas where id_seccion=1";
            SqlDataAdapter adpt = new SqlDataAdapter(SQL, conSQL);
            DataTable tbl = new DataTable();
            tbl = new DataTable("datos");
            adpt.Fill(tbl);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                string Id = tbl.Rows[i]["id"].ToString();
                string pregunta = tbl.Rows[i]["pregunta"].ToString();

                vLiteral = vLiteral + "<tr>";
                vLiteral = vLiteral + "<td>"+ Id + "</td>";
                vLiteral = vLiteral + "<td style='text-align: justify;'>" + pregunta + "</td>";
                vLiteral = vLiteral + "<td>";
                vLiteral = vLiteral + "    <div class='input-control select' style='width: 125%; margin-left: -11px;'>";
                vLiteral = vLiteral + "        <select name='resultado" + Id + "' id='resultado" + Id + "' runat='server'>";
                vLiteral = vLiteral + "            <option value='' disabled selected>Seleccione...</option>";
                vLiteral = vLiteral + "            <option value='1'>OK</option>";
                vLiteral = vLiteral + "            <option value='2'>N/A</option>";
                vLiteral = vLiteral + "            <option value='3'>Reparar</option>";
                vLiteral = vLiteral + "            <option value='4'>Reemplazar</option>";
                vLiteral = vLiteral + "        </select>";
                vLiteral = vLiteral + "    </div>";
                //vLiteral = vLiteral + "    <div class='input-control select' style='width: 125%; margin-left: -11px;'>";
                //vLiteral = vLiteral + "        <asp:DropDownList ID='DDL" + Id + "' runat='server'>";
                //vLiteral = vLiteral + "            <asp:ListItem Value='0'>Seleccione...</asp:ListItem>";
                //vLiteral = vLiteral + "            <asp:ListItem Value='1'>OK</asp:ListItem>";
                //vLiteral = vLiteral + "            <asp:ListItem Value='2'>N/A</asp:ListItem>";
                //vLiteral = vLiteral + "            <asp:ListItem Value='3'>Reparar</asp:ListItem>";
                //vLiteral = vLiteral + "            <asp:ListItem Value='4'>Reemplazar</asp:ListItem>";
                //vLiteral = vLiteral + "        </asp:DropDownList>";
                //vLiteral = vLiteral + "    </div>";
                vLiteral = vLiteral + "</td>";
                vLiteral = vLiteral + "<td width='30%'>";
                vLiteral = vLiteral + "    <label>";
                vLiteral = vLiteral + "        <textarea maxlength='500'  runat='server' id='txtComentarios" + Id + "' style='height: 45px; -ms-overflow-y: hidden; width: 98%;'></textarea>";
                vLiteral = vLiteral + "    </label>";
                vLiteral = vLiteral + "</td>";
                vLiteral = vLiteral + "</tr>";
            }
        }
        catch (Exception ex)
        { if (conSQL != null) conSQL.Close(); }
        finally { if (conSQL != null) conSQL.Close(); }

        vLiteral = vLiteral + "</table>";
        //Panel1.Controls.Add(new LiteralControl(vLiteral));
    }
    #endregion
     
}
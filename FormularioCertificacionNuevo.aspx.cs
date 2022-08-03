using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Usados_Certificados_FormularioCertificacionNuevo : System.Web.UI.Page
{
    DateTime fechaActual = DateTime.Now;
    public string p1 = "";
    public string p2 = "";
    public string p3 = "";
    public string p4 = "";
    public string p5 = "";
    public string p6 = "";
    public string p7 = "";
    public string p8 = "";
    public string p9 = "";
    public string p10 = "";
    public string p11 = "";
    public string p12 = "";
    public string p13 = "";
    public string p14 = "";
    public string p15 = "";
    public string p16 = "";
    public string p17 = "";
    public string p18 = "";
    public string p19 = "";
    public string p20 = "";
    public string p21 = "";

    SqlConnection conSQL = new SqlConnection(ConfigurationManager.ConnectionStrings["SAP_WEBConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["botonAtras"] == "si")
            {
                txtNumStock.Value = Session["Stock"].ToString();
                txtVIN.Value = Session["VIN"].ToString();
                txtModelo.Value = Session["Modelo"].ToString();
                txtVersion.Value = Session["Version"].ToString();
                txtPatente.Value = Session["Patente"].ToString();
                txtKmsActual.Value = Session["Kms"].ToString();
                txtFechaVenta.Value = Session["FechaVta"].ToString();
                txtAñoUso.Value = Session["AñoUso"].ToString();
                txtOT.Value = Session["OT"].ToString();
                if (Session["30d"] == "1") chk30d.Checked = true;
                if (Session["10k"] == "10") chk10k.Checked = true;
                if (Session["20k"] == "20") chk20k.Checked = true;
                if (Session["30k"] == "30") chk30k.Checked = true;
                if (Session["40k"] == "40") chk40k.Checked = true;
                if (Session["50k"] == "50") chk50k.Checked = true;
                if (Session["60k"] == "60") chk60k.Checked = true;
                if (Session["70k"] == "70") chk70k.Checked = true;
                if (Session["80k"] == "80") chk80k.Checked = true;
                if (Session["90k"] == "90") chk90k.Checked = true;
                txtComentarios.Value =Session["Comentarios"].ToString();
                txtFechaUltMant.Value = Session["FechaUltMant"].ToString();

                p1 = Session["P1"].ToString(); p2 = Session["P2"].ToString(); p3 = Session["P3"].ToString(); p4 = Session["P4"].ToString(); p5 = Session["P5"].ToString(); p6 = Session["P6"].ToString(); p7 = Session["P7"].ToString();
                p8 = Session["P8"].ToString(); p9 = Session["P9"].ToString(); p10 = Session["P10"].ToString(); p11 = Session["P11"].ToString(); p12 = Session["P12"].ToString(); p13 = Session["P13"].ToString(); p14 = Session["P14"].ToString();
                p15 = Session["P15"].ToString(); p16 = Session["P16"].ToString(); p17 = Session["P17"].ToString(); p18 = Session["P18"].ToString(); p19 = Session["P19"].ToString(); p20 = Session["P20"].ToString(); p21 = Session["P21"].ToString();

            }
            Session["botonAtras"] = "no";
        }
    }

    #region botones
    protected void btnBuscarStock_Click(object sender, EventArgs e)
    {
        txtVIN.Value = "";
        txtVIN.Value = "";
        txtModelo.Value = "";
        txtVersion.Value = "";
        txtPatente.Value = "";
        txtKmsActual.Value = "";
        txtFechaVenta.Value = "";
        txtAñoUso.Value = "";
        txtOT.Value = "";
        chk30d.Checked = false;
        chk10k.Checked = false;
        chk20k.Checked = false;
        chk30k.Checked = false;
        chk40k.Checked = false;
        chk50k.Checked = false;
        chk60k.Checked = false;
        chk70k.Checked = false;
        chk80k.Checked = false;
        chk90k.Checked = false;

        string NumStock = "";
        if (txtNumStock.Value == "")
        { Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "MensajeValidaStock();", true); return; }
        if (txtNumStock.Value.Length < 10)
        { NumStock = txtNumStock.Value.PadLeft(10, '0'); }
        else
        { NumStock = txtNumStock.Value; }

        traerDatosVeh(txtNumStock.Value);
        traerDatosRev(txtNumStock.Value);
    }
    protected void btn_Atras_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "closewindows", "parent.jQuery.fancybox.close();", true);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "closewindows", "parent.jQuery.fancybox.close();", true);
    }
    protected void btn_Siguiente_Click(object sender, EventArgs e)
    {
        if (txtOT.Value == "")
        { Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "MensajeValidaOT();", true); return; }
        /* Asignar las variables de sesion */
        Session["Stock"] = txtNumStock.Value;
        Session["VIN"] = txtVIN.Value;
        Session["Modelo"] = txtModelo.Value;
        Session["Version"] = txtVersion.Value;
        Session["Patente"] = txtPatente.Value;
        Session["Kms"] = txtKmsActual.Value;
        Session["FechaVta"] = txtFechaVenta.Value;
        Session["AñoUso"] = txtAñoUso.Value;
        Session["OT"] = txtOT.Value;
        if (chk30d.Checked == true)
            Session["30d"] = "1";
        if (chk10k.Checked == true)
            Session["10k"] = "10";
        if (chk20k.Checked == true)
            Session["20k"] = "20";
        if (chk30k.Checked == true)
            Session["30k"] = "30";
        if (chk40k.Checked == true)
            Session["40k"] = "40";
        if (chk50k.Checked == true)
            Session["50k"] = "50";
        if (chk60k.Checked == true)
            Session["60k"] = "60";
        if (chk70k.Checked == true)
            Session["70k"] = "70";
        if (chk80k.Checked == true)
            Session["80k"] = "80";
        if (chk90k.Checked == true)
            Session["90k"] = "90";
        Session["Comentarios"] = txtComentarios.Value;
        Session["FechaUltMant"] = txtFechaUltMant.Value;

        Response.Redirect("FormDetalle01Nuevo.aspx?pagina=1");
    }
    #endregion

    #region DATOS_VEHICULO
    protected void traerDatosVeh(string _Stock)
    {
        string SQL = "";
        if (_Stock.Length < 10)
        {
            _Stock = _Stock.PadLeft(10, '0');
        }
        SQL = "use sap_web_pro";
        SQL = SQL + " " + "select (select patente from garantiaregistro (nolock)";
        SQL = SQL + " " + "where vehsto=a.numero_stock) as patente,";
        SQL = SQL + " " + "(select garFecReg from garantiaregistro (nolock)";
        SQL = SQL + " " + "where vehsto=a.numero_stock) as fecha_venta,";
        SQL = SQL + " " + "(select linea from modelopcion where modelo=a.modelo and  opcion=a.opcion) as modelo,codigo_version,";
        SQL = SQL + " " + "(select descripcion_valor from caracteristicas_vehiculos (nolock)";
        SQL = SQL + " " + "where numero_stock=a.numero_stock and caracteristica='C_COLOR') as color,SUBSTRING(MesAno_Produccion,1,4) as AñoVeh";
        SQL = SQL + " " + ",Numero_Vin";
        SQL = SQL + " " + "from maestro_vehiculos a (nolock)";
        SQL = SQL + " " + "where numero_stock='" + _Stock + "'";
        conSQL.Open();
        try
        {
            SqlDataAdapter ad = new SqlDataAdapter(SQL, conSQL);
            DataTable tbl = new DataTable();
            tbl = new DataTable("miVeh");
            ad.Fill(tbl);
            if (tbl.Rows.Count > 0)
            {
                txtVIN.Value = tbl.Rows[0]["Numero_Vin"].ToString().Trim();
                txtPatente.Value = tbl.Rows[0]["patente"].ToString().Trim();
                txtModelo.Value = tbl.Rows[0]["modelo"].ToString().Trim();
                txtVersion.Value = tbl.Rows[0]["codigo_version"].ToString().Trim();
                txtFechaVenta.Value = tbl.Rows[0]["fecha_venta"].ToString().Substring(0,10);
                //txtColor.Value = tbl.Rows[0]["color"].ToString().Trim();
                //txtAñoVeh.Value = tbl.Rows[0]["AñoVeh"].ToString().Trim();
                DateTime fechaVenta = Convert.ToDateTime(txtFechaVenta.Value);
                txtAñoUso.Value = DiferenciaFechas(fechaActual, fechaVenta);
            }
        }
        catch (Exception ex)
        { }
        finally
        { if (conSQL != null) conSQL.Close(); }
    }
    private String DiferenciaFechas(DateTime newdt, DateTime olddt)
    {
        Int32 anios;
        Int32 meses;
        Int32 dias;
        String str = "";

        anios = (newdt.Year - olddt.Year);
        meses = (newdt.Month - olddt.Month);
        dias = (newdt.Day - olddt.Day);

        if (meses < 0)
        {
            anios -= 1;
            meses += 12;
        }
        if (dias < 0)
        {
            meses -= 1;
            dias += DateTime.DaysInMonth(newdt.Year, newdt.Month);
        }

        if (anios < 0)
        {
            return "Fecha Invalida";
        }
        if (anios > 0)
            if (anios == 1)
                str = str + anios.ToString() + " año ";
            else
                str = str + anios.ToString() + " años ";
        if (meses > 0)
            if (meses == 1)
                str = str + meses.ToString() + " mes ";
            else
                str = str + meses.ToString() + " meses ";
        if (dias > 0)
            if (dias == 1)
                str = str + dias.ToString() + " día ";
            else
                str = str + dias.ToString() + " días ";

        return str;
    }
    #endregion

    #region DATOS_MANTENCIONES
    protected void traerDatosRev(string _Stock)
    {
        string SQL = "";
        if (_Stock.Length < 10)
        {
            _Stock = _Stock.PadLeft(10, '0');
        }
        txtNumStock.Value = _Stock;
        conSQL.Open();
        SQL = "use sap_web_pro";
        SQL = SQL + " " + "EXEC Sp_Lst_Vehiculos_Mantencion_All '" + _Stock + "'";
        try
        {
            SqlDataAdapter ad = new SqlDataAdapter(SQL, conSQL);
            DataTable tbl = new DataTable();
            tbl = new DataTable("miRev");
            ad.Fill(tbl);
            int contar = tbl.Rows.Count;
            if (contar > 0)
            {
                for (int i = 0; i < contar; i++)
                {
                    int revision = Convert.ToInt32(tbl.Rows[i]["RevNumero"].ToString());
                    if (revision == 1)
                        chk30d.Checked = true;
                    if (revision == 10)
                        chk10k.Checked = true;
                    if (revision == 20)
                        chk20k.Checked = true;
                    if (revision == 30)
                        chk30k.Checked = true;
                    if (revision == 40)
                        chk40k.Checked = true;
                    if (revision == 50)
                        chk50k.Checked = true;
                    if (revision == 60)
                        chk60k.Checked = true;
                    if (revision == 70)
                        chk70k.Checked = true;
                    if (revision == 80)
                        chk80k.Checked = true;
                    if (revision == 90)
                        chk90k.Checked = true;

                    if (i == 0)
                    {
                        txtKmsActual.Value = tbl.Rows[i]["RevKms"].ToString();
                        txtFechaUltMant.Value = tbl.Rows[i]["RevFec"].ToString().Substring(0,10);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("<font color=red><b>" + ex.Message + "</b></font>");

        }
        finally
        { if (conSQL != null) conSQL.Close(); }

    }
    #endregion
}
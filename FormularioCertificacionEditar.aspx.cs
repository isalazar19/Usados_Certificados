using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Usados_Certificados_FormularioCertificacionEditar : System.Web.UI.Page
{
    public string stock = "";
    public string estado = "";
    SqlConnection conSQL = new SqlConnection(ConfigurationManager.ConnectionStrings["SAP_WEBConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null && Request.QueryString["estat"] != null)
            {
                stock = Request.QueryString["id"].ToString();
                estado = Request.QueryString["estat"].ToString();
                if (estado != "Pendiente")
                {
                    aprob.Attributes.Add("style", "visibility:hidden;");
                    rechaz.Attributes.Add("style", "visibility:hidden;");
                    btn_Guardar.Visible = false;
                }
                txtNumStock.Value = stock;
                traer_datos(stock);
                traerDatosRev(txtNumStock.Value);
            }
        }
    }

    #region botones
    protected void btn_Ver_Click(object sender, EventArgs e)
    {
        Response.Redirect("VerPlanilla.aspx?id=" + txtNumStock.Value + "&estat=" + estado);   
    }
    protected void btn_Salir_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "closewindows", "parent.jQuery.fancybox.close();", true);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "closewindows", "parent.jQuery.fancybox.close();", true);
    }
    protected void btn_Guardar_Click(object sender, EventArgs e)
    {
        string estado_nuevo = "";
        if (rb_aprobar.Checked == true) estado_nuevo = "A";
        if (rb_rechazar.Checked == true) estado_nuevo = "R";
        /* colocar la fecha de vencimiento */
        DateTime fechaHoy = DateTime.Now;
        DateTime fechaVen = fechaHoy.AddDays(365);
        string fechaVcto = Convert.ToString(fechaVen).Substring(0,10);

        string SqlUpdt = "";
        SqlUpdt = "UPDATE usados_certificados_header";
        SqlUpdt = SqlUpdt + " " + "SET Estado='" + estado_nuevo;
        SqlUpdt = SqlUpdt + "', " + "fecha_vence='" + fechaVcto;
        SqlUpdt = SqlUpdt + "' " + "WHERE numero_stock='" + txtNumStock.Value + "'";
        try
        {
            conSQL.Open();
            SqlCommand cmd = new SqlCommand(SqlUpdt, conSQL);
            cmd.ExecuteNonQuery();
            string script = @"<script type='text/javascript'>
                                        openCustom();
                                    </script>";

            ClientScript.RegisterStartupScript(this.GetType(), "invocarfuncion", script, false);
            Enviar_Correo(estado_nuevo, txtNumStock.Value, txtPatente.Value, txtModelo.Value, txtVersion.Value);
        }
        catch (Exception ex)
        {
            string script = @"<script type='text/javascript'>
                                         setTimeout(function () {
                                            $.Notify({ type: 'alert', caption: 'Aviso', content: 'Ocurrio un error de Excepción', icon: '<span class='mif-warning'></span>' });
                                            }, 1000);
                                        </script>";

            ClientScript.RegisterStartupScript(this.GetType(), "invocarfuncion", script, false);
        }
        finally
        { if (conSQL != null) conSQL.Close(); }
    }
    #endregion

    #region BD
    protected void traer_datos(string _stock)
    {
        string SQL = "SELECT * FROM usados_certificados_header WhERE numero_stock='" + _stock + "'";
        conSQL.Open();
        try
        {
            SqlDataAdapter ad = new SqlDataAdapter(SQL, conSQL);
            DataTable tbl = new DataTable();
            tbl = new DataTable("miTabla");
            ad.Fill(tbl);
            if (tbl.Rows.Count > 0)
            {
                txtVIN.Value = tbl.Rows[0]["VIN"].ToString();
                txtModelo.Value = tbl.Rows[0]["Modelo"].ToString();
                txtVersion.Value = tbl.Rows[0]["Codigo_Version"].ToString();
                txtPatente.Value = tbl.Rows[0]["Patente"].ToString();
                txtKmsActual.Value = tbl.Rows[0]["Kilometraje"].ToString();
                txtFechaVenta.Value = tbl.Rows[0]["Fecha_Venta"].ToString();
                txtAñoUso.Value = tbl.Rows[0]["ano_uso"].ToString();
                txtOT.Value = tbl.Rows[0]["numero_ot"].ToString();
                txtComentarios.Value = tbl.Rows[0]["comentarios"].ToString();
                bool mant_30d = Convert.ToBoolean(tbl.Rows[0]["mant_30d"].ToString());
                bool mant_10k = Convert.ToBoolean(tbl.Rows[0]["mant_10k"].ToString());
                bool mant_20k = Convert.ToBoolean(tbl.Rows[0]["mant_20k"].ToString());
                bool mant_30k = Convert.ToBoolean(tbl.Rows[0]["mant_30k"].ToString());
                bool mant_40k = Convert.ToBoolean(tbl.Rows[0]["mant_40k"].ToString());
                bool mant_50k = Convert.ToBoolean(tbl.Rows[0]["mant_50k"].ToString());
                bool mant_60k = Convert.ToBoolean(tbl.Rows[0]["mant_60k"].ToString());
                bool mant_70k = Convert.ToBoolean(tbl.Rows[0]["mant_70k"].ToString());
                bool mant_80k = Convert.ToBoolean(tbl.Rows[0]["mant_80k"].ToString());
                bool mant_90k = Convert.ToBoolean(tbl.Rows[0]["mant_90k"].ToString());
                if (mant_30d == true) chk30d.Checked = true;
                if (mant_10k == true) chk10k.Checked = true;
                if (mant_20k == true) chk20k.Checked = true;
                if (mant_30k == true) chk30k.Checked = true;
                if (mant_40k == true) chk40k.Checked = true;
                if (mant_50k == true) chk50k.Checked = true;
                if (mant_60k == true) chk60k.Checked = true;
                if (mant_70k == true) chk70k.Checked = true;
                if (mant_80k == true) chk80k.Checked = true;
                if (mant_90k == true) chk90k.Checked = true;
            }
        }
        catch (Exception ex)
        { }
        finally
        { if (conSQL != null) conSQL.Close(); }
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
                    if (i == 0)
                    {
                        txtFechaUltMant.Value = tbl.Rows[i]["RevFec"].ToString().Substring(0, 10);
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

    #region CORREO
    protected void Enviar_Correo(string estado, string stock, string patente, string modelo, string version)
    {
        string _correoDestinatario = "";
        string DesEstado = "";
        if (estado == "A") DesEstado = "Aprobado";
        if (estado == "R") DesEstado = "Rechazado";

        string texto = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>";
        texto = texto + "<html>";

        texto = texto + "<head>";
        texto = texto + "    <meta charset='UTF-8'>";
        texto = texto + "    <meta name='viewport' content='width=device-width, initial-scale=1'>";
        texto = texto + "    <meta name='x-apple-disable-message-reformatting'>";
        texto = texto + "    <meta http-equiv='X-UA-Compatible' content='IE=edge'>";
        texto = texto + "    <meta name='format-detection' content='telephone=no'>";
        texto = texto + "    <link href='css/email.css' rel='stylesheet' type='text/css' />";
        texto = texto + "    <title></title>";
        texto = texto + "    <!--[if (mso 16)]>";
        texto = texto + "    <style type='text/css'>";
        texto = texto + "    a {text-decoration: none;}";
        texto = texto + "    </style>";
        texto = texto + "    <![endif]-->";
        texto = texto + "    <!--[if gte mso 9]><style>sup { font-size: 100% !important; }</style><![endif]-->";
        texto = texto + "    <!--[if !mso]><!-- -->";
        texto = texto + "    <link href='https://fonts.googleapis.com/css?family=Roboto:400,400i,700,700i' rel='stylesheet'>";
        texto = texto + "    <!--<![endif]-->";
        texto = texto + "</head>";

        texto = texto + "<body>";
        texto = texto + "    <div class='es-wrapper-color'>";
        texto = texto + "        <!--[if gte mso 9]>";
        texto = texto + "	        <v:background xmlns:v='urn:schemas-microsoft-com:vml' fill='t'>";
        texto = texto + "		        <v:fill type='tile' color='#f6f6f6'></v:fill>";
        texto = texto + "	        </v:background>";
        texto = texto + "        <![endif]-->";
        texto = texto + "        <table width='100%' class='es-wrapper' cellspacing='0' cellpadding='0'>";
        texto = texto + "            <tbody>";
        texto = texto + "                <tr>";
        texto = texto + "                    <td class='esd-email-paddings' valign='top'>";
        texto = texto + "                        <table align='center' class='es-content esd-header-popover' cellspacing='0' cellpadding='0'>";
        texto = texto + "                            <tbody>";
        texto = texto + "                                <tr>";
        texto = texto + "                                    <td align='center' class='esd-stripe'>";
        texto = texto + "                                        <table width='600' align='center' class='es-content-body' style='background-color: transparent;' bgcolor='transparent' cellspacing='0' cellpadding='0'>";
        texto = texto + "                                            <tbody>";
        texto = texto + "                                                <tr>";
        texto = texto + "                                                    <td align='left' class='esd-structure es-p10t es-p10b es-p20r es-p20l'>";
        texto = texto + "                                                        <table width='100%' cellspacing='0' cellpadding='0'>";
        texto = texto + "                                                            <tbody>";
        texto = texto + "                                                                <tr>";
        texto = texto + "                                                                    <td width='560' align='center' class='esd-container-frame' valign='top'>";
        texto = texto + "                                                                        <table width='100%' cellspacing='0' cellpadding='0'>";
        texto = texto + "                                                                            <tbody>";
        texto = texto + "                                                                                <tr>";
        texto = texto + "                                                                                    <td align='left' class='esd-block-text es-infoblock es-m-txt-c'>";
        texto = texto + "                                                                                        <p></p>";
        texto = texto + "                                                                                    </td>";
        texto = texto + "                                                                                </tr>";
        texto = texto + "                                                                            </tbody>";
        texto = texto + "                                                                        </table>";
        texto = texto + "                                                                    </td>";
        texto = texto + "                                                                </tr>";
        texto = texto + "                                                            </tbody>";
        texto = texto + "                                                        </table>";
        texto = texto + "                                                    </td>";
        texto = texto + "                                                </tr>";
        texto = texto + "                                            </tbody>";
        texto = texto + "                                        </table>";
        texto = texto + "                                    </td>";
        texto = texto + "                                </tr>";
        texto = texto + "                            </tbody>";
        texto = texto + "                        </table>";
        //texto = texto + "                        <table align='center' class='es-content' cellspacing='0' cellpadding='0'>";
        //texto = texto + "                            <tbody>";
        //texto = texto + "                                <tr>";
        //texto = texto + "                                    <td align='center' class='esd-stripe' esd-custom-block-id='61187'>";
        //texto = texto + "                                        <table width='600' align='center' class='es-content-body' style='background-color: transparent;' bgcolor='transparent' cellspacing='0' cellpadding='0'>";
        //texto = texto + "                                            <tbody>";
        //texto = texto + "                                                <tr>";
        //texto = texto + "                                                    <td align='left' class='esd-structure' style='background-position: center bottom;'>";
        //texto = texto + "                                                        <table width='100%' cellspacing='0' cellpadding='0'>";
        //texto = texto + "                                                            <tbody>";
        //texto = texto + "                                                                <tr>";
        //texto = texto + "                                                                    <td width='600' align='center' class='esd-container-frame' valign='top'>";
        //texto = texto + "                                                                        <table width='100%' style='background-color: rgb(255, 255, 255);' bgcolor='#ffffff' cellspacing='0' cellpadding='0'>";
        //texto = texto + "                                                                            <tbody>";
        //texto = texto + "                                                                                <tr>";
        //texto = texto + "                                                                                    <td align='left' class='esd-block-image'><a target='_blank'><img width='210' class='adapt-img' style='display: block;' alt src='imagenes\\Logo_toyota3.jpg'></a></td>";
        //texto = texto + "                                                                                </tr>";
        //texto = texto + "                                                                            </tbody>";
        //texto = texto + "                                                                        </table>";
        //texto = texto + "                                                                    </td>";
        //texto = texto + "                                                                </tr>";
        //texto = texto + "                                                            </tbody>";
        //texto = texto + "                                                        </table>";
        //texto = texto + "                                                    </td>";
        //texto = texto + "                                                </tr>";
        //texto = texto + "                                            </tbody>";
        //texto = texto + "                                        </table>";
        //texto = texto + "                                    </td>";
        //texto = texto + "                                </tr>";
        //texto = texto + "                            </tbody>";
        //texto = texto + "                        </table>";
        texto = texto + "                        <table align='center' class='es-content' cellspacing='0' cellpadding='0'>";
        texto = texto + "                            <tbody>";
        texto = texto + "                                <tr>";
        texto = texto + "                                    <td align='center' class='esd-stripe' esd-custom-block-id='61188'>";
        texto = texto + "                                        <table width='600' align='center' class='es-content-body' style='border-top:4px solid #cc0000;background-color: transparent;' bgcolor='transparent' cellspacing='0' cellpadding='0'>";
        texto = texto + "                                            <tbody>";
        texto = texto + "                                                <tr>";
        texto = texto + "                                                    <td align='left' class='esd-structure es-p20b' style='background-position: center top;'>";
        texto = texto + "                                                        <table width='100%' cellspacing='0' cellpadding='0'>";
        texto = texto + "                                                            <tbody>";
        texto = texto + "                                                                <tr>";
        texto = texto + "                                                                    <td width='600' align='center' class='esd-container-frame' valign='top'>";
        texto = texto + "                                                                        <table width='100%' style='background-position: center bottom; background-color: rgb(255, 255, 255); border-radius: 5px; border-collapse: separate;' bgcolor='#ffffff' cellspacing='0' cellpadding='0'>";
        texto = texto + "                                                                            <tbody>";
        texto = texto + "                                                                                <tr>";
        texto = texto + "                                                                                    <td align='left' class='esd-block-text es-p20t es-p5b es-p20r es-p20l es-m-txt-l'>";
        texto = texto + "                                                                                        <h2>Estimados(as)</h2><br />";
        texto = texto + "                                                                                    </td>";
        texto = texto + "                                                                                </tr>";
        texto = texto + "                                                                                <tr>";
        texto = texto + "                                                                                    <td align='left' class='esd-block-text es-p10t es-p20r es-p20l'>";
        texto = texto + "                                                                                        <p>Junto con saludar, le informamos que hemos <strong><u>" + DesEstado + "</u></strong> y corresponde al siguiente vehículo:";
        texto = texto + "                                                                                        <br /><br /><strong> Stock: " + stock + "</strong>";
        texto = texto + "                                                                                        <br /><strong> Patente: " + patente + "</strong>";
        texto = texto + "                                                                                        <br /><strong> Modelo: " + modelo + ", " + version + "</strong></p><br />";
        texto = texto + "                                                                                    </td>";
        texto = texto + "                                                                                </tr>";
        //texto = texto + "                                                                                <tr>";
        //texto = texto + "                                                                                    <td align='left' class='esd-block-text es-p10t es-p5b es-p20r es-p20l'>";
        //texto = texto + "                                                                                        <p><br /></p>";
        //texto = texto + "                                                                                    </td>";
        //texto = texto + "                                                                                </tr>";
        texto = texto + "                                                                                <tr>";
        texto = texto + "                                                                                     <td align='left' class='esd-block-text es-p10t es-p20r es-p20l'>";
        texto = texto + "                                                                                        <p>Por favor, ingrese al portal en el siguiente link y siga las instrucciones indicadas en el manual del programa para su aprobación <strong></strong>";
        texto = texto + "                                                                                        <br /><a href='http://www.toyotachile.cl/Portal_sap_pro/Login.aspx'>Portal Concesionarios</a></p>";
        texto = texto + "                                                                                        <br /><strong>NOTA: FAVOR NO RESPONDER A ESTE CORREO</strong>";
        texto = texto + "                                                                                     </td>";
        //texto = texto + "                                                                                </tr>";
        //texto = texto + "                                                                                <tr>";
        //texto = texto + "                                                                                     <td align='left' class='esd-block-text es-p10t es-p20r es-p20l'>";
        //texto = texto + "                                                                                        <br />";
        //texto = texto + "                                                                                        <p><a href='http://www.toyotachile.cl/Portal_sap_pro/Login.aspx'>Portal Concesionarios</a></p>";
        //texto = texto + "                                                                                     <td><a href='http://www.toyotachile.cl/Portal_sap_pro/Login.aspx'>link</a>Haga clic aqui...</td>";
        texto = texto + "                                                                                </tr><tr></tr>";
        texto = texto + "                                                                                <tr>";
        texto = texto + "                                                                                    <td align='center' class='esd-block-text es-p10t es-p20b es-p20r es-p20l es-m-txt-c' bgcolor='#999999'>";
        texto = texto + "                                                                                        <p style='color: #ffffff;'><strong>USADOS CERTIFICADOS</strong></p>";
        texto = texto + "                                                                                    </td>";
        texto = texto + "                                                                                </tr>";
        texto = texto + "                                                                            </tbody>";
        texto = texto + "                                                                        </table>";
        texto = texto + "                                                                    </td>";
        texto = texto + "                                                                </tr>";
        texto = texto + "                                                            </tbody>";
        texto = texto + "                                                        </table>";
        texto = texto + "                                                    </td>";
        texto = texto + "                                                </tr>";
        texto = texto + "                                            </tbody>";
        texto = texto + "                                        </table>";
        texto = texto + "                                    </td>";
        texto = texto + "                                </tr>";
        texto = texto + "                            </tbody>";
        texto = texto + "                        </table>";
        texto = texto + "                        <table align='center' class='es-content esd-footer-popover' cellspacing='0' cellpadding='0'>";
        texto = texto + "                            <tbody>";
        texto = texto + "                                <tr>";
        texto = texto + "                                    <td align='center' class='esd-stripe'>";
        texto = texto + "                                        <table width='600' align='center' class='es-content-body' style='background-color: transparent;' bgcolor='transparent' cellspacing='0' cellpadding='0'>";
        texto = texto + "                                            <tbody>";
        texto = texto + "                                                <tr>";
        texto = texto + "                                                    <td align='left' class='esd-structure es-p30t es-p30b es-p20r es-p20l' style='background-position: left top;'>";
        texto = texto + "                                                        <table width='100%' cellspacing='0' cellpadding='0'>";
        texto = texto + "                                                            <tbody>";
        texto = texto + "                                                                <tr>";
        texto = texto + "                                                                    <td width='560' align='center' class='esd-container-frame' valign='top'>";
        texto = texto + "                                                                        <table width='100%' cellspacing='0' cellpadding='0'>";
        texto = texto + "                                                                            <tbody>";
        texto = texto + "                                                                                <tr>";
        texto = texto + "                                                                                    <td align='center' class='esd-empty-container' style='display: none;'></td>";
        texto = texto + "                                                                                </tr>";
        texto = texto + "                                                                            </tbody>";
        texto = texto + "                                                                        </table>";
        texto = texto + "                                                                    </td>";
        texto = texto + "                                                                </tr>";
        texto = texto + "                                                            </tbody>";
        texto = texto + "                                                        </table>";
        texto = texto + "                                                    </td>";
        texto = texto + "                                                </tr>";
        texto = texto + "                                            </tbody>";
        texto = texto + "                                        </table>";
        texto = texto + "                                    </td>";
        texto = texto + "                                </tr>";
        texto = texto + "                            </tbody>";
        texto = texto + "                        </table>";
        texto = texto + "                    </td>";
        texto = texto + "                </tr>";
        texto = texto + "            </tbody>";
        texto = texto + "        </table>";
        texto = texto + "    </div>";
        texto = texto + "</body>";

        texto = texto + "</html>";
        GenerarMail miEmail = new GenerarMail();
        miEmail.email = "fmerida@toyota.cl";
        miEmail.cc = "ivan.salazar@toyota.cl";
        miEmail.asunto = "Usados certificados – Formulario de Aprobación";
        miEmail.prioridad = 3;
        miEmail.mensaje = texto;
        miEmail.isHTML = true;

        miEmail.Enviar();
    }
    #endregion
}
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Usados_Certificados_FormularioReventa : System.Web.UI.Page
{
    public string CodConc = "";
    public string Usuario = "";
    SqlConnection conSQL = new SqlConnection(ConfigurationManager.ConnectionStrings["SAP_WEBConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LlenarComuna();
            if (Session["Cliente_Numero"] != null && Session["usuario"] != null)
            {
                CodConc = Session["Cliente_Numero"].ToString().Trim();
                if (CodConc == "TCL1")
                    precioMedio.Visible = true;
                else
                    precioMedio.Visible = false;
            }
            else
            {
                Response.Redirect("../Usados_Certificados/Default.aspx");
            }
        }
    }

    #region DROPDOWN
    protected void LlenarComuna()
    {
        string consulta1;
        try
        {
            ListItem item = new ListItem();
            item.Text = "Seleccione Comuna...";
            item.Value = "";
            DDLComuna.Items.Add(item);
            //
            consulta1 = "SELECT * FROM MAESTRO_CIUDAD_COMUNA ORDER BY 2";
            SqlDataAdapter adaptador1 = new SqlDataAdapter(consulta1, conSQL);
            DataTable table = new DataTable();
            table = new DataTable("micomuna");
            adaptador1.Fill(table);
            for (Int32 k = 0; k <= table.Rows.Count - 1; k++)
            {
                string ID_Comuna = table.Rows[k][0].ToString().Trim();
                string NB_Comuna = table.Rows[k][1].ToString().Trim();
                ListItem itemS2 = new ListItem();
                itemS2.Text = NB_Comuna;
                itemS2.Value = ID_Comuna;
                DDLComuna.Items.Add(itemS2);
            }
        }
        catch (Exception)
        {
            if (conSQL != null)
                conSQL.Close();
        }
        finally
        {
            if (conSQL != null)
                conSQL.Close();
        }
    }
    #endregion

    #region botones
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        if (txtRut.Value == "" && txtNumStock.Value == "")
        { Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "MensajeValidaCompuesto();", true); return; }
        else if (txtRut.Value == "")
        { Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "MensajeValidaRut();", true); return; }
        else if (txtNumStock.Value == "")
        { Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "MensajeValidaStock();", true); return; }
        traerDatosCli(txtRut.Value, txtNumStock.Value);
    }
    protected void btn_Atras_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "closewindows", "parent.jQuery.fancybox.close();", true);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "closewindows", "parent.jQuery.fancybox.close();", true);
    }
    protected void btn_Guardar_Click(object sender, EventArgs e)
    {
        if (validar())
        {
            string SqlIns = "";
            string NumStock = "";
            if (txtNumStock.Value.Length < 10)
            {
                NumStock = txtNumStock.Value.PadLeft(10, '0');
            }
            else
            {
                NumStock = txtNumStock.Value;
            }
            Usuario = Session["usuario"].ToString().Trim();
            CodConc = Session["Cliente_Numero"].ToString().Trim();
            string[] cadenaRut = txtRut.Value.Split('-');
            string FechaVenta = txtFechaVenta.Value.Substring(8, 2) + "-" + txtFechaVenta.Value.Substring(5, 2) + "-" + txtFechaVenta.Value.Substring(0, 4);

            SqlIns = "EXEC Sp_Ins_Usados_Reventa";
            SqlIns = SqlIns + " '" + NumStock;
            SqlIns = SqlIns + "', '" + Usuario;
            SqlIns = SqlIns + "', '" + CodConc;
            SqlIns = SqlIns + "', " + cadenaRut[0].Replace(".", "");
            SqlIns = SqlIns + ", '" + cadenaRut[1];
            SqlIns = SqlIns + "', '" + txtNomClte.Value;
            SqlIns = SqlIns + "', '" + txtDireccion.Value;
            SqlIns = SqlIns + "', " + DDLComuna.SelectedValue;
            SqlIns = SqlIns + ", '" + txtTel1.Value;
            SqlIns = SqlIns + "', '" + txtTelDir.Value;
            SqlIns = SqlIns + "', '" + txtMail.Value;
            SqlIns = SqlIns + "', '" + FechaVenta;
            if (txtPrecioVenta.Value == "")
                SqlIns = SqlIns + "', " + 0;
            else
                SqlIns = SqlIns + "', " + txtPrecioVenta.Value;
            SqlIns = SqlIns + ", '" + "RV_" + cadenaRut[0].Replace(".", "") + "_" + NumStock + "_" + CargarArchivo.FileName;
            if (txtPrecioMedio.Value == "")
                SqlIns = SqlIns + "', " + 0;
            else
                SqlIns = SqlIns + "', " + txtPrecioMedio.Value;
            SqlIns = SqlIns + ", " + txtDiasStock.Value;
            SqlIns = SqlIns + ", " + txtDifPrecio.Value;

            //Response.Write(SqlIns);
            //Response.End();
            conSQL.Close();
            try
            {
                conSQL.Open();
                SqlCommand cmd = new SqlCommand(SqlIns, conSQL);
                cmd.ExecuteNonQuery();
                string script = @"<script type='text/javascript'>
                                        openCustom();
                                    </script>";

                ClientScript.RegisterStartupScript(this.GetType(), "invocarfuncion", script, false);
                Enviar_Correo(txtNumStock.Value, HFPatente.Value, HFModelo.Value, HFVersion.Value);
                /* Grabar el Archivo en la ruta especificada */
                string fileName = CargarArchivo.FileName;
                string extension = System.IO.Path.GetExtension(fileName);
                int fileSize = CargarArchivo.PostedFile.ContentLength;
                string IFile = CargarArchivo.FileName;
                SaveFile(CargarArchivo.PostedFile, cadenaRut[0].Replace(".", ""), NumStock);

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
    }
    #endregion

    #region CargarArchivo
    void SaveFile(HttpPostedFile file, string _rut, string _NumStock)
    {
        // Specify the path to save the uploaded file to.
        string raiz = Server.MapPath("..");
        string savePath = raiz + Convert.ToString(new mySetup("url_info_usados", Server.MapPath("~/config/DirectorioVirtual.xml")).myConfiguracion);
        //string raiz = @"P:\";
        //string savePath = raiz + Convert.ToString(new mySetup("url_info_usados", Server.MapPath("~/config/DirectorioVirtual.xml")).myConfiguracion);

        // Get the name of the file to upload.
        string fileName = CargarArchivo.FileName;

        // Create the path and file name to check for duplicates.
        string pathToCheck = savePath + fileName;

        // Create a temporary file name to use for checking duplicates.
        string tempfileName = "";

        // Check to see if a file already exists with the
        // same name as the file to upload.        
        if (System.IO.File.Exists(pathToCheck))
        {
            //int counter = 2;
            //while (System.IO.File.Exists(pathToCheck))
            //{
            //    // if a file with this name already exists,
            //    // prefix the filename with a number.
            //    tempfileName = counter.ToString() + fileName;
            //    pathToCheck = savePath + tempfileName;
            //    counter++;
            //}

            //fileName = tempfileName;

            //// Notify the user that the file name was changed.
            //UploadStatusLabel.Text = "A file with the same name already exists." +
            //    "<br />Your file was saved as " + fileName;
        }
        else
        {
            // Notify the user that the file was saved successfully.
            //UploadStatusLabel.Text = "Your file was uploaded successfully.";
            // Append the name of the file to upload to the path.
            savePath += "RV_" + _rut + "_" + _NumStock + "_" + fileName;

            // Call the SaveAs method to save the uploaded
            // file to the specified directory.
            CargarArchivo.SaveAs(savePath);
        }
    }
    #endregion

    #region BD
    protected void traerDatosCli(string _RUT, string _NumStock)
    {
        string[] ArrayRut = _RUT.Split('-');
        string NumStock = "";
        if (_NumStock.Length < 10)
        {
            NumStock = _NumStock.PadLeft(10, '0');
        }
        else
        {
            NumStock = _NumStock;
        }

        string SQL = "";
        SQL = "EXEC Sp_Lst_Consulta_Usados_Retoma_Rut_Stock";
        SQL = SQL + " " + ArrayRut[0].Replace(".", "");
        SQL = SQL + ", '" + NumStock + "'";
        conSQL.Open();
        try
        {
            SqlDataAdapter ad = new SqlDataAdapter(SQL, conSQL);
            DataTable tbl = new DataTable();
            tbl = new DataTable("miTabla");
            ad.Fill(tbl);
            if (tbl.Rows.Count > 0)
            {
                conSQL.Close();
                /* Buscar si ya existe en Reventa */
                SQL = "select count(*) from usados_reventa";
	            SQL = SQL + " " + "where rut_clte=" + ArrayRut[0].Replace(".", "");
                SQL = SQL + " " + "and numero_stock='" + NumStock + "'";
                conSQL.Open();
                SqlCommand cmd = new SqlCommand(SQL, conSQL);
                int cant = Convert.ToInt32(cmd.ExecuteScalar());
                if (cant == 0)
                {
                    txtNomClte.Value = tbl.Rows[0]["nombre_clte"].ToString().Trim();
                    txtDireccion.Value = tbl.Rows[0]["dir_clte"].ToString().Trim();
                    DDLComuna.SelectedValue = tbl.Rows[0]["comuna"].ToString().Trim();
                    txtTel1.Value = tbl.Rows[0]["tel_cel"].ToString().Trim();
                    txtTelDir.Value = tbl.Rows[0]["tel_dir"].ToString().Trim();
                    txtMail.Value = tbl.Rows[0]["correo"].ToString().Trim();
                    txtFechaRetoma.Value = tbl.Rows[0]["fecha_retoma"].ToString().Substring(0, 10);
                    txtPrecioRetoma.Value = tbl.Rows[0]["precio_retoma"].ToString();
                    //HFNumStock.Value = tbl.Rows[0]["Id"].ToString();
                    HFPatente.Value = tbl.Rows[0]["patente"].ToString();
                    HFModelo.Value = tbl.Rows[0]["tipo_vehiculo"].ToString();
                    HFVersion.Value = tbl.Rows[0]["codigo_version"].ToString();
                }
                else if (cant > 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "MensajeValidaDatosReventa();", true); return;
                }
            }
            else
            { Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "MensajeValidaDatos();", true); return; }
        }
        catch (Exception ex)
        { }
        finally
        { if (conSQL != null) conSQL.Close(); }
    }
    #endregion

    #region validar
    public bool validar()
    {
        bool retorno = true;
        string fileName = CargarArchivo.FileName;
        string extension = System.IO.Path.GetExtension(fileName);
        if (!CargarArchivo.HasFile)
        { Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "MensajeCargarArchivo();", true); retorno = false; }
        else if (extension != ".pdf")
        { Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "MensajeValidaArchivo();", true); retorno = false; }
        return retorno;
    }
    #endregion

    #region CORREO
    protected void Enviar_Correo(string stock, string patente, string modelo, string version)
    {
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
        texto = texto + "                                                                                        <p>Junto con saludar, le informamos que hemos recibido un formulario del programa <strong style='color: #FF0000;'>Toyota Usados Certificados REVENTA</strong> y corresponde al siguiente vehículo:";
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
        miEmail.cc = "";
        miEmail.asunto = "Usados Certificados – Formulario de ReVenta STOCK [" + stock + "]";
        miEmail.prioridad = 3;
        miEmail.mensaje = texto;
        miEmail.isHTML = true;

        miEmail.Enviar();
    }
    #endregion
}
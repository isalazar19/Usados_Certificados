using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Usados_Certificados_FormularioCertificacion : System.Web.UI.Page
{
    DateTime fechaHoy = DateTime.Now;
    string fechaInicio;
    string fechaFin;
    public string CodConc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Cliente_Numero"] != null)
            {
                CodConc = Session["Cliente_Numero"].ToString().Trim();
                fechaInicio = "01-" + Convert.ToString(fechaHoy).Substring(3, 2) + "-" + Convert.ToString(fechaHoy).Substring(6, 4);  //99-99-9999
                fechaFin = Convert.ToString(fechaHoy).Substring(0, 10);
                fechaDesde.Value = fechaInicio.Replace('-', '.');
                fechaHasta.Value = fechaFin.Replace('-', '.');
                string dia = Convert.ToString(fechaHoy).Substring(0, 2);
                string mes = Convert.ToString(fechaHoy).Substring(3, 2);
                string año = Convert.ToString(fechaHoy).Substring(6, 4);
                Label1.Text = año + "-" + mes + "-" + dia;//Convert.ToString(fechaHoy).Substring(0, 10);
                Label2.Text = año + "-" + mes + "-" + dia + " 23:59:59";//Convert.ToString(fechaHoy).Substring(0, 10);
                if (CodConc == "TCL1")
                {
                    botonNew.Attributes.Add("style", "display: none;");
                }
                btnConsultar_Click(null, null);
            }
        }
    }
        
    #region botones
    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        string diaIni = Convert.ToString(fechaDesde.Value).Substring(0, 2);
        string mesIni = Convert.ToString(fechaDesde.Value).Substring(3, 2);
        string añoIni = Convert.ToString(fechaDesde.Value).Substring(6, 4);
        Label1.Text = añoIni + "-" + mesIni + "-" + diaIni;
        string diaFin = Convert.ToString(fechaHasta.Value).Substring(0, 2);
        string mesFin = Convert.ToString(fechaHasta.Value).Substring(3, 2);
        string añoFin = Convert.ToString(fechaHasta.Value).Substring(6, 4);
        Label2.Text = añoFin + "-" + mesFin + "-" + diaFin + " 23:59:59";

        SqlDataSource SqlDataSource1 = new SqlDataSource();
        SqlDataSource1.ID = "SqlDataSource1" + Guid.NewGuid();
        this.Page.Controls.Add(SqlDataSource1);
        SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SAP_WEBConnectionString"].ConnectionString;
        SqlDataSource1.SelectCommand = "EXEC Sp_Lst_Consulta_Usados_Certificados_Header '" + Label1.Text + "', '" + Label2.Text + "'";
        SqlDataSource1.Selecting += new SqlDataSourceSelectingEventHandler(SqlDataSource1_Selecting);
        GridView1.DataSource = SqlDataSource1;
        GridView1.DataBind();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.CommandTimeout = 6000;
    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
    }
    protected void deleteParam(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        ImageButton imgBtn = (ImageButton)sender;
        string codigo = imgBtn.CommandArgument;
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SAP_WEBConnectionString"].ConnectionString);
        try
        {
            string sql = "EXEC Sp_Del_Usados_Certificados '" + codigo + "'";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            command.ExecuteNonQuery();
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<font color=red><b>" + Page.Page.AppRelativeVirtualPath + " - " + ex.Message + "</b></font>");
        }
        finally
        { if (connection != null) connection.Close(); }
    }
    protected void printParam(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        ImageButton imgBtn = (ImageButton)sender;
        string stock = imgBtn.CommandArgument;
        Imprimir(stock);
    }
    #endregion

    #region GRIDVIEW
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CodConc = Session["Cliente_Numero"].ToString().Trim();
            if (CodConc != "TCL1")
            {
                ImageButton btnBorrar = (ImageButton)e.Row.FindControl("rowToDelete");
                //string estadoFormulario = e.Row.Cells[8].Text;
                //if (estadoFormulario == "A")
                //{
                    btnBorrar.Visible = false;
                //}
            }
       }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {        
    }
    protected void deleteParam_Click(object sender, EventArgs e)
    {
        //string _stock = ((Button)sender).ComandArgument;
    }
    #endregion

    #region IMPRIMIR
    private void Imprimir(string _stock)
    {
        #region Configuracion Impresion
        long vNumeral = DateTime.Now.Year * 10000000000;
        vNumeral = vNumeral + DateTime.Now.Month * 100000000;
        vNumeral = vNumeral + DateTime.Now.Day * 1000000;
        vNumeral = vNumeral + DateTime.Now.Hour * 10000;
        vNumeral = vNumeral + DateTime.Now.Minute * 100;
        vNumeral = vNumeral + DateTime.Now.Second;
        string Raiz = Server.MapPath("..") + "/Usados_Certificados";
        string NameHTML = "FormularioCertificados" + Convert.ToString(vNumeral) + ".html";
        string fileHTML = Raiz + "/" + NameHTML;
        //elimina archivos que empiezan con
        string rootFolderPath = @"" + Raiz + "";
        string filesToDelete = @"FormularioCertificados*.*";
        string[] fileList = System.IO.Directory.GetFiles(rootFolderPath, filesToDelete);
        foreach (string file in fileList)
        {
            System.IO.File.Delete(file);
        }
        StreamWriter writer = File.CreateText(fileHTML);
        string vTexto = "";
        //HTML
        vTexto = "<html xmlns='http://www.w3.org/1999/xhtml' rel='alternate' hreflang='es'>";
        writer.WriteLine(vTexto.Trim());
        #endregion
        #region HEAD
        vTexto = "<head>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<title>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "Formulario Usados Certificados";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</title>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<style type='text/css'>";
        writer.WriteLine(vTexto.Trim());
        vTexto = ".xl221";
        writer.WriteLine(vTexto.Trim());
	    vTexto = "{mso-style-parent:style0;";
        writer.WriteLine(vTexto.Trim());
	    vTexto = "font-size:20.0pt;";
        writer.WriteLine(vTexto.Trim());
	    vTexto = "font-weight:700;";
        writer.WriteLine(vTexto.Trim());
	    vTexto = "text-align:center;";
        writer.WriteLine(vTexto.Trim());
	    vTexto = "vertical-align:middle;";
        writer.WriteLine(vTexto.Trim());
	    vTexto = "border-top:.5pt solid windowtext;";
        writer.WriteLine(vTexto.Trim());
	    vTexto = "border-right:none;";
        writer.WriteLine(vTexto.Trim());
	    vTexto = "border-bottom:.5pt solid windowtext;";
        writer.WriteLine(vTexto.Trim());
	    vTexto = "border-left:none;";
        writer.WriteLine(vTexto.Trim());
	    vTexto = "background:#F2F2F2;";
        writer.WriteLine(vTexto.Trim());
	    vTexto = "mso-pattern:black none;}";
        writer.WriteLine(vTexto.Trim());
	    vTexto = ".font24";
        writer.WriteLine(vTexto.Trim());
	    vTexto = "{color:red;";
        writer.WriteLine(vTexto.Trim());
	    vTexto = "font-size:20.0pt;";
        writer.WriteLine(vTexto.Trim());
	    vTexto = "font-weight:700;";
        writer.WriteLine(vTexto.Trim());
	    vTexto = "font-style:normal;";
        writer.WriteLine(vTexto.Trim());
	    vTexto = "text-decoration:none;";
        writer.WriteLine(vTexto.Trim());
	    vTexto = "font-family:Calibri, sans-serif;";
        writer.WriteLine(vTexto.Trim());
	    vTexto = "mso-font-charset:0;}";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</style>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8'/><meta http-equiv='X-UA-Compatible' content='IE=11' /> </head>";
        writer.WriteLine(vTexto.Trim());
        #endregion
        #region BODY
        vTexto = "<body>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<table cellspacing='0' cellpadding='0'>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<tr>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<td width='1836' height='38' class='xl221' style='height:29.25pt;&#10;    width:1379pt' colspan='14'>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "PAUTA DE CONTROL";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<font class='font24'>USADOS CERTIFICADOS TOYOTA</font>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</tr>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<tr>";
        writer.WriteLine(vTexto.Trim());

        /* Datos de Cabecera */
        //********************************************Proceso Cabecera**************************************//
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SAP_WEBConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand("exec Sp_Lst_Consulta_Usados_Certificados_Header_Print '" + _stock + "'", con);
        SqlDataAdapter AdaptadorTabla = new SqlDataAdapter(cmd);
        DataTable tabla = new DataTable();
        AdaptadorTabla.Fill(tabla);

        vTexto = "<td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<label style='text-align: left;'>Número Stock</label> <strong>" + tabla.Rows[0]["Numero_Stock"].ToString() + "</strong>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<td><img src='imagenes/image001.png'  style='max-width: 100%; margin-left: 290px;' /></td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</tr>";
        writer.WriteLine(vTexto.Trim());

        vTexto = "<tr>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<label style='text-align: left;'>VIN</label> <u>" + tabla.Rows[0]["VIN"].ToString() + "</u>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</tr>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<tr>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<label style='text-align: left;'>Modelo</label> <u>" + tabla.Rows[0]["Modelo"].ToString() + "</u>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<td rowspan='5'>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<img src='imagenes/image006.png' style='margin-left: -100px; height: 200px; margin-top: -120px; opacity: .6;' />";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</tr>";
        writer.WriteLine(vTexto.Trim());

        vTexto = "<tr>";
        writer.WriteLine(vTexto.Trim()); 
        vTexto = "<td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<label style='text-align: left;'>Versión</label> <u>" + tabla.Rows[0]["codigo_version"].ToString() + "</u>";
        writer.WriteLine(vTexto.Trim()); 

        vTexto = "</td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</tr>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<tr>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<label style='text-align: left;'>Patente</label> <u>" + tabla.Rows[0]["Patente"].ToString() + "</u>";
        writer.WriteLine(vTexto.Trim()); 

        vTexto = "</td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</tr>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<tr>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<label style='text-align: left;'>Kilometraje</label> <u>" + tabla.Rows[0]["kilometraje"].ToString() + "</u>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</tr>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<tr>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<td width='50%'>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<label style='text-align: left;'>Fecha de Venta</label> <u>" + tabla.Rows[0]["fecha_venta"].ToString().Substring(0, 10) + "</u>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</tr>";
        writer.WriteLine(vTexto.Trim()); 

        vTexto = "<tr>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<label style='text-align: left;'>Años de Uso</label> <u>" + tabla.Rows[0]["ano_uso"].ToString() + "</u>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</tr>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<tr>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<label style='text-align: left;'>Número de OT</label> <u>" + tabla.Rows[0]["numero_ot"].ToString() + "</u>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<label style='text-align: left; '>Comentarios</label>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</td>";
        writer.WriteLine(vTexto.Trim());

        vTexto = "</tr>";
        writer.WriteLine(vTexto.Trim());

        vTexto = "<tr>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<textarea maxlength='500' style='height: 70px; -ms-overflow-y: hidden; width: 100%; margin-left: 270px;'>" + tabla.Rows[0]["comentarios"].ToString() + "</textarea>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</tr>";
        writer.WriteLine(vTexto.Trim());

        vTexto = "</table>";
        writer.WriteLine(vTexto.Trim());

        vTexto = "<table>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<tr>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<label style='text-align: left;'>Mantenimientos Registrados</label>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</table>";
        writer.WriteLine(vTexto.Trim());

        vTexto = "<table border='1' style='border-collapse: collapse;'>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<tr>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<th>30d</th>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<th>10K</th>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<th>20K</th>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<th>30K</th>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<th>40K</th>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<th>50K</th>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<th>60K</th>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<th>70K</th>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<th>80K</th>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<th>90K</th>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</tr>";
        writer.WriteLine(vTexto.Trim());
        /* ------------------ */
        /* IMPIMIR LOS CHECKS */
        /* ------------------ */
        //30D
        vTexto = "<tr>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<center>";
        writer.WriteLine(vTexto.Trim());
        bool mant_30d = Convert.ToBoolean(tabla.Rows[0]["mant_30d"].ToString());
        if (mant_30d == true)
        {
            vTexto = "<input type='checkbox' checked='true' />";
            writer.WriteLine(vTexto.Trim());
            vTexto = "<span class='check'></span>";
            writer.WriteLine(vTexto.Trim());
        }
        vTexto = "</center>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</td>";
        writer.WriteLine(vTexto.Trim());
        //10K
        vTexto = "<td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<center>";
        writer.WriteLine(vTexto.Trim());
        bool mant_10k = Convert.ToBoolean(tabla.Rows[0]["mant_10k"].ToString());
        if (mant_10k == true)
        {
            vTexto = "<input type='checkbox' checked='true' />";
            writer.WriteLine(vTexto.Trim());
            vTexto = "<span class='check'></span>";
            writer.WriteLine(vTexto.Trim());
        }
        vTexto = "</center>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</td>";
        writer.WriteLine(vTexto.Trim());
        //20K
        vTexto = "<td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<center>";
        writer.WriteLine(vTexto.Trim());
        bool mant_20k = Convert.ToBoolean(tabla.Rows[0]["mant_20k"].ToString());
        if (mant_20k == true)
        {
            vTexto = "<input type='checkbox' checked='true' />";
            writer.WriteLine(vTexto.Trim());
            vTexto = "<span class='check'></span>";
            writer.WriteLine(vTexto.Trim());
        }
        vTexto = "<span class='check'></span>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</center>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</td>";
        writer.WriteLine(vTexto.Trim());
        //30K
        vTexto = "<td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<center>";
        writer.WriteLine(vTexto.Trim());
        bool mant_30k = Convert.ToBoolean(tabla.Rows[0]["mant_30k"].ToString());
        if (mant_30k == true)
        {
            vTexto = "<input type='checkbox' checked='true' />";
            writer.WriteLine(vTexto.Trim());
            vTexto = "<span class='check'></span>";
            writer.WriteLine(vTexto.Trim());
        }
        vTexto = "<span class='check'></span>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</center>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</td>";
        writer.WriteLine(vTexto.Trim());
        //40K
        vTexto = "<td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<center>";
        writer.WriteLine(vTexto.Trim());
        bool mant_40k = Convert.ToBoolean(tabla.Rows[0]["mant_40k"].ToString());
        if (mant_40k == true)
        {
            vTexto = "<input type='checkbox' checked='true' />";
            writer.WriteLine(vTexto.Trim());
            vTexto = "<span class='check'></span>";
            writer.WriteLine(vTexto.Trim());
        }
        vTexto = "<span class='check'></span>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</center>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</td>";
        writer.WriteLine(vTexto.Trim());
        //50K
        vTexto = "<td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<center>";
        writer.WriteLine(vTexto.Trim());
        bool mant_50k = Convert.ToBoolean(tabla.Rows[0]["mant_50k"].ToString());
        if (mant_50k == true)
        {
            vTexto = "<input type='checkbox' checked='true' />";
            writer.WriteLine(vTexto.Trim());
            vTexto = "<span class='check'></span>";
            writer.WriteLine(vTexto.Trim());
        }
        vTexto = "<span class='check'></span>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</center>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</td>";
        writer.WriteLine(vTexto.Trim());
        //60K
        vTexto = "<td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<center>";
        writer.WriteLine(vTexto.Trim());
        bool mant_60k = Convert.ToBoolean(tabla.Rows[0]["mant_60k"].ToString());
        if (mant_60k == true)
        {
            vTexto = "<input type='checkbox' checked='true' />";
            writer.WriteLine(vTexto.Trim());
            vTexto = "<span class='check'></span>";
            writer.WriteLine(vTexto.Trim());
        }
        vTexto = "<span class='check'></span>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</center>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</td>";
        writer.WriteLine(vTexto.Trim());
        //70K
        vTexto = "<td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<center>";
        writer.WriteLine(vTexto.Trim());
        bool mant_70k = Convert.ToBoolean(tabla.Rows[0]["mant_70k"].ToString());
        if (mant_70k == true)
        {
            vTexto = "<input type='checkbox' checked='true' />";
            writer.WriteLine(vTexto.Trim());
            vTexto = "<span class='check'></span>";
            writer.WriteLine(vTexto.Trim());
        }
        vTexto = "<span class='check'></span>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</center>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</td>";
        writer.WriteLine(vTexto.Trim());
        //80K
        vTexto = "<td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<center>";
        writer.WriteLine(vTexto.Trim());
        bool mant_80k = Convert.ToBoolean(tabla.Rows[0]["mant_80k"].ToString());
        if (mant_80k == true)
        {
            vTexto = "<input type='checkbox' checked='true' />";
            writer.WriteLine(vTexto.Trim());
            vTexto = "<span class='check'></span>";
            writer.WriteLine(vTexto.Trim());
        }
        vTexto = "<span class='check'></span>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</center>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</td>";
        writer.WriteLine(vTexto.Trim());
        //90K
        vTexto = "<td>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<center>";
        writer.WriteLine(vTexto.Trim());
        bool mant_90k = Convert.ToBoolean(tabla.Rows[0]["mant_90k"].ToString());
        if (mant_90k == true)
        {
            vTexto = "<input type='checkbox' checked='true' />";
            writer.WriteLine(vTexto.Trim());
            vTexto = "<span class='check'></span>";
            writer.WriteLine(vTexto.Trim());
        }
        vTexto = "<span class='check'></span>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</center>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</td>";
        writer.WriteLine(vTexto.Trim());
        //
        vTexto = "</tr>";
        writer.WriteLine(vTexto.Trim());

        //********************************************Proceso 94 Puntos**************************************//
        // PARTE I
        vTexto = "<br />";
        writer.WriteLine(vTexto.Trim());
        vTexto =  "<table class='table' id='GridView1' style='border-collapse: collapse; width: 100%;' border='1' rules='all' cellspacing='0'>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<tr>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    <th style='background-color: Silver;' scope='col' colspan='2'>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "        (I) CONDICION, APARIENCIA EXTERIOR, ILUMINACIÓN E INDICADORES";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    </th>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    <th style='background-color: Silver; width: 10%' scope='col'>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "        Resultado";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    </th>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    <th style='background-color: Silver;' scope='col'>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "        Comentarios";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    </th>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</tr>";
        writer.WriteLine(vTexto.Trim());

        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SAP_WEBConnectionString"].ConnectionString);
        SqlCommand cmd1 = new SqlCommand("EXEC Sp_Lst_Consulta_Usados_Certificados_Detalle 1, '" + _stock + "'", con1);
        SqlDataAdapter AdaptadorTabla1 = new SqlDataAdapter(cmd1);
        DataTable tabla1 = new DataTable();
        AdaptadorTabla1.Fill(tabla1);
        if (tabla1.Rows.Count > 0)
        {
            for (int i = 0; i < tabla1.Rows.Count; i++ )
            {
                string Id = tabla1.Rows[i]["id"].ToString();
                string pregunta = tabla1.Rows[i]["pregunta"].ToString();
                string resultado = tabla1.Rows[i]["resultado"].ToString();
                string comentario = tabla1.Rows[i]["comentarios"].ToString();

                vTexto = "<tr>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "<td>" + Id + "</td>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "<td style='text-align: justify;'>" + pregunta + "</td>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "<td>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "    <div class='input-control select' style='width: 125%; margin-left: -1px;'>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "       <label style='text-align: left;'>" + resultado + "</label>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "    </div>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "</td>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "<td width='30%'>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "    <label>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "        <textarea maxlength='500' style='height: 35px; -ms-overflow-y: hidden; width: 98%;' readonly='readonly'>" + comentario + "</textarea>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "    </label>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "</td>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "</tr>";
                writer.WriteLine(vTexto.Trim());
            }
        }
        vTexto = "</table>";
        writer.WriteLine(vTexto.Trim());
        // PARTE 2
        vTexto = "<table class='table' id='GridView1' style='border-collapse: collapse; width: 100%;' border='1' rules='all' cellspacing='0'>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<tr>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    <th style='background-color: Silver;' scope='col' colspan='2'>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "        (II) COMPARTIMIENTO DE MOTOR, BATERIA Y SISTEMA DE CARGA";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    </th>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    <th style='background-color: Silver; width: 10%' scope='col'>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "        Resultado";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    </th>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    <th style='background-color: Silver;' scope='col'>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "        Comentarios";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    </th>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</tr>";
        writer.WriteLine(vTexto.Trim());

        SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["SAP_WEBConnectionString"].ConnectionString);
        SqlCommand cmd2 = new SqlCommand("EXEC Sp_Lst_Consulta_Usados_Certificados_Detalle 2, '" + _stock + "'", con2);
        SqlDataAdapter AdaptadorTabla2 = new SqlDataAdapter(cmd2);
        DataTable tabla2 = new DataTable();
        AdaptadorTabla2.Fill(tabla2);
        if (tabla2.Rows.Count > 0)
        {
            for (int i = 0; i < tabla2.Rows.Count; i++)
            {
                string Id = tabla2.Rows[i]["id"].ToString();
                string pregunta = tabla2.Rows[i]["pregunta"].ToString();
                string resultado = tabla2.Rows[i]["resultado"].ToString();
                string comentario = tabla2.Rows[i]["comentarios"].ToString();

                vTexto = "<tr>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "<td>" + Id + "</td>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "<td style='text-align: justify;'>" + pregunta + "</td>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "<td>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "    <div class='input-control select' style='width: 125%; margin-left: -1px;'>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "       <label style='text-align: left;'>" + resultado + "</label>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "    </div>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "</td>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "<td width='30%'>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "    <label>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "        <textarea maxlength='500' style='height: 35px; -ms-overflow-y: hidden; width: 98%;' readonly='readonly'>" + comentario + "</textarea>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "    </label>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "</td>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "</tr>";
                writer.WriteLine(vTexto.Trim());
            }
        }
        vTexto = "</table>";
        writer.WriteLine(vTexto.Trim());
        // PARTE 3
        vTexto = "<table class='table' id='GridView1' style='border-collapse: collapse; width: 100%;' border='1' rules='all' cellspacing='0'>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<tr>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    <th style='background-color: Silver;' scope='col' colspan='2'>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "        (III) COMPARTIMIENTO MALETA, Y NEUMATICOS INCLUYE REPUESTO";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    </th>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    <th style='background-color: Silver; width: 10%' scope='col'>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "        Resultado";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    </th>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    <th style='background-color: Silver;' scope='col'>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "        Comentarios";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    </th>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</tr>";
        writer.WriteLine(vTexto.Trim());

        SqlConnection con3 = new SqlConnection(ConfigurationManager.ConnectionStrings["SAP_WEBConnectionString"].ConnectionString);
        SqlCommand cmd3 = new SqlCommand("EXEC Sp_Lst_Consulta_Usados_Certificados_Detalle 3, '" + _stock + "'", con3);
        SqlDataAdapter AdaptadorTabla3 = new SqlDataAdapter(cmd3);
        DataTable tabla3 = new DataTable();
        AdaptadorTabla3.Fill(tabla3);
        if (tabla3.Rows.Count > 0)
        {
            for (int i = 0; i < tabla3.Rows.Count; i++)
            {
                string Id = tabla3.Rows[i]["id"].ToString();
                string pregunta = tabla3.Rows[i]["pregunta"].ToString();
                string resultado = tabla3.Rows[i]["resultado"].ToString();
                string comentario = tabla3.Rows[i]["comentarios"].ToString();

                vTexto = "<tr>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "<td>" + Id + "</td>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "<td style='text-align: justify;'>" + pregunta + "</td>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "<td>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "    <div class='input-control select' style='width: 125%; margin-left: -1px;'>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "       <label style='text-align: left;'>" + resultado + "</label>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "    </div>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "</td>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "<td width='30%'>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "    <label>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "        <textarea maxlength='500' style='height: 35px; -ms-overflow-y: hidden; width: 98%;' readonly='readonly'>" + comentario + "</textarea>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "    </label>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "</td>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "</tr>";
                writer.WriteLine(vTexto.Trim());
            }
        }
        vTexto = "</table>";
        writer.WriteLine(vTexto.Trim());
        // PARTE 4
        vTexto = "<br />";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<table class='table' id='GridView1' style='border-collapse: collapse; width: 100%;' border='1' rules='all' cellspacing='0'>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<tr>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    <th style='background-color: Silver;' scope='col' colspan='2'>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "        (IV) PANEL DE INSTRUMENTOS Y SISTEMAS ELECTRONICOS";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    </th>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    <th style='background-color: Silver; width: 10%' scope='col'>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "        Resultado";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    </th>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    <th style='background-color: Silver;' scope='col'>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "        Comentarios";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    </th>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</tr>";
        writer.WriteLine(vTexto.Trim());

        SqlConnection con4 = new SqlConnection(ConfigurationManager.ConnectionStrings["SAP_WEBConnectionString"].ConnectionString);
        SqlCommand cmd4 = new SqlCommand("EXEC Sp_Lst_Consulta_Usados_Certificados_Detalle 4, '" + _stock + "'", con4);
        SqlDataAdapter AdaptadorTabla4 = new SqlDataAdapter(cmd4);
        DataTable tabla4 = new DataTable();
        AdaptadorTabla4.Fill(tabla4);
        if (tabla4.Rows.Count > 0)
        {
            for (int i = 0; i < tabla4.Rows.Count; i++)
            {
                string Id = tabla4.Rows[i]["id"].ToString();
                string pregunta = tabla4.Rows[i]["pregunta"].ToString();
                string resultado = tabla4.Rows[i]["resultado"].ToString();
                string comentario = tabla4.Rows[i]["comentarios"].ToString();

                vTexto = "<tr>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "<td>" + Id + "</td>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "<td style='text-align: justify;'>" + pregunta + "</td>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "<td>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "    <div class='input-control select' style='width: 125%; margin-left: -1px;'>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "       <label style='text-align: left;'>" + resultado + "</label>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "    </div>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "</td>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "<td width='30%'>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "    <label>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "        <textarea maxlength='500' style='height: 35px; -ms-overflow-y: hidden; width: 98%;' readonly='readonly'>" + comentario + "</textarea>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "    </label>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "</td>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "</tr>";
                writer.WriteLine(vTexto.Trim());
            }
        }
        vTexto = "</table>";
        writer.WriteLine(vTexto.Trim());
        // PARTE 5
        vTexto = "<table class='table' id='GridView1' style='border-collapse: collapse; width: 100%;' border='1' rules='all' cellspacing='0'>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<tr>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    <th style='background-color: Silver;' scope='col' colspan='2'>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "        (V) SISTEMA DIRECCION, FRENOS Y SUSPENCIÓN";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    </th>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    <th style='background-color: Silver; width: 10%' scope='col'>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "        Resultado";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    </th>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    <th style='background-color: Silver;' scope='col'>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "        Comentarios";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    </th>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</tr>";
        writer.WriteLine(vTexto.Trim());

        SqlConnection con5 = new SqlConnection(ConfigurationManager.ConnectionStrings["SAP_WEBConnectionString"].ConnectionString);
        SqlCommand cmd5 = new SqlCommand("EXEC Sp_Lst_Consulta_Usados_Certificados_Detalle 5, '" + _stock + "'", con5);
        SqlDataAdapter AdaptadorTabla5 = new SqlDataAdapter(cmd5);
        DataTable tabla5 = new DataTable();
        AdaptadorTabla5.Fill(tabla5);
        if (tabla5.Rows.Count > 0)
        {
            for (int i = 0; i < tabla5.Rows.Count; i++)
            {
                string Id = tabla5.Rows[i]["id"].ToString();
                string pregunta = tabla5.Rows[i]["pregunta"].ToString();
                string resultado = tabla5.Rows[i]["resultado"].ToString();
                string comentario = tabla5.Rows[i]["comentarios"].ToString();

                vTexto = "<tr>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "<td>" + Id + "</td>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "<td style='text-align: justify;'>" + pregunta + "</td>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "<td>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "    <div class='input-control select' style='width: 125%; margin-left: -1px;'>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "       <label style='text-align: left;'>" + resultado + "</label>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "    </div>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "</td>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "<td width='30%'>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "    <label>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "        <textarea maxlength='500' style='height: 35px; -ms-overflow-y: hidden; width: 98%;' readonly='readonly'>" + comentario + "</textarea>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "    </label>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "</td>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "</tr>";
                writer.WriteLine(vTexto.Trim());
            }
        }
        vTexto = "</table>";
        writer.WriteLine(vTexto.Trim());
        // PARTE 6
        vTexto = "<table class='table' id='GridView1' style='border-collapse: collapse; width: 100%;' border='1' rules='all' cellspacing='0'>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "<tr>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    <th style='background-color: Silver;' scope='col' colspan='2'>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "        (VI) PRUEBA DE RUTA, TRANSMISION, TRACCIÓN E INDICADORES";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    </th>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    <th style='background-color: Silver; width: 10%' scope='col'>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "        Resultado";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    </th>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    <th style='background-color: Silver;' scope='col'>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "        Comentarios";
        writer.WriteLine(vTexto.Trim());
        vTexto = "    </th>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</tr>";
        writer.WriteLine(vTexto.Trim());

        SqlConnection con6 = new SqlConnection(ConfigurationManager.ConnectionStrings["SAP_WEBConnectionString"].ConnectionString);
        SqlCommand cmd6 = new SqlCommand("EXEC Sp_Lst_Consulta_Usados_Certificados_Detalle 6, '" + _stock + "'", con6);
        SqlDataAdapter AdaptadorTabla6 = new SqlDataAdapter(cmd6);
        DataTable tabla6 = new DataTable();
        AdaptadorTabla6.Fill(tabla6);
        if (tabla6.Rows.Count > 0)
        {
            for (int i = 0; i < tabla6.Rows.Count; i++)
            {
                string Id = tabla6.Rows[i]["id"].ToString();
                string pregunta = tabla6.Rows[i]["pregunta"].ToString();
                string resultado = tabla6.Rows[i]["resultado"].ToString();
                string comentario = tabla6.Rows[i]["comentarios"].ToString();

                vTexto = "<tr>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "<td>" + Id + "</td>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "<td style='text-align: justify;'>" + pregunta + "</td>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "<td>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "    <div class='input-control select' style='width: 125%; margin-left: -1px;'>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "       <label style='text-align: left;'>" + resultado + "</label>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "    </div>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "</td>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "<td width='30%'>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "    <label>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "        <textarea maxlength='500' style='height: 35px; -ms-overflow-y: hidden; width: 98%;' readonly='readonly'>" + comentario + "</textarea>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "    </label>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "</td>";
                writer.WriteLine(vTexto.Trim());
                vTexto = "</tr>";
                writer.WriteLine(vTexto.Trim());
            }
        }
        vTexto = "</table>";
        writer.WriteLine(vTexto.Trim());

        vTexto = "</table>";
        writer.WriteLine(vTexto.Trim());

        vTexto = "</body>";
        writer.WriteLine(vTexto.Trim());
        vTexto = "</html>";
        writer.WriteLine(vTexto.Trim());
        // JAVASCRIPT
        vTexto = "<script language='JavaScript'>window.print()</script>";
        writer.WriteLine(vTexto.Trim());
        // CIERRA STREAMWRITER
        writer.Close();
        string popup = "<script language='JavaScript'>window.open('" + NameHTML + "')</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", popup);
        #endregion
    }
    #endregion
}
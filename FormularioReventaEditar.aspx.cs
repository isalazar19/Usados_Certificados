using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Usados_Certificados_FormularioReventaEditar : System.Web.UI.Page
{
    public string CodConc = "";
    public string Usuario = "";
    SqlConnection conSQL = new SqlConnection(ConfigurationManager.ConnectionStrings["SAP_WEBConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        int Id = Convert.ToInt32(Request.QueryString["id"].ToString());
        LlenarComuna();
        if (Session["Cliente_Numero"] != null && Session["usuario"] != null)
        {
            CodConc = Session["Cliente_Numero"].ToString().Trim();
            if (CodConc == "TCL1")
            { precioMedio.Visible = true; }
            else
            { precioMedio.Visible = false; btn_Guardar.Style.Add("display", "none"); }

            traerDatos(Id);
        }
        else
        {
            Response.Redirect("../Usados_Certificados/Default.aspx");
        }
    }

    #region DropDown
    protected void LlenarComuna()
    {
        SqlConnection conexion1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SAP_WEBConnectionString"].ConnectionString);
        string consulta1;
        try
        {
            ListItem item = new ListItem();
            item.Text = "Seleccione Comuna...";
            item.Value = "";
            DDLComuna.Items.Add(item);
            //
            consulta1 = "SELECT * FROM MAESTRO_CIUDAD_COMUNA ORDER BY 2";
            SqlDataAdapter adaptador1 = new SqlDataAdapter(consulta1, conexion1);
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
            if (conexion1 != null)
                conexion1.Close();
        }
        finally
        {
            if (conexion1 != null)
                conexion1.Close();
        }
    }
    #endregion

    #region botones
    protected void btn_Atras_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "closewindows", "parent.jQuery.fancybox.close();", true);
    }
    protected void btn_Guardar_Click(object sender, EventArgs e)
    {
    }
    #endregion

    #region DATOS
    protected void traerDatos(int param)
    {
        string SQL = "";
        //SQL = "select * from USADOS_REVENTA where id=" + param;
        SQL = "select a.*, b.fecha_retoma, b.precio_retoma"; 
        SQL = SQL + " " + "from usados_reventa a"; 
        SQL = SQL + " " + "inner join usados_retoma b on b.rut_clte=a.rut_clte and b.numero_stock=a.numero_stock";
        SQL = SQL + " " + "where a.id=" + param;
        conSQL.Open();
        try
        {
            SqlDataAdapter ad = new SqlDataAdapter(SQL, conSQL);
            DataTable tbl = new DataTable();
            ad.Fill(tbl);
            if (tbl.Rows.Count > 0)
            {
                txtRut.Value = tbl.Rows[0]["RUT_CLTE"].ToString() + "-" + tbl.Rows[0]["DV_CLTE"].ToString();
                txtNumStock.Value = tbl.Rows[0]["NUMERO_STOCK"].ToString();
                txtNomClte.Value = tbl.Rows[0]["NOMBRE_CLTE"].ToString();
                txtDireccion.Value = tbl.Rows[0]["DIR_CLTE"].ToString();
                DDLComuna.SelectedValue = tbl.Rows[0]["COMUNA"].ToString();
                txtTel1.Value = tbl.Rows[0]["TEL_CEL"].ToString();
                txtTelDir.Value = tbl.Rows[0]["TEL_DIR"].ToString();
                txtMail.Value = tbl.Rows[0]["CORREO"].ToString();
                txtFechaVenta.Value = tbl.Rows[0]["FECHA_VENTA"].ToString().Substring(0, 10);
                txtFechaRetoma.Value = tbl.Rows[0]["FECHA_RETOMA"].ToString().Substring(0, 10);
                txtPrecioVenta.Value = tbl.Rows[0]["PRECIO_VENTA"].ToString();
                CodConc = Session["Cliente_Numero"].ToString().Trim();
                /* Mostrar el Archivo adjuntado */
                string respuesta = "";
                string url = "../Archivos/Usados_Certificados/";
                string archivo = tbl.Rows[0]["DOCUMENTO"].ToString().Trim();
                if (archivo.Trim().Length >= 1)
                    respuesta = "../Utilidades/DescargaArchivo.aspx?ruta=" + url.Trim() + "&archivo=" + archivo.Trim();
                HyperLink1.NavigateUrl = respuesta;
                if (CodConc == "TCL1")
                {
                    precioMedio.Visible = true;
                    txtPrecioMedio.Value = tbl.Rows[0]["PRECIO_MEDIO"].ToString();
                    if (txtPrecioMedio.Value == "0,00") txtPrecioMedio.Value = "";
                }
                else
                { precioMedio.Visible = false; }
                txtDiasStock.Value = tbl.Rows[0]["DIAS_STOCK"].ToString();
                txtDifPrecio.Value = tbl.Rows[0]["DIFERENCIA_PRECIO"].ToString();
                txtPrecioRetoma.Value = tbl.Rows[0]["PRECIO_RETOMA"].ToString();
            }
        }
        catch (Exception ex)
        {
        }
        finally
        { if (conSQL != null) conSQL.Close(); }
    }
    #endregion
}
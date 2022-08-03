using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Usados_Certificados_VerPlanilla : System.Web.UI.Page
{
    public string vLiteral = "";
    public string stock = "";
    public string estado = "";
    SqlConnection conSQL = new SqlConnection(ConfigurationManager.ConnectionStrings["SAP_WEBConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null && Request.QueryString["estat"] != null)
        {
            stock = Request.QueryString["id"].ToString();
            estado = Request.QueryString["estat"].ToString();
            cargar_tabla(stock);
        }
    }

    protected void btn_Salir_Click(object sender, EventArgs e)
    {
        Response.Redirect("FormularioCertificacionEditar.aspx?id=" + stock + "&estat=" + estado );
    }

    #region ARMAR_PLANILLA
    protected void cargar_tabla(string stock)
    {
        string SQL = "";
        int seccion = 1;
        vLiteral = vLiteral + "<table class='table' id='GridView1' style='border-collapse: collapse; width: 100%;' border='1' rules='all' cellspacing='0'>";
        vLiteral = vLiteral + "<tr>";
        vLiteral = vLiteral + "    <th style='background-color: Silver;' scope='col' colspan='2'>";
        vLiteral = vLiteral + "        (I) CONDICION, APARIENCIA EXTERIOR, ILUMINACIÓN E INDICADORES";
        vLiteral = vLiteral + "    </th>";
        vLiteral = vLiteral + "    <th style='background-color: Silver; width: 10%' scope='col'>";
        vLiteral = vLiteral + "        Resultado";
        vLiteral = vLiteral + "    </th>";
        vLiteral = vLiteral + "    <th style='background-color: Silver;' scope='col'>";
        vLiteral = vLiteral + "        Comentarios";
        vLiteral = vLiteral + "    </th>";
        vLiteral = vLiteral + "</tr>";

        try
        {
            SQL = "EXEC Sp_Lst_Consulta_Usados_Certificados_Detalle";
            SQL = SQL + " " + seccion;
            SQL = SQL + ", '" + stock + "'";
            //Response.Write(SQL);
            //Response.End();
            SqlDataAdapter adpt = new SqlDataAdapter(SQL, conSQL);
            DataTable tbl = new DataTable();
            tbl = new DataTable("datos");
            adpt.Fill(tbl);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                string Id = tbl.Rows[i]["id"].ToString();
                string pregunta = tbl.Rows[i]["pregunta"].ToString();
                string resultado = tbl.Rows[i]["resultado"].ToString();
                string comentario = tbl.Rows[i]["comentarios"].ToString();

                vLiteral = vLiteral + "<tr>";
                vLiteral = vLiteral + "<td>" + Id + "</td>";
                vLiteral = vLiteral + "<td style='text-align: justify;'>" + pregunta + "</td>";
                vLiteral = vLiteral + "<td>";
                vLiteral = vLiteral + "    <div class='input-control select' style='width: 125%; margin-left: -1px;'>";
                vLiteral = vLiteral + "       <label style='text-align: left;'>" + resultado + "</label>";
                vLiteral = vLiteral + "    </div>";
                vLiteral = vLiteral + "</td>";
                vLiteral = vLiteral + "<td width='30%'>";
                vLiteral = vLiteral + "    <label>";
                vLiteral = vLiteral + "        <textarea maxlength='500' style='height: 35px; -ms-overflow-y: hidden; width: 98%;' readonly='readonly'>"+ comentario + "</textarea>";
                vLiteral = vLiteral + "    </label>";
                vLiteral = vLiteral + "</td>";
                vLiteral = vLiteral + "</tr>";
            }
            vLiteral = vLiteral + "</table>";
        }
        catch (Exception ex)
        { if (conSQL != null) conSQL.Close(); }
        finally { if (conSQL != null) conSQL.Close(); }

        /* PARTE 2 */
        seccion = 2;
        vLiteral = vLiteral + "<table class='table' id='GridView1' style='border-collapse: collapse; width: 100%;' border='1' rules='all' cellspacing='0'>";
        vLiteral = vLiteral + "<tr>";
        vLiteral = vLiteral + "    <th style='background-color: Silver;' scope='col' colspan='2'>";
        vLiteral = vLiteral + "        (II) COMPARTIMIENTO DE MOTOR, BATERIA Y SISTEMA DE CARGA";
        vLiteral = vLiteral + "    </th>";
        vLiteral = vLiteral + "    <th style='background-color: Silver; width: 10%' scope='col'>";
        vLiteral = vLiteral + "        Resultado";
        vLiteral = vLiteral + "    </th>";
        vLiteral = vLiteral + "    <th style='background-color: Silver;' scope='col'>";
        vLiteral = vLiteral + "        Comentarios";
        vLiteral = vLiteral + "    </th>";
        vLiteral = vLiteral + "</tr>";

        try
        {
            SQL = "EXEC Sp_Lst_Consulta_Usados_Certificados_Detalle";
            SQL = SQL + " " + seccion;
            SQL = SQL + ", '" + stock + "'";
            //Response.Write(SQL);
            //Response.End();
            SqlDataAdapter adpt = new SqlDataAdapter(SQL, conSQL);
            DataTable tbl = new DataTable();
            tbl = new DataTable("datos");
            adpt.Fill(tbl);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                string Id = tbl.Rows[i]["id"].ToString();
                string pregunta = tbl.Rows[i]["pregunta"].ToString();
                string resultado = tbl.Rows[i]["resultado"].ToString();
                string comentario = tbl.Rows[i]["comentarios"].ToString();

                vLiteral = vLiteral + "<tr>";
                vLiteral = vLiteral + "<td>" + Id + "</td>";
                vLiteral = vLiteral + "<td style='text-align: justify;'>" + pregunta + "</td>";
                vLiteral = vLiteral + "<td>";
                vLiteral = vLiteral + "    <div class='input-control select' style='width: 125%; margin-left: -1px;'>";
                vLiteral = vLiteral + "       <label style='text-align: left;'>" + resultado + "</label>";
                vLiteral = vLiteral + "    </div>";
                vLiteral = vLiteral + "</td>";
                vLiteral = vLiteral + "<td width='30%'>";
                vLiteral = vLiteral + "    <label>";
                vLiteral = vLiteral + "        <textarea maxlength='500' style='height: 35px; -ms-overflow-y: hidden; width: 98%;' readonly='readonly'>" + comentario + "</textarea>";
                vLiteral = vLiteral + "    </label>";
                vLiteral = vLiteral + "</td>";
                vLiteral = vLiteral + "</tr>";
            }
            vLiteral = vLiteral + "</table>";
        }
        catch (Exception ex)
        { if (conSQL != null) conSQL.Close(); }
        finally { if (conSQL != null) conSQL.Close(); }

        /* PARTE 3 */
        seccion = 3;
        vLiteral = vLiteral + "<table class='table' id='GridView1' style='border-collapse: collapse; width: 100%;' border='1' rules='all' cellspacing='0'>";
        vLiteral = vLiteral + "<tr>";
        vLiteral = vLiteral + "    <th style='background-color: Silver;' scope='col' colspan='2'>";
        vLiteral = vLiteral + "        (III) COMPARTIMIENTO MALETA, Y NEUMATICOS INCLUYE REPUESTO";
        vLiteral = vLiteral + "    </th>";
        vLiteral = vLiteral + "    <th style='background-color: Silver; width: 10%' scope='col'>";
        vLiteral = vLiteral + "        Resultado";
        vLiteral = vLiteral + "    </th>";
        vLiteral = vLiteral + "    <th style='background-color: Silver;' scope='col'>";
        vLiteral = vLiteral + "        Comentarios";
        vLiteral = vLiteral + "    </th>";
        vLiteral = vLiteral + "</tr>";
        try
        {
            SQL = "EXEC Sp_Lst_Consulta_Usados_Certificados_Detalle";
            SQL = SQL + " " + seccion;
            SQL = SQL + ", '" + stock + "'";
            //Response.Write(SQL);
            //Response.End();
            SqlDataAdapter adpt = new SqlDataAdapter(SQL, conSQL);
            DataTable tbl = new DataTable();
            tbl = new DataTable("datos");
            adpt.Fill(tbl);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                string Id = tbl.Rows[i]["id"].ToString();
                string pregunta = tbl.Rows[i]["pregunta"].ToString();
                string resultado = tbl.Rows[i]["resultado"].ToString();
                string comentario = tbl.Rows[i]["comentarios"].ToString();

                vLiteral = vLiteral + "<tr>";
                vLiteral = vLiteral + "<td>" + Id + "</td>";
                vLiteral = vLiteral + "<td style='text-align: justify;'>" + pregunta + "</td>";
                vLiteral = vLiteral + "<td>";
                vLiteral = vLiteral + "    <div class='input-control select' style='width: 125%; margin-left: -1px;'>";
                vLiteral = vLiteral + "       <label style='text-align: left;'>" + resultado + "</label>";
                vLiteral = vLiteral + "    </div>";
                vLiteral = vLiteral + "</td>";
                vLiteral = vLiteral + "<td width='30%'>";
                vLiteral = vLiteral + "    <label>";
                vLiteral = vLiteral + "        <textarea maxlength='500' style='height: 35px; -ms-overflow-y: hidden; width: 98%;' readonly='readonly'>" + comentario + "</textarea>";
                vLiteral = vLiteral + "    </label>";
                vLiteral = vLiteral + "</td>";
                vLiteral = vLiteral + "</tr>";
            }
            vLiteral = vLiteral + "</table>";
        }
        catch (Exception ex)
        { if (conSQL != null) conSQL.Close(); }
        finally { if (conSQL != null) conSQL.Close(); }

        /* PARTE 4 */
        seccion = 4;
        vLiteral = vLiteral + "<table class='table' id='GridView1' style='border-collapse: collapse; width: 100%;' border='1' rules='all' cellspacing='0'>";
        vLiteral = vLiteral + "<tr>";
        vLiteral = vLiteral + "    <th style='background-color: Silver;' scope='col' colspan='2'>";
        vLiteral = vLiteral + "        (IV) PANEL DE INSTRUMENTOS Y SISTEMAS ELECTRONICOS";
        vLiteral = vLiteral + "    </th>";
        vLiteral = vLiteral + "    <th style='background-color: Silver; width: 10%' scope='col'>";
        vLiteral = vLiteral + "        Resultado";
        vLiteral = vLiteral + "    </th>";
        vLiteral = vLiteral + "    <th style='background-color: Silver;' scope='col'>";
        vLiteral = vLiteral + "        Comentarios";
        vLiteral = vLiteral + "    </th>";
        vLiteral = vLiteral + "</tr>";
        try
        {
            SQL = "EXEC Sp_Lst_Consulta_Usados_Certificados_Detalle";
            SQL = SQL + " " + seccion;
            SQL = SQL + ", '" + stock + "'";
            //Response.Write(SQL);
            //Response.End();
            SqlDataAdapter adpt = new SqlDataAdapter(SQL, conSQL);
            DataTable tbl = new DataTable();
            tbl = new DataTable("datos");
            adpt.Fill(tbl);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                string Id = tbl.Rows[i]["id"].ToString();
                string pregunta = tbl.Rows[i]["pregunta"].ToString();
                string resultado = tbl.Rows[i]["resultado"].ToString();
                string comentario = tbl.Rows[i]["comentarios"].ToString();

                vLiteral = vLiteral + "<tr>";
                vLiteral = vLiteral + "<td>" + Id + "</td>";
                vLiteral = vLiteral + "<td style='text-align: justify;'>" + pregunta + "</td>";
                vLiteral = vLiteral + "<td>";
                vLiteral = vLiteral + "    <div class='input-control select' style='width: 125%; margin-left: -1px;'>";
                vLiteral = vLiteral + "       <label style='text-align: left;'>" + resultado + "</label>";
                vLiteral = vLiteral + "    </div>";
                vLiteral = vLiteral + "</td>";
                vLiteral = vLiteral + "<td width='30%'>";
                vLiteral = vLiteral + "    <label>";
                vLiteral = vLiteral + "        <textarea maxlength='500' style='height: 35px; -ms-overflow-y: hidden; width: 98%;' readonly='readonly'>" + comentario + "</textarea>";
                vLiteral = vLiteral + "    </label>";
                vLiteral = vLiteral + "</td>";
                vLiteral = vLiteral + "</tr>";
            }
            vLiteral = vLiteral + "</table>";
        }
        catch (Exception ex)
        { if (conSQL != null) conSQL.Close(); }
        finally { if (conSQL != null) conSQL.Close(); }

        /* PARTE 5 */
        seccion = 5;
        vLiteral = vLiteral + "<table class='table' id='GridView1' style='border-collapse: collapse; width: 100%;' border='1' rules='all' cellspacing='0'>";
        vLiteral = vLiteral + "<tr>";
        vLiteral = vLiteral + "    <th style='background-color: Silver;' scope='col' colspan='2'>";
        vLiteral = vLiteral + "        (V) SISTEMA DIRECCION, FRENOS Y SUSPENCIÓN";
        vLiteral = vLiteral + "    </th>";
        vLiteral = vLiteral + "    <th style='background-color: Silver; width: 10%' scope='col'>";
        vLiteral = vLiteral + "        Resultado";
        vLiteral = vLiteral + "    </th>";
        vLiteral = vLiteral + "    <th style='background-color: Silver;' scope='col'>";
        vLiteral = vLiteral + "        Comentarios";
        vLiteral = vLiteral + "    </th>";
        vLiteral = vLiteral + "</tr>";
        try
        {
            SQL = "EXEC Sp_Lst_Consulta_Usados_Certificados_Detalle";
            SQL = SQL + " " + seccion;
            SQL = SQL + ", '" + stock + "'";
            //Response.Write(SQL);
            //Response.End();
            SqlDataAdapter adpt = new SqlDataAdapter(SQL, conSQL);
            DataTable tbl = new DataTable();
            tbl = new DataTable("datos");
            adpt.Fill(tbl);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                string Id = tbl.Rows[i]["id"].ToString();
                string pregunta = tbl.Rows[i]["pregunta"].ToString();
                string resultado = tbl.Rows[i]["resultado"].ToString();
                string comentario = tbl.Rows[i]["comentarios"].ToString();

                vLiteral = vLiteral + "<tr>";
                vLiteral = vLiteral + "<td>" + Id + "</td>";
                vLiteral = vLiteral + "<td style='text-align: justify;'>" + pregunta + "</td>";
                vLiteral = vLiteral + "<td>";
                vLiteral = vLiteral + "    <div class='input-control select' style='width: 125%; margin-left: -1px;'>";
                vLiteral = vLiteral + "       <label style='text-align: left;'>" + resultado + "</label>";
                vLiteral = vLiteral + "    </div>";
                vLiteral = vLiteral + "</td>";
                vLiteral = vLiteral + "<td width='30%'>";
                vLiteral = vLiteral + "    <label>";
                vLiteral = vLiteral + "        <textarea maxlength='500' style='height: 35px; -ms-overflow-y: hidden; width: 98%;' readonly='readonly'>" + comentario + "</textarea>";
                vLiteral = vLiteral + "    </label>";
                vLiteral = vLiteral + "</td>";
                vLiteral = vLiteral + "</tr>";
            }
            vLiteral = vLiteral + "</table>";
        }
        catch (Exception ex)
        { if (conSQL != null) conSQL.Close(); }
        finally { if (conSQL != null) conSQL.Close(); }

        /* PARTE 6 */
        seccion = 6;
        vLiteral = vLiteral + "<table class='table' id='GridView1' style='border-collapse: collapse; width: 100%;' border='1' rules='all' cellspacing='0'>";
        vLiteral = vLiteral + "<tr>";
        vLiteral = vLiteral + "    <th style='background-color: Silver;' scope='col' colspan='2'>";
        vLiteral = vLiteral + "        (VI) PRUEBA DE RUTA, TRANSMISION, TRACCIÓN E INDICADORES.";
        vLiteral = vLiteral + "    </th>";
        vLiteral = vLiteral + "    <th style='background-color: Silver; width: 10%' scope='col'>";
        vLiteral = vLiteral + "        Resultado";
        vLiteral = vLiteral + "    </th>";
        vLiteral = vLiteral + "    <th style='background-color: Silver;' scope='col'>";
        vLiteral = vLiteral + "        Comentarios";
        vLiteral = vLiteral + "    </th>";
        vLiteral = vLiteral + "</tr>";
        try
        {
            SQL = "EXEC Sp_Lst_Consulta_Usados_Certificados_Detalle";
            SQL = SQL + " " + seccion;
            SQL = SQL + ", '" + stock + "'";
            //Response.Write(SQL);
            //Response.End();
            SqlDataAdapter adpt = new SqlDataAdapter(SQL, conSQL);
            DataTable tbl = new DataTable();
            tbl = new DataTable("datos");
            adpt.Fill(tbl);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                string Id = tbl.Rows[i]["id"].ToString();
                string pregunta = tbl.Rows[i]["pregunta"].ToString();
                string resultado = tbl.Rows[i]["resultado"].ToString();
                string comentario = tbl.Rows[i]["comentarios"].ToString();

                vLiteral = vLiteral + "<tr>";
                vLiteral = vLiteral + "<td>" + Id + "</td>";
                vLiteral = vLiteral + "<td style='text-align: justify;'>" + pregunta + "</td>";
                vLiteral = vLiteral + "<td>";
                vLiteral = vLiteral + "    <div class='input-control select' style='width: 125%; margin-left: -1px;'>";
                vLiteral = vLiteral + "       <label style='text-align: left;'>" + resultado + "</label>";
                vLiteral = vLiteral + "    </div>";
                vLiteral = vLiteral + "</td>";
                vLiteral = vLiteral + "<td width='30%'>";
                vLiteral = vLiteral + "    <label>";
                vLiteral = vLiteral + "        <textarea maxlength='500' style='height: 35px; -ms-overflow-y: hidden; width: 98%;' readonly='readonly'>" + comentario + "</textarea>";
                vLiteral = vLiteral + "    </label>";
                vLiteral = vLiteral + "</td>";
                vLiteral = vLiteral + "</tr>";
            }
            vLiteral = vLiteral + "</table>";
        }
        catch (Exception ex)
        { if (conSQL != null) conSQL.Close(); }
        finally { if (conSQL != null) conSQL.Close(); }

        vLiteral = vLiteral + "</table>";
        Panel1.Controls.Add(new LiteralControl(vLiteral));
    }
    #endregion
}
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Usados_Certificados_ListaReventa : System.Web.UI.Page
{
    public string CodConc = "";
    SqlConnection conSQL = new SqlConnection(ConfigurationManager.ConnectionStrings["SAP_WEBConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CodConc = Session["Cliente_Numero"].ToString().Trim();
            if (CodConc == "TCL1")
                LblGrupo.Text = "%";
            else
                Busca_Grupo(CodConc);

            Cargar_Datos();
        }
    }

    protected void Busca_Grupo(string _CodConc)
    {
        string SQL = "";
        SQL = "SELECT ID_GRUPO,REGION FROM GRUPO_CONCESIONARIO";
        SQL = SQL + " " + "WHERE CONCESIONARIO='" + _CodConc + "'";
        conSQL.Open();
        try
        {
            SqlDataAdapter ad = new SqlDataAdapter(SQL, conSQL);
            DataTable tbl = new DataTable();
            tbl = new DataTable("miTabla");
            ad.Fill(tbl);
            if (tbl.Rows.Count > 0)
            {
                //LblRegion.Text = tbl.Rows[0]["REGION"].ToString().Trim();
                LblGrupo.Text = tbl.Rows[0]["ID_GRUPO"].ToString().Trim();
            }
        }
        catch (Exception ex)
        { }
        finally
        { if (conSQL != null) conSQL.Close(); }
    }

    #region GRIDVIEW
    protected void Cargar_Datos()
    {
        SqlDataSource SqlDataSource1 = new SqlDataSource();
        SqlDataSource1.ID = "SqlDataSource1" + Guid.NewGuid();
        this.Page.Controls.Add(SqlDataSource1);
        SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SAP_WEBConnectionString"].ConnectionString;
        SqlDataSource1.SelectCommand = "EXEC Sp_Lst_Consulta_Usados_Reventa '" + LblGrupo.Text + "'";
        SqlDataSource1.Selecting += new SqlDataSourceSelectingEventHandler(SqlDataSource1_Selecting);
        GridView1.DataSource = SqlDataSource1;
        GridView1.DataBind();
    }

    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.CommandTimeout = 6000;
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CodConc = Session["Cliente_Numero"].ToString().Trim();
            if (CodConc != "TCL1")
            {
                HyperLink myRuta = e.Row.FindControl("btnEditar") as HyperLink;
                //myRuta.NavigateUrl = "";
            }
        }
    }
    #endregion
}
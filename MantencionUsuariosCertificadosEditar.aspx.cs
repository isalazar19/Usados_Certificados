using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Usados_Certificados_MantencionUsuariosCertificadosEditar : System.Web.UI.Page
{
    public string codigo_grupo = "";
    public string Nom_Grupo = "";
    SqlConnection conSQL = new SqlConnection(ConfigurationManager.ConnectionStrings["SAP_WEBConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int Id = Convert.ToInt32(Request.QueryString["id"].ToString());
            if (Session["Cliente_Numero"] != null)
            {
                LlenarGrupo();
                traerDatos(Id);
            }
        }
    }

    #region DROPDOWN
    protected void LlenarGrupo()
    {
        string consulta1;
        try
        {
            ListItem item = new ListItem();
            item.Text = "Seleccionar Grupo..";
            item.Value = "";
            DDLGrupo.Items.Add(item);
            consulta1 = "EXEC Sp_Lst_Grupo_Concesionario";
            SqlDataAdapter adaptador1 = new SqlDataAdapter(consulta1, conSQL);
            DataTable table = new DataTable();
            table = new DataTable("migrupo");
            adaptador1.Fill(table);
            for (Int32 k = 0; k <= table.Rows.Count - 1; k++)
            {
                string ID_grupo = table.Rows[k][0].ToString().Trim();
                ListItem item2 = new ListItem();
                item2.Text = ID_grupo;
                item2.Value = ID_grupo;
                DDLGrupo.Items.Add(item2);
            }
        }
        catch (Exception)
        { if (conSQL != null) conSQL.Close(); }
        finally
        { if (conSQL != null) conSQL.Close(); }
    }
    protected void DDLGrupo_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDLSucursal.Items.Clear();
        Nom_Grupo = DDLGrupo.SelectedValue.ToString();
        LlenarSucursal();
    }
    protected void LlenarSucursal()
    {
        string consulta1;
        try
        {
            ListItem itemS = new ListItem();
            itemS.Text = "Seleccionar Sucursal..";
            itemS.Value = "";
            DDLSucursal.Items.Add(itemS);
            consulta1 = "EXEC Sp_Lst_Grupo_Concesionario_Detalle"; consulta1 = consulta1 + " " + "'" + Nom_Grupo + "'";
            SqlDataAdapter adaptador1 = new SqlDataAdapter(consulta1, conSQL);
            DataTable table = new DataTable();
            table = new DataTable("misucursal");
            adaptador1.Fill(table);
            for (Int32 k = 0; k <= table.Rows.Count - 1; k++)
            {
                string ID_Sucursal = table.Rows[k][1].ToString().Trim();
                string NB_Sucursal = table.Rows[k][2].ToString().Trim();
                ListItem itemS2 = new ListItem();
                itemS2.Text = NB_Sucursal;
                itemS2.Value = ID_Sucursal;
                DDLSucursal.Items.Add(itemS2);
            }
        }
        catch (Exception)
        { if (conSQL != null) conSQL.Close(); }
        finally
        { if (conSQL != null) conSQL.Close(); }
    }
    #endregion

    #region CHECK
    protected void ChkActivo_CheckedChanged(object sender, EventArgs e)
    {
        bool value = ChkActivo.Checked;
    }
    #endregion

    #region botones
    protected void btn_Atras_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "closewindows", "parent.jQuery.fancybox.close();", true);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "closewindows", "parent.jQuery.fancybox.close();", true);
    }
    protected void btn_Guardar_Click(object sender, EventArgs e)
    {
        int Id = Convert.ToInt32(Request.QueryString["id"].ToString());
        if (Request.QueryString["id"] != null)
        {
            string sucursal = DDLSucursal.SelectedValue.ToString();
            string nombre = txtNombre.Value;
            string cargo = txtCargo.Value;
            string correo = txtMail.Value;
            string telefono = txtTel1.Value;
            bool bactivo = ChkActivo.Checked;
            int activo = 0;
            if (bactivo) activo = 1;

            string SQL = "";
            SQL = "EXEC Sp_Upd_Usados_Certificados_Mail";
            SQL = SQL + " " + Id;
            SQL = SQL + " ,'" + sucursal;
            SQL = SQL + "', '" + nombre;
            SQL = SQL + "', '" + cargo;
            SQL = SQL + "', '" + correo;
            SQL = SQL + "', '" + telefono;
            SQL = SQL + "', " + activo;
            //Response.Write(SQL);
            //Response.End();
            try
            {
                conSQL.Open();
                SqlCommand cmd = new SqlCommand(SQL, conSQL);
                cmd.ExecuteNonQuery();
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
        else
        { ClientScript.RegisterStartupScript(this.GetType(), "closewindows", "parent.jQuery.fancybox.close();", true); }
    }
    #endregion

    #region BD
    protected void traerDatos(int param)
    {
        string SQL = "";
        SQL = "select * from usados_certificados_mail where id=" + param;
        conSQL.Open();
        try
        {
            SqlDataAdapter ad = new SqlDataAdapter(SQL, conSQL);
            DataTable tbl = new DataTable();
            tbl = new DataTable("miTabla");
            ad.Fill(tbl);
            if (tbl.Rows.Count > 0)
            {
                /* buscar el Grupo de acuerdo a la Sucursal */
                string sucursal = tbl.Rows[0]["Cod_Concesionario"].ToString().Trim();
                if (sucursal != "")
                {
                    string _sql = "select ID_GRUPO from grupo_concesionario where concesionario = '" + sucursal + "'";
                    SqlDataAdapter adaptador1 = new SqlDataAdapter(_sql, conSQL);
                    DataTable table = new DataTable();
                    table = new DataTable("migrupo");
                    adaptador1.Fill(table);
                    if (table.Rows.Count > 0)
                    {
                        DDLGrupo.SelectedValue = table.Rows[0]["ID_GRUPO"].ToString().Trim();
                        Nom_Grupo = DDLGrupo.SelectedValue.ToString();
                        LlenarSucursal();
                        DDLSucursal.SelectedValue = sucursal;
                    }
                }
                else
                {
                    DDLGrupo.SelectedValue = Session["Cliente_Nombre"].ToString().Trim();
                }
                DDLSucursal.SelectedValue = tbl.Rows[0]["Cod_Concesionario"].ToString();
                txtNombre.Value = tbl.Rows[0]["Nombre"].ToString();
                txtCargo.Value = tbl.Rows[0]["Cargo"].ToString();
                txtMail.Value = tbl.Rows[0]["Correo"].ToString();
                txtTel1.Value = tbl.Rows[0]["Telefono"].ToString();
                bool aprobador;
                aprobador = Convert.ToBoolean(tbl.Rows[0]["Aprobador_94"]);
                if (!aprobador)
                    ChkActivo.Checked = false;
                else
                    ChkActivo.Checked = true;
            }
        }
        catch (Exception ex)
        { }
        finally
        { if (conSQL != null) conSQL.Close(); }
    }
    #endregion
}
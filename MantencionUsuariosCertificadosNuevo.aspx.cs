using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Usados_Certificados_MantencionUsuariosCertificadosNuevo : System.Web.UI.Page
{
    public string codigo_grupo = "";
    public string Nom_Grupo = "";
    SqlConnection conSQL = new SqlConnection(ConfigurationManager.ConnectionStrings["SAP_WEBConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LlenarGrupo();
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
        string CodConc = DDLSucursal.SelectedValue.ToString();
        string nombre = txtNombre.Value;
        string correo = txtMail.Value;
        string cargo = txtCargo.Value;
        string telefono = txtTel1.Value;
        bool bactivo = ChkActivo.Checked;
        int activo = 0;
        if (bactivo) activo = 1;

        string SqlIns = "";
        SqlIns = "EXEC Sp_Ins_Usados_Certificados_Mail";
        SqlIns = SqlIns + " '" + CodConc;
        SqlIns = SqlIns + "', '" + nombre;
        SqlIns = SqlIns + "', '" + cargo;
        SqlIns = SqlIns + "', '" + correo;
        SqlIns = SqlIns + "', '" + telefono;
        SqlIns = SqlIns + "', " + activo;
        try
        {
            conSQL.Open();
            SqlCommand cmd = new SqlCommand(SqlIns, conSQL);
            cmd.ExecuteNonQuery();
            string script = @"<script type='text/javascript'>
                                        openCustom();
                                    </script>";

            ClientScript.RegisterStartupScript(this.GetType(), "invocarfuncion", script, false);
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
}
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;

public partial class Usados_Certificados_ListaUsuarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (this.GridView1.Rows.Count > 0)
            //    GroupGridView(GridView1.Rows, 1, 3);
        }
    }

    #region botones
    protected void deleteParam(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        ImageButton imgBtn = (ImageButton)sender;
        string codigo = imgBtn.CommandArgument;
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SAP_WEBConnectionString"].ConnectionString);
        try
        {
            string sql = "EXEC Sp_Del_Usados_Certificados_Mail " + Convert.ToInt32(codigo);
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
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
    #endregion

    void GroupGridView(GridViewRowCollection gvrc, int startIndex, int total)
    {
        if (total == 0) return;
        int i, count = 1;
        ArrayList lst = new ArrayList();
        lst.Add(gvrc[0]);
        TableCell ctrl = new TableCell(); /* esta decalaracion es para FrameWork 2.0 */
        ctrl = gvrc[0].Cells[startIndex];
        //var ctrl = gvrc[0].Cells[startIndex]; /* esta decalaracion es para FrameWork 4.0 */
        for (i = 1; i < gvrc.Count; i++)
        {
            TableCell nextCell = gvrc[i].Cells[startIndex];
            if (ctrl.Text == nextCell.Text)
            {
                count++;
                nextCell.Visible = false;
                lst.Add(gvrc[i]);
            }
            else
            {
                if (count > 1)
                {
                    ctrl.RowSpan = count;
                    GroupGridView(new GridViewRowCollection(lst), startIndex + 1, total - 1);
                }
                count = 1;
                lst.Clear();
                ctrl = gvrc[i].Cells[startIndex];
                lst.Add(gvrc[i]);
            }
        }
        if (count > 1)
        {
            ctrl.RowSpan = count;
            GroupGridView(new GridViewRowCollection(lst), startIndex + 1, total - 1);
        }
        count = 1;
        lst.Clear();
    }
}
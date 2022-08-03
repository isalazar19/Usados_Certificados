using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Usados_Certificados_FormDetalle06Nuevo : System.Web.UI.Page
{
    SqlConnection conSQL = new SqlConnection(ConfigurationManager.ConnectionStrings["SAP_WEBConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["P85"] != null && Session["P86"] != null && Session["P87"] != null && Session["P88"] != null && Session["P89"] != null &&
                Session["P90"] != null && Session["P91"] != null && Session["P92"] != null && Session["P93"] != null && Session["P94"] != null)
            {
                DDL85.SelectedValue = Session["P85"].ToString(); DDL86.SelectedValue = Session["P86"].ToString(); DDL87.SelectedValue = Session["P87"].ToString(); DDL88.SelectedValue = Session["P88"].ToString(); DDL89.SelectedValue = Session["P89"].ToString();
                DDL90.SelectedValue = Session["P90"].ToString(); DDL91.SelectedValue = Session["P91"].ToString(); DDL92.SelectedValue = Session["P92"].ToString(); DDL93.SelectedValue = Session["P93"].ToString(); DDL94.SelectedValue = Session["P94"].ToString();
                /* Comentarios */
                txtComentarios85.Value = Session["C85"].ToString(); txtComentarios86.Value = Session["C86"].ToString(); txtComentarios87.Value = Session["C87"].ToString();
                txtComentarios88.Value = Session["C88"].ToString(); txtComentarios89.Value = Session["C89"].ToString(); txtComentarios90.Value = Session["C90"].ToString();
                txtComentarios91.Value = Session["C91"].ToString(); txtComentarios92.Value = Session["C92"].ToString(); txtComentarios93.Value = Session["C93"].ToString();
                txtComentarios94.Value = Session["C94"].ToString();
            }
        }
    }
    #region botones
    protected void btn_Atras_Click(object sender, EventArgs e)
    {
        Session["botonAtras"] = "si";
        Session["P85"] = DDL85.SelectedValue.ToString(); Session["P86"] = DDL86.SelectedValue.ToString(); Session["P87"] = DDL87.SelectedValue.ToString(); Session["P88"] = DDL88.SelectedValue.ToString(); Session["P89"] = DDL89.SelectedValue.ToString();
        Session["P90"] = DDL90.SelectedValue.ToString(); Session["P91"] = DDL91.SelectedValue.ToString(); Session["P92"] = DDL92.SelectedValue.ToString(); Session["P93"] = DDL93.SelectedValue.ToString(); Session["P94"] = DDL94.SelectedValue.ToString();
        /* Comentarios */
        Session["C85"] = txtComentarios85.Value; Session["C86"] = txtComentarios86.Value; Session["C87"] = txtComentarios87.Value; Session["C88"] = txtComentarios88.Value; Session["C89"] = txtComentarios89.Value;
        Session["C90"] = txtComentarios90.Value; Session["C91"] = txtComentarios91.Value; Session["C92"] = txtComentarios92.Value; Session["C93"] = txtComentarios93.Value; Session["C94"] = txtComentarios94.Value;
        Response.Redirect("FormDetalle05Nuevo.aspx?pagina=5");
    }
    protected void btn_Salir_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "closewindows", "parent.jQuery.fancybox.close();", true);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "closewindows", "parent.jQuery.fancybox.close();", true);
    }
    protected void btn_Guardar_Click(object sender, EventArgs e)
    {
        if (validar())
        {
            Session["P85"] = DDL85.SelectedValue.ToString(); Session["P86"] = DDL86.SelectedValue.ToString(); Session["P87"] = DDL87.SelectedValue.ToString(); Session["P88"] = DDL88.SelectedValue.ToString(); Session["P89"] = DDL89.SelectedValue.ToString();
            Session["P90"] = DDL90.SelectedValue.ToString(); Session["P91"] = DDL91.SelectedValue.ToString(); Session["P92"] = DDL92.SelectedValue.ToString(); Session["P93"] = DDL93.SelectedValue.ToString(); Session["P94"] = DDL94.SelectedValue.ToString();
            /* Comentarios */
            Session["C85"] = txtComentarios85.Value; Session["C86"] = txtComentarios86.Value; Session["C87"] = txtComentarios87.Value; Session["C88"] = txtComentarios88.Value; Session["C89"] = txtComentarios89.Value;
            Session["C90"] = txtComentarios90.Value; Session["C91"] = txtComentarios91.Value; Session["C92"] = txtComentarios92.Value; Session["C93"] = txtComentarios93.Value; Session["C94"] = txtComentarios94.Value;

            /* Datos de Cabecera  */
            int Mant_30d = 0;
            int Mant_10K = 0;
            int Mant_20K = 0;
            int Mant_30K = 0;
            int Mant_40K = 0;
            int Mant_50K = 0;
            int Mant_60K = 0;
            int Mant_70K = 0;
            int Mant_80K = 0;
            int Mant_90K = 0;
            string NumeroStock = Session["Stock"].ToString();
            string VIN = Session["VIN"].ToString();
            string Modelo = Session["Modelo"].ToString();
            string Version = Session["Version"].ToString();
            string Patente = Session["Patente"].ToString();
            string KmsActual = Session["Kms"].ToString();
            string FechaVenta = Session["FechaVta"].ToString();
            string AñoUso = Session["AñoUso"].ToString();
            string OT = Session["OT"].ToString();
            if (Session["30d"] == "1") Mant_30d = 1;
            if (Session["10k"] == "10") Mant_10K = 1;
            if (Session["20k"] == "20") Mant_20K = 1;
            if (Session["30k"] == "30") Mant_30K = 1;
            if (Session["40k"] == "40") Mant_40K = 1;
            if (Session["50k"] == "50") Mant_50K = 1;
            if (Session["60k"] == "60") Mant_60K = 1;
            if (Session["70k"] == "70") Mant_70K = 1;
            if (Session["80k"] == "80") Mant_80K = 1;
            if (Session["90k"] == "90") Mant_90K = 1;
            string Comentarios = Session["Comentarios"].ToString();
            string CodConc = Session["Cliente_Numero"].ToString();

            string SqlInsHdr = "";
            SqlInsHdr = "EXEC Sp_Ins_Usados_Certificados_Header";
            SqlInsHdr = SqlInsHdr + " '" + NumeroStock;
            SqlInsHdr = SqlInsHdr + "', '" + VIN;
            SqlInsHdr = SqlInsHdr + "', '" + Patente;
            SqlInsHdr = SqlInsHdr + "', '" + Modelo;
            SqlInsHdr = SqlInsHdr + "', '" + Version;
            SqlInsHdr = SqlInsHdr + "', '" + CodConc;
            SqlInsHdr = SqlInsHdr + "', " + Convert.ToInt32(KmsActual);
            SqlInsHdr = SqlInsHdr + " , '" + FechaVenta;
            SqlInsHdr = SqlInsHdr + "', " + Mant_30d;
            SqlInsHdr = SqlInsHdr + ", " + Mant_10K;
            SqlInsHdr = SqlInsHdr + ", " + Mant_20K;
            SqlInsHdr = SqlInsHdr + ", " + Mant_30K;
            SqlInsHdr = SqlInsHdr + ", " + Mant_40K;
            SqlInsHdr = SqlInsHdr + ", " + Mant_50K;
            SqlInsHdr = SqlInsHdr + ", " + Mant_60K;
            SqlInsHdr = SqlInsHdr + ", " + Mant_70K;
            SqlInsHdr = SqlInsHdr + ", " + Mant_80K;
            SqlInsHdr = SqlInsHdr + ", " + Mant_90K;
            SqlInsHdr = SqlInsHdr + ", '" + AñoUso;
            SqlInsHdr = SqlInsHdr + "', '" + OT;
            SqlInsHdr = SqlInsHdr + "', '" + Comentarios + "'";

            try
            {
                conSQL.Open();
                SqlCommand cmd = new SqlCommand(SqlInsHdr, conSQL);
                cmd.ExecuteNonQuery();
                conSQL.Close();

                /* Datos Detalle */
                string SqlInsDet = "";
                string comentario = "";
                int i = 0;
                while (i <= 94 - 1)
                {
                    if (i == 0)
                    {
                        int pregunta = 1;
                        string resultado = Session["P1"].ToString();
                        comentario = Session["C1"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 1)
                    {
                        int pregunta = 2;
                        string resultado = Session["P2"].ToString();
                        comentario = Session["C2"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 2)
                    {
                        int pregunta = 3;
                        string resultado = Session["P3"].ToString();
                        comentario = Session["C3"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 3)
                    {
                        int pregunta = 4;
                        string resultado = Session["P4"].ToString();
                        comentario = Session["C4"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 4)
                    {
                        int pregunta = 5;
                        string resultado = Session["P5"].ToString();
                        comentario = Session["C5"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 5)
                    {
                        int pregunta = 6;
                        string resultado = Session["P6"].ToString();
                        comentario = Session["C6"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 6)
                    {
                        int pregunta = 7;
                        string resultado = Session["P7"].ToString();
                        comentario = Session["C7"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 7)
                    {
                        int pregunta = 8;
                        string resultado = Session["P8"].ToString();
                        comentario = Session["C8"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 8)
                    {
                        int pregunta = 9;
                        string resultado = Session["P9"].ToString();
                        comentario = Session["C9"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 9)
                    {
                        int pregunta = 10;
                        string resultado = Session["P10"].ToString();
                        comentario = Session["C10"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 10)
                    {
                        int pregunta = 11;
                        string resultado = Session["P11"].ToString();
                        comentario = Session["C11"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 11)
                    {
                        int pregunta = 12;
                        string resultado = Session["P12"].ToString();
                        comentario = Session["C12"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 12)
                    {
                        int pregunta = 13;
                        string resultado = Session["P13"].ToString();
                        comentario = Session["C13"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 13)
                    {
                        int pregunta = 14;
                        string resultado = Session["P14"].ToString();
                        comentario = Session["C14"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 14)
                    {
                        int pregunta = 15;
                        string resultado = Session["P15"].ToString();
                        comentario = Session["C15"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 15)
                    {
                        int pregunta = 16;
                        string resultado = Session["P16"].ToString();
                        comentario = Session["C16"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 16)
                    {
                        int pregunta = 17;
                        string resultado = Session["P17"].ToString();
                        comentario = Session["C17"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 17)
                    {
                        int pregunta = 18;
                        string resultado = Session["P18"].ToString();
                        comentario = Session["C18"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 18)
                    {
                        int pregunta = 19;
                        string resultado = Session["P19"].ToString();
                        comentario = Session["C19"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 19)
                    {
                        int pregunta = 20;
                        string resultado = Session["P20"].ToString();
                        comentario = Session["C20"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 20)
                    {
                        int pregunta = 21;
                        string resultado = Session["P21"].ToString();
                        comentario = Session["C21"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 21)
                    {
                        int pregunta = 22;
                        string resultado = Session["P22"].ToString();
                        comentario = Session["C22"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 22)
                    {
                        int pregunta = 23;
                        string resultado = Session["P23"].ToString();
                        comentario = Session["C23"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 23)
                    {
                        int pregunta = 24;
                        string resultado = Session["P24"].ToString();
                        comentario = Session["C24"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 24)
                    {
                        int pregunta = 25;
                        string resultado = Session["P25"].ToString();
                        comentario = Session["C25"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 25)
                    {
                        int pregunta = 26;
                        string resultado = Session["P26"].ToString();
                        comentario = Session["C26"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 26)
                    {
                        int pregunta = 27;
                        string resultado = Session["P27"].ToString();
                        comentario = Session["C27"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 27)
                    {
                        int pregunta = 28;
                        string resultado = Session["P28"].ToString();
                        comentario = Session["C28"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 28)
                    {
                        int pregunta = 29;
                        string resultado = Session["P29"].ToString();
                        comentario = Session["C29"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 29)
                    {
                        int pregunta = 30;
                        string resultado = Session["P30"].ToString();
                        comentario = Session["C30"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 30)
                    {
                        int pregunta = 31;
                        string resultado = Session["P31"].ToString();
                        comentario = Session["C31"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 31)
                    {
                        int pregunta = 32;
                        string resultado = Session["P32"].ToString();
                        comentario = Session["C32"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 32)
                    {
                        int pregunta = 33;
                        string resultado = Session["P33"].ToString();
                        comentario = Session["C33"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 33)
                    {
                        int pregunta = 34;
                        string resultado = Session["P34"].ToString();
                        comentario = Session["C34"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 34)
                    {
                        int pregunta = 35;
                        string resultado = Session["P35"].ToString();
                        comentario = Session["C35"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 35)
                    {
                        int pregunta = 36;
                        string resultado = Session["P36"].ToString();
                        comentario = Session["C36"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 36)
                    {
                        int pregunta = 37;
                        string resultado = Session["P37"].ToString();
                        comentario = Session["C37"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 37)
                    {
                        int pregunta = 38;
                        string resultado = Session["P38"].ToString();
                        comentario = Session["C38"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 38)
                    {
                        int pregunta = 39;
                        string resultado = Session["P39"].ToString();
                        comentario = Session["C39"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 39)
                    {
                        int pregunta = 40;
                        string resultado = Session["P40"].ToString();
                        comentario = Session["C40"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 40)
                    {
                        int pregunta = 41;
                        string resultado = Session["P41"].ToString();
                        comentario = Session["C41"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 41)
                    {
                        int pregunta = 42;
                        string resultado = Session["P42"].ToString();
                        comentario = Session["C42"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 42)
                    {
                        int pregunta = 43;
                        string resultado = Session["P43"].ToString();
                        comentario = Session["C43"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 43)
                    {
                        int pregunta = 44;
                        string resultado = Session["P44"].ToString();
                        comentario = Session["C44"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 44)
                    {
                        int pregunta = 45;
                        string resultado = Session["P45"].ToString();
                        comentario = Session["C45"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 45)
                    {
                        int pregunta = 46;
                        string resultado = Session["P46"].ToString();
                        comentario = Session["C46"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 46)
                    {
                        int pregunta = 47;
                        string resultado = Session["P47"].ToString();
                        comentario = Session["C47"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 47)
                    {
                        int pregunta = 48;
                        string resultado = Session["P48"].ToString();
                        comentario = Session["C48"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 48)
                    {
                        int pregunta = 49;
                        string resultado = Session["P49"].ToString();
                        comentario = Session["C49"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 49)
                    {
                        int pregunta = 50;
                        string resultado = Session["P50"].ToString();
                        comentario = Session["C50"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 50)
                    {
                        int pregunta = 51;
                        string resultado = Session["P51"].ToString();
                        comentario = Session["C51"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 51)
                    {
                        int pregunta = 52;
                        string resultado = Session["P52"].ToString();
                        comentario = Session["C52"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 52)
                    {
                        int pregunta = 53;
                        string resultado = Session["P53"].ToString();
                        comentario = Session["C53"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 53)
                    {
                        int pregunta = 54;
                        string resultado = Session["P54"].ToString();
                        comentario = Session["C54"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 54)
                    {
                        int pregunta = 55;
                        string resultado = Session["P55"].ToString();
                        comentario = Session["C55"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 55)
                    {
                        int pregunta = 56;
                        string resultado = Session["P56"].ToString();
                        comentario = Session["C56"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 56)
                    {
                        int pregunta = 57;
                        string resultado = Session["P57"].ToString();
                        comentario = Session["C57"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 57)
                    {
                        int pregunta = 58;
                        string resultado = Session["P58"].ToString();
                        comentario = Session["C58"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 58)
                    {
                        int pregunta = 59;
                        string resultado = Session["P59"].ToString();
                        comentario = Session["C59"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 59)
                    {
                        int pregunta = 60;
                        string resultado = Session["P60"].ToString();
                        comentario = Session["C60"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 60)
                    {
                        int pregunta = 61;
                        string resultado = Session["P61"].ToString();
                        comentario = Session["C61"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 61)
                    {
                        int pregunta = 62;
                        string resultado = Session["P62"].ToString();
                        comentario = Session["C62"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 62)
                    {
                        int pregunta = 63;
                        string resultado = Session["P63"].ToString();
                        comentario = Session["C63"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 63)
                    {
                        int pregunta = 64;
                        string resultado = Session["P64"].ToString();
                        comentario = Session["C64"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 64)
                    {
                        int pregunta = 65;
                        string resultado = Session["P65"].ToString();
                        comentario = Session["C65"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 65)
                    {
                        int pregunta = 66;
                        string resultado = Session["P66"].ToString();
                        comentario = Session["C66"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 66)
                    {
                        int pregunta = 67;
                        string resultado = Session["P67"].ToString();
                        comentario = Session["C67"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 67)
                    {
                        int pregunta = 68;
                        string resultado = Session["P68"].ToString();
                        comentario = Session["C68"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 68)
                    {
                        int pregunta = 69;
                        string resultado = Session["P69"].ToString();
                        comentario = Session["C69"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 69)
                    {
                        int pregunta = 70;
                        string resultado = Session["P70"].ToString();
                        comentario = Session["C70"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 70)
                    {
                        int pregunta = 71;
                        string resultado = Session["P71"].ToString();
                        comentario = Session["C71"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 71)
                    {
                        int pregunta = 72;
                        string resultado = Session["P72"].ToString();
                        comentario = Session["C72"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 72)
                    {
                        int pregunta = 73;
                        string resultado = Session["P74"].ToString();
                        comentario = Session["C74"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 73)
                    {
                        int pregunta = 74;
                        string resultado = Session["P74"].ToString();
                        comentario = Session["C74"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 74)
                    {
                        int pregunta = 75;
                        string resultado = Session["P75"].ToString();
                        comentario = Session["C75"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 75)
                    {
                        int pregunta = 76;
                        string resultado = Session["P76"].ToString();
                        comentario = Session["C76"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 76)
                    {
                        int pregunta = 77;
                        string resultado = Session["P77"].ToString();
                        comentario = Session["C77"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 77)
                    {
                        int pregunta = 78;
                        string resultado = Session["P78"].ToString();
                        comentario = Session["C78"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 78)
                    {
                        int pregunta = 79;
                        string resultado = Session["P79"].ToString();
                        comentario = Session["C79"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 79)
                    {
                        int pregunta = 80;
                        string resultado = Session["P80"].ToString();
                        comentario = Session["C80"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 80)
                    {
                        int pregunta = 81;
                        string resultado = Session["P81"].ToString();
                        comentario = Session["C81"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 81)
                    {
                        int pregunta = 82;
                        string resultado = Session["P82"].ToString();
                        comentario = Session["C82"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 82)
                    {
                        int pregunta = 83;
                        string resultado = Session["P83"].ToString();
                        comentario = Session["C83"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 83)
                    {
                        int pregunta = 84;
                        string resultado = Session["P84"].ToString();
                        comentario = Session["C84"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 84)
                    {
                        int pregunta = 85;
                        string resultado = Session["P85"].ToString();
                        comentario = Session["C85"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 85)
                    {
                        int pregunta = 86;
                        string resultado = Session["P86"].ToString();
                        comentario = Session["C86"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 86)
                    {
                        int pregunta = 87;
                        string resultado = Session["P87"].ToString();
                        comentario = Session["C87"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 87)
                    {
                        int pregunta = 88;
                        string resultado = Session["P88"].ToString();
                        comentario = Session["C88"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 88)
                    {
                        int pregunta = 89;
                        string resultado = Session["P89"].ToString();
                        comentario = Session["C89"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 89)
                    {
                        int pregunta = 90;
                        string resultado = Session["P90"].ToString();
                        comentario = Session["C90"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 90)
                    {
                        int pregunta = 91;
                        string resultado = Session["P91"].ToString();
                        comentario = Session["C91"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 91)
                    {
                        int pregunta = 92;
                        string resultado = Session["P92"].ToString();
                        comentario = Session["C92"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 92)
                    {
                        int pregunta = 93;
                        string resultado = Session["P93"].ToString();
                        comentario = Session["C93"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }
                    if (i == 93)
                    {
                        int pregunta = 94;
                        string resultado = Session["P94"].ToString();
                        comentario = Session["C94"].ToString();
                        SqlInsDet = "EXEC Sp_Ins_Usados_Certificados_Detalle";
                        SqlInsDet = SqlInsDet + " '" + NumeroStock;
                        SqlInsDet = SqlInsDet + "', " + pregunta;
                        SqlInsDet = SqlInsDet + ", " + Convert.ToInt32(resultado);
                        SqlInsDet = SqlInsDet + ", '" + comentario + "'";
                    }

                        conSQL.Open();
                        cmd = new SqlCommand(SqlInsDet, conSQL);
                        cmd.ExecuteNonQuery();
                        conSQL.Close();
                    
                    i++;
                }

                string script = @"<script type='text/javascript'>
                                        openCustom();
                                    </script>";

                ClientScript.RegisterStartupScript(this.GetType(), "invocarfuncion", script, false);

                Enviar_Correo(CodConc, NumeroStock, Patente, Modelo, Version);

            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>
                                         setTimeout(function () {
                                            $.Notify({ type: 'alert', caption: 'Aviso', content: 'Ocurrio un error al Grabar en la Cabecera', icon: '<span class='mif-warning'></span>' });
                                            }, 1000);
                                        </script>";

                ClientScript.RegisterStartupScript(this.GetType(), "invocarfuncion", script, false);
            }
            finally
            { if (conSQL != null) conSQL.Close(); }
        }
    }
    public bool validar()
    {
        bool retorno = true;
        if (DDL85.SelectedValue == "0" || DDL86.SelectedValue == "0" || DDL87.SelectedValue == "0" || DDL88.SelectedValue == "0" || DDL89.SelectedValue == "0" || DDL90.SelectedValue == "0" || DDL91.SelectedValue == "0" ||
            DDL92.SelectedValue == "0" || DDL93.SelectedValue == "0" || DDL94.SelectedValue == "0")
        { Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "MensajeValidaResultado();", true); retorno = false; }
        return retorno;
    }
    #endregion

    #region CORREO
    protected void Enviar_Correo(string concesionario, string stock, string patente, string modelo, string version)
    {
        string _correoDestinatario = "";
        string _asunto = "";
        string SQL = "";
        SQL = "select * from usados_certificados_mail where cod_concesionario = '" + concesionario + "'";
        SQL = SQL + " " + "and aprobador_94=1"; 
        conSQL.Open();
        try
        {
            SqlDataAdapter ad = new SqlDataAdapter(SQL, conSQL);
            DataTable tbl = new DataTable();
            tbl = new DataTable("datos");
            ad.Fill(tbl);
            if (tbl.Rows.Count > 0)
            {
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    if (i == 0)
                        _correoDestinatario = tbl.Rows[i]["CORREO"].ToString();
                    else
                        _correoDestinatario = _correoDestinatario + ";" + tbl.Rows[i]["CORREO"].ToString();
                        _asunto = "Usados certificados – Formulario de Aprobación ";
                }
            }
            else
            {
                _correoDestinatario = "fmerida@toyota.cl";
                _asunto = "Usados certificados – Formulario de Aprobación (Dealer sin Aprobador 94 puntos)";
            }
        }
        catch (Exception ex)
        { }
        finally
        { if (conSQL != null) conSQL.Close(); }

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
        texto = texto + "                                                                                        <p>Junto con saludar, le informamos que hemos recibido un formulario del programa Toyota usados certificados el cual necesita de su aprobación  y corresponde al siguiente vehículo:";
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
        miEmail.email = _correoDestinatario;
        miEmail.cc = "";
        miEmail.asunto = _asunto; // "Usados certificados – Formulario de Aprobación";
        miEmail.prioridad = 3;
        miEmail.mensaje = texto;
        miEmail.isHTML = true;

        miEmail.Enviar();
    }
    #endregion
}
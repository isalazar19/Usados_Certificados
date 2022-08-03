<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MantencionUsuariosCertificadosNuevo.aspx.cs" Inherits="Usados_Certificados_MantencionUsuariosCertificadosNuevo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/metro.css" rel="stylesheet" type="text/css" />
    <link href="../GEMBA/css/metro-icons.css" rel="stylesheet" type="text/css" />
    <link href="../GEMBA/css/metro-bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../GEMBA/css/metro-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../GEMBA/css/metro-schemes.css" rel="stylesheet" type="text/css" />
    <link href="../GEMBA/css/docs.css" rel="stylesheet" type="text/css" />

    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />


    <%--<link href="../GEMBA/css/style.css" rel="stylesheet" type="text/css" />--%>
    <script src="../GEMBA/js/jquery.fancybox.pack.js" type="text/javascript"></script>
    <script src="../GEMBA/js/jquery-2.1.3.min.js" type="text/javascript"></script>
    <script src="../GEMBA/js/jquery-3.3.1.min.js" type="text/javascript"></script>

    <%--<script src="js/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="js/jquery/jquery.dataTables.js" type="text/javascript"></script>
    <link href="css/dataTables.bootstrap.css" rel="stylesheet" type="text/css" />--%>


    <script src="../GEMBA/js/v2_metro.js" type="text/javascript"></script>
    <%--<script src="js/v3_metro.js" type="text/javascript"></script>--%>
    <script src="../GEMBA/js/docs.js" type="text/javascript"></script>
    <script src="../GEMBA/js/ga.js" type="text/javascript"></script>

    <script type="text/javascript">
        function openCustom() {
                metroDialog.create({
                    title: "Información",
                    content: "Registro Guardado Satisfactoriamente!!!",
                    actions: [
                            {
                                title: "Ok",
                                onclick: function (el) {
                                    //console.log(el);
                                    $(el).data('dialog').close();
                                    parent.jQuery.fancybox.close();
                                }
                            }
                    //                    {
                    //                        title: "Cancel",
                    //                        cls: "js-dialog-close"
                    //                    }
                        ],
                    options: {
                    }
                });
            }
        </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="span12">
        <br /><br />
        <fieldset style="border: 1px solid #999; border-radius: 8px; box-shadow:0 0 10px #999;"">
 
            <table width="50%">
                <tr>
                    <td>
                        <label style="text-align: left;">Grupo</label>
                        <div class="input-control select" >
                            <asp:DropDownList ID="DDLGrupo" runat="server" style="width: 99%;" 
                                AutoPostBack="True" onselectedindexchanged="DDLGrupo_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </td>
                    <td>
                        <label style="text-align: left;">Sucursal Agendamiento</label>
                        <div class="input-control select" >
                            <asp:DropDownList ID="DDLSucursal" runat="server">
                            </asp:DropDownList>
                        </div>
                    </td>
                </tr>
            </table>
            <table width="10%">
                <tr>
                    <td>
                        <label style="text-align: left;">Nombre</label>
                        <div class="input-control text" data-role="input-control">
                            <input type="text" placeholder="" id="txtNombre" maxlength="50" runat="server" style="width: 220%;" />
                        </div>
                    </td>
                    <td>
                        <label style="text-align: left; margin-left: 250px;">Cargo</label>
                        <div class="input-control text" data-role="input-control">
                            <input type="text" placeholder="" id="txtCargo" maxlength="50" runat="server" style="width: 220%; margin-left: 250px;" />
                        </div>
                    </td>
                </tr>
            </table>
            <table width="10%">
                <tr>
                    <td>
                        <label style="text-align: left;">Correo electrónico</label>
                        <div class="input-control text" data-role="input-control">
                            <input type="text" placeholder="" id="txtMail" maxlength="130" runat="server" style="width: 550%;" />
                        </div>
                    </td>
                </tr>
            </table>
            <table width="10%">
                <tr>
                    <td>
                        <label style="text-align: left;">Teléfono</label>
                        <div class="input-control text" data-role="input-control">
                            <input type="text" placeholder="" id="txtTel1" maxlength="20" runat="server" />
                        </div>
                    </td>
                    <td>
                         <div class="input-control switch margin10" data-role="input-control">
                            <label style="margin-left: 50px;">
                                Aprobador
                                <asp:CheckBox ID="ChkActivo" runat="server" AutoPostBack="True"
                                oncheckedchanged="ChkActivo_CheckedChanged"  />
                                    <br /><span class="check" style="margin-top: 10px; margin-left: 50px;"></span>
                            </label>
                        </div>
                    </td>
                </tr>
            </table>

        </fieldset>
    </div>
    <br /><br />
    <div align="center">
        <button class="image-button primary" id="btn_Guardar" runat="server" onserverclick="btn_Guardar_Click">
            Grabar
            <span class="icon mif-floppy-disk bg-darkCobalt"></span>
        </button>
        <button class="image-button primary" id="btn_Atras" runat="server" onserverclick="btn_Atras_Click">
            Salir
            <span class="icon mif-exit bg-darkCobalt"></span>
        </button>
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormDetalle06Nuevo.aspx.cs" Inherits="Usados_Certificados_FormDetalle06Nuevo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
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
        function MensajeValidaResultado() {
            setTimeout(function () {
                $.Notify({ type: 'alert', caption: 'Aviso', content: "Indique un Resultado", icon: "<span class='mif-warning'></span>" });
            }, 1000);
        }

        function openCustom() {
            metroDialog.create({
                title: "Información",
                content: "Formulario Guardado Satisfactoriamente!!!",
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
    <div>
        <table class="table" id="GridView1" style="border-collapse: collapse; width: 100%;" border="1" rules="all" cellspacing="0">
            <tr>
                <th style="background-color: Silver;" scope="col" colspan="2">
                    (VI) PRUEBA DE RUTA, TRANSMISION, TRACCIÓN E INDICADORES.
                </th>
                <th style="background-color: Silver;" scope="col">
                    Resultado
                </th>
                <th style="background-color: Silver;" scope="col">
                    Comentarios
                </th>
            </tr>
            <tr>
                <td>85</td>
                <td style="text-align: justify;">El medidor de la temperatura funciona correctamente.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL85" runat="server">
                            <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                            <asp:ListItem Value="1">OK</asp:ListItem>
                            <asp:ListItem Value="2">N/A</asp:ListItem>
                            <asp:ListItem Value="3">Reparar</asp:ListItem>
                            <asp:ListItem Value="4">Reemplazar</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </td>
                <td width="30%">
                    <label>
                        <textarea maxlength="500"  runat="server" id="txtComentarios85"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>86</td>
                <td style="text-align: justify;">El velocímetro, tacometro y el odómetro funcionan correctamente.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL86" runat="server">
                            <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                            <asp:ListItem Value="1">OK</asp:ListItem>
                            <asp:ListItem Value="2">N/A</asp:ListItem>
                            <asp:ListItem Value="3">Reparar</asp:ListItem>
                            <asp:ListItem Value="4">Reemplazar</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </td>
                <td width="30%">
                    <label>
                        <textarea maxlength="500"  runat="server" id="txtComentarios86"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>87</td>
                <td style="text-align: justify;">El control crucero de velocidad funciona correctamente.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL87" runat="server">
                            <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                            <asp:ListItem Value="1">OK</asp:ListItem>
                            <asp:ListItem Value="2">N/A</asp:ListItem>
                            <asp:ListItem Value="3">Reparar</asp:ListItem>
                            <asp:ListItem Value="4">Reemplazar</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </td>
                <td width="30%">
                    <label>
                        <textarea maxlength="500"  runat="server" id="txtComentarios87"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>88</td>
                <td style="text-align: justify;">El vehículo con volante centrado sigue el trayecto y marcha en línea recta en superficies niveladas.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL88" runat="server">
                            <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                            <asp:ListItem Value="1">OK</asp:ListItem>
                            <asp:ListItem Value="2">N/A</asp:ListItem>
                            <asp:ListItem Value="3">Reparar</asp:ListItem>
                            <asp:ListItem Value="4">Reemplazar</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </td>
                <td width="30%">
                    <label>
                        <textarea maxlength="500"  runat="server" id="txtComentarios88"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>89</td>
                <td style="text-align: justify;">No se siente exceso de vibraciones de las ruedas o del volante a  velocidad permitida.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL89" runat="server">
                            <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                            <asp:ListItem Value="1">OK</asp:ListItem>
                            <asp:ListItem Value="2">N/A</asp:ListItem>
                            <asp:ListItem Value="3">Reparar</asp:ListItem>
                            <asp:ListItem Value="4">Reemplazar</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </td>
                <td width="30%">
                    <label>
                        <textarea maxlength="500"  runat="server" id="txtComentarios89"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>90</td>
                <td style="text-align: justify;">No hay vibración excesiva al frenar.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL90" runat="server">
                            <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                            <asp:ListItem Value="1">OK</asp:ListItem>
                            <asp:ListItem Value="2">N/A</asp:ListItem>
                            <asp:ListItem Value="3">Reparar</asp:ListItem>
                            <asp:ListItem Value="4">Reemplazar</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </td>
                <td width="30%">
                    <label>
                        <textarea maxlength="500"  runat="server" id="txtComentarios90"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>91</td>
                <td style="text-align: justify;">El embrague y la transmisión funcionan apropiadamente.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL91" runat="server">
                            <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                            <asp:ListItem Value="1">OK</asp:ListItem>
                            <asp:ListItem Value="2">N/A</asp:ListItem>
                            <asp:ListItem Value="3">Reparar</asp:ListItem>
                            <asp:ListItem Value="4">Reemplazar</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </td>
                <td width="30%">
                    <label>
                        <textarea maxlength="500"  runat="server" id="txtComentarios91"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>92</td>
                <td style="text-align: justify;">La transmisión automática pasa los cambios apropiadamente.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL92" runat="server">
                            <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                            <asp:ListItem Value="1">OK</asp:ListItem>
                            <asp:ListItem Value="2">N/A</asp:ListItem>
                            <asp:ListItem Value="3">Reparar</asp:ListItem>
                            <asp:ListItem Value="4">Reemplazar</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </td>
                <td width="30%">
                    <label>
                        <textarea maxlength="500"  runat="server" id="txtComentarios92"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>93</td>
                <td style="text-align: justify;">No existen  ruidos anormales en el interior de la trasnmisión</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL93" runat="server">
                            <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                            <asp:ListItem Value="1">OK</asp:ListItem>
                            <asp:ListItem Value="2">N/A</asp:ListItem>
                            <asp:ListItem Value="3">Reparar</asp:ListItem>
                            <asp:ListItem Value="4">Reemplazar</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </td>
                <td width="30%">
                    <label>
                        <textarea maxlength="500"  runat="server" id="txtComentarios93"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>94</td>
                <td style="text-align: justify;">La caja de transferencia cambia suavemente de 2WD a 4WD y de 4WD a 2WD</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL94" runat="server">
                            <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                            <asp:ListItem Value="1">OK</asp:ListItem>
                            <asp:ListItem Value="2">N/A</asp:ListItem>
                            <asp:ListItem Value="3">Reparar</asp:ListItem>
                            <asp:ListItem Value="4">Reemplazar</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </td>
                <td width="30%">
                    <label>
                        <textarea maxlength="500"  runat="server" id="txtComentarios94"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
        </table>
        <button class="button danger cycle-button" style="margin-left: 890px;" id="btn_Atras" runat="server" onserverclick="btn_Atras_Click"><span class="icon mif-arrow-left"></span></button>
    </div>
    <br /><br />
    <div align="center">
        <button class="image-button primary" id="btn_Guardar" runat="server" onserverclick="btn_Guardar_Click">
            Grabar
            <span class="icon mif-floppy-disk bg-darkCobalt"></span>
        </button>
        <button class="image-button primary" id="Button1" runat="server" onserverclick="btn_Salir_Click">
            Salir
            <span class="icon mif-exit bg-darkCobalt"></span>
        </button>
    </div>
    </form>
</body>
</html>

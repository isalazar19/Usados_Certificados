<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormDetalle05Nuevo.aspx.cs" Inherits="Usados_Certificados_FormDetalle05Nuevo" %>

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

    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="table" id="GridView1" style="border-collapse: collapse; width: 100%;" border="1" rules="all" cellspacing="0">
            <tr>
                <th style="background-color: Silver;" scope="col" colspan="2">
                    (V) SISTEMA DIRECCION, FRENOS Y SUSPENCIÓN
                </th>
                <th style="background-color: Silver;" scope="col">
                    Resultado
                </th>
                <th style="background-color: Silver;" scope="col">
                    Comentarios
                </th>
            </tr>
            <tr>
                <td>75</td>
                <td style="text-align: justify;">Inspección de la cremallera de dirección, uniones, bujes, brazos de control y guardapolvos.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL75" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios75"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>76</td>
                <td style="text-align: justify;">Inspección de frenos, caliper, tuberías y mangueras.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL76" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios76"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>77</td>
                <td style="text-align: justify;">Pastillas de frenos/zapatas deben tener un mínimo de 50% de uso restante.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL77" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios77"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>78</td>
                <td style="text-align: justify;">Estado general de los soportes de la transmisión.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL78" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios78"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>79</td>
                <td style="text-align: justify;">Inspección general de la caja de transmisión, diferenciales, crucetas y homocineticas.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL79" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios79"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>80</td>
                <td style="text-align: justify;">Estado general de Rotula, pernos y bujes.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL80" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios80"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>81</td>
                <td style="text-align: justify;">Estado general de Rodamientos de rueda.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL81" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios81"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>82</td>
                <td style="text-align: justify;">Estado general de barra de torsión y barra estabilizadora.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL82" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios82"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>83</td>
                <td style="text-align: justify;">Estado general de los amortiguadores (verificar fugas)</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL83" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios83"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>84</td>
                <td style="text-align: justify;">Estado general de los resortes.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL84" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios84"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
        </table>
        <button class="button danger cycle-button" style="margin-left: 890px;" id="btn_Atras" runat="server" onserverclick="btn_Atras_Click"><span class="icon mif-arrow-left"></span></button>
        <button class="button success cycle-button" id="btn_Siguiente" runat="server" onserverclick="btn_Siguiente_Click"><span class="icon mif-arrow-right"></span></button>
    </div>
    </form>
</body>
</html>

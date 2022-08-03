<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormularioCertificacionNuevo.aspx.cs" Inherits="Usados_Certificados_FormularioCertificacionNuevo" %>

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

    <style type="text/css">
        .xl221
	    {mso-style-parent:style0;
	    font-size:24.0pt;
	    font-weight:700;
	    text-align:center;
	    vertical-align:middle;
	    border-top:.5pt solid windowtext;
	    border-right:none;
	    border-bottom:.5pt solid windowtext;
	    border-left:none;
	    background:#F2F2F2;
	    mso-pattern:black none;}
	    .font24
	    {color:red;
	    font-size:24.0pt;
	    font-weight:700;
	    font-style:normal;
	    text-decoration:none;
	    font-family:Calibri, sans-serif;
	    mso-font-charset:0;}
    </style>

    <script type="text/javascript">
        function MensajeValidaStock() {
            setTimeout(function () {
                $.Notify({ type: 'alert', caption: 'Aviso', content: "No ha ingresado N° Stock", icon: "<span class='mif-warning'></span>" });
            }, 1000);
        }

        $(function () {
            $(".validar").keydown(function (event) {
                //alert(event.keyCode);
                if ((event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105) && event.keyCode !== 190 && event.keyCode !== 110 && event.keyCode !== 8 && event.keyCode !== 9) {
                    return false;
                }
            });
        });

        function MensajeValidaOT() {
            setTimeout(function () {
                $.Notify({ type: 'alert', caption: 'Aviso', content: "Ingrese un Número de OT para continuar", icon: "<span class='mif-warning'></span>" });
            }, 1000);
        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <fieldset style="border: 1px solid #999; border-radius: 8px; box-shadow:0 0 10px #999;"">
            <table cellspacing="0" cellpadding="0">
                <tr>
                    <td width="1836" height="38" class="xl221" style="height:29.25pt;&#10;    width:1379pt" colspan="14">
                        PAUTA DE CONTROL
                        <font class="font24">USADOS CERTIFICADOS TOYOTA</font>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label style="text-align: left;">Número Stock</label>
                        <div class="input-control text" data-role="input-control">
                                <input type="text" placeholder="" id="txtNumStock" maxlength="10" runat="server" style="margin-top: 25px; margin-left: -85px;" />
                                <button class="button" runat="server" id="btnBuscarStock" onserverclick="btnBuscarStock_Click" style="margin-top: 25px; position: static;"><span class="mif-search"></span></button>
                            </div>
                    </td>
                    <td><img src="imagenes/image001.png"  style="max-width: 100%; margin-left: 290px;" /></td>
                </tr>
                <tr>
                    <td>
                        <label style="text-align: left;">VIN</label>
                        <div class="input-control text" data-role="input-control">
                            <input type="text" placeholder="" id="txtVIN" maxlength="35" runat="server" readonly="readonly" style="margin-left: 60px;" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label style="text-align: left;">Modelo</label>
                        <div class="input-control text" data-role="input-control">
                            <input type="text" placeholder="" id="txtModelo" maxlength="18" runat="server" readonly="readonly" style="margin-left:38px;" />
                        </div>
                    </td>
                    <td rowspan="5">
                        <img src="imagenes/image006.png" style="margin-left: -100px;" />
                    </td>

                </tr>
                <tr>
                    <td>
                        <label style="text-align: left;">Versión</label>
                        <div class="input-control text" data-role="input-control">
                            <input type="text" placeholder="" id="txtVersion" maxlength="32" runat="server" style="width: 110%; margin-left: 40px;" readonly="readonly" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label style="text-align: left;">Patente</label>
                        <div class="input-control text" data-role="input-control">
                            <input type="text" placeholder="" id="txtPatente" maxlength="10" runat="server" readonly="readonly" style="margin-left: 40px;" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label style="text-align: left;">Kilometraje</label>
                        <div class="input-control text" data-role="input-control">
                            <input type="text" class="validar" placeholder="" id="txtKmsActual" maxlength="10" runat="server" style="margin-left: 19px;" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td width="50%">
                        <label style="text-align: left;">Fecha de Venta</label>
                        <div class="input-control text" data-role="input-control">
                            <input type="text" placeholder="" id="txtFechaVenta" maxlength="10" runat="server" readonly="readonly" />
                        </div>
                    </td>
                </tr>
<%--                <tr>
                    <td>
                        <label style="text-align: left;">Mantenimientos Registrados</label>
                        <div class="input-control text" data-role="input-control">
                            <input type="text" placeholder="" id="txtMantRegist" maxlength="10" runat="server" readonly="readonly" />
                        </div> 
                    </td>
                </tr>--%>
                <tr>
                    <td>
                        <label style="text-align: left;">Años de Uso</label>
                        <div class="input-control text" data-role="input-control">
                            <input type="text" placeholder="" id="txtAñoUso" maxlength="100" runat="server" style="margin-left: 12px;" readonly="readonly" />
                        </div>
                    </td>
                    <td>
                        <label style="text-align: left;">Comentarios</label>
                        <textarea maxlength="500" style="height: 70px; -ms-overflow-y: hidden; width: 100%; margin-left: -70px;" runat="server" id="txtComentarios" ></textarea>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label style="text-align: left;">Número de OT</label>
                        <div class="input-control text" data-role="input-control">
                            <input type="text" placeholder="" id="txtOT" maxlength="10" runat="server" style="margin-left: 1px;" />
                        </div>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <label style="text-align: left;">Mantenimientos Registrados</label>
                    </td>
                    <td>
                        <label style="text-align: left; margin-left: 150px;">Fecha Última Mantención</label>
                    </td>
                    <td>
                        <div class="input-control text" data-role="input-control">
                            <input type="text" placeholder="" id="txtFechaUltMant" maxlength="10" runat="server" readonly="readonly" />
                        </div>
                    </td>
                    
                    <td><button class="button danger cycle-button" style="margin-left: 190px;" id="btn_Atras" runat="server" onserverclick="btn_Atras_Click"><span class="icon mif-cross"</button></td>
                    <td><button class="button success cycle-button" id="btn_Siguiente" runat="server" onserverclick="btn_Siguiente_Click"><span class="icon mif-arrow-right"</button></td>

                </tr>
                
            </table>
            <table border="1">
                <tr>
                    <th>30d</th>
                    <th>10K</th>
                    <th>20K</th>
                    <th>30K</th>
                    <th>40K</th>
                    <th>50K</th>
                    <th>60K</th>
                    <th>70K</th>
                    <th>80K</th>
                    <th>90K</th>
                </tr>
                <tr>
                    <td>
                        <center>
                            <input type="checkbox" checked="false" runat="server" id="chk30d"/>
                            <span class="check"></span>
                        </center>
                    </td>
                    <td>
                        <center>
                            <input type="checkbox" checked="false" runat="server" id="chk10k"/>
                            <span class="check"></span>
                        </center>
                    </td>
                    <td>
                        <center>
                            <input type="checkbox" checked="false" runat="server" id="chk20k"/>
                            <span class="check"></span>
                        </center>
                    </td>
                    <td>
                        <center>
                            <input type="checkbox" checked="false" runat="server" id="chk30k"/>
                            <span class="check"></span>
                        </center>
                    </td>
                    <td>
                        <center>
                            <input type="checkbox" checked="false" runat="server" id="chk40k"/>
                            <span class="check"></span>
                        </center>
                    </td>
                    <td>
                        <center>
                            <input type="checkbox" checked="false" runat="server" id="chk50k"/>
                            <span class="check"></span>
                        </center>
                    </td>
                    <td>
                        <center>
                            <input type="checkbox" checked="false" runat="server" id="chk60k"/>
                            <span class="check"></span>
                        </center>
                    </td>
                    <td>
                        <center>
                            <input type="checkbox" checked="false" runat="server" id="chk70k"/>
                            <span class="check"></span>
                        </center>
                    </td>
                    <td>
                        <center>
                            <input type="checkbox" checked="false" runat="server" id="chk80k"/>
                            <span class="check"></span>
                        </center>
                    </td>
                    <td>
                        <center>
                            <input type="checkbox" checked="false" runat="server" id="chk90k"/>
                            <span class="check"></span>
                        </center>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>

    <%--<br /><br />
    <div align="center">
        
        <button class="image-button primary" id="btn_Guardar" runat="server" onserverclick="btn_Guardar_Click">
            Grabar
            <span class="icon mif-floppy-disk bg-darkCobalt"></span>
        </button>
        <button class="image-button primary" id="btn_Atras" runat="server" onserverclick="btn_Atras_Click">
            Salir
            <span class="icon mif-exit bg-darkCobalt"></span>
        </button>
    </div>--%>

    </form>
</body>
</html>

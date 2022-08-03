<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormularioReventaEditar.aspx.cs" Inherits="Usados_Certificados_FormularioReventaEditar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../GEMBA/css/metro.css" rel="stylesheet" type="text/css" />
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
        function formatCliente(txtRut) {
            txtRut.value = txtRut.value.replace(/[.-]/g, '')
            .replace(/^(\d{1,2})(\d{3})(\d{3})(\w{1})$/, '$1.$2.$3-$4')
        }

        function MensajeValidaCompuesto() {
            setTimeout(function () {
                $.Notify({ type: 'alert', caption: 'Aviso', content: "Ingrese un RUT y un N° de Stock", icon: "<span class='mif-warning'></span>" });
            }, 1000);
        }

        function MensajeValidaRut() {
            setTimeout(function () {
                $.Notify({ type: 'alert', caption: 'Aviso', content: "Ingrese un RUT", icon: "<span class='mif-warning'></span>" });
            }, 1000);
        }

        function MensajeValidaStock() {
            setTimeout(function () {
                $.Notify({ type: 'alert', caption: 'Aviso', content: "Ingrese un N° de Stock", icon: "<span class='mif-warning'></span>" });
            }, 1000);
        }

        function MensajeValidaDatos() {
            setTimeout(function () {
                $.Notify({ type: 'alert', caption: 'Aviso', content: "No hay Retoma con los Datos ingresados", icon: "<span class='mif-warning'></span>" });
            }, 1000);
        }

        function MensajeValidaDatosReventa() {
            setTimeout(function () {
                $.Notify({ type: 'alert', caption: 'Aviso', content: "Solo se permite una Reventa con los Datos igresados", icon: "<span class='mif-warning'></span>" });
            }, 1000);
        }

        function validarSiNumero(numero) {
            if (!/^([0-9])*$/.test(numero))
            //alert("El valor del Precio Retoma " + numero + " no es un número");
                setTimeout(function () {
                    $.Notify({ type: 'warning', caption: 'Aviso', content: "El valor del Precio Venta y/o Precio Medio " + numero + " no es un número", icon: "<span class='mif-warning'></span>" });
                }, 3000);
        }

        function MensajeCargarArchivo() {
            setTimeout(function () {
                $.Notify({ type: 'alert', caption: 'Aviso', content: "No ha seleccionado un Archivo", icon: "<span class='mif-warning'></span>" });
            }, 1000);

        }
        function MensajeValidaArchivo() {
            setTimeout(function () {
                $.Notify({ type: 'alert', caption: 'Aviso', content: "Solo se acepta archivo PDF", icon: "<span class='mif-warning'></span>" });
            }, 1000);

        }

        function CalcularDias() {
            var f2 = $('#txtFechaVenta').val();
            var dia2 = f2.substr(8, 2);
            var mes2 = f2.substr(5, 2);
            var año2 = f2.substr(0, 4);
            var fechaVenta = mes2 + "-" + dia2 + "-" + año2;
            //$('#txtFechaVenta').val(f1);
            /* Obtiene el valor de la Fecha Retoma */
            var f1 = $('#txtFechaRetoma').val();
            var dia1 = f1.substr(0, 2);
            var mes1 = f1.substr(3, 2);
            var año1 = f1.substr(6, 4);
            var fechaRetoma = mes1 + "-" + dia1 + "-" + año1;

            var fecha1 = new Date(fechaRetoma);
            var fecha2 = new Date(fechaVenta);

            var milisegundosDia = 24 * 60 * 60 * 1000;

            var milisegundosTranscurridos = Math.abs(fecha1.getTime() - fecha2.getTime());

            var diasTranscurridos = Math.round(milisegundosTranscurridos / milisegundosDia);
            $('#txtDiasStock').val(diasTranscurridos);
        }

        function CalcularDifPrecio() {
            var precioVenta = parseFloat($('#txtPrecioVenta').val());
            var precioRetoma = parseFloat($('#txtPrecioRetoma').val());
            /* Calcular la Dif de Precios */
            var difPrecio = (precioVenta / precioRetoma) - 1;
            var difPrecio = Math.round(difPrecio * 100, 1);
            $('#txtDifPrecio').val(difPrecio);
        }

        function openCustom() {
            metroDialog.create({
                title: "Información",
                content: "Datos Guardados Satisfactoriamente!!!",
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
            <div class="example" data-text="Datos del Cliente">
                <div class="grid">
                    <div class="row cells2">
                        <div class="cell">
                            <label style="text-align: left;">Rut</label>
                            <div class="input-control text" data-role="input">
                                <input type="text" placeholder="" id="txtRut" maxlength="12" runat="server" onkeyup="formatCliente(this)" readonly="readonly" >
                            </div>
                        </div>
                        <div class="cell">
                            <label style="text-align: left;">N° Stock</label>
                            <div class="input-control text" data-role="input">
                                <input type="text" placeholder="" id="txtNumStock" maxlength="10" runat="server" readonly="readonly" >
                                <%--<button class="button" runat="server" id="btnBuscar" onserverclick="btnBuscar_Click"><span class="mif-search"></span></button>--%>
                            </div>
                        </div>
                        <div class="cell" style="width: 50%;">
                            <% Response.Write(Session["Cliente_Numero"]);%> - <% Response.Write(Session["Cliente_Nombre"]);%>\<% Response.Write(Session["usuario"]);%>
                        </div>
                    </div>

                    <div class="row cells2">
                        <div class="cell">
                            <label style="text-align: left;">Nombre Cliente</label>
                            <div class="input-control text" data-role="input-control">
                                <input type="text" placeholder="" id="txtNomClte" maxlength="100" runat="server" style="width: 200%;" readonly="readonly" />
                            </div>
                        </div>
                        <div class="cell"></div>
                        <div class="cell">
                            <label style="text-align: left;">Dirección</label>
                            <div class="input-control text" data-role="input-control">
                                <input type="text" placeholder="" id="txtDireccion" maxlength="150" runat="server" style="width: 300%;" readonly="readonly" />
                            </div>
                        </div>
                    </div>

                    <div class="row cells2">
                        <div class="cell">
                            <label style="text-align: left;">Comuna</label>
                            <div class="input-control select" >
                                <asp:DropDownList ID="DDLComuna" runat="server" style="width: 99%;" 
                                    AutoPostBack="True" Enabled="False">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="cell">
                            <label style="text-align: left;">Teléfono Celular</label>
                            <div class="input-control text" data-role="input-control">
                                <input type="text" placeholder="" id="txtTel1" maxlength="20" runat="server" readonly="readonly" />
                            </div>
                        </div>
                        <div class="cell">
                            <label style="text-align: left;">Teléfono Directo</label>
                            <div class="input-control text" data-role="input-control">
                                <input type="text" placeholder="" id="txtTelDir" maxlength="20" runat="server" readonly="readonly" />
                            </div>
                        </div>
                        <div class="cell">
                            <label style="text-align: left;">Correo electrónico</label>
                            <div class="input-control text" data-role="input-control">
                                <input type="text" placeholder="" id="txtMail" maxlength="100" runat="server" style="width: 200%;" readonly="readonly" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
            <div class="example" data-text="Datos Transacción">
                <div class="grid">
                    <div class="row cells4">
                        <div class="cell">
                            <label style="text-align: left;">Fecha Venta</label>
                            <div class="input-control text" data-role="datepicker" data-week-start="1">
                                <input type="text" placeholder="" id="txtFechaVenta" runat="server" name="txtFechaVenta" onblur="CalcularDias();" />
                                <button class="button" type="button" runat="server" id="btnCalendar" disabled="disabled"><span class="mif-calendar"></span></button>
                            </div>
                        </div>
                        <div class="cell">
                            <label style="text-align: left;">Fecha Retoma</label>
                            <div class="input-control text" data-role="input" id="datepicker">
                                <input type="text" readonly="readonly" id="txtFechaRetoma" runat="server" />
                                <button class="button" type="button" runat="server" id="Button1" disabled="disabled"><span class="mif-calendar"></span></button>
                            </div>
                        </div>
                        <div class="cell">
                            <label style="text-align: left;">Precio Venta</label>
                            <div class="input-control text" data-role="input-control">
                                <input type="text" placeholder="" id="txtPrecioVenta" maxlength="10" runat="server" onchange="validarSiNumero(this.value);" onblur="CalcularDifPrecio();" readonly="readonly" />
                            </div>
                        </div>
                        <%--<div class="cell">
                            <label>Seleccione Documento Adjunto</label>
                            <div class="input-control file full-size" data-role="input">
                                <asp:FileUpload ID="CargarArchivo" runat="server" Enabled="false" />
                                <button class="button" type="button">
                                    <span class="mif-folder"></span>
                                </button>
                            </div>
                        </div>--%>
                        <div class="cell">
                            <%--<asp:Image ID="Image1" runat="server" 
                                ImageUrl="" Height="100px" 
                                Width="100px" />--%>
                                <asp:HyperLink ID="HyperLink1" runat="server" Height="100px" 
                                ImageUrl="~/Imagenes/pdf.png" Width="100px" Target="_blank" >HyperLink</asp:HyperLink>
                        </div>
                    </div>
                    <div class="row cells2">
                        <div class="cell">
                            <label style="text-align: left;">Precio Retoma</label>
                            <div class="input-control text" data-role="input-control">
                                <input type="text" placeholder="" id="txtPrecioRetoma" maxlength="10" runat="server" readonly="readonly" />
                            </div>
                        </div>
                        <div class="cell" runat="server" id="precioMedio">
                            <label style="text-align: left;">Precio Medio Vehículo</label>
                            <div class="input-control text" data-role="input-control">
                                <input type="text" placeholder="" id="txtPrecioMedio" maxlength="10" runat="server" onchange="validarSiNumero(this.value);" />
                            </div>
                        </div>
                        <div class="cell">
                            <label style="text-align: left;">Días de Stock</label>
                            <div class="input-control text" data-role="input-control">
                                <input type="text" placeholder="" id="txtDiasStock" maxlength="4" runat="server" readonly="readonly" />
                            </div>
                        </div>
                        <div class="cell">
                            <label style="text-align: left;">Diferencia Precio (%)</label>
                            <div class="input-control text" data-role="input-control">
                                <input type="text" placeholder="" id="txtDifPrecio" maxlength="10" runat="server" readonly="readonly" />
                            </div>
                        </div>
                        
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="HFNumStock" runat="server" />
            <asp:HiddenField ID="HFPatente" runat="server" />
            <asp:HiddenField ID="HFModelo" runat="server" />
            <asp:HiddenField ID="HFVersion" runat="server" />
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

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormularioRetomaEditar.aspx.cs" Inherits="Usados_Certificados_FormularioRetomaEditar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../GEMBA/css/metro.css" rel="stylesheet" type="text/css" />
    <link href="../GEMBA/css/metro-icons.css" rel="stylesheet" type="text/css" />
    <link href="../GEMBA/css/metro-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../GEMBA/css/metro-schemes.css" rel="stylesheet" type="text/css" />
    <link href="../GEMBA/css/docs.css" rel="stylesheet" type="text/css" />
    <%--<link href="css/dataTables.bootstrap.css" rel="stylesheet" type="text/css" />--%>

    <%--<link href="../GEMBA/css/style.css" rel="stylesheet" type="text/css" />--%>
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />

    <script src="../GEMBA/js/jquery-2.1.3.min.js" type="text/javascript"></script>
    <script src="../GEMBA/js/jquery-3.3.1.min.js" type="text/javascript"></script>
    <%--<script src="js/jquery.dataTables.min.js" type="text/javascript"></script>--%>
    <script src="../GEMBA/js/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="../GEMBA/js/jquery/jquery.dataTables.js" type="text/javascript"></script>
    <link href="../GEMBA/css/dataTables.bootstrap.css" rel="stylesheet" type="text/css" />
    
    <script src="../GEMBA/js/v2_metro.js" type="text/javascript"></script>
    <script src="../GEMBA/js/docs.js" type="text/javascript"></script>
    <script src="../GEMBA/js/ga.js" type="text/javascript"></script>

    <%-- Area de codigo --%>
    <script type="text/javascript">
        function formatCliente(txtRut) {
            txtRut.value = txtRut.value.replace(/[.-]/g, '')
            .replace(/^(\d{1,2})(\d{3})(\d{3})(\w{1})$/, '$1.$2.$3-$4')
        }
        function MensajeValidaRut() {
            setTimeout(function () {
                $.Notify({ type: 'alert', caption: 'Aviso', content: "Ingrese un RUT", icon: "<span class='mif-warning'></span>" });
            }, 1000);
        }
        function MensajeValidaEmail() {
            setTimeout(function () {
                $.Notify({ type: 'alert', caption: 'Aviso', content: "La dirección de email es incorrecta.", icon: "<span class='mif-warning'></span>" });
            }, 1000);
        }
        function MensajeValidaCompuesto() {
            setTimeout(function () {
                $.Notify({ type: 'alert', caption: 'Aviso', content: "No ha ingresado Kms Actual", icon: "<span class='mif-warning'></span>" });
            }, 1000);
            setTimeout(function () {
                $.Notify({ type: 'alert', caption: 'Aviso', content: "No ha indicado la Fecha de Retoma", icon: "<span class='mif-warning'></span>" });
            }, 1000);
            setTimeout(function () {
                $.Notify({ type: 'alert', caption: 'Aviso', content: "No ha seleccionado un Archivo", icon: "<span class='mif-warning'></span>" });
            }, 1000);
        }
        function MensajeValidaFecha() {
            setTimeout(function () {
                $.Notify({ type: 'alert', caption: 'Aviso', content: "No ha indicado la Fecha de Retoma", icon: "<span class='mif-warning'></span>" });
            }, 1000);
        }
        function MensajeValidaFecha() {
            setTimeout(function () {
                $.Notify({ type: 'alert', caption: 'Aviso', content: "No ha indicado la Fecha de Retoma", icon: "<span class='mif-warning'></span>" });
            }, 1000);
        }
        function MensajeValidaKmsActual() {
            setTimeout(function () {
                $.Notify({ type: 'alert', caption: 'Aviso', content: "No ha ingresado Kms Actual", icon: "<span class='mif-warning'></span>" });
            }, 1000);
        }
        function MensajeCargarArchivo() {
            setTimeout(function () {
                $.Notify({ type: 'alert', caption: 'Aviso', content: "No ha seleccionado un Archivo", icon: "<span class='mif-warning'></span>" });
            }, 1000);

        }
        function MensajeExisteRegistro() {
            setTimeout(function () {
                $.Notify({ type: 'warning', caption: 'Aviso', content: "Cliente ya se encuentra Registrado", icon: "<span class='mif-warning'></span>" });
            }, 1000);

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
                                //parent.jQuery.fancybox.close();
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

        function validarSiNumero(numero) {
            if (!/^([0-9])*$/.test(numero))
            //alert("El valor del Precio Retoma " + numero + " no es un número");
                setTimeout(function () {
                    $.Notify({ type: 'warning', caption: 'Aviso', content: "El valor del Precio Medio " + numero + " no es un número", icon: "<span class='mif-warning'></span>" });
                }, 3000);
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="font-size: 24pt; font-weight: bold; color: #6D90AA; text-align: center;
        font-family: Toyota Display Heavy; width: 100%;">
            USADOS CERTIFICADOS
        </div>
        <div class="tabcontrol2" data-role="tabcontrol">
            <ul class="tabs">
                <li class="active"><a href="#frame_5_1">Datos del Cliente</a></li>
                <li><a href="#frame_5_2">Datos del Vehiculo</a></li>
                <li><a href="#frame_5_3">Transacción</a></li>
            </ul>
            <div class="frames">
                <%--TAB 1--%>
                <div class="frame" id="frame_5_1" style="display: block;">
                    <div class="span12">
                        <fieldset style="border: 1px solid #999; border-radius: 8px; box-shadow:0 0 10px #999;"">

                            <div class="example" data-text="Datos del Cliente">
                                <div class="grid">
                                    <div class="row cells2">
                                        <div class="cell">
                                            <label style="text-align: left;">Rut</label>
                                            <div class="input-control text" data-role="input">
                                                <input type="text" placeholder="" id="txtRut" maxlength="12" runat="server" readonly="readonly" onkeyup="formatCliente(this)" >
                                                <%--<button class="button" runat="server" id="btnBuscar" onserverclick="btnBuscar_Click"><span class="mif-search"></span></button>--%>
                                            </div>
                                        </div>
                                        <div class="cell" style="width: 50%;">
                                            <% Response.Write(Session["Cliente_Numero"]);%> - <% Response.Write(Session["Cliente_Nombre"]);%>\<% Response.Write(Session["usuario"]);%>
                                        </div>
                                        <div><a href="ListaRetoma.aspx"><span class="mif-exit mif-3x"></span> Volver</a></div>
                                    </div>

                                    <div class="row cells2">
                                        <div class="cell">
                                            <label style="text-align: left;">Nombre Cliente</label>
                                            <div class="input-control text" data-role="input-control">
                                                <input type="text" placeholder="" id="txtNomClte" maxlength="100" runat="server" style="width: 270%;" />
                                            </div>
                                        </div>
                                        <div class="cell"></div>
                                        <div class="cell">
                                            <label style="text-align: left;">Dirección</label>
                                            <div class="input-control text" data-role="input-control">
                                                <input type="text" placeholder="" id="txtDireccion" maxlength="150" runat="server" style="width: 350%;" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row cells2">
                                        <div class="cell">
                                            <label style="text-align: left;">Comuna</label>
                                            <div class="input-control select" >
                                                <asp:DropDownList ID="DDLComuna" runat="server" style="width: 99%;" 
                                                    AutoPostBack="True">
                                                </asp:DropDownList>
                                            </div>
                                       </div>
                                       <div class="cell">
                                            <label style="text-align: left;">Teléfono Celular</label>
                                            <div class="input-control text" data-role="input-control">
                                                <input type="text" placeholder="" id="txtTel1" maxlength="20" runat="server" />
                                            </div>
                                       </div>
                                       <div class="cell">
                                            <label style="text-align: left;">Teléfono Directo</label>
                                            <div class="input-control text" data-role="input-control">
                                                <input type="text" placeholder="" id="txtTelDir" maxlength="20" runat="server" />
                                            </div>
                                       </div>
                                       <div class="cell">
                                            <label style="text-align: left;">Correo electrónico</label>
                                            <div class="input-control text" data-role="input-control">
                                                <input type="text" placeholder="" id="txtMail" maxlength="100" runat="server" style="width: 213%;" />
                                            </div>
                                       </div>
                                    </div>
                                </div>
                            </div>
                            
                        </fieldset>
                    </div>
                </div>
                <%--TAB 2--%>
                <div class="frame" id="frame_5_2" style="display: none;">
                    <div class="span12">
                        <fieldset style="border: 1px solid #999; border-radius: 8px; box-shadow:0 0 10px #999;"">

                            <div class="example" data-text="Datos del Vehículo">
                                <div class="grid">
                                    <div class="row cells2">
                                        <div class="cell">
                                            <label style="text-align: left;">N° Stock</label>
                                            <div class="input-control text" data-role="input">
                                                <input type="text" placeholder="" id="txtNumStock" maxlength="10" runat="server" readonly="readonly" >
                                                <%--<button class="button" runat="server" id="btnBuscarStock" onserverclick="btnBuscarStock_Click"><span class="mif-search"></span></button>--%>
                                            </div>
                                        </div>
                                        <div class="cell">
                                            <label style="text-align: left;">N° VIN</label>
                                            <div class="input-control text" data-role="input">
                                                <input type="text" placeholder="" id="txtVIN" maxlength="35" runat="server" readonly="readonly" />
                                             </div>
                                        </div>
                                        <div class="cell" style="width: 50%;">
                                            <% Response.Write(Session["Cliente_Numero"]);%> - <% Response.Write(Session["Cliente_Nombre"]);%>\<% Response.Write(Session["NombreUsuario"]);%>
                                        </div>
                                    </div>

                                    <div class="row cells2">
                                        
                                        <div class="cell">
                                            <label style="text-align: left;">Patente</label>
                                            <div class="input-control text" data-role="input-control">
                                                <input type="text" placeholder="" id="txtpatente" maxlength="10" runat="server" readonly="readonly" />
                                            </div>
                                       </div>
                                       <div class="cell">
                                            <label style="text-align: left;">Modelo</label>
                                            <div class="input-control text" data-role="input-control">
                                                <input type="text" placeholder="" id="txtModelo" maxlength="18" runat="server" readonly="readonly" />
                                            </div>
                                       </div>
                                       <div class="cell">
                                            <label style="text-align: left;">Versión</label>
                                            <div class="input-control text" data-role="input-control">
                                                <input type="text" placeholder="" id="txtVersion" maxlength="32" runat="server" style="width: 110%;" readonly="readonly" />
                                            </div>
                                       </div>
                                       <div class="cell">
                                            <label style="text-align: left;">Color.............</label>
                                            <div class="input-control text" data-role="input-control">
                                                <input type="text" placeholder="" id="txtColor" maxlength="100" runat="server" style="width: 150%;"  readonly="readonly"/>
                                            </div>
                                       </div>
                                    </div>

                                    <div class="row cells2">
                                        <div class="cell">
                                            <label style="text-align: left;">Kilometraje Actual</label>
                                            <div class="input-control text" data-role="input-control">
                                                <input type="text" placeholder="" id="txtKmsActual" maxlength="10" runat="server" />
                                            </div>
                                        </div>
                                        <div class="cell">
                                            <label style="text-align: left;">Año Vehiculo</label>
                                            <div class="input-control text" data-role="input-control">
                                                <input type="text" placeholder="" id="txtAñoVeh" maxlength="10" runat="server" readonly="readonly" />
                                            </div>
                                        </div>
                                        <div class="cell">
                                            <label style="text-align: left;">Kms Ult Mantención</label>
                                            <div class="input-control text" data-role="input-control">
                                                <input type="text" placeholder="" id="txtKmsUltMant" maxlength="10" runat="server" readonly="readonly" />
                                            </div>                                        
                                        </div>
                                        <div class="cell">
                                            <label style="text-align: left;">Fecha Ult Mantención</label>
                                            <div class="input-control text" data-role="input-control">
                                                <input type="text" placeholder="" id="txtFechaUltMant" maxlength="10" runat="server" readonly="readonly" />
                                            </div>
                                            
                                        </div>

                                    </div>

                                </div>
                            </div>

                            <div class="row cells2">
                            <div class="cell">
                            <center><asp:Label id="Label5" runat="server" Text="Datos Mantenciones" Font-Underline="True" Font-Names="Arial" Font-Bold="True" Font-Size="Medium" __designer:wfdid="w75"></asp:Label></center>
                            <asp:GridView id="GridViewMantenciones" runat="server" Width="98%" Font-Names="Arial" ForeColor="#333333" Font-Size="7pt" CellSpacing="1" CellPadding="3" GridLines="None" DataKeyNames="VehSto,RevNumero" __designer:wfdid="w76" AutoGenerateColumns="False" OnRowDataBound="GridViewMantenciones_RowDataBound" AllowSorting="True" PageSize="4">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

                                <EmptyDataRowStyle HorizontalAlign="Center" BorderColor="#C00000"></EmptyDataRowStyle>
                                <Columns>
                                    <asp:BoundField DataField="RevNumero2" HeaderText="Revisi&#243;n" ReadOnly="True" SortExpression="RevNumero"></asp:BoundField>
                                    <asp:BoundField DataField="RevOrt" HeaderText="Ort" SortExpression="RevOrt"></asp:BoundField>
                                    <asp:BoundField DataField="RevFec2" HeaderText="Fec.Mantenci&#243;n" SortExpression="RevFec"></asp:BoundField>
                                    <asp:BoundField DataField="RevKms" HeaderText="Kms" SortExpression="RevKms"></asp:BoundField>
                                    <asp:BoundField DataField="DESCONC" HeaderText="Concesionario" SortExpression="RevSat">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:HyperLinkField DataNavigateUrlFields="CUSTRUT,CUSTDV" DataNavigateUrlFormatString="~/Cliente_Portal/Buscar_Cliente_02.aspx?dv={1}&amp;rut={0}" DataTextField="RUT" HeaderText="R.Cliente" SortExpression="CUSTRUT">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:HyperLinkField>
                                    <asp:BoundField DataField="GarClave" HeaderText="C&#243;digo" SortExpression="GarClave"></asp:BoundField>
                                    <asp:BoundField DataField="Usuario" HeaderText="Usuario" SortExpression="Usuario"></asp:BoundField>
                                    <asp:BoundField DataField="interno" HeaderText="Interno" SortExpression="interno"></asp:BoundField>
                                    <asp:BoundField DataField="RevFecReg" HeaderText="Fec.Registro" SortExpression="RevFecReg"></asp:BoundField>
                                    <asp:BoundField DataField="RevSAt" HeaderText="RevSAt" SortExpression="RevSAt"></asp:BoundField>
                                    <%--<asp:BoundField DataField="factura" HeaderText="Factura" SortExpression="Factura"></asp:BoundField>--%>

                                    </Columns>

                                    <%--<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>
                                    <EmptyDataTemplate>
                                
                                                                    <table align="center" width="95%">
                                                                        <tr>
                                                                            <td style="width: 100%; height: 50px; text-align: center" bgcolor="#ffffc0">
                                                                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="8pt"
                                                                                    Font-Underline="True" Text="Stock no registra mantenciones."></asp:Label></td>
                                                                        </tr>
                                                                    </table>
                            
                                    </EmptyDataTemplate>
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                    <EditRowStyle BackColor="#999999"></EditRowStyle>
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>--%>
                                    </asp:GridView> 
                                    </div>
                                    </div>
                                    <div class="row cells2">
                                        <div class="cell">
                                            <center><asp:Label id="Label7" runat="server" Text="Datos DYP" Font-Underline="True" Font-Names="Arial" Font-Bold="True" Font-Size="Medium" __designer:wfdid="w79"></asp:Label></center>
                                            <asp:GridView id="GridViewDYP" runat="server" Width="98%" Font-Names="Arial" ForeColor="#333333" Font-Size="7pt" CellSpacing="1" CellPadding="3" GridLines="None" __designer:wfdid="w80" AutoGenerateColumns="False" OnRowDataBound="GridViewDYP_RowDataBound" AllowSorting="True" PageSize="3">
                                                <%--<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>
                                                <RowStyle BackColor="#EFF3FB"></RowStyle>
                                                <EmptyDataRowStyle HorizontalAlign="Center" BorderColor="#C00000" BorderWidth="1px" BorderStyle="Outset"></EmptyDataRowStyle>--%>
                                                <Columns>
                                                    <asp:BoundField DataField="categoria" HeaderText="Categoria" SortExpression="categoria"></asp:BoundField>
                                                    <asp:BoundField DataField="CAMPO" HeaderText="Desripci&#243;n" SortExpression="CAMPO"></asp:BoundField>
                                                    <asp:BoundField DataField="Ort" HeaderText="Ort" SortExpression="Ort"></asp:BoundField>
                                                    <asp:BoundField DataField="Fecha2" HeaderText="F.DYP" SortExpression="Fecha"></asp:BoundField>
                                                    <asp:BoundField DataField="Kms" HeaderText="Kms" SortExpression="Kms"></asp:BoundField>
                                                    <asp:BoundField DataField="DESCONC" HeaderText="Concesionario" SortExpression="Codconc">
                                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:HyperLinkField DataNavigateUrlFields="RUT" DataNavigateUrlFormatString="~/Cliente_Portal/Buscar_Cliente_02.aspx?rut={0}" DataTextField="RUT" HeaderText="R.Cliente" SortExpression="CUSTRUT">
                                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                    </asp:HyperLinkField>
                                                    <asp:BoundField DataField="Codigo" HeaderText="C&#243;digo" SortExpression="Codigo"></asp:BoundField>
                                                    <asp:BoundField DataField="Usuario" HeaderText="Usuario" SortExpression="Usuario"></asp:BoundField>
                                                    <asp:BoundField DataField="interno" HeaderText="Interno" SortExpression="interno"></asp:BoundField>
                                                    <asp:BoundField DataField="RegFec" HeaderText="F.Registro" SortExpression="RegFec">
                                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="codconc" HeaderText="codconc"></asp:BoundField>
                                                </Columns>
                                                <%--<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>
                                                <EmptyDataTemplate>
                                                <table align="center" width="95%">
                                                    <tr>
                                                        <td style="width: 100%; height: 50px; text-align: center" bgcolor="#ffffc0">
                                                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="8pt"
                                                                Font-Underline="True" Text="Stock no registra DYP."></asp:Label></td>
                                                    </tr>
                                                </table>
                                                    </EmptyDataTemplate>
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                                    <EditRowStyle BackColor="#2461BF"></EditRowStyle>
                                                    <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>--%>
                                                </asp:GridView> 
                                        </div>
                                    </div>
                        </fieldset>
                    </div>
                </div>
                <%--TAB 3--%>
                <div class="frame" id="frame_5_3" style="display: none;">
                    <div class="span12">
                        <fieldset style="border: 1px solid #999; border-radius: 8px; box-shadow:0 0 10px #999;"">

                            <div class="example" data-text="">
                                <div class="grid">
                                    <div class="row cells2">
                                        <div class="cell">
                                            <label style="text-align: left;">Fecha Retoma</label>
                                            <div class="input-control text" data-role="input">
                                                <input type="text" readonly="readonly" id="txtFechaRetoma" runat="server" />
                                                <button class="button" type="button" runat="server" id="btnCalendar" disabled="disabled"><span class="mif-calendar"></span></button>
                                            </div>
                                        </div>
                                        <div class="cell">
                                            <label style="text-align: left;">Precio Retoma</label>
                                            <div class="input-control text" data-role="input-control">
                                                <input type="text" placeholder="" id="txtPrecioRetoma" maxlength="10" runat="server" readonly="readonly" />
                                            </div>
                                        </div>
                                        <div class="cell">
                                            <label>Seleccione Documento Adjunto</label>
                                            <div class="input-control file full-size" data-role="input">
                                                <asp:FileUpload ID="CargarArchivo" runat="server" Enabled="false"  />
                                                <button class="button" type="button">
                                                    <span class="mif-folder"></span>
                                                </button>
                                            </div>
                                        </div>
                                        <div class="cell">
                                            <%--<asp:Image ID="Image1" runat="server" 
                                                ImageUrl="" Height="100px" 
                                                Width="100px" />--%>
                                                <asp:HyperLink ID="HyperLink1" runat="server" Height="100px" 
                                                ImageUrl="~/Imagenes/pdf.png" Width="100px" Target="_blank">HyperLink</asp:HyperLink>
                                        </div>
                                    </div>
                                    <div class="row cells2">
                                        <div class="cell" runat="server" id="precioMedio">
                                            <label style="text-align: left;">Precio Medio Vehículo</label>
                                            <div class="input-control text" data-role="input-control">
                                                <input type="text" placeholder="" id="txtPrecioMedio" maxlength="10" runat="server" onchange="validarSiNumero(this.value);" />
                                            </div>
                                        </div>
                                        
                                    </div>
                                </div>
                            </div>
                            <center>
                                <button class="image-button primary" id="btn_Guardar" runat="server" onserverclick="btn_Guardar_Click" >
                                    Grabar
                                    <span class="icon mif-floppy-disk bg-darkCobalt"></span>
                                </button>
                                <button class="image-button primary" id="btn_Atras" runat="server" onserverclick="btn_Atras_Click">
                                    Salir
                                    <span class="icon mif-exit bg-darkCobalt"></span>
                                </button>
                            </center>
                        </fieldset>
                    </div>
                </div>
            </div>
        </div>    
    </div>
    </form>
</body>
</html>

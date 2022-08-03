<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormularioCertificacion.aspx.cs" Inherits="Usados_Certificados_FormularioCertificacion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <%--<meta http-equiv="Refresh" content="5; URL=FormularioCertificacion.aspx" />--%>
    <link href="../css/metro.css" rel="stylesheet" type="text/css" />
    <link href="../GEMBA/css/metro-icons.css" rel="stylesheet" type="text/css" />
    <link href="../GEMBA/css/metro-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../GEMBA/css/metro-schemes.css" rel="stylesheet" type="text/css" />
    <link href="../GEMBA/css/docs.css" rel="stylesheet" type="text/css" />

    <%--<link href="../GEMBA/css/style.css" rel="stylesheet" type="text/css" />--%>
    <script src="../GEMBA/js/jquery-2.1.3.min.js" type="text/javascript"></script>
    <script src="../GEMBA/js/jquery-3.3.1.min.js" type="text/javascript"></script>

    <script src="../GEMBA/js/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="../GEMBA/js/jquery/jquery.dataTables.js" type="text/javascript"></script>
    <link href="../GEMBA/css/dataTables.bootstrap.css" rel="stylesheet" type="text/css" />


    <script src="../GEMBA/js/v2_metro.js" type="text/javascript"></script>
    <%--<script src="js/v3_metro.js" type="text/javascript"></script>--%>
    <script src="../GEMBA/js/docs.js" type="text/javascript"></script>
    <script src="../GEMBA/js/ga.js" type="text/javascript"></script>

    <script src="../GEMBA/js/jquery.fancybox.pack.js" type="text/javascript"></script>
    <link href="../GEMBA/css/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <style type="text/css">div#fancybox-wrap {top:100px !important;}</style>

    <style type="text/css">
        html, body
        {
            height: 100%;
        }
        body
        {
        }
        .page-content
        {
            padding-top: 3.125rem;
            min-height: 100%;
            height: 100%;
        }
        .table .input-control.checkbox
        {
            line-height: 1;
            min-height: 0;
            height: auto;
        }
        
        @media screen and (max-width: 800px)
        {
            #cell-sidebar
            {
                flex-basis: 52px;
            }
            #cell-content
            {
                flex-basis: calc(100% - 52px);
            }
        }
        
        a.btn_actions, input[type="button"], input[type="submit"], input[type="reset"], button.btn_actions
        {
            border: 1px solid #ccc !important;
            padding: 8px 5px !important;
            border-radius: 4px !important;
            /*color: #333333 !important;*/
            text-align: center !important;
            cursor: pointer !important;
            display: inline-block !important;
            outline: none !important;
            font-family: 'Segoe UI_' , 'Open Sans' , Verdana, Arial, Helvetica, sans-serif !important;
            font-size: 14px !important;
            /*background-color: #fff !important;*/
        }
        a.btn_actions:hover, button.btn_actions:hover, input[type="button"]:hover, input[type="submit"]:hover, input[type="reset"]:hover
        {
            background-color: #ebebeb !important;
            text-decoration: none !important;
        }
        a.btn_actions:active, button.btn_actions:active, input[type="button"]:active, input[type="submit"]:active, input[type="reset"]:active
        {
            background-color: #e2e2e2 !important; /*border-color: #adadad;*/
            text-decoration: none !important;
        }
        
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("a.fancy3").fancybox({
                'width': '980',
                'height': '710',
                'scrolling': 'no',
                'type': 'iframe',
                iframe: {
                    scrolling: 'yes'
                },
                'topRatio': '0',
                afterShow: function () {
                    $(".fancybox-wrap").css({ "top": 0, "margin": "-25px 0 0" });
                },
                'fitToView': false,
                'autoSize': false,
                'modal': true
            });
        });
    </script>

    <script>
        $(document).ready(function () {
            $('#GridView1').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
        });
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="app-bar fixed-top red" data-role="appbar">
        <a class="app-bar-element branding"><span class="mif-calendar"></span></a><span class="app-bar-divider">
        </span>

        <ul class="app-bar-menu">
            <li><a href="../Default.aspx"><span class="mif-home"></span>  Inicio</a> </li>
        </ul>
        <div class="app-bar-element place-right">
            <% Response.Write(Session["Cliente_Numero"]);%> - <% Response.Write(Session["Cliente_Nombre"]);%>
            <span class="mif-user"></span>&nbsp<% Response.Write(Session["NombreUsuario"]);%>(<% Response.Write(Session["usuario"]);%>)<%--<asp:Label ID="Label10" runat="server" Text="Invitado"></asp:Label>--%>
        </div>
    </div>

    <div class="page-content">
        <div class="flex-grid no-responsive-future" style="height: 100%;">
            <div class="row" style="height: 100%">
                <div class="cell auto-size padding20 bg-white" id="cell-content">

                    <h3 class="text-light">
                        Usados Certificados<span class="mif-drive-eta place-right"></span>
                    </h3>
                     <hr class="thin bg-grayLighter" />

                     <%--Los filtros--%>
                     <div class="row cells4">
                         <div class="cell2">
                            <h5>Fecha Desde</h5>
                            <div class="input-control text" data-role="datepicker" data-format="dd.mm.yyyy">
                                <input type="text" id="fechaDesde" readonly="readonly" runat="server" />
                                <button class="button" type="button"><span class="mif-calendar"></span></button>
                            </div>
                         </div>
                         <div style="flex-grow: 0; flex-shrink: 0; flex-basis: 1.33%;"></div>
                         <div class="cell2">
                            <h5>Fecha Hasta</h5>
                            <div class="input-control text" data-role="datepicker" data-format="dd.mm.yyyy">
                                <input type="text" id="fechaHasta" readonly="readonly" runat="server"/>
                                <button class="button" type="button"><span class="mif-calendar"></span></button>
                            </div>
                         </div>
                         <div style="flex-grow: 0; flex-shrink: 0; flex-basis: 1.33%;"></div>
                         <button class="button loading-cube lighten warning" id="btnConsultar" runat="server" onserverclick="btnConsultar_Click" style="margin-top: 50px;">Consultar...</button>
                         <div style="flex-grow: 0; flex-shrink: 0; flex-basis: 1.33%;"></div>
                         <div class="cell"></div>
                         <div class="cell2">
                            
                                <a runat="server" id="botonNew" class="button primary fancy3 mif-plus" href="FormularioCertificacionNuevo.aspx" style="font-size: 0.87rem; margin-top: 50px;"> Nuevo...</a>
                                    
                                
                        </div>
                        <div style="flex-grow: 0; flex-shrink: 0; flex-basis: 1.33%;"></div>
                        <div class="cell2">
                            <button class="button success" id="btnExcel" runat="server" onserverclick="btnExcel_Click" style="margin-top: 50px;">
                                <span class="mif-file-excel"></span> Descargar Excel
                            </button>
                        </div>

                     </div>

                     <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" 
                        EnableModelValidation="True" OnRowDataBound="GridView1_RowDataBound" >
                        <Columns>
                            <asp:TemplateField HeaderText="N°" ItemStyle-Width="1%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Numero_Stock" HeaderText="N° Stock" >
                            <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Vin" HeaderText="Vin" >
                            <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Patente" HeaderText="Patente" >
                            <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Modelo" HeaderText="Modelo" >
                            <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Codigo_Version" HeaderText="Versión" >
                            <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NUMERO_OT" HeaderText="N° OT" >
                            <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="concesionario" HeaderText="Concesionario" >
                            <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="fecha_crea" HeaderText="Fecha Ingreso" DataFormatString="{0:d}">
                            <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="estado" HeaderText="Estado" >
                            <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Acciones" >
                            <ItemTemplate>
                                            
                                    <a class="btn_actions fancy3" href="FormularioCertificacionEditar.aspx?id=<%# Eval("Numero_Stock") %>&estat=<%# Eval("estado") %>"
                                        style=" background-color: #2086bf !important; color: #ffffff !important; width: 87px;">Aprob/Rech</a>
                                            
                                    <asp:ImageButton ID="rowToDelete" runat="server" CssClass="btn_actions" AlternateText="Borrar" 
                                        style=" background-color: #ce352c !important; color: #ffffff !important; border-radius: 4px !important; border: 1px solid #ccc !important;
                                        margin-top: -8px; width: 87px; height: 33px;" 
                                            OnClick="deleteParam" CommandArgument='<%# Eval ("Numero_Stock") %>' OnClientClick="return confirm('Esta seguro de eliminar este Registro?');" />
                                                
                                    <asp:ImageButton ID="rowToPrint" runat="server" CssClass="btn_actions" AlternateText="Imprimir" 
                                        style=" background-color: #60a917 !important; color: #ffffff !important; border-radius: 4px !important; border: 1px solid #ccc !important;
                                        margin-top: -8px; width: 87px; height: 33px;" 
                                            OnClick="printParam" CommandArgument='<%# Eval ("Numero_Stock") %>' />
                                                
                                <%--<asp:Button ID="Button1" runat="server" Text="Aprob/Rech" CssClass="btn_actions" style="background-color: #2086bf !important; color: #ffffff !important; 
                                    border-radius: 4px !important; border: 1px solid #ccc !important;"/>
                                <asp:Button ID="Button2" runat="server" Text="Eliminar" CssClass="btn_actions" style="background-color: #ce352c !important; color: #ffffff !important; 
                                    border-radius: 4px !important; border: 1px solid #ccc !important;"
                                    CommandArgument='<%# Bind ("Numero_Stock") %>' OnClick="deleteParam_Click" />
                                <asp:Button ID="Button3" runat="server" Text="Imprimir" CssClass="btn_actions" style="background-color: #60a917 !important; color: #ffffff !important; 
                                    border-radius: 4px !important; border: 1px solid #ccc !important;" />--%>
                            </ItemTemplate>
                            <%--<ItemStyle HorizontalAlign="Left" Width="1%" />--%>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SAP_WEBConnectionString %>"
                        SelectCommand="Sp_Lst_Consulta_Usados_Certificados_Header @fechaini, @fechafin ">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="Label1" Name="fechaini" />
                            <asp:ControlParameter ControlID="Label2" Name="fechafin" />
                        </SelectParameters>
                    </asp:SqlDataSource>--%>
                </div>
            </div>
        </div>
    </div>
    <asp:Label ID="Label1" runat="server" Text="" style="display: none;"></asp:Label>
    <asp:Label ID="Label2" runat="server" Text="" style="display: none;"></asp:Label>

    </form>
</body>
</html>

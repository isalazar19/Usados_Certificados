<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListaReventa.aspx.cs" Inherits="Usados_Certificados_ListaReventa" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <%--<meta http-equiv="Refresh" content="1; URL=GestionTakata.aspx" />--%>
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
                'modal': true,
                'afterClose': function () {
                    parent.location.reload(true);
                }
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
        <a class="app-bar-element branding"><span class="mif-automobile"></span><sup>Usados
            Certificados</sup> </a><span class="app-bar-divider"></span>
        <ul class="app-bar-menu">
            <li><a href="Default.aspx"><span class="mif-home"></span>Inicio</a> </li>
        </ul>
        <div class="app-bar-element place-right">
            <% Response.Write(Session["Cliente_Numero"]);%>
            -
            <% Response.Write(Session["Cliente_Nombre"]);%>
            <span class="mif-user"></span>&nbsp<% Response.Write(Session["NombreUsuario"]);%>(<% Response.Write(Session["usuario"]);%>)<%--<asp:Label ID="Label10" runat="server" Text="Invitado"></asp:Label>--%>
        </div>
    </div>

    <div class="page-content">
        <div class="flex-grid no-responsive-future" style="height: 100%;">
            <div class="row" style="height: 100%">
                <div class="cell auto-size padding20 bg-white" id="cell-content">

                    <a class="button primary mif-plus fancy3" href="FormularioReventa.aspx" style="font-size: 0.87rem;">
                    Nuevo...</a>

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
                        OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="N°" ItemStyle-Width="1%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="1%"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField DataField="RUT" HeaderText="Rut">
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NOMBRE_CLTE" HeaderText="Nombre Cliente">
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Fecha_Crea" HeaderText="Fecha Creacion" DataFormatString="{0:d}">
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Fecha_Venta" HeaderText="Fecha Venta" DataFormatString="{0:d}">
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Sucursal_Retoma" HeaderText="Sucursal">
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Numero_Stock" HeaderText="N° Stock">
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Vin" HeaderText="Vin">
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="" HeaderStyle-Width="45px">
                                <ItemTemplate>
                                    <a class="button primary fancy3" href="FormularioReventaEditar.aspx?id=<%# Eval("ID") %>">
                                        <span class="icon mif-stack"></span> Editar </a>
                                        <%--<asp:HyperLink CssClass="button primary fancy3" ID="btnEditar" runat="server" 
                                        NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.ID", "FormularioRetomaEditar.aspx?id={0}") %>'>
                                        <span class="icon mif-stack"></span>
                                         Editar</asp:HyperLink>--%>
                                </ItemTemplate>
                                <HeaderStyle Width="45px"></HeaderStyle>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ID" HeaderText="Id" Visible="False" />
                        </Columns>
                    </asp:GridView>

                </div>
            </div>
        </div>
    </div>
    <asp:Label ID="LblGrupo" runat="server" Text="" style="display: none;"></asp:Label>
    </form>
</body>
</html>

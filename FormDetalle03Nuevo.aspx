<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormDetalle03Nuevo.aspx.cs" Inherits="Usados_Certificados_FormDetalle03Nuevo" %>

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
                    (III) COMPARTIMIENTO MALETA, Y NEUMATICOS INCLUYE REPUESTO
                </th>
                <th style="background-color: Silver;" scope="col">
                    Resultado
                </th>
                <th style="background-color: Silver;" scope="col">
                    Comentarios
                </th>
            </tr>
            <tr>
                <td>36</td>
                <td style="text-align: justify;">El porta equipaje está limpio, sin basura ni manchas y el tapizado luce bien.</td>
                <td>
                    <div class="input-control select" style="width: 120%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL36" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios36"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>37</td>
                <td style="text-align: justify;">La luz del porta equipaje funciona correctamente.</td>
                <td>
                    <div class="input-control select" style="width: 120%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL37" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios37"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>38</td>
                <td style="text-align: justify;">El gato y herramientas estan correctos y asegurados.</td>
                <td>
                    <div class="input-control select" style="width: 120%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL38" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios38"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>39</td>
                <td style="text-align: justify;">Banda de rodamiento restante de por lo menos 4 mm en el neumatico de repuesto.</td>
                <td>
                    <div class="input-control select" style="width: 120%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL39" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios39"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>40</td>
                <td style="text-align: justify;">El neumatico de repuesto esta con la presión correcta.</td>
                <td>
                    <div class="input-control select" style="width: 120%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL40" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios40"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>41</td>
                <td style="text-align: justify;">Inspección torque aprete de los neumáticos  y medir la presión de inflado.</td>
                <td>
                    <div class="input-control select" style="width: 120%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL41" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios41"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>42</td>
                <td style="text-align: justify;">Los 4 neumáticos son de la misma marca, modelo, medida, dibujo de la huella, velocidad y clasificación de carga.</td>
                <td>
                    <div class="input-control select" style="width: 120%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL42" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios42"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>43</td>
                <td style="text-align: justify;">Inspeccionar el estado general de los neumaticos (sin cortes, abultamientos o desgaste disparejo).</td>
                <td>
                    <div class="input-control select" style="width: 120%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL43" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios43"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>44</td>
                <td style="text-align: justify;">Mínimo de 4 mm restante de profundidad en toda la banda de rodamiento.</td>
                <td>
                    <div class="input-control select" style="width: 120%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL44" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios44"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
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

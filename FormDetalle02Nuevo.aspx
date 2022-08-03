<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormDetalle02Nuevo.aspx.cs" Inherits="Usados_Certificados_FormDetalle02Nuevo" %>

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
                    (II) COMPARTIMIENTO DE MOTOR, BATERIA Y SISTEMA DE CARGAS
                </th>
                <th style="background-color: Silver;" scope="col">
                    Resultado
                </th>
                <th style="background-color: Silver;" scope="col">
                    Comentarios
                </th>
            </tr>
            <tr>
                <td>22</td>
                <td style="text-align: justify;">Inspección de pérdidas de combustible, aceite, refrigerante u otros fluidos.</td>
                <td>
                    <div class="input-control select" style="width: 120%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL22" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios22"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>23</td>
                <td style="text-align: justify;">Correcto Ralenti  con el motor frío y caliente.</td>
                <td>
                    <div class="input-control select" style="width: 120%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL23" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios23"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>24</td>
                <td style="text-align: justify;">El ventilador del motor funciona apropiadamente.</td>
                <td>
                    <div class="input-control select" style="width: 120%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL24" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios24"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>25</td>
                <td style="text-align: justify;">Correas y mangueras sin grietas ni daños.</td>
                <td>
                    <div class="input-control select" style="width: 120%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL25" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios25"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>26</td>
                <td style="text-align: justify;">No hay daños en los soportes del motor.</td>
                <td>
                    <div class="input-control select" style="width: 120%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL26" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios26"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>27</td>
                <td style="text-align: justify;">Nivel adecuado del aceite motor, del líquido de frenos,  del sistema limpiador y de dirección hidráulica.</td>
                <td>
                    <div class="input-control select" style="width: 120%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL27" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios27"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>28</td>
                <td style="text-align: justify;">Inspeccionar emision de gases de escape.</td>
                <td>
                    <div class="input-control select" style="width: 120%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL28" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios28"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>29</td>
                <td style="text-align: justify;">Batería en buenas condiciones, tiene amperes adecuados en el arranque y capacidad de reserva.</td>
                <td>
                    <div class="input-control select" style="width: 120%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL29" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios29"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>30</td>
                <td style="text-align: justify;">Batería de la medida adecuada y asegurada en su soporte.</td>
                <td>
                    <div class="input-control select" style="width: 120%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL30" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios30"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>31</td>
                <td style="text-align: justify;">Bornes  de la batería libres de corrosión.</td>
                <td>
                    <div class="input-control select" style="width: 120%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL31" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios31"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>32</td>
                <td style="text-align: justify;">Cables en buenas condiciones.</td>
                <td>
                    <div class="input-control select" style="width: 120%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL32" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios32"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>33</td>
                <td style="text-align: justify;">Verificar el voltaje de entrega del Alternador. </td>
                <td>
                    <div class="input-control select" style="width: 120%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL33" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios33"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>34</td>
                <td style="text-align: justify;">Funcionamiento del alternador libre de ruidos.</td>
                <td>
                    <div class="input-control select" style="width: 120%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL34" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios34"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>35</td>
                <td style="text-align: justify;">Los fusibles estan bien instalados y en buenas condiciones.</td>
                <td>
                    <div class="input-control select" style="width: 120%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL35" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios35"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
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

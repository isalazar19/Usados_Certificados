<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormDetalle04Nuevo.aspx.cs" Inherits="Usados_Certificados_FormDetalle04Nuevo" %>

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
                    (IV) PANEL DE INSTRUMENTOS Y SISTEMAS ELECTRONICOS
                </th>
                <th style="background-color: Silver;" scope="col">
                    Resultado
                </th>
                <th style="background-color: Silver;" scope="col">
                    Comentarios
                </th>
            </tr>
            <tr>
                <td>45</td>
                <td style="text-align: justify;">Las luces de los instrumentos funcionan. (medidor combinado)</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL45" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios45"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>46</td>
                <td style="text-align: justify;">Las luces de la calefacción funcionan.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL46" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios46"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>47</td>
                <td style="text-align: justify;">Atenuación de las luces del tablero funciona.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL47" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios47"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>48</td>
                <td style="text-align: justify;">La luz de indicación del desempañador se enciende cuando el interruptor está encendido.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL48" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios48"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>49</td>
                <td style="text-align: justify;">Las luces del techo/de cortesía funcionan correctamente con los ciclos de las puertas.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL49" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios49"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>50</td>
                <td style="text-align: justify;">El medidor de combustible proporciona la información correcta.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL50" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios50"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>51</td>
                <td style="text-align: justify;">El espejo retrovisor para día o noche opera correctamente y el espejo está en buenas condiciones.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL51" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios51"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>52</td>
                <td style="text-align: justify;">Toma de corriente funcionando.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL52" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios52"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>53</td>
                <td style="text-align: justify;">Techo, asientos, viseras, panel del tablero, tapizados, consola, portavasos y alfombras, están en el lugar correcto y en buenas condicones.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL53" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios53"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>54</td>
                <td style="text-align: justify;">Se encuentra piso seguros instalados correctamente.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL54" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios54"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>55</td>
                <td style="text-align: justify;">Los asientos funcionan adecuadamente incluyendo todos los ajustes de las posiciones.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL55" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios55"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>56</td>
                <td style="text-align: justify;">Los cinturones de seguridad funcionan suave y adecuadamente en toda su extension.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL56" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios56"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>57</td>
                <td style="text-align: justify;">La palanca de apertura de la guantera funciona correctamente.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL57" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios57"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>58</td>
                <td style="text-align: justify;">La palanca de la tapa de la bencina y compartimento de carga funcionan correctamente.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL58" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios58"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>59</td>
                <td style="text-align: justify;">El ajuste de la altura del volante funciona apropiadamente.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL59" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios59"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>60</td>
                <td style="text-align: justify;">Produce algun tipo de ruido la columna de direcction.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL60" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios60"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>61</td>
                <td style="text-align: justify;">La llave principal está y sus copias.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL61" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios61"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>62</td>
                <td style="text-align: justify;">La bocina funciona.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL62" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios62"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>63</td>
                <td style="text-align: justify;">El reloj funciona y se mantiene en hora.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL63" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios63"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>64</td>
                <td style="text-align: justify;">El sistema limpiador del parabrisas funciona correctamente y en todas sus velocidades y no emite ruidos extraños.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL64" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios64"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>65</td>
                <td style="text-align: justify;">El techo corredizo opera normalmente en todas las posiciones</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL65" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios65"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>66</td>
                <td style="text-align: justify;">Las ventanas operan normalmente.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL66" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios66"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>67</td>
                <td style="text-align: justify;">Los controles de la memoria de los asientos funcionan apropiadamente.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL67" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios67"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>68</td>
                <td style="text-align: justify;">El sistema de audio funciona correctamente.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL68" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios68"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>69</td>
                <td style="text-align: justify;">La antena funciona apropiadamente.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL69" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios69"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>70</td>
                <td style="text-align: justify;">Los parlantes de la radio funcionan correctamente a un volumen mediano.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL70" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios70"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>71</td>
                <td style="text-align: justify;">El aire acondicionado funciona normalmente.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL71" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios71"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>72</td>
                <td style="text-align: justify;">La calefacción funciona normalmente.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL72" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios72"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>73</td>
                <td style="text-align: justify;">Inspeccionar el estado general del filtro de polen.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL73" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios73"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
                    </label>
                </td>
            </tr>
            <tr>
                <td>74</td>
                <td style="text-align: justify;">Estado general del freno de mano.</td>
                <td>
                    <div class="input-control select" style="width: 125%; margin-left: -11px;">
                        <asp:DropDownList ID="DDL74" runat="server">
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
                        <textarea maxlength="500"  runat="server" id="txtComentarios74"  style="height: 35px; -ms-overflow-y: hidden; width: 98%;"></textarea>
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

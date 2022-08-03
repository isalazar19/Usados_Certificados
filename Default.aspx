<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Usados_Certificados_Default" %>

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

    <script src="../GEMBA/js/jquery-2.1.3.min.js" type="text/javascript"></script>
    <script src="../GEMBA/js/jquery-3.3.1.min.js" type="text/javascript"></script>
    <%--<script src="js/jquery.dataTables.min.js" type="text/javascript"></script>--%>
    <script src="../GEMBA/js/v2_metro.js" type="text/javascript"></script>

    <script src="../GEMBA/js/docs.js" type="text/javascript"></script>
    <script src="../GEMBA/js/ga.js" type="text/javascript"></script>
</head>
<body class="bg-steal">
    <form id="form1" runat="server">
    <div class="app-bar fixed-top red" data-role="appbar">
        <a class="app-bar-element branding">
            <span class="mif-automobile"></span>
            <sup>Usados Certificados</sup>
        </a>
        <span class="app-bar-divider"></span>
        <%--Aqui va el menu--%>
        <ul class="app-bar-menu">
            <li>
                <a href="" class="dropdown-toggle">Almacenamiento</a>
                <ul class="d-menu" data-role="dropdown">
                    <li><a href="ListaUsuarios.aspx" runat="server" id="mnu_Usuario">Mantención de Usuarios</a></li>
                    <li><a href="ListaRetoma.aspx">Formulario de Retoma</a></li>
                    <li><a href="ListaReventa.aspx">Formulario de Venta Usados</a></li>
                    <li><a href="../default.aspx">Regresar al Portal</a></li>
                </ul>
            </li>
        </ul>
        <div class="app-bar-element place-right">
        <% Response.Write(Session["Cliente_Numero"]);%> - <% Response.Write(Session["Cliente_Nombre"]);%>
            <span class="mif-user"></span>&nbsp<% Response.Write(Session["NombreUsuario"]);%>(<% Response.Write(Session["usuario"]);%>)<%--<asp:Label ID="Label10" runat="server" Text="Invitado"></asp:Label>--%>
        </div>
    </div>
    <div style="font-size: 24pt; font-weight: bold; color: #6D90AA; text-align: center;
        font-family: Toyota Display Heavy; width: 100%;">
        USADOS CERTIFICADOS
    </div>
    <div style="display: flex; justify-content: center;  align-items: center;">
    <div class="carousel" id="carousel2" style="height: 270px;">
        <div class="slide">
            <img src="/imagenes/Yaris.jpg" class="cover1" />
        </div>
        <div class="slide">
            <img src="/imagenes/Corolla.png" class="cover1" />
        </div>
        <div class="slide">
            <img src="/imagenes/Prius2.jpg" class="cover1" />
        </div>
        <div class="slide">
            <img src="/imagenes/RAV4.png" class="cover1" />
        </div>
        <div class="slide">
            <img src="/imagenes/Hilux.jpg" class="cover1" />
        </div>        
         <div class="slide">
            <img src="/imagenes/bg.jpg" class="cover1" />
        </div>
         <div class="slide">
            <img src="/imagenes/C-HR.png" class="cover1" />
        </div>
        <a class="controls left"><i class="icon-arrow-left-3"></i></a>
        <a class="controls right"><i class="icon-arrow-right-3"></i></a>
        <div class="markers default">
        
        </div>
    </div>
    </div>
    <script>
        $(function(){
        <!--$('.carousel').carousel();-->
        $("#carousel2").carousel({
           <!--auto: false,-->
           <!--period: 7000,-->
           <!--duration: 3000,-->
           width: 1024,
           height: 657,
           effect: 'fade',
           markers: {
               type: "default",
               show: true,
               position: 'bottom-right'
           }
        });
        })
    </script>
    </form>
</body>
</html>

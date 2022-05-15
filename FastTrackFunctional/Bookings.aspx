<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Bookings.aspx.cs" Inherits="FastTrackFront.Bookings" %>

<!DOCTYPE html>
<html lang="zxx">

<!-- Mirrored from duruthemes.com/demo/html/cappa/demo1/index.html by HTTrack Website Copier/3.x [XR&CO'2014], Fri, 15 Apr 2022 11:08:03 GMT -->
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>FastTrack Waste Management</title>
    <link rel="shortcut icon" href="img/favicon.png" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Barlow&amp;family=Barlow+Condensed&amp;family=Gilda+Display&amp;display=swap">
    <link rel="stylesheet" href="css/plugins.css" />
    <link rel="stylesheet" href="css/style.css" />

        <link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <!--===============================================================================================-->
        <link rel="stylesheet" type="text/css" href="vendor/animate/animate.css">
    <!--===============================================================================================-->
        <link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css">
    <!--===============================================================================================-->
        <link rel="stylesheet" type="text/css" href="vendor/perfect-scrollbar/perfect-scrollbar.css">
    <!--===============================================================================================-->
        <link rel="stylesheet" type="text/css" href="css/util.css">
        <link rel="stylesheet" type="text/css" href="css/main.css">
    <!--===============================================================================================-->
    <!-- Global site tag (gtag.js) - Google Analytics -->
    <script async src="https://www.googletagmanager.com/gtag/js?id=UA-144098545-1"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() {
            dataLayer.push(arguments);
        }
        gtag('js', new Date());
        gtag('config', 'UA-144098545-1');
    </script>
    <style>
        th {
            font-family: Lato-Bold;
            font-size: 18px;
            color: #4272d7;
            line-height: 1.4;
            background-color: transparent;
            border-bottom: 2px solid #f2f2f2;
            border-left: none;
            border-right: none;
        }
        table{
            border-radius: 10px !important;
            background-color: white;
        }
        td{
            border: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <!-- Preloader -->
    <div class="preloader-bg"></div>
    <div id="preloader">
        <div id="preloader-status">
            <div class="preloader-position loader"> <span></span> </div>
        </div>
    </div>
    <!-- Progress scroll totop -->
    <div class="progress-wrap cursor-pointer">
        <svg class="progress-circle svg-content" width="100%" height="100%" viewBox="-1 -1 102 102">
            <path d="M50,1 a49,49 0 0,1 0,98 a49,49 0 0,1 0,-98" />
        </svg>
    </div>
    <!-- Navbar -->
    <nav class="navbar navbar-expand-lg" style="background-color: white !important;">
        <div class="container">
            <!-- Logo -->
            <div class="logo-wrapper navbar-brand valign">
                <a href="index.html">
                    <div class="logo">
                        <img src="img/logo.png" class="logo-img" alt="">
                    </div>
                </a>
            </div>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation"> <span class="icon-bar"><i class="ti-line-double"></i></span> </button>
            <!-- Navbar links -->

                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav ml-auto">

                        <li runat="server" id="HomeMenu" class="nav-item"><a class="nav-link" runat="server" onserverClick="homeLink_Click" style="color: black !important;">Home</a></li>      
                        <li runat="server" id="CompaniesMenu"  class="nav-item"><a class="nav-link" runat="server" onserverClick="companiesLink_Click" style="color: black !important;">Companies</a></li>   
                        <li runat="server" id="AccountsMenu"  class="nav-item"><a class="nav-link" runat="server" onserverClick="accountsLink_Click" style="color: black !important;" href="accounts.html">Accounts</a></li>   
                        <li runat="server" id="BookingsMenu"  class="nav-item"><a class="nav-link" runat="server" onserverClick="bookingsLink_Click" style="color: black !important;" href="bookings.html">Bookings</a></li>      
                        <li runat="server" id="RegisterCompayMenu"  class="nav-item"><a class="nav-link" runat="server" onserverClick="registerCompanyLink_Click" style="color: black !important;" href="register-company.html">Register Company</a></li>
                        <li runat="server" id="RegisterMenu"  class="nav-item"><a class="nav-link" runat="server" onserverClick="registerLink_Click" style="color: black !important;" href="register.html">Register</a></li>
                        <li runat="server" id="LoginMenu"  class="nav-item"><a class="nav-link" runat="server" onserverClick="loginLink_Click" style="color: black !important;" href="login.html">Login</a></li>
                        <li runat="server" id="LogoutMenu"  class="nav-item"><a class="nav-link" runat="server" onserverClick="logoutLink_Click"  style="color: black !important;">Logout</a></li>
         
                    </ul>
                </div>

        </div>
    </nav>
    <section class="rooms1 section-padding bg-cream" data-scroll-index="1">
        <div class="container">
            <h3>Bookings</h3><br>
           <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" PageSize="4" OnPageIndexChanging="GridView1_PageIndexChanging"  OnRowCommand="Editbtn_Click" >
               <Columns>
                   <asp:TemplateField>
                        <ItemTemplate>
                            <i class="ti-pencil" onclick="document.getElementById('GridView1_Editbtn_<%#  Container.DataItemIndex %>').click()" style="font-size: 22px; cursor: pointer;" />
                            <asp:LinkButton ID="Editbtn" CausesValidation="false" style="display: none;" runat="server" CommandArgument='<%#  Eval("BookingID") %>' CommandName="EditRow"  ></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderTemplate>
                              Edit
                       </HeaderTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField>
                        <ItemTemplate>

                            <i class="ti-trash" onclick="document.getElementById('GridView1_Deletebtn_<%#  Container.DataItemIndex %>').click()" style="font-size: 22px; cursor: pointer;" />
                            <asp:LinkButton ID="Deletebtn" CausesValidation="false" style="display: none;" runat="server" CommandArgument='<%#  Eval("BookingID") %>' CommandName="DeleteRow"  ></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderTemplate>
                              Delete
                       </HeaderTemplate>
                   </asp:TemplateField>
                </Columns>
           </asp:GridView>
        </div>
    </section>
    <footer class="footer">
        <div class="footer-top">
            <div class="container">
                <div class="row">
                    <div class="col-md-4">
                        <div class="footer-column footer-about">
                            <h3 class="footer-title">About FastTrack</h3>
                            <p class="footer-about-text">About.</p>

                            <div class="footer-language"> <i class="lni ti-world"></i>
                                <select>
                                    <option>English</option>
                                </select>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="footer-column footer-contact">
                            <h3 class="footer-title">Contact</h3>
                            <p class="footer-contact-text">257 Glover Avenue Melrose<br>South Africa</p>
                            <div class="footer-contact-info">
                                <p class="footer-contact-phone"><span class="flaticon-call"></span> 082 536 2118</p>
                                <p class="footer-contact-mail">boitumelo@gmail.com</p>
                            </div>
                            <div class="footer-about-social-list">
                                <a href="#"><i class="ti-instagram"></i></a>
                                <a href="#"><i class="ti-twitter"></i></a>
                                <a href="#"><i class="ti-youtube"></i></a>
                                <a href="#"><i class="ti-facebook"></i></a>
                                <a href="#"><i class="ti-pinterest"></i></a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="footer-bottom">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="footer-bottom-inner">
                            <p class="footer-bottom-copy-right">© FastTrack 2022</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </footer>
                    </form>
    <!-- jQuery -->
    <script src="js/jquery-3.6.0.min.js"></script>
    <script src="js/jquery-migrate-3.0.0.min.js"></script>
    <script src="js/modernizr-2.6.2.min.js"></script>
    <script src="js/imagesloaded.pkgd.min.js"></script>
    <script src="js/jquery.isotope.v3.0.2.js"></script>
    <script src="js/pace.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/scrollIt.min.js"></script>
    <script src="js/jquery.waypoints.min.js"></script>
    <script src="js/owl.carousel.min.js"></script>
    <script src="js/jquery.stellar.min.js"></script>
    <script src="js/jquery.magnific-popup.js"></script>
    <script src="js/YouTubePopUp.js"></script>
    <script src="js/select2.js"></script>
    <script src="js/datepicker.js"></script>
    <script src="js/smooth-scroll.min.js"></script>
    <script src="js/custom.js"></script>
</body>

<!-- Mirrored from duruthemes.com/demo/html/cappa/demo1/index.html by HTTrack Website Copier/3.x [XR&CO'2014], Fri, 15 Apr 2022 11:11:08 GMT -->
</html>
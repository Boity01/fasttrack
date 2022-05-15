<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyDetails.aspx.cs" Inherits="FastTrackFront.CompanyDetails" %>

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
    <!-- Room Page Slider -->
    <header class="header slider">
        <div class="owl-carousel owl-theme">
            <!-- The opacity on the image is made with "data-overlay-dark="number". You can change it using the numbers 0-9. -->
            <div class="text-center item bg-img" data-overlay-dark="3" data-background="img/slider/9.jpg"></div>
            <div class="text-center item bg-img" data-overlay-dark="3" data-background="img/slider/7.jpg"></div>
            <div class="text-center item bg-img" data-overlay-dark="3" data-background="img/slider/8.jpg"></div>
        </div>
        <!-- arrow down -->
        <div class="arrow bounce text-center">
            <a href="#" data-scroll-nav="1" class=""> <i class="ti-arrow-down"></i> </a>
        </div>
    </header>
    <!-- Room Content -->
    <section class="rooms-page section-padding" data-scroll-index="1">
        <div class="container">
            <!-- project content -->
            <div class="row">
                <div class="col-md-12"> 
                    <span>
                        <i class="star-rating"></i>
                        <i class="star-rating"></i>
                        <i class="star-rating"></i>
                        <i class="star-rating"></i>
                        <i class="star-rating"></i>
                    </span>
                    <div class="section-title" runat="server" id="Name"></div>
                </div>
                <div class="col-md-8">
                    <p class="mb-30" runat="server" id="Description"></p>
                    <div class="row">
                        <div class="col-md-12 map animate-box" data-animate-effect="fadeInUp">
                            <iframe src="https://maps.google.com/maps?q=257%20glover%20avenue&t=&z=13&ie=UTF8&iwloc=&output=embed" width="100%" height="600" style="border:0;" allowfullscreen="" loading="lazy"></iframe>
                        </div>
                    </div>
                </div>
                <div class="col-md-3 offset-md-1">
                    <h6>Services</h6>
                    <ul class="list-unstyled page-list mb-30">
                        <li>
                            <div class="page-list-icon"> <input type="radio" style="width: 18px; height: 18px;"> </div>
                            <div class="page-list-text">
                                <p>Recycling</p>
                            </div>
                        </li>
                        <li>
                            <div class="page-list-icon"> <input type="radio" style="width: 18px; height: 18px;"> </div>
                            <div class="page-list-text">
                                <p>Waste Collection</p>
                            </div>
                        </li>
                        <li>
                            <br>
                            <asp:Button runat="server" OnClick="btnBook_Click" style="border-radius: 5px;" class="btn-form1-submit mt-15" Text="Book Now" />
                        </li>
                    </ul>
                </div>
            </div>
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
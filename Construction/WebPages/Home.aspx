d+8\[piu '<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebPages.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="fa">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />

    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <!--[if lte IE 8]><script src="assets/js/ie/html5shiv.js"></script><![endif]-->
    <link href="assets/css/main.css" rel="stylesheet" />
    <!--[if lte IE 9]><link rel="stylesheet" href="assets/css/ie9.css" /><![endif]-->
    <!--[if lte IE 8]><link rel="stylesheet" href="assets/css/ie8.css" /><![endif]-->
    <link href="bootstrap-3.3.7-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="bootstrap-3.3.7-dist/css/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="_Scripts/jquery.minv1.11.3.js"></script>
    <script src="bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>

    <script src="_Slider/JavaScript.js"></script>
    <link href="_Slider/_sliderStyle.css" rel="stylesheet" />
    <link href="_Styles/HomeStyleSheet.css" rel="stylesheet" />
    <script src="_Scripts/HomeJavaScript.js"></script>
</head>

<body class="landing">
    <form id="form1" runat="server">
        <div>
            <div class="container-fluid ">

                <div class="top-nav hidden-xs hidden-s">
                    <div class="top-nav-inner">
                        <div class="email">
                            <span class="glyphicon glyphicon-envelope" aria-hidden="true"></span>
                            <a href="#" class="">demo@gmail.com</a>
                        </div>
                        <div class="phone">
                            <span class="glyphicon glyphicon-earphone" aria-hidden="true"></span>
                            <a href="#" class="">1234</a>
                        </div>
                        <div class="sosioal-network">
                            <ul>
                                <li>
                                    <div class="telegram"></div>
                                </li>
                                <li>
                                    <div class="instagram"></div>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="line_verticall" id="fixme">
                    <nav class="navbar-default  second-nav" style="background-color: transparent;">

                        <div class="container-fluid">
                            <div class="navbar-header">
                                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                                    <span class="icon-bar"></span>
                                    <span class="icon-bar"></span>
                                    <span class="icon-bar"></span>
                                </button>
                                <a class="navbar-brand" href="#">Construction</a>
                            </div>
                            <div class="collapse navbar-collapse" id="myNavbar">
                                <ul class="nav navbar-nav">
                                    <li class="active"><a href="#">Home</a></li>
                                    <li class="dropdown">
                                        <a class="dropdown-toggle" data-toggle="dropdown" href="#">Page 1 <span class="caret"></span></a>
                                        <ul class="dropdown-menu">
                                            <li><a href="#">Page 1-1</a></li>
                                            <li><a href="#">Page 1-2</a></li>
                                            <li><a href="#">Page 1-3</a></li>
                                        </ul>
                                    </li>
                                    <li><a href="#">Page 2</a></li>
                                    <li><a href="#">Page 3</a></li>
                                </ul>
                            </div>
                        </div>
                    </nav>
                </div>
                <div class="inner-container">
                    <div class="slide-div">
                        <div class="slider-container">
                            <div class="slider-control left inactive"></div>
                            <div class="slider-control right"></div>
                            <ul class="slider-pagi"></ul>
                            <div class="slider">
                                <div class="slide slide-0 active">
                                    <div class="slide__bg"></div>
                                    <div class="slide__content">
                                        <svg class="slide__overlay" viewBox="0 0 720 405" preserveAspectRatio="xMaxYMax slice">
                                            <path class="slide__overlay-path" d="M0,0 150,0 500,405 0,405" />
                                        </svg>
                                        <div class="slide__text">
                                            <h2 class="slide__text-heading">Project name 1</h2>
                                            <p class="slide__text-desc">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Distinctio veniam minus illo debitis nihil animi facere, doloremque voluptate tempore quia. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Distinctio veniam minus illo debitis nihil animi facere, doloremque voluptate tempore quia.</p>
                                            <a class="slide__text-link">Project link</a>
                                        </div>
                                    </div>
                                </div>
                                <div class="slide slide-1 ">
                                    <div class="slide__bg"></div>
                                    <div class="slide__content">
                                        <svg class="slide__overlay" viewBox="0 0 720 405" preserveAspectRatio="xMaxYMax slice">
                                            <path class="slide__overlay-path" d="M0,0 150,0 500,405 0,405" />
                                        </svg>
                                        <div class="slide__text">
                                            <h2 class="slide__text-heading">Project name 2</h2>
                                            <p class="slide__text-desc">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Distinctio veniam minus illo debitis nihil animi facere, doloremque voluptate tempore quia. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Distinctio veniam minus illo debitis nihil animi facere, doloremque voluptate tempore quia.</p>
                                            <a class="slide__text-link">Project link</a>
                                        </div>
                                    </div>
                                </div>
                                <div class="slide slide-2">
                                    <div class="slide__bg"></div>
                                    <div class="slide__content">
                                        <svg class="slide__overlay" viewBox="0 0 720 405" preserveAspectRatio="xMaxYMax slice">
                                            <path class="slide__overlay-path" d="M0,0 150,0 500,405 0,405" />
                                        </svg>
                                        <div class="slide__text">
                                            <h2 class="slide__text-heading">Project name 3</h2>
                                            <p class="slide__text-desc">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Distinctio veniam minus illo debitis nihil animi facere, doloremque voluptate tempore quia. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Distinctio veniam minus illo debitis nihil animi facere, doloremque voluptate tempore quia.</p>
                                            <a class="slide__text-link">Project link</a>
                                        </div>
                                    </div>
                                </div>
                                <div class="slide slide-3">
                                    <div class="slide__bg"></div>
                                    <div class="slide__content">
                                        <svg class="slide__overlay" viewBox="0 0 720 405" preserveAspectRatio="xMaxYMax slice">
                                            <path class="slide__overlay-path" d="M0,0 150,0 500,405 0,405" />
                                        </svg>
                                        <div class="slide__text">
                                            <h2 class="slide__text-heading">Project name 4</h2>
                                            <p class="slide__text-desc">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Distinctio veniam minus illo debitis nihil animi facere, doloremque voluptate tempore quia. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Distinctio veniam minus illo debitis nihil animi facere, doloremque voluptate tempore quia.</p>
                                            <a class="slide__text-link">Project link</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div id="page-wrapper">

                        <!-- Banner -->
                        <section id="banner">
                            <div class="content">
                                <header>
                                    <h2>The future has landed</h2>
                                    <p>
                                        And there are no hoverboards or flying cars.<br />
                                        Just apps. Lots of mother flipping apps.
                                    </p>
                                </header>
                                <span class="image">
                                    <img src="images/pic01.jpg" alt="" /></span>
                            </div>
                            <a href="#one" class="goto-next scrolly">Next</a>
                        </section>

                        <!-- One -->
                        <section id="one" class="spotlight style1 bottom">
                            <span class="image fit main">
                                <img src="images/pic02.jpg" alt="" /></span>
                            <div class="content">
                                <div class="container">
                                    <div class="row">
                                        <div class="4u 12u$(medium)">
                                            <header>
                                                <h2>Odio faucibus ipsum integer consequat</h2>
                                                <p>Nascetur eu nibh vestibulum amet gravida nascetur praesent</p>
                                            </header>
                                        </div>
                                        <div class="4u 12u$(medium)">
                                            <p>
                                                Feugiat accumsan lorem eu ac lorem amet sed accumsan donec.
									Blandit orci porttitor semper. Arcu phasellus tortor enim mi
									nisi praesent dolor adipiscing. Integer mi sed nascetur cep aliquet
									augue varius tempus lobortis porttitor accumsan consequat
									adipiscing lorem dolor.
                                            </p>
                                        </div>
                                        <div class="4u$ 12u$(medium)">
                                            <p>
                                                Morbi enim nascetur et placerat lorem sed iaculis neque ante
									adipiscing adipiscing metus massa. Blandit orci porttitor semper.
									Arcu phasellus tortor enim mi mi nisi praesent adipiscing. Integer
									mi sed nascetur cep aliquet augue varius tempus. Feugiat lorem
									ipsum dolor nullam.
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <a href="#two" class="goto-next scrolly">Next</a>
                        </section>

                        <!-- Two -->
                        <section id="two" class="spotlight style2 right">
                            <span class="image fit main">
                                <img src="images/pic03.jpg" alt="" /></span>
                            <div class="content">
                                <header>
                                    <h2>Interdum amet non magna accumsan</h2>
                                    <p>Nunc commodo accumsan eget id nisi eu col volutpat magna</p>
                                </header>
                                <p>Feugiat accumsan lorem eu ac lorem amet ac arcu phasellus tortor enim mi mi nisi praesent adipiscing. Integer mi sed nascetur cep aliquet augue varius tempus lobortis porttitor lorem et accumsan consequat adipiscing lorem.</p>
                                <ul class="actions">
                                    <li><a href="#" class="button">Learn More</a></li>
                                </ul>
                            </div>
                            <a href="#three" class="goto-next scrolly">Next</a>
                        </section>

                        <!-- Three -->
                        <section id="three" class="spotlight style3 left">
                            <span class="image fit main bottom">
                                <img src="images/pic04.jpg" alt="" /></span>
                            <div class="content">
                                <header>
                                    <h2>Interdum felis blandit praesent sed augue</h2>
                                    <p>Accumsan integer ultricies aliquam vel massa sapien phasellus</p>
                                </header>
                                <p>Feugiat accumsan lorem eu ac lorem amet ac arcu phasellus tortor enim mi mi nisi praesent adipiscing. Integer mi sed nascetur cep aliquet augue varius tempus lobortis porttitor lorem et accumsan consequat adipiscing lorem.</p>
                                <ul class="actions">
                                    <li><a href="#" class="button">Learn More</a></li>
                                </ul>
                            </div>
                            <a href="#four" class="goto-next scrolly">Next</a>
                        </section>

                        <!-- Four -->
                        <section id="four" class="wrapper style1 special fade-up">
                            <div class="container">
                                <header class="major">
                                    <h2>Accumsan sed tempus adipiscing blandit</h2>
                                    <p>Iaculis ac volutpat vis non enim gravida nisi faucibus posuere arcu consequat</p>
                                </header>
                                <div class="box alt">
                                    <div class="row uniform">
                                        <section class="4u 6u(medium) 12u$(xsmall)">
                                            <span class="icon alt major fa-area-chart"></span>
                                            <h3>Ipsum sed commodo</h3>
                                            <p>Feugiat accumsan lorem eu ac lorem amet accumsan donec. Blandit orci porttitor.</p>
                                        </section>
                                        <section class="4u 6u$(medium) 12u$(xsmall)">
                                            <span class="icon alt major fa-comment"></span>
                                            <h3>Eleifend lorem ornare</h3>
                                            <p>Feugiat accumsan lorem eu ac lorem amet accumsan donec. Blandit orci porttitor.</p>
                                        </section>
                                        <section class="4u$ 6u(medium) 12u$(xsmall)">
                                            <span class="icon alt major fa-flask"></span>
                                            <h3>Cubilia cep lobortis</h3>
                                            <p>Feugiat accumsan lorem eu ac lorem amet accumsan donec. Blandit orci porttitor.</p>
                                        </section>
                                        <section class="4u 6u$(medium) 12u$(xsmall)">
                                            <span class="icon alt major fa-paper-plane"></span>
                                            <h3>Non semper interdum</h3>
                                            <p>Feugiat accumsan lorem eu ac lorem amet accumsan donec. Blandit orci porttitor.</p>
                                        </section>
                                        <section class="4u 6u(medium) 12u$(xsmall)">
                                            <span class="icon alt major fa-file"></span>
                                            <h3>Odio laoreet accumsan</h3>
                                            <p>Feugiat accumsan lorem eu ac lorem amet accumsan donec. Blandit orci porttitor.</p>
                                        </section>
                                        <section class="4u$ 6u$(medium) 12u$(xsmall)">
                                            <span class="icon alt major fa-lock"></span>
                                            <h3>Massa arcu accumsan</h3>
                                            <p>Feugiat accumsan lorem eu ac lorem amet accumsan donec. Blandit orci porttitor.</p>
                                        </section>
                                    </div>
                                </div>
                                <footer class="major">
                                    <ul class="actions">
                                        <li><a href="#" class="button">Magna sed feugiat</a></li>
                                    </ul>
                                </footer>
                            </div>
                        </section>

                        <!-- Five -->
                        <section id="five" class="wrapper style2 special fade">
                            <div class="container">
                                <header>
                                    <h2>Magna faucibus lorem diam</h2>
                                    <p>Ante metus praesent faucibus ante integer id accumsan eleifend</p>
                                </header>
                                <div <%--method="post" action="#"--%> class="container 50%">
                                    <div class="row uniform 50%">
                                        <div class="8u 12u$(xsmall)">
                                            <input type="email" name="email" id="email" placeholder="Your Email Address" />
                                        </div>
                                        <div class="4u$ 12u$(xsmall)">
                                            <input type="submit" value="Get Started" class="fit special" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </section>

                        <!-- Footer -->
                        <footer id="footer">
                            <ul class="icons">
                                <li><a href="#" class="icon alt fa-twitter"><span class="label">Twitter</span></a></li>
                                <li><a href="#" class="icon alt fa-facebook"><span class="label">Facebook</span></a></li>
                                <li><a href="#" class="icon alt fa-linkedin"><span class="label">LinkedIn</span></a></li>
                                <li><a href="#" class="icon alt fa-instagram"><span class="label">Instagram</span></a></li>
                                <li><a href="#" class="icon alt fa-github"><span class="label">GitHub</span></a></li>
                                <li><a href="#" class="icon alt fa-envelope"><span class="label">Email</span></a></li>
                            </ul>
                            <ul class="copyright">
                                <li>&copy; Untitled. All rights reserved.</li>
                                <li>Design: <a href="http://html5up.net">HTML5 UP</a></li>
                            </ul>
                        </footer>
                    </div>
                    <!-- Scripts -->

                    <script src="assets/js/jquery.scrolly.min.js"></script>
                    <script src="assets/js/jquery.dropotron.min.js"></script>
                    <script src="assets/js/jquery.scrollex.min.js"></script>
                    <script src="assets/js/skel.min.js"></script>
                    <script src="assets/js/util.js"></script>
                    <!--[if lte IE 8]><script src="assets/js/ie/respond.min.js"></script><![endif]-->
                    <script src="assets/js/main.js"></script>
                </div>
            </div>
        </div>

        <script src="_Scripts/HomeJavaScript.js"></script>
    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebPages.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="fa">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />

    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1" />
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
                <a
                    href="#"
                    class="scrollToTop"></a>
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
                                    <h2>آینده اینجاست</h2>
                                    <p>
                                        و هیچ ماشین پرده ای وجود ندارد<br />
                                        . فقط نرم افزار ، خیلی نرم افزار
                                    </p>
                                </header>
                                <span class="image">
                                    <img src="Images/profile.png" />
                                </span>
                            </div>
                            <a href="#one" class="goto-next scrolly">Next</a>
                        </section>

                        <!-- One -->
                        <section id="one" class="spotlight style1 bottom">
                            <span class="image fit main">
                                <img src="images/1 (3).jpg" alt="" /></span>
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
                                <img src="images/1 (4).jpg" alt="" /></span>
                            <div class="content">
                                <div class="cont">
                                    <div class="demo">
                                        <div class="login">
                                            <div class="login__check"></div>
                                            <div class="login__form">
                                                <div class="login__row">
                                                    <svg class="login__icon name svg-icon" viewBox="0 0 20 20">
                                                        <path d="M0,20 a10,8 0 0,1 20,0z M10,0 a4,4 0 0,1 0,8 a4,4 0 0,1 0,-8" />
                                                    </svg>
                                                    <input type="text" class="login__input name" />
                                                </div>
                                                <div class="login__row">
                                                    <svg class="login__icon pass svg-icon" viewBox="0 0 20 20">
                                                        <path d="M0,20 20,20 20,8 0,8z M10,13 10,16z M4,8 a6,8 0 0,1 12,0" />
                                                    </svg>
                                                    <input type="password" class="login__input pass" />
                                                </div>
                                                <button type="button" class="login__submit">Sign in</button>
                                                <p class="login__signup">Don't have an account? &nbsp;<a>Sign up</a></p>
                                            </div>
                                        </div>
                                        <div class="app">
                                            <div class="app__top">
                                                <div class="app__menu-btn">
                                                    <span></span>
                                                </div>
                                                <svg class="app__icon search svg-icon" viewBox="0 0 20 20">
                                                    <!-- yeap, its purely hardcoded numbers straight from the head :D (same for svg above) -->
                                                    <path d="M20,20 15.36,15.36 a9,9 0 0,1 -12.72,-12.72 a 9,9 0 0,1 12.72,12.72" />
                                                </svg>
                                                <p class="app__hello">Good Morning!</p>
                                                <div class="app__user">
                                                    <img src="//s3-us-west-2.amazonaws.com/s.cdpn.io/142996/profile/profile-512_5.jpg" alt="" class="app__user-photo" />
                                                    <span class="app__user-notif">3</span>
                                                </div>
                                                <div class="app__month">
                                                    <span class="app__month-btn left"></span>
                                                    <p class="app__month-name">March</p>
                                                    <span class="app__month-btn right"></span>
                                                </div>
                                            </div>
                                            <div class="app__bot">
                                                <div class="app__days">
                                                    <div class="app__day weekday">Sun</div>
                                                    <div class="app__day weekday">Mon</div>
                                                    <div class="app__day weekday">Tue</div>
                                                    <div class="app__day weekday">Wed</div>
                                                    <div class="app__day weekday">Thu</div>
                                                    <div class="app__day weekday">Fri</div>
                                                    <div class="app__day weekday">Sad</div>
                                                    <div class="app__day date">8</div>
                                                    <div class="app__day date">9</div>
                                                    <div class="app__day date">10</div>
                                                    <div class="app__day date">11</div>
                                                    <div class="app__day date">12</div>
                                                    <div class="app__day date">13</div>
                                                    <div class="app__day date">14</div>
                                                </div>
                                                <div class="app__meetings">
                                                    <div class="app__meeting">
                                                        <img src="https://s3-us-west-2.amazonaws.com/s.cdpn.io/142996/profile/profile-80_5.jpg" alt="" class="app__meeting-photo" />
                                                        <p class="app__meeting-name">Feed the cat</p>
                                                        <p class="app__meeting-info">
                                                            <span class="app__meeting-time">8 - 10am</span>
                                                            <span class="app__meeting-place">Real-life</span>
                                                        </p>
                                                    </div>
                                                    <div class="app__meeting">
                                                        <img src="//s3-us-west-2.amazonaws.com/s.cdpn.io/142996/profile/profile-512_5.jpg" alt="" class="app__meeting-photo" />
                                                        <p class="app__meeting-name">Feed the cat!</p>
                                                        <p class="app__meeting-info">
                                                            <span class="app__meeting-time">1 - 3pm</span>
                                                            <span class="app__meeting-place">Real-life</span>
                                                        </p>
                                                    </div>
                                                    <div class="app__meeting">
                                                        <img src="//s3-us-west-2.amazonaws.com/s.cdpn.io/142996/profile/profile-512_5.jpg" alt="" class="app__meeting-photo" />
                                                        <p class="app__meeting-name">FEED THIS CAT ALREADY!!!</p>
                                                        <p class="app__meeting-info">
                                                            <span class="app__meeting-time">This button is just for demo ></span>
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="app__logout">
                                                <svg class="app__logout-icon svg-icon" viewBox="0 0 20 20">
                                                    <path d="M6,3 a8,8 0 1,0 8,0 M10,0 10,12" />
                                                </svg>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <ul class="actions">
                                    <li><a href="#" class="button">Learn More</a></li>
                                </ul>
                            </div>
                            <a href="#three" class="goto-next scrolly">Next</a>
                        </section>

                        <!-- Three -->
                        <section id="three" class="spotlight style3 left">
                            <span class="image fit main bottom">
                                <img src="images/1 (6).jpg" alt="" /></span>
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
        <

        <script src="_Scripts/HomeJavaScript.js"></script>
    </form>
</body>
</html>
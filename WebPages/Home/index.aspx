<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebPages.Home.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="fa">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1" />
    <!--Favicons-->
    <link rel="apple-touch-icon" sizes="57x57" href="favicon/apple-touch-icon-57x57.png" />
    <link rel="apple-touch-icon" sizes="60x60" href="favicon/apple-touch-icon-60x60.png" />
    <link rel="icon" type="image/png" href="favicon/favicon-16x16.png" sizes="16x16" />
    <link rel="icon" type="image/png" href="favicon/favicon-32x32.png" sizes="32x32" />
    <meta name="msapplication-TileColor" content="#da532c" />

    <!--Bootstrap and Other Vendors-->
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/bootstrap-theme.min.css" />
    <link rel="stylesheet" href="css/font-awesome.min.css" />
    <link rel="stylesheet" href="vendors/owl.carousel/css/owl.carousel.css" />
    <link rel="stylesheet" type="text/css" href="vendors/rs-plugin/css/settings.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="vendors/js-flickr-gallery/css/js-flickr-gallery.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="vendors/lightbox/css/lightbox.css" media="screen" />

    <!--Construction Styles-->
    <link rel="stylesheet" href="css/style.css" />

    <!--[if lt IE 9]>
      <script src="js/html5shiv.min.js"></script>
      <script src="js/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
        <style>
            .order-spec a {
                text-decoration: none;
                position: fixed;
                left: 10px;
                bottom: 10px;
                background-color: #f1404b;
                color: #f4f5f9;
                padding: 10px;
                border-radius: 50px;
                max-width: 180px;
                z-index: 9999;
                text-align: center;
                box-shadow: 0px 3px 10px rgba(0,0,0,0.3);
                transition: 500ms;
            }

                .order-spec a:hover {
                    background-color: #252c41;
                }
        </style>
        <div class="order-spec"><a href="http://webroya.ir" target="_blank">جهت سفارش طراحی سایت و قالب اختصاصی کلیک کنید.</a></div>
        <div id="pageloader" class="row m0">
            <div class="loader-item">
                <img src="images/loader.gif" alt="loading">
            </div>
        </div>
        <section id="nr_topStrip" class="row">
            <div class="container">
                <div class="row">
                    <ul class="list-inline c-info fleft">
                        <li><a href="tel:123456789012"><i class="fa fa-phone"></i>1234-5678-9012</a></li>
                        <li><a href="mailto:info@domain.com"><i class="fa fa-envelope-o"></i>info@domain.com</a></li>
                    </ul>
                    <ul class="list-inline lang fright">
                        <li class="active"><a href="#">
                            <img src="images/flags/flag1.png" alt=""></a></li>
                        <li><a href="#">
                            <img src="images/flags/flag2.png" alt=""></a></li>
                        <li><a href="#">
                            <img src="images/flags/flag3.png" alt=""></a></li>
                        <li><a href="#">
                            <img src="images/flags/flag4.png" alt=""></a></li>
                    </ul>
                </div>
            </div>
        </section>
        <!--Top Strip-->

        <header class="row">
            <div class="container">
                <div class="row">
                    <div class="logo col-sm-6">
                        <div class="row">
                            <a href="index.html">
                                <img src="images/logo.png" alt="Construction - Construction Company HTML Template"></a>
                        </div>
                    </div>
                    <div class="social_nav col-sm-6">
                        <div class="row">
                            <ul class="list-inline fright">
                                <li><a href="#"><i class="fa fa-google-plus"></i></a></li>
                                <li><a href="#"><i class="fa fa-twitter"></i></a></li>
                                <li><a href="#"><i class="fa fa-facebook"></i></a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </header>
        <!--Header-->

        <nav class="navbar navbar-default navbar-static-top">
            <div class="container-fluid container">
                <div class="row m04m">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#main_nav">
                            <span class="bars">
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                            </span>
                            <span class="btn-text">مشاهده منو اصلی</span>
                        </button>
                    </div>
                    <div class="collapse navbar-collapse" id="main_nav">
                        <ul class="nav navbar-nav">
                            <li class="active "><a href="index.html">خانه</a></li>
                            <li class=" dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">درباره ما</a>
                                <ul class="dropdown-menu" role="menu">
                                    <li><a href="about-us.html">درباره ما 1</a></li>
                                    <li><a href="about-us2.html">درباره ما 2</a></li>
                                </ul>
                            </li>
                            <li class=" dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">پروژه ها</a>
                                <ul class="dropdown-menu" role="menu">
                                    <li><a href="projects_full.html">پروژه ها ی تمام صفحه</a></li>
                                    <li><a href="projects2.html">پروژه ها های دو ستونه</a></li>
                                    <li><a href="projects3.html">پروژه ها سه ستونه</a></li>
                                </ul>
                            </li>
                            <li><a href="services.html">خدمات ما</a></li>
                            <li class=" dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">اخبار</a>
                                <ul class="dropdown-menu" role="menu">
                                    <li><a href="blog.html">وبلاگ</a></li>
                                    <li><a href="single-post.html">ادامه مطلب پست</a></li>
                                </ul>
                            </li>
                            <li class=" dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">تماس با ما</a>
                                <ul class="dropdown-menu" role="menu">
                                    <li><a href="contact.html">تماس با ما 1</a></li>
                                    <li><a href="contact2.html">تماس با ما 2</a></li>
                                </ul>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </nav>
        <!--Main Nav-->

        <section id="nr_slider" class="row">
            <div class="mainSliderContainer">
                <div class="mainSlider">
                    <ul>
                        <!-- SLIDE 3 -->
                        <li data-transition="boxslide" data-slotamount="7">
                            <img src="images/slider/slide3.png" alt="slidebg1" data-bgfit="cover" data-bgposition="left top" data-bgrepeat="no-repeat">
                            <div class="caption sfr str"
                                data-x="-100"
                                data-y="135"
                                data-speed="700"
                                data-start="1700"
                                data-easing="easeOutBack">
                                <h3>قالب <strong>ساخت و ساز</strong></h3>
                            </div>
                            <div class="caption sfl stl"
                                data-x="-100"
                                data-y="190"
                                data-speed="500"
                                data-start="1900"
                                data-easing="easeOutBack">
                                <h4>ساخته شده با <strong>بوت استرپ</strong></h4>
                            </div>
                            <div class="caption skewfromleft skewtoleft"
                                data-x="-100"
                                data-y="265"
                                data-hoffset="-176"
                                data-speed="500"
                                data-start="1900"
                                data-easing="easeOutBack">
                                <p>
                                    لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده ا
                                    <br>
                                    ز طراحان گرافیک است.
                                </p>
                            </div>
                            <div class="caption sfb stb"
                                data-x="-100"
                                data-y="375"
                                data-hoffset="0"
                                data-speed="500"
                                data-start="1900"
                                data-easing="easeOutBack">
                                <a type="button" class="btn btn-default">بیشتر بخوانید</a>
                            </div>
                            <div class="caption skewfromright skewtoright"
                                data-x="right"
                                data-y="0"
                                data-hoffset="176"
                                data-speed="500"
                                data-start="1900"
                                data-easing="easeOutBack">
                                <div class="sketch">
                                    <img src="images/slider/sketch.png" alt="brifcase">
                                </div>
                            </div>
                        </li>
                        <!-- SLIDE 2 -->
                        <li data-transition="boxslide" data-slotamount="7">
                            <img src="images/slider/slide2.png" alt="slidebg1" data-bgfit="cover" data-bgposition="left top" data-bgrepeat="no-repeat">
                            <div class="caption sfr str"
                                data-x="-100"
                                data-y="135"
                                data-speed="700"
                                data-start="1700"
                                data-easing="easeOutBack">
                                <h3><strong>واکنشگرا</strong> و مخصوص شرکت ها</h3>
                            </div>
                            <div class="caption sfl stl"
                                data-x="-100"
                                data-y="190"
                                data-speed="500"
                                data-start="1900"
                                data-easing="easeOutBack">
                                <h4>طراحی <strong>بسیار</strong> زیبا و مدرن</h4>
                            </div>
                            <div class="caption skewfromleft skewtoleft"
                                data-x="-100"
                                data-y="265"
                                data-hoffset="-176"
                                data-speed="500"
                                data-start="1900"
                                data-easing="easeOutBack">
                                <p>لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است. </p>
                            </div>
                            <div class="caption sfb stb"
                                data-x="-100"
                                data-y="375"
                                data-hoffset="0"
                                data-speed="500"
                                data-start="1900"
                                data-easing="easeOutBack">
                                <a type="button" class="btn btn-default">بیشتر بخوانید</a>
                            </div>
                            <div class="caption skewfromright skewtoright"
                                data-x="right"
                                data-y="130"
                                data-hoffset="176"
                                data-speed="500"
                                data-start="1900"
                                data-easing="easeOutBack">
                                <div class="tools">
                                    <img src="images/slider/construction_tools.png" alt="brifcase">
                                </div>
                            </div>
                        </li>
                        <!-- SLIDE  -->
                        <li data-transition="boxslide" data-slotamount="7">
                            <img src="images/slider/slide1.png" alt="slidebg1" data-bgfit="cover" data-bgposition="left top" data-bgrepeat="no-repeat">
                            <div class="caption sfr str"
                                data-x="center"
                                data-y="140"
                                data-speed="700"
                                data-start="1700"
                                data-easing="easeOutBack">
                                <h2>ما کمپانی <strong>ساخت و ساز</strong> هستیم</h2>
                            </div>
                            <div class="caption sfl stl"
                                data-x="center"
                                data-y="225"
                                data-speed="500"
                                data-start="1900"
                                data-easing="easeOutBack">
                                <div class="cont-row">از <span class="bb3">خانه های</span>کوچک تا<span class="bb1">ساختمان های</span> بزرگ</div>
                            </div>
                            <div class="caption skewfromleft skewtoleft"
                                data-x="center"
                                data-y="310"
                                data-hoffset="-176"
                                data-speed="500"
                                data-start="1900"
                                data-easing="easeOutBack">
                                <div class="ico_box">
                                    <img src="images/slider/ico1.png" alt="brifcase">
                                </div>
                            </div>
                            <div class="caption sfb stb"
                                data-x="center"
                                data-y="310"
                                data-hoffset="0"
                                data-speed="500"
                                data-start="1900"
                                data-easing="easeOutBack">
                                <div class="ico_box">
                                    <img src="images/slider/ico2.png" alt="brifcase">
                                </div>
                            </div>
                            <div class="caption skewfromright skewtoright"
                                data-x="center"
                                data-y="310"
                                data-hoffset="176"
                                data-speed="500"
                                data-start="1900"
                                data-easing="easeOutBack">
                                <div class="ico_box">
                                    <img src="images/slider/ico3.png" alt="brifcase">
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>

            <div class="container sliderAfterTriangle"></div>
            <!--Triangle After Slider-->
        </section>
        <!--Slider-->

        <section id="nr_services" class="row">
            <div class="container">
                <div class="row sectionTitles">
                    <h2 class="sectionTitle">خدمات ما</h2>
                    <div class="sectionSubTitle">وبسایت ساخت و ساز تقدیم میکند</div>
                </div>
                <div class="row m0 text-center">
                    <div class="col-sm-3">
                        <div class="row m0 service">
                            <div class="row m0 innerRow">
                                <i class="fa fa-laptop"></i>
                                <div class="serviceName" data-hover="نقشه کشی ساختمان">نقشه کشی ساختمان</div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="row m0 service">
                            <div class="row m0 innerRow">
                                <i class="fa fa-film"></i>
                                <div class="serviceName" data-hover="طراحی ساختمان و خانه">طراحی ساختمان و خانه</div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="row m0 service">
                            <div class="row m0 innerRow">
                                <i class="fa fa-clock-o"></i>
                                <div class="serviceName" data-hover="سرعت عمل بالا">سرعت عمل بالا</div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="row m0 service">
                            <div class="row m0 innerRow">
                                <i class="fa fa-building-o"></i>
                                <div class="serviceName" data-hover="بازسازی خانه">بازسازی خانه</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!--Services-->

        <section id="projectsRow" class="row fullWidth">
            <div class="row sectionTitles m0">
                <h2 class="sectionTitle">پروژه های ما</h2>
                <div class="sectionSubTitle">آخرین کار ها</div>
            </div>
            <div class="row filtersRow m0">
                <button type="button" class="collapsed project_filderButton visible-xs" data-toggle="collapse" data-target="#filters">
                    <span class="btn-text"><i class="fa fa-filter"></i>دسته بندی پروژه ها</span>
                </button>
                <ul class="list-inline text-center collapse navbar-collapse filters" id="filters">
                    <li class="active" data-filter="*"><i class="fa fa-th"></i>نمایش همه</li>
                    <li data-filter=".catHospital">بیمارستان ها </li>
                    <li data-filter=".catSchools">مدارس </li>
                    <li data-filter=".catHouses">خانه ها </li>
                    <li data-filter=".catFlats">ساختمان ها </li>
                    <li data-filter=".catOffices">دفاتر کار </li>
                    <li data-filter=".catUniversities">دانشگاه ها </li>
                </ul>
            </div>
            <div class="row projects m0" id="container">
                <div class="project catHouses">
                    <a href="images/projects/project1.png" data-lightbox="project" data-title="Central Hospital (building)">
                        <img src="images/projects/project1.png" alt="Project 1" class="projectImg">
                    </a>
                    <div class="projectDetails row m0">
                        <div class="fleft nameType">
                            <div class="row m0 projectName">نام پروژه اینجا</div>
                            <div class="row m0 projectType">نقشه کشی, طراحی, پیاده سازی</div>
                        </div>
                        <div class="fright projectIcons btn-group" role="group">
                            <a href="images/projects/project1.png" data-lightbox="project" data-title="Central Hospital (building)" class="btn btn-default"><i class="fa fa-search"></i></a>
                            <a href="#" class="btn btn-default"><i class="fa fa-file-o"></i></a>
                        </div>
                    </div>
                </div>
                <div class="project catHospital">
                    <a href="images/projects/project2.png" data-lightbox="project" data-title="Construction CEO (ceo, architect)">
                        <img src="images/projects/project2.png" alt="Project 1" class="projectImg">
                    </a>
                    <div class="projectDetails row m0">
                        <div class="fleft nameType">
                            <div class="row m0 projectName">نام پروژه اینجا</div>
                            <div class="row m0 projectType">نقشه کشی, طراحی, پیاده سازی</div>
                        </div>
                        <div class="fright projectIcons btn-group" role="group">
                            <a href="images/projects/project2.png" data-lightbox="project" data-title="Construction CEO (ceo, architect)" class="btn btn-default"><i class="fa fa-search"></i></a>
                            <a href="#" class="btn btn-default"><i class="fa fa-file-o"></i></a>
                        </div>
                    </div>
                </div>
                <div class="project catFlats">
                    <a href="images/projects/project3.png" data-lightbox="project" data-title="Workder Accessories (tools, accessories)">
                        <img src="images/projects/project3.png" alt="Project 1" class="projectImg">
                    </a>
                    <div class="projectDetails row m0">
                        <div class="fleft nameType">
                            <div class="row m0 projectName">نام پروژه اینجا</div>
                            <div class="row m0 projectType">نقشه کشی, طراحی, پیاده سازی</div>
                        </div>
                        <div class="fright projectIcons btn-group" role="group">
                            <a href="images/projects/project3.png" data-lightbox="project" data-title="Workder Accessories (tools, accessories)" class="btn btn-default"><i class="fa fa-search"></i></a>
                            <a href="#" class="btn btn-default"><i class="fa fa-file-o"></i></a>
                        </div>
                    </div>
                </div>
                <div class="project catSchools">
                    <a href="images/projects/project4.png" data-lightbox="project" data-title="Rebuilding an old University (university, building)">
                        <img src="images/projects/project4.png" alt="Project 1" class="projectImg">
                    </a>
                    <div class="projectDetails row m0">
                        <div class="fleft nameType">
                            <div class="row m0 projectName">نام پروژه اینجا</div>
                            <div class="row m0 projectType">نقشه کشی, طراحی, پیاده سازی</div>
                        </div>
                        <div class="fright projectIcons btn-group" role="group">
                            <a href="images/projects/project4.png" data-lightbox="project" data-title="Rebuilding an old University (university, building)" class="btn btn-default"><i class="fa fa-search"></i></a>
                            <a href="#" class="btn btn-default"><i class="fa fa-file-o"></i></a>
                        </div>
                    </div>
                </div>
                <div class="project catUniversities">
                    <a href="images/projects/project5.png" data-lightbox="project" data-title="Construction Tools (tools, assets)">
                        <img src="images/projects/project5.png" alt="Project 1" class="projectImg">
                    </a>
                    <div class="projectDetails row m0">
                        <div class="fleft nameType">
                            <div class="row m0 projectName">نام پروژه اینجا</div>
                            <div class="row m0 projectType">نقشه کشی, طراحی, پیاده سازی</div>
                        </div>
                        <div class="fright projectIcons btn-group" role="group">
                            <a href="images/projects/project5.png" data-lightbox="project" data-title="Construction Tools (tools, assets)" class="btn btn-default"><i class="fa fa-search"></i></a>
                            <a href="#" class="btn btn-default"><i class="fa fa-file-o"></i></a>
                        </div>
                    </div>
                </div>
                <div class="project catOffices">
                    <a href="images/projects/project6.png" data-lightbox="project" data-title="Big Trucks on Action (cat, building)">
                        <img src="images/projects/project6.png" alt="Project 1" class="projectImg">
                    </a>
                    <div class="projectDetails row m0">
                        <div class="fleft nameType">
                            <div class="row m0 projectName">نام پروژه اینجا</div>
                            <div class="row m0 projectType">نقشه کشی, طراحی, پیاده سازی</div>
                        </div>
                        <div class="fright projectIcons btn-group" role="group">
                            <a href="images/projects/project6.png" data-lightbox="project" data-title="Big Trucks on Action (cat, building)" class="btn btn-default"><i class="fa fa-search"></i></a>
                            <a href="#" class="btn btn-default"><i class="fa fa-file-o"></i></a>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!--Projects-->

        <section id="latestPosts" class="row">
            <div class="container">
                <div class="row sectionTitles">
                    <h2 class="sectionTitle">آخرین اخبار ما</h2>
                    <div class="sectionSubTitle">اخبار داغ گروه</div>
                </div>
                <div class="row">
                    <div class="col-sm-4 blog latest-blog">
                        <div class="row m0 blogInner">
                            <div class="row m0 blogDateTime">
                                <i class="fa fa-calendar"></i>15 شهریور 1395 - ساعت 21:15
                            </div>
                            <div class="row m0 featureImg">
                                <a href="single-post.html">
                                    <img src="images/blog/blog1.png" alt="Faceted Search Has Landed" class="img-responsive">
                                </a>
                            </div>
                            <div class="row m0 postExcerpts">
                                <div class="row m0 postExcerptInner">
                                    <a href="single-post.html" class="postTitle row m0">
                                        <h4>نام خبر در این بخش</h4>
                                    </a>
                                    <p>لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است. </p>
                                    <a href="single-post.html" class="readMore">بیشتر بخوانید</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-4 blog latest-blog">
                        <div class="row m0 blogInner">
                            <div class="row m0 blogDateTime">
                                <i class="fa fa-calendar"></i>15 شهریور 1395 - ساعت 21:15
                            </div>
                            <div class="row m0 featureImg">
                                <a href="single-post.html">
                                    <img src="images/blog/blog2.png" alt="Faceted Search Has Landed" class="img-responsive">
                                </a>
                            </div>
                            <div class="row m0 postExcerpts">
                                <div class="row m0 postExcerptInner">
                                    <a href="single-post.html" class="postTitle row m0">
                                        <h4>نام خبر در این بخش</h4>
                                    </a>
                                    <p>لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است. </p>
                                    <a href="single-post.html" class="readMore">بیشتر بخوانید</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-4 blog latest-blog">
                        <div class="row m0 blogInner">
                            <div class="row m0 blogDateTime">
                                <i class="fa fa-calendar"></i>15 شهریور 1395 - ساعت 21:15
                            </div>
                            <div class="row m0 featureImg">
                                <a href="single-post.html">
                                    <img src="images/blog/blog3.png" alt="Faceted Search Has Landed" class="img-responsive">
                                </a>
                            </div>
                            <div class="row m0 postExcerpts">
                                <div class="row m0 postExcerptInner">
                                    <a href="single-post.html" class="postTitle row m0">
                                        <h4>نام خبر در این بخش</h4>
                                    </a>
                                    <p>لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است. </p>
                                    <a href="single-post.html" class="readMore">بیشتر بخوانید</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!--Latest Blog-->

        <section id="testimonials" class="row">
            <div class="container">
                <div class="row sectionTitles">
                    <h2 class="sectionTitle whiteTC">نظرات مشتریان</h2>
                    <div class="sectionSubTitle whiteTC">مشتریان درباره ما مینویسند</div>
                </div>
                <div class="row">
                    <div class="owl-carousel testimonialSlider row m0">
                        <div class="item">
                            <div class="clientPhoto row m0">
                                <img src="images/testimonial/photo.png" alt="">
                            </div>
                            <div class="clientNameTitle row m0">رضا دلیر، مدیر عامل ماسوله</div>
                            <div class="arrow row m0">
                                <img src="images/testimonial/arrow.png" alt="arrow down">
                            </div>
                            <div class="testimonial row m0">لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است. </div>
                        </div>
                        <div class="item">
                            <div class="clientPhoto row m0">
                                <img src="images/testimonial/photo.png" alt="">
                            </div>
                            <div class="clientNameTitle row m0">رضا دلیر، مدیر عامل ماسوله</div>
                            <div class="arrow row m0">
                                <img src="images/testimonial/arrow.png" alt="arrow down">
                            </div>
                            <div class="testimonial row m0">لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است. </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!--Testimonials-->

        <section id="elements" class="row">
            <div class="row sectionTitles m0">
                <h2 class="sectionTitle">سوالات متداول و سفارش</h2>
                <div class="sectionSubTitle">سوالات متداول و سفارش پروژه</div>
            </div>
            <div class="container">
                <div class="row">
                    <div class="col-sm-6">
                        <div class="panel-group" id="hAccordion" role="tablist" aria-multiselectable="true">
                            <div class="panel panel-default">
                                <div class="panel-heading" role="tab" id="headingOne">
                                    <h4 class="panel-title">
                                        <a data-toggle="collapse" data-parent="#hAccordion" href="#collapse1" aria-expanded="true" aria-controls="collapse1">لورم ایپسوم متن ساختگی است <span class="sign fa"></span><i class="fa fa-question"></i>
                                        </a>
                                    </h4>
                                </div>
                                <div id="collapse1" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                                    <div class="panel-body">
                                        <div class="fleft icon">
                                            <i class="fa fa-laptop"></i>
                                        </div>
                                        <div class="fleft texts">
                                            لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است.
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!--hAccordion No #1-->
                            <div class="panel panel-default">
                                <div class="panel-heading" role="tab" id="heading2">
                                    <h4 class="panel-title">
                                        <a class="collapsed" data-toggle="collapse" data-parent="#hAccordion" href="#collapse2" aria-expanded="false" aria-controls="collapse2">لورم ایپسوم متن ساختگی است <span class="sign fa"></span><i class="fa fa-question"></i>
                                        </a>
                                    </h4>
                                </div>
                                <div id="collapse2" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading2">
                                    <div class="panel-body">
                                        <div class="fleft icon">
                                            <i class="fa fa-laptop"></i>
                                        </div>
                                        <div class="fleft texts">
                                            لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است.
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!--hAccordion No #2-->
                            <div class="panel panel-default">
                                <div class="panel-heading" role="tab" id="heading3">
                                    <h4 class="panel-title">
                                        <a class="collapsed" data-toggle="collapse" data-parent="#hAccordion" href="#collapse3" aria-expanded="false" aria-controls="collapse3">لورم ایپسوم متن ساختگی است <span class="sign fa"></span><i class="fa fa-question"></i>
                                        </a>
                                    </h4>
                                </div>
                                <div id="collapse3" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading3">
                                    <div class="panel-body">
                                        <div class="fleft icon">
                                            <i class="fa fa-laptop"></i>
                                        </div>
                                        <div class="fleft texts">
                                            لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است.
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!--hAccordion No #3-->
                            <div class="panel panel-default">
                                <div class="panel-heading" role="tab" id="heading4">
                                    <h4 class="panel-title">
                                        <a class="collapsed" data-toggle="collapse" data-parent="#hAccordion" href="#collapse4" aria-expanded="false" aria-controls="collapse4">لورم ایپسوم متن ساختگی است <span class="sign fa"></span><i class="fa fa-question"></i>
                                        </a>
                                    </h4>
                                </div>
                                <div id="collapse4" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading4">
                                    <div class="panel-body">
                                        <div class="fleft icon">
                                            <i class="fa fa-laptop"></i>
                                        </div>
                                        <div class="fleft texts">
                                            لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است.
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!--hAccordion No #4-->
                            <div class="panel panel-default">
                                <div class="panel-heading" role="tab" id="heading5">
                                    <h4 class="panel-title">
                                        <a class="collapsed" data-toggle="collapse" data-parent="#hAccordion" href="#collapse5" aria-expanded="false" aria-controls="collapse5">لورم ایپسوم متن ساختگی است <span class="sign fa"></span><i class="fa fa-question"></i>
                                        </a>
                                    </h4>
                                </div>
                                <div id="collapse5" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading5">
                                    <div class="panel-body">
                                        <div class="fleft icon">
                                            <i class="fa fa-laptop"></i>
                                        </div>
                                        <div class="fleft texts">
                                            لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است.
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!--hAccordion No #5-->
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="row m0 leftAlignedTap">
                            <ul class="nav nav-tabs" role="tablist" id="myTab">
                                <li role="presentation" class="active"><a href="#h_tab1" aria-controls="h_tab1" role="tab" data-toggle="tab">
                                    <i class="fa fa-laptop"></i>لایه بندی ریسپانسیو
                                </a></li>
                                <li role="presentation"><a href="#h_tab2" aria-controls="h_tab2" role="tab" data-toggle="tab">
                                    <i class="fa fa-briefcase"></i>چندین نمونه کار
                                </a></li>
                                <li role="presentation"><a href="#h_tab3" aria-controls="h_tab3" role="tab" data-toggle="tab">
                                    <i class="fa fa-youtube-play"></i>پشتیبانی از ویدئو
                                </a></li>
                            </ul>
                            <div class="tab-content">
                                <div role="tabpanel" class="tab-pane active" id="h_tab1">
                                    با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است. چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است و برای شرایط فعلی تکنولوژی مورد نیاز و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد. کتابهای زیادی در شصت و سه درصد گذشته، حال و آینده شناخت فراوان جامعه و متخصصان را می طلبد
                                </div>
                                <div role="tabpanel" class="tab-pane" id="h_tab2">
                                    لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است. چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است و برای شرایط فعلی تکنولوژی مورد نیاز و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد. کتابهای زیادی در شصت و سه درصد گذشته، حال و آینده شناخت فراوان جامعه و متخصصان را می طلبد
                                </div>
                                <div role="tabpanel" class="tab-pane" id="h_tab3">
                                    لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است. چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است و برای شرایط فعلی تکنولوژی مورد نیاز و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد. کتابهای زیادی در شصت و سه درصد گذشته، حال و آینده شناخت فراوان جامعه و متخص
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!--Elements-->

        <footer id="nr_footer" class="row">
            <div class="container">
                <div class="row goTop">
                    <a href="#top"><i class="fa fa-angle-up"></i></a>
                </div>
                <div class="footerWidget row">
                    <div class="col-sm-6 widget">
                        <div class="getInTouch_widget row">
                            <div class="widgetHeader row m0">
                                <img src="images/whiteSquare.png" alt="">با ما در ارتباط باشید
                            </div>
                            <div class="row getInTouch_tab m0">
                                <ul class="nav nav-tabs nav-justified" role="tablist" id="getInTouch_tab">
                                    <li role="presentation" class="active"><a href="#contactPhone" aria-controls="contactPhone" role="tab" data-toggle="tab"><i class="fa fa-phone"></i></a></li>
                                    <li role="presentation"><a href="#contactEmail" aria-controls="contactEmail" role="tab" data-toggle="tab"><i class="fa fa-envelope"></i></a></li>
                                    <li role="presentation"><a href="#contactHome" aria-controls="contactHome" role="tab" data-toggle="tab"><i class="fa fa-map-marker"></i></a></li>
                                </ul>

                                <div class="tab-content">
                                    <div role="tabpanel" class="tab-pane active" id="contactPhone"><i class="fa fa-phone"></i>با ما تماس بگیرید : +399 (500) 321 9548</div>
                                    <div role="tabpanel" class="tab-pane" id="contactEmail"><i class="fa fa-envelope"></i>به ما ایمیل بزنید : support@construction.com</div>
                                    <div role="tabpanel" class="tab-pane" id="contactHome"><i class="fa fa-map-marker"></i>ایران، شمال شرق، خراسان رضوی، مشهد</div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 widget">
                        <div class="row">
                            <div class="widgetHeader row m0">
                                <img src="images/whiteSquare.png" alt="">درباره ساخت و ساز ما
                            </div>
                            <div class="row m0 footer-white">
                                لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است. چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است و برای شرایط فعلی تکنولوژی مورد نیاز و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد. کتابهای زیادی در شصت و سه درصد گذشته، حال و آینده شناخت فراوان جامعه و متخصصان را می طلبد
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row copyrightRow">
                    فارسی و راستچین سازی توسط <a href="http://rtl-theme.com/author/irezadalir">رضا دلیر</a> .
                </div>
            </div>
        </footer>

        <!--jQuery, Bootstrap and other vendor JS-->
        <script src="js/jquery-2.1.3.min.js"></script>
        <script src="https://maps.googleapis.com/maps/api/js"></script>
        <script src="js/bootstrap.min.js"></script>

        <script src="vendors/rs-plugin/js/jquery.themepunch.tools.min.js"></script>
        <script src="vendors/rs-plugin/js/jquery.themepunch.revolution.min.js"></script>
        <script src="vendors/owl.carousel/js/owl.carousel.min.js"></script>
        <script src="vendors/nicescroll/jquery.nicescroll.js"></script>

        <script src="vendors/js-flickr-gallery/js/js-flickr-gallery.min.js"></script>
        <script src="vendors/lightbox/js/lightbox.min.js"></script>
        <!--Isotope-->
        <script src="vendors/isotope/isotope-custom.js"></script>

        <!--Construction JS-->
        <script src="js/construction.js"></script>
    </form>
</body>
</html>
<%@ Page Title="" Language="C#" MasterPageFile="~/_construction/IndexMaster.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebPages._construction.Index1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="nr_slider" class="row">
        <div class="mainSliderContainer">
            <div class="mainSlider" style="direction: rtl;">
                <ul>
                    <!-- SLIDE  -->
                    <li data-transition="boxslide" data-slotamount="7">
                        <img src="images/slider/slide1.png" alt="slidebg1" data-bgfit="cover" data-bgposition="left top" data-bgrepeat="no-repeat" />
                        <div class="caption sfr str"
                            data-x="center"
                            data-y="140"
                            data-speed="700"
                            data-start="1700"
                            data-easing="easeOutBack">
                            <h2>ما شرکت <strong>ساخت و ساز</strong>هستیم</h2>
                        </div>
                        <div class="caption sfl stl"
                            data-x="center"
                            data-y="225"
                            data-speed="500"
                            data-start="1900"
                            data-easing="easeOutBack">
                            <div class="cont-row">
                                از
                                <span class="bb3">خانه های</span>
                                کوچک
                                تا

                                <span class="bb1">ساختمان های </span>
                                بزرگ
                            </div>
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
                    <!-- SLIDE 2 -->
                    <li data-transition="boxslide" data-slotamount="7">
                        <img src="images/slider/slide2.png" alt="slidebg1" data-bgfit="cover" data-bgposition="left top" data-bgrepeat="no-repeat">
                        <div class="caption sfr str"
                            data-x="-100"
                            data-y="135"
                            data-speed="700"
                            data-start="1700"
                            data-easing="easeOutBack">
                            <h3>یک کمپانی قابل
                                <strong>اعتماد</strong>
                                و
                                <strong>مطمئن</strong>
                            </h3>
                        </div>
                        <div class="caption sfl stl"
                            data-x="-100"
                            data-y="190"
                            data-speed="500"
                            data-start="1900"
                            data-easing="easeOutBack">
                            <h4>لورم اسپوم متن ساختگی</h4>
                        </div>
                        <div class="caption skewfromleft skewtoleft"
                            data-x="-100"
                            data-y="265"
                            data-hoffset="-176"
                            data-speed="500"
                            data-start="1900"
                            data-easing="easeOutBack">
                            <p>
                                لورم اسپوم متن ساختگی با استفاده<br>
                                در صنعت چاپ و گرافیک
                                <br>
                                و مورد استفاده طراحان وب
                            </p>
                        </div>
                        <div class="caption sfb stb"
                            data-x="-100"
                            data-y="375"
                            data-hoffset="0"
                            data-speed="500"
                            data-start="1900"
                            data-easing="easeOutBack">
                            <a type="button" class="btn btn-default">بیشتر بدانید</a>
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
                    <!-- SLIDE 3 -->
                    <li data-transition="boxslide" data-slotamount="7">
                        <img src="images/slider/slide3.png" alt="slidebg1" data-bgfit="cover" data-bgposition="left top" data-bgrepeat="no-repeat">
                        <div class="caption sfr str"
                            data-x="-100"
                            data-y="135"
                            data-speed="700"
                            data-start="1700"
                            data-easing="easeOutBack">
                            <h3>قالب
                                <strong>ساخت و ساز</strong>
                            </h3>
                        </div>
                        <div class="caption sfl stl"
                            data-x="-100"
                            data-y="190"
                            data-speed="500"
                            data-start="1900"
                            data-easing="easeOutBack">
                            <h4>ساخته شده با
                                <strong>بوت استرپ</strong>
                            </h4>
                        </div>
                        <div class="caption skewfromleft skewtoleft"
                            data-x="-100"
                            data-y="265"
                            data-hoffset="-176"
                            data-speed="500"
                            data-start="1900"
                            data-easing="easeOutBack">
                            <p>
                                لورم اسپوم یک متن ساختگی با
                                <br>
                                لورم اسپوم یک متن ساختگی با
                                <br>
                                لورم اسپوم یک متن ساختگی با
                            </p>
                        </div>
                        <div class="caption sfb stb"
                            data-x="-100"
                            data-y="375"
                            data-hoffset="0"
                            data-speed="500"
                            data-start="1900"
                            data-easing="easeOutBack">
                            <a type="button" class="btn btn-default">بیشتر بدانید</a>
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
                </ul>
            </div>
        </div>

        <div class="container sliderAfterTriangle"></div>
        <!--Triangle After Slider-->
    </section>
    <!--Slider-->

    <section id="nr_services" class="row">
        <div class="container" style="direction: rtl">
            <div class="row sectionTitles">
                <h2 class="sectionTitle">خدمات ما</h2>
                <div class="sectionSubTitle">آنچه ما ارائه می دهیم</div>
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
                            <i class="fa fa-clock-o"></i>
                            <div class="serviceName" data-hover="سرعت عمل بالا">سرعت عمل بالا</div>
                        </div>
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="row m0 service">
                        <div class="row m0 innerRow">
                            <i class="fa fa-film"></i>
                            <div class="serviceName" data-hover="طراحی ساختمان">طراحی ساختمان</div>
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

    <section id="projects" class="row fullWidth">
        <div class="row sectionTitles m0">
            <h2 class="sectionTitle">پروژه های ما</h2>
            <div class="sectionSubTitle">آخرین کار ها</div>
        </div>
        <div class="row filters m0">
            <button type="button" class="collapsed project_filderButton visible-xs" data-toggle="collapse" data-target="#filters">
                <span class="btn-text"><i class="fa fa-filter"></i>Project Filter</span>
            </button>
            <ul class="list-inline text-center collapse navbar-collapse" id="filters">
                <li class="filter" data-filter="all"><i class="fa fa-th"></i>نمایش همه</li>
                <li class="filter" data-filter=".catHospital">بیمارستان</li>
                <li class="filter" data-filter=".catSchools">مدرسه</li>
                <li class="filter" data-filter=".catHouses">خانه</li>
                <li class="filter" data-filter=".catFlats">آپارتمان</li>
                <li class="filter" data-filter=".catOffices">دفتر کار</li>
                <li class="filter" data-filter=".catUniversities">دانشگاه ها</li>
            </ul>
        </div>
        <div class="row projects m0">
            <div class="project mix catHouses">
                <a href="images/projects/project1.png" data-lightbox="project" data-title="Central Hospital (building)">
                    <img src="images/projects/project1.png" alt="Project 1" class="projectImg">
                </a>
                <div class="projectDetails row m0">

                    <div class="fleft projectIcons btn-group" role="group">
                        <a href="images/projects/project1.png" data-lightbox="project" data-title="Central Hospital (building)" class="btn btn-default"><i class="fa fa-search"></i></a>
                        <a href="#" class="btn btn-default"><i class="fa fa-file-o"></i></a>
                    </div>
                    <div class="fright nameType">
                        <div class="row m0 projectName">بیمارستان مرکزی</div>
                        <div class="row m0 projectType">ساخت و ساز</div>
                    </div>
                </div>
            </div>
            <div class="project mix catHospital">
                <a href="images/projects/project2.png" data-lightbox="project" data-title="Construction CEO (ceo, architect)">
                    <img src="images/projects/project2.png" alt="Project 1" class="projectImg">
                </a>
                <div class="projectDetails row m0">
                    <div class="fleft projectIcons btn-group" role="group">
                        <a href="images/projects/project1.png" data-lightbox="project" data-title="Central Hospital (building)" class="btn btn-default"><i class="fa fa-search"></i></a>
                        <a href="#" class="btn btn-default"><i class="fa fa-file-o"></i></a>
                    </div>
                    <div class="fright nameType">
                        <div class="row m0 projectName">بیمارستان مرکزی</div>
                        <div class="row m0 projectType">ساخت و ساز</div>
                    </div>
                </div>
            </div>
            <div class="project mix catFlats">
                <a href="images/projects/project3.png" data-lightbox="project" data-title="Workder Accessories (tools, accessories)">
                    <img src="images/projects/project3.png" alt="Project 1" class="projectImg">
                </a>
                <div class="projectDetails row m0">
                    <div class="fleft projectIcons btn-group" role="group">
                        <a href="images/projects/project1.png" data-lightbox="project" data-title="Central Hospital (building)" class="btn btn-default"><i class="fa fa-search"></i></a>
                        <a href="#" class="btn btn-default"><i class="fa fa-file-o"></i></a>
                    </div>
                    <div class="fright nameType">
                        <div class="row m0 projectName">بیمارستان مرکزی</div>
                        <div class="row m0 projectType">ساخت و ساز</div>
                    </div>
                </div>
            </div>
            <div class="project mix catSchools">
                <a href="images/projects/project4.png" data-lightbox="project" data-title="Rebuilding an old University (university, building)">
                    <img src="images/projects/project4.png" alt="Project 1" class="projectImg">
                </a>
                <div class="projectDetails row m0">
                    <div class="fleft projectIcons btn-group" role="group">
                        <a href="images/projects/project1.png" data-lightbox="project" data-title="Central Hospital (building)" class="btn btn-default"><i class="fa fa-search"></i></a>
                        <a href="#" class="btn btn-default"><i class="fa fa-file-o"></i></a>
                    </div>
                    <div class="fright nameType">
                        <div class="row m0 projectName">بیمارستان مرکزی</div>
                        <div class="row m0 projectType">ساخت و ساز</div>
                    </div>
                </div>
            </div>
            <div class="project mix catUniversities">
                <a href="images/projects/project5.png" data-lightbox="project" data-title="Construction Tools (tools, assets)">
                    <img src="images/projects/project5.png" alt="Project 1" class="projectImg">
                </a>
                <div class="projectDetails row m0">
                    <div class="fleft projectIcons btn-group" role="group">
                        <a href="images/projects/project1.png" data-lightbox="project" data-title="Central Hospital (building)" class="btn btn-default"><i class="fa fa-search"></i></a>
                        <a href="#" class="btn btn-default"><i class="fa fa-file-o"></i></a>
                    </div>
                    <div class="fright nameType">
                        <div class="row m0 projectName">بیمارستان مرکزی</div>
                        <div class="row m0 projectType">ساخت و ساز</div>
                    </div>
                </div>
            </div>
            <div class="project mix catOffices">
                <a href="images/projects/project6.png" data-lightbox="project" data-title="Big Trucks on Action (cat, building)">
                    <img src="images/projects/project6.png" alt="Project 1" class="projectImg">
                </a>
                <div class="projectDetails row m0">
                    <div class="fleft projectIcons btn-group" role="group">
                        <a href="images/projects/project1.png" data-lightbox="project" data-title="Central Hospital (building)" class="btn btn-default"><i class="fa fa-search"></i></a>
                        <a href="#" class="btn btn-default"><i class="fa fa-file-o"></i></a>
                    </div>
                    <div class="fright nameType">
                        <div class="row m0 projectName">بیمارستان مرکزی</div>
                        <div class="row m0 projectType">ساخت و ساز</div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!--Projects-->

    <section id="latestPosts" class="row">
        <div class="container">
            <div class="row sectionTitles">
                <h2 class="sectionTitle">آخرین مقالات</h2>
                <div class="sectionSubTitle">جدید ترین ها</div>
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
                <h2 class="sectionTitle whiteTC">استاد کاران برتر</h2>
                <div class="sectionSubTitle whiteTC">از دیددگاه شما</div>
            </div>
            <div class="row">
                <div class="owl-carousel testimonialSlider row m0">
                    <div class="item">
                        <div class="clientPhoto row m0">
                            <img src="images/testimonial/photo.png" alt="">
                        </div>
                        <div class="clientNameTitle row m0">
                            <h4>مجید محمدی</h4>
                        </div>
                        <div class="arrow row m0">
                            <img src="images/testimonial/arrow.png" alt="arrow down" />
                        </div>
                        <div class="testimonial row m0">
                            <div class="testimonial row m0">لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است</div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="clientPhoto row m0">
                            <img src="images/testimonial/photo.png" alt="">
                        </div>
                        <div class="clientNameTitle row m0">
                            <h4>مجید محمدی</h4>
                        </div>
                        <div class="arrow row m0">
                            <img src="images/testimonial/arrow.png" alt="arrow down" />
                        </div>
                        <div class="testimonial row m0">لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است</div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!--Testimonials-->
    <section id="elements" class="row">
        <div class="row sectionTitles m0">
            <h2 class="sectionTitle">Accordion &amp; Tabs</h2>
            <div class="sectionSubTitle">elements</div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-sm-6">
                    <div class="panel-group" id="hAccordion" role="tablist" aria-multiselectable="true">
                        <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="headingOne">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#hAccordion" href="#collapse1" aria-expanded="true" aria-controls="collapse1">
                                        <i class="fa fa-question"></i>Marketplace Basics <span class="sign fa"></span>
                                    </a>
                                </h4>
                            </div>
                            <div id="collapse1" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                                <div class="panel-body">
                                    <div class="fleft icon">
                                        <i class="fa fa-laptop"></i>
                                    </div>
                                    <div class="fleft texts">
                                        Proin gravida nibh vel velit auctor aliquet. Aenean sollicitudin, lorem quis bibendum auctor, nisi elit consequat ipsum, nec sagittis sem nibh id elit. Duis sed odio sit amet nibh vulputate
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!--hAccordion No #1-->
                        <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="heading2">
                                <h4 class="panel-title">
                                    <a class="collapsed" data-toggle="collapse" data-parent="#hAccordion" href="#collapse2" aria-expanded="false" aria-controls="collapse2">
                                        <i class="fa fa-question"></i>Author Resources <span class="sign fa"></span>
                                    </a>
                                </h4>
                            </div>
                            <div id="collapse2" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading2">
                                <div class="panel-body">
                                    <div class="fleft icon">
                                        <i class="fa fa-laptop"></i>
                                    </div>
                                    <div class="fleft texts">
                                        Proin gravida nibh vel velit auctor aliquet. Aenean sollicitudin, lorem quis bibendum auctor, nisi elit consequat ipsum, nec sagittis sem nibh id elit. Duis sed odio sit amet nibh vulputate
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!--hAccordion No #2-->
                        <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="heading3">
                                <h4 class="panel-title">
                                    <a class="collapsed" data-toggle="collapse" data-parent="#hAccordion" href="#collapse3" aria-expanded="false" aria-controls="collapse3">
                                        <i class="fa fa-question"></i>Authoring Rquirements <span class="sign fa"></span>
                                    </a>
                                </h4>
                            </div>
                            <div id="collapse3" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading3">
                                <div class="panel-body">
                                    <div class="fleft icon">
                                        <i class="fa fa-laptop"></i>
                                    </div>
                                    <div class="fleft texts">
                                        Proin gravida nibh vel velit auctor aliquet. Aenean sollicitudin, lorem quis bibendum auctor, nisi elit consequat ipsum, nec sagittis sem nibh id elit. Duis sed odio sit amet nibh vulputate
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!--hAccordion No #3-->
                        <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="heading4">
                                <h4 class="panel-title">
                                    <a class="collapsed" data-toggle="collapse" data-parent="#hAccordion" href="#collapse4" aria-expanded="false" aria-controls="collapse4">
                                        <i class="fa fa-question"></i>Copyright &amp; Legal <span class="sign fa"></span>
                                    </a>
                                </h4>
                            </div>
                            <div id="collapse4" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading4">
                                <div class="panel-body">
                                    <div class="fleft icon">
                                        <i class="fa fa-laptop"></i>
                                    </div>
                                    <div class="fleft texts">
                                        Proin gravida nibh vel velit auctor aliquet. Aenean sollicitudin, lorem quis bibendum auctor, nisi elit consequat ipsum, nec sagittis sem nibh id elit. Duis sed odio sit amet nibh vulputate
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!--hAccordion No #4-->
                        <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="heading5">
                                <h4 class="panel-title">
                                    <a class="collapsed" data-toggle="collapse" data-parent="#hAccordion" href="#collapse5" aria-expanded="false" aria-controls="collapse5">
                                        <i class="fa fa-question"></i>Affiliate Program <span class="sign fa"></span>
                                    </a>
                                </h4>
                            </div>
                            <div id="collapse5" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading5">
                                <div class="panel-body">
                                    <div class="fleft icon">
                                        <i class="fa fa-laptop"></i>
                                    </div>
                                    <div class="fleft texts">
                                        Proin gravida nibh vel velit auctor aliquet. Aenean sollicitudin, lorem quis bibendum auctor, nisi elit consequat ipsum, nec sagittis sem nibh id elit. Duis sed odio sit amet nibh vulputate
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
                                <i class="fa fa-laptop"></i>Responsive Layout
                            </a></li>
                            <li role="presentation"><a href="#h_tab2" aria-controls="h_tab2" role="tab" data-toggle="tab">
                                <i class="fa fa-briefcase"></i>Multiple Portfolios
                            </a></li>
                            <li role="presentation"><a href="#h_tab3" aria-controls="h_tab3" role="tab" data-toggle="tab">
                                <i class="fa fa-youtube-play"></i>Video Support
                            </a></li>
                        </ul>
                        <div class="tab-content">
                            <div role="tabpanel" class="tab-pane active" id="h_tab1">
                                Proin gravida nibh vel velit auctor aliquet. Aenean sollicitudin, lorem quis bibendum auctor, nisi elit consequat ipsum, nec sagittis sem nibh id elit. Duis sed odio sit amet nibh vulputate cursus a sit amet mauris. Morbi accumsan ipsum velit. Nam nec tellus a odio tincidunt auctor a ornare odio. Sed non  mauris vitae erat consequat auctor eu in elit.
                            </div>
                            <div role="tabpanel" class="tab-pane" id="h_tab2">
                                Duis sed odio sit amet nibh vulputate cursus a sit amet mauris. Morbi accumsan ipsum velit. Proin gravida nibh vel velit auctor aliquet. Aenean sollicitudin, lorem quis bibendum auctor, nisi elit consequat ipsum, nec sagittis sem nibh id elit. Nam nec tellus a odio tincidunt auctor a ornare odio. Sed non  mauris vitae erat consequat auctor eu in elit.
                            </div>
                            <div role="tabpanel" class="tab-pane" id="h_tab3">
                                Nam nec tellus a odio tincidunt auctor a ornare odio. Sed non  mauris vitae erat consequat auctor eu in elit. Proin gravida nibh vel velit auctor aliquet. Aenean sollicitudin, lorem quis bibendum auctor, nisi elit consequat ipsum, nec sagittis sem nibh id elit. Duis sed odio sit amet nibh vulputate cursus a sit amet mauris. Morbi accumsan ipsum velit.
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!--Elements-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="map" runat="server">
    <div class="col-xs-10">
        <div class="mapBox">
            <div class="weHere">
                <p>ما اینجا هستیم</p>
            </div>
            <div id="map" style="width: 100%; margin-left: auto; margin-right: auto; height: 350px;"></div>
        </div>
    </div>
</asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/_construction/IndexMaster.Master" AutoEventWireup="true" CodeBehind="BlogPost.aspx.cs" Inherits="WebPages._construction.BlogPost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <section id="pageCover" class="row AddNewsHead">
            <div class="row pageTitle">افزودن خبر</div>
            <div class="row pageBreadcrumbs">
                <ol class="breadcrumb" style="direction: rtl">
                    <li><a href="index.html" style="color: #F7B71E">خانه</a></li>
                    <li><span class="fa fa-arrow-left" style="color: #ffffff" aria-hidden="true"></span></li>
                    <li class="active" style="color: #F7B71E">افزودن خبر</li>
                </ol>
            </div>
        </section>

        <section id="blogs" class="row">
            <div class="container">
                <div class="row">
                    <div class="col-sm-9">
                        <div class="row">
                            <div class="row blog sinlge-blog">
                                <div class="row m0 blogInner">
                                    <div class="row m0 blogDateTime">
                                        <i class="fa fa-calendar"></i>14 November 2014, 10:50 AM
                               
                               
                                    </div>
                                    <div class="row m0 featureImg">
                                        <a href="single-post.html">
                                            <img src="images/projects/project1.png" alt="Faceted Search Has Landed" class="img-responsive">
                                        </a>
                                    </div>
                                    <div class="row m0 postExcerpts">
                                        <div class="row m0 postExcerptInner">
                                            <a href="single-post.html" class="postTitle row m0">
                                                <h4>Faceted Search Has Landed</h4>
                                            </a>
                                            <p>
                                                This is Photoshop's version  of Lorem Ipsum. Proin gravida nibh vel velit auctor aliquet. Aenean sollicitudin, lorem quis bibendum auctor, nisi elit consequat ipsum, nec sagittis sem nibh id elit. Duis sed odio sit amet nibh vulputate cursus a sit amet mauris. Morbi accumsan ipsum velit. Nam nec tellus a odio tincidunt auctor a ornare odio.
                                           
                                           

                                                <br>
                                                <br>
                                                Sed non  mauris vitae erat consequat auctor eu in elit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Mauris in erat justo. Nullam ac urna eu felis dapibus condimentum sit amet a augue. Sed non neque elit. Sed ut imperdiet nisi. Proin condimentum fermentum nunc. Etiam pharetra, erat sed fermentum feugiat, velit mauris egestas quam, ut aliquam massa nisl quis neque. Suspendisse in orci enim.
                                       
                                       
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>


                        </div>
                    </div>
                    <aside class="col-sm-3 sidebar">
                        <div class="row m0 recentPostWidget widgetS">
                            <h4>Recent Posts</h4>
                            <div class="row m0 recentblogs">
                                <div class="media recentblog">
                                    <div class="media-left">
                                        <a href="#">
                                            <img class="media-object" src="images/blog/recent1.png" alt="">
                                        </a>
                                    </div>
                                    <div class="media-body">
                                        <a href="#">
                                            <h5 class="media-heading">This is PhotoShop's version of Lorem Ipsum</h5>
                                        </a>
                                    </div>
                                </div>
                                <div class="media recentblog">
                                    <div class="media-left">
                                        <a href="#">
                                            <img class="media-object" src="images/blog/recent2.png" alt="">
                                        </a>
                                    </div>
                                    <div class="media-body">
                                        <a href="#">
                                            <h5 class="media-heading">This is PhotoShop's version of Lorem Ipsum</h5>
                                        </a>
                                    </div>
                                </div>
                                <div class="media recentblog">
                                    <div class="media-left">
                                        <a href="#">
                                            <img class="media-object" src="images/blog/recent3.png" alt="">
                                        </a>
                                    </div>
                                    <div class="media-body">
                                        <a href="#">
                                            <h5 class="media-heading">This is PhotoShop's version of Lorem Ipsum</h5>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row m0 contactWidget widgetS">
                            <h4>Contact us</h4>
                            <ul class="list-unstyled">
                                <li><i class="fa fa-phone"></i>9930 1234 5678</li>
                                <li><i class="fa fa-envelope"></i>contact@yourdomain.com</li>
                                <li><i class="fa fa-home"></i>street address example</li>
                            </ul>
                        </div>
                        <div class="row m0 textWidget widgetS">
                            <h4>Text Widget</h4>
                            <p>
                                This is Photoshop's version  of Lorem Ipsum. Proin gravida . Aenean sollicitudin, lorem quis bibendum
                           
                           

                                <br>
                                <br>
                                auctor, nisi elit consequat ipsum, nec sagittis sem nibh id
                       
                       
                            </p>
                        </div>
                    </aside>
                </div>
            </div>
        </section>
    </div>

</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>

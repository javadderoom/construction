<%@ Page Title="" Language="C#" MasterPageFile="~/_construction/IndexMaster.Master" AutoEventWireup="true" CodeBehind="ShowProject.aspx.cs" Inherits="WebPages._construction.ShowProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:PlaceHolder ID="MetaPlaceHolder" runat="server" />

    <title runat="server" id="PageTitle"></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageStyles" runat="server">
    <link href="<%=ResolveUrl("../_Styles/BlogPost.css")%>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="direction: rtl;">
        <section id="pageCover" class="row BlogPostHead">
            <div class="row pageTitle" runat="server" id="DivHeadTitle"></div>
        </section>
        <section id="blogs" class="row ">
            <div class="container dady">
                <div class="row ">

                    <aside class="col-sm-3 sidebar  ">
                        <div class="pinned">
                            <div class="row m0 recentPostWidget widgetS ">
                                <h4>پروژه های اخیر</h4>

                                <div id="DivRecenPosts" runat="server" class="row m0 recentblogs">
                                </div>
                            </div>
                            <div class="row m0 contactWidget widgetS">
                                <h4>تماس با ما</h4>
                                <ul class="list-unstyled">
                                    <li><i class="fa fa-phone" style="margin-left: 5px;"></i><span runat="server" id="BlogPhone"></span></li>
                                    <li><i class="fa fa-envelope" style="margin-left: 5px;"></i><span runat="server" id="BlogMail"></span></li>
                                    <li><i class="fa fa-home" style="margin-left: 5px;"></i><span runat="server" id="BlogAddress"></span></li>
                                </ul>
                            </div>
                        </div>
                    </aside>
                    <div class="col-sm-9">
                        <div class="row">
                            <div class="row blog sinlge-blog">
                                <div class="row m0 blogInner">
                                    <div class="row m0 blogDateTime">
                                        <i class="fa fa-calendar"></i><span runat="server" id="DivPostDate"></span>
                                    </div>

                                    <div class="row m0 featureImg">
                                        <a href="single-post.html">
                                            <img src="" runat="server" id="ImageTag" alt="عکس بالایی" class="img-responsive" />
                                        </a>
                                    </div>
                                    <div class="row m0 postExcerpts">
                                        <div class="row m0 postExcerptInner">
                                            <div>
                                                <h4 runat="server" id="DivTitle"></h4>
                                            </div>
                                            <div runat="server" id="DivBody">
                                            </div>

                                            <div runat="server" id="DivTags">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="Scripts" runat="server">
    <script>

        $('.active').removeClass('active');
        $('.Projects').addClass('active');

        $("#ContentPlaceHolder1_DivBody").find("img").addClass("img-responsive");
    </script>
</asp:Content>

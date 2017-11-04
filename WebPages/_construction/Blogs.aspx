<%@ Page Title="" Language="C#" MasterPageFile="~/_construction/IndexMaster.Master" AutoEventWireup="true" CodeBehind="Blogs.aspx.cs" Inherits="WebPages._construction.Blogs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>وبلاگ ها</title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="pageStyles" runat="server">
    <link href="../_Styles/Blogs.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section id="pageCover" class="row blogPage">

        <div class="row pageTitle">مقاله ها</div>
        <div class="row pageBreadcrumbs">
            <ol class="breadcrumb" style="direction: rtl">
                <li><a href="/" style="color: #F7B71E">خانه</a></li>
                <li><span class="fa fa-arrow-left" style="color: #ffffff" aria-hidden="true"></span></li>
                <li class="active" style="color: #F7B71E">مقاله ها</li>
            </ol>
        </div>
    </section>

    <section id="blogs" class="row">
        <div class="container" style="text-align: right">
            <div class="filters">
                <label class="filtersLable" for="ddlGroups">فیلتر ها : </label>
                <div id="divDDL" class="ddlContainer">
                    <div>
                        <label for="ddlGroups">گروه اصلی : </label>
                        <asp:DropDownList ID="ddlGroups" class="DDLClass" AutoPostBack="true" OnSelectedIndexChanged="ddlGroups_SelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                    <div>
                        <label>زیر گروه : </label>
                        <asp:UpdatePanel ID="updatepanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlSubGroups" OnSelectedIndexChanged="ddlSubGroups_SelectedIndexChanged" AutoPostBack="true" CssClass="DDLClass" runat="server"></asp:DropDownList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlGroups" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>

            <asp:UpdatePanel ID="updatepanel5" ChildrenAsTriggers="false" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
                    <div class="row" id="easyPaginate">
                        <ul runat="server" id="UlArticles">
                        </ul>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlGroups" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="ddlSubGroups" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Scripts" runat="server">
    <script src="../_Scripts/jquery.easyPaginate.js"></script>
    <script src="../_Scripts/BlogsScript.js"></script>
    <script>
        $('.active').removeClass('active');
        $('.Blogs').addClass('active');
    </script>
</asp:Content>

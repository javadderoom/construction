<%@ Page Title="" Language="C#" MasterPageFile="~/_construction/IndexMaster.Master" AutoEventWireup="true" CodeBehind="Projects.aspx.cs" Inherits="WebPages._construction.Projects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="pageStyles" runat="server">
    <link href="../_Styles/Blogs.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:scriptmanager id="ScriptManager1" runat="server"></asp:scriptmanager>
    <section id="pageCover" class="row blogPage">

        <div class="row pageTitle">مقاله ها</div>
        <div class="row pageBreadcrumbs">
            <ol class="breadcrumb" style="direction: rtl">
                <li><a href="index.html" style="color: #F7B71E">خانه</a></li>
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
                        <asp:dropdownlist id="ddlGroups" class="DDLClass" autopostback="true" onselectedindexchanged="ddlGroups_SelectedIndexChanged" runat="server"></asp:dropdownlist>
                    </div>
                    <div>
                        <asp:updatepanel id="updatepanel1" runat="server" childrenastriggers="true" updatemode="Conditional">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlSubGroups" OnSelectedIndexChanged="ddlSubGroups_SelectedIndexChanged" AutoPostBack="true" CssClass="DDLClass" runat="server"></asp:DropDownList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlGroups" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:updatepanel>
                    </div>
                </div>
            </div>

            <asp:updatepanel id="updatepanel5" childrenastriggers="false" updatemode="Conditional" runat="server">
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
            </asp:updatepanel>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Scripts" runat="server">
    <script src="../_Scripts/jquery.easyPaginate.js"></script>
    <script src="../_Scripts/BlogsScript.js"></script>
</asp:Content>
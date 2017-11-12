<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/Admin/NewAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageProjects.aspx.cs" Inherits="WebPages.Panels.Admin.ManageProjects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>مدیریت پروژه ها</title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageStyle" runat="server">
    <link href="../../_Styles/GridView.css" rel="stylesheet" />
    <link href="../../_Styles/ManageBlogs.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="container">
        <div class="InnerContainer">
            <div>
                <h2>مدیریت پروژه ها : </h2>
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
                            <asp:UpdateProgress ID="updateProgress1" runat="server" DisplayAfter="0">
                                <ProgressTemplate>
                                    <div style="position: fixed; text-align: center; height: 100%; padding-top: 100px; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #ffffff; opacity: 0.8;">
                                        <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/_construction/images/44frgm.gif" AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; top: 45%; left: 50%;" />
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="updatepanel3" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div runat="server" id="diverror">
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlGroups" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="ddlSubGroups" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="gvPosts" EventName="RowCommand" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <asp:UpdateProgress ID="updateProgress2" runat="server" DisplayAfter="0">
                        <ProgressTemplate>
                            <div style="position: fixed; text-align: center; height: 100%; padding-top: 100px; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #ffffff; opacity: 0.8;">
                                <asp:Image ID="imgUpdateProgress2" runat="server" ImageUrl="~/_construction/images/44frgm.gif" AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; top: 45%; left: 50%;" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </div>
                <asp:UpdatePanel ID="updatepanel2" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                    <ContentTemplate>

                        <div id="gvContainer" runat="server">
                            <asp:GridView ID="gvPosts" runat="server"
                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal"
                                AutoGenerateColumns="False" CssClass="dirRight table " HorizontalAlign="Center"
                                AllowCustomPaging="False" AllowPaging="True"
                                OnRowCommand="gvPosts_RowCommand" OnPageIndexChanging="gvPosts_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="ProjectID" HeaderText="شناسه" />
                                    <asp:BoundField DataField="Title" HeaderText="عنوان" />
                                    <asp:BoundField DataField="PostDateTime" HeaderText="تاریخ و زمان" />

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="Show" runat="server"
                                                CommandName="Show"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                Text="نمایش" />
                                            <asp:Button ID="Edid" runat="server"
                                                CommandName="Edit"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                Text="ویرایش" />

                                            <asp:Button OnClientClick="if(!confirm('ایا برای حذف مطمئن هستید؟')) return false;" ID="Delet" runat="server"
                                                CommandName="Delet"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                Text="حذف" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <PagerStyle HorizontalAlign="center" CssClass="GridPager" />
                                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                <SortedDescendingHeaderStyle BackColor="#242121" />
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlGroups" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlSubGroups" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="gvPosts" EventName="RowCommand" />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:UpdateProgress ID="updateProgress3" runat="server" DisplayAfter="0">
                    <ProgressTemplate>
                        <div style="position: fixed; text-align: center; height: 100%; padding-top: 100px; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #ffffff; opacity: 0.8;">
                            <asp:Image ID="imgUpdateProgress3" runat="server" ImageUrl="~/_construction/images/44frgm.gif" AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; top: 45%; left: 50%;" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Script" runat="server">
</asp:Content>
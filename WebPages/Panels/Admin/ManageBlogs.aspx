<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/Admin/NewAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageBlogs.aspx.cs" Inherits="WebPages.Panels.Admin.ManageBlogs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                <h2>مدیریت پست ها : </h2>
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
                                    <asp:BoundField DataField="ArticleID" HeaderText="شناسه" />
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
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Script" runat="server">
</asp:Content>
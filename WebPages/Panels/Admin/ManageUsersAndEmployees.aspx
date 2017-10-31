<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/Admin/NewAdminMaster.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="ManageUsersAndEmployees.aspx.cs" Inherits="WebPages.Panels.Admin.ManageUsersAndEmployees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>مدیریت کاربر ها و کارمند ها
    </title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageStyle" runat="server">
    <link href="../../_Styles/ManageGroups.css" rel="stylesheet" />
    <link href="../../_Styles/GridView.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <div style="direction: rtl; padding: 28px 7% 20px 7%; margin-bottom: 20px;">

        <div class="col-md-4 col-xs-12 text-righ" style="float: right; height: 100px">
            <div class="input-group">
                <span class="input-group-btn">
                    <button type="button" id="btnSearch" class="btn btn-primary" runat="server" onserverclick="btnSearch_ServerClick">
                        جستجو
                    </button>
                </span>

                <div id="ContentPlaceHolder1_upSearch">

                    <input name="ctl00$ContentPlaceHolder1$tbxnameSearch" style="height: 38px" runat="server" placeholder="متن جستجو" type="text" maxlength="50" id="tbxSearch" class="form-control text-right dirRight pull-right" />
                </div>
            </div>
        </div>
        <div class="c-title" style="display: block; clear: right">
            <h3>

                <asp:Literal runat="server" Text="لیست کاربران و کامندان" /></h3>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div id="ContentPlaceHolder1_upGrid">
            <div style="float: right; overflow-x: auto; width: 100%; }">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

                        <asp:GridView ID="gvUsers" runat="server" BackColor="White" BorderColor="#CCCCCC"
                            BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                            GridLines="Horizontal" AutoGenerateColumns="False" CssClass="dirRight table"
                            HorizontalAlign="Center" OnRowDataBound="gvUsers_RowDataBound" OnPageIndexChanging="gvUsers_PageIndexChanging" AllowCustomPaging="False"
                            AllowPaging="True" OnRowCommand="gvUsers_RowCommand" PageSize="20">
                            <Columns>

                                <asp:BoundField DataField="UserID" HeaderText="شناسه" />
                                <asp:BoundField DataField="UserName" HeaderText="نام کاربری" />
                                <asp:BoundField DataField="RegSeen" HeaderText="RegSeen" />
                                <asp:BoundField DataField="FullName" HeaderText="نام" />
                                <asp:BoundField DataField="Mobile" HeaderText="شماره تلفن" />
                                <asp:BoundField DataField="fullAddress" HeaderText="آدرس" />
                                <asp:BoundField DataField="urole" HeaderText="نقش" />

                                <asp:TemplateField>
                                    <ItemTemplate>

                                        <asp:Label ID="Label1" ForeColor="Green" Width="150" runat="server" Text='<%# ((Eval("RegSeen").ToString() == "False") ? "کاربر جدید" :"") %>'></asp:Label>
                                        <asp:Button ID="Details" runat="server"
                                            CommandName="view"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                            Text="مشاهده جزئیات" Width="100" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerSettings Mode="NumericFirstLast"
                                NextPageText="بعدی"
                                LastPageText="انتها"
                                FirstPageText="ابتدا"
                                PreviousPageText="قبلی"
                                PageButtonCount="2"
                                Position="Bottom" />
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <PagerStyle HorizontalAlign="center" CssClass="GridPager" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-5 col-md-push-7 col-xs-6 col-xs-push-6">
                <button type="button" id="btnViewAll" class="btn btn-auto-h btn-info goRight" runat="server" style="margin-right: 5px; display: block" onserverclick="btnViewAll_ServerClick">
                    <asp:Literal runat="server" Text="مشاهده تمام کاربران" />
                    <span class="fa fa-list"></span>
                </button>
            </div>
        </div>
        <div class="extra"></div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Script" runat="server">
</asp:Content>
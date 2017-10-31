<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/Admin/NewAdminMaster.Master" AutoEventWireup="true" CodeBehind="Scores.aspx.cs" Inherits="WebPages.Panels.Admin.Scores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PageStyle" runat="server">
    <style>
        .myContainer {
            padding: 30px 100px;
        }

        .title {
            text-align: right;
            margin-bottom: 15px;
        }

        #Content_btnSearch {
            height: 38px;
        }

        @media (max-width: 414px) {
            .myContainer {
                padding: 30px 10px;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <div class="myContainer">
        <div class="row">
            <div class="col-md-12 title">
                <h3>لیست کارمندان</h3>
            </div>
        </div>
        <div class="col-md-4 col-xs-12 text-righ" style="float: right; height: 100px">
            <div class="input-group">
                <span class="input-group-btn">
                    <button type="button" id="btnSearch" class="btn btn-primary" runat="server">
                        جستجو
                    </button>
                </span>

                <div id="ContentPlaceHolder1_upSearch">

                    <input name="ctl00$ContentPlaceHolder1$tbxnameSearch" style="height: 38px" runat="server" placeholder="متن جستجو" type="text" maxlength="50" id="tbxSearch" class="form-control text-right dirRight pull-right" />
                </div>
            </div>
        </div>
        <div class="row">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="gvEmployees" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4"
                        ForeColor="Black" GridLines="Horizontal" AllowPaging="True">
                        <Columns>

                            <asp:BoundField DataField="UserID" HeaderText="شناسه" />
                            <asp:BoundField DataField="UserName" HeaderText="نام کاربری" />

                            <asp:BoundField DataField="FullName" HeaderText="نام" />
                            <asp:BoundField DataField="Mobile" HeaderText="شماره تلفن" />
                            <asp:BoundField DataField="fullAddress" HeaderText="آدرس" />

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
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
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
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Script" runat="server">
</asp:Content>
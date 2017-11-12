<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/Admin/NewAdminMaster.Master" AutoEventWireup="true" CodeBehind="MessageInboxAdmin.aspx.cs" Inherits="WebPages.Panels.Admin.MessageInboxAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>صندوق پیام ها</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="bigDiv">
        <div class="c-title">
            <h4>

                <asp:Literal runat="server" Text="لیست گفتگو ها" /></h4>
        </div>

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

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="ContentPlaceHolder1_upGrid">
            <div style="overflow-x: auto; overflow-x: auto; width: 100%;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

                        <asp:GridView ID="gvChats" runat="server" BackColor="White" BorderColor="#CCCCCC"
                            BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                            GridLines="Horizontal" AutoGenerateColumns="False" CssClass="dirRight table"
                            HorizontalAlign="Center" OnRowDataBound="gvChats_RowDataBound" AllowCustomPaging="False"
                            AllowPaging="True" OnRowCommand="gvChats_RowCommand" OnPageIndexChanging="gvChats_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="ChatID" HeaderText="شناسه" />
                                <asp:BoundField DataField="UserID" HeaderText="id" />
                                <asp:BoundField DataField="UserName" HeaderText="نام کاربری" />
                                <asp:BoundField DataField="FullName" HeaderText="نام و نام خانوادگی" />
                                <asp:BoundField DataField="urole" HeaderText="نوع کاربر" />
                                <asp:BoundField DataField="ChatTitle" HeaderText="عنوان صندوق پیام" />
                                <asp:BoundField DataField="lastMsg" HeaderText="آخرین پیام" />
                                <asp:BoundField DataField="seen" HeaderText="seen" />
                                <asp:BoundField DataField="lastMsgTime" HeaderText="تاریخ و ساعت آخرین پیام" />

                                <asp:TemplateField>
                                    <ItemTemplate>

                                        <asp:Image ID="imgSeen" runat="server" ImageUrl='<%# "~/img/" + ((Eval("seen").ToString() == "1") ? "notSeenMsg.png" : "seenMsg.png") %>' />
                                        <asp:Button ID="Details" runat="server"
                                            CommandName="view"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                            Text="مشاهده کفتگو" Width="100" />
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
                    </ContentTemplate>
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
        <br />
        <div class="row">
            <div class="col-md-5 col-md-push-7 col-xs-6 col-xs-push-6">
                <button type="button" id="btnViewAll" class="btn btn-auto-h btn-info goRight" runat="server" style="margin-right: 5px; display: block" onserverclick="btnViewAll_ServerClick">
                    <asp:Literal runat="server" Text="مشاهده تمام گفتگوها" />
                    <span class="fa fa-list"></span>
                </button>
            </div>
        </div>
        <div class="extra"></div>
    </div>
</asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/UserPanel/UsersMaster.Master" AutoEventWireup="true" CodeBehind="MessageInbox.aspx.cs" Inherits="WebPages.Panels.UserPanel.MessageInbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageStyles" runat="server">
    <link href="../../_Styles/GridView.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="direction: rtl; padding: 28px 7% 20px 7%; margin-bottom: 20px;">
        <div class="c-title" style="margin-bottom: 20px; font-size: 16px; font-weight: bold">
            <h3>

                <asp:Literal runat="server" Text="لیست گفتگو ها" />
            </h3>
        </div>

        <div class="col-md-4 col-xs-12 text-righ" style="float: right; height: 64px">
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
            <div style="overflow-x: auto; width: 100%;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

                        <asp:GridView ID="gvChats" runat="server" BackColor="White" BorderColor="#CCCCCC"
                            BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                            GridLines="Horizontal" AutoGenerateColumns="False" CssClass="dirRight table"
                            HorizontalAlign="Center" OnRowDataBound="gvChats_RowDataBound" AllowCustomPaging="False"
                            AllowPaging="True" OnRowCommand="gvChats_RowCommand" OnPageIndexChanging="gvChats_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="ChatID" HeaderText="شناسه" />
                                <asp:BoundField DataField="ChatTitle" ItemStyle-Width="30%" HeaderText="عنوان صندوق پیام" />
                                <asp:BoundField DataField="lastMsgText" ItemStyle-Width="30%" HeaderText="آخرین پیام" />
                                <asp:BoundField DataField="seen" HeaderText="seen" />
                                <asp:BoundField DataField="lastMsgDate" HeaderText="تاریخ و ساعت آخرین پیام" />

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
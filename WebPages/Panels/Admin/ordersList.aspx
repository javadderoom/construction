<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/Admin/NewAdminMaster.Master" AutoEventWireup="true" CodeBehind="ordersList.aspx.cs" Inherits="WebPages.Panels.Admin.ordersList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>لیست سفارشات</title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageStyle" runat="server">
    <link href="../../_Styles/ProjectDetailStyles.css" rel="stylesheet" />
    <link href="../../_Styles/Input&Lable.css" rel="stylesheet" />
    <link href="../../_Styles/GridView.css" rel="stylesheet" />
    <style>
        div#container {
            min-height: 500px;
        }

        .InnerContainer {
            min-height: 300px;
            width: 100%;
            box-shadow: 5px 4px 10px #858585;
            padding: 1px 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <div id="container">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="InnerContainer">

            <div style="overflow-x: auto; width: 100%;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvChats" runat="server" BackColor="White" BorderColor="#CCCCCC"
                            BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                            GridLines="Horizontal" AutoGenerateColumns="False" CssClass="dirToLeft table grid "
                            HorizontalAlign="Center" OnPageIndexChanging="gvChats_PageIndexChanging" OnRowDataBound="gvChats_RowDataBound" AllowCustomPaging="False"
                            AllowPaging="True" OnRowCommand="gvChats_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="OrderID" HeaderText="شناسه" />
                                <asp:BoundField DataField="fullName" HeaderText="نام" />
                                <asp:BoundField DataField="Title" HeaderText="عنوان سفارش" />
                                <asp:BoundField DataField="FullAdd" HeaderText="شهر و استان" />
                                <asp:BoundField DataField="Budget" HeaderText="بودجه" />
                                <asp:BoundField DataField="IsSeen" HeaderText="IsSeen" />

                                <asp:TemplateField>

                                    <ItemTemplate>
                                        <asp:Label ID="lblSeen" runat="server" ForeColor="Green" Text='<%# (((Eval("IsSeen").ToString() == "False")) ? "سفارش جدید" : "")  %>'></asp:Label>
                                        <asp:Button ID="Details" runat="server"
                                            CommandName="view"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                            Text="مشاهده جزییات" Width="100" />
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
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Script" runat="server">
</asp:Content>
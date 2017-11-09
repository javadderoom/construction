<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/Admin/NewAdminMaster.Master" AutoEventWireup="true" CodeBehind="ordersList.aspx.cs" Inherits="WebPages.Panels.Admin.ordersList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>لیست سفارشات</title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageStyle" runat="server">
    <link href="../../_Styles/ProjectDetailStyles.css" rel="stylesheet" />
    <link href="../../_Styles/Input&Lable.css" rel="stylesheet" />
    <link href="../../_Styles/GridView.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <div class="bigDiv">
        <asp:GridView ID="gvChats" runat="server" BackColor="White" BorderColor="#CCCCCC"
            BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
            GridLines="Horizontal" AutoGenerateColumns="False" CssClass="dirToLeft table grid "
            HorizontalAlign="Center" OnRowDataBound="gvChats_RowDataBound" AllowCustomPaging="True"
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
                        <asp:Label ID="lblSeen" runat="server" Text='<%#  %>'></asp:Label>
                    </ItemTemplate>
                    <ItemTemplate>
                        <asp:Button ID="Details" runat="server"
                            CommandName="view"
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                            Text="مشاهده جزییات" Width="100" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Script" runat="server">
</asp:Content>

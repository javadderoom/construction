<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/Admin/NewAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageFirstPage.aspx.cs" Inherits="WebPages.Panels.Admin.ManageFirstPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PageStyle" runat="server">
    <link href="../../_Styles/ManageFirstPage.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <div id="container">
        <div class="InnerContainer">
            <h3>اسلایدر ها : </h3>

            <div id="gvContainer">
                <asp:GridView ID="gvSlider" runat="server"
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                    BorderWidth="1px" CellPadding="4" Width="250px" ForeColor="Black" GridLines="Horizontal"
                    AutoGenerateColumns="False" CssClass="dirRight table " HorizontalAlign="Center"
                    AllowCustomPaging="True" AllowPaging="True"
                    OnRowCommand="gvSlider_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="SlideID" HeaderText="شناسه" />
                        <asp:TemplateField>
                            <ItemTemplate>

                                <asp:Button ID="Edid" runat="server"
                                    CommandName="EditRow"
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                    Text="ویرایش" />
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
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Script" runat="server">
</asp:Content>


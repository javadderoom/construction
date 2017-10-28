<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/Admin/NewAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageFirstPage.aspx.cs" Inherits="WebPages.Panels.Admin.ManageFirstPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PageStyle" runat="server">
    <link href="../../_Styles/ManageFirstPage.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="container">
        <div class="InnerContainer">
            <h3>اسلایدر ها : </h3>

            <div id="gvContainer" style="overflow-x: auto">
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

            <hr style="margin-top: 20px; margin-bottom: 20px" />
            <h3>راه های ارتباطی : </h3>
            <div style="padding-right: 25px;">
                <asp:UpdatePanel ID="updatepanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="form-group">

                            <label for="tbxPhone">شماره تماس :</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" SetFocusOnError="true" ControlToValidate="tbxPhone" runat="server" CssClass="error" ErrorMessage="شماره تماس نمیتواند خالی باشد!"></asp:RequiredFieldValidator>

                            <asp:TextBox ID="tbxPhone" onkeydown="return (event.keyCode!=13);" Style="max-width: 500px; height: 40px;" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">

                            <label for="tbxAdress">آدرس :</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" SetFocusOnError="true" ControlToValidate="tbxAdress" runat="server" CssClass="error" ErrorMessage="آدرس نمیتواند خالی باشد!"></asp:RequiredFieldValidator>

                            <asp:TextBox ID="tbxAdress" onkeydown="return (event.keyCode!=13);" Style="max-width: 500px; height: 40px;" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">

                            <label for="tbxMail">ایمیل :</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" SetFocusOnError="true" ControlToValidate="tbxMail" runat="server" CssClass="error" ErrorMessage="ایمیل نمیتواند خالی باشد!"></asp:RequiredFieldValidator>

                            <asp:TextBox ID="tbxMail" onkeydown="return (event.keyCode!=13);" Style="max-width: 500px; height: 40px;" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">

                            <label for="tbxAbout">متن پایین صفحه :</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" SetFocusOnError="true" ControlToValidate="tbxAbout" runat="server" CssClass="error" ErrorMessage="درباره ما نمیتواند خالی باشد!"></asp:RequiredFieldValidator>

                            <asp:TextBox ID="tbxAbout" Style="max-width: 500px;" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>

                <div style="text-align: center; margin: 20px 0">
                    <asp:Button ID="btnSave" OnClick="btnSave_Click" CssClass=" btn btn-success middle_yellow" runat="server" Text="ذخیره" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Script" runat="server">
</asp:Content>
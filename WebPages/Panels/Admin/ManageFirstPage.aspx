<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/Admin/NewAdminMaster.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="ManageFirstPage.aspx.cs" Inherits="WebPages.Panels.Admin.ManageFirstPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>مدیریت صفحه اول</title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PageStyle" runat="server">
    <link href="../../_Styles/ManageFirstPage.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="container">
        <div class="InnerContainer">
            <h3>اسلایدر ها : </h3>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div id="gvContainer" style="overflow-x: auto">
                        <asp:GridView ID="gvSlider" runat="server"
                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                            BorderWidth="1px" CellPadding="4" Width="250px" ForeColor="Black" GridLines="Horizontal"
                            AutoGenerateColumns="False" CssClass="dirRight table " HorizontalAlign="Center"
                            AllowCustomPaging="False" AllowPaging="True"
                            OnRowCommand="gvSlider_RowCommand" OnPageIndexChanging="gvSlider_PageIndexChanging">
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
                            <PagerStyle HorizontalAlign="center" CssClass="GridPager" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />
                        </asp:GridView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <hr style="margin-top: 20px; margin-bottom: 20px" />
            <h3>راه های ارتباطی : </h3>
            <div style="padding-right: 25px;">

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
                <div class="form-group">

                    <label for="tbxAboutPage">متن صفحه درباره ما :</label>

                    <asp:TextBox ID="tbxAboutPage" Style="max-width: 500px;" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">

                    <label for="tbxAboutPage">لوگو :</label>

                    <label class="btn btn-info" style="width: 100px;">
                        <asp:Literal runat="server" Text="انتخاب عکس" />

                        <asp:FileUpload ID="FileUpload1" CssClass="displaynone" BackColor="#CCCCCC" runat="server" />
                    </label>
                    <label id="filename"></label>
                </div>
                <div class="form-group">

                    <label for="tele">تلگرام :</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" SetFocusOnError="true" ControlToValidate="tbxtele" runat="server" CssClass="error" ErrorMessage="ایمیل نمیتواند خالی باشد!"></asp:RequiredFieldValidator>

                    <asp:TextBox ID="tbxtele" Style="max-width: 500px; height: 40px;" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">

                    <label for="tbxInsta">اینستاگرام :</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Display="Dynamic" SetFocusOnError="true" ControlToValidate="tbxInsta" runat="server" CssClass="error" ErrorMessage="ایمیل نمیتواند خالی باشد!"></asp:RequiredFieldValidator>

                    <asp:TextBox ID="tbxInsta" Style="max-width: 500px; height: 40px;" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div style="text-align: center; margin: 20px 0">
                    <asp:Button ID="btnSave" OnClick="btnSave_Click" CssClass=" btn btn-success middle_yellow" runat="server" Text="ذخیره" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Script" runat="server">
    <script>

        CKEDITOR.replace('Content_tbxAboutPage', {
            toolbar: [

            { name: 'basicstyles', items: ['Bold', 'Italic', ] },
            { name: 'paragraph', items: ['NumberedList', 'BulletedList', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'BidiLtr', 'BidiRtl'] },

            { name: 'styles', items: ['Format', 'Font', 'FontSize'] },
            { name: 'colors', items: ['TextColor', 'BGColor'] },

            ],
            language: 'fa', resize_maxWidth: '400',
            contentsLangDirection: 'rtl',
            toolbarDirection: 'rtl',
            resize_maxHeight: '400'
        });

        $(document).on('click', '#Content_btnSave', function (e) {

            var messageLength = CKEDITOR.instances['Content_tbxAboutPage'].getData().replace(/<[^>]*>/gi, '').length;
            if (!messageLength) {
                alert('شما هیچ متنی وارد نکرده اید!');

                e.preventDefault();
                return false;
            }

        });
        $('#Content_FileUpload1').change(function () {
            var filename = $(this).val();
            var lastIndex = filename.lastIndexOf("\\");
            if (lastIndex >= 0) {
                filename = filename.substring(lastIndex + 1);
            }
            $('#filename').html(filename);
        });
    </script>
</asp:Content>
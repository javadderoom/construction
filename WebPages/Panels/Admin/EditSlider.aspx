<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/Admin/NewAdminMaster.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="EditSlider.aspx.cs" Inherits="WebPages.Panels.Admin.AddSlider" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageStyle" runat="server">
    <link href="../../_Styles/EditSlider.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <div id="container">
        <div class="InnerContainer" style="padding-bottom: 40px">
            <h3>ویرایش اسلایدر : </h3>
            <div class="form-group text-right input-group" style="margin-top: 20px;">
                <label style="display: block" for="Abstract">عکس پس زمینه فعلی : </label>

                <div style="max-width: 200px; max-height: 200px;">
                    <img src="" runat="server" id="oldBimg" class="img-responsive" />
                </div>

            </div>
            <div class="form-group text-right input-group" style="margin-top: 20px;">
                <label style="display: block" for="Abstract">عکس پس زمینه جدید : </label>
                <label class="btn btn-info" style="width: 100px;">
                    <asp:Literal runat="server" Text="انتخاب عکس" />


                    <asp:FileUpload ID="FileUpload1" runat="server" accept="image/*" CssClass="displaynone" BackColor="#CCCCCC" />

                </label>
                <label style="padding: 18px" id="filename"></label>

            </div>

            <hr />

            <div class="form-group text-right input-group" style="margin-top: 20px;">
                <label style="display: block" for="Abstract">عکس سمت راست فعلی : </label>

                <div style="max-width: 200px; max-height: 200px; color: red" runat="server" id="Rimg">
                </div>

            </div>
            <div class="form-group text-right input-group" style="margin-top: 20px;">
                <label style="display: block" for="Abstract">عکس سمت راست(اختیاری) : </label>
                <div>
                    بدون عکس؟ :   
                <asp:CheckBox ID="CheckBox1" runat="server" />
                </div>

                <label class="btn btn-info" style="width: 100px;">
                    <asp:Literal runat="server" Text="انتخاب عکس" />


                    <asp:FileUpload ID="FileUpload2" runat="server" accept="image/*" CssClass="displaynone" BackColor="#CCCCCC" />

                </label>
                <label style="padding: 18px" id="filename2"></label>

            </div>
            <hr />

            <div class="form-group" style="margin-top: 20px; max-width: 500px">
                <label for="text">متن سمت راست : </label>
                <asp:TextBox ID="text" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
            </div>
            <hr />
            <div class="form-group" style="margin-top: 20px; margin-bottom: 20px; max-width: 500px">
                <label for="tbxLink">لینک (اختیاری) : </label>
                <asp:TextBox ID="tbxLink" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div style="text-align: center">
                <asp:Button ID="btnSave" OnClick="btnSave_Click" CssClass="btn btn-success" runat="server" Text="ثبت" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Script" runat="server">
    <script>


        CKEDITOR.replace('Content_text', {
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
        $('#Content_FileUpload1').change(function () {
            var filename = $(this).val();
            var lastIndex = filename.lastIndexOf("\\");
            if (lastIndex >= 0) {
                filename = filename.substring(lastIndex + 1);
            }
            $('#filename').html(filename);
        });
        $('#Content_FileUpload2').change(function () {
            var filename = $(this).val();
            var lastIndex = filename.lastIndexOf("\\");
            if (lastIndex >= 0) {
                filename = filename.substring(lastIndex + 1);
            }
            $('#filename2').html(filename);
        });
        $(document).on('click', '#Content_btnSave', function (e) {



            var messageLength = CKEDITOR.instances['Content_text'].getData().replace(/<[^>]*>/gi, '').length;
            if (!messageLength) {
                alert('شما هیچ متنی وارد نکرده اید!');

                e.preventDefault();
                return false;
            }




        });
    </script>
</asp:Content>

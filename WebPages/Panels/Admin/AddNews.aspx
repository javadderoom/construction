<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/Admin/NewAdminMaster.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="AddNews.aspx.cs" Inherits="WebPages.Panels.Admin.AddNews1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section id="pageCover" class="row AddNewsHead">
        <div class="row pageTitle">افزودن خبر</div>
        <div class="row pageBreadcrumbs">
            <ol class="breadcrumb" style="direction: rtl">
                <li><a href="index.html" style="color: #F7B71E">خانه</a></li>
                <span class="fa fa-arrow-left" style="color: #ffffff" aria-hidden="true"></span>
                <li class="active" style="color: #F7B71E">افزودن خبر</li>
            </ol>
        </div>
    </section>
    <div id="container">

        <div class="form-group">

            <label for="title">عنوان :</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="title" runat="server" CssClass="error" ErrorMessage="عنوان نمیتواند خالی باشد!"></asp:RequiredFieldValidator>

            <asp:TextBox ID="title" onkeydown="return (event.keyCode!=13);" Style="max-width: 500px; height: 40px;" placeholder="عنوان باید کوتاه و مفید باشد" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="Abstract">توضیح کوتاه : </label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Abstract" runat="server" CssClass="error" ErrorMessage="توضیح کوتاه نمیتواند خالی باشد!"></asp:RequiredFieldValidator>

            <asp:TextBox ID="Abstract" Style="max-width: 500px; height: 85px;" placeholder="تعداد کلمات پیشنهادی 160 عدد میباشد" Rows="5" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="DDLGroups">گروه کاری : </label>
            <asp:DropDownList ID="DDLGroups" OnSelectedIndexChanged="DDLGroups_SelectedIndexChanged" AutoPostBack="true" CssClass="DDLClass" runat="server"></asp:DropDownList>
        </div>
        <div class="form-group">
            <label>زیر گروه : </label>
            <div>

                <div class="Displayinline" id="upPan1">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:ListBox ID="SubGroups" CssClass="LBXClass" runat="server"></asp:ListBox>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DDLGroups" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="RemoveFromSub" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="AddToSub" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>

                </div>
                <div style="display: inline;">

                    <table style='width: 70px; display: inline'>
                        <tr>

                            <td style='width: 50px; text-align: center; vertical-align: middle;'>
                                <asp:Button ID="AddToSub" Width="50px" OnClick="AddToSub_Click" CausesValidation="False" runat="server" Text=">>" />
                                <br />
                                <br />
                                <asp:Button ID="RemoveFromSub" Width="50px" OnClick="RemoveFromSub_Click" CausesValidation="False" runat="server" Text="<<" />
                            </td>
                        </tr>
                    </table>

                </div>

                <div style="display: inline" id="upPan2">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:ListBox ID="SelectedSubGroups" CssClass="LBXClass" runat="server"></asp:ListBox>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="AddToSub" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="RemoveFromSub" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>

                </div>
            </div>

        </div>
        <div style="max-height: 870px">

            <asp:TextBox runat="server" ID="editor1" TextMode="MultiLine"></asp:TextBox>

        </div>
        <div class="form-group" style="margin-top: 20px">
            <label for="KeyWords">کلمات کلیدی:</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="KeyWords" runat="server" CssClass="error" ErrorMessage="کلمات کلیدی نمیتواند خالی باشد!"></asp:RequiredFieldValidator>

            <asp:TextBox ID="KeyWords" Style="max-width: 500px; height: 40px;" placeholder="چند کلمه کلیدی وارد کنید" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Tags">برچسب ها:</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="Tags" runat="server" CssClass="error" ErrorMessage="برچسب ها نمیتواند خالی باشد!"></asp:RequiredFieldValidator>

            <asp:TextBox ID="Tags" data-role="tagsinput" Style="max-width: 500px; height: 85px;" placeholder="برچسب ها باید جملاتی کوتاه باشند" Rows="5" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="row">
            <div class="col-md-5"></div>
            <div class="col-md-2">
                <asp:Button ID="Save" runat="server" OnClick="Save_Click" CssClass="btn btn-success" Text="ذخیره" />
            </div>
            <div class="col-md-5"></div>
        </div>
    </div>

    <script>

        var roxyFileman = '../../fileman/index.html';
        // Replace the <textarea id="editor1"> with a CKEditor
        // instance, using default configuration.
        CKEDITOR.replace('ContentPlaceHolder1_editor1', {
            toolbar: [
            { name: 'document', items: ['Save', 'NewPage', 'Preview', 'Print', '-', 'Templates'] },
            { name: 'clipboard', items: ['Cut', 'Copy', 'Paste', 'PasteText', '-', 'Undo', 'Redo'] },
            { name: 'editing', items: ['Find', 'Replace', '-', 'SelectAll', '-'] },
             '/',
            { name: 'basicstyles', items: ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript', '-', 'CopyFormatting', 'RemoveFormat'] },
            { name: 'paragraph', items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'BidiLtr', 'BidiRtl'] },
            { name: 'links', items: ['Link', 'Unlink', 'Anchor'] },
            { name: 'insert', items: ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak'] },
            '/',
            { name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] },
            { name: 'colors', items: ['TextColor', 'BGColor'] },
            { name: 'tools', items: ['Maximize'] }
            ],
            language: 'fa',
            contentsLangDirection: 'rtl',
            toolbarDirection: 'rtl',
            filebrowserBrowseUrl: roxyFileman,
            filebrowserImageBrowseUrl: roxyFileman + '?type=image',
            removeDialogTabs: 'link:upload;image:upload', resize_maxHeight: '830'
        });
    </script>

</asp:Content>

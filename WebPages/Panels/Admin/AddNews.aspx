<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/Admin/NewAdminMaster.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="AddNews.aspx.cs" Inherits="WebPages.Panels.Admin.AddNews1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section id="pageCover" class="row AddNewsHead">
        <div class="row pageTitle">افزودن خبر</div>
        <div class="row pageBreadcrumbs">
            <ol class="breadcrumb" style="direction: rtl">
                <li><a href="index.html" style="color: #F7B71E">خانه</a></li>
                <li><span class="fa fa-arrow-left" style="color: #ffffff" aria-hidden="true"></span></li>
                <li class="active" style="color: #F7B71E">افزودن خبر</li>
            </ol>
        </div>
    </section>
    <div id="container">

        <div class="form-group">

            <label for="title">عنوان :</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="true" ControlToValidate="title" runat="server" CssClass="error" ErrorMessage="عنوان نمیتواند خالی باشد!"></asp:RequiredFieldValidator>

            <asp:TextBox ID="title" onkeydown="return (event.keyCode!=13);" Style="max-width: 500px; height: 40px;" placeholder="عنوان باید کوتاه و مفید باشد" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="Abstract">توضیح کوتاه : </label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" SetFocusOnError="true" ControlToValidate="Abstract" runat="server" CssClass="error" ErrorMessage="توضیح کوتاه نمیتواند خالی باشد!"></asp:RequiredFieldValidator>

            <asp:TextBox ID="Abstract" Style="max-width: 500px; height: 85px;" placeholder="تعداد کلمات پیشنهادی 160 عدد میباشد" Rows="5" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group text-right input-group">
            <label style="display: block" for="Abstract">عکس بالای مقاله : </label>
            <label class="btn btn-info" style="width: 100px;">
                <asp:Literal runat="server" Text="انتخاب عکس" />


                <asp:FileUpload ID="FileUpload1" runat="server" accept="image/*" CssClass="displaynone" BackColor="#CCCCCC" />

            </label>
            <label style="padding: 18px" id="filename"></label>
            <asp:RequiredFieldValidator SetFocusOnError="true" ID="RequiredFieldValidator5" ControlToValidate="FileUpload1" runat="server" CssClass="error" ErrorMessage="هیچ عکسی انتخاب نشده است!"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label style="display: block" for="DDLGroups">گروه کاری : </label>
            <asp:DropDownList ID="DDLGroups" OnSelectedIndexChanged="DDLGroups_SelectedIndexChanged" AutoPostBack="true" CssClass="DDLClass" runat="server"></asp:DropDownList>
            <div class="Displayinline" id="upPan3">
                <asp:UpdatePanel ID="updatepanel4" runat="server">
                    <ContentTemplate>
                        <div runat="server" id="NoItemDiv" style="display: inline; padding: 25px;">
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DDLGroups" EventName="SelectedIndexChanged" />

                    </Triggers>
                </asp:UpdatePanel>
            </div>
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
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" SetFocusOnError="true" ControlToValidate="KeyWords" runat="server" CssClass="error" ErrorMessage="کلمات کلیدی نمیتواند خالی باشد!"></asp:RequiredFieldValidator>

            <asp:TextBox ID="KeyWords" Style="max-width: 500px; height: 40px;" placeholder="چند کلمه کلیدی وارد کنید" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Tags">برچسب ها:</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" SetFocusOnError="true" ControlToValidate="Tags" runat="server" CssClass="error" ErrorMessage="برچسب ها نمیتواند خالی باشد!"></asp:RequiredFieldValidator>

            <asp:TextBox ID="Tags" Style="max-width: 500px; height: 85px;" placeholder="برچسب ها شبه جملاتی چند کلمه ای هستند" CssClass="form-control" runat="server"></asp:TextBox>
        </div>


        <asp:UpdatePanel ID="UpdatePanel3" ChildrenAsTriggers="true" runat="server">
            <ContentTemplate>
                <div runat="server" class="error" id="diverror">
                </div>
                <div class="row">
                    <div class="col-md-5"></div>
                    <div class="col-md-2" style="text-align: center;">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn btn-success" Text="ذخیره" />

                    </div>
                    <div class="col-md-5"></div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="AddToSub" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="RemoveFromSub" EventName="Click" />
                <asp:PostBackTrigger ControlID="btnSave" />
            </Triggers>
        </asp:UpdatePanel>

    </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Script" runat="server">
    <script src="../../_Scripts/AddNews.js"></script>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/Admin/NewAdminMaster.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="EditProject.aspx.cs" Inherits="WebPages.Panels.Admin.EdidProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>ویرایش پروژه</title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section id="pageCover" class="row AddNewsHead">
        <div class="row pageTitle">ویرایش پروژه</div>
        <div class="row pageBreadcrumbs">
            <ol class="breadcrumb" style="direction: rtl">
                <li><a href="/" style="color: #F7B71E">خانه</a></li>
                <li><span class="fa fa-arrow-left" style="color: #ffffff" aria-hidden6="true"></span></li>
                <li class="active" style="color: #F7B71E">ویرایش پروژه</li>
            </ol>
        </div>
    </section>

    <div id="container">

        <div class="form-group">

            <label for="title">عنوان :</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" SetFocusOnError="true" ControlToValidate="title" runat="server" CssClass="error" ErrorMessage="عنوان نمیتواند خالی باشد!"></asp:RequiredFieldValidator>

            <asp:TextBox ID="title" onkeydown="return (event.keyCode!=13);" Style="max-width: 500px; height: 40px;" placeholder="عنوان باید کوتاه و مفید باشد" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="Abstract">توضیح کوتاه : </label>
            <asp:RegularExpressionValidator Display="Dynamic" SetFocusOnError="true" ControlToValidate="Abstract" CssClass="error" ID="RegularExpressionValidator2" ValidationExpression="^[\s\S]{130,}$" runat="server" ErrorMessage="حداقل 130 کاراکتر وارد کنید"></asp:RegularExpressionValidator>
            <asp:TextBox ID="Abstract" Style="max-width: 500px; height: 85px;" placeholder="حداقل تعداد حروف 130 عدد میباشد" Rows="5" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group text-right input-group">
            <label style="display: block" for="Abstract">عکس فعلی : </label>
            <asp:Image ID="oldPhoto" CssClass="img-responsive" Width="200px" Height="200px" runat="server" />
        </div>
        <div class="form-group text-right input-group">
            <label style="display: block" for="Abstract">انتخاب عکس جدید :  </label>
            <label class="btn btn-info" style="width: 100px;">
                <asp:Literal runat="server" Text="انتخاب عکس" />

                <asp:FileUpload ID="FileUpload1" runat="server" accept="image/*" CssClass="displaynone" BackColor="#CCCCCC" />
            </label>
            <label style="padding: 18px" id="filename"></label>
        </div>
        <div class="form-group">
            <label style="display: block" for="DDLGroups">گروه کاری : </label>
            <asp:DropDownList ID="DDLGroups2" OnSelectedIndexChanged="DDLGroups2_SelectedIndexChanged" AutoPostBack="true" CssClass="DDLClass" runat="server"></asp:DropDownList>
            <div class="Displayinline" id="upPan3">
                <asp:UpdatePanel ID="updatepanel4" runat="server">
                    <ContentTemplate>
                        <div runat="server" id="NoItemDiv" style="display: inline; padding: 25px;">
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DDLGroups2" EventName="SelectedIndexChanged" />
                    </Triggers>
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
        <div class="form-group">
            <label>زیر گروه : </label>
            <div>

                <div class="Displayinline" id="upPan1">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:ListBox ID="SubGroups2" CssClass="LBXClass" runat="server"></asp:ListBox>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DDLGroups2" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="RemoveFromSub2" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="AddToSub2" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <asp:UpdateProgress ID="updateProgress2" runat="server" DisplayAfter="0">
                        <ProgressTemplate>
                            <div style="position: fixed; text-align: center; height: 100%; padding-top: 100px; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #ffffff; opacity: 0.8;">
                                <asp:Image ID="imgUpdateProgress2" runat="server" ImageUrl="~/_construction/images/44frgm.gif" AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; top: 45%; left: 50%;" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </div>
                <div style="display: inline;">

                    <table style='width: 70px; display: inline'>
                        <tr>

                            <td style='width: 50px; text-align: center; vertical-align: middle;'>
                                <asp:Button ID="AddToSub2" Width="50px" OnClick="AddToSub2_Click" CausesValidation="False" runat="server" Text=">>" />
                                <br />
                                <br />
                                <asp:Button ID="RemoveFromSub2" Width="50px" OnClick="RemoveFromSub2_Click" CausesValidation="False" runat="server" Text="<<" />
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
                            <asp:AsyncPostBackTrigger ControlID="AddToSub2" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="RemoveFromSub2" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <asp:UpdateProgress ID="updateProgress3" runat="server" DisplayAfter="0">
                        <ProgressTemplate>
                            <div style="position: fixed; text-align: center; height: 100%; padding-top: 100px; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #ffffff; opacity: 0.8;">
                                <asp:Image ID="imgUpdateProgress3" runat="server" ImageUrl="~/_construction/images/44frgm.gif" AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; top: 45%; left: 50%;" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </div>
            </div>
        </div>
        <div style="max-height: 870px">

            <asp:TextBox runat="server" ID="editor1" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="form-group" style="margin-top: 20px">
            <label for="KeyWords">کلمات کلیدی:</label>
            <asp:RequiredFieldValidator Display="Dynamic" data-role="tagsinput" ID="RequiredFieldValidator3" SetFocusOnError="true" ControlToValidate="KeyWords" runat="server" CssClass="error" ErrorMessage="کلمات کلیدی نمیتواند خالی باشد!"></asp:RequiredFieldValidator>

            <asp:TextBox ID="KeyWords" Style="max-width: 500px; height: 40px;" onkeydown="return (event.keyCode!=13);" data-role="tagsinput" placeholder="چند کلمه کلیدی وارد کنید" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Tags">برچسب ها:</label>
            <asp:RequiredFieldValidator Display="Dynamic" data-role="tagsinput" ID="RequiredFieldValidator4" SetFocusOnError="true" ControlToValidate="Tags" runat="server" CssClass="error" ErrorMessage="برچسب ها نمیتواند خالی باشد!"></asp:RequiredFieldValidator>

            <asp:TextBox ID="Tags" Style="max-width: 500px; height: 85px;" data-role="tagsinput" onkeydown="return (event.keyCode!=13);" placeholder="برچسب ها شبه جملاتی چند کلمه ای هستند" CssClass="form-control" runat="server"></asp:TextBox>
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
                <asp:AsyncPostBackTrigger ControlID="AddToSub2" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="RemoveFromSub2" EventName="Click" />
                <asp:PostBackTrigger ControlID="btnSave" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="updateProgress4" runat="server" DisplayAfter="0">
            <ProgressTemplate>
                <div style="position: fixed; text-align: center; height: 100%; padding-top: 100px; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #ffffff; opacity: 0.8;">
                    <asp:Image ID="imgUpdateProgress4" runat="server" ImageUrl="~/_construction/images/44frgm.gif" AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; top: 45%; left: 50%;" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Script" runat="server">
    <script src="../../_Scripts/AddNews.js"></script>
</asp:Content>
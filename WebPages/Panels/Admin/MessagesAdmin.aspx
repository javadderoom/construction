﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/Admin/NewAdminMaster.Master" AutoEventWireup="true" CodeBehind="MessagesAdmin.aspx.cs" Inherits="WebPages.Panels.Admin.MessagesAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>صفحه چت</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
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
    <div id="container">

        <div class="InnerContainer">
            <input id="hiddenControl" type="hidden" runat="server" />
            <div class="c-title">
                <h4>
                    <asp:Literal runat="server" Text="نمایش پیام ها" /></h4>
            </div>

            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="x_panel">
                        <div runat="server" id="divReciver"></div>
                        <div class="alert alert-info alert-dismissable dirRight text-right" style="color: black; background-color: #18bc9c">
                            <span id="lblid" runat="server" style="color: black;"><span class="fa fa-arrow-left"></span><b></b><span class="fa fa-arrow-left"></span>کارشناس آموزش مهندسی شیمی- خانم صداقت</span>
                        </div>

                        <div class="x_content">
                            <div id="demo-form2" class="form-horizontal form-label-right">
                                <div class="col-md-8 col-md-offset-2 col-xs-12">
                                    <div id="ContentPlaceHolder1_upWait">

                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-xs-12 col-sm-2 col-sm-push-10 text-right">
                                                    <span id="ContentPlaceHolder1_lbl_ConversationID" class="control-label formLabel" style="font-size: 100%; font-weight: bold;">شناسه</span>
                                                </div>

                                                <div class="col-xs-12 col-sm-10 col-sm-pull-2 text-right">
                                                    <span id="lblidnum" runat="server" class="control-label formLabel text-right dirRight" style="color: DarkBlue; font-size: 100%; font-weight: bold;"></span>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-xs-12 col-sm-2 col-sm-push-10 text-right">
                                                    <span id="ContentPlaceHolder1_lbl_Subject" class="control-label formLabel" style="font-size: 100%; font-weight: bold;">عنوان پیام</span>
                                                </div>

                                                <div class="col-xs-12 col-sm-10 col-sm-pull-2 text-right">
                                                    <span id="lblSubject" runat="server" class="control-label formLabel text-right dirRight" style="color: DarkRed; font-size: 100%; font-weight: bold;"></span>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-xs-12 col-sm-2 col-sm-push-10 text-right">
                                                    <span id="ContentPlaceHolder1_lbl_StartDateTime" class="control-label formLabel " style="font-size: 100%; font-weight: bold;">تاریخ و زمان شروع</span>
                                                </div>

                                                <div class="col-xs-12 col-sm-10 col-sm-pull-2 text-right">
                                                    <span id="lblStartTime" runat="server" class="control-label formLabel text-right dirRight" style="color: Green; font-size: 100%; font-weight: bold;"><span class="fa fa-calendar"></span><span class="fa fa-clock-o"></span></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="ln_double_solid"></div>
                                    <div class="form-group">

                                        <div class="col-xs-8 text-right">
                                            <div id="ContentPlaceHolder1_upMsgBtn">

                                                <div id="ContentPlaceHolder1_pnlMsgBtn">

                                                    <button type="button" class="btn btn-primary" data-toggle="collapse" data-target="#pnlSendMessage" aria-expanded="false" aria-controls="pnlSendMessage">
                                                        ارسال پیام جدید
                                                    </button>
                                                </div>
                                                <div class="ln_double_solid"></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div id="demo-form3" class="form-horizontal form-label-right">
                                <div class="col-md-8 col-md-offset-2 col-xs-12">
                                    <div class="ln_double_solid"></div>
                                    <div id="demo-pnlForm" class="form-horizontal form-label-right">
                                        <div id="pnlSendMessage" class="collapse">
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-xs-12 text-right">
                                                        <span id="ContentPlaceHolder1_lblMessageText" class="control-label formLabel" style="font-size: 100%; font-weight: bold;">متن پیام</span>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-xs-12 text-right dirRight">
                                                        <textarea name="ctl00$ContentPlaceHolder1$tbxMessageText" runat="server" maxlength="500" rows="2" cols="20" id="tbxMessageText" class="form-control text-right dirRight" style="height: 160px;"></textarea>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="tbxMessageText" CssClass="alert-danger" runat="server" ErrorMessage="متن پیام را وارد کنید"></asp:RequiredFieldValidator>
                                                        <div style="width: 200px; text-align: right; color: green">ظرفیت : 500 کاراکتر</div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <div class="row">

                                                    <div class="col-xs-12 text-right dirRight">
                                                        <div class="alert alert-info alert-dismissible text-right dirRight" role="alert">
                                                            <button type="button" class="close" data-dismiss="alert" aria-label="Close"></button>
                                                            در صورت نیاز به ارسال پیام های طولانی لطفا متن پیام را در فایل word تایپ کرده و درقالب فایل پیوست پیام ارسال نمایید
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-xs-12 col-sm-2 col-sm-push-10 text-right">
                                                        <span id="ContentPlaceHolder1_lblAttachFile" class="control-label formLabel" style="font-size: 100%; font-weight: bold;">فایل ضمیمه</span>
                                                    </div>

                                                    <div class="col-xs-12 col-sm-10 col-sm-pull-2 text-right">
                                                        <span id="ContentPlaceHolder1_FileUploadMessage" class="control-label formLabel" style="color: Green; font-size: 100%;">!حداکثر ظرفیت فایل آپلود 1 مگابایت</span>
                                                        <label class="btn btn-info" style="width: 100px;">
                                                            <asp:Literal runat="server" Text="آپلود فایل" />
                                                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="dispnone" accept=".zip" />
                                                        </label>
                                                        <label style="padding: 18px" id="filename"></label>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <div class="ln_solid"></div>

                                                <div class="col-xs-12 text-right">
                                                    <asp:Label ID="lblWarning" runat="server" Text=""></asp:Label>
                                                    <input type="button" value="ارسال" class="btn btn-success" runat="server" onserverclick="Unnamed_ServerClick" />
                                                </div>
                                            </div>
                                            <div class="ln_double_solid"></div>
                                        </div>
                                        <div id="ContentPlaceHolder1_upGrid">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <%=messages() %>

            <div class="extra"></div>


        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="server">
    <script>
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

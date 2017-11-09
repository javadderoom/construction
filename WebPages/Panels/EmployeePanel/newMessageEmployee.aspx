<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/EmployeePanel/EmployeeMaster.Master" AutoEventWireup="true" CodeBehind="newMessageEmployee.aspx.cs" Inherits="WebPages.Panels.EmployeePanel.newMessageEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>پیام جدید</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="direction: rtl; padding: 28px 7% 20px 7%; margin-bottom: 20px;">
        <div class="c-title">
            <h4>

                <asp:Literal runat="server" Text="پیام جدید" />
            </h4>
        </div>

        <div class="right_col" role="main" style="min-height: 420px;">

            <span id="tickMessageStatus" style="visibility: hidden; display: none;"></span>



            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="x_panel">

                        <div class="x_content">
                            <div id="demo-form2" class="form-horizontal form-label-right">
                                <div class="col-md-8 col-md-offset-2 col-xs-12">
                                    <div id="ContentPlaceHolder1_upWait">

                                        <div id="ContentPlaceHolder1_pnlBoxInfo">

                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-xs-12 col-sm-2 col-sm-push-10 text-right">
                                                    </div>

                                                    <div class="col-xs-12 col-sm-10 col-sm-pull-2 text-right dirRight">
                                                        <div class="alert alert-warning alert-dismissible text-right dirRight" style="background-color: #18bc9c; color: white;" role="alert">
                                                            <button type="button" class="close" data-dismiss="alert" aria-label="Close"></button>

                                                            رعایت  اخلاقیات توسط طرفین(درخواست کننده و پاسخ دهنده) در سامانه الزامی خواهد بود، در غیر اینصورت مطابق مقررات برخورد خواهد شد.</span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-xs-12 col-sm-2 col-sm-push-10 text-right">
                                                    <span id="ContentPlaceHolder1_lblSubject" class="control-label formLabel" style="font-size: 100%; font-weight: bold;">موضوع</span>
                                                </div>

                                                <div class="col-xs-12 col-sm-10 col-sm-pull-2 text-right">
                                                    <input type="text" runat="server" maxlength="50" id="txtSubject" class="form-control text-right dirRight tbxCounter" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtSubject" CssClass="alert-danger" runat="server" ErrorMessage="موضوع پیام را وارد کنید"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-xs-12 col-sm-2 col-sm-push-10 text-right">
                                                <span id="ContentPlaceHolder1_lblMessageText" class="control-label formLabel" style="font-size: 100%; font-weight: bold;">متن پیام</span>
                                            </div>

                                            <div class="col-xs-12 col-sm-10 col-sm-pull-2 text-right dirRight">
                                                <textarea name="" runat="server" rows="2" cols="20" id="tbxMessageText" class="form-control text-right dirRight" maxlength="500" style="height: 160px;"></textarea>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="tbxMessageText" CssClass="alert-danger" runat="server" ErrorMessage="متن پیام را وارد کنید"></asp:RequiredFieldValidator>

                                                <div style="width: 648px; text-align: right; color: green" id="lblcnt">ظرفیت : 500 کاراکتر</div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-xs-12 col-sm-2 col-sm-push-10 text-right">
                                            </div>

                                            <div class="col-xs-12 col-sm-10 col-sm-pull-2 text-right dirRight">
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

                                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="ln_solid"></div>
                                    <div class="form-group">
                                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                        <div class="col-xs-4 text-left">
                                        </div>
                                        <div class="col-xs-8 text-right">

                                            <input style="float: right; margin-left: 50px; margin-top: -3px" type="button" id="btnSend" class="btn btn-success" runat="server" onserverclick="btnSend_ServerClick" value="ارسال پیام" />

                                            <asp:Label ID="lblWarning" runat="server" Text=""></asp:Label>
                                        </div>

                                        <div class="modal fade" id="modalAskSubmitAdd" tabindex="-1" role="dialog" aria-labelledby="modalAskSubmitAdd-label" aria-hidden="true">
                                            <div class="modal-dialog">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                                        <h4 class="modal-title" id="modalAskSubmitAdd-label">هشدار

                                                    <span class="glyphicon glyphicon-warning-sign"></span>
                                                        </h4>
                                                    </div>
                                                    <div class="modal-body">
                                                        <p>آیا برای ثبت اطلاعات اطمینان دارید؟</p>
                                                    </div>
                                                    <div class="modal-footer">
                                                        <div class="row">
                                                            <div class="col-xs-12 text-center">
                                                                <button type="button" class="btn btn-danger" data-dismiss="modal">
                                                                    خیر
                                                                </button>

                                                                <input type="submit" name="ctl00$ContentPlaceHolder1$btnSubmit" value="بله" onclick="$('#modalAskSubmitAdd').hide();" id="ContentPlaceHolder1_btnSubmit" class="btn btn-primary">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- footer content -->

            <footer>
                <div class="copyright-info">
                    <p class="pull-right dirRight" style="color: #34516d;">
                        <span id="lblFooter">تمامی حقوق این سامانه برای شرکت پیمانکاری محفوظ است | تولید۱۳۹6</span>
                    </p>
                </div>
                <div class="clearfix"></div>
            </footer>
            <!-- /footer content -->
        </div>
    </div>
</asp:Content>

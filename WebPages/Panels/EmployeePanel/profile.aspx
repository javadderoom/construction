<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/EmployeePanel/EmployeeMaster.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="WebPages.Panels.EmployeePanel.profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="../../js/jquery.min.js"></script>
    <link href="../../_Styles/simple-sidebar.css" rel="stylesheet" />
    <link href="../../_Styles/bootstrap.css" rel="stylesheet" />
    <link href="../../_Styles/StyleSheet.css" rel="stylesheet" />
    <link href="../../_Styles/AdminPanelStyles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="c-title">
        <h4>

            <asp:Literal runat="server" Text="کارتابل شخصی" />
        </h4>
    </div>
    <div class="col-md-12 col-sm-12 col-xs-12">
        <div class="x_panel">


            <div class="x_content">
                <div id="demo-form2" class="form-horizontal form-label-right">
                    <div class="col-md-6 col-md-offset-3 col-xs-12">
                        <div id="ContentPlaceHolder1_upWait" style="height: 650px">
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-12 col-sm-4 col-sm-push-8 text-right">
                                        <span id="ContentPlaceHolder1k_lbl_ID" class="control-label formLabel" style="font-size: 100%; font-weight: bold;">عکس</span>
                                    </div>

                                    <div class="col-xs-12 col-sm-8 col-sm-pull-4 text-right">
                                        <asp:Image ID="Image1" runat="server" Width="100" Height="100" />
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-12 col-sm-4 col-sm-push-8 text-right">
                                        <span id="ContentPlaceHolder1_lbl_ID" class="control-label formLabel" style="font-size: 100%; font-weight: bold;">شناسه</span>
                                    </div>

                                    <div class="col-xs-12 col-sm-8 col-sm-pull-4 text-right">
                                        <span id="lblid" runat="server" class="control-label formLabel"></span>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-12 col-sm-4 col-sm-push-8 text-right">
                                        <span id="ContentPlaceHolder1_lbl_StudentCode" class="control-label formLabel" style="font-size: 100%; font-weight: bold;">نام کاربری</span>
                                    </div>

                                    <div class="col-xs-12 col-sm-8 col-sm-pull-4 text-right">
                                        <span id="lblusername" runat="server" class="control-label formLabel"></span>
                                    </div>
                                </div>
                            </div>



                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-12 col-sm-4 col-sm-push-8 text-right">
                                        <span id="ContentPlaceHolder1_lbl_LastName" class="control-label formLabel" style="font-size: 100%; font-weight: bold;">نام و نام خانوادگی</span>
                                    </div>

                                    <div class="col-xs-12 col-sm-8 col-sm-pull-4 text-right">
                                        <span id="lblfullname" runat="server" class="control-label formLabel"></span>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-12 col-sm-4 col-sm-push-8 text-right">
                                        <span id="ContentPlaceHolder1_lbl_Field" class="control-label formLabel" style="font-size: 100%; font-weight: bold;">شماره موبایل</span>
                                    </div>

                                    <div class="col-xs-12 col-sm-8 col-sm-pull-4 text-right">
                                        <span id="lblmobile" runat="server" class="control-label formLabel"></span>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-12 col-sm-4 col-sm-push-8 text-right">
                                        <span id="wwwwww" class="control-label formLabel" style="font-size: 100%; font-weight: bold;">کد پستی</span>
                                    </div>

                                    <div class="col-xs-12 col-sm-8 col-sm-pull-4 text-right">
                                        <span id="lblzip" runat="server" class="control-label formLabel"></span>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-12 col-sm-4 col-sm-push-8 text-right">
                                        <span id="fsfd" class="control-label formLabel" style="font-size: 100%; font-weight: bold;">ایمیل</span>
                                    </div>

                                    <div class="col-xs-12 col-sm-8 col-sm-pull-4 text-right">
                                        <span id="lblemail" runat="server" class="control-label formLabel"></span>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-12 col-sm-4 col-sm-push-8 text-right">
                                        <span id="ContentPlaceHolder1_lbl_AdmissionType" class="control-label formLabel" style="font-size: 100%; font-weight: bold;">استان و شهر</span>
                                    </div>

                                    <div class="col-xs-12 col-sm-8 col-sm-pull-4 text-right">
                                        <span id="lblcitystate" runat="server" class="control-label formLabel"></span>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-12 col-sm-4 col-sm-push-8 text-right">
                                        <span id="ContentPlaceHolder1_lbl_EntryTerm" class="control-label formLabel" style="font-size: 100%; font-weight: bold;">آدرس</span>
                                    </div>

                                    <div class="col-xs-12 col-sm-8 col-sm-pull-4 text-right">
                                        <span id="lbladdress" runat="server" class="control-label formLabel"></span>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-12 col-sm-4 col-sm-push-8 text-right">
                                        <span id="ContentPlaceHolder1_lbl_EntryTermj" class="control-label formLabel" style="font-size: 100%; font-weight: bold;">رزومه</span>
                                    </div>

                                    <div class="col-xs-12 col-sm-8 col-sm-pull-4 text-right dirRight">
                                        <asp:FileUpload ID="fileResume" runat="server" />
                                        <asp:Label ID="lblWarningResume" runat="server" Text="لطفا رزومه ی خود را بصورت فایل zip. با حجم کمتر از 5 مگابایت بارگذاری کنید." ForeColor="Green"></asp:Label>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-12 col-sm-4 col-sm-push-8 text-right">
                                        <span id="ContentPlaceHolder1_lbl_EntryTنermj" class="control-label formLabel" style="font-size: 100%; font-weight: bold;">تعویض عکس</span>
                                    </div>

                                    <div class="col-xs-12 col-sm-8 col-sm-pull-4 text-right dirRight">
                                        <asp:FileUpload ID="fileImage" runat="server" />
                                        <asp:Label ID="lblWarningImage" runat="server" Text="عکس با فرمت jpg. یا png. با حجم کمتر از 1 مگابایت بارگذاری کنید" ForeColor="Green"></asp:Label>
                                    </div>
                                </div>
                            </div>



                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-12 col-sm-12 text-right dirRight">
                                    </div>
                                </div>
                            </div>
                            <div class="ln_solid"></div>
                            <div class="form-group">
                                <div class="col-xs-12 text-right">
                                    <asp:Button ID="btnEdit" CssClass="btn btn-auto-v btn-auto-h btn-primary goRight" runat="server" Text="ثبت ویرایش" OnClick="btnEdit_Click" />
                                </div>

                            </div>

                        </div>
                    </div>
                </div>
                <div class="extra"></div>
                <div class="extra"></div>
            </div>
        </div>

    </div>

</asp:Content>

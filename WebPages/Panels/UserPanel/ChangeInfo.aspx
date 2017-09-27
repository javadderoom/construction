<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/UserPanel/UsersMaster.Master" AutoEventWireup="true" CodeBehind="ChangeInfo.aspx.cs" Inherits="WebPages.Panels.UserPanel.ChangeInformation" %>

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
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script src="../../js/jquery.validate.min.js"></script>

    <link href="../../_Styles/StyleSheet.css" rel="stylesheet" />
    <link href="../../_Styles/AdminPanelStyles.css" rel="stylesheet" />
    <style>
        body {
            font-family: 'B Nazanin' Tahoma sans-serif;
            height: 600px;
        }
    </style>

    <script>
        $(document).ready(function () {
            $("#tbxMobile").keydown(function (e) {
                // Allow: backspace, delete, tab, escape, enter and .
                if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
                    // Allow: Ctrl+A, Command+A
                    (e.keyCode === 65 && (e.ctrlKey === true || e.metaKey === true)) ||
                    // Allow: home, end, left, right, down, up
                    (e.keyCode >= 35 && e.keyCode <= 40)) {
                    // let it happen, don't do anything
                    return;
                }
                // Ensure that it is a number and stop the keypress
                if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
                    e.preventDefault();
                }
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="c-title">
        <h4>

            <asp:Literal runat="server" Text="تغییر رمز عبور" />
        </h4>
    </div>
    <div class="x_content">
        <div id="demo-form2" class="form-horizontal form-label-right">
            <div class="col-md-6 col-md-offset-3 col-xs-12">
                <div id="ContentPlaceHolder1_upWait">


                    <div class="form-group">
                        <div class="row">
                            <div class="col-xs-12 col-sm-4 col-sm-push-8 text-right">
                                :
                                        <span id="ContentPlaceHolder1_lblCurrentPassword" class="control-label formLabel" style="font-size: 100%; font-weight: bold;">رمز عبور جاری</span>
                            </div>

                            <div class="col-xs-12 col-sm-8 col-sm-pull-4 text-right">

                                <asp:TextBox ID="tbxnowPass" runat="server" ValidationGroup="pass" TextMode="Password" MaxLength="50" CssClass="form-control text-right dirRight"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="pass" ControlToValidate="tbxnowPass" CssClass="alert-danger" runat="server" ErrorMessage="رمز عبور جاری را وارد کنید"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-xs-12 col-sm-4 col-sm-push-8 text-right">
                                :
                                        <span id="ContentPlaceHolder1_lblNewPassword" class="control-label formLabel" style="font-size: 100%; font-weight: bold;">رمز عبور جدید</span>
                            </div>

                            <div class="col-xs-12 col-sm-8 col-sm-pull-4 text-right">
                                <asp:TextBox ID="tbxnewpass" runat="server" ValidationGroup="pass" TextMode="Password" MaxLength="50" CssClass="form-control text-right dirRight"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="pass" ControlToValidate="tbxnewpass" CssClass="alert-danger" runat="server" ErrorMessage="رمز عبور جدید را وارد کنید"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-xs-12 col-sm-4 col-sm-push-8 text-right">
                                :
                                        <span id="ContentPlaceHolder1_lblConfirmNewPassword" class="control-label formLabel" style="font-size: 100%; font-weight: bold;">تکرار رمز عبور جدید</span>
                            </div>

                            <div class="col-xs-12 col-sm-8 col-sm-pull-4 text-right">
                                <asp:TextBox ID="tbxnewpassagain" ValidationGroup="pass" runat="server" TextMode="Password" MaxLength="50" CssClass="form-control text-right dirRight"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="pass" ControlToValidate="tbxnewpassagain" CssClass="alert-danger" runat="server" ErrorMessage="رمز عبور جدید را دوباره وارد کنید"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>


                </div>

                <div class="ln_solid"></div>
                <div class="form-group">
                    <div class="col-xs-12 text-right">
                        <asp:Label runat="server" Text="" ID="lblWarning"></asp:Label>
                        <asp:Button ID="btnSabt" runat="server" Text="ثـــــبت" CssClass="btn btn-success" OnClick="btnSabt_ServerClick" ValidationGroup="pass" />

                    </div>




                </div>
                <div class="extra"></div>
            </div>
            <div class="extra"></div>
        </div>
        <div class="extra"></div>
    </div>
    <div class="c-title">
        <h4>

            <asp:Literal runat="server" Text="تغییر شماره موبایل" />
        </h4>
    </div>
    <div class="x_content">
        <div id="demo-form2" class="form-horizontal form-label-right">
            <div class="col-md-6 col-md-offset-3 col-xs-12">
                <div id="ContentPlaceHolder1_upWait">


                    <div class="form-group">
                        <div class="row">
                            <div class="col-xs-12 col-sm-4 col-sm-push-8 text-right">
                                :
                                        <span id="ContentPlaceHolder1_lblCurrentPassword" class="control-label formLabel" style="font-size: 100%; font-weight: bold;">شماره موبایل</span>
                            </div>

                            <div class="col-xs-12 col-sm-8 col-sm-pull-4 text-right">

                                <asp:TextBox ID="tbxMobile" runat="server" MaxLength="11" ValidationGroup="mobile" CssClass="form-control text-right dirRight"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="mobile" ControlToValidate="tbxMobile" CssClass="alert-danger" runat="server" ErrorMessage="شماره موبایل راوارد کنید"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>






                </div>

                <div class="ln_solid"></div>
                <div class="form-group">
                    <div class="col-xs-12 text-right">
                        <asp:Label runat="server" Text="" ID="lblMobileWarning"></asp:Label>
                        <asp:Button ID="btnMobile" runat="server" Text="ثـــــبت" CssClass="btn btn-success" OnClick="btnMobile_Click" ValidationGroup="mobile" />

                    </div>




                </div>
                <div class="extra"></div>
            </div>
            <div class="extra"></div>
        </div>
        <div class="extra"></div>
    </div>
    <div class="extra" style="height: 400px"></div>
</asp:Content>

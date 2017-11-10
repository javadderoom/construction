<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebPages.UserReg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ثبت نام</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1,max-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <script src="js/jquery.min.js"></script>
    <script src="js/jquery.validate.min.js"></script>

    <script src="bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>

    <link href="bootstrap-3.3.7-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="_Styles/RegStyle.css" rel="stylesheet" />
    <style>
        .form-control:focus {
            border-color: #18bc9c;
        }
    </style>
    <script>
        $(document).ready(function () {

            $("#txtmobile").keydown(function (e) {
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

            $("#txtzip").keydown(function (e) {
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
</head>
<body style="overflow-x: hidden">

    <!-- Header -->
    <div class="page-bg"></div>
    <div>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="container">
                <div class="row">
                    <div class="col-md-4 "></div>
                    <div class="registerContainer col-md-6 col-sm-12 col-xs-12">

                        <div class=" MainDiv ">
                            <div class="registerLogo"></div>
                            <div class="col-md-12 rdiDiv">

                                <asp:RadioButton ID="rdiEmployees" runat="server" Text="همکاران" CssClass="rdiLogin" GroupName="login" />
                                <asp:RadioButton ID="rdiUsers" runat="server" Text="مشتریان" CssClass="rdiLogin" GroupName="login" Checked="true" />
                            </div>
                            <div class="col-md-12 col-sm-12 col-xs-12 loginContent">
                                <div class="row text">
                                    <div class="col-md-12 registerAccountInfo">

                                        <div class="row">
                                            <div class="col-md-6 col-sm-6 col-xs-12 pull-right">
                                                نام
                                    <br />

                                                <input type="text" class="" id="txtName" runat="server" required="required" maxlength="50" placeholder="نام خود را وارد کنید" oninvalid="this.setCustomValidity('لطفا این فیلد را پر کنید !')" oninput="setCustomValidity('')" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TxtName" CssClass="alert-danger" runat="server" ErrorMessage="نام خود را وارد کنید"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-6 col-sm-6 col-xs-12 pull-left">
                                                نام خانوادگی
                                    <br />
                                                <input type="text" class="" id="txtFamily" runat="server" required maxlength="50" placeholder="نام خانوادگی خود را وارد کنید" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtFamily" CssClass="alert-danger" runat="server" ErrorMessage="نام خانوادگی را وارد کنید"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6 col-sm-6 col-xs-12 pull-right">
                                                نام کاربری
                                    <br />
                                                <input type="text" class="" id="txtusername" runat="server" required maxlength="50" placeholder="نام کاربری خود را وارد کنید" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtusername" CssClass="alert-danger" runat="server" ErrorMessage="نام کاربری را وارد کنید"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-6 col-sm-6 col-xs-12 pull-left">
                                                ایمیل
                                                    <br />
                                                <input type="text" class="" placeholder="ایمیل خود را وارد کنید(اختیاری)" id="txtEmail" runat="server" maxlength="50" />
                                                <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="فرمت ایمیل وارد شده اشتباه است"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-6 col-sm-6 col-xs-12 pull-right">
                                                رمز عبور
                                    <br />
                                                <input type="password" class="" placeholder="رمز عبور خود را وارد کنید" required id="txtPassword" runat="server" maxlength="50" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtPassword" CssClass="alert-danger" runat="server" ErrorMessage="رمز کاربری را وارد کنید"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-6 col-sm-6 col-xs-12 pull-left">
                                                تکرار رمز عبور
                                    <br />
                                                <input type="password" class="" placeholder="رمز عبور خود را تکرار کنید" required id="txtpassword2" runat="server" maxlength="50" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtpassword2" CssClass="alert-danger" runat="server" ErrorMessage="رمز عبور خود را دوباره وارد کنید"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <%-- <div class="row">
                                            <div class="col-md-6 col-sm-6 col-xs-12 pull-right">
                                            </div>
                                            <div class="col-md-6 col-sm-6 col-xs-12 pull-left">
                                            </div>
                                        </div>--%>

                                        <div class="row">
                                            <div class="col-md-6 col-sm-6 col-xs-12 pull-right">
                                                موبایل
                                    <br />
                                                <input type="text" class="" placeholder="شماره موبایل خود را وارد کنید" required id="txtmobile" runat="server" maxlength="11" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtmobile" CssClass="alert-danger" runat="server" ErrorMessage="شماره موبایل خود را وارد کنید"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="(\+98|0)?9\d{9}" ControlToValidate="txtmobile" ErrorMessage="فرمت شماره وارد شده اشتباه است"></asp:RegularExpressionValidator>
                                            </div>
                                            <div class="col-md-6 col-sm-6 col-xs-12 pull-left">
                                                کد پستی
                                    <br />
                                                <input type="text" class="" placeholder="کدپستی خود را بدون خط تیره وارد کنید" id="txtzip" runat="server" maxlength="10" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtzip" CssClass="alert-danger" runat="server" ErrorMessage="کدپستی خود را وارد کنید"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-6 col-sm-6 col-xs-12 pull-right">
                                                <div class="dropDiv">
                                                    استان :
                                    <asp:DropDownList ID="ddlState" runat="server" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                    <br />
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                        <ContentTemplate>
                                                            شهر &nbsp :
                                    <asp:DropDownList ID="ddlCity" runat="server"></asp:DropDownList>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlState" EventName="SelectedIndexChanged" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                            <div class="col-md-6 col-sm-6 col-xs-12 pull-left">
                                                آدرس
                                    <br />
                                                <textarea placeholder="آدرس خود را وارد کنید" id="txtadress" runat="server" maxlength="50"></textarea>
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtadress" CssClass="alert-danger" runat="server" ErrorMessage="آدرس را وارد کنید"></asp:RequiredFieldValidator>--%>
                                            </div>
                                        </div>

                                        <div class="row   captchaBlock">
                                            <div class="col-md-12 col-xs-12" style="margin-bottom: 10px;">
                                                <asp:UpdatePanel ID="UpdateImage" runat="server">
                                                    <ContentTemplate>
                                                        <table>
                                                            <tr>
                                                                <td style="height: 100%; width: 50px;">
                                                                    <asp:Image ID="btnImg" runat="server" CssClass="imgInline" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            <div class="col-md-12 col-xs-12">
                                                <input type="text" id="txtImage" runat="server" maxlength="5" class="form-control" placeholder="کد تصویر را وارد کنید" style="width: 190px; display: inline; text-align: right; font-family: Tahoma"></input>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12 btnLogindiv" style="">
                                            <div class="col-md-12 col-xs-12 col-sm-12">
                                                <asp:Button runat="server" ID="BtnRegister" CssClass="btnRegister" Text="ثبت نام" OnClick="BtnLogin_Click" />
                                                <asp:Label ID="lblWarning" runat="server" Text="" ForeColor="Red" BackColor="LightPink"></asp:Label>
                                                <span runat="server" id="SpLabl" class="alert-danger"></span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
        </form>
    </div>

    <!-- Footer -->
</body>
</html>

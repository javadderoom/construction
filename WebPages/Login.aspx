<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebPages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>صفحه ورود کاربران</title>

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1,max-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <script src="js/jquery-1.11.3.min.js"></script>
    <script src="js/jquery.min.js"></script>
    <script src="js/jquery.validate.min.js"></script>
    <script src="bootstrap-3.3.7-dist/js/bootstrap.js"></script>
    <script src="bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>
    <script src="bootstrap-3.3.7-dist/js/npm.js"></script>
    <link href="bootstrap-3.3.7-dist/css/bootstrap-theme.min.css" rel="stylesheet" />

    <link href="bootstrap-3.3.7-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="_Styles/StyleSheet.css" rel="stylesheet" />
    <link href="_Styles/sasan.css" rel="stylesheet" />
    <link href="_Styles/LoginStyle.css" rel="stylesheet" />
    <style>
        .form-control:focus {
            border-color: #18bc9c;
        }
    </style>
    <style>
    </style>
</head>
<body style="overflow-x: hidden">

    <!-- Header -->

    <div>
        <div class="page-bg"></div>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="container">
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="loginContainer col-md-4 col-sm-12 col-xs-12">

                        <div class=" MainDiv ">
                            <div class="loginLogo"></div>
                            <div class="col-md-12 rdiDiv">

                                <asp:RadioButton ID="rdiEmployees" runat="server" Text="همکاران" CssClass="rdiLogin" GroupName="login" />
                                <asp:RadioButton ID="rdiUsers" runat="server" Text="مشتریان" CssClass="rdiLogin" GroupName="login" Checked="true" />
                            </div>
                            <div class="col-md-12 loginContent">

                                <div>

                                    <br />
                                    <div class="loginInfo">
                                        <div class="userText">
                                            <span class="glyphicon glyphicon-user "></span>
                                            <input type="text" placeholder="نام کاربری" class="" id="txtName" runat="server" maxlength="50" />
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TxtName" CssClass="alert-danger"
                                            runat="server" ErrorMessage="نام کاربری را وارد کنید"></asp:RequiredFieldValidator>
                                        <br />

                                        <br />
                                        <div class="passText">
                                            <div class="passcontainer">
                                                <div class="passIcon"></div>
                                            </div>
                                            <input type="password" placeholder="رمز عبور" class="" id="txtPassword" runat="server" maxlength="50" />
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TxtPassword" CssClass="alert-danger"
                                            runat="server" ErrorMessage="رمز کاربری را وارد کنید"></asp:RequiredFieldValidator>
                                        <br />
                                    </div>
                                    <div class="row captchaBlock">
                                        <div class="col-md-5">
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
                                        <div class="col-md-7">
                                            <input type="text" id="txtImage" runat="server" maxlength="5" class="form-control" placeholder="کد تصویر را وارد کنید" style="width: 190px; display: inline"></input>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12 btnLogindiv" style="">
                                            <div class="col-md-12">
                                                <asp:Button runat="server" ID="BtnLogin" CssClass="btnLogin" Text="ورود" OnClick="BtnLogin_Click" />
                                            </div>

                                            <br />
                                            <div class="col-md-12">
                                                <asp:Label ID="lblWarning" CssClass="alert-danger" runat="server" Text="" ForeColor="Red" BackColor="LightPink"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-12 emailForgot">
                                            <a href="#">رمز عبور خود را فراموش کرده اید؟</a>
                                        </div>
                                    </div>
                                    <br />
                                    <br />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4"></div>
                </div>
            </div>
        </form>
    </div>

    <!-- Footer -->
</body>
</html>
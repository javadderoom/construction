<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="WebPages.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>صفحه ورود کاربران</title>
    <script src="bootstrap-3.3.7-dist/js/bootstrap.js"></script>
    <script src="bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>
    <script src="bootstrap-3.3.7-dist/js/npm.js"></script>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link href="bootstrap-3.3.7-dist/css/bootstrap-theme.css" rel="stylesheet" />
    <link href="bootstrap-3.3.7-dist/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="bootstrap-3.3.7-dist/css/bootstrap.css" rel="stylesheet" />
    <link href="bootstrap-3.3.7-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/jquery-1.11.3.min.js"></script>
    <script src="js/jquery.min.js"></script>
    <script src="js/jquery.validate.min.js"></script>
    <link href="_Styles/StyleSheet.css" rel="stylesheet" />
    <link href="_Styles/sasan.css" rel="stylesheet" />
    <style>
        .form-control:focus {
            border-color: #18bc9c;
        }
    </style>
</head>
<body style="overflow-x: hidden">

    <nav id="mainNav" class="navbar navbar-default navbar-fixed-top navbar-custom">
        <div class="container myFont">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header page-scroll">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span> Menu <i class="fa fa-bars"></i>
                </button>
                <a class="navbar-brand" href="#page-top">سایت خبری روز</a>
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav navbar-right">
                    <li class="hidden">
                        <a href="#page-top"></a>
                    </li>
                    <li class="page-scroll">
                        <a href="../../Index.aspx">خانه</a>
                    </li>
                    <li class="page-scroll">

                        <a href="../../pages/Users/Loginpage.aspx">ورود </a>
                    </li>
                    <li class="page-scroll">
                        <a href="">ثبت نام</a>
                    </li>
                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container-fluid -->
    </nav>

    <!-- Header -->
    <header>
        <div class="container myFont" id="maincontent" tabindex="-1">
            <div class="row">
                <div class="col-lg-12">
                    <img class="img-responsive" src="img/profile.png" alt="" style="width: 100px; height: 100px;">
                    <div class="intro-text">
                        <h1 class="name myFont">
                            <span class="myFont">به سایت خبری روز خوش آمدید
                            </span></h1>
                        <hr class="star-light">
                        <span class="skills" style="font-weight: bold">پنل ورود کاربران</span>
                    </div>
                </div>
            </div>
        </div>
    </header>
    <div>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="container-fluid MainDiv">
                <div class="col-md-8" style="direction: rtl; margin-top: 10px;">
                </div>
                <div class="row mrgTop20">
                    <div class="col-md-8">
                    </div>
                    <div class="col-md-8" style="margin-top: 20px;">
                        نام کاربری
                  <br />
                        <input type="text" class="form-control" id="txtName" runat="server" maxlength="50" style="width: 400px;" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TxtName" CssClass="alert-danger" runat="server" ErrorMessage="نام کاربری را وارد کنید"></asp:RequiredFieldValidator>
                        <br />
                        رمز عبور
                  <br />
                        <input type="password" class="form-control" id="txtPassword" runat="server" maxlength="50" style="width: 400px;" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TxtPassword" CssClass="alert-danger" runat="server" ErrorMessage="رمز کاربری را وارد کنید"></asp:RequiredFieldValidator>
                        <br />
                        <%-- <div id="dvCaptcha">
                        </div>
                        <asp:TextBox ID="txtCaptcha" runat="server" Style="display: none" />
                        <asp:RequiredFieldValidator ID="rfvCaptcha" ErrorMessage="Captcha validation is required." ControlToValidate="txtCaptcha"
                            runat="server" ForeColor="Red" Display="Dynamic" />--%>

                        <asp:UpdatePanel ID="UpdateImage" runat="server">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td style="height: 40px; width: 50px;">
                                            <asp:Image ID="btnImg" runat="server" CssClass="imgInline" />
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <input type="text" id="txtImage" runat="server" maxlength="5" class="form-control" placeholder="کد تصویر را وارد کنید" style="width: 190px; display: inline"></input>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button runat="server" ID="BtnLogin" CssClass="btn btn-success" Text="ورود" OnClick="BtnLogin_Click" Height="50" Width="100" />
                        <asp:Label ID="lblWarning" runat="server" Text="" ForeColor="Red" BackColor="LightPink"></asp:Label>
                        <span runat="server" id="SpLabl" class="alert-danger"></span>
                        <br />
                        <br />
                    </div>
                    <div class="col-md-4">
                    </div>
                </div>

            </div>
        </form>
    </div>

    <!-- Footer -->
    <footer class="text-center">
        <div class="footer-above">
            <div class="container">
                <div class="row">
                    <div class="footer-col col-md-4">
                        <h3 class="myFont">آدرس</h3>
                        <p>
                            3481 Melrose Place
                            <br>
                            Beverly Hills, CA 90210
                        </p>
                    </div>
                    <div class="footer-col col-md-4">
                        <h3>Around the Web</h3>
                        <ul class="list-inline">
                            <li>
                                <a href="#" class="btn-social btn-outline"><span class="sr-only">Facebook</span><i class="fa fa-fw fa-facebook"></i></a>
                            </li>
                            <li>
                                <a href="#" class="btn-social btn-outline"><span class="sr-only">Google Plus</span><i class="fa fa-fw fa-google-plus"></i></a>
                            </li>
                            <li>
                                <a href="#" class="btn-social btn-outline"><span class="sr-only">Twitter</span><i class="fa fa-fw fa-twitter"></i></a>
                            </li>
                            <li>
                                <a href="#" class="btn-social btn-outline"><span class="sr-only">Linked In</span><i class="fa fa-fw fa-linkedin"></i></a>
                            </li>
                            <li>
                                <a href="#" class="btn-social btn-outline"><span class="sr-only">Dribble</span><i class="fa fa-fw fa-dribbble"></i></a>
                            </li>
                        </ul>
                    </div>
                    <div class="footer-col col-md-4">
                        <h3>About Freelancer</h3>
                        <p>Freelance is a free to use, open source Bootstrap theme created by <a href="http://startbootstrap.com">Start Bootstrap</a>.</p>
                    </div>
                </div>
            </div>
        </div>
        <div class="footer-below">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">
                        Copyright &copy; Your Website 2016
                    </div>
                </div>
            </div>
        </div>
    </footer>




</body>
</html>

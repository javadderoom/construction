<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersReg.aspx.cs" Inherits="WebPages.UserReg" %>

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

    <nav id="mainNav" class="navbar navbar-default navbar-fixed-top navbar-custom">
        <div class=" container myFont">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class=" navbar-header page-scroll">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span> Menu <i class="fa fa-bars"></i>
                </button>
                <a class="navbar-brand" href="#page-top">سایت خبری روز</a>
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">
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
                        <a href="../../pages/Users/RegUser.aspx">ثبت نام</a>
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
                <div class="col-md-12">
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
                <div class="row mrgTop20">
                    <%--<div class="col-md-8">
                    </div>--%>
                    <div class="col-md-8" style="margin-top: 20px;">
                        نام
                  <br />
                        <input type="text" class="form-control" id="txtName" runat="server" maxlength="50" style="width: 400px;" placeholder="نام خود را وارد کنید" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TxtName" CssClass="alert-danger" runat="server" ErrorMessage="نام خود را وارد کنید"></asp:RequiredFieldValidator>
                        <br />
                        نام خانوادگی
                  <br />
                        <input type="text" class="form-control" id="txtFamily" runat="server" maxlength="50" style="width: 400px;" placeholder="نام خانوادگی خود را وارد کنید" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TxtPassword" CssClass="alert-danger" runat="server" ErrorMessage="نام خانوادگی را وارد کنید"></asp:RequiredFieldValidator>
                        <br />

                        نام کاربری
                  <br />
                        <input type="text" class="form-control" id="txtusername" runat="server" maxlength="50" style="width: 400px;" placeholder="نام کاربری خود را وارد کنید" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="TxtName" CssClass="alert-danger" runat="server" ErrorMessage="نام کاربری را وارد کنید"></asp:RequiredFieldValidator>
                        <br />
                        رمز عبور
                  <br />
                        <input type="password" class="form-control" placeholder="رمز عبور خود را وارد کنید" id="txtPassword" runat="server" maxlength="50" style="width: 400px;" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="TxtPassword" CssClass="alert-danger" runat="server" ErrorMessage="رمز کاربری را وارد کنید"></asp:RequiredFieldValidator>
                        <br />

                        تکرار رمز عبور
                  <br />
                        <input type="password" class="form-control" placeholder="رمز عبور خود را دوباره وارد کنید" id="txtpassword2" runat="server" maxlength="50" style="width: 400px;" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="TxtName" CssClass="alert-danger" runat="server" ErrorMessage="رمز عبور خود را دوباره وارد کنید"></asp:RequiredFieldValidator>
                        <br />
                        موبایل
                  <br />
                        <input type="text" class="form-control" placeholder="شماره موبایل خود را وارد کنید" id="txtmobile" runat="server" maxlength="11" style="width: 400px;" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="TxtPassword" CssClass="alert-danger" runat="server" ErrorMessage="شماره موبایل خود را وارد کنید"></asp:RequiredFieldValidator>
                        <br />


                        آدرس
                  <br />
                        <input type="text" class="form-control" placeholder="آدرس خود را وارد کنید" id="txtadress" runat="server" maxlength="50" style="width: 400px;" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="TxtName" CssClass="alert-danger" runat="server" ErrorMessage="آدرس را وارد کنید"></asp:RequiredFieldValidator>
                        <br />
                        کد پستی
                  <br />
                        <input type="text" class="form-control" placeholder="کدپستی خود را بدون خط تیره وارد کنید" id="txtzip" runat="server" maxlength="10" style="width: 400px;" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="TxtPassword" CssClass="alert-danger" runat="server" ErrorMessage="کدپستی خود را وارد کنید"></asp:RequiredFieldValidator>
                        <br />
                        <div>
                            استان :
                            <asp:DropDownList ID="ddlState" runat="server" Width="150" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <br />
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    شهر &nbsp :
                                    <asp:DropDownList ID="ddlCity" runat="server" Width="150"></asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlState" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                        <br />

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
                        <input type="text" id="txtImage" runat="server" class="form-control" placeholder="کد تصویر را وارد کنید" style="width: 190px; display: inline"></input>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button runat="server" ID="BtnLogin" CssClass="btn btn-success" Text="ثبت نام" OnClick="BtnLogin_Click" Height="50" Width="100" />
                        <asp:Label ID="lblWarning" runat="server" Text="" ForeColor="Red" BackColor="LightPink"></asp:Label>
                        <span runat="server" id="SpLabl" class="alert-danger"></span>
                        <br />
                        <br />
                    </div>
                    <%--<div class="col-md-4">
                    </div>--%>
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

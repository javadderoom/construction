<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebPages.Login" %>

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


    <link href="_Styles/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="c-title">
                <h4>
                    <asp:Literal runat="server" Text="ورود کاربران" /></h4>
            </div>
            <div class="c-content">
                <div id="demo-form2" class="form-horizontal form-label-right">
                    <div class="col-md-6 col-md-offset-3 col-xs-12">

                        <div class="form-group">
                            <div class="row">
                                <div class="col-xs-12 col-sm-4 col-sm-push-8 text-right">
                                    <span id="lblStudentCode" class="control-label formLabel" style="font-size: 100%; font-weight: bold;">
                                        <asp:Literal runat="server" Text="نام کاربری" />
                                    </span>
                                </div>

                                <div class="col-xs-12 col-sm-8 col-sm-pull-4 text-right">
                                    <input name="ctl00$ContentPlaceHolder1$tbxStudentCode" type="text" maxlength="50" id="tbxusername" runat="server" class="form-control text-right dirRight" />
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="row">
                                <div class="col-xs-12 col-sm-4 col-sm-push-8 text-right">
                                    <span id="ContentPlaceHolder1_lbl_FirstName" class="control-label formLabel" style="font-size: 100%; font-weight: bold;">
                                        <asp:Literal runat="server" Text="رمز ورود" />
                                    </span>
                                </div>

                                <div class="col-xs-12 col-sm-8 col-sm-pull-4 text-right">
                                    <input name="ctl00$ContentPlaceHolder1$tbxFirstName" type="text" maxlength="50" id="tbxpassword" runat="server" class="form-control text-right dirRight" />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

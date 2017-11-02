<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="WebPages.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>صفحه ورود </title>
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

    <link href="_Styles/LoginStyle.css" rel="stylesheet" />
    <style>
        .form-control:focus {
            border-color: #18bc9c;
        }
 </style>
</head>
<body style="overflow-x: hidden">

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
</body>
</html>
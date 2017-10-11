<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testpage.aspx.cs" Inherits="WebPages.test.testpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>test page</title>
    <link href="teststyle.css" rel="stylesheet" />
    <script src="testscript.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
          
            <div class="login">
                <div class="login_title">
                    <span>وارد اکانت خود شوید</span>
                </div>
                <div class="login_fields">
                    <div class="login_fields__user">
                        <div class="icon">
                            <img src="https://s3-us-west-2.amazonaws.com/s.cdpn.io/217233/user_icon_copy.png" />
                        </div>
                        <input placeholder="Username" type="text">
                            <div class="validation">
                                <img src="https://s3-us-west-2.amazonaws.com/s.cdpn.io/217233/tick.png" />
                            </div>
                        </input>
                    </div>
                    <div class="login_fields__password">
                        <div class="icon">
                            <img src="https://s3-us-west-2.amazonaws.com/s.cdpn.io/217233/lock_icon_copy.png" />
                        </div>
                        <input placeholder="Password" type="password"></input>
                        <div class="validation">
                            <img src="https://s3-us-west-2.amazonaws.com/s.cdpn.io/217233/tick.png" />
                        </div>
                    </div>
                    <div class="login_fields__submit">
                        <input type="button" value="Log In"></input>
                        <div class="forgot">
                            <a href="#">Forgotten password?</a>
                        </div>
                    </div>
                </div>
                <div class="success">
                    <h2>Authentication Success</h2>
                    <p>Welcome back</p>
                </div>
                <div class="disclaimer">
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce semper laoreet placerat. Nullam semper auctor justo, rutrum posuere odio vulputate nec.</p>
                </div>
            </div>
            <div class="authent">
                <img src="https://s3-us-west-2.amazonaws.com/s.cdpn.io/217233/puff.svg" />
                <p>Authenticating...</p>
            </div>
            <div class="love">
                <p>
                    Made with
                    <img src="https://s3-us-west-2.amazonaws.com/s.cdpn.io/217233/love_copy.png" />
                    by <a href='https://www.jamiecoulter.co.uk' target='_blank'>Jcoulterdesign </a>
                </p>
            </div>
        </div>
    </form>
</body>
</html>
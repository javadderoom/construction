<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebPages.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="fa">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <script src="_Scripts/jquery-3.2.1.min.js"></script>
    <script src="bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>
    <script src="bootstrap-3.3.7-dist/js/npm.js"></script>
    <link href="bootstrap-3.3.7-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="bootstrap-3.3.7-dist/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="_Styles/HomeStyleSheet.css" rel="stylesheet" />
</head>
<body data-spy="scroll" data-target=".navbar" data-offset="50">
    <form id="form1" runat="server">
        <div>
            <div class="container-fluid " style="height: 800px;">

                <div class="top-nav hidden-xs hidden-s">
                    <div class="top-nav-inner">
                        <div class="email">
                            <span class="glyphicon glyphicon-envelope" aria-hidden="true"></span>
                            <a href="#" class="">demo@gmail.com</a>
                        </div>
                        <div class="phone">
                            <span class="glyphicon glyphicon-earphone" aria-hidden="true"></span>
                            <a href="#" class="">1234</a>
                        </div>
                        <div class="sosioal-network">
                            <ul>
                                <li>
                                    <div class="telegram"></div>
                                </li>
                                <li>
                                    <div class="instagram"></div>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>

                <div style="border-bottom: 1px #DDE2E6 solid; width: 100%;">
                    <nav class=" second-nav navbar  navbar-default " style="background-color: transparent;">

                        <div class="container-fluid">
                            <div class="navbar-header">
                                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                                    <span class="icon-bar"></span>
                                    <span class="icon-bar"></span>
                                    <span class="icon-bar"></span>
                                </button>
                                <a class="navbar-brand" href="#">Construction</a>
                            </div>
                            <div class="collapse navbar-collapse" id="myNavbar">
                                <ul class="nav navbar-nav">
                                    <li class="active"><a href="#">Home</a></li>
                                    <li class="dropdown">
                                        <a class="dropdown-toggle" data-toggle="dropdown" href="#">Page 1 <span class="caret"></span></a>
                                        <ul class="dropdown-menu">
                                            <li><a href="#">Page 1-1</a></li>
                                            <li><a href="#">Page 1-2</a></li>
                                            <li><a href="#">Page 1-3</a></li>
                                        </ul>
                                    </li>
                                    <li><a href="#">Page 2</a></li>
                                    <li><a href="#">Page 3</a></li>
                                </ul>
                            </div>
                        </div>
                    </nav>
                </div>

                <div class="inner-container">
                </div>
            </div>
        </div>
    </form>
</body>
</html>
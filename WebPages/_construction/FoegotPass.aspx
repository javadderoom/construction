<%@ Page Title="" Language="C#" MasterPageFile="~/_construction/IndexMaster.Master" AutoEventWireup="true" CodeBehind="FoegotPass.aspx.cs" Inherits="WebPages._construction.FoegotPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>فراموشی رمز عبور</title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="pageStyles" runat="server">
    <style>
        div#container {
            min-height: 500px;
        }

        .InnerContainer {
            min-height: 300px;
            box-shadow: 5px 4px 10px #858585;
            padding: 1px 5px;
        }
    </style>
    <link href="_Styles/StyleSheet.css" rel="stylesheet" />

    <link href="_Styles/LoginStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="container">
        <div class="InnerContainer" style="padding: 0 25px;">
            <div class="row sectionTitles">
                <h2 class="sectionTitle"></h2>
                <div class="sectionSubTitle">فراموشی رمز عبور</div>
            </div>
            <div style="margin-top: 20px">
                <div class="form-group">

                    <label for="title">نام کابری یا آدرس ایمیلی که با آن ثبت نام کرده اید :</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" SetFocusOnError="true" ControlToValidate="title" runat="server" CssClass="error" ErrorMessage="نام کاربری یا آدرس ایمیل"></asp:RequiredFieldValidator>

                    <asp:TextBox ID="title" onkeydown="return (event.keyCode!=13);" Style="max-width: 500px; height: 40px;" placeholder="عنوان باید کوتاه و مفید باشد" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="row captchaBlock">
                    <div class="col-md-5 col-xs-5">
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
                    <div class="col-md-7 col-xs-7">
                        <input type="text" id="txtImage" runat="server" maxlength="5" class="form-control" placeholder="کد تصویر را وارد کنید" style="width: 190px; display: inline; font-family: Tahoma"></input>
                    </div>
                </div>

            </div>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="map" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>

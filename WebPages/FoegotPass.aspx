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
            background-color: white;
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
                <div class="row">
                    <div class="col-md-12 rdiDiv">

                        <asp:RadioButton ID="rdiEmployees" runat="server" Text="همکار" CssClass="rdiLogin" GroupName="login" />
                        <asp:RadioButton ID="rdiUsers" runat="server" Text="مشتری" CssClass="rdiLogin" GroupName="login" Checked="true" />
                    </div>
                </div>

                <div class="form-group">

                    <label for="tbxMail">نام کابری یا آدرس ایمیلی که با آن ثبت نام کرده اید :</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" SetFocusOnError="true" ControlToValidate="tbxMail" runat="server" CssClass="error" ErrorMessage="لطقا این فیلد را پر کنید !"></asp:RequiredFieldValidator>

                    <asp:TextBox ID="tbxMail" onkeydown="return (event.keyCode!=13);" Style="max-width: 500px; height: 40px;" placeholder="نام کاربری یا آدرس ایمیل" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="row ">

                    <asp:UpdatePanel ID="UpdateImage" runat="server">
                        <ContentTemplate>
                            <div class="col-md-4 col-xs-5" style="float: right">
                                <div class="dow">
                                    <div class="col-md-4 col-sx-12">
                                        <asp:Image ID="btnImg" runat="server" CssClass="imgInline" />
                                    </div>
                                    <div class="col-md-8 col-sx-12">
                                        <input type="text" id="txtImage" runat="server" maxlength="5" class="form-control" placeholder="کد تصویر را وارد کنید" style="width: 154px; display: inline; font-family: Tahoma"></input>
                                    </div>
                                </div>
                                <table>
                                    <tr>
                                        <td style="height: 100%; width: 50px;"></td>
                                        <td style="height: 100%;"></td>
                                    </tr>
                                </table>
                            </div>
                            <div class="col-md-8 col-xs-7">
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div style="text-align: center; padding-bottom: 25px;">
                    <asp:Button ID="Button1" CssClass="btn btn-success" runat="server" OnClick="Button1_Click" Text="تایید" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="map" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
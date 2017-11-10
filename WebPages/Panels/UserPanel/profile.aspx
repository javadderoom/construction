<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/UserPanel/UsersMaster.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="WebPages.Panels.UserPanel.profile" %>

<asp:Content ID="content3" ContentPlaceHolderID="pageStyles" runat="server">
    <link href="../../_Styles/ProfileStyles.css" rel="stylesheet" />
    <style>
        .glyphicon {
            cursor: pointer;
            pointer-events: all;
        }

        /* Styles for CodePen Demo Only */
        #wrapper {
            max-width: 500px;
            margin: auto;
        }
    </style>

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {

            $("#lblmobile").keydown(function (e) {
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

            $("#lblzip").keydown(function (e) {
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
    </asp:Content>

    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="user">
            <section class="mainSection ">
                <div class="c_title col-md-3 col-sm-12 col-xs-12">
                    <h4>

                        <asp:Literal runat="server" Text="پروفایل شخصی" />
                    </h4>
                    <img class="ProfileImg" src="../../_construction/images/user128px.png" />

                    <h3 runat="server" id="hFullName"></h3>
                </div>
                <div class="col-md-8 col-sm-12 col-xs-12 x_panel">
                    <div class="infoContent">
                        <div class="accountInfo col-md-6">
                            <div class="infoTitle">
                                اطلاعات کاربری
                            </div>
                            <div class="infoInnerContent">
                                <div class="formGroup">
                                    <label>شناسه </label>
                                    <input id="lblid" class="dirToLeft" runat="server" disabled="disabled" type="text" />
                                </div>
                            </div>
                            <div class="infoInnerContent">
                                <div class="formGroup">
                                    <label>نام کاربری </label>
                                    <input id="lblusername" class="dirToLeft" disabled="disabled" runat="server" type="text" />
                                </div>
                            </div>

                            <div class="infoInnerContent">
                                <div class="formGroup">
                                    <label>رمز عبور </label>
                                    <div id="wrapper">
                                        <div class="form-group has-feedback">
                                            <input type="password" runat="server" class="form-control dirToLeft" id="password" />
                                            <i class="glyphicon glyphicon-eye-open form-control-feedback"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="peronalInfo col-md-6">
                            <div class="infoTitle">
                                اطلاعات شخصی
                            </div>
                            <div class="infoInnerContent">
                                <div class="formGroup">
                                    <label>نام  </label>
                                    <input id="lblfirstName" runat="server" required="required" oninvalid="this.setCustomValidity('لطفا این فیلد را پر کنید !')" oninput="setCustomValidity('')" type="text" />
                                </div>
                            </div>
                            <div class="infoInnerContent">
                                <div class="formGroup">
                                    <label>نام خانوادگی </label>
                                    <input id="lblLastName" runat="server" required="required" oninvalid="this.setCustomValidity('لطفا این فیلد را پر کنید !')" oninput="setCustomValidity('')" type="text" />
                                </div>
                            </div>
                            <div class="infoInnerContent">
                                <div class="formGroup">
                                    <label>موبایل </label>
                                    <input id="lblmobile" class="dirToLeft" maxlength="11" required="required" oninvalid="this.setCustomValidity('لطفا این فیلد را پر کنید !')" oninput="setCustomValidity('')" runat="server" type="text" />
                                </div>
                            </div>
                            <div class="infoInnerContent">
                                <div class="formGroup">
                                    <label>کد پستی </label>
                                    <input id="lblzip" maxlength="10" class="dirToLeft" runat="server" type="text" />
                                </div>
                            </div>
                            <div class="infoInnerContent">
                                <div class="formGroup">
                                    <label>پست الکترونیک </label>
                                    <input id="lblemail" class="dirToLeft" required="required" oninvalid="this.setCustomValidity('لطفا این فیلد را پر کنید !')" oninput="setCustomValidity('')" runat="server" type="text" />
                                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="lblemail" ValidationGroup="Validation" ErrorMessage="فرمت ایمیل وارد شده اشتباه است"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="infoInnerContent">
                                <div class="formGroup">
                                    <%-- <label>استان و شهر </label>--%>
                                    <div class="dropDiv">
                                        <div class="divState">
                                            <label>استان</label>
                                            <asp:DropDownList ID="ddlState" runat="server" CssClass="ddl" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                        <br />
                                        <div class="divState">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <contenttemplate>
                                                <label>شهر</label>
                                                <asp:DropDownList ID="ddlCity" CssClass="ddl" runat="server"></asp:DropDownList>
                                            </contenttemplate>
                                                <triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlState" EventName="SelectedIndexChanged" />
                                            </triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="infoInnerContent">

                                <div class="formGroup">
                                    <label>آدرس </label>
                                    <textarea cols="2" id="lbladdress" required="required" oninvalid="this.setCustomValidity('لطفا این فیلد را پر کنید !')" oninput="setCustomValidity('')" runat="server"></textarea>
                                </div>
                            </div>
                            <div class="infoInnerContent">
                                <div class="formGroup">
                                    <asp:Button ID="btnEdit" CssClass="btnLogin" runat="server" Text="ثبت تغییرات" OnClick="btnEdit_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </asp:Content>
    <asp:Content ID="Content4" ContentPlaceHolderID="Scripts" runat="server">
        <script>
            // toggle password visibility
            $('.glyphicon-eye-open').on('click', function () {
                $(this).toggleClass('glyphicon-eye-close').toggleClass('glyphicon-eye-open'); // toggle our classes for the eye icon

                var x = document.getElementById("ContentPlaceHolder1_password");
                if (x.type === "password") {
                    x.type = "text";
                } else {
                    x.type = "password";
                }
            });


        </script>
</asp:Content>

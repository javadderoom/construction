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
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="user">
        <section class="mainSection ">
            <div class="c_title col-md-3 col-sm-12 col-xs-12">
                <h4>

                    <asp:Literal runat="server" Text="پروفایل شخصی" />
                </h4>

                <asp:Image ID="pImg" CssClass="ProfileImg" runat="server" />
                <h3 runat="server" id="hFullName"></h3>

                <%-- <a class="btn btn-auto-v btn-auto-h btn-primary goRight" href="/Panels/UserPanel/ChangeInfo.aspx">ویرایش اطلاعات
                                        <span class="fa fa-edit"></span>
            </a>--%>
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
                                <input id="lblid" class="dirToLeft" runat="server" disabled type="text" />
                            </div>
                        </div>
                        <div class="infoInnerContent">
                            <div class="formGroup">
                                <label>نام کاربری </label>
                                <input id="lblusername" class="dirToLeft" runat="server" type="text" />
                            </div>
                        </div>
                        <%--<label>رمز عبور </label>

                                <input type="password" class=" dirToLeft" id="password" runat="server" placeholder="Password" />
                        --%>
                        <div class="infoInnerContent">
                            <div class="formGroup">
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
                                <input id="lblfirstName" runat="server" type="text" />
                            </div>
                        </div>
                        <div class="infoInnerContent">
                            <div class="formGroup">
                                <label>نام خانوادگی </label>
                                <input id="lblLastName" runat="server" type="text" />
                            </div>
                        </div>
                        <div class="infoInnerContent">
                            <div class="formGroup">
                                <label>موبایل </label>
                                <input id="lblmobile" class="dirToLeft" runat="server" type="text" />
                            </div>
                        </div>
                        <div class="infoInnerContent">
                            <div class="formGroup">
                                <label>کد پستی </label>
                                <input id="lblzip" class="dirToLeft" runat="server" type="text" />
                            </div>
                        </div>
                        <div class="infoInnerContent">
                            <div class="formGroup">
                                <label>پست الکترونیک </label>
                                <input id="lblemail" class="dirToLeft" runat="server" type="text" />
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
                                            <ContentTemplate>
                                                <label>شهر</label>
                                                <asp:DropDownList ID="ddlCity" CssClass="ddl" runat="server"></asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlState" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="infoInnerContent">

                            <div class="formGroup">
                                <label>آدرس </label>
                                <textarea cols="2" id="lbladdress" runat="server"></textarea>
                            </div>
                        </div>
                        <div class="infoInnerContent">
                            <div class="formGroup">
                                <asp:Button ID="btnEdit" CssClass="btnLogin" runat="server" Text="ثبت تغییرات" OnClick="btnEdit_Click" />
                            </div>
                        </div>
                    </div>

                    <div class="" style="display: none">

                        <div class="ln_solid"></div>
                        <div class="form-group">
                            <div class="col-xs-12 text-right">
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
        $(' .glyphicon').on('click', function () {
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

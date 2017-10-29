<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/EmployeePanel/EmployeeMaster.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="WebPages.Panels.EmployeePanel.profile" %>

<asp:Content ID="content3" ContentPlaceHolderID="pageStyles" runat="server">
    <link href="../../_Styles/ProfileStyles.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <section class="mainSection">
        <div class="c_title col-md-3 col-sm-12 col-xs-12">
            <h4>

                <asp:Literal runat="server" Text="پروفایل شخصی" />
            </h4>
            <img class="ProfileImg" id="Image1" runat="server" src="../../_construction/images/user128px.png" />
            <h3 runat="server" id="hFullName"></h3>

            <div class="imgUpload">
                <label class="btn btn-info" style="width: 133px;">
                    <asp:Literal runat="server" Text="تغییر عکس پروفایل" />

                    <asp:FileUpload ID="fileImage" runat="server" accept="image/*" CssClass="displaynone" BackColor="#CCCCCC" />
                </label>
                <br />
                <label style="padding: 18px" id="imageName"></label>
            </div>
            <br />
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
                    <div class="infoInnerContent">
                        <div class="formGroup">
                            <label>رمز عبور </label>
                            <input id="lblpassword" class="dirToLeft" runat="server" type="password" />
                        </div>
                    </div>

                    <div class="infoInnerContent">
                        <div class="formGroup">
                            <label>ارسال رزومه </label>
                            <label class="btn btn-info" style="width: 100px;">
                                <asp:Literal runat="server" Text="انتخاب فایل" />

                                <asp:FileUpload ID="fileResume" runat="server" accept="zip/*" CssClass="displaynone" BackColor="#CCCCCC" />
                            </label>
                            <label style="padding: 18px" id="filename"></label>
                        </div>
                    </div>

                    <asp:Label ID="lblWarning" runat="server" Text=""></asp:Label>
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
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
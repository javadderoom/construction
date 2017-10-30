<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/Admin/NewAdminMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeInfo.aspx.cs" Inherits="WebPages.Panels.Admin.EmployeeInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>جزئیات همکار</title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PageStyle" runat="server">
    <link href="../../_Styles/ProfileStyles.css" rel="stylesheet" />
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="../../js/jquery.min.js"></script>
    <link href="../../_Styles/simple-sidebar.css" rel="stylesheet" />
    <link href="../../_Styles/bootstrap.css" rel="stylesheet" />
    <link href="../../_Styles/StyleSheet.css" rel="stylesheet" />
    <link href="../../_Styles/AdminPanelStyles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <section class="mainSection">
        <div class="c_title col-md-3 col-sm-12 col-xs-12">
            <h4>
                <asp:Literal runat="server" Text="اطلاعات کارمندان" />
            </h4>
            <img class="ProfileImg" id="Image1" runat="server" src="../../_construction/images/user128px.png" />
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
                            <input id="lblid" class="dirToLeft" runat="server" disabled type="text" />
                        </div>
                    </div>
                    <div class="infoInnerContent">
                        <div class="formGroup">
                            <label>نام کاربری </label>
                            <input id="lblusername" class="dirToLeft" runat="server" disabled type="text" />
                        </div>
                    </div>
                    <div class="infoInnerContent">
                        <div class="formGroup">

                            <asp:ListBox ID="lbxJobs" runat="server" Height="150" Width="200"></asp:ListBox>
                        </div>
                    </div>
                    <div class="infoInnerContent">
                        <div class="formGroup">
                            <label>رزومه</label>
                            <asp:Button ID="btnDownLoadResume" runat="server" Text="دانلود رزومه" OnClick="btnDownLoadResume_Click" />
                        </div>
                    </div>
                </div>
                <div class="peronalInfo col-md-6">
                    <div class="infoTitle">
                        اطلاعات شخصی
                    </div>
                    <div class="infoInnerContent">
                        <div class="formGroup">
                            <label>نام و نام خانوادگی </label>
                            <input id="lblfullname" runat="server" disabled type="text" />
                        </div>
                    </div>
                    <div class="infoInnerContent">
                        <div class="formGroup">
                            <label>موبایل </label>
                            <input id="lblmobile" class="dirToLeft" runat="server" disabled type="text" />
                        </div>
                    </div>
                    <div class="infoInnerContent">
                        <div class="formGroup">
                            <label>کد پستی </label>
                            <input id="lblzip" class="dirToLeft" runat="server" disabled type="text" />
                        </div>
                    </div>
                    <div class="infoInnerContent">
                        <div class="formGroup">
                            <label>پست الکترونیک </label>
                            <input id="lblemail" class="dirToLeft" runat="server" disabled type="text" />
                        </div>
                    </div>
                    <div class="infoInnerContent">
                        <div class="formGroup">
                            <label>استان و شهر </label>
                            <input id="lblcitystate" runat="server" disabled type="text" />
                        </div>
                    </div>
                    <div class="infoInnerContent">

                        <div class="formGroup">
                            <label>آدرس </label>
                            <input id="lbladdress" runat="server" disabled type="text" />
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
<asp:Content ID="Content5" ContentPlaceHolderID="Script" runat="server">
</asp:Content>

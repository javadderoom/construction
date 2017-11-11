<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/Admin/NewAdminMaster.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="WebPages.Panels.Admin.UserInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>اطلاعات کاربر</title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageStyle" runat="server">
    <link href="../../_Styles/ProfileStyles.css" rel="stylesheet" />
    <style>
        div#container {
            min-height: 500px;
        }

        .InnerContainer {
            min-height: 790px;
            width: 100%;
            padding: 1px 5px;
        }

        @media(max-width:991px) {
            .InnerContainer {
                height: 1378px;
            }
        }
    </style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <div id="container">
        <div class="InnerContainer">
            <div class="c_title col-md-3 col-sm-12 col-xs-12">
                <h4>
                    <asp:Literal runat="server" Text="اطلاعات کاربر" />
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
                                <input id="lblid" class="dirToLeft" runat="server" disabled type="text" />
                            </div>
                        </div>
                        <div class="infoInnerContent">
                            <div class="formGroup">
                                <label>نام کاربری </label>
                                <input id="lblusername" class="dirToLeft" runat="server" disabled type="text" />
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
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Script" runat="server">
</asp:Content>
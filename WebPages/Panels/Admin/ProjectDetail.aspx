<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/Admin/NewAdminMaster.Master" AutoEventWireup="true" CodeBehind="ProjectDetail.aspx.cs" Inherits="WebPages.Panels.Admin.ProjectDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>جزییات سفارش</title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageStyle" runat="server">
    <link href="../../_Styles/ProjectDetailStyles.css" rel="stylesheet" />
    <link href="../../_Styles/Input&Lable.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">

    <div class="content col-md-9 col-sm-12 col-xs-12">
        <div class="Title">
            جزییات سفارش
        </div>
        <div class="innerContent col-md-12 col-sm-12 col-xs-12">
            <div class="userInfo col-md-4 col-sm-4 col-xs-12">
                <div class="innerTitles">
                    مشتری
                </div>
                <div class="inputDiv">
                    <div class="formGroup">
                        <label>نام </label>
                        <input id="FullName" runat="server" disabled type="text" />
                    </div>
                </div>

                <div class="inputDiv">
                    <div class="formGroup">
                        <label>موبایل </label>
                        <input id="mobile" class="dirToLeft" runat="server" disabled type="text" />
                    </div>
                </div>
                <div class="inputDiv">
                    <div class="formGroup">
                        <label>ایمیل </label>
                        <input id="email" class="dirToLeft" runat="server" disabled type="text" />
                    </div>
                </div>
            </div>
            <div class="info col-md-4 col-sm-4 col-xs-12">
                <div class="innerTitles">
                    مشخصات پروژه
                </div>
                <div class="inputDiv">
                    <div class="formGroup">
                        <label>عنوان </label>
                        <input id="onvan" runat="server" disabled type="text" />
                    </div>
                </div>

                <div class="inputDiv">
                    <div class="formGroup">
                        <label>تاریخ شروع </label>
                        <input id="startDate" runat="server" disabled type="text" />
                    </div>
                </div>
                <div class="inputDiv">
                    <div class="formGroup">
                        <label>تاریخ پایان </label>
                        <input id="finishDate" runat="server" disabled type="text" />
                    </div>
                </div>
                <div class="inputDiv">
                    <div class="formGroup">
                        <label>بودجه </label>
                        <input id="budget" runat="server" disabled type="text" />
                    </div>
                </div>
                <div class="inputDiv">
                    <div class="formGroup">
                        <label>توضیحات </label>
                        <textarea id="desc" runat="server" disabled type="text"></textarea>
                    </div>
                </div>
            </div>
            <div class="location col-md-4 col-sm-4 col-xs-12">
                <div class="innerTitles">
                    محل اجرای پروژه
                </div>
                <div class="inputDiv">
                    <div class="formGroup">

                        <label>استان </label>
                        <input id="ostan" runat="server" disabled type="text" />
                    </div>
                </div>
                <div class="inputDiv">
                    <div class="formGroup">
                        <label>شهر </label>
                        <input id="city" runat="server" disabled type="text" />
                    </div>
                </div>
                <div class="inputDiv">
                    <div class="formGroup">
                        <label>آدرس </label>
                        <textarea id="address" runat="server" disabled type="text"></textarea>
                    </div>
                </div>

                <div class="col-md-12 col-sm-12 col-xs-12">
                </div>
                <asp:Button ID="btnMessage" CssClass="btnMessage" OnClick="btnMessage_Click" runat="server" Text="پاسخ با پیام" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Script" runat="server">
</asp:Content>
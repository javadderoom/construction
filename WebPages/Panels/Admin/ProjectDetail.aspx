<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/Admin/NewAdminMaster.Master" AutoEventWireup="true" CodeBehind="ProjectDetail.aspx.cs" Inherits="WebPages.Panels.Admin.ProjectDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageStyle" runat="server">
    <link href="../../_Styles/ProjectDetailStyles.css" rel="stylesheet" />
    <link href="../../_Styles/Input&Lable.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">

    <div class="content col-md-9 col-sm-12 col-xs-12">
        <div class="Title">
            جزییات پروژه
        </div>
        <div class="innerContent col-md-12 col-sm-12 col-xs-12">
            <div class="userInfo col-md-4 col-sm-4 col-xs-12">
                <div class="innerTitles">
                    مشتری
                </div>
                <div class="inputDiv">
                    <div class="formGroup">
                        <label>نام </label>
                        <input id="lblUserName" value="نام مشتری" runat="server" disabled type="text" />
                    </div>
                </div>

                <div class="inputDiv">
                    <div class="formGroup">
                        <label>موبایل </label>
                        <input id="Text1" class="dirToLeft" value="09111234567" runat="server" disabled type="text" />
                    </div>
                </div>
                <div class="inputDiv">
                    <div class="formGroup">
                        <label>ایمل </label>
                        <input id="Text2" class="dirToLeft" value="deomo@info.com" runat="server" disabled type="text" />
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
                        <input id="lblid" value="عنوان پروژه" runat="server" disabled type="text" />
                    </div>
                </div>

                <div class="inputDiv">
                    <div class="formGroup">
                        <label>تاریخ شروع </label>
                        <input id="Text3" runat="server" disabled type="text" />
                    </div>
                </div>
                <div class="inputDiv">
                    <div class="formGroup">
                        <label>تاریخ پایان </label>
                        <input id="Text4" runat="server" disabled type="text" />
                    </div>
                </div>
                <div class="inputDiv">
                    <div class="formGroup">
                        <label>بودجه </label>
                        <input id="Text5" runat="server" disabled type="text" />
                    </div>
                </div>
                <div class="inputDiv">
                    <div class="formGroup">
                        <label>توضیحات </label>
                        <textarea id="Text6" runat="server" disabled type="text"></textarea>
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
                        <input id="Text7" runat="server" disabled type="text" />
                    </div>
                </div>
                <div class="inputDiv">
                    <div class="formGroup">
                        <label>شهر </label>
                        <input id="Text8" runat="server" disabled type="text" />
                    </div>
                </div>
                <div class="inputDiv">
                    <div class="formGroup">
                        <label>توضیحات </label>
                        <textarea id="Textarea1" runat="server" disabled type="text"></textarea>
                    </div>
                </div>
                <div class="col-md-12 col-sm-12 col-xs-12">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Script" runat="server">
</asp:Content>
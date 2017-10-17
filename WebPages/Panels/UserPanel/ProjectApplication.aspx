<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/UserPanel/UsersMaster.Master" AutoEventWireup="true" CodeBehind="ProjectApplication.aspx.cs" Inherits="WebPages.Panels.UserPanel.ProjectApplication" %>

<asp:Content ID="Content2" ContentPlaceHolderID="pageStyles" runat="server">
    <link href="../../_Styles/FloatingLable.css" rel="stylesheet" />
    <link href="../../_Styles/ProjectAppStyles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content col-md-8 col-sm-12 col-xs-12">
        <div class="Title">
            سفارش پروژه
        </div>
        <div class="innerContent col-md-12 col-sm-12 col-xs-12">
            <div class="info col-md-6 col-sm-6 col-xs-12">
                <div class="innerTitles">
                    مشخصات پروژه
                </div>
                <div class="inputDiv">
                    <input class="FloatingLabel" id="title" type="text" placeholder="عنوان پروژه را وارد اینجا بنویسید" alt="عنوان" />
                </div>
                <div class="inputDiv">
                    <input class="FloatingLabel" id="maxTime" type="text" placeholder="تاریخ پیشنهای شروع پروژه" alt="تاریح شروع" />
                </div>
                <div class="inputDiv">
                    <input class="FloatingLabel" id="deadline" type="text" placeholder="تاریخ پیشنهای اتمام پروژه" alt="تاریخ اتمام" />
                </div>
                <div class="inputDiv">
                    <input class="FloatingLabel" id="budget" type="text" placeholder="بودجه" alt="بودجه" />
                </div>
                <div class="inputDiv">
                    <textarea class="FloatingLabel" id="description" placeholder="توضیحات مربوط به پروژه را اینجا بنویسید" alt="توضیحات"></textarea>
                </div>
            </div>
            <div class="location col-md-6 col-sm-6 col-xs-12">
                <div class="innerTitles">
                    محل اجرای پروژه
                </div>
                <div class="inputDiv">
                    <input class="FloatingLabel" id="state" type="text" placeholder="استان" alt="استان" />
                </div>
                <div class="inputDiv">
                    <input class="FloatingLabel" id="city" type="text" placeholder="شهر" alt="شهر" />
                </div>
                <div class="inputDiv">
                    <textarea class="FloatingLabel" id="address" placeholder="آدرس" alt="آدرس"></textarea>
                </div>
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <input class="btnSubmit" runat="server" type="button" value="ثبت درخواست" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Scripts" runat="server">
    <script src="../../_Scripts/FlotingLables.js"></script>
</asp:Content>
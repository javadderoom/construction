﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/UserPanel/UsersMaster.Master" AutoEventWireup="true" CodeBehind="ProjectApplication.aspx.cs" Inherits="WebPages.Panels.UserPanel.ProjectApplication" %>

<asp:Content ID="Content2" ContentPlaceHolderID="pageStyles" runat="server">
    <link href="../../_Styles/FloatingLable.css" rel="stylesheet" />
    <link href="../../_Styles/ProjectAppStyles.css" rel="stylesheet" />
    <link href="../../MdBootstrapPersianDateTimePicker/jquery.Bootstrap-PersianDateTimePicker.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
                    <input class="FloatingLabel" runat="server" id="title" type="text" placeholder="عنوان پروژه را وارد اینجا بنویسید" alt="عنوان" />
                </div>
                <div class="inputDiv">

                    <input class="FloatingLabel" runat="server" id="maxTime" type="text" placeholder="تاریخ پیشنهای شروع پروژه" alt="تاریح شروع" data-mddatetimepicker="true" data-disablebeforetoday="false" data-trigger="click" data-targetselector="#ContentPlaceHolder1_maxTime" data-groupid="group1" data-enabletimepicker="false" data-placement="left" />
                </div>
                <div class="inputDiv">
                    <input class="FloatingLabel" runat="server" id="deadline" type="text" placeholder="تاریخ پیشنهای اتمام پروژه" alt="تاریخ اتمام" data-mddatetimepicker="true" data-disablebeforetoday="false" data-trigger="click" data-targetselector="#ContentPlaceHolder1_deadline" data-groupid="group1" data-enabletimepicker="false" data-placement="left" />
                </div>
                <div class="inputDiv">
                    <input class="FloatingLabel" runat="server" id="budget" type="text" placeholder="بودجه" alt="بودجه" />
                </div>
                <div class="inputDiv">
                    <textarea class="FloatingLabel" runat="server" id="description" placeholder="توضیحات مربوط به پروژه را اینجا بنویسید" alt="توضیحات"></textarea>
                </div>
            </div>
            <div class="location col-md-6 col-sm-6 col-xs-12">
                <div class="innerTitles">
                    محل اجرای پروژه
                </div>
                <div class="inputDiv">
                    <asp:DropDownList ID="ddlState" runat="server" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </div>
                <div class="inputDiv">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlCity" runat="server"></asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlState" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>

                </div>
                <div class="inputDiv">
                    <textarea class="FloatingLabel" runat="server" id="address" placeholder="آدرس" alt="آدرس"></textarea>
                </div>
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <input class="btnSubmit" id="btnSabt" runat="server" type="button" value="ثبت درخواست" onclick="BtnSabt_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Scripts" runat="server">
    <script src="../../_Scripts/FlotingLables.js"></script>
    <script src="../../MdBootstrapPersianDateTimePicker/jalaali.js"></script>
    <script src="../../MdBootstrapPersianDateTimePicker/jquery.Bootstrap-PersianDateTimePicker.js"></script>


</asp:Content>

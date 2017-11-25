<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/Admin/NewAdminMaster.Master" EnableEventValidation="false" AutoEventWireup="true" ValidateRequest="false" CodeBehind="AddProject.aspx.cs" Inherits="WebPages.Panels.Admin.AddProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>افزودن پروژه</title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PageStyle" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section id="pageCover" class="row AddProjectHead">
        <div class="row pageTitle">افزودن پروژه</div>
        <div class="row pageBreadcrumbs">
            <ol class="breadcrumb" style="direction: rtl">
                <li><a href="/" style="color: #F7B71E">خانه</a></li>
                <li><span class="fa fa-arrow-left" style="color: #ffffff" aria-hidden="true"></span></li>
                <li class="active" style="color: #F7B71E">افزودن پروژه</li>
            </ol>
        </div>
    </section>
    <div id="container">

        <div class="form-group">

            <label for="title">عنوان :</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" SetFocusOnError="true" ControlToValidate="title" runat="server" CssClass="error" ErrorMessage="عنوان نمیتواند خالی باشد!"></asp:RequiredFieldValidator>

            <asp:TextBox ID="title" onkeydown="return (event.keyCode!=13);" Style="max-width: 500px; height: 40px;" placeholder="عنوان باید کوتاه و مفید باشد" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="Abstract">توضیح کوتاه : </label>
            <asp:RegularExpressionValidator Display="Dynamic" SetFocusOnError="true" ControlToValidate="Abstract" CssClass="error" ID="RegularExpressionValidator2" ValidationExpression="^[\s\S]{130,}$" runat="server" ErrorMessage="حداقل 130 کاراکتر وارد کنید"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" Display="Dynamic" SetFocusOnError="true" ControlToValidate="Abstract" runat="server" CssClass="error" ErrorMessage="متن توضیح نمیتواند خالی باشد!"></asp:RequiredFieldValidator>
            <asp:TextBox ID="Abstract" Style="max-width: 500px; height: 85px;" placeholder="حداقل تعداد حروف 130 عدد میباشد" Rows="5" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group text-right input-group">
            <label style="display: block" for="Abstract">عکس بالای پروژه : </label>
            <label class="btn btn-info" style="width: 100px;">
                <asp:Literal runat="server" Text="انتخاب عکس" />

                <asp:FileUpload ID="FileUpload1" runat="server" accept="image/*" CssClass="displaynone" BackColor="#CCCCCC" />
            </label>
            <label style="padding: 18px" id="filename"></label>

            <asp:RequiredFieldValidator Display="Dynamic" SetFocusOnError="true" ID="RequiredFieldValidator5" ControlToValidate="FileUpload1" runat="server" CssClass="error" ErrorMessage="هیچ عکسی انتخاب نشده است!"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label style="display: block" for="DDLGroups">گروه کاری : </label>
            <select id="DDLGroups" onchange="ddlGroups()" class="DDLClass"></select>
            <%-- <asp:DropDownList ID="DDLGroups" onchange="ddlGroups()" CssClass="DDLClass" runat="server"></asp:DropDownList>--%>

            <div runat="server" id="NoItemDiv" style="display: inline; padding: 25px; color: red;">
            </div>
        </div>
        <div class="form-group">
            <label>زیر گروه : </label>
            <div>

                <div class="Displayinline" id="upPan1">

                    <asp:ListBox ID="SubGroups" CssClass="LBXClass" runat="server"></asp:ListBox>
                </div>
                <div style="display: inline;">

                    <table style='width: 70px; display: inline'>
                        <tr>

                            <td style='width: 50px; text-align: center; vertical-align: middle;'>
                                <button id="addToSub" type="button" style="width: 50px; height: 20px;" onclick="AddSubGroups()">>></button>
                                <%--<asp:Button ID="AddToSub" Width="50px" OnClick="AddToSub_Click" OnClientClick="AddSubGroups() " CausesValidation="False" runat="server" Text=">>" />--%>
                                <br />
                                <br />
                                <button id="removeFromSub" type="button" style="width: 50px; height: 20px;" onclick="removeSubGroups()"><<</button>
                            </td>
                        </tr>
                    </table>
                </div>

                <div style="display: inline" id="upPan2">

                    <asp:ListBox ID="SelectedSubGroups" CssClass="LBXClass" runat="server"></asp:ListBox>
                </div>
            </div>
        </div>

        <div style="max-height: 870px">

            <asp:TextBox runat="server" ID="editor1" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="form-group" style="margin-top: 20px">
            <label for="KeyWords">کلمات کلیدی:</label>
            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" SetFocusOnError="true" ControlToValidate="KeyWords" runat="server" CssClass="error" ErrorMessage="کلمات کلیدی نمیتواند خالی باشد!"></asp:RequiredFieldValidator>

            <asp:TextBox ID="KeyWords" Style="max-width: 500px; height: 40px;" onkeydown="return (event.keyCode!=13);" data-role="tagsinput" placeholder="چند کلمه کلیدی وارد کنید" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Tags">برچسب ها:</label>
            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" SetFocusOnError="true" ControlToValidate="Tags" runat="server" CssClass="error" ErrorMessage="برچسب ها نمیتواند خالی باشد!"></asp:RequiredFieldValidator>

            <asp:TextBox ID="Tags" Style="max-width: 500px; height: 85px;" data-role="tagsinput" onkeydown="return (event.keyCode!=13);" placeholder="برچسب ها شبه جملاتی چند کلمه ای هستند" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Conditional" ChildrenAsTriggers="true" runat="server">
            <ContentTemplate>
                <div runat="server" class="error" id="diverror">
                </div>
                <div class="row">
                    <div class="col-md-5"></div>
                    <div class="col-md-2" style="text-align: center;">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn btn-success" Text="ادامه" />
                    </div>
                    <div class="col-md-5"></div>
                </div>
            </ContentTemplate>
            <Triggers>
                <%--<asp:AsyncPostBackTrigger ControlID="AddToSub" EventName="Click" />--%>
                <%--<asp:AsyncPostBackTrigger ControlID="RemoveFromSub" EventName="Click" />--%>
                <asp:PostBackTrigger ControlID="btnSave" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Script" runat="server">
    <script src="../../_Scripts/AddNews.js"></script>
    <script>

        $(document).ready(function ddlGroups() {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                //url is the path of our web method (Page name/function name)
                url: "/panels/admin/AddProject.aspx/getGroups",
                data: "{}",
                dataType: "json",
                //called on jquery ajax call success
                success: function (result) {
                    $('#DDLGroups').empty();
                    $('#DDLGroups').append("<option selected value='0'>یک گروه انتخاب کنید</option>");
                    $.each(result.d, function (key, value) {
                        $("#DDLGroups").append($("<option></option>").val(value.GroupID).html(value.Title));
                    });
                },

                //called on jquery ajax call failure
                error: function ajaxError(result) {
                    alert(result.status + ' : ' + result.statusText);
                }

            });
        });
        $(document).on("change", "select", function () {
            $("option[value=" + this.value + "]", this)
            .attr("selected", true).siblings()
            .removeAttr("selected")
        });
        function ddlGroups() {
            var s = $("#Content_ddlGroups").find("option:selected").prop("value");
            ;
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                //url is the path of our web method (Page name/function name)
                url: "/panels/admin/AddProject.aspx/getSubgroups",
                data: JSON.stringify({ Id: $('#DDLGroups').find(":selected").val() }),
                dataType: "json",
                //called on jquery ajax call success
                success: function (result) {
                    $('#Content_SubGroups').empty();

                    $.each(result.d, function (key, value) {
                        $("#Content_SubGroups").append($("<option></option>").val(value.GroupID).html(value.Title));

                    });
                },

                //called on jquery ajax call failure
                error: function ajaxError(result) {
                    alert(result.status + ' : ' + result.statusText);
                }
            });
        };
        function AddSubGroups() {
            $('#Content_NoItemDiv').html('')
            if ($('#Content_SubGroups').find(":selected").index() != -1) {
                var isadd = false;
                var text = $('#Content_SubGroups').find(":selected").text();
                var value = $('#Content_SubGroups').find(":selected").val();
                var myOpts = document.getElementById('Content_SelectedSubGroups').options;
                $("#Content_SelectedSubGroups option").each(function () {
                    var optionText = $(this).text()

                    if (optionText == text) {
                        isadd = true;
                    }
                });
                if (!isadd) {
                    $("#Content_SelectedSubGroups").append($("<option></option>").val(value).html(text));
                    $('#Content_btnSave').removeAttr("disabled");
                    $('#Content_diverror').html('');
                }
                else {
                    $('#Content_NoItemDiv').html('این مورد قبلا اضافه شده است')
                }

            }
            else {
                $('#Content_NoItemDiv').html('شما هیچ موردی را انتخاب نکرده اید!')
            }
        };
        function removeSubGroups() {
            $('#Content_NoItemDiv').html('')
            if ($('#Content_SelectedSubGroups').find(":selected").index() != -1) {

                $("#Content_SelectedSubGroups option:selected").remove();

            }
            else {
                $('#Content_NoItemDiv').html('شما هیچ موردی را انتخاب نکرده اید!')
            }
        }
        $('#Content_btnSave').click(function selectedGroups() {
            var arr = [];
            $("#Content_SelectedSubGroups  option").each(function () {
                arr.push($(this).val()); // this line push all text in array
            });
            ;
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                //url is the path of our web method (Page name/function name)
                url: "/panels/admin/AddProject.aspx/selectedGroups",
                data: JSON.stringify({ list: arr }),
                dataType: "json",
                //called on jquery ajax call success

                //called on jquery ajax call failure

            });
        });
    </script>
</asp:Content>
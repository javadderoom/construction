<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/Admin/NewAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageJobGroups.aspx.cs" Inherits="WebPages.Panels.Admin.ManageJobGroups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>مدیریت گروه های کاری</title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PageStyle" runat="server">
    <link href="../../_Styles/ManageGroups.css" rel="stylesheet" />
    <link href="../../_Styles/GridView.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="container">
        <h2 style="padding-right: 5px;">مدیریت گروه ها  :   </h2>

        <table class="InnerContainer" style="min-height: 590px;">
            <tr>
                <td style="text-align: center; padding-top: 5px;">
                    <input id="Button1" type="button" onclick="$('#modalNewGroup').modal('show');" class="btn btn-primary" value="گروه جدید" />
                    <input id="Button2" type="button" onclick="$('#modalNewSubGroup').modal('show');" class="btn btn-primary" value="زیرگروه جدید" />
                </td>
            </tr>
            <tr>

                <td class=" disp" style="margin-top: 40px;">

                    <h3>گروه های اصلی : </h3>
                    <asp:UpdatePanel ID="updatepanel2" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                        <ContentTemplate>

                            <asp:GridView ID="gvGroups" runat="server"
                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal"
                                AutoGenerateColumns="False" CssClass="dirRight table " Width="400"
                                AllowCustomPaging="False" AllowPaging="True"
                                OnRowCommand="gvGroups_RowCommand" OnPageIndexChanging="gvGroups_PageIndexChanging" PageSize="7">
                                <Columns>
                                    <asp:BoundField DataField="JobGroupID" HeaderText="شناسه" />
                                    <asp:BoundField DataField="JobGroupTitle" HeaderText="عنوان" />

                                    <asp:TemplateField>
                                        <ItemTemplate>

                                            <asp:Button ID="Edid" runat="server"
                                                CommandName="EditRow"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                Text="ویرایش" />

                                            <asp:Button OnClientClick="if(!confirm('با حذف این گروه زیر گروه های مربوط به آن وارتباطشان با مقاله ها\n (درصورت وجود) هم از بین میروند!\nآیا برای حذف اطمینان دارید؟')) return false;" ID="Delet" runat="server"
                                                CommandName="Delet"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                Text="حذف" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <PagerStyle HorizontalAlign="center" CssClass="GridPager" />
                                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                <SortedDescendingHeaderStyle BackColor="#242121" />
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnSaveGroupChange" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btnSaveNewGroup" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <asp:UpdateProgress ID="updateProgress1" runat="server" DisplayAfter="0">
                        <ProgressTemplate>
                            <div style="position: fixed; text-align: center; height: 100%; padding-top: 100px; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #ffffff; opacity: 0.8;">
                                <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/_construction/images/44frgm.gif" AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; top: 45%; left: 50%;" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </td>
                <td class="disp">

                    <asp:UpdatePanel ID="updatepanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                        <ContentTemplate>
                            <h3>زیر گروه ها : </h3>
                            <div>
                                <asp:DropDownList ID="ddlGroups" AutoPostBack="true" CssClass="DDLClass" OnSelectedIndexChanged="ddlGroups_SelectedIndexChanged" runat="server"></asp:DropDownList>
                            </div>
                            <asp:GridView ID="gvSubGroups" runat="server"
                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal"
                                AutoGenerateColumns="False" CssClass="dirRight table " Width="400"
                                AllowCustomPaging="False" AllowPaging="True"
                                OnRowCommand="gvSubGroups_RowCommand" OnPageIndexChanging="gvSubGroups_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="JobID" HeaderText="شناسه" />
                                    <asp:BoundField DataField="JobTitle" HeaderText="عنوان" />

                                    <asp:TemplateField>
                                        <ItemTemplate>

                                            <asp:Button ID="Edit" runat="server"
                                                CommandName="EditRow"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                Text="ویرایش" />

                                            <asp:Button OnClientClick="if(!confirm('حذف این زیر گروه باعث حذف ارتباطش(در صورت وجود) با مقالات میشود،\nآیا برای حذف اطمینان دارید؟')) return false;" ID="Button1" runat="server"
                                                CommandName="Delet"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                Text="حذف" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <PagerStyle HorizontalAlign="center" CssClass="GridPager" />
                                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                <SortedDescendingHeaderStyle BackColor="#242121" />
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlGroups" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="gvGroups" EventName="RowCommand" />
                            <asp:AsyncPostBackTrigger ControlID="btnSaveSubGroupChane" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btnSaveNewGroup" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btnSaveNewSub" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <asp:UpdateProgress ID="updateProgress2" runat="server" DisplayAfter="0">
                        <ProgressTemplate>
                            <div style="position: fixed; text-align: center; height: 100%; padding-top: 100px; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #ffffff; opacity: 0.8;">
                                <asp:Image ID="imgUpdateProgress2" runat="server" ImageUrl="~/_construction/images/44frgm.gif" AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; top: 45%; left: 50%;" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </td>
            </tr>
        </table>
    </div>

    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>

            <div class="modal fade" id="modalShowGroupDetails" tabindex="-1" role="dialog" aria-labelledby="modalAskSubmitUpdate-label" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" id="btnClose" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                            <h4 class="modal-title" id="modalAskSubmitUpdate-label">

                                <span class="glyphicon glyphicon-warning-sign"></span>
                                ویرایش گروه
                            </h4>
                        </div>
                        <div class="modal-body" id="divtoprint">

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-12 " style="direction: rtl!important;">
                                        <span class="control-label formLabel text-right" style="font-size: 100%; font-weight: bold;">
                                            <asp:Literal runat="server" Text=" شناسه : " />
                                            <asp:Literal runat="server" ID="IDholder" Text="" />
                                        </span>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-12 " style="direction: rtl!important;">
                                        <span id="ContentPlaceHolder1_lbl_Email" class="control-label formLabel text-right" style="font-size: 100%; font-weight: bold;">
                                            <asp:Literal runat="server" Text=" نام قبلی : " />
                                        </span>
                                    </div>

                                    <div class="col-xs-12  ">
                                        <span id="tbxOldName" runat="server" class="form-control control-label formLabel text-right"></span>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-12 " style="direction: rtl!important;">
                                        <span id="ContentPlaceHolder1_lbl_Address" class="control-label formLabel text-right" style="font-size: 100%; font-weight: bold;">
                                            <asp:Literal runat="server" Text=" نام جدید : " />
                                        </span>
                                    </div>

                                    <div class="col-xs-12 ">
                                        <asp:TextBox ID="tbxNewName" runat="server" class="form-control text-right dirRight"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <div class="row">
                                <div class="col-xs-12 text-center">
                                    <asp:Button ID="btnSaveGroupChange" onkeydown="return (event.keyCode!=13);" runat="server" OnClick="btnSaveGroupChange_Click" class="btn btn-success" Text="ذخیره" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>

        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSaveGroupChange" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="updateProgress3" runat="server" DisplayAfter="0">
        <ProgressTemplate>
            <div style="position: fixed; text-align: center; height: 100%; padding-top: 100px; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #ffffff; opacity: 0.8;">
                <asp:Image ID="imgUpdateProgress3" runat="server" ImageUrl="~/_construction/images/44frgm.gif" AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; top: 45%; left: 50%;" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>

            <div class="modal fade" id="modalShowSubGroupDetails" tabindex="-1" role="dialog" aria-labelledby="modalAskSubmitUpdate-label" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                            <h4 class="modal-title">

                                <span class="glyphicon glyphicon-warning-sign"></span>
                                ویرایش گروه
                            </h4>
                        </div>
                        <div class="modal-body">

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-12 " style="direction: rtl!important;">
                                        <span class="control-label formLabel text-right" style="font-size: 100%; font-weight: bold;">
                                            <asp:Literal runat="server" Text=" شناسه : " />
                                            <asp:Literal runat="server" ID="SubIDHolder" Text="" />
                                        </span>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-12 " style="direction: rtl!important;">
                                        <span class="control-label formLabel text-right" style="font-size: 100%; font-weight: bold;">
                                            <asp:Literal runat="server" Text=" نام قبلی : " />
                                        </span>
                                    </div>

                                    <div class="col-xs-12  ">
                                        <span id="SubOldName" runat="server" class="form-control control-label formLabel text-right"></span>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-12 " style="direction: rtl!important;">
                                        <span class="control-label formLabel text-right" style="font-size: 100%; font-weight: bold;">
                                            <asp:Literal runat="server" Text=" نام جدید : " />
                                        </span>
                                    </div>

                                    <div class="col-xs-12 ">
                                        <asp:TextBox ID="SubNewName" onkeydown="return (event.keyCode!=13);" runat="server" class="form-control text-right dirRight"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <div class="row">
                                <div class="col-xs-12 text-center">
                                    <asp:Button ID="btnSaveSubGroupChane" runat="server" OnClick="btnSaveSubGroupChane_Click" class="btn btn-success" Text="ذخیره" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>

        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSaveSubGroupChane" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="updateProgress4" runat="server" DisplayAfter="0">
        <ProgressTemplate>
            <div style="position: fixed; text-align: center; height: 100%; padding-top: 100px; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #ffffff; opacity: 0.8;">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/_construction/images/44frgm.gif" AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; top: 45%; left: 50%;" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
        <ContentTemplate>

            <div class="modal fade" id="modalNewGroup" tabindex="-1" role="dialog" aria-labelledby="modalAskSubmitUpdate-label" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                            <h4 class="modal-title">

                                <span class="glyphicon glyphicon-warning-sign"></span>
                                گروه جدید
                            </h4>
                        </div>
                        <div class="modal-body">

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-12 " style="direction: rtl!important;">
                                        <span class="control-label formLabel text-right" style="font-size: 100%; font-weight: bold;">
                                            <asp:Literal runat="server" Text=" نام گروه جدید : " />
                                        </span>
                                    </div>

                                    <div class="col-xs-12 ">
                                        <asp:TextBox ID="tbxNewGroup" onkeydown="return (event.keyCode!=13);" runat="server" class="form-control text-right dirRight"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <div class="row">
                                <div class="col-xs-12 text-center">
                                    <asp:Button ID="btnSaveNewGroup" runat="server" OnClick="btnSaveNewGroup_Click" class="btn btn-success" Text="ذخیره" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>

        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSaveSubGroupChane" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="updateProgress5" runat="server" DisplayAfter="0">
        <ProgressTemplate>
            <div style="position: fixed; text-align: center; height: 100%; padding-top: 100px; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #ffffff; opacity: 0.8;">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/_construction/images/44frgm.gif" AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; top: 45%; left: 50%;" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
        <ContentTemplate>

            <div class="modal fade" id="modalNewSubGroup" tabindex="-1" role="dialog" aria-labelledby="modalAskSubmitUpdate-label" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                            <h4 class="modal-title">

                                <span class="glyphicon glyphicon-warning-sign"></span>
                                افزودن زیرگروه
                            </h4>
                        </div>
                        <div class="modal-body">

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-12 " style="direction: rtl!important;">
                                        <span class="control-label formLabel text-right" style="font-size: 100%; font-weight: bold;">
                                            <asp:Literal runat="server" Text=" گروه اصلی : " />
                                            <asp:DropDownList ID="ddlgroupsForModal" runat="server"></asp:DropDownList>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-12 " style="direction: rtl!important;">
                                        <span class="control-label formLabel text-right" style="font-size: 100%; font-weight: bold;">
                                            <asp:Literal runat="server" Text=" نام زیر گروه جدید : " />
                                        </span>
                                    </div>

                                    <div class="col-xs-12 ">
                                        <asp:TextBox ID="tbxNewSubGroupName" onkeydown="return (event.keyCode!=13);" runat="server" class="form-control text-right dirRight"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-12 " style="direction: rtl!important;">
                                        <div style="font-size: 100%; text-align: center; font-weight: bold;">
                                            <asp:Button ID="btnAddNewSub" OnClick="btnAddNewSub_Click" CssClass="btn btn-primary" runat="server" Text="افزودن" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-12 " style="direction: rtl!important;">
                                        <span class="control-label formLabel text-right" style="font-size: 100%; font-weight: bold;">
                                            <asp:Literal runat="server" Text=" زیر گروه های جدید : " />
                                        </span>
                                    </div>

                                    <div class="col-xs-12  " style="direction: rtl">
                                        <asp:ListBox ID="lbxSubs" Width="200px" runat="server"></asp:ListBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="modal-footer">
                            <div class="row">
                                <div class="col-xs-12 text-center">
                                    <asp:Button ID="btnSaveNewSub" runat="server" OnClick="btnSaveNewSub_Click" class="btn btn-success" Text="ذخیره" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSaveSubGroupChane" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSaveNewSub" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnAddNewSub" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="updateProgress6" runat="server" DisplayAfter="0">
        <ProgressTemplate>
            <div style="position: fixed; text-align: center; height: 100%; padding-top: 100px; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #ffffff; opacity: 0.8;">
                <asp:Image ID="imgUpdateProgress4" runat="server" ImageUrl="~/_construction/images/44frgm.gif" AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; top: 45%; left: 50%;" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Script" runat="server">
    <script>
        $(document).ready(function () {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                //url is the path of our web method (Page name/function name)
                url: "ManageJobGroups.aspx/getJobGroups",
                data: "{}",
                dataType: "json",
                //called on jquery ajax call success
                success: function (result) {
                    $('#ddlDepartments').empty();
                    $('#ddlDepartments').append("<option value='0'>--Select--</option>");
                    $.each(result.d, function (key, value) {
                        $("#ddlDepartments").append($("<option></option>").val(value.DeptId).html(value.DeptName));
                    });
                },
                //called on jquery ajax call failure
                error: function ajaxError(result) {
                    alert(result.status + ' : ' + result.statusText);
                }
            });
        });
    </script>
</asp:Content>
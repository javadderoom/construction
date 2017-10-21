<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/Admin/NewAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageGroups.aspx.cs" Inherits="WebPages.Panels.Admin.ManageGroups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageStyle" runat="server">
    <link href="../../_Styles/ManageGroups.css" rel="stylesheet" />
    <link href="../../_Styles/GridView.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="container">
        <h2 style="padding-right: 5px;">مدیریت گروه ها  :   </h2>

        <table class="InnerContainer">

            <tr>

                <td class="disp" style="padding-right: 20px;">

                    <h3>گروه های اصلی : </h3>
                    <asp:UpdatePanel ID="updatepanel2" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                        <ContentTemplate>

                            <asp:GridView ID="gvGroups" runat="server"
                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal"
                                AutoGenerateColumns="False" CssClass="dirRight table " Width="400"
                                AllowCustomPaging="True" AllowPaging="True"
                                OnRowCommand="gvGroups_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="GroupID" HeaderText="شناسه" />
                                    <asp:BoundField DataField="Title" HeaderText="عنوان" />

                                    <asp:TemplateField>
                                        <ItemTemplate>

                                            <asp:Button ID="Edid" runat="server"
                                                CommandName="EditRow"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                Text="ویرایش" />

                                            <asp:Button OnClientClick="if(!confirm('ایا برای حذف مطمئن هستید؟')) return false;" ID="Delet" runat="server"
                                                CommandName="Delet"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                Text="حذف" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                <SortedDescendingHeaderStyle BackColor="#242121" />
                            </asp:GridView>
                        </ContentTemplate>
                        <%--<Triggers>
                        </Triggers>--%>
                    </asp:UpdatePanel>
                </td>
                <td class="disp" style="padding-top: 40px; padding-right: 20px">
                    <h3>زیر گروه ها : </h3>
                    <div>
                        <asp:DropDownList ID="ddlGroups" CssClass="DDLClass" runat="server"></asp:DropDownList>
                    </div>
                    <asp:UpdatePanel ID="updatepanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                        <ContentTemplate>

                            <asp:GridView ID="gvSubGroups" runat="server"
                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal"
                                AutoGenerateColumns="False" CssClass="dirRight table " Width="400"
                                AllowCustomPaging="True" AllowPaging="True"
                                OnRowCommand="gvGroups_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="GroupID" HeaderText="شناسه" />
                                    <asp:BoundField DataField="Title" HeaderText="عنوان" />

                                    <asp:TemplateField>
                                        <ItemTemplate>

                                            <asp:Button ID="Edid" runat="server"
                                                CommandName="Edit"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                Text="ویرایش" />

                                            <asp:Button OnClientClick="if(!confirm('ایا برای حذف مطمئن هستید؟')) return false;" ID="Delet" runat="server"
                                                CommandName="Delet"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                Text="حذف" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                <SortedDescendingHeaderStyle BackColor="#242121" />
                            </asp:GridView>
                        </ContentTemplate>
                        <%-- <Triggers>
                        </Triggers>--%>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>

        <input type="button" value="j,hvhv," onclick="$('#modalShowGroupDetails').modal('show');" />
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
                                            <asp:Literal runat="server" Text=" نام قبلی : " />
                                            <asp:Literal runat="server" ID="IDholder" Text="" />
                                        </span>
                                    </div>

                                    <div class="col-xs-12  ">
                                        <span id="Span1" runat="server" class="form-control control-label formLabel"></span>
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
                                    <button type="button" class="btn btn-default " data-dismiss="modal">
                                        <asp:Literal runat="server" Text="Resources:Dashboard,back" />
                                    </button>
                                    <input name="b_print2" type="button" class="btn btn-primary" data-dismiss="modal" value=" پرینت " />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <%-- <Triggers>
            <asp:AsyncPostBackTrigger ControlID="gvGroups" EventName="RowCommand" />
        </Triggers>--%>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Script" runat="server">
</asp:Content>
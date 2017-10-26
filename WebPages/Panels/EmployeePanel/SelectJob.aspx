<%@ Page Title="" Language="C#" MasterPageFile="~/Panels/EmployeePanel/EmployeeMaster.Master" AutoEventWireup="true" CodeBehind="SelectJob.aspx.cs" Inherits="WebPages.Panels.EmployeePanel.SelectJob" %>

<asp:Content ID="Content2" ContentPlaceHolderID="pageStyles" runat="server">
    <link href="../../_Styles/ProfileStyles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
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
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div style="direction: rtl; margin-right: 200px">
        <div class="form-group">
            <label style="display: block" for="DDLGroups">گروه کاری : </label>
            <asp:DropDownList ID="DDLGroups" OnSelectedIndexChanged="DDLGroups_SelectedIndexChanged" AutoPostBack="true" CssClass="DDLClass" runat="server"></asp:DropDownList>
            <div class="Displayinline" id="upPan3">
                <asp:UpdatePanel ID="updatepanel4" runat="server">
                    <ContentTemplate>
                        <div runat="server" id="NoItemDiv" style="display: inline; padding: 25px;">
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DDLGroups" EventName="SelectedIndexChanged" />

                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="form-group">
            <label>زیر گروه : </label>
            <div>

                <div class="Displayinline" id="upPan1">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:ListBox ID="SubGroups" CssClass="LBXClass" runat="server" Height="200"></asp:ListBox>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DDLGroups" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="RemoveFromSub" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="AddToSub" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>

                </div>
                <div style="display: inline;">

                    <table style='width: 70px; display: inline'>
                        <tr>

                            <td style='width: 50px; text-align: center; vertical-align: middle;'>
                                <asp:Button ID="AddToSub" Width="50px" OnClick="AddToSub_Click" CausesValidation="False" runat="server" Text=">>" />
                                <br />
                                <br />
                                <asp:Button ID="RemoveFromSub" Width="50px" OnClick="RemoveFromSub_Click" CausesValidation="False" runat="server" Text="<<" />
                            </td>
                        </tr>
                    </table>

                </div>

                <div style="display: inline" id="upPan2">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:ListBox ID="SelectedSubGroups" CssClass="LBXClass" runat="server" Height="200"></asp:ListBox>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="AddToSub" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="RemoveFromSub" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>

                </div>
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>

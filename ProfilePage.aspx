<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ProfilePage.aspx.cs" Inherits="ProfilePage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table style="width: 100%; margin-top: 50px;" border="0">
        <tr>
            <td style=" width:15%;">
                <asp:Image runat="server" Height="100px" ImageUrl="~/Images/no-image.gif" Width="100px" />
            </td>
            <td style=" width:85%;  text-align: left;">
                <table style=" text-align: left;">
                    <tr>
                        <td>
                            <asp:Label ID="lblname" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblage" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblmale" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblemail" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 70%; float:right;" valign="top">
               <asp:HyperLink ID="lnkeditinfo" runat="server" Text="Edit" NavigateUrl="~/EditInfo.aspx"></asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                Notification Area
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Button runat="server" Text="Ask Question" PostBackUrl="~/AddQuestion.aspx" Style="background-color: #4B6C9E;
                                color: White; cursor: pointer; width: 100px; height: 30px; border-collapse: collapse;
                                border-style: none; font-weight: bold; float: right;" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%;">
                            <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="lbtnFirst" />
                                    <asp:PostBackTrigger ControlID="lbtnPrevious" />
                                    <asp:PostBackTrigger ControlID="lbtnLast" />
                                    <asp:PostBackTrigger ControlID="lbtnNext" />
                                </Triggers>
                                <ContentTemplate>
                                    <div style="font-weight: bold; font-size: large; vertical-align: top;">
                                        My Questions
                                    </div>
                                    <asp:DataList runat="server" ID="DlstQuestion" runat="server" OnItemDataBound="DlstQuestion_ItemDataBound"
                                        Width="100%">
                                        <AlternatingItemStyle CssClass="AlternateItemonHover" />
                                        <ItemStyle CssClass="ItemonHover" />
                                        <ItemTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:HyperLink ID="lnkQuestionTitle" runat="server"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label runat="server" ID="LblAskedon"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:DataList>
                                    <table width="100%" cellpadding="0" border="0">
                                        <tr>
                                            <td align="center">
                                                <asp:LinkButton ID="lbtnFirst" runat="server" CausesValidation="false" OnClick="lbtnFirst_Click">First</asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton ID="lbtnPrevious" runat="server" CausesValidation="false" OnClick="lbtnPrevious_Click">Previous</asp:LinkButton>&nbsp;&nbsp;
                                                &nbsp;&nbsp;<asp:LinkButton ID="lbtnNext" runat="server" CausesValidation="false"
                                                    OnClick="lbtnNext_Click">Next</asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton ID="lbtnLast" runat="server" CausesValidation="false" OnClick="lbtnLast_Click">Last</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5" align="center" style="height: 30px" valign="middle">
                                                <asp:Label ID="lblPageInfo" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%;" valign="top">
                            <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional">
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="AlbtnFirst" />
                                    <asp:PostBackTrigger ControlID="AlbtnPrevious" />
                                    <asp:PostBackTrigger ControlID="AlbtnLast" />
                                    <asp:PostBackTrigger ControlID="AlbtnNext" />
                                </Triggers>
                                <ContentTemplate>
                                    <div style="font-weight: bold; font-size: large; vertical-align: top;">
                                        My Answer
                                    </div>
                                    <asp:DataList runat="server" ID="datlstAnswer" OnItemDataBound="datlstAnswer_ItemDataBound">
                                        <AlternatingItemStyle CssClass="AlternateItemonHover" Width="100%" />
                                        <ItemStyle CssClass="ItemonHover" />
                                        <ItemTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:HyperLink ID="lnkQuestionTitle" runat="server"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label runat="server" ID="LblAskedon"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:DataList>
                                    <table width="100%" cellpadding="0" border="0">
                                        <tr>
                                            <td align="center">
                                                <asp:LinkButton ID="AlbtnFirst" runat="server" CausesValidation="false" OnClick="AlbtnFirst_Click">First</asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton ID="AlbtnPrevious" runat="server" CausesValidation="false" OnClick="AlbtnPrevious_Click">Previous</asp:LinkButton>&nbsp;&nbsp;
                                                &nbsp;&nbsp;<asp:LinkButton ID="AlbtnNext" runat="server" CausesValidation="false"
                                                    OnClick="AlbtnNext_Click">Next</asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton ID="AlbtnLast" runat="server" CausesValidation="false" OnClick="AlbtnLast_Click">Last</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5" align="center" style="height: 30px" valign="middle">
                                                <asp:Label ID="AlblPageInfo" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

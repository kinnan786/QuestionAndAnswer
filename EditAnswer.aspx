<%@ Page Title="" Language="C#" MasterPageFile="~/Nestedmaster.master" AutoEventWireup="true"
    CodeFile="EditAnswer.aspx.cs" Inherits="EditAnswer" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ProfileMasterPageLeftContent" runat="Server">
    <table width="100%" style="border-collapse: collapse; margin-top: 50px;">
        <tr>
            <td>
                <table width="750px" border="0" style="border-collapse: collapse;">
                    <tr>
                        <td style="width: 750px;" colspan="2">
                            Question?
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Tags:
                            <div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10%">
                            Title: &nbsp;
                        </td>
                        <td style="width: 90%">
                            <asp:Label runat="server" Text="Question Title"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="width: 90%">
                            <asp:Label runat="server" Text="Question Description"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding: 25px 0px 10px 0px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 750px;" colspan="2">
                            Answer
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:TextBox TextMode="MultiLine" runat="server" Style="width: 700px; height: 400px;
                                vertical-align: top;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td style="float: right;">
                            <asp:Button runat="server" Text="Cancel" Style="background-color: #4B6C9E; color: White;
                                cursor: pointer; width: 100px; height: 30px; border-collapse: collapse; border-style: none;
                                font-weight: bold;" />
                            <asp:Button runat="server" Text="Save Edit" Style="background-color: #4B6C9E; color: White;
                                cursor: pointer; width: 100px; height: 30px; border-collapse: collapse; border-style: none;
                                font-weight: bold;" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>

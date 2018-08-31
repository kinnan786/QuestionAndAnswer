<%@ Page Title="" Language="C#" MasterPageFile="~/Nestedmaster.master" AutoEventWireup="true"
    CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ProfileMasterPageLeftContent" runat="Server">
    <div style="font-size: x-large; font-weight: bold;">
        Question
        <br />
        <hr />
    </div>
    <asp:DataList ID="DataListQuestion" runat="server" Width="100%" OnItemDataBound="DataListQuestion_ItemDataBound">
        <AlternatingItemStyle />
        <ItemStyle />
        <ItemTemplate>
            <table class="ItemonHover" cellpadding="5px" width="100%"  >
            <tr>
                <td style=" margin-bottom:-8px; float:right;"></td>
            </tr>
                <tr>
                    <td valign="top" style=" border-top-width:thin; border-top-style:dashed;">
                        <asp:HyperLink ID="lnkQuestionTitle" runat="server"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:Literal ID="ltrdesc" runat="server" ></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:Label runat="server" ID="LblAskedon"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
        </ItemTemplate>
    </asp:DataList>
    <br /><br />
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
</asp:Content>

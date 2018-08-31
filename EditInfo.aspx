<%@ Page Title="" Language="C#" MasterPageFile="~/Nestedmaster.master" AutoEventWireup="true"
    CodeFile="EditInfo.aspx.cs" Inherits="EditInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NestedHeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ProfileMasterPageLeftContent" runat="Server">
    <table width="100%">
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td>
                            First Name
                        </td>
                        <td>
                            <asp:TextBox ID="TxtFname" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Last Name
                        </td>
                        <td>
                            <asp:TextBox ID="TxtLname" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            sex
                        </td>
                        <td>
                            <asp:DropDownList ID="drlstsex" runat="server">
                                <asp:ListItem Text="Select" Value="select">Select</asp:ListItem>
                                <asp:ListItem Text="Male" Value="Male">Male</asp:ListItem>
                                <asp:ListItem Text="Female" Value="Female">Female</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Email
                        </td>
                        <td>
                            <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Password
                        </td>
                        <td>
                            <asp:TextBox ID="TxtPass" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Retype Password
                        </td>
                        <td>
                            <asp:TextBox ID="ReTxtPass" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnupdate" runat="server" Text="Update" />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <asp:Image ID="imgpic" runat="server" ImageUrl="~/Images/no-image.gif" Height="100px"
                    Width="100px" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ProfileMasterPageRightContent" runat="Server">
</asp:Content>

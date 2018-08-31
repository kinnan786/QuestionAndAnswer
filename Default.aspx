<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head runat="server">
    <t3itle></title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
    <div class="page">
        <div class="header">
            <div class="title">
                <h1>
                </h1>
            </div>
            <div class="loginDisplay">
                Email:&nbsp;<asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
                &nbsp;
                Password: &nbsp;<asp:TextBox ID="txtpassword" TextMode="Password" runat="server"></asp:TextBox>
                &nbsp;
                <asp:Button runat="server" ID="btnlogin"  Text="Log in" Style="background-color: #4B6C9E; color: White;
                    cursor: pointer; width: 60px; height: 25px; border-collapse: collapse; border-style: groove;
                    font-weight: bold;" onclick="btnlogin_Click" />
            </div>
        </div>
        <div style="min-height: 600px; padding-left: 50px; padding-top: 20px; padding-right: 10px;">
            <table width="100%" border="0" style="border-collapse: collapse;">
                <tr>
                    <td valign="top" style="width: 75%;">
                        Description & stats
                    </td>
                    <td valign="top" style="width: 25%; text-align: center;">
                        <br />
                        <br />
                        <asp:Button runat="server" ID="btnregister" Text="Register" PostBackUrl="~/Register.aspx" Style="background-color: #4B6C9E; color: White;
                            cursor: pointer; width: 100px; height: 30px; border-collapse: collapse; border-style: none;
                            font-weight: bold;" />
                        <br />
                        <br />
                        <asp:Button ID="btnaskquestion" PostBackUrl="~/AddQuestion.aspx" runat="server" Text="Ask Question" Style="background-color: #4B6C9E;
                            color: White; cursor: pointer; width: 100px; height: 30px; border-collapse: collapse;
                            border-style: none; font-weight: bold;" />
                        <br />
                        <br />
                        <asp:Button runat="server" ID="btnAnswerquestion" Text="Answer Question" Style="background-color: #4B6C9E;
                            color: White; cursor: pointer; width: 150px; height: 30px; border-collapse: collapse;
                            border-style: none; font-weight: bold;" />
                        <br />
                    </td>
                </tr>
            </table>
        </div>
        <div class="footer">
            <asp:HyperLink runat="server">About</asp:HyperLink>&nbsp;
            <asp:HyperLink runat="server">Contact Us</asp:HyperLink>&nbsp;
            <asp:HyperLink runat="server">Advertisment</asp:HyperLink>&nbsp;
            <asp:HyperLink runat="server">Help</asp:HyperLink>&nbsp;
            <asp:HyperLink runat="server">Privacy</asp:HyperLink>&nbsp;
        </div>
    </form>
</body>
</html>

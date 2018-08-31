<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Login" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="text-align: center; padding: 200px 0px 0px 200px;">
        <table>
            <tr>
                <th colspan="2">
                    Login
                </th>
            </tr>
            <tr>
                <td style=" text-align:left;">
                    Email: 
                </td>
                <td>
                    <asp:TextBox runat="server" Style="height: 20px; width: 200px;" id="TxtEmail" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style=" text-align:left;">
                    Password: 
                </td>
                <td>
                    <asp:TextBox runat="server" Style="height: 20px; width: 200px;" id="txtpassword" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    </td>
                <td>
                    <div id="divmessage" runat="server" style=" color:Red; display:none;">
                        Cannot login Wrong passwrod
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    
                </td>
                <td>
                     <asp:Button ID="BtnLogin" runat="server" Text="Log in" 
                         style=" background-color:#4B6C9E; color:White; cursor:pointer; width:100px; height:30px; border-collapse:collapse; border-style:none; font-weight:bold; " 
                         onclick="BtnLogin_Click" />

                </td>
            </tr>
        </table>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="text-align: center;">
        <table style="padding: 100px 0px 0px 200px; text-align: left;">
            <tr>
                <th colspan="2">
                    <center>
                        REGISTER</center>
                </th>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td>
                    First Name:
                </td>
                <td>
                    <asp:TextBox ID="TxtFname" runat="server" Style="height: 20px; width: 220px;"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Last Name:
                </td>
                <td>
                    <asp:TextBox ID="TxtLname" runat="server" Style="height: 20px; width: 220px;"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Your email:
                </td>
                <td>
                    <asp:TextBox ID="TxtEmail" runat="server" Style="height: 20px; width: 220px;"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Re-enter email:
                </td>
                <td>
                    <asp:TextBox runat="server" Style="height: 20px; width: 220px;"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    New Password:
                </td>
                <td>
                    <asp:TextBox ID="TxtPass" TextMode="Password" runat="server" Style="height: 20px; width: 220px;"  ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Sex:
                </td>
                <td>
                    <asp:DropDownList ID="drplstsex" runat="server" Style="width: 100px;">
                        <asp:ListItem Selected="True">Sex</asp:ListItem>
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Birthday
                </td>
                <td>
                    <asp:DropDownList ID="drplstmonth" runat="server" Style="width: 100px;">
                        <asp:ListItem Selected="True">Months</asp:ListItem>
                        <asp:ListItem Value="1">January</asp:ListItem>
                        <asp:ListItem Value="2">February</asp:ListItem>
                        <asp:ListItem Value="3">March</asp:ListItem>
                        <asp:ListItem Value="4">April</asp:ListItem>
                        <asp:ListItem Value="5">May</asp:ListItem>
                        <asp:ListItem Value="6">June</asp:ListItem>
                        <asp:ListItem Value="7">July</asp:ListItem>
                        <asp:ListItem Value="8">August</asp:ListItem>
                        <asp:ListItem Value="9">September</asp:ListItem>
                        <asp:ListItem Value="10">October</asp:ListItem>
                        <asp:ListItem Value="11">November</asp:ListItem>
                        <asp:ListItem Value="12">December</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="drplstday" runat="server">
                        <asp:ListItem Selected="True">Day</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>26</asp:ListItem>
                        <asp:ListItem>27</asp:ListItem>
                        <asp:ListItem>28</asp:ListItem>
                        <asp:ListItem>29</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>31</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="drplstyear" runat="server">
                        <asp:ListItem Selected="True">Years</asp:ListItem>
                        <asp:ListItem>1999</asp:ListItem>
                        <asp:ListItem>2000</asp:ListItem>
                        <asp:ListItem>3000</asp:ListItem>
                        <asp:ListItem>4000</asp:ListItem>
                        <asp:ListItem>5000</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <div id="divmessage" runat="server" style="color: Red; display: none;">
                        Cannot Register User exists
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="BtnRegister" runat="server" Text="Register" Style="background-color: #4B6C9E;
                        color: White; cursor: pointer; width: 100px; height: 30px; border-collapse: collapse;
                        border-style: none; font-weight: bold;" OnClick="BtnRegister_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

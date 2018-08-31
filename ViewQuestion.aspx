<%@ Page Title="" Language="C#" MasterPageFile="~/Nestedmaster.master" AutoEventWireup="true"
    CodeFile="ViewQuestion.aspx.cs" Inherits="ViewQuestion" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NestedHeadContent" runat="server">
    <script type="text/javascript" language="javascript">
        function upvotequestion() {
            var resultActual = GetSynchronousJSONResponse('<%= Page.ResolveUrl("ViewQuestion.aspx/UpvoteQuestion")%>');

            result = eval('(' + resultActual + ')');

            if (result.d == 1)
                return true;
            else {
                alert("Not register");
                return false;
            }
        }

        function downvotequestion() {
            var resultActual = GetSynchronousJSONResponse('<%= Page.ResolveUrl("ViewQuestion.aspx/DownvoteQuestion")%>');
            result = eval('(' + resultActual + ')');
            if (typeof (result.d) == 'undefined') {
                return resultActual;
            }
            else if (result.d != "-1") {
                return result.d;
            }
        }

        function GetSynchronousJSONResponse(url, postData) {

            var xmlhttp = null;
            if (window.XMLHttpRequest)
                xmlhttp = new XMLHttpRequest();
            else if (window.ActiveXObject) {
                if (new ActiveXObject("Microsoft.XMLHTTP"))
                    xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                else
                    xmlhttp = new ActiveXObject("Msxml2.XMLHTTP");
            }
            // to be ensure non-cached version of response
            url = url + "?rnd=" + Math.random();

            xmlhttp.open("POST", url, true); //false means synchronous
            xmlhttp.setRequestHeader("Content-Type", "application/json; charset=utf-8");
            xmlhttp.send(postData);
            var responseText = xmlhttp.responseText;
            return responseText;
        }

        function upvoteanswer(id) {
            var resultActual = GetSynchronousJSONResponse('<%= Page.ResolveUrl("ViewQuestion.aspx/UpvoteAnswer")%>', '{"answerid":"' + id + '"}');

            if (result.d == 1)
                return true;
            else {
                alert("Not register");
                return false;
            }

        }

        function downvoteanswer(id) {
            var resultActual = GetSynchronousJSONResponse('<%= Page.ResolveUrl("ViewQuestion.aspx/DownvoteAnswer")%>', '{"answerid":"' + id + '"}');
            result = eval('(' + resultActual + ')');

            if (result.d == 1)
                return true;
            else {
                alert("Not register");
                return false;
            }   
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ProfileMasterPageLeftContent" runat="Server">
    <asp:HiddenField runat="server" ID="hdnquestionid" Value="" />
    <table width="100%" border="0" style="border-collapse: collapse; vertical-align: text-top;"
        border="0">
        <tr>
            <td valign="top">
                <asp:Label ID="LblQTitle" Style="font-size: x-large; font-weight: bold;" runat="server"
                    Text="Question Title"></asp:Label>
                <br />
                <span id="divTags" runat="server">Tags</span>
                <hr />
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:UpdatePanel ID="QPanel" runat="server">
                    <Triggers>
                    
                        <asp:PostBackTrigger ControlID="Qup" />
                        <asp:PostBackTrigger ControlID="Qdown" />
                    </Triggers>
                    <ContentTemplate>
                        <table width="100%" style="height: 100px;" border="0">
                            <tr>
                                <td valign="top" style="width: 40px;">
                                    <asp:ImageButton ID="Qup" OnClientClick="return upvotequestion()" runat="server"
                                        ImageUrl="~/Images/Arrow_Up.png" Height="25px" Width="25px" ToolTip="Vote Up" />
                                    <br />
                                    &nbsp;&nbsp;<asp:Label runat="server" ID="LblQRate" Font-Bold="true" Font-Size="Large"></asp:Label>
                                    <br />
                                    <asp:ImageButton ID="Qdown" OnClientClick="return downvotequestion()" runat="server"
                                        ImageUrl="~/Images/Arrow_down.png" Height="25px" Width="25px" ToolTip="Vote Down" />
                                    <br />
                                </td>
                                <td valign="top" style="text-align: left;">
                                    <asp:Literal ID="ltrldesc" runat="server"><b>Description</b></asp:Literal>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="float: right; margin-right: 100px;" valign="top">
                <asp:Repeater ID="rptComments" runat="server">
                    <ItemTemplate>
                        <table width="100%">
                            <tr>
                                <td>
                                    asdas
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
            </td>
        </tr>
        <tr>
            <td style="font-weight: bold;">
                <br />
                ANSWERS
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:DataList runat="server" ID="DatalistAnswer" OnItemDataBound="DatalistAnswer_ItemDataBound"
                    Width="100%">
                    <ItemTemplate>
                        <table width="100%">
                            <tr>
                                <td colspan="2">
                                    <br />
                                    <br />
                                    <br />
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <asp:UpdatePanel ID="APanel" runat="server">
                                    <Triggers >
                                        <asp:PostBackTrigger ControlID="Aup" />
                                        <asp:PostBackTrigger ControlID="Adown" />
                                    </Triggers>
                                    <ContentTemplate >
                                        <td valign="top" style="width: 10%;">
                                            <asp:ImageButton ID="Aup" runat="server" ImageUrl="~/Images/Arrow_Up.png" Height="25px"
                                                Width="25px" ToolTip="Vote Up" />
                                            <br />
                                            &nbsp;&nbsp;<asp:Label runat="server" ID="LblARate" Font-Bold="true" Font-Size="Large"></asp:Label>
                                            <br />
                                            <asp:ImageButton ID="Adown" runat="server" ImageUrl="~/Images/Arrow_down.png" Height="25px"
                                                Width="25px" ToolTip="Vote Down" />
                                            <br />
                                        </td>
                                        <td style="text-align: left; width: 90%;">
                                            <asp:Literal ID="ltrlAnswer" runat="server"></asp:Literal>
                                        </td>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </tr>
                            <tr>
                                <td colspan="2">
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <span style="font-weight: bold;">My Answer</span>
                <hr />
                <textarea id="TxtDesc" name="area1" runat="server" style="width: 100%; max-height: 900px;
                    height: 420px; overflow: scroll;"></textarea>
            </td>
        </tr>
        <tr>
            <td style="float: right;">
                <br />
                <asp:Button runat="server" ID="btnPostAnswer" Text="My Answer" Style="background-color: #4B6C9E;
                    color: White; cursor: pointer; width: 100px; height: 30px; border-collapse: collapse;
                    border-style: none; font-weight: bold;" OnClick="btnPostAnswer_Click" />
            </td>
        </tr>
    </table>
    <div style="margin-top: 100px;">
    </div>
</asp:Content>

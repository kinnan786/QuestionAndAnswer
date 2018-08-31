<%@ Page Title="" Language="C#" MasterPageFile="~/Nestedmaster.master" AutoEventWireup="true"
    CodeFile="AddQuestion.aspx.cs" Inherits="AddQuestion" validateRequest="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="content1" ContentPlaceHolderID="NestedHeadContent" runat="server">
<script type="text/javascript" language="javascript">
    //Intellisense functions Start
    function selected_ItemCode(sender, e) {
        var ArrayVal = (e._value).split("|");
        var jcontrolid = '<%=ATxtQuestion.TargetControlID %>' + '_txtField';
        var jAssocode = document.getElementById('<%=ATxtQuestion.TargetControlID%>' + '_txtField').value;

        if (ArrayVal[1] == jAssocode) {
            alert("CPT Code And AssoCode are Duplicate.");
            document.getElementById(jcontrolid).innerText = "";
            document.getElementById(jcontrolid).focus = "true";
            return false;
        }
        else {
            document.getElementById(jcontrolid).innerText = ArrayVal[1];
        }
    }

    function ClientPopulatedCode(sender, e) {
        var listObject = $find('<%=ATxtQuestion.TargetControlID %>');

        listObject._popupBehavior._element.style.zIndex = 50000;
        listObject._popupBehavior._element.style.width = "400px";

        var complaints = sender.get_completionList().childNodes;
        for (var i = 0; i < complaints.length; i++) {
            var complaintsVals = (complaints[i]._value).split("|");
            complaints[i].innerHTML = "<table border='0' width='98%' class='Label' cellspacing='0' cellpadding='0px' _value=" + complaints[i]._value + " ><tr><td valign='top'  style=' width:15%' class='Label' _value=" + complaints[i]._value + ">" + complaintsVals[1] + "</td></tr></table>";

            //document.getElementById("hdnintellieid").value += complaintsVals[1] + ",";
        }
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ProfileMasterPageLeftContent" runat="Server">
    <table width="100%" style="border-collapse: collapse;">
        <tr>
            <td>
                <table width="100%" border="0" style="border-collapse: collapse;">
                    <tr>
                        <td style="width: 750px;" colspan="2">
                            Question?
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Tags:&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="TxtQuestion" runat="server" Width="145px" MaxTextLength="30"></asp:TextBox>
                            <asp:AutoCompleteExtender TargetControlID="TxtQuestion" ID="ATxtQuestion" MinimumPrefixLength="2"
                                        EnableCaching="true" runat="server" ServiceMethod="GetTags" ServicePath="~/QAWebService.asmx"
                                        OnClientItemSelected="selected_ItemCode" OnClientPopulated="ClientPopulatedCode" />
                            <br />
                            <div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Title:&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="TxtTitle" runat="server" Style="width: 800px;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <textarea id="TxtDesc" name="area1" runat="server" style="width: 820px; max-height:900px; height: 420px; overflow: scroll; " ></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td style="float: right;">
                        <br />
                        <asp:Button runat="server" ID="btnCancel" Text="Cancel" Style="background-color: #4B6C9E; color: White;
                                cursor: pointer; width: 100px; height: 30px; border-collapse: collapse; border-style: none;
                                font-weight: bold;" onclick="btnCancel_Click" />
                                &nbsp;&nbsp;
                            <asp:Button runat="server" ID="btnAddQuestion" Text="Ask Question" Style="background-color: #4B6C9E; color: White;
                                cursor: pointer; width: 100px; height: 30px; border-collapse: collapse; border-style: none;
                                font-weight: bold;" onclick="btnAddQuestion_Click"/>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

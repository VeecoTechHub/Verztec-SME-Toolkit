<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master" AutoEventWireup="true" CodeFile="FMSelfAssessment.aspx.cs" Inherits="Public_FMSelfAssessment" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div align="center">
                <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="left" height="33" valign="top" class="sme_title">
                            <div>
                                Financial Management Self-Evaluation Questionnaire</div>
                        </td>
                    </tr>
                    <tr>
                        <td height="300" valign="top">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                            <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <strong>What is this?</strong><br />
                                        <br />
                                        …explanation here…<br />
                                        On a scale of 1 (Very Poor) to 5 (Excellent), please rate the following statements
                                        in relation to your organisation.
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:GridView ID="gvQuestionaire" GridLines="Both" AllowSorting="true" Width="870"
                                            AutoGenerateColumns="false" runat="server" AllowPaging="true">
                                            <Columns>
                                                <asp:TemplateField HeaderText="No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOrderBy" runat="server" Text='<%#Eval("Order_By") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="25px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Question">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblQuestion" runat="server" Text='<%#Eval("Question") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="715px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Rating (1-5)">
                                                    <ItemTemplate>
                                                        <cc1:Rating runat="server" ID="Rating1" MaxRating="5" CssClass="ratingStar"
                                                            StarCssClass="ratingItem" WaitingStarCssClass="red" FilledStarCssClass="yellow"
                                                            EmptyStarCssClass="white" >
                                                        </cc1:Rating>
                                                        <asp:HiddenField ID="hdfldRating" runat="server" Value='<%#Eval("Rating") %>' />
                                                        <asp:HiddenField ID="hdfldQID" runat="server" Value='<%#Eval("FMT_EQ_ID") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle CssClass="GridRow" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <AlternatingRowStyle CssClass="AlternateGridRow" />
                                        </asp:GridView>
                                        <asp:HiddenField ID="hdfldSelectedValues" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Button ID="btnProcess" runat="server" Text="Process This" OnClick="btnProcess_Click" class="orange_button" />
                                        <br />
                                        <br />
                                        <asp:Label ID="lblValues" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            </ContentTemplate>
                    </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </div>
</asp:Content>


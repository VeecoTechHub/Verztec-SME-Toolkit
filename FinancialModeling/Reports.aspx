<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="Reports"
    EnableViewState="false" EnableEventValidation="false" MasterPageFile="~/MasterPages/MainMaster.master"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/Hightlights.ascx" TagName="Hightlights" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">


        function formatCellsWithComma(strLblClientIds) {


            var lblSplitIds = strLblClientIds.split(',');

            for (i = 0; i <= lblSplitIds.length - 1; i++) {

                var lblObj = document.getElementById(lblSplitIds[i]);

                var val = document.getElementById(lblSplitIds[i]).innerHTML;

                lblObj.innerHTML = includeComma(val, 3);
            }
        }
      


    </script>

    <asp:UpdatePanel ID="upPanel" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="imgBtnWorkingCapital" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="imgBtnBreakeven" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <table>
                <tr>
                    <td valign="top" class="bodybg">
                        <table width="898" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <table width="898" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td valign="top" class="newContentbg">
                                                <table width="898" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td align="center">
                                                            <table border="0" cellspacing="0" cellpadding="0" width="898">
                                                                <tr>
                                                                    <td width="898" align="center">
                                                                        <table width="898">
                                                                            <tr>
                                                                                <td class="Reportsbg">
                                                                                    <table align="center">
                                                                                        <tr>
                                                                                            <td width="60px">
                                                                                                &nbsp;
                                                                                            </td>
                                                                                            <td width="90px" align="center">
                                                                                                <asp:ImageButton ID="imgbtnStatements" ToolTip="Statements" ImageUrl="~/images/icon-statements.png"
                                                                                                    runat="server" OnClick="imgbtnStatements_Click" meta:resourcekey="imgbtnStatementsResource1" /><br />
                                                                                                <asp:Label ID="lblStatements" runat="server" Text="Statements" meta:resourcekey="lblStatementsResource1"></asp:Label>
                                                                                            </td>
                                                                                            <td width="90px" align="center">
                                                                                                <asp:ImageButton ID="imgbtnHome" ToolTip="Home" ImageUrl="~/images/icon-home.png"
                                                                                                    runat="server" OnClick="imgbtnHome_Click" meta:resourcekey="imgbtnHomeResource1" />
                                                                                                <br />
                                                                                                <asp:Label ID="lblHome" runat="server" Text="Home" meta:resourcekey="lblHomeResource1"></asp:Label>
                                                                                            </td>
                                                                                            <td width="90px" align="center">
                                                                                                <asp:ImageButton ID="imgBtnGenerateReport" ToolTip="Generate Report" ImageUrl="~/images/icon-report.png"
                                                                                                    runat="server" OnClick="imgBtnGenerateReport_Click" meta:resourcekey="imgBtnGenerateReportResource1" /><br />
                                                                                                <asp:Label ID="lblReport" runat="server" Text="Report" meta:resourcekey="lblReportResource1"></asp:Label>
                                                                                            </td>
                                                                                            <td style="width: 90px" align="center">
                                                                                                <asp:ImageButton ID="imgBtnHelp" ToolTip="Help" ImageUrl="~/images/icon-faq.png"
                                                                                                    runat="server" PostBackUrl="~/FinancialModeling/Help.aspx" meta:resourcekey="imgBtnHelpResource1" /><br />
                                                                                                <asp:Label ID="lblHelp" runat="server" Text="Help" meta:resourcekey="lblHelpResource1"></asp:Label>
                                                                                            </td>
                                                                                            <td style="width: 60px">
                                                                                                &nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table width="874" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td width="53">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td>
                                                                        <table width="758">
                                                                            <tr>
                                                                                <td style="padding-left: 35px; width: 350px">
                                                                                    <asp:Label ID="lblRounded" runat="server" Text="Report to be rounded to the nearest :"
                                                                                        meta:resourcekey="lblRoundedResource1"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlRoundDollar" runat="server" meta:resourcekey="ddlRoundDollarResource1">
                                                                                        <asp:ListItem Value="1" Text="Dollars" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                                                                        <asp:ListItem Value="1000" Text="Thousands" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td valign="top">
                                                                                    <asp:Button ID="btnGo" runat="server" CssClass="orange_button" Text="Go" OnClick="btnGo_Click"
                                                                                        Style="height: 26px" meta:resourcekey="btnGoResource1" />
                                                                                </td>
                                                                                <td align="right">
                                                                                    <asp:ImageButton ID="imgbtnDownloadReport" ToolTip="Generate Report" runat="server"
                                                                                        OnClick="imgbtnDownloadReport_Click" meta:resourcekey="imgbtnDownloadReportResource1" />
                                                                                    <asp:Label ID="lblDownloadReportFake" runat="server" Visible="False" 
                                                                                        meta:resourcekey="lblDownloadReportFakeResource1"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                    <tr>
                                                                        <td valign="top" width="53">
                                                                            <asp:HyperLink ID="hlkHome" runat="server" NavigateUrl="~/FinancialModeling/FinancialModelingHome.aspx?Id=''"
                                                                                meta:resourcekey="hlkHomeResource1"></asp:HyperLink>
                                                                            <asp:Label ID="lblFakeHome" runat="server" Visible="False" meta:resourcekey="lblFakeHomeResource1"></asp:Label>
                                                                        </td>
                                                                        <td valign="top" width="758">
                                                                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="779" style="height: 500px">
                                                                                <tr>
                                                                                    <td align="left" class="timesheet_bg" valign="top" width="750">
                                                                                        <asp:PlaceHolder ID="phFinancialGraphs" runat="server"></asp:PlaceHolder>
                                                                                    </td>
                                                                                    <td valign="top">
                                                                                        <table border="0" cellpadding="0" cellspacing="0" width="29">
                                                                                            <tr>
                                                                                                <td height="3">
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:ImageButton ID="imgBtnHightlight" runat="server" border="0" Height="117px" ImageUrl="~/images/highlights.jpg"
                                                                                                        OnClick="imgBtnHightlight_Click" Width="29px" meta:resourcekey="imgBtnHightlightResource1" />
                                                                                                    <asp:Label ID="lblHigh" runat="server" Visible="False" 
                                                                                                        meta:resourcekey="lblHighResource1"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:ImageButton ID="imgBtnBreakeven" runat="server" border="0" Height="117px" ImageUrl="~/images/breaken.jpg"
                                                                                                        OnClick="imgBtnBreakeven_Click" Width="29px" meta:resourcekey="imgBtnBreakevenResource1" />
                                                                                                             <asp:Label ID="lblBreakeven" runat="server" Visible="False" 
                                                                                                        meta:resourcekey="lblBreakevenResource1"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:ImageButton ID="imgBtnWorkingCapital" runat="server" border="0" Height="117px"
                                                                                                        ImageUrl="~/images/WorkingCapital.jpg" OnClick="imgBtnWorkingCapital_Click" Width="29px"
                                                                                                        meta:resourcekey="imgBtnWorkingCapitalResource1" />
                                                                                                             <asp:Label ID="lblWorkingCapital" runat="server" Visible="False" 
                                                                                                        meta:resourcekey="lblWorkingCapitalResource1"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:ImageButton ID="imgBtnCashFlow" runat="server" border="0" Height="117px" ImageUrl="~/images/CashFlow.jpg"
                                                                                                        OnClick="imgBtnCashFlow_Click" Width="29px" meta:resourcekey="imgBtnCashFlowResource1" />
                                                                                                             <asp:Label ID="lblCashFlow" runat="server" Visible="False" 
                                                                                                        meta:resourcekey="lblCashFlowResource1"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:ImageButton ID="imgBtnFunding" runat="server" border="0" Height="117px" ImageUrl="~/images/Funding.jpg"
                                                                                                        OnClick="imgBtnFunding_Click" Width="29px" meta:resourcekey="imgBtnFundingResource1" />
                                                                                                             <asp:Label ID="lblFunding" runat="server" Visible="False" 
                                                                                                        meta:resourcekey="lblFundingResource1"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:ImageButton ID="imgBtnAppendix" runat="server" border="0" Height="117px" ImageUrl="~/images/AppendixA.jpg"
                                                                                                        OnClick="imgBtnAppendix_Click" Width="29px" meta:resourcekey="imgBtnAppendixResource1" />
                                                                                                             <asp:Label ID="lblApp1" runat="server" Visible="False" 
                                                                                                        meta:resourcekey="lblApp1Resource1"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:ImageButton ID="imgBtnAppendix2" runat="server" border="0" Height="117px" ImageUrl="~/images/AppendixB.jpg"
                                                                                                        Width="29px" OnClick="imgBtnAppendix2_Click" meta:resourcekey="imgBtnAppendix2Resource1" />
                                                                                                             <asp:Label ID="lblApp2" runat="server" Visible="False" 
                                                                                                        meta:resourcekey="lblApp2Resource1"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--    <asp:UpdateProgress runat="server" ID="UpdateProgress">
        <ProgressTemplate>
            <div>
          <asp:Image ID="Image1" ImageUrl="~/images/progressbar.gif" AlternateText="Processing" runat="server" />
            </div>
            
        </ProgressTemplate>
    </asp:UpdateProgress>--%>
    <%--    <ajaxToolkit:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress"
PopupControlID="UpdateProgress" BackgroundCssClass="modalPopup" />--%>
</asp:Content>

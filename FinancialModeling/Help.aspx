<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="Help.aspx.cs" Inherits="FinancialModeling_Help" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MenuPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LogPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table   width="874" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="33" valign="top" class="sme_title">
                <div>
                    <asp:Label ID="lblHeading" runat="server" 
                        Text="Classification Guide for the entry of Financial Statements" 
                        meta:resourcekey="lblHeadingResource1"></asp:Label>
                    </div>
            </td>
        </tr>
        <tr>
            <td height="300" valign="top">
                <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table id="tbl1" width="874" border="0" align="center" cellpadding="3" cellspacing="1">
                                <tr class="blue_bg">
                                    <td colspan="4">
                                        <strong>
                                            <asp:Label ID="lblBalanceSheet" runat="server" Text="A. Balance Sheet" 
                                            meta:resourcekey="lblBalanceSheetResource1"></asp:Label>
                                        </strong> :
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" valign="top" bgcolor="#FEFEFE">
                                        <strong>
                                        <asp:Label ID="lblCurrentAssets" runat="server" Text="Current Assets" 
                                            meta:resourcekey="lblCurrentAssetsResource1"></asp:Label>
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="26" align="center" valign="top" bgcolor="#E9E9E9">
                                    <asp:Label ID="lblA" runat="server" Text="A" meta:resourcekey="lblAResource1"></asp:Label>
                                        
                                    </td>
                                    <td width="204" valign="top" bgcolor="#E9E9E9">
                                    <asp:Label ID="lblCash" runat="server" Text="Cash" 
                                            meta:resourcekey="lblCashResource1"></asp:Label>
                                        
                                    </td>
                                    <td width="624" colspan="2" valign="top" bgcolor="#E9E9E9" 
                                        style="text-align: justify">
                                        <asp:Label ID="lblRefers" runat="server" 
                                            Text="refers to cash on hand, cash at bank and all fixed deposits placed with the banks" 
                                            meta:resourcekey="lblRefersResource1"></asp:Label>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top" bgcolor="#FEFEFE">
                                        <asp:Label ID="lblB" runat="server" Text="B" meta:resourcekey="lblBResource1"></asp:Label>
                                        
                                    </td>
                                    <td valign="top" bgcolor="#FEFEFE">
                                     <asp:Label ID="lblTradereceivables" runat="server" Text="Trade receivables" 
                                            meta:resourcekey="lblTradereceivablesResource1"></asp:Label>
                                        
                                    </td>
                                    <td colspan="2" valign="top" bgcolor="#FEFEFE" style="text-align: justify">
                                    <asp:Localize ID="locPara1" runat="server" Text="refers to all trade debts owing by your customers. Trade debts refers to unpaid
                                        invoices for sale of goods or provision of services, net of any provision for doubtful
                                        debts or bad debts written off" meta:resourcekey="locPara1Resource1"></asp:Localize>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top" bgcolor="#E9E9E9">
                                    <asp:Label ID="lblC" runat="server" Text="C" meta:resourcekey="lblCResource1"></asp:Label>
                                    </td>
                                    <td valign="top" bgcolor="#E9E9E9">
                                    <asp:Label ID="lblInventory" runat="server" Text="Inventory" 
                                            meta:resourcekey="lblInventoryResource1"></asp:Label>
                                        
                                    </td>
                                    <td colspan="2" valign="top" bgcolor="#E9E9E9" style="text-align: justify">
                                    <asp:Localize ID="locPara2" runat="server" Text="refers to raw materials, finished goods and work-in-progress of the business, net
                                        of any provision for obsolete inventory" meta:resourcekey="locPara2Resource1"></asp:Localize>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top" bgcolor="#FEFEFE">
                                     <asp:Label ID="lblD" runat="server" Text="D" meta:resourcekey="lblDResource1"></asp:Label>
                                    </td>
                                    <td valign="top" bgcolor="#FEFEFE">
                                     <asp:Label ID="lblDue" runat="server" Text="Due from business owner/(s)" 
                                            meta:resourcekey="lblDueResource1"></asp:Label>
                                        
                                    </td>
                                    <td colspan="2" valign="top" bgcolor="#FEFEFE" style="text-align: justify">
                                     <asp:Localize ID="locPara3" runat="server" Text="refers to amounts owing by the shareholder/(s) and/or related companies that are
                                        non-trade in nature" meta:resourcekey="locPara3Resource1"></asp:Localize>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top" bgcolor="#E9E9E9">
                                     <asp:Label ID="lblE" runat="server" Text="E" meta:resourcekey="lblEResource1"></asp:Label>
                                        
                                    </td>
                                    <td valign="top" bgcolor="#E9E9E9">
                                     <asp:Label ID="lblOtherAssets" runat="server" Text="Other Assets" 
                                            meta:resourcekey="lblOtherAssetsResource1"></asp:Label>
                                        
                                    </td>
                                    <td colspan="2" valign="top" bgcolor="#E9E9E9" style="text-align: justify">
                                    <asp:Localize ID="locPara4" runat="server" Text="refers to all other types of current assets such as prepayments, rental and uitlities
                                        deposits, GST receivables, staff advances, other debtors, etc (not relating to the
                                        trading activities of the business)" meta:resourcekey="locPara4Resource1"></asp:Localize>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" bgcolor="#FDFDFD">
                                        <strong>
                                        <asp:Label ID="lblNonCurrent" runat="server" Text="Non-current Assets" 
                                            meta:resourcekey="lblNonCurrentResource1"></asp:Label>
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top" bgcolor="#E9E9E9">
                                     <asp:Label ID="lbl1A" runat="server" Text="A" meta:resourcekey="lbl1AResource1"></asp:Label>
                                       
                                    </td>
                                    <td valign="top" bgcolor="#E9E9E9">
                                    <asp:Label ID="lblProperty" runat="server" Text="Property, plant & machinery" 
                                            meta:resourcekey="lblPropertyResource1"></asp:Label>
                                        
                                    </td>
                                    <td colspan="2" valign="top" bgcolor="#E9E9E9" style="text-align: justify">
                                     <asp:Localize ID="locPara5" runat="server" Text="refers to fixed assets less accumulated depreciation, example: furniture & fittings,
                                        office equipment, computer, motor vehicles, renovation, plant & machinery, land
                                        and building, etc. Please also include other non-current assets such as country
                                        club memberships, intangibles, investments in associates or in shares. etc. in this
                                        field, if applicable" meta:resourcekey="locPara5Resource1"></asp:Localize>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" valign="top" bgcolor="#FEFEFE">
                                        <strong>
                                     <asp:Label ID="lblTotalLiabilities" runat="server" Text="Total Liabilities" 
                                            meta:resourcekey="lblTotalLiabilitiesResource1"></asp:Label>
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top" bgcolor="#E9E9E9">
                                     <asp:Label ID="lbl2A" runat="server" Text="A" meta:resourcekey="lbl2AResource1"></asp:Label>
                                    </td>
                                    <td valign="top" bgcolor="#E9E9E9">
                                    <asp:Label ID="lblWorkingCapital" runat="server" Text="Working Capital loan" 
                                            meta:resourcekey="lblWorkingCapitalResource1"></asp:Label>
                                        
                                    </td>
                                    <td colspan="2" valign="top" bgcolor="#E9E9E9" style="text-align: justify">
                                    <asp:Label ID="lbl1Refers" runat="server" 
                                            Text="refers to amounts owing to the Banks and/or Financial Institutions, example: bank overdrafts, trust receipts, factoring loans, short-term advances and revolving credit, etc" 
                                            meta:resourcekey="lbl1RefersResource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top" bgcolor="#FEFEFE">
                                    <asp:Label ID="lbl2B" runat="server" Text="B" meta:resourcekey="lbl2BResource1"></asp:Label>
                                        
                                    </td>
                                    <td valign="top" bgcolor="#FEFEFE">
                                     <asp:Label ID="lblTermLoan" runat="server" Text="Term Loan / Hire-purchase loan" 
                                            meta:resourcekey="lblTermLoanResource1"></asp:Label>
                                        
                                    </td>
                                    <td colspan="2" valign="top" bgcolor="#FEFEFE" style="text-align: justify">
                                    <asp:Localize ID="locPara6" runat="server" 
                                            Text="
                                        refers to the term loans and/or hire purchase loans owing to the Banks and/or Financial
                                        Institutions. For hire purchase loan, the amount should be net of interest in suspense" 
                                            meta:resourcekey="locPara6Resource1"></asp:Localize>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top" bgcolor="#E9E9E9">
                                      <asp:Label ID="lbl2C" runat="server" Text="C" meta:resourcekey="lbl2CResource1"></asp:Label>
                                        
                                    </td>
                                    <td valign="top" bgcolor="#E9E9E9">
                                      <asp:Label ID="lblTradePayables" runat="server" Text="Trade Payables" 
                                            meta:resourcekey="lblTradePayablesResource1"></asp:Label>
                                        
                                    </td>
                                    <td colspan="2" valign="top" bgcolor="#E9E9E9" style="text-align: justify">
                                    <asp:Localize ID="locPara7" runat="server" Text="
                                        refers to trade related liabilities owing to suppliers for the purchases of the
                                        materials and services. If you receive advances from your customers prior to the
                                        delivery of goods and services, which is a normal terms of supply, please enter
                                        such advances here." meta:resourcekey="locPara7Resource1"></asp:Localize>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top" bgcolor="#FEFEFE">
                                        <asp:Label ID="lbl2D" runat="server" Text="D" meta:resourcekey="lbl2DResource1"></asp:Label>
                                    </td>
                                    <td valign="top" bgcolor="#FEFEFE">
                                    <asp:Label ID="lblIncomeTax" runat="server" Text="Income tax payables" 
                                            meta:resourcekey="lblIncomeTaxResource1"></asp:Label>
                                        
                                    </td>
                                    <td colspan="2" valign="top" bgcolor="#FEFEFE" style="text-align: justify">
                                    <asp:Label ID="lblRefersToTheProvision" runat="server" 
                                            Text="refers to the provision for income tax" 
                                            meta:resourcekey="lblRefersToTheProvisionResource1"></asp:Label>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top" bgcolor="#E9E9E9">
                                    <asp:Label ID="lbl2E" runat="server" Text="E" meta:resourcekey="lbl2EResource1"></asp:Label>
                                    </td>
                                    <td valign="top" bgcolor="#E9E9E9">
                                    <asp:Label ID="lblDueTo" runat="server" Text="Due to business owners" 
                                            meta:resourcekey="lblDueToResource1"></asp:Label>
                                        
                                    </td>
                                    <td colspan="2" valign="top" bgcolor="#E9E9E9" style="text-align: justify">
                                    <asp:Localize ID="locPara8" runat="server" Text="
                                        refers to amounts owing to the shareholder/(s) and/or related companies that are
                                        non trade in nature" meta:resourcekey="locPara8Resource1"></asp:Localize>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top" bgcolor="#FEFEFE">
                                    <asp:Label ID="lblF" runat="server" Text="F" meta:resourcekey="lblFResource1"></asp:Label>
                                    </td>
                                    <td valign="top" bgcolor="#FEFEFE">
                                    <asp:Label ID="lblOtherLiabilities" runat="server" Text="Other Liabilities" 
                                            meta:resourcekey="lblOtherLiabilitiesResource1"></asp:Label>
                                        
                                    </td>
                                    <td colspan="2" valign="top" bgcolor="#FEFEFE" style="text-align: justify">
                                    <asp:Localize ID="locPara9" runat="server" Text="
                                        refers to all other types of liabilities example: other creditors (contractors for
                                        renovation, suppliers for fixed assets, etc), accruals, GST payables, deferred tax
                                        liabilities, etc" meta:resourcekey="locPara9Resource1"></asp:Localize>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" valign="top" bgcolor="#FEFEFE">
                                        <strong>
                                        <asp:Label ID="lblEquity" runat="server" Text="Equity" 
                                            meta:resourcekey="lblEquityResource1"></asp:Label>
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top" bgcolor="#E9E9E9">
                                     <asp:Label ID="lbl3A" runat="server" Text="A" meta:resourcekey="lbl3AResource1"></asp:Label>
                                        
                                    </td>
                                    <td valign="top" bgcolor="#E9E9E9">
                                     <asp:Label ID="lblShareCapital" runat="server" 
                                            Text="Share Capital / Partners' or Sole-Proprietor's Capital Accounts" 
                                            meta:resourcekey="lblShareCapitalResource1"></asp:Label>
                                        
                                    </td>
                                    <td colspan="2" valign="top" bgcolor="#E9E9E9" style="text-align: justify">
                                     <asp:Localize ID="locPara10" runat="server" Text="
                                        For company limited by shares, it refers to the paid-up capital of the company;<br />
                                        For sole proprietorship, it refers to the amount that the sole proprietor has advanced
                                        to the business; and<br />
                                        For partnership, it represents the partners' capital accounts." 
                                            meta:resourcekey="locPara10Resource1"></asp:Localize>
                                    </td>
                                </tr>
                                 <tr>
                                    <td align="center" valign="top" bgcolor="#FEFEFE">
                                    <asp:Label ID="lbl3B" runat="server" Text="B" meta:resourcekey="lbl3BResource1"></asp:Label>
                                    </td>
                                    <td valign="top" bgcolor="#FEFEFE">
                                    <asp:Label ID="lblRetained" runat="server" 
                                            Text="Retained earnings / (Accumulated losses)" 
                                            meta:resourcekey="lblRetainedResource1"></asp:Label>
                                        
                                    </td>
                                    <td colspan="2" valign="top" bgcolor="#FEFEFE" style="text-align: justify">
                                     <asp:Label ID="lblaccumulated" runat="server" 
                                            Text="refers to the accumulated profits or losses, net of all dividends paid out." 
                                            meta:resourcekey="lblaccumulatedResource1"></asp:Label>
                                    </td>
                                </tr>
                              
                                <tr class="blue_bg">
                                    <td colspan="4">
                                        <strong>
                                        <asp:Label ID="lblBIncomeStmt" runat="server" Text="B. Income Statement" 
                                            meta:resourcekey="lblBIncomeStmtResource1"></asp:Label>
                                       </strong>:
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top" bgcolor="#E9E9E9">
                                     <asp:Label ID="lbl4A" runat="server" Text="A" meta:resourcekey="lbl4AResource1"></asp:Label>
                                        
                                    </td>
                                    <td valign="top" bgcolor="#E9E9E9">
                                     <asp:Label ID="lblSales" runat="server" Text="Sales" 
                                            meta:resourcekey="lblSalesResource1"></asp:Label>
                                        
                                    </td>
                                    <td colspan="2" valign="top" bgcolor="#E9E9E9" style="text-align: justify">
                                    <asp:Localize ID="locPara11" runat="server" Text="
                                        refers to the total revenue generated by the business from sales of goods or services
                                        rendered to the customers, net of discounts and returns" 
                                            meta:resourcekey="locPara11Resource1"></asp:Localize>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top" bgcolor="#FEFEFE">
                                    <asp:Label ID="lbl4B" runat="server" Text="B" meta:resourcekey="lbl4BResource1"></asp:Label>
                                        
                                    </td>
                                    <td valign="top" bgcolor="#FEFEFE">
                                    <asp:Label ID="lbl1CostofSales" runat="server" Text="Cost of Sales" 
                                            meta:resourcekey="lbl1CostofSalesResource1"></asp:Label>
                                       
                                    </td>
                                    <td colspan="2" valign="top" bgcolor="#FEFEFE">
                                    <asp:Label ID="lbldirect" runat="server" 
                                            Text="refers to the direct cost associated to the sales generated" 
                                            meta:resourcekey="lbldirectResource1"></asp:Label>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top" bgcolor="#FEFEFE">
                                        &nbsp;
                                    </td>
                                    <td valign="top" bgcolor="#FEFEFE">
                                        &nbsp;
                                    </td>
                                    <td colspan="2" valign="top" bgcolor="#FEFEFE">
                                    <asp:Label ID="lblExample" runat="server" Text="Example:" 
                                            meta:resourcekey="lblExampleResource1"></asp:Label>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top" bgcolor="#FEFEFE">
                                        &nbsp;
                                    </td>
                                    <td valign="top" bgcolor="#FEFEFE">
                                        &nbsp;
                                    </td>
                                    <td width="159" valign="top" bgcolor="#FEFEFE">
                                     <asp:Label ID="lblTrading" runat="server" Text="(i) Trading company" 
                                            meta:resourcekey="lblTradingResource1"></asp:Label>
                                        
                                    </td>
                                    <td valign="top" bgcolor="#FEFEFE" style="text-align: justify">
                                     <asp:Label ID="lblPurchases" runat="server" 
                                            Text="purchases of goods and delivery charges" 
                                            meta:resourcekey="lblPurchasesResource1"></asp:Label>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top" bgcolor="#FEFEFE">
                                        &nbsp;
                                    </td>
                                    <td valign="top" bgcolor="#FEFEFE">
                                        &nbsp;
                                    </td>
                                    <td valign="top" bgcolor="#FEFEFE">
                                    <asp:Label ID="lblManufacturing" runat="server" Text="(ii) Manufacturing company" 
                                            meta:resourcekey="lblManufacturingResource1"></asp:Label>
                                        
                                    </td>
                                    <td valign="top" bgcolor="#FEFEFE" style="text-align: justify">
                                    <asp:Label ID="lblmaterials" runat="server" 
                                            Text="Cost of raw materials and delivery charges" 
                                            meta:resourcekey="lblmaterialsResource1"></asp:Label>
                                        
                                    </td>
                                </tr>
                                  <tr>
                                    <td align="center" valign="top" bgcolor="#FEFEFE">
                                        &nbsp;
                                    </td>
                                    <td valign="top" bgcolor="#FEFEFE">
                                        &nbsp;
                                    </td>
                                    <td valign="top" bgcolor="#FEFEFE">
                                       
                                    </td>
                                    <td valign="top" bgcolor="#FEFEFE" style="text-align: justify">
                                    <asp:Label ID="lblOverheads" runat="server" 
                                            Text="Overheads include salaries and staff welfare of production workers, factory rental, equipment rental, repair and maintenance of equipments, factory utilities " 
                                            meta:resourcekey="lblOverheadsResource1"></asp:Label>
                                       
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top" bgcolor="#FEFEFE">
                                        &nbsp;
                                    </td>
                                    <td valign="top" bgcolor="#FEFEFE">
                                        &nbsp;
                                    </td>
                                    <td valign="top" bgcolor="#FEFEFE">
                                        <asp:Label ID="lblServicing" runat="server" Text="(iii) Servicing company" 
                                            meta:resourcekey="lblServicingResource1"></asp:Label>
                                        
                                    </td>
                                    <td valign="top" bgcolor="#FEFEFE">
                                    <asp:Label ID="lblLabour" runat="server" Text="Labour and sub-contracting charges" 
                                            meta:resourcekey="lblLabourResource1"></asp:Label>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top" bgcolor="#E9E9E9">
                                    <asp:Label ID="lbl3C" runat="server" Text="C" meta:resourcekey="lbl3CResource1"></asp:Label>
                                        
                                    </td>
                                    <td valign="top" bgcolor="#E9E9E9">
                                    <asp:Label ID="lblOperatingExpenses" runat="server" Text="Operating Expenses" 
                                            meta:resourcekey="lblOperatingExpensesResource1"></asp:Label>
                                        
                                    </td>
                                    <td valign="top" bgcolor="#E9E9E9">
                                    <asp:Label ID="lblSellingdistribution" runat="server" 
                                            Text="Selling and distribution" 
                                            meta:resourcekey="lblSellingdistributionResource1"></asp:Label>
                                        
                                    </td>
                                    <td valign="top" bgcolor="#E9E9E9" style="text-align: justify">
                                    <asp:Localize ID="locPara12" runat="server" Text="
                                        all operating costs pertaining to the running of the sales and distribution departments,
                                        including salaries, staff welfare, transportation costs, upkeep of motor vehicle,
                                        sales commission, marketing expenses, freight outwards, etc" 
                                            meta:resourcekey="locPara12Resource1"></asp:Localize>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top" bgcolor="#E9E9E9">
                                        &nbsp;
                                    </td>
                                    <td valign="top" bgcolor="#E9E9E9">
                                        &nbsp;
                                    </td>
                                    <td valign="top" bgcolor="#E9E9E9">
                                    <asp:Label ID="lblOtherAdministrative" runat="server" 
                                            Text="Other Administrative expenses" 
                                            meta:resourcekey="lblOtherAdministrativeResource1"></asp:Label>
                                       
                                    </td>
                                    <td valign="top" bgcolor="#E9E9E9" style="text-align: justify">
                                     <asp:Localize ID="locPara13" runat="server" Text="
                                        all other operating expenses including salaries and staff welfare for the administrative
                                        and finance department, office rental expenses, telecommunication expenses, utilities,
                                        directors salaries, audit fees, professional fees, printing and stationery, general
                                        expenses, etc" meta:resourcekey="locPara13Resource1"></asp:Localize>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top" bgcolor="#FEFEFE">
                                        <asp:Label ID="lbl4D" runat="server" Text="D" meta:resourcekey="lbl4DResource1"></asp:Label>
                                        
                                    </td>
                                    <td valign="top" bgcolor="#FEFEFE">
                                    <asp:Label ID="lbl2OtherIncome" runat="server" Text="Other Income" 
                                            meta:resourcekey="lbl2OtherIncomeResource1"></asp:Label>
                                        
                                    </td>
                                    <td colspan="2" valign="top" bgcolor="#FEFEFE" style="text-align: justify">
                                    <asp:Localize ID="locPara14" runat="server" Text="
                                        refers to income which is not derived directly from core business activities, example
                                        interest income, rental income, gain on sale of fixed assets, etc" 
                                            meta:resourcekey="locPara14Resource1"></asp:Localize>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top" bgcolor="#E9E9E9">
                                    <asp:Label ID="lbl3E" runat="server" Text="E" meta:resourcekey="lbl3EResource1"></asp:Label>
                                        
                                    </td>
                                    <td valign="top" bgcolor="#E9E9E9">
                                    <asp:Label ID="lblDepreciationamortisation" runat="server" 
                                            Text="Depreciation & amortisation" 
                                            meta:resourcekey="lblDepreciationamortisationResource1"></asp:Label>
                                        
                                    </td>
                                    <td colspan="2" valign="top" bgcolor="#E9E9E9" style="text-align: justify">
                                    <asp:Localize ID="locPara15" runat="server" Text="
                                        refers to the depreciation charges on fixed assets of the business and amortisation
                                        of intangible assets, if applicable" meta:resourcekey="locPara15Resource1"></asp:Localize>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top" bgcolor="#FEFEFE">
                                    <asp:Label ID="lbl3F" runat="server" Text="F" meta:resourcekey="lbl3FResource1"></asp:Label>
                                        
                                    </td>
                                    <td valign="top" bgcolor="#FEFEFE">
                                    <asp:Label ID="lblInterestexpense" runat="server" Text="Interest expense" 
                                            meta:resourcekey="lblInterestexpenseResource1"></asp:Label>
                                        
                                    </td>
                                    <td colspan="2" valign="top" bgcolor="#FEFEFE" style="text-align: justify">
                                    <asp:Label ID="lblinterestincurred" runat="server" 
                                            Text="refers to interest incurred on bank debts and hire purchase loans" 
                                            meta:resourcekey="lblinterestincurredResource1"></asp:Label>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top" bgcolor="#E9E9E9">
                                    <asp:Label ID="lbl3G" runat="server" Text="G" meta:resourcekey="lbl3GResource1"></asp:Label>
                                        
                                    </td>
                                    <td valign="top" bgcolor="#E9E9E9">
                                    <asp:Label ID="lbl2IncomeTax" runat="server" Text="Income Tax" 
                                            meta:resourcekey="lbl2IncomeTaxResource1"></asp:Label>
                                        
                                    </td>
                                    <td colspan="2" valign="top" bgcolor="#E9E9E9" style="text-align: justify">
                                    <asp:Localize ID="locPara16" runat="server" Text="
                                        refers to tax computed on the chargeable profits of the business and any deferred
                                        tax liabilities to be expensed to the current year's Income Statement" 
                                            meta:resourcekey="locPara16Resource1"></asp:Localize>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

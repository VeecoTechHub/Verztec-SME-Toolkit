<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TermsConditions.aspx.cs"
    Inherits="TermsConditions" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ABS : Terms & Conditions</title>
    <style type="text/css">
        .appendix
        {
            font: bold 14px Arial, Helvetica, sans-serif;
            color: Black;
            background-color: #A4A4A4;
            padding: 5px 10px;
            margin: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; width: 800px">
            <tr>
                <td height="30" style="padding: 10px 5px 10px 5px; width: 800px">
                    <span style="color: Red; font-weight: bold;"><b>
                        <asp:Label ID="lblTerms" runat="server" Text="Terms & Conditions" 
                        meta:resourcekey="lblTermsResource1"></asp:Label>
                    </b></span>
                </td>
            </tr>
            <tr>
                <td style="text-align: justify" class="appendix">
                    <asp:Label ID="Label1" runat="server" Text="Financial Management Toolkit Terms of Use and Privacy Notice
                        General " meta:resourcekey="Label1Resource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: justify">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblByEnter" runat="server" 
                                    Text="By entering this site, any pages thereof and/or by using the online  services, you have acknowledged and agreed to all the terms and conditions  stated herein in this document. These Terms of Use apply to all visits to this website,  both now and in the future.  If you do  not agree to any one of these conditions, please do not use this site." 
                                    meta:resourcekey="lblByEnterResource1"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="3%">
                                <strong>1. </strong>
                            </td>
                            <td width="97%">
                                <strong>
                                    <asp:Label ID="lblCopyright" runat="server" 
                                    Text="Copyright &amp;  Ownership" meta:resourcekey="lblCopyrightResource1"></asp:Label>
                                </strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <ol type="a">
                                    <li>
                                        <asp:Label ID="lblExcept" runat="server" 
                                            Text="Except as otherwise expressly stated, the copyright and all other  intellectual property in the contents of this website (including, but not  limited to, all design, layout, text, images, photographs links, search  engines) are the property of The Association of Banks of Singapore (ABS) and  its supporting partners Enterprise Singapore and Stone Forest Corporate Advisory  Pte Ltd. They may not be used, reproduced, transmitted, published, performed,  broadcast, stored, adapted, distributed, displayed, licensed, altered,  hyperlinked or otherwise used in whole or in part in any manner without the express  written permission and consent of ABS." 
                                            meta:resourcekey="lblExceptResource1"></asp:Label>
                                    </li>
                                    <li>
                                        <asp:Label ID="lblSaveAndExcept" runat="server" 
                                            Text="Save and except with the ABS&rsquo;s prior written consent, you may not insert  a hyperlink to this website or any part thereof on any other website or  &quot;mirror&quot; or &ldquo;frame&rdquo; this website, any part thereof, or any  information or materials contained in this website on any other server, website  or webpage." 
                                            meta:resourcekey="lblSaveAndExceptResource1"></asp:Label>
                                    </li>
                                    <li>
                                        <asp:Label ID="lblAllTrademarks" runat="server" 
                                            Text="All trademarks, service marks, logos used in this website are the  property of ABS and/or the respective third party proprietors identified in  this website." 
                                            meta:resourcekey="lblAllTrademarksResource1"></asp:Label>
                                    </li>
                                    <li>
                                        <asp:Label ID="lblNoLicense" runat="server" 
                                            Text="No license or right is granted to you and your access to this Website  and/or use of the online tools and services should not be construed as  granting, by implication, estoppel or otherwise, any license or right to use  any of the Contents without the prior written consent of ABS or the relevant  third party owner of the proprietary right thereof." 
                                            meta:resourcekey="lblNoLicenseResource1"></asp:Label>
                                    </li>
                                    <li>
                                        <asp:Label ID="lblYouMay" runat="server" 
                                            Text="You may use, copy and distribute the Contents found on this Website  solely for personal, internal, non-commercial and/or informational purposes  only. You may download one copy of any information provided on this Website  onto a computer for your own personal and non-commercial use provided that you  keep intact all accompanying copyright and other proprietary notices.  Modification or use of the material on this site for any purpose violates ABS's  legal rights." 
                                            meta:resourcekey="lblYouMayResource1"></asp:Label>
                                    </li>
                                    <li>
                                        <asp:Label ID="lblModification" runat="server" 
                                            Text="Modification of any of the Contents or use of the Contents for any other  purpose will be a violation of ABS' copyright and other intellectual property  rights. Graphics and images on this Website are protected by copyright and may  not be reproduced or appropriated in any manner without the prior written  consent of their respective copyright owners." 
                                            meta:resourcekey="lblModificationResource1"></asp:Label>
                                    </li>
                                </ol>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong>2.</strong>
                            </td>
                            <td>
                                <strong>
                                    <asp:Label ID="lblDisclaimer" runat="server" Text="Disclaimer" 
                                    meta:resourcekey="lblDisclaimerResource1"></asp:Label>
                                </strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <ol type="a">
                                    <li>
                                    <asp:Localize ID="locPara1" runat="server" Text="
                                    The information and materials on this website is for general information only. Note
                                        that ABS is not involved in giving professional advice. The website may not cover
                                        all information available on a particular issue. ABS advises that users conduct
                                        their own checks or obtain relevant professional advice outside this website." 
                                            meta:resourcekey="locPara1Resource1"></asp:Localize></li>
                                    <li>
                                    <asp:Localize ID="locPara2" runat="server" Text="
                                    The contents of this Website, (including but not limited to the &ldquo;online tools
                                        and calculators&rdquo;), are provided on an &quot;as is&quot; and &ldquo;as available&rdquo;
                                        basis without warranties of any kind, and are of a general nature." 
                                            meta:resourcekey="locPara2Resource1"></asp:Localize> </li>
                                    <li>
                                    <asp:Localize ID="locPara3" runat="server" Text="
                                    While every effort is made to ensure that the contents herein are consistent with
                                        existing law and business practice, you are advised to refer to the relevant legislation
                                        and you should seek professional advice at all times before making any decision
                                        based on any such information or materials. Neither ABS nor any third party content
                                        providers is responsible for any errors or omissions, or for the results obtained
                                        from the use of the information and material in this Website or the tools contained
                                        in this Website." meta:resourcekey="locPara3Resource1"></asp:Localize></li>
                                    <li>
                                        <asp:Label ID="lblNeither" runat="server" 
                                            Text="Neither ABS nor any third party content providers warrants: " 
                                            meta:resourcekey="lblNeitherResource1"></asp:Label>
                                    </li>
                                    <ol type="i">
                                        <li>
                                         <asp:Localize ID="locPara4" runat="server" Text="
                                        the truth, accuracy, adequacy, reliability, completeness, reasonableness, currency
                                            or timeliness, of the Contents contained in or accessed through this Website and
                                            expressly disclaims liability for any errors in or omissions from, the Contents
                                            of the Website; and" meta:resourcekey="locPara4Resource1"></asp:Localize></li>
                                        <li><asp:Localize ID="locPara5" runat="server" Text="that the Contents available through this Website or any functions associated therewith
                                            will be uninterrupted or error-free, or that defects will be corrected or that this
                                            Website and the server is and will be free of all viruses and/or other malicious,
                                            destructive or corrupting code, macro or program." 
                                                meta:resourcekey="locPara5Resource1"></asp:Localize> </li>
                                    </ol>
                                    <li><asp:Localize ID="locPara6" runat="server" Text="No warranty of any kind, express, implied or statutory (including but not limited
                                        to, warranties of title, merchantability, satisfactory quality, non-infringement
                                        of third-party intellectual property rights, fitness for a particular purpose and
                                        freedom from computer virus), is given in conjunction with the contents of this
                                        Website, the tools contained in this Website or this Website in general. " 
                                            meta:resourcekey="locPara6Resource1"></asp:Localize></li>
                                    <li><asp:Localize ID="locPara7" runat="server" Text="Under no circumstances shall the ABS be liable regardless of the form of action
                                        for any failure of performance, system, server or connection failure, error, omission,
                                        interruption, breach of security, computer virus, malicious code, corruption, delay
                                        in operation or transmission, transmission error or unavailability of access in
                                        connection with your accessing this website and/or using the online services even
                                        if ABS had been advised as to the possibility. " 
                                            meta:resourcekey="locPara7Resource1"></asp:Localize> </li>
                                    <li><asp:Localize ID="locPara15" runat="server" 
                                            Text="Neither ABS nor any third party content providers shall be liable for damages, expenses,
                                        costs or loss of any kind (including without limitation any direct, or indirect,
                                        special, incidental or consequential damages, loss of profits or loss opportunity)
                                        howsoever caused as a result (direct or indirect) of, or in connection with, your
                                        use of this Website, or reliance on any information, materials, tools or online
                                        services provided in or available from this Website, regardless of the form of action. " 
                                            meta:resourcekey="locPara15Resource1"></asp:Localize></li>
                                </ol>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong>3. </strong>
                            </td>
                            <td>
                                <strong>
                                    <asp:Label ID="lblConfidentiality" runat="server" 
                                    Text="Confidentiality and Privacy of Information" 
                                    meta:resourcekey="lblConfidentialityResource1"></asp:Label>
                                </strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <ol type="a">
                                    <li><asp:Localize ID="locPara8" runat="server" Text="The use of this website contents and online tools are subject to successful online
                                        registration with a valid email address and other non-sensitive personal information.
                                        The information captured shall NOT be shared with any external parties, unless required
                                        are compelled by law to do so. ABS may use the information gathered for general
                                        statistical analysis of website usage such as which pages are most frequently visited,
                                        how many visitors this website receives daily, and how long visitors stay on each
                                        page. " meta:resourcekey="locPara8Resource1"></asp:Localize></li>
                                    <li>
                                     <asp:Label ID="lblABSMay" runat="server" 
                                            Text="ABS may collect and use the following kinds of personal information:" 
                                            meta:resourcekey="lblABSMayResource1"></asp:Label>
                                    </li>
                                    <ol type="i">
                                        <li>
                                        <asp:Label ID="lblInformation" runat="server" 
                                                Text="Information about your use of this website" 
                                                meta:resourcekey="lblInformationResource1"></asp:Label>
                                        </li>
                                        <li>
                                        <asp:Label ID="lblInformationThat" runat="server" Text="Information that you provide using for the purpose of registering with the website
                                            (including valid email and non-sensitive personal information)." 
                                                meta:resourcekey="lblInformationThatResource1"></asp:Label>
                                        </li>
                                        <li><asp:Label ID="lblInformationAbout" runat="server" Text="Information about transactions carried out over this website (including statistical
                                            usage)." meta:resourcekey="lblInformationAboutResource1"></asp:Label></li>
                                        <li><asp:Label ID="lblInformationThatYou" runat="server" Text="Information that you provide for the purpose of subscribing to the website services
                                            (including comments; and)" meta:resourcekey="lblInformationThatYouResource1"></asp:Label></li>
                                        <li><asp:Label ID="lblInformationAnyOther" runat="server" 
                                                Text="any other information that you may send to ABS" 
                                                meta:resourcekey="lblInformationAnyOtherResource1"></asp:Label></li>
                                    </ol>
                                    <li><asp:Label ID="lblTheUseOf" runat="server" Text="The use of this website and online tools are subject to the successful online registration
                                        with a valid email address and other non-sensitive personal information." 
                                            meta:resourcekey="lblTheUseOfResource1"></asp:Label></li>
                                    <li><asp:Label ID="lblABSMayUse" runat="server" 
                                            Text="ABS may use your non sensitive personal information to:" 
                                            meta:resourcekey="lblABSMayUseResource1"></asp:Label></li>
                                    <ol type="i">
                                        <li><asp:Label ID="lblpersonalize" runat="server" 
                                                Text="personalize the website for you;" 
                                                meta:resourcekey="lblpersonalizeResource1"></asp:Label></li>
                                        <li><asp:Label ID="lblenable" runat="server" 
                                                Text="enable your access to and use of the website services;" 
                                                meta:resourcekey="lblenableResource1"></asp:Label></li>
                                        <li><asp:Label ID="lblStatistical" runat="server" 
                                                Text="Statistical analysis of website usage." 
                                                meta:resourcekey="lblStatisticalResource1"></asp:Label></li>
                                    </ol>
                                    <li><asp:Label ID="lblABSwill" runat="server" Text="ABS will take reasonable technical and organizational precautions to prevent the
                                        loss, misuse or alteration of your personal information." 
                                            meta:resourcekey="lblABSwillResource1"></asp:Label></li>
                                    <li><asp:Label ID="lblABSwillStore" runat="server" Text="ABS will store all the non-sensitive personal information you provide on its secure
                                        servers" meta:resourcekey="lblABSwillStoreResource1"></asp:Label></li>
                                    <li><asp:Label ID="lblInformationrelating" runat="server" Text="Information relating to electronic transactions entered into via this website will
                                        be protected by encryption technology and governed by the terms and conditions set
                                        forth by the online gateway." 
                                            meta:resourcekey="lblInformationrelatingResource1"></asp:Label></li>
                                    <li><asp:Label ID="lblABSreserves" runat="server" Text="ABS reserves the right to purge any user data that may cause degradation of server/or
                                        and database performance during periodic maintenance. Users are required to perform
                                        the necessary record keeping or data backup accordingly." 
                                            meta:resourcekey="lblABSreservesResource1"></asp:Label></li>
                                </ol>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong>4.</strong>
                            </td>
                            <td>
                                <strong><asp:Label ID="lblRight" runat="server" 
                                    Text="Right of Access / Restricted Access" meta:resourcekey="lblRightResource1"></asp:Label></strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <ol type="a">
                                    <li><asp:Localize ID="locPara9" runat="server" Text="Access to certain areas of this website is restricted. ABS reserves the right to
                                        restrict access to other areas of this website, or indeed this entire website, at
                                        ABS&rsquo;s discretion. " meta:resourcekey="locPara9Resource1"></asp:Localize></li>
                                    <li><asp:Localize ID="locPara10" runat="server" Text="If ABS provides you with a user ID and password to enable you to access restricted
                                        areas of this website or other content or services, you must ensure that the user
                                        ID and password are kept confidential." meta:resourcekey="locPara10Resource1"></asp:Localize></li>
                                    <li><asp:Localize ID="locPara11" runat="server" Text="ABS may disable your user ID and password in ABS’s sole discretion without notice
                                        or explanation." meta:resourcekey="locPara11Resource1"></asp:Localize> </li>
                                    <li><asp:Localize ID="locPara12" runat="server" Text="ABS reserves all rights to deny or restrict access to this Website to any particular
                                        person, or to block access from a particular Internet address to this Website, at
                                        any time, without having to give any reason or prior notice thereof" 
                                            meta:resourcekey="locPara12Resource1"></asp:Localize></li>
                                </ol>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong>5. </strong>
                            </td>
                            <td>
                                <strong>
                                    <asp:Label ID="lblHyperlinks" runat="server" Text="Hyperlinks" 
                                    meta:resourcekey="lblHyperlinksResource1"></asp:Label>
                                </strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                            <asp:Localize ID="locPara13" runat="server" Text="
                                For your convenience, ABS may include hyperlinks to websites on the Internet that
                                are owned or operated by third parties. Such linked websites are not under the control
                                of the ABS and ABS cannot accept responsibility for the contents of or the consequences
                                of accessing any linked website or any link contained in a linked website. Furthermore,
                                the hyperlinks provided in this website shall not be considered or construed as
                                an endorsement or verification of such linked websites or the contents therein by
                                ABS. You agree that your access to and/or use of such linked websites is entirely
                                at your own risk and subject to the terms and conditions of access and/or use contained
                                therein." meta:resourcekey="locPara13Resource1"></asp:Localize>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong>6. </strong>
                            </td>
                            <td>
                                <strong>
                                  <asp:Label ID="lblBreaches" runat="server" 
                                    Text="Breaches of these terms and conditions" 
                                    meta:resourcekey="lblBreachesResource1"></asp:Label>
                                </strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                            <asp:Localize ID="locPara14" runat="server" Text="
                                Without prejudice to ABS&rsquo;s other rights under these terms and conditions,
                                if you breach these terms and conditions in any way, ABS may take such action as
                                ABS deems appropriate to deal with the breach, including suspending your access
                                to the website, prohibiting you from accessing the website, blocking computers using
                                your IP address from accessing the website, contacting your internet service provider
                                to request that they block your access to the website and/or bringing court proceedings
                                against you." meta:resourcekey="locPara14Resource1"></asp:Localize>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong>7. </strong>
                            </td>
                            <td>
                                <strong>
                                       <asp:Label ID="lblEnforcement" runat="server" 
                                    Text="Enforcement of copyright" meta:resourcekey="lblEnforcementResource1"></asp:Label>
                                </strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <ol type="a">
                                    <li>
                                    <asp:Label ID="lblABSTakesThe" runat="server" 
                                            Text="ABS takes the protection of its copyright very seriously." 
                                            meta:resourcekey="lblABSTakesTheResource1"></asp:Label>
                                    </li>
                                    <li><asp:Localize ID="locPara16" runat="server" Text="If ABS discovers that you have used its copyright materials in contravention of
                                        the license above, ABS may bring legal proceedings against you seeking monetary
                                        damages and an injunction to stop you using those materials." 
                                            meta:resourcekey="locPara16Resource1"></asp:Localize></li>
                                    <li>
                                        <asp:Label ID="lblIfyoubecome" runat="server" 
                                            meta:resourcekey="lblIfyoubecomeResource1"></asp:Label>
                                   </li>
                                </ol>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong>8. </strong>
                            </td>
                            <td>
                                <strong>
                                 <asp:Label ID="lblInfringement" runat="server" Text="Infringement of material" 
                                    meta:resourcekey="lblInfringementResource1"></asp:Label>
                                </strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                            <asp:Label ID="lblIfyoubecomeaware" runat="server" 
                                    meta:resourcekey="lblIfyoubecomeawareResource1"></asp:Label>
                               
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong>9. </strong>
                            </td>
                            <td>
                                <strong>
                                <asp:Label ID="lblPermissions" runat="server" Text="Permissions" 
                                    meta:resourcekey="lblPermissionsResource1"></asp:Label>
                                </strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                            <asp:Label ID="lblYoumayrequestpermission" runat="server" 
                                    meta:resourcekey="lblYoumayrequestpermissionResource1"></asp:Label>
                               
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong>10.</strong>
                            </td>
                            <td>
                                <strong>
                                <asp:Label ID="lblGoverningLaw" runat="server" Text="Governing Law" 
                                    meta:resourcekey="lblGoverningLawResource1"></asp:Label>
                                </strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                             <asp:Label ID="lblTheseTerms" runat="server" Text="These Terms of Use shall be governed and construed in accordance with laws of the
                                Republic of Singapore." meta:resourcekey="lblTheseTermsResource1"></asp:Label>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong>11. </strong>
                            </td>
                            <td>
                                <strong>
                                <asp:Label ID="lblReasonableness" runat="server" Text="Reasonableness" 
                                    meta:resourcekey="lblReasonablenessResource1"></asp:Label>
                                </strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <ol type="a">
                                    <li>
                                     <asp:Label ID="lblByUsing" runat="server" Text=" By using this website, you agree that the exclusions and limitations of liability
                                        set out in this website disclaimer are reasonable." 
                                            meta:resourcekey="lblByUsingResource1"></asp:Label>
                                   </li>
                                    <li>
                                    <asp:Label ID="lblIfYoudonotthink" runat="server" 
                                            Text="If you do not think they are reasonable, you must not use this website." 
                                            meta:resourcekey="lblIfYoudonotthinkResource1"></asp:Label>
                                    </li>
                                </ol>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong>12. </strong>
                            </td>
                            <td>
                                <strong>
                                    <asp:Label ID="lblUpdates" runat="server" Text="Updates" 
                                    meta:resourcekey="lblUpdatesResource1"></asp:Label>
                                </strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                              <asp:Label ID="lblABSmayUpdate" runat="server" 
                                    Text="ABS may update this terms and privacy policy by posting a new version on this website.
                                You should check this page periodically to ensure you are familiar with any changes" 
                                    meta:resourcekey="lblABSmayUpdateResource1"></asp:Label>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong>13. </strong>
                            </td>
                            <td>
                                <strong>
                                    <asp:Label ID="lblContact" runat="server" Text="Contact" 
                                    meta:resourcekey="lblContactResource1"></asp:Label>
                                </strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                               <asp:Label ID="lblIfYouhaveAnyQue" runat="server" 
                                    meta:resourcekey="lblIfYouhaveAnyQueResource1"></asp:Label>
                                
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

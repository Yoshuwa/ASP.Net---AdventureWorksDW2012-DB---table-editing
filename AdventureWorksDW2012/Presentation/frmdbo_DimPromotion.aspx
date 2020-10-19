<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Page Title="dbo_DimPromotion" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="frmdbo_DimPromotion.aspx.cs" Inherits="AdventureWorksDW2012.frmdbo_DimPromotion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <link rel="stylesheet" href="../Styles/Reset.css" type="text/css" media="screen" />
        <link rel="stylesheet" href="../Styles/Site.css" type="text/css" media="screen" />
        <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" ID="ScriptManager1" />
        <uc:OkMessageBox ID="ec" runat="server" />
        <section id="content">
            <h2>Dbo. Dim Promotion</h2>
            <div style="height: 10px"></div>
            <div style="text-align: center;">
                <div style="display: inline-block;">
                    <asp:DropDownList CssClass="input" ID="cmbFields" Width="150px" runat="server" CausesValidation="False"></asp:DropDownList>
                    <asp:DropDownList CssClass="input" ID="cmbCondition" Width="150px" runat="server" CausesValidation="False"></asp:DropDownList>
                    <asp:TextBox CssClass="input" ID="txtSearch" Width="100px" runat="server"></asp:TextBox>
                    <asp:Button ID="butSearch" Width="70px" Text="Search" runat="server" CausesValidation="False" OnClick="butSearch_Click"></asp:Button>
                    <asp:Button ID="butShowAll" Width="70px" Text="Show All" runat="server" CausesValidation="False" OnClick="butShowAll_Click"></asp:Button>
                </div>
            </div>
            <div style="height: 40px"></div>
            <div>
                <div style="float: left;">
                    <asp:DropDownList ID="ddlFile" Width="100px" runat="server" CssClass="input">
                        <asp:ListItem Value=".pdf">Pdf</asp:ListItem>
                        <asp:ListItem Value=".xls">Excel</asp:ListItem>
                        <asp:ListItem Value=".doc">Word</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="btnExport" Width="70px" runat="server" Text="Export" CausesValidation="False" OnClick="btnExport_Click"></asp:Button>
                </div>
                <div style="float: right;">
                    <asp:DropDownList CssClass="input" ID="cmbRecords" Width="100px" runat="server" CausesValidation="False"></asp:DropDownList>
                    <asp:Button ID="butRecords" Text="Records" Width="70px" runat="server" CausesValidation="False" OnClick="butRecords_Click"></asp:Button>
                </div>
            </div>
            <div style="height: 40px"></div>
        <%-------------------------------------%>
            <div style="text-align: center;">
                <div style="display: inline-block; overflow: auto;">
                <%-----
                    If GridView (grddbo_DimPromotion) width is bigger than web-page (or screen) width (for Mobile and Tablet)...
                    1) comment above 2 lines, and
                    2) uncomment following 2 lines
                -------%>
        <%--<div style="width: 100%;">
                <div style="overflow: auto;">--%>
                <%-------------------------------------%>
                    <asp:GridView id="grddbo_DimPromotion" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="PromotionKey" 
                        OnRowCancelingEdit="grddbo_DimPromotion_RowCancelingEdit" OnRowDataBound="grddbo_DimPromotion_RowDataBound" OnRowEditing="grddbo_DimPromotion_RowEditing"
                        OnPageIndexChanging="grddbo_DimPromotion_PageIndexChanging" OnSorting="grddbo_DimPromotion_Sorting" 
                        OnRowUpdating="grddbo_DimPromotion_RowUpdating" OnRowCommand="grddbo_DimPromotion_RowCommand" OnRowDeleting="grddbo_DimPromotion_RowDeleting" ShowFooter="True" Font-Size="Medium" >
                        <Columns>
                            <asp:TemplateField HeaderText="Promotion Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="PromotionKey">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPromotionKey" width="100px" runat="server" CssClass="input" Text='<%# Eval("PromotionKey") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewPromotionKey" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblPromotionKey" width="100px" runat="server" Text='<%# Eval("PromotionKey") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Promotion Alternate Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="PromotionAlternateKey">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPromotionAlternateKey" width="100px" runat="server" CssClass="input" Text='<%# Eval("PromotionAlternateKey") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewPromotionAlternateKey" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblPromotionAlternateKey" width="100px" runat="server" Text='<%# Eval("PromotionAlternateKey") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="English Promotion Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="EnglishPromotionName">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEnglishPromotionName" width="100px" runat="server" CssClass="input" Text='<%# Eval("EnglishPromotionName") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewEnglishPromotionName" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblEnglishPromotionName" width="100px" runat="server" Text='<%# Eval("EnglishPromotionName") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Spanish Promotion Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="SpanishPromotionName">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtSpanishPromotionName" width="100px" runat="server" CssClass="input" Text='<%# Eval("SpanishPromotionName") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewSpanishPromotionName" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblSpanishPromotionName" width="100px" runat="server" Text='<%# Eval("SpanishPromotionName") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="French Promotion Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="FrenchPromotionName">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtFrenchPromotionName" width="100px" runat="server" CssClass="input" Text='<%# Eval("FrenchPromotionName") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewFrenchPromotionName" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblFrenchPromotionName" width="100px" runat="server" Text='<%# Eval("FrenchPromotionName") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Discount Pct" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="DiscountPct">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDiscountPct" width="100px" runat="server" CssClass="input" Text='<%# Eval("DiscountPct") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewDiscountPct" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblDiscountPct" width="100px" runat="server" Text='<%# Eval("DiscountPct") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="English Promotion Type" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="EnglishPromotionType">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEnglishPromotionType" width="100px" runat="server" CssClass="input" Text='<%# Eval("EnglishPromotionType") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewEnglishPromotionType" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblEnglishPromotionType" width="100px" runat="server" Text='<%# Eval("EnglishPromotionType") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Spanish Promotion Type" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="SpanishPromotionType">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtSpanishPromotionType" width="100px" runat="server" CssClass="input" Text='<%# Eval("SpanishPromotionType") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewSpanishPromotionType" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblSpanishPromotionType" width="100px" runat="server" Text='<%# Eval("SpanishPromotionType") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="French Promotion Type" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="FrenchPromotionType">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtFrenchPromotionType" width="100px" runat="server" CssClass="input" Text='<%# Eval("FrenchPromotionType") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewFrenchPromotionType" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblFrenchPromotionType" width="100px" runat="server" Text='<%# Eval("FrenchPromotionType") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="English Promotion Category" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="EnglishPromotionCategory">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEnglishPromotionCategory" width="100px" runat="server" CssClass="input" Text='<%# Eval("EnglishPromotionCategory") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewEnglishPromotionCategory" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblEnglishPromotionCategory" width="100px" runat="server" Text='<%# Eval("EnglishPromotionCategory") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Spanish Promotion Category" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="SpanishPromotionCategory">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtSpanishPromotionCategory" width="100px" runat="server" CssClass="input" Text='<%# Eval("SpanishPromotionCategory") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewSpanishPromotionCategory" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblSpanishPromotionCategory" width="100px" runat="server" Text='<%# Eval("SpanishPromotionCategory") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="French Promotion Category" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="FrenchPromotionCategory">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtFrenchPromotionCategory" width="100px" runat="server" CssClass="input" Text='<%# Eval("FrenchPromotionCategory") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewFrenchPromotionCategory" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblFrenchPromotionCategory" width="100px" runat="server" Text='<%# Eval("FrenchPromotionCategory") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Start Date" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="StartDate">
                                <EditItemTemplate>
                                     <table>
                                          <tr>
                                               <td>
                                                    <asp:TextBox ID="txtStartDate" width="100px" runat="server" CssClass="input" Text='<%# Eval("StartDate", "{0:d}") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                               </td>
                                               <td>
                                                    <asp:ImageButton runat="Server" ID="ImageStartDate" ImageUrl="/images/Calendar.png" AlternateText="Click to show calendar" CausesValidation="False" BackColor="BlanchedAlmond" /><br />
                                                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtenderStartDate" runat="server" TargetControlID="txtStartDate" PopupButtonID="ImageStartDate" />
                                               </td>
                                          </tr>
                                     </table>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                     <table>
                                          <tr>
                                               <td>
                                                    <asp:TextBox ID="txtNewStartDate" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                               </td>
                                               <td>
                                                    <asp:ImageButton runat="Server" ID="ImageNewStartDate" ImageUrl="/images/Calendar.png" AlternateText="Click to show calendar" CausesValidation="False" BackColor="LightYellow" /><br />
                                                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtenderNewStartDate" runat="server" TargetControlID="txtNewStartDate" PopupButtonID="ImageNewStartDate" />
                                               </td>
                                          </tr>
                                     </table>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblStartDate" width="100px" runat="server" Text='<%# Eval("StartDate", "{0:d}") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="End Date" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="EndDate">
                                <EditItemTemplate>
                                     <table>
                                          <tr>
                                               <td>
                                                    <asp:TextBox ID="txtEndDate" width="100px" runat="server" CssClass="input" Text='<%# Eval("EndDate", "{0:d}") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                               </td>
                                               <td>
                                                    <asp:ImageButton runat="Server" ID="ImageEndDate" ImageUrl="/images/Calendar.png" AlternateText="Click to show calendar" CausesValidation="False" BackColor="BlanchedAlmond" /><br />
                                                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtenderEndDate" runat="server" TargetControlID="txtEndDate" PopupButtonID="ImageEndDate" />
                                               </td>
                                          </tr>
                                     </table>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                     <table>
                                          <tr>
                                               <td>
                                                    <asp:TextBox ID="txtNewEndDate" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                               </td>
                                               <td>
                                                    <asp:ImageButton runat="Server" ID="ImageNewEndDate" ImageUrl="/images/Calendar.png" AlternateText="Click to show calendar" CausesValidation="False" BackColor="LightYellow" /><br />
                                                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtenderNewEndDate" runat="server" TargetControlID="txtNewEndDate" PopupButtonID="ImageNewEndDate" />
                                               </td>
                                          </tr>
                                     </table>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblEndDate" width="100px" runat="server" Text='<%# Eval("EndDate", "{0:d}") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Min Qty" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="MinQty">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMinQty" width="100px" runat="server" CssClass="input" Text='<%# Eval("MinQty") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewMinQty" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblMinQty" width="100px" runat="server" Text='<%# Eval("MinQty") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Max Qty" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="MaxQty">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMaxQty" width="100px" runat="server" CssClass="input" Text='<%# Eval("MaxQty") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewMaxQty" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblMaxQty" width="100px" runat="server" Text='<%# Eval("MaxQty") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False" HeaderStyle-HorizontalAlign="Left">
                                <EditItemTemplate>
                                     <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="False" CommandName="Update" Text="Update"></asp:LinkButton>
                                     <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                </EditItemTemplate>
                                <FooterTemplate>
                                     <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="False" CommandName="Insert" Text="Insert"></asp:LinkButton>
                                </FooterTemplate>
                                <ItemTemplate>
                                     <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowDeleteButton="True" ShowHeader="True" />
                        </Columns>
                        <PagerSettings Mode="Numeric" />
                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                        <AlternatingRowStyle BackColor="AliceBlue" />
                    </asp:GridView><br />
                    <input id="htmlHiddenSortExpression" type="hidden" value="PromotionKey" name="htmlHiddenSortExpression" runat="server" />
                </div>
            </div>
        </section>
</asp:Content>
 

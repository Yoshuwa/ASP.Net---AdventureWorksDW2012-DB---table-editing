<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Page Title="dbo_FactSurveyResponse" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="frmdbo_FactSurveyResponse.aspx.cs" Inherits="AdventureWorksDW2012.frmdbo_FactSurveyResponse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <link rel="stylesheet" href="../Styles/Reset.css" type="text/css" media="screen" />
        <link rel="stylesheet" href="../Styles/Site.css" type="text/css" media="screen" />
        <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" ID="ScriptManager1" />
        <uc:OkMessageBox ID="ec" runat="server" />
        <section id="content">
            <h2>Dbo. Fact Survey Response</h2>
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
                    If GridView (grddbo_FactSurveyResponse) width is bigger than web-page (or screen) width (for Mobile and Tablet)...
                    1) comment above 2 lines, and
                    2) uncomment following 2 lines
                -------%>
        <%--<div style="width: 100%;">
                <div style="overflow: auto;">--%>
                <%-------------------------------------%>
                    <asp:GridView id="grddbo_FactSurveyResponse" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="SurveyResponseKey" 
                        OnRowCancelingEdit="grddbo_FactSurveyResponse_RowCancelingEdit" OnRowDataBound="grddbo_FactSurveyResponse_RowDataBound" OnRowEditing="grddbo_FactSurveyResponse_RowEditing"
                        OnPageIndexChanging="grddbo_FactSurveyResponse_PageIndexChanging" OnSorting="grddbo_FactSurveyResponse_Sorting" 
                        OnRowUpdating="grddbo_FactSurveyResponse_RowUpdating" OnRowCommand="grddbo_FactSurveyResponse_RowCommand" OnRowDeleting="grddbo_FactSurveyResponse_RowDeleting" ShowFooter="True" Font-Size="Medium" >
                        <Columns>
                            <asp:TemplateField HeaderText="Survey Response Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="SurveyResponseKey">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtSurveyResponseKey" width="100px" runat="server" CssClass="input" Text='<%# Eval("SurveyResponseKey") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewSurveyResponseKey" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblSurveyResponseKey" width="100px" runat="server" Text='<%# Eval("SurveyResponseKey") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="DateKey">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="txtDateKey" width="100px" runat="server" CssClass="input" DataTextField="DateKey" DataValueField="DateKey" BackColor="BlanchedAlmond"></asp:DropDownList>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="txtNewDateKey" width="100px" runat="server" CssClass="input" DataTextField="DateKey" DataValueField="DateKey" BackColor="LightYellow"></asp:DropDownList>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblDateKey" width="100px" runat="server" Text='<%# Eval("DateKey") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Customer Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="CustomerKey">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="txtCustomerKey" width="100px" runat="server" CssClass="input" DataTextField="CustomerKey" DataValueField="CustomerKey" BackColor="BlanchedAlmond"></asp:DropDownList>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="txtNewCustomerKey" width="100px" runat="server" CssClass="input" DataTextField="CustomerKey" DataValueField="CustomerKey" BackColor="LightYellow"></asp:DropDownList>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblCustomerKey" width="100px" runat="server" Text='<%# Eval("CustomerKey") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Product Category Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="ProductCategoryKey">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtProductCategoryKey" width="100px" runat="server" CssClass="input" Text='<%# Eval("ProductCategoryKey") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewProductCategoryKey" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblProductCategoryKey" width="100px" runat="server" Text='<%# Eval("ProductCategoryKey") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="English Product Category Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="EnglishProductCategoryName">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEnglishProductCategoryName" width="100px" runat="server" CssClass="input" Text='<%# Eval("EnglishProductCategoryName") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewEnglishProductCategoryName" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblEnglishProductCategoryName" width="100px" runat="server" Text='<%# Eval("EnglishProductCategoryName") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Product Subcategory Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="ProductSubcategoryKey">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtProductSubcategoryKey" width="100px" runat="server" CssClass="input" Text='<%# Eval("ProductSubcategoryKey") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewProductSubcategoryKey" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblProductSubcategoryKey" width="100px" runat="server" Text='<%# Eval("ProductSubcategoryKey") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="English Product Subcategory Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="EnglishProductSubcategoryName">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEnglishProductSubcategoryName" width="100px" runat="server" CssClass="input" Text='<%# Eval("EnglishProductSubcategoryName") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewEnglishProductSubcategoryName" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblEnglishProductSubcategoryName" width="100px" runat="server" Text='<%# Eval("EnglishProductSubcategoryName") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="Date">
                                <EditItemTemplate>
                                     <table>
                                          <tr>
                                               <td>
                                                    <asp:TextBox ID="txtDate" width="100px" runat="server" CssClass="input" Text='<%# Eval("Date", "{0:d}") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                               </td>
                                               <td>
                                                    <asp:ImageButton runat="Server" ID="ImageDate" ImageUrl="/images/Calendar.png" AlternateText="Click to show calendar" CausesValidation="False" BackColor="BlanchedAlmond" /><br />
                                                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtenderDate" runat="server" TargetControlID="txtDate" PopupButtonID="ImageDate" />
                                               </td>
                                          </tr>
                                     </table>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                     <table>
                                          <tr>
                                               <td>
                                                    <asp:TextBox ID="txtNewDate" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                               </td>
                                               <td>
                                                    <asp:ImageButton runat="Server" ID="ImageNewDate" ImageUrl="/images/Calendar.png" AlternateText="Click to show calendar" CausesValidation="False" BackColor="LightYellow" /><br />
                                                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtenderNewDate" runat="server" TargetControlID="txtNewDate" PopupButtonID="ImageNewDate" />
                                               </td>
                                          </tr>
                                     </table>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblDate" width="100px" runat="server" Text='<%# Eval("Date", "{0:d}") %>'></asp:Label>
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
                    <input id="htmlHiddenSortExpression" type="hidden" value="SurveyResponseKey" name="htmlHiddenSortExpression" runat="server" />
                </div>
            </div>
        </section>
</asp:Content>
 

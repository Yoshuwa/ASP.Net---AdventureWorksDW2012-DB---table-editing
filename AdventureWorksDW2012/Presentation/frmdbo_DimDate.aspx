<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Page Title="dbo_DimDate" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="frmdbo_DimDate.aspx.cs" Inherits="AdventureWorksDW2012.frmdbo_DimDate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <link rel="stylesheet" href="../Styles/Reset.css" type="text/css" media="screen" />
        <link rel="stylesheet" href="../Styles/Site.css" type="text/css" media="screen" />
        <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" ID="ScriptManager1" />
        <uc:OkMessageBox ID="ec" runat="server" />
        <section id="content">
            <h2>Dbo. Dim Date</h2>
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
                    If GridView (grddbo_DimDate) width is bigger than web-page (or screen) width (for Mobile and Tablet)...
                    1) comment above 2 lines, and
                    2) uncomment following 2 lines
                -------%>
        <%--<div style="width: 100%;">
                <div style="overflow: auto;">--%>
                <%-------------------------------------%>
                    <asp:GridView id="grddbo_DimDate" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="DateKey" 
                        OnRowCancelingEdit="grddbo_DimDate_RowCancelingEdit" OnRowDataBound="grddbo_DimDate_RowDataBound" OnRowEditing="grddbo_DimDate_RowEditing"
                        OnPageIndexChanging="grddbo_DimDate_PageIndexChanging" OnSorting="grddbo_DimDate_Sorting" 
                        OnRowUpdating="grddbo_DimDate_RowUpdating" OnRowCommand="grddbo_DimDate_RowCommand" OnRowDeleting="grddbo_DimDate_RowDeleting" ShowFooter="True" Font-Size="Medium" >
                        <Columns>
                            <asp:TemplateField HeaderText="Date Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="DateKey">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDateKey" width="100px" runat="server" CssClass="input" Text='<%# Eval("DateKey") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewDateKey" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblDateKey" width="100px" runat="server" Text='<%# Eval("DateKey") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Full Date Alternate Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="FullDateAlternateKey">
                                <EditItemTemplate>
                                     <table>
                                          <tr>
                                               <td>
                                                    <asp:TextBox ID="txtFullDateAlternateKey" width="100px" runat="server" CssClass="input" Text='<%# Eval("FullDateAlternateKey", "{0:d}") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                               </td>
                                               <td>
                                                    <asp:ImageButton runat="Server" ID="ImageFullDateAlternateKey" ImageUrl="/images/Calendar.png" AlternateText="Click to show calendar" CausesValidation="False" BackColor="BlanchedAlmond" /><br />
                                                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtenderFullDateAlternateKey" runat="server" TargetControlID="txtFullDateAlternateKey" PopupButtonID="ImageFullDateAlternateKey" />
                                               </td>
                                          </tr>
                                     </table>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                     <table>
                                          <tr>
                                               <td>
                                                    <asp:TextBox ID="txtNewFullDateAlternateKey" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                               </td>
                                               <td>
                                                    <asp:ImageButton runat="Server" ID="ImageNewFullDateAlternateKey" ImageUrl="/images/Calendar.png" AlternateText="Click to show calendar" CausesValidation="False" BackColor="LightYellow" /><br />
                                                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtenderNewFullDateAlternateKey" runat="server" TargetControlID="txtNewFullDateAlternateKey" PopupButtonID="ImageNewFullDateAlternateKey" />
                                               </td>
                                          </tr>
                                     </table>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblFullDateAlternateKey" width="100px" runat="server" Text='<%# Eval("FullDateAlternateKey", "{0:d}") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Day Number Of Week" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="DayNumberOfWeek">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDayNumberOfWeek" width="100px" runat="server" CssClass="input" Text='<%# Eval("DayNumberOfWeek") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewDayNumberOfWeek" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblDayNumberOfWeek" width="100px" runat="server" Text='<%# Eval("DayNumberOfWeek") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="English Day Name Of Week" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="EnglishDayNameOfWeek">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEnglishDayNameOfWeek" width="100px" runat="server" CssClass="input" Text='<%# Eval("EnglishDayNameOfWeek") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewEnglishDayNameOfWeek" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblEnglishDayNameOfWeek" width="100px" runat="server" Text='<%# Eval("EnglishDayNameOfWeek") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Spanish Day Name Of Week" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="SpanishDayNameOfWeek">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtSpanishDayNameOfWeek" width="100px" runat="server" CssClass="input" Text='<%# Eval("SpanishDayNameOfWeek") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewSpanishDayNameOfWeek" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblSpanishDayNameOfWeek" width="100px" runat="server" Text='<%# Eval("SpanishDayNameOfWeek") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="French Day Name Of Week" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="FrenchDayNameOfWeek">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtFrenchDayNameOfWeek" width="100px" runat="server" CssClass="input" Text='<%# Eval("FrenchDayNameOfWeek") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewFrenchDayNameOfWeek" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblFrenchDayNameOfWeek" width="100px" runat="server" Text='<%# Eval("FrenchDayNameOfWeek") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Day Number Of Month" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="DayNumberOfMonth">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDayNumberOfMonth" width="100px" runat="server" CssClass="input" Text='<%# Eval("DayNumberOfMonth") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewDayNumberOfMonth" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblDayNumberOfMonth" width="100px" runat="server" Text='<%# Eval("DayNumberOfMonth") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Day Number Of Year" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="DayNumberOfYear">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDayNumberOfYear" width="100px" runat="server" CssClass="input" Text='<%# Eval("DayNumberOfYear") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewDayNumberOfYear" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblDayNumberOfYear" width="100px" runat="server" Text='<%# Eval("DayNumberOfYear") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Week Number Of Year" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="WeekNumberOfYear">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtWeekNumberOfYear" width="100px" runat="server" CssClass="input" Text='<%# Eval("WeekNumberOfYear") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewWeekNumberOfYear" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblWeekNumberOfYear" width="100px" runat="server" Text='<%# Eval("WeekNumberOfYear") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="English Month Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="EnglishMonthName">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEnglishMonthName" width="100px" runat="server" CssClass="input" Text='<%# Eval("EnglishMonthName") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewEnglishMonthName" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblEnglishMonthName" width="100px" runat="server" Text='<%# Eval("EnglishMonthName") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Spanish Month Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="SpanishMonthName">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtSpanishMonthName" width="100px" runat="server" CssClass="input" Text='<%# Eval("SpanishMonthName") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewSpanishMonthName" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblSpanishMonthName" width="100px" runat="server" Text='<%# Eval("SpanishMonthName") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="French Month Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="FrenchMonthName">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtFrenchMonthName" width="100px" runat="server" CssClass="input" Text='<%# Eval("FrenchMonthName") %>' BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewFrenchMonthName" width="100px" runat="server" CssClass="input" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblFrenchMonthName" width="100px" runat="server" Text='<%# Eval("FrenchMonthName") %>'></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Month Number Of Year" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="MonthNumberOfYear">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMonthNumberOfYear" width="100px" runat="server" CssClass="input" Text='<%# Eval("MonthNumberOfYear") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewMonthNumberOfYear" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblMonthNumberOfYear" width="100px" runat="server" Text='<%# Eval("MonthNumberOfYear") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Calendar Quarter" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="CalendarQuarter">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCalendarQuarter" width="100px" runat="server" CssClass="input" Text='<%# Eval("CalendarQuarter") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewCalendarQuarter" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblCalendarQuarter" width="100px" runat="server" Text='<%# Eval("CalendarQuarter") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Calendar Year" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="CalendarYear">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCalendarYear" width="100px" runat="server" CssClass="input" Text='<%# Eval("CalendarYear") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewCalendarYear" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblCalendarYear" width="100px" runat="server" Text='<%# Eval("CalendarYear") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Calendar Semester" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="CalendarSemester">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCalendarSemester" width="100px" runat="server" CssClass="input" Text='<%# Eval("CalendarSemester") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewCalendarSemester" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblCalendarSemester" width="100px" runat="server" Text='<%# Eval("CalendarSemester") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fiscal Quarter" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="FiscalQuarter">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtFiscalQuarter" width="100px" runat="server" CssClass="input" Text='<%# Eval("FiscalQuarter") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewFiscalQuarter" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblFiscalQuarter" width="100px" runat="server" Text='<%# Eval("FiscalQuarter") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fiscal Year" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="FiscalYear">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtFiscalYear" width="100px" runat="server" CssClass="input" Text='<%# Eval("FiscalYear") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewFiscalYear" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblFiscalYear" width="100px" runat="server" Text='<%# Eval("FiscalYear") %>' style="text-align: right;"></asp:Label>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fiscal Semester" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" SortExpression="FiscalSemester">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtFiscalSemester" width="100px" runat="server" CssClass="input" Text='<%# Eval("FiscalSemester") %>' style="text-align: right;" BackColor="BlanchedAlmond"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNewFiscalSemester" width="100px" runat="server" CssClass="input" style="text-align: right;" BackColor="LightYellow"></asp:TextBox>
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblFiscalSemester" width="100px" runat="server" Text='<%# Eval("FiscalSemester") %>' style="text-align: right;"></asp:Label>
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
                    <input id="htmlHiddenSortExpression" type="hidden" value="DateKey" name="htmlHiddenSortExpression" runat="server" />
                </div>
            </div>
        </section>
</asp:Content>
 

using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using System.IO;

namespace AdventureWorksDW2012
{
    public partial class frmdbo_DimDate : System.Web.UI.Page
    {

        private dbo_DimDateDataClass clsdbo_DimDateData = new dbo_DimDateDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimDate;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {

                Session.Remove("dvdbo_DimDate");
                Session.Remove("Row");

                cmbFields.Items.Add("Date Key");
                cmbFields.Items.Add("Full Date Alternate Key");
                cmbFields.Items.Add("Day Number Of Week");
                cmbFields.Items.Add("English Day Name Of Week");
                cmbFields.Items.Add("Spanish Day Name Of Week");
                cmbFields.Items.Add("French Day Name Of Week");
                cmbFields.Items.Add("Day Number Of Month");
                cmbFields.Items.Add("Day Number Of Year");
                cmbFields.Items.Add("Week Number Of Year");
                cmbFields.Items.Add("English Month Name");
                cmbFields.Items.Add("Spanish Month Name");
                cmbFields.Items.Add("French Month Name");
                cmbFields.Items.Add("Month Number Of Year");
                cmbFields.Items.Add("Calendar Quarter");
                cmbFields.Items.Add("Calendar Year");
                cmbFields.Items.Add("Calendar Semester");
                cmbFields.Items.Add("Fiscal Quarter");
                cmbFields.Items.Add("Fiscal Year");
                cmbFields.Items.Add("Fiscal Semester");

                cmbCondition.Items.Add("Contains");
                cmbCondition.Items.Add("Equals");
                cmbCondition.Items.Add("Starts with...");
                cmbCondition.Items.Add("More than...");
                cmbCondition.Items.Add("Less than...");
                cmbCondition.Items.Add("Equal or more than...");
                cmbCondition.Items.Add("Equal or less than...");
			    
                cmbRecords.Items.Add("5");
                cmbRecords.Items.Add("10");
                cmbRecords.Items.Add("25");
                cmbRecords.Items.Add("50");
                cmbRecords.Items.Add("100");
                cmbRecords.Items.Add("500");

                LoadGriddbo_DimDate();
            }
        }

        private void LoadGriddbo_DimDate()
        {
            try {
                if ((Session["dvdbo_DimDate"] != null)) {
                    dvdbo_DimDate = (DataView)Session["dvdbo_DimDate"];
                    // DataView was not found in the session.
                } else {
                    dvdbo_DimDate = dbo_DimDateDataClass.SelectAll().DefaultView;
                    Session["dvdbo_DimDate"] = dvdbo_DimDate;
                }
                if (dvdbo_DimDate.Count > 0) {
                    grddbo_DimDate.DataSource = dvdbo_DimDate;
                    grddbo_DimDate.DataBind();
                }
                if (dvdbo_DimDate.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("DateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("FullDateAlternateKey", Type.GetType("System.DateTime"));
                    dt.Columns.Add("DayNumberOfWeek", Type.GetType("System.Byte"));
                    dt.Columns.Add("EnglishDayNameOfWeek", Type.GetType("System.String"));
                    dt.Columns.Add("SpanishDayNameOfWeek", Type.GetType("System.String"));
                    dt.Columns.Add("FrenchDayNameOfWeek", Type.GetType("System.String"));
                    dt.Columns.Add("DayNumberOfMonth", Type.GetType("System.Byte"));
                    dt.Columns.Add("DayNumberOfYear", Type.GetType("System.Int16"));
                    dt.Columns.Add("WeekNumberOfYear", Type.GetType("System.Byte"));
                    dt.Columns.Add("EnglishMonthName", Type.GetType("System.String"));
                    dt.Columns.Add("SpanishMonthName", Type.GetType("System.String"));
                    dt.Columns.Add("FrenchMonthName", Type.GetType("System.String"));
                    dt.Columns.Add("MonthNumberOfYear", Type.GetType("System.Byte"));
                    dt.Columns.Add("CalendarQuarter", Type.GetType("System.Byte"));
                    dt.Columns.Add("CalendarYear", Type.GetType("System.Int16"));
                    dt.Columns.Add("CalendarSemester", Type.GetType("System.Byte"));
                    dt.Columns.Add("FiscalQuarter", Type.GetType("System.Byte"));
                    dt.Columns.Add("FiscalYear", Type.GetType("System.Int16"));
                    dt.Columns.Add("FiscalSemester", Type.GetType("System.Byte"));
                    dvdbo_DimDate = dt.DefaultView;
                    Session["dvdbo_DimDate"] = dvdbo_DimDate;

                    grddbo_DimDate.DataSource = dvdbo_DimDate;
                    grddbo_DimDate.DataBind();

                    int TotalColumns = grddbo_DimDate.Rows[0].Cells.Count;
                    grddbo_DimDate.Rows[0].Cells.Clear();
                    grddbo_DimDate.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimDate.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimDate.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimDate.Sort = htmlHiddenSortExpression.Value;
            }
            catch (Exception ex)
            {
                ec.ShowMessage(ex.Message, " Dbo. Dim Date ");
            }
        }

        protected void grddbo_DimDate_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                TextBox txtDateKey = (TextBox)e.Row.FindControl("txtDateKey");
                if (txtDateKey != null) {
                    txtDateKey.Enabled = false;
                }
            }
        }

        protected void grddbo_DimDate_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grddbo_DimDate.EditIndex = -1;
            LoadGriddbo_DimDate();
        }

        protected void grddbo_DimDate_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grddbo_DimDate.EditIndex = e.NewEditIndex;
            Edit();
        }

        protected void grddbo_DimDate_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            UpdateRecord();
        }

        protected void grddbo_DimDate_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            DeleteRecord();
        }

        protected void grddbo_DimDate_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert")) {
                InsertRecord();
            }
        }

        protected void grddbo_DimDate_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            GridViewRow gvr = (GridViewRow)gv.BottomPagerRow;
            if (gvr != null) {
                gvr.Visible = true;
            }
        }

        protected void grddbo_DimDate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddbo_DimDate.PageIndex = e.NewPageIndex;
            LoadGriddbo_DimDate();
        }

        protected void grddbo_DimDate_Sorting(object sender, GridViewSortEventArgs e)
        {
            htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            LoadGriddbo_DimDate();
        }

        private void Edit()
        {
            try {
                dbo_DimDateClass clsdbo_DimDate = new dbo_DimDateClass();
                Label lblDateKey = (Label)grddbo_DimDate.Rows[grddbo_DimDate.EditIndex].FindControl("lblDateKey");
                clsdbo_DimDate.DateKey = System.Convert.ToInt32(lblDateKey.Text);
                clsdbo_DimDate = dbo_DimDateDataClass.Select_Record(clsdbo_DimDate);


                LoadGriddbo_DimDate();
            } catch {  
            }
        }

        private void InsertRecord()
        {
            try {
                TextBox txtNewDateKey = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewDateKey");
                TextBox txtNewFullDateAlternateKey = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewFullDateAlternateKey");
                TextBox txtNewDayNumberOfWeek = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewDayNumberOfWeek");
                TextBox txtNewEnglishDayNameOfWeek = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewEnglishDayNameOfWeek");
                TextBox txtNewSpanishDayNameOfWeek = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewSpanishDayNameOfWeek");
                TextBox txtNewFrenchDayNameOfWeek = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewFrenchDayNameOfWeek");
                TextBox txtNewDayNumberOfMonth = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewDayNumberOfMonth");
                TextBox txtNewDayNumberOfYear = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewDayNumberOfYear");
                TextBox txtNewWeekNumberOfYear = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewWeekNumberOfYear");
                TextBox txtNewEnglishMonthName = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewEnglishMonthName");
                TextBox txtNewSpanishMonthName = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewSpanishMonthName");
                TextBox txtNewFrenchMonthName = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewFrenchMonthName");
                TextBox txtNewMonthNumberOfYear = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewMonthNumberOfYear");
                TextBox txtNewCalendarQuarter = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewCalendarQuarter");
                TextBox txtNewCalendarYear = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewCalendarYear");
                TextBox txtNewCalendarSemester = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewCalendarSemester");
                TextBox txtNewFiscalQuarter = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewFiscalQuarter");
                TextBox txtNewFiscalYear = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewFiscalYear");
                TextBox txtNewFiscalSemester = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewFiscalSemester");

                dbo_DimDateClass clsdbo_DimDate = new dbo_DimDateClass();
                if (VerifyDataNew() == true) {
                    clsdbo_DimDate.DateKey = System.Convert.ToInt32(txtNewDateKey.Text);
                    clsdbo_DimDate.FullDateAlternateKey = System.Convert.ToDateTime(txtNewFullDateAlternateKey.Text);
                    clsdbo_DimDate.DayNumberOfWeek = System.Convert.ToByte(txtNewDayNumberOfWeek.Text);
                    clsdbo_DimDate.EnglishDayNameOfWeek = System.Convert.ToString(txtNewEnglishDayNameOfWeek.Text);
                    clsdbo_DimDate.SpanishDayNameOfWeek = System.Convert.ToString(txtNewSpanishDayNameOfWeek.Text);
                    clsdbo_DimDate.FrenchDayNameOfWeek = System.Convert.ToString(txtNewFrenchDayNameOfWeek.Text);
                    clsdbo_DimDate.DayNumberOfMonth = System.Convert.ToByte(txtNewDayNumberOfMonth.Text);
                    clsdbo_DimDate.DayNumberOfYear = System.Convert.ToInt16(txtNewDayNumberOfYear.Text);
                    clsdbo_DimDate.WeekNumberOfYear = System.Convert.ToByte(txtNewWeekNumberOfYear.Text);
                    clsdbo_DimDate.EnglishMonthName = System.Convert.ToString(txtNewEnglishMonthName.Text);
                    clsdbo_DimDate.SpanishMonthName = System.Convert.ToString(txtNewSpanishMonthName.Text);
                    clsdbo_DimDate.FrenchMonthName = System.Convert.ToString(txtNewFrenchMonthName.Text);
                    clsdbo_DimDate.MonthNumberOfYear = System.Convert.ToByte(txtNewMonthNumberOfYear.Text);
                    clsdbo_DimDate.CalendarQuarter = System.Convert.ToByte(txtNewCalendarQuarter.Text);
                    clsdbo_DimDate.CalendarYear = System.Convert.ToInt16(txtNewCalendarYear.Text);
                    clsdbo_DimDate.CalendarSemester = System.Convert.ToByte(txtNewCalendarSemester.Text);
                    clsdbo_DimDate.FiscalQuarter = System.Convert.ToByte(txtNewFiscalQuarter.Text);
                    clsdbo_DimDate.FiscalYear = System.Convert.ToInt16(txtNewFiscalYear.Text);
                    clsdbo_DimDate.FiscalSemester = System.Convert.ToByte(txtNewFiscalSemester.Text);
                    bool bSucess = false;
                    bSucess = dbo_DimDateDataClass.Add(clsdbo_DimDate);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimDate");
                        LoadGriddbo_DimDate();
                    } else {
                        ec.ShowMessage(" Insert failed. ", " Dbo. Dim Date ");
                    }
                }
            } catch {  
            }
        }

        private void UpdateRecord()
        {
            try {
                TextBox txtDateKey = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDateKey");
                TextBox txtFullDateAlternateKey = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFullDateAlternateKey");
                TextBox txtDayNumberOfWeek = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDayNumberOfWeek");
                TextBox txtEnglishDayNameOfWeek = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEnglishDayNameOfWeek");
                TextBox txtSpanishDayNameOfWeek = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSpanishDayNameOfWeek");
                TextBox txtFrenchDayNameOfWeek = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFrenchDayNameOfWeek");
                TextBox txtDayNumberOfMonth = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDayNumberOfMonth");
                TextBox txtDayNumberOfYear = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDayNumberOfYear");
                TextBox txtWeekNumberOfYear = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtWeekNumberOfYear");
                TextBox txtEnglishMonthName = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEnglishMonthName");
                TextBox txtSpanishMonthName = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSpanishMonthName");
                TextBox txtFrenchMonthName = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFrenchMonthName");
                TextBox txtMonthNumberOfYear = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtMonthNumberOfYear");
                TextBox txtCalendarQuarter = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCalendarQuarter");
                TextBox txtCalendarYear = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCalendarYear");
                TextBox txtCalendarSemester = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCalendarSemester");
                TextBox txtFiscalQuarter = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFiscalQuarter");
                TextBox txtFiscalYear = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFiscalYear");
                TextBox txtFiscalSemester = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFiscalSemester");

                dbo_DimDateClass oclsdbo_DimDate = new dbo_DimDateClass();
                dbo_DimDateClass clsdbo_DimDate = new dbo_DimDateClass();
                oclsdbo_DimDate.DateKey = System.Convert.ToInt32(txtDateKey.Text);
                oclsdbo_DimDate = dbo_DimDateDataClass.Select_Record(oclsdbo_DimDate);

                if (VerifyData() == true) {
                    clsdbo_DimDate.DateKey = System.Convert.ToInt32(txtDateKey.Text);
                    clsdbo_DimDate.FullDateAlternateKey = System.Convert.ToDateTime(txtFullDateAlternateKey.Text);
                    clsdbo_DimDate.DayNumberOfWeek = System.Convert.ToByte(txtDayNumberOfWeek.Text);
                    clsdbo_DimDate.EnglishDayNameOfWeek = System.Convert.ToString(txtEnglishDayNameOfWeek.Text);
                    clsdbo_DimDate.SpanishDayNameOfWeek = System.Convert.ToString(txtSpanishDayNameOfWeek.Text);
                    clsdbo_DimDate.FrenchDayNameOfWeek = System.Convert.ToString(txtFrenchDayNameOfWeek.Text);
                    clsdbo_DimDate.DayNumberOfMonth = System.Convert.ToByte(txtDayNumberOfMonth.Text);
                    clsdbo_DimDate.DayNumberOfYear = System.Convert.ToInt16(txtDayNumberOfYear.Text);
                    clsdbo_DimDate.WeekNumberOfYear = System.Convert.ToByte(txtWeekNumberOfYear.Text);
                    clsdbo_DimDate.EnglishMonthName = System.Convert.ToString(txtEnglishMonthName.Text);
                    clsdbo_DimDate.SpanishMonthName = System.Convert.ToString(txtSpanishMonthName.Text);
                    clsdbo_DimDate.FrenchMonthName = System.Convert.ToString(txtFrenchMonthName.Text);
                    clsdbo_DimDate.MonthNumberOfYear = System.Convert.ToByte(txtMonthNumberOfYear.Text);
                    clsdbo_DimDate.CalendarQuarter = System.Convert.ToByte(txtCalendarQuarter.Text);
                    clsdbo_DimDate.CalendarYear = System.Convert.ToInt16(txtCalendarYear.Text);
                    clsdbo_DimDate.CalendarSemester = System.Convert.ToByte(txtCalendarSemester.Text);
                    clsdbo_DimDate.FiscalQuarter = System.Convert.ToByte(txtFiscalQuarter.Text);
                    clsdbo_DimDate.FiscalYear = System.Convert.ToInt16(txtFiscalYear.Text);
                    clsdbo_DimDate.FiscalSemester = System.Convert.ToByte(txtFiscalSemester.Text);
                    bool bSucess = false;
                    bSucess = dbo_DimDateDataClass.Update(oclsdbo_DimDate, clsdbo_DimDate);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimDate");
                        grddbo_DimDate.EditIndex = -1;
                        LoadGriddbo_DimDate();
                    } else {
                        ec.ShowMessage(" Update failed. ", " Dbo. Dim Date ");
                    }
                }
            } catch {  
            }
        }

        private void DeleteRecord()
        {
            dbo_DimDateClass clsdbo_DimDate = new dbo_DimDateClass();
            Label lblDateKey = (Label)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblDateKey");
            clsdbo_DimDate.DateKey = System.Convert.ToInt32(lblDateKey.Text);
            clsdbo_DimDate = dbo_DimDateDataClass.Select_Record(clsdbo_DimDate);
            bool bSucess = false;
            bSucess = dbo_DimDateDataClass.Delete(clsdbo_DimDate);
            if (bSucess == true) {
                Session.Remove("dvdbo_DimDate");
                LoadGriddbo_DimDate();
            } else {
                ec.ShowMessage(" Delete failed. ", " Dbo. Dim Date ");
            }
        }

        private Boolean VerifyData()
        {
            TextBox txtDateKey = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDateKey");
            TextBox txtFullDateAlternateKey = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFullDateAlternateKey");
            TextBox txtDayNumberOfWeek = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDayNumberOfWeek");
            TextBox txtEnglishDayNameOfWeek = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEnglishDayNameOfWeek");
            TextBox txtSpanishDayNameOfWeek = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSpanishDayNameOfWeek");
            TextBox txtFrenchDayNameOfWeek = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFrenchDayNameOfWeek");
            TextBox txtDayNumberOfMonth = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDayNumberOfMonth");
            TextBox txtDayNumberOfYear = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDayNumberOfYear");
            TextBox txtWeekNumberOfYear = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtWeekNumberOfYear");
            TextBox txtEnglishMonthName = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEnglishMonthName");
            TextBox txtSpanishMonthName = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSpanishMonthName");
            TextBox txtFrenchMonthName = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFrenchMonthName");
            TextBox txtMonthNumberOfYear = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtMonthNumberOfYear");
            TextBox txtCalendarQuarter = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCalendarQuarter");
            TextBox txtCalendarYear = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCalendarYear");
            TextBox txtCalendarSemester = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCalendarSemester");
            TextBox txtFiscalQuarter = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFiscalQuarter");
            TextBox txtFiscalYear = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFiscalYear");
            TextBox txtFiscalSemester = (TextBox)grddbo_DimDate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFiscalSemester");

            if (txtDateKey.Text == "") {
                ec.ShowMessage(" Date Key is Required. ", " Dbo. Dim Date ");
                txtDateKey.Focus();
                return false;}
            
            if (txtDayNumberOfWeek.Text == "") {
                ec.ShowMessage(" Day Number Of Week is Required. ", " Dbo. Dim Date ");
                txtDayNumberOfWeek.Focus();
                return false;}
            if (txtEnglishDayNameOfWeek.Text == "") {
                ec.ShowMessage(" English Day Name Of Week is Required. ", " Dbo. Dim Date ");
                txtEnglishDayNameOfWeek.Focus();
                return false;}
            if (txtSpanishDayNameOfWeek.Text == "") {
                ec.ShowMessage(" Spanish Day Name Of Week is Required. ", " Dbo. Dim Date ");
                txtSpanishDayNameOfWeek.Focus();
                return false;}
            if (txtFrenchDayNameOfWeek.Text == "") {
                ec.ShowMessage(" French Day Name Of Week is Required. ", " Dbo. Dim Date ");
                txtFrenchDayNameOfWeek.Focus();
                return false;}
            if (txtDayNumberOfMonth.Text == "") {
                ec.ShowMessage(" Day Number Of Month is Required. ", " Dbo. Dim Date ");
                txtDayNumberOfMonth.Focus();
                return false;}
            if (txtDayNumberOfYear.Text == "") {
                ec.ShowMessage(" Day Number Of Year is Required. ", " Dbo. Dim Date ");
                txtDayNumberOfYear.Focus();
                return false;}
            if (txtWeekNumberOfYear.Text == "") {
                ec.ShowMessage(" Week Number Of Year is Required. ", " Dbo. Dim Date ");
                txtWeekNumberOfYear.Focus();
                return false;}
            if (txtEnglishMonthName.Text == "") {
                ec.ShowMessage(" English Month Name is Required. ", " Dbo. Dim Date ");
                txtEnglishMonthName.Focus();
                return false;}
            if (txtSpanishMonthName.Text == "") {
                ec.ShowMessage(" Spanish Month Name is Required. ", " Dbo. Dim Date ");
                txtSpanishMonthName.Focus();
                return false;}
            if (txtFrenchMonthName.Text == "") {
                ec.ShowMessage(" French Month Name is Required. ", " Dbo. Dim Date ");
                txtFrenchMonthName.Focus();
                return false;}
            if (txtMonthNumberOfYear.Text == "") {
                ec.ShowMessage(" Month Number Of Year is Required. ", " Dbo. Dim Date ");
                txtMonthNumberOfYear.Focus();
                return false;}
            if (txtCalendarQuarter.Text == "") {
                ec.ShowMessage(" Calendar Quarter is Required. ", " Dbo. Dim Date ");
                txtCalendarQuarter.Focus();
                return false;}
            if (txtCalendarYear.Text == "") {
                ec.ShowMessage(" Calendar Year is Required. ", " Dbo. Dim Date ");
                txtCalendarYear.Focus();
                return false;}
            if (txtCalendarSemester.Text == "") {
                ec.ShowMessage(" Calendar Semester is Required. ", " Dbo. Dim Date ");
                txtCalendarSemester.Focus();
                return false;}
            if (txtFiscalQuarter.Text == "") {
                ec.ShowMessage(" Fiscal Quarter is Required. ", " Dbo. Dim Date ");
                txtFiscalQuarter.Focus();
                return false;}
            if (txtFiscalYear.Text == "") {
                ec.ShowMessage(" Fiscal Year is Required. ", " Dbo. Dim Date ");
                txtFiscalYear.Focus();
                return false;}
            if (txtFiscalSemester.Text == "") {
                ec.ShowMessage(" Fiscal Semester is Required. ", " Dbo. Dim Date ");
                txtFiscalSemester.Focus();
                return false;}
            return true;
        }

        private Boolean VerifyDataNew()
        {
            TextBox txtNewDateKey = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewDateKey");
            TextBox txtNewFullDateAlternateKey = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewFullDateAlternateKey");
            TextBox txtNewDayNumberOfWeek = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewDayNumberOfWeek");
            TextBox txtNewEnglishDayNameOfWeek = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewEnglishDayNameOfWeek");
            TextBox txtNewSpanishDayNameOfWeek = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewSpanishDayNameOfWeek");
            TextBox txtNewFrenchDayNameOfWeek = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewFrenchDayNameOfWeek");
            TextBox txtNewDayNumberOfMonth = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewDayNumberOfMonth");
            TextBox txtNewDayNumberOfYear = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewDayNumberOfYear");
            TextBox txtNewWeekNumberOfYear = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewWeekNumberOfYear");
            TextBox txtNewEnglishMonthName = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewEnglishMonthName");
            TextBox txtNewSpanishMonthName = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewSpanishMonthName");
            TextBox txtNewFrenchMonthName = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewFrenchMonthName");
            TextBox txtNewMonthNumberOfYear = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewMonthNumberOfYear");
            TextBox txtNewCalendarQuarter = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewCalendarQuarter");
            TextBox txtNewCalendarYear = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewCalendarYear");
            TextBox txtNewCalendarSemester = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewCalendarSemester");
            TextBox txtNewFiscalQuarter = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewFiscalQuarter");
            TextBox txtNewFiscalYear = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewFiscalYear");
            TextBox txtNewFiscalSemester = (TextBox)grddbo_DimDate.FooterRow.FindControl("txtNewFiscalSemester");

            if (txtNewDateKey.Text == "") {
                ec.ShowMessage(" Date Key is Required. ", " Dbo. Dim Date ");
                txtNewDateKey.Focus();
                return false;}
            
            if (txtNewDayNumberOfWeek.Text == "") {
                ec.ShowMessage(" Day Number Of Week is Required. ", " Dbo. Dim Date ");
                txtNewDayNumberOfWeek.Focus();
                return false;}
            if (txtNewEnglishDayNameOfWeek.Text == "") {
                ec.ShowMessage(" English Day Name Of Week is Required. ", " Dbo. Dim Date ");
                txtNewEnglishDayNameOfWeek.Focus();
                return false;}
            if (txtNewSpanishDayNameOfWeek.Text == "") {
                ec.ShowMessage(" Spanish Day Name Of Week is Required. ", " Dbo. Dim Date ");
                txtNewSpanishDayNameOfWeek.Focus();
                return false;}
            if (txtNewFrenchDayNameOfWeek.Text == "") {
                ec.ShowMessage(" French Day Name Of Week is Required. ", " Dbo. Dim Date ");
                txtNewFrenchDayNameOfWeek.Focus();
                return false;}
            if (txtNewDayNumberOfMonth.Text == "") {
                ec.ShowMessage(" Day Number Of Month is Required. ", " Dbo. Dim Date ");
                txtNewDayNumberOfMonth.Focus();
                return false;}
            if (txtNewDayNumberOfYear.Text == "") {
                ec.ShowMessage(" Day Number Of Year is Required. ", " Dbo. Dim Date ");
                txtNewDayNumberOfYear.Focus();
                return false;}
            if (txtNewWeekNumberOfYear.Text == "") {
                ec.ShowMessage(" Week Number Of Year is Required. ", " Dbo. Dim Date ");
                txtNewWeekNumberOfYear.Focus();
                return false;}
            if (txtNewEnglishMonthName.Text == "") {
                ec.ShowMessage(" English Month Name is Required. ", " Dbo. Dim Date ");
                txtNewEnglishMonthName.Focus();
                return false;}
            if (txtNewSpanishMonthName.Text == "") {
                ec.ShowMessage(" Spanish Month Name is Required. ", " Dbo. Dim Date ");
                txtNewSpanishMonthName.Focus();
                return false;}
            if (txtNewFrenchMonthName.Text == "") {
                ec.ShowMessage(" French Month Name is Required. ", " Dbo. Dim Date ");
                txtNewFrenchMonthName.Focus();
                return false;}
            if (txtNewMonthNumberOfYear.Text == "") {
                ec.ShowMessage(" Month Number Of Year is Required. ", " Dbo. Dim Date ");
                txtNewMonthNumberOfYear.Focus();
                return false;}
            if (txtNewCalendarQuarter.Text == "") {
                ec.ShowMessage(" Calendar Quarter is Required. ", " Dbo. Dim Date ");
                txtNewCalendarQuarter.Focus();
                return false;}
            if (txtNewCalendarYear.Text == "") {
                ec.ShowMessage(" Calendar Year is Required. ", " Dbo. Dim Date ");
                txtNewCalendarYear.Focus();
                return false;}
            if (txtNewCalendarSemester.Text == "") {
                ec.ShowMessage(" Calendar Semester is Required. ", " Dbo. Dim Date ");
                txtNewCalendarSemester.Focus();
                return false;}
            if (txtNewFiscalQuarter.Text == "") {
                ec.ShowMessage(" Fiscal Quarter is Required. ", " Dbo. Dim Date ");
                txtNewFiscalQuarter.Focus();
                return false;}
            if (txtNewFiscalYear.Text == "") {
                ec.ShowMessage(" Fiscal Year is Required. ", " Dbo. Dim Date ");
                txtNewFiscalYear.Focus();
                return false;}
            if (txtNewFiscalSemester.Text == "") {
                ec.ShowMessage(" Fiscal Semester is Required. ", " Dbo. Dim Date ");
                txtNewFiscalSemester.Focus();
                return false;}
            if (
                txtNewDateKey.Text != "" 
            )  {
                dbo_DimDateClass clsdbo_DimDate = new dbo_DimDateClass();
                clsdbo_DimDate.DateKey = System.Convert.ToInt32(txtNewDateKey.Text);
                clsdbo_DimDate = dbo_DimDateDataClass.Select_Record(clsdbo_DimDate);
                if (clsdbo_DimDate != null) {
                    ec.ShowMessage(" Record already exists. ", " Dbo. Dim Date ");
                    txtNewDateKey.Focus();
                    return false; }
            }
            return true;
        }

        private string GetSortDirection(string column)
        {
            dynamic sortDirection = "ASC";
            dynamic sortExpression = ViewState["SortExpression"] as string;
            if (sortExpression != null)
            {
                if (sortExpression == column)
                {
                    dynamic lastDirection = ViewState["SortDirection"] as string;
                    if (lastDirection != null && lastDirection == "ASC")
                    {
                        sortDirection = "DESC";
                    }
                }
            }
            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;
            return sortDirection;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_DimDate.PageIndex = 0;
		    grddbo_DimDate.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimDate();
        }

        public void butShowAll_Click(object sender, System.EventArgs e)
        {
		    txtSearch.Text = null;
		    Session.Remove("dvdbo_DimDate");
		    LoadGriddbo_DimDate();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
		    	Session.Remove("dvdbo_DimDate");
			if ((Session["dvdbo_DimDate"] != null)) {
				dvdbo_DimDate = (DataView)Session["dvdbo_DimDate"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimDate = dbo_DimDateDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimDate"] = dvdbo_DimDate;
		    	}
                if (dvdbo_DimDate.Count > 0) {
                    grddbo_DimDate.DataSource = dvdbo_DimDate;
                    grddbo_DimDate.DataBind();
                }
                if (dvdbo_DimDate.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("DateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("FullDateAlternateKey", Type.GetType("System.DateTime"));
                    dt.Columns.Add("DayNumberOfWeek", Type.GetType("System.Byte"));
                    dt.Columns.Add("EnglishDayNameOfWeek", Type.GetType("System.String"));
                    dt.Columns.Add("SpanishDayNameOfWeek", Type.GetType("System.String"));
                    dt.Columns.Add("FrenchDayNameOfWeek", Type.GetType("System.String"));
                    dt.Columns.Add("DayNumberOfMonth", Type.GetType("System.Byte"));
                    dt.Columns.Add("DayNumberOfYear", Type.GetType("System.Int16"));
                    dt.Columns.Add("WeekNumberOfYear", Type.GetType("System.Byte"));
                    dt.Columns.Add("EnglishMonthName", Type.GetType("System.String"));
                    dt.Columns.Add("SpanishMonthName", Type.GetType("System.String"));
                    dt.Columns.Add("FrenchMonthName", Type.GetType("System.String"));
                    dt.Columns.Add("MonthNumberOfYear", Type.GetType("System.Byte"));
                    dt.Columns.Add("CalendarQuarter", Type.GetType("System.Byte"));
                    dt.Columns.Add("CalendarYear", Type.GetType("System.Int16"));
                    dt.Columns.Add("CalendarSemester", Type.GetType("System.Byte"));
                    dt.Columns.Add("FiscalQuarter", Type.GetType("System.Byte"));
                    dt.Columns.Add("FiscalYear", Type.GetType("System.Int16"));
                    dt.Columns.Add("FiscalSemester", Type.GetType("System.Byte"));
                    dvdbo_DimDate = dt.DefaultView;
                    Session["dvdbo_DimDate"] = dvdbo_DimDate;

                    grddbo_DimDate.DataSource = dvdbo_DimDate;
                    grddbo_DimDate.DataBind();

                    int TotalColumns = grddbo_DimDate.Rows[0].Cells.Count;
                    grddbo_DimDate.Rows[0].Cells.Clear();
                    grddbo_DimDate.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimDate.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimDate.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimDate.Sort = htmlHiddenSortExpression.Value;
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Date ");
		    }
        }

        public void btnExport_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (ddlFile.SelectedValue == ".pdf")
                {
                    DataTable dt = new DataTable();
                    if (!string.IsNullOrEmpty(txtSearch.Text))
                    { dt = dbo_DimDateDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimDateDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Date", "Many");
                    Document document = pdfForm.CreateDocument();
                    PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
                    renderer.Document = document;
                    renderer.RenderDocument();

                    MemoryStream stream = new MemoryStream();
                    renderer.PdfDocument.Save(stream, false);

                    Response.Clear();
                    Response.ContentType = "application/" + ddlFile.SelectedItem.Text + ddlFile.SelectedValue;
                    Response.AddHeader("content-disposition", "attachment;filename=" + "Report" + ddlFile.SelectedValue);
                    Response.BinaryWrite(stream.ToArray());
                    Response.Flush();
                    Response.End();
                }
                else
                {
                    Response.Clear();
                    Response.Charset = "";
                    Response.ContentEncoding = System.Text.Encoding.UTF8;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = "application/" + ddlFile.SelectedItem.Text + ddlFile.SelectedValue;
                    Response.AddHeader("content-disposition", "attachment;filename=" + "Report" + ddlFile.SelectedValue);

                    System.IO.StringWriter sw = new System.IO.StringWriter();
                    HtmlTextWriter htw = new HtmlTextWriter(sw);
                    GridView GVExport = new GridView();
                    GVExport.DataSource = Session["dvdbo_DimDate"];
                    GVExport.DataBind();
                    GVExport.RenderControl(htw);

                    Response.Write(sw);
                    sw = null;
                    htw = null;
                    Response.Flush();
                    Response.End();
                }
            }
            catch
            {
            }
        }

    }
}
 

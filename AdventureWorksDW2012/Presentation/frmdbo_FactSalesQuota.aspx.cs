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
    public partial class frmdbo_FactSalesQuota : System.Web.UI.Page
    {

        private dbo_FactSalesQuotaDataClass clsdbo_FactSalesQuotaData = new dbo_FactSalesQuotaDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_FactSalesQuota;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                Session["EmployeeKey_SelectedValue"] = "";
                Session["DateKey_SelectedValue"] = "";

                Session.Remove("dvdbo_FactSalesQuota");
                Session.Remove("Row");

                cmbFields.Items.Add("Sales Quota Key");
                cmbFields.Items.Add("Employee Key");
                cmbFields.Items.Add("Date Key");
                cmbFields.Items.Add("Calendar Year");
                cmbFields.Items.Add("Calendar Quarter");
                cmbFields.Items.Add("Sales Amount Quota");
                cmbFields.Items.Add("Date");

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

                LoadGriddbo_FactSalesQuota();
            }
        }

        private void Loaddbo_FactSalesQuota_dbo_DimEmployeeComboBox300(GridViewRowEventArgs e)
        {
            List<dbo_FactSalesQuota_dbo_DimEmployeeClass300> dbo_FactSalesQuota_dbo_DimEmployeeList = new  List<dbo_FactSalesQuota_dbo_DimEmployeeClass300>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtEmployeeKey = (DropDownList)e.Row.FindControl("txtEmployeeKey");
                if (txtEmployeeKey != null) {
                    try {
                        dbo_FactSalesQuota_dbo_DimEmployeeList = dbo_FactSalesQuota_dbo_DimEmployeeDataClass300.List();
                        txtEmployeeKey.DataSource = dbo_FactSalesQuota_dbo_DimEmployeeList;
                        txtEmployeeKey.DataValueField = "EmployeeKey";
                        txtEmployeeKey.DataTextField = "EmployeeKey";
                        txtEmployeeKey.DataBind();
                        txtEmployeeKey.SelectedValue = Convert.ToString(Session["EmployeeKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Sales Quota ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewEmployeeKey = (DropDownList)e.Row.FindControl("txtNewEmployeeKey");
                if (txtNewEmployeeKey != null) {
                    try {
                        dbo_FactSalesQuota_dbo_DimEmployeeList = dbo_FactSalesQuota_dbo_DimEmployeeDataClass300.List();
                        txtNewEmployeeKey.DataSource = dbo_FactSalesQuota_dbo_DimEmployeeList;
                        txtNewEmployeeKey.DataValueField = "EmployeeKey";
                        txtNewEmployeeKey.DataTextField = "EmployeeKey";
                        txtNewEmployeeKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Sales Quota ");
                    }
                }
            }
        }

        private void Loaddbo_FactSalesQuota_dbo_DimDateComboBox301(GridViewRowEventArgs e)
        {
            List<dbo_FactSalesQuota_dbo_DimDateClass301> dbo_FactSalesQuota_dbo_DimDateList = new  List<dbo_FactSalesQuota_dbo_DimDateClass301>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtDateKey = (DropDownList)e.Row.FindControl("txtDateKey");
                if (txtDateKey != null) {
                    try {
                        dbo_FactSalesQuota_dbo_DimDateList = dbo_FactSalesQuota_dbo_DimDateDataClass301.List();
                        txtDateKey.DataSource = dbo_FactSalesQuota_dbo_DimDateList;
                        txtDateKey.DataValueField = "DateKey";
                        txtDateKey.DataTextField = "DateKey";
                        txtDateKey.DataBind();
                        txtDateKey.SelectedValue = Convert.ToString(Session["DateKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Sales Quota ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewDateKey = (DropDownList)e.Row.FindControl("txtNewDateKey");
                if (txtNewDateKey != null) {
                    try {
                        dbo_FactSalesQuota_dbo_DimDateList = dbo_FactSalesQuota_dbo_DimDateDataClass301.List();
                        txtNewDateKey.DataSource = dbo_FactSalesQuota_dbo_DimDateList;
                        txtNewDateKey.DataValueField = "DateKey";
                        txtNewDateKey.DataTextField = "DateKey";
                        txtNewDateKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Sales Quota ");
                    }
                }
            }
        }

        private void LoadGriddbo_FactSalesQuota()
        {
            try {
                if ((Session["dvdbo_FactSalesQuota"] != null)) {
                    dvdbo_FactSalesQuota = (DataView)Session["dvdbo_FactSalesQuota"];
                    // DataView was not found in the session.
                } else {
                    dvdbo_FactSalesQuota = dbo_FactSalesQuotaDataClass.SelectAll().DefaultView;
                    Session["dvdbo_FactSalesQuota"] = dvdbo_FactSalesQuota;
                }
                if (dvdbo_FactSalesQuota.Count > 0) {
                    grddbo_FactSalesQuota.DataSource = dvdbo_FactSalesQuota;
                    grddbo_FactSalesQuota.DataBind();
                }
                if (dvdbo_FactSalesQuota.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("SalesQuotaKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("EmployeeKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("DateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("CalendarYear", Type.GetType("System.Int16"));
                    dt.Columns.Add("CalendarQuarter", Type.GetType("System.Byte"));
                    dt.Columns.Add("SalesAmountQuota", Type.GetType("System.Decimal"));
                    dt.Columns.Add("Date", Type.GetType("System.DateTime"));
                    dvdbo_FactSalesQuota = dt.DefaultView;
                    Session["dvdbo_FactSalesQuota"] = dvdbo_FactSalesQuota;

                    grddbo_FactSalesQuota.DataSource = dvdbo_FactSalesQuota;
                    grddbo_FactSalesQuota.DataBind();

                    int TotalColumns = grddbo_FactSalesQuota.Rows[0].Cells.Count;
                    grddbo_FactSalesQuota.Rows[0].Cells.Clear();
                    grddbo_FactSalesQuota.Rows[0].Cells.Add(new TableCell());
                    grddbo_FactSalesQuota.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_FactSalesQuota.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_FactSalesQuota.Sort = htmlHiddenSortExpression.Value;
            }
            catch (Exception ex)
            {
                ec.ShowMessage(ex.Message, " Dbo. Fact Sales Quota ");
            }
        }

        protected void grddbo_FactSalesQuota_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Loaddbo_FactSalesQuota_dbo_DimEmployeeComboBox300(e);
            Loaddbo_FactSalesQuota_dbo_DimDateComboBox301(e);
            if (e.Row.RowType == DataControlRowType.DataRow) {
                TextBox txtSalesQuotaKey = (TextBox)e.Row.FindControl("txtSalesQuotaKey");
                if (txtSalesQuotaKey != null) {
                    txtSalesQuotaKey.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                TextBox txtNewSalesQuotaKey = (TextBox)e.Row.FindControl("txtNewSalesQuotaKey");
                if (txtNewSalesQuotaKey != null) {
                    txtNewSalesQuotaKey.Enabled = false;
                }
                txtNewSalesQuotaKey.Text = System.Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "FactSalesQuota"));
            }
        }

        protected void grddbo_FactSalesQuota_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grddbo_FactSalesQuota.EditIndex = -1;
            LoadGriddbo_FactSalesQuota();
        }

        protected void grddbo_FactSalesQuota_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grddbo_FactSalesQuota.EditIndex = e.NewEditIndex;
            Edit();
        }

        protected void grddbo_FactSalesQuota_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            UpdateRecord();
        }

        protected void grddbo_FactSalesQuota_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            DeleteRecord();
        }

        protected void grddbo_FactSalesQuota_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert")) {
                InsertRecord();
            }
        }

        protected void grddbo_FactSalesQuota_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            GridViewRow gvr = (GridViewRow)gv.BottomPagerRow;
            if (gvr != null) {
                gvr.Visible = true;
            }
        }

        protected void grddbo_FactSalesQuota_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddbo_FactSalesQuota.PageIndex = e.NewPageIndex;
            LoadGriddbo_FactSalesQuota();
        }

        protected void grddbo_FactSalesQuota_Sorting(object sender, GridViewSortEventArgs e)
        {
            htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            LoadGriddbo_FactSalesQuota();
        }

        private void Edit()
        {
            try {
                dbo_FactSalesQuotaClass clsdbo_FactSalesQuota = new dbo_FactSalesQuotaClass();
                Label lblSalesQuotaKey = (Label)grddbo_FactSalesQuota.Rows[grddbo_FactSalesQuota.EditIndex].FindControl("lblSalesQuotaKey");
                clsdbo_FactSalesQuota.SalesQuotaKey = System.Convert.ToInt32(lblSalesQuotaKey.Text);
                clsdbo_FactSalesQuota = dbo_FactSalesQuotaDataClass.Select_Record(clsdbo_FactSalesQuota);

                Session["EmployeeKey_SelectedValue"] = clsdbo_FactSalesQuota.EmployeeKey;
                Session["DateKey_SelectedValue"] = clsdbo_FactSalesQuota.DateKey;

                LoadGriddbo_FactSalesQuota();
            } catch {  
            }
        }

        private void InsertRecord()
        {
            try {
                DropDownList txtNewEmployeeKey = (DropDownList)grddbo_FactSalesQuota.FooterRow.FindControl("txtNewEmployeeKey");
                DropDownList txtNewDateKey = (DropDownList)grddbo_FactSalesQuota.FooterRow.FindControl("txtNewDateKey");
                TextBox txtNewCalendarYear = (TextBox)grddbo_FactSalesQuota.FooterRow.FindControl("txtNewCalendarYear");
                TextBox txtNewCalendarQuarter = (TextBox)grddbo_FactSalesQuota.FooterRow.FindControl("txtNewCalendarQuarter");
                TextBox txtNewSalesAmountQuota = (TextBox)grddbo_FactSalesQuota.FooterRow.FindControl("txtNewSalesAmountQuota");
                TextBox txtNewDate = (TextBox)grddbo_FactSalesQuota.FooterRow.FindControl("txtNewDate");

                dbo_FactSalesQuotaClass clsdbo_FactSalesQuota = new dbo_FactSalesQuotaClass();
                if (VerifyDataNew() == true) {
                    clsdbo_FactSalesQuota.EmployeeKey = System.Convert.ToInt32(txtNewEmployeeKey.SelectedValue);
                    clsdbo_FactSalesQuota.DateKey = System.Convert.ToInt32(txtNewDateKey.SelectedValue);
                    clsdbo_FactSalesQuota.CalendarYear = System.Convert.ToInt16(txtNewCalendarYear.Text);
                    clsdbo_FactSalesQuota.CalendarQuarter = System.Convert.ToByte(txtNewCalendarQuarter.Text);
                    clsdbo_FactSalesQuota.SalesAmountQuota = System.Convert.ToDecimal(txtNewSalesAmountQuota.Text);
                    if (string.IsNullOrEmpty(txtNewDate.Text)) {
                        clsdbo_FactSalesQuota.Date = null;
                    } else {
                        clsdbo_FactSalesQuota.Date = System.Convert.ToDateTime(txtNewDate.Text); }
                    bool bSucess = false;
                    bSucess = dbo_FactSalesQuotaDataClass.Add(clsdbo_FactSalesQuota);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_FactSalesQuota");
                        LoadGriddbo_FactSalesQuota();
                    } else {
                        ec.ShowMessage(" Insert failed. ", " Dbo. Fact Sales Quota ");
                    }
                }
            } catch {  
            }
        }

        private void UpdateRecord()
        {
            try {
                TextBox txtSalesQuotaKey = (TextBox)grddbo_FactSalesQuota.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesQuotaKey");
                DropDownList txtEmployeeKey = (DropDownList)grddbo_FactSalesQuota.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEmployeeKey");
                DropDownList txtDateKey = (DropDownList)grddbo_FactSalesQuota.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDateKey");
                TextBox txtCalendarYear = (TextBox)grddbo_FactSalesQuota.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCalendarYear");
                TextBox txtCalendarQuarter = (TextBox)grddbo_FactSalesQuota.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCalendarQuarter");
                TextBox txtSalesAmountQuota = (TextBox)grddbo_FactSalesQuota.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesAmountQuota");
                TextBox txtDate = (TextBox)grddbo_FactSalesQuota.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDate");

                dbo_FactSalesQuotaClass oclsdbo_FactSalesQuota = new dbo_FactSalesQuotaClass();
                dbo_FactSalesQuotaClass clsdbo_FactSalesQuota = new dbo_FactSalesQuotaClass();
                oclsdbo_FactSalesQuota.SalesQuotaKey = System.Convert.ToInt32(txtSalesQuotaKey.Text);
                oclsdbo_FactSalesQuota = dbo_FactSalesQuotaDataClass.Select_Record(oclsdbo_FactSalesQuota);

                if (VerifyData() == true) {
                    clsdbo_FactSalesQuota.EmployeeKey = System.Convert.ToInt32(txtEmployeeKey.SelectedValue);
                    clsdbo_FactSalesQuota.DateKey = System.Convert.ToInt32(txtDateKey.SelectedValue);
                    clsdbo_FactSalesQuota.CalendarYear = System.Convert.ToInt16(txtCalendarYear.Text);
                    clsdbo_FactSalesQuota.CalendarQuarter = System.Convert.ToByte(txtCalendarQuarter.Text);
                    clsdbo_FactSalesQuota.SalesAmountQuota = System.Convert.ToDecimal(txtSalesAmountQuota.Text);
                    if (string.IsNullOrEmpty(txtDate.Text)) {
                        clsdbo_FactSalesQuota.Date = null;
                    } else {
                        clsdbo_FactSalesQuota.Date = System.Convert.ToDateTime(txtDate.Text); }
                    bool bSucess = false;
                    bSucess = dbo_FactSalesQuotaDataClass.Update(oclsdbo_FactSalesQuota, clsdbo_FactSalesQuota);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_FactSalesQuota");
                        grddbo_FactSalesQuota.EditIndex = -1;
                        LoadGriddbo_FactSalesQuota();
                    } else {
                        ec.ShowMessage(" Update failed. ", " Dbo. Fact Sales Quota ");
                    }
                }
            } catch {  
            }
        }

        private void DeleteRecord()
        {
            dbo_FactSalesQuotaClass clsdbo_FactSalesQuota = new dbo_FactSalesQuotaClass();
            Label lblSalesQuotaKey = (Label)grddbo_FactSalesQuota.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblSalesQuotaKey");
            clsdbo_FactSalesQuota.SalesQuotaKey = System.Convert.ToInt32(lblSalesQuotaKey.Text);
            clsdbo_FactSalesQuota = dbo_FactSalesQuotaDataClass.Select_Record(clsdbo_FactSalesQuota);
            bool bSucess = false;
            bSucess = dbo_FactSalesQuotaDataClass.Delete(clsdbo_FactSalesQuota);
            if (bSucess == true) {
                Session.Remove("dvdbo_FactSalesQuota");
                LoadGriddbo_FactSalesQuota();
            } else {
                ec.ShowMessage(" Delete failed. ", " Dbo. Fact Sales Quota ");
            }
        }

        private Boolean VerifyData()
        {
            TextBox txtSalesQuotaKey = (TextBox)grddbo_FactSalesQuota.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesQuotaKey");
            DropDownList txtEmployeeKey = (DropDownList)grddbo_FactSalesQuota.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEmployeeKey");
            DropDownList txtDateKey = (DropDownList)grddbo_FactSalesQuota.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDateKey");
            TextBox txtCalendarYear = (TextBox)grddbo_FactSalesQuota.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCalendarYear");
            TextBox txtCalendarQuarter = (TextBox)grddbo_FactSalesQuota.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCalendarQuarter");
            TextBox txtSalesAmountQuota = (TextBox)grddbo_FactSalesQuota.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesAmountQuota");
            TextBox txtDate = (TextBox)grddbo_FactSalesQuota.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDate");

            if (txtEmployeeKey.Text == "") {
                ec.ShowMessage(" Employee Key is Required. ", " Dbo. Fact Sales Quota ");
                txtEmployeeKey.Focus();
                return false;}
            if (txtDateKey.Text == "") {
                ec.ShowMessage(" Date Key is Required. ", " Dbo. Fact Sales Quota ");
                txtDateKey.Focus();
                return false;}
            if (txtCalendarYear.Text == "") {
                ec.ShowMessage(" Calendar Year is Required. ", " Dbo. Fact Sales Quota ");
                txtCalendarYear.Focus();
                return false;}
            if (txtCalendarQuarter.Text == "") {
                ec.ShowMessage(" Calendar Quarter is Required. ", " Dbo. Fact Sales Quota ");
                txtCalendarQuarter.Focus();
                return false;}
            if (txtSalesAmountQuota.Text == "") {
                ec.ShowMessage(" Sales Amount Quota is Required. ", " Dbo. Fact Sales Quota ");
                txtSalesAmountQuota.Focus();
                return false;}
            return true;
        }

        private Boolean VerifyDataNew()
        {
            DropDownList txtNewEmployeeKey = (DropDownList)grddbo_FactSalesQuota.FooterRow.FindControl("txtNewEmployeeKey");
            DropDownList txtNewDateKey = (DropDownList)grddbo_FactSalesQuota.FooterRow.FindControl("txtNewDateKey");
            TextBox txtNewCalendarYear = (TextBox)grddbo_FactSalesQuota.FooterRow.FindControl("txtNewCalendarYear");
            TextBox txtNewCalendarQuarter = (TextBox)grddbo_FactSalesQuota.FooterRow.FindControl("txtNewCalendarQuarter");
            TextBox txtNewSalesAmountQuota = (TextBox)grddbo_FactSalesQuota.FooterRow.FindControl("txtNewSalesAmountQuota");
            TextBox txtNewDate = (TextBox)grddbo_FactSalesQuota.FooterRow.FindControl("txtNewDate");

            if (txtNewEmployeeKey.Text == "") {
                ec.ShowMessage(" Employee Key is Required. ", " Dbo. Fact Sales Quota ");
                txtNewEmployeeKey.Focus();
                return false;}
            if (txtNewDateKey.Text == "") {
                ec.ShowMessage(" Date Key is Required. ", " Dbo. Fact Sales Quota ");
                txtNewDateKey.Focus();
                return false;}
            if (txtNewCalendarYear.Text == "") {
                ec.ShowMessage(" Calendar Year is Required. ", " Dbo. Fact Sales Quota ");
                txtNewCalendarYear.Focus();
                return false;}
            if (txtNewCalendarQuarter.Text == "") {
                ec.ShowMessage(" Calendar Quarter is Required. ", " Dbo. Fact Sales Quota ");
                txtNewCalendarQuarter.Focus();
                return false;}
            if (txtNewSalesAmountQuota.Text == "") {
                ec.ShowMessage(" Sales Amount Quota is Required. ", " Dbo. Fact Sales Quota ");
                txtNewSalesAmountQuota.Focus();
                return false;}
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
		    grddbo_FactSalesQuota.PageIndex = 0;
		    grddbo_FactSalesQuota.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_FactSalesQuota();
        }

        public void butShowAll_Click(object sender, System.EventArgs e)
        {
		    txtSearch.Text = null;
		    Session.Remove("dvdbo_FactSalesQuota");
		    LoadGriddbo_FactSalesQuota();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
		    	Session.Remove("dvdbo_FactSalesQuota");
			if ((Session["dvdbo_FactSalesQuota"] != null)) {
				dvdbo_FactSalesQuota = (DataView)Session["dvdbo_FactSalesQuota"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_FactSalesQuota = dbo_FactSalesQuotaDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_FactSalesQuota"] = dvdbo_FactSalesQuota;
		    	}
                if (dvdbo_FactSalesQuota.Count > 0) {
                    grddbo_FactSalesQuota.DataSource = dvdbo_FactSalesQuota;
                    grddbo_FactSalesQuota.DataBind();
                }
                if (dvdbo_FactSalesQuota.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("SalesQuotaKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("EmployeeKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("DateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("CalendarYear", Type.GetType("System.Int16"));
                    dt.Columns.Add("CalendarQuarter", Type.GetType("System.Byte"));
                    dt.Columns.Add("SalesAmountQuota", Type.GetType("System.Decimal"));
                    dt.Columns.Add("Date", Type.GetType("System.DateTime"));
                    dvdbo_FactSalesQuota = dt.DefaultView;
                    Session["dvdbo_FactSalesQuota"] = dvdbo_FactSalesQuota;

                    grddbo_FactSalesQuota.DataSource = dvdbo_FactSalesQuota;
                    grddbo_FactSalesQuota.DataBind();

                    int TotalColumns = grddbo_FactSalesQuota.Rows[0].Cells.Count;
                    grddbo_FactSalesQuota.Rows[0].Cells.Clear();
                    grddbo_FactSalesQuota.Rows[0].Cells.Add(new TableCell());
                    grddbo_FactSalesQuota.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_FactSalesQuota.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_FactSalesQuota.Sort = htmlHiddenSortExpression.Value;
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Sales Quota ");
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
                    { dt = dbo_FactSalesQuotaDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_FactSalesQuotaDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Fact Sales Quota", "Many");
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
                    GVExport.DataSource = Session["dvdbo_FactSalesQuota"];
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
 

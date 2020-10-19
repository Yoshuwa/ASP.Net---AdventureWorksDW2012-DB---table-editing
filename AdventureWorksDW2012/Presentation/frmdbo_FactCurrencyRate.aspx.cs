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
    public partial class frmdbo_FactCurrencyRate : System.Web.UI.Page
    {

        private dbo_FactCurrencyRateDataClass clsdbo_FactCurrencyRateData = new dbo_FactCurrencyRateDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_FactCurrencyRate;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                Session["CurrencyKey_SelectedValue"] = "";
                Session["DateKey_SelectedValue"] = "";

                Session.Remove("dvdbo_FactCurrencyRate");
                Session.Remove("Row");

                cmbFields.Items.Add("Currency Key");
                cmbFields.Items.Add("Date Key");
                cmbFields.Items.Add("Average Rate");
                cmbFields.Items.Add("End Of Day Rate");
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

                LoadGriddbo_FactCurrencyRate();
            }
        }

        private void Loaddbo_FactCurrencyRate_dbo_DimCurrencyComboBox223(GridViewRowEventArgs e)
        {
            List<dbo_FactCurrencyRate_dbo_DimCurrencyClass223> dbo_FactCurrencyRate_dbo_DimCurrencyList = new  List<dbo_FactCurrencyRate_dbo_DimCurrencyClass223>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtCurrencyKey = (DropDownList)e.Row.FindControl("txtCurrencyKey");
                if (txtCurrencyKey != null) {
                    try {
                        dbo_FactCurrencyRate_dbo_DimCurrencyList = dbo_FactCurrencyRate_dbo_DimCurrencyDataClass223.List();
                        txtCurrencyKey.DataSource = dbo_FactCurrencyRate_dbo_DimCurrencyList;
                        txtCurrencyKey.DataValueField = "CurrencyKey";
                        txtCurrencyKey.DataTextField = "CurrencyName";
                        txtCurrencyKey.DataBind();
                        txtCurrencyKey.SelectedValue = Convert.ToString(Session["CurrencyKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Currency Rate ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewCurrencyKey = (DropDownList)e.Row.FindControl("txtNewCurrencyKey");
                if (txtNewCurrencyKey != null) {
                    try {
                        dbo_FactCurrencyRate_dbo_DimCurrencyList = dbo_FactCurrencyRate_dbo_DimCurrencyDataClass223.List();
                        txtNewCurrencyKey.DataSource = dbo_FactCurrencyRate_dbo_DimCurrencyList;
                        txtNewCurrencyKey.DataValueField = "CurrencyKey";
                        txtNewCurrencyKey.DataTextField = "CurrencyName";
                        txtNewCurrencyKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Currency Rate ");
                    }
                }
            }
        }

        private void Loaddbo_FactCurrencyRate_dbo_DimDateComboBox224(GridViewRowEventArgs e)
        {
            List<dbo_FactCurrencyRate_dbo_DimDateClass224> dbo_FactCurrencyRate_dbo_DimDateList = new  List<dbo_FactCurrencyRate_dbo_DimDateClass224>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtDateKey = (DropDownList)e.Row.FindControl("txtDateKey");
                if (txtDateKey != null) {
                    try {
                        dbo_FactCurrencyRate_dbo_DimDateList = dbo_FactCurrencyRate_dbo_DimDateDataClass224.List();
                        txtDateKey.DataSource = dbo_FactCurrencyRate_dbo_DimDateList;
                        txtDateKey.DataValueField = "DateKey";
                        txtDateKey.DataTextField = "FullDateAlternateKey";
                        txtDateKey.DataBind();
                        txtDateKey.SelectedValue = Convert.ToString(Session["DateKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Currency Rate ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewDateKey = (DropDownList)e.Row.FindControl("txtNewDateKey");
                if (txtNewDateKey != null) {
                    try {
                        dbo_FactCurrencyRate_dbo_DimDateList = dbo_FactCurrencyRate_dbo_DimDateDataClass224.List();
                        txtNewDateKey.DataSource = dbo_FactCurrencyRate_dbo_DimDateList;
                        txtNewDateKey.DataValueField = "DateKey";
                        txtNewDateKey.DataTextField = "FullDateAlternateKey";
                        txtNewDateKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Currency Rate ");
                    }
                }
            }
        }

        private void LoadGriddbo_FactCurrencyRate()
        {
            try {
                if ((Session["dvdbo_FactCurrencyRate"] != null)) {
                    dvdbo_FactCurrencyRate = (DataView)Session["dvdbo_FactCurrencyRate"];
                    // DataView was not found in the session.
                } else {
                    dvdbo_FactCurrencyRate = dbo_FactCurrencyRateDataClass.SelectAll().DefaultView;
                    Session["dvdbo_FactCurrencyRate"] = dvdbo_FactCurrencyRate;
                }
                if (dvdbo_FactCurrencyRate.Count > 0) {
                    grddbo_FactCurrencyRate.DataSource = dvdbo_FactCurrencyRate;
                    grddbo_FactCurrencyRate.DataBind();
                }
                if (dvdbo_FactCurrencyRate.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("CurrencyName", Type.GetType("System.Int32"));
                    dt.Columns.Add("FullDateAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("AverageRate", Type.GetType("System.Decimal"));
                    dt.Columns.Add("EndOfDayRate", Type.GetType("System.Decimal"));
                    dt.Columns.Add("Date", Type.GetType("System.DateTime"));
                    dvdbo_FactCurrencyRate = dt.DefaultView;
                    Session["dvdbo_FactCurrencyRate"] = dvdbo_FactCurrencyRate;

                    grddbo_FactCurrencyRate.DataSource = dvdbo_FactCurrencyRate;
                    grddbo_FactCurrencyRate.DataBind();

                    int TotalColumns = grddbo_FactCurrencyRate.Rows[0].Cells.Count;
                    grddbo_FactCurrencyRate.Rows[0].Cells.Clear();
                    grddbo_FactCurrencyRate.Rows[0].Cells.Add(new TableCell());
                    grddbo_FactCurrencyRate.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_FactCurrencyRate.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_FactCurrencyRate.Sort = htmlHiddenSortExpression.Value;
            }
            catch (Exception ex)
            {
                ec.ShowMessage(ex.Message, " Dbo. Fact Currency Rate ");
            }
        }

        protected void grddbo_FactCurrencyRate_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Loaddbo_FactCurrencyRate_dbo_DimCurrencyComboBox223(e);
            Loaddbo_FactCurrencyRate_dbo_DimDateComboBox224(e);
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtCurrencyKey = (DropDownList)e.Row.FindControl("txtCurrencyKey");
                if (txtCurrencyKey != null) {
                    txtCurrencyKey.Enabled = false;
                }
                DropDownList txtDateKey = (DropDownList)e.Row.FindControl("txtDateKey");
                if (txtDateKey != null) {
                    txtDateKey.Enabled = false;
                }
            }
        }

        protected void grddbo_FactCurrencyRate_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grddbo_FactCurrencyRate.EditIndex = -1;
            LoadGriddbo_FactCurrencyRate();
        }

        protected void grddbo_FactCurrencyRate_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grddbo_FactCurrencyRate.EditIndex = e.NewEditIndex;
            Edit();
        }

        protected void grddbo_FactCurrencyRate_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            UpdateRecord();
        }

        protected void grddbo_FactCurrencyRate_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            DeleteRecord();
        }

        protected void grddbo_FactCurrencyRate_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert")) {
                InsertRecord();
            }
        }

        protected void grddbo_FactCurrencyRate_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            GridViewRow gvr = (GridViewRow)gv.BottomPagerRow;
            if (gvr != null) {
                gvr.Visible = true;
            }
        }

        protected void grddbo_FactCurrencyRate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddbo_FactCurrencyRate.PageIndex = e.NewPageIndex;
            LoadGriddbo_FactCurrencyRate();
        }

        protected void grddbo_FactCurrencyRate_Sorting(object sender, GridViewSortEventArgs e)
        {
            htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            LoadGriddbo_FactCurrencyRate();
        }

        private void Edit()
        {
            try {
                dbo_FactCurrencyRateClass clsdbo_FactCurrencyRate = new dbo_FactCurrencyRateClass();
                Label lblCurrencyKey = (Label)grddbo_FactCurrencyRate.Rows[grddbo_FactCurrencyRate.EditIndex].FindControl("lblCurrencyKey");
                clsdbo_FactCurrencyRate.CurrencyKey = System.Convert.ToInt32(lblCurrencyKey.Text);
                Label lblDateKey = (Label)grddbo_FactCurrencyRate.Rows[grddbo_FactCurrencyRate.EditIndex].FindControl("lblDateKey");
                clsdbo_FactCurrencyRate.DateKey = System.Convert.ToInt32(lblDateKey.Text);
                clsdbo_FactCurrencyRate = dbo_FactCurrencyRateDataClass.Select_Record(clsdbo_FactCurrencyRate);

                Session["CurrencyKey_SelectedValue"] = clsdbo_FactCurrencyRate.CurrencyKey;
                Session["DateKey_SelectedValue"] = clsdbo_FactCurrencyRate.DateKey;

                LoadGriddbo_FactCurrencyRate();
            } catch {  
            }
        }

        private void InsertRecord()
        {
            try {
                DropDownList txtNewCurrencyKey = (DropDownList)grddbo_FactCurrencyRate.FooterRow.FindControl("txtNewCurrencyKey");
                DropDownList txtNewDateKey = (DropDownList)grddbo_FactCurrencyRate.FooterRow.FindControl("txtNewDateKey");
                TextBox txtNewAverageRate = (TextBox)grddbo_FactCurrencyRate.FooterRow.FindControl("txtNewAverageRate");
                TextBox txtNewEndOfDayRate = (TextBox)grddbo_FactCurrencyRate.FooterRow.FindControl("txtNewEndOfDayRate");
                TextBox txtNewDate = (TextBox)grddbo_FactCurrencyRate.FooterRow.FindControl("txtNewDate");

                dbo_FactCurrencyRateClass clsdbo_FactCurrencyRate = new dbo_FactCurrencyRateClass();
                if (VerifyDataNew() == true) {
                    clsdbo_FactCurrencyRate.CurrencyKey = System.Convert.ToInt32(txtNewCurrencyKey.SelectedValue);
                    clsdbo_FactCurrencyRate.DateKey = System.Convert.ToInt32(txtNewDateKey.SelectedValue);
                    clsdbo_FactCurrencyRate.AverageRate = System.Convert.ToDecimal(txtNewAverageRate.Text);
                    clsdbo_FactCurrencyRate.EndOfDayRate = System.Convert.ToDecimal(txtNewEndOfDayRate.Text);
                    if (string.IsNullOrEmpty(txtNewDate.Text)) {
                        clsdbo_FactCurrencyRate.Date = null;
                    } else {
                        clsdbo_FactCurrencyRate.Date = System.Convert.ToDateTime(txtNewDate.Text); }
                    bool bSucess = false;
                    bSucess = dbo_FactCurrencyRateDataClass.Add(clsdbo_FactCurrencyRate);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_FactCurrencyRate");
                        LoadGriddbo_FactCurrencyRate();
                    } else {
                        ec.ShowMessage(" Insert failed. ", " Dbo. Fact Currency Rate ");
                    }
                }
            } catch {  
            }
        }

        private void UpdateRecord()
        {
            try {
                DropDownList txtCurrencyKey = (DropDownList)grddbo_FactCurrencyRate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCurrencyKey");
                DropDownList txtDateKey = (DropDownList)grddbo_FactCurrencyRate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDateKey");
                TextBox txtAverageRate = (TextBox)grddbo_FactCurrencyRate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAverageRate");
                TextBox txtEndOfDayRate = (TextBox)grddbo_FactCurrencyRate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEndOfDayRate");
                TextBox txtDate = (TextBox)grddbo_FactCurrencyRate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDate");

                dbo_FactCurrencyRateClass oclsdbo_FactCurrencyRate = new dbo_FactCurrencyRateClass();
                dbo_FactCurrencyRateClass clsdbo_FactCurrencyRate = new dbo_FactCurrencyRateClass();
                oclsdbo_FactCurrencyRate.CurrencyKey = System.Convert.ToInt32(txtCurrencyKey.Text);
                oclsdbo_FactCurrencyRate.DateKey = System.Convert.ToInt32(txtDateKey.Text);
                oclsdbo_FactCurrencyRate = dbo_FactCurrencyRateDataClass.Select_Record(oclsdbo_FactCurrencyRate);

                if (VerifyData() == true) {
                    clsdbo_FactCurrencyRate.CurrencyKey = System.Convert.ToInt32(txtCurrencyKey.SelectedValue);
                    clsdbo_FactCurrencyRate.DateKey = System.Convert.ToInt32(txtDateKey.SelectedValue);
                    clsdbo_FactCurrencyRate.AverageRate = System.Convert.ToDecimal(txtAverageRate.Text);
                    clsdbo_FactCurrencyRate.EndOfDayRate = System.Convert.ToDecimal(txtEndOfDayRate.Text);
                    if (string.IsNullOrEmpty(txtDate.Text)) {
                        clsdbo_FactCurrencyRate.Date = null;
                    } else {
                        clsdbo_FactCurrencyRate.Date = System.Convert.ToDateTime(txtDate.Text); }
                    bool bSucess = false;
                    bSucess = dbo_FactCurrencyRateDataClass.Update(oclsdbo_FactCurrencyRate, clsdbo_FactCurrencyRate);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_FactCurrencyRate");
                        grddbo_FactCurrencyRate.EditIndex = -1;
                        LoadGriddbo_FactCurrencyRate();
                    } else {
                        ec.ShowMessage(" Update failed. ", " Dbo. Fact Currency Rate ");
                    }
                }
            } catch {  
            }
        }

        private void DeleteRecord()
        {
            dbo_FactCurrencyRateClass clsdbo_FactCurrencyRate = new dbo_FactCurrencyRateClass();
            Label lblCurrencyKey = (Label)grddbo_FactCurrencyRate.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblCurrencyKey");
            clsdbo_FactCurrencyRate.CurrencyKey = System.Convert.ToInt32(lblCurrencyKey.Text);
            Label lblDateKey = (Label)grddbo_FactCurrencyRate.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblDateKey");
            clsdbo_FactCurrencyRate.DateKey = System.Convert.ToInt32(lblDateKey.Text);
            clsdbo_FactCurrencyRate = dbo_FactCurrencyRateDataClass.Select_Record(clsdbo_FactCurrencyRate);
            bool bSucess = false;
            bSucess = dbo_FactCurrencyRateDataClass.Delete(clsdbo_FactCurrencyRate);
            if (bSucess == true) {
                Session.Remove("dvdbo_FactCurrencyRate");
                LoadGriddbo_FactCurrencyRate();
            } else {
                ec.ShowMessage(" Delete failed. ", " Dbo. Fact Currency Rate ");
            }
        }

        private Boolean VerifyData()
        {
            DropDownList txtCurrencyKey = (DropDownList)grddbo_FactCurrencyRate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCurrencyKey");
            DropDownList txtDateKey = (DropDownList)grddbo_FactCurrencyRate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDateKey");
            TextBox txtAverageRate = (TextBox)grddbo_FactCurrencyRate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAverageRate");
            TextBox txtEndOfDayRate = (TextBox)grddbo_FactCurrencyRate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEndOfDayRate");
            TextBox txtDate = (TextBox)grddbo_FactCurrencyRate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDate");

            if (txtCurrencyKey.Text == "") {
                ec.ShowMessage(" Currency Key is Required. ", " Dbo. Fact Currency Rate ");
                txtCurrencyKey.Focus();
                return false;}
            if (txtDateKey.Text == "") {
                ec.ShowMessage(" Date Key is Required. ", " Dbo. Fact Currency Rate ");
                txtDateKey.Focus();
                return false;}
            if (txtAverageRate.Text == "") {
                ec.ShowMessage(" Average Rate is Required. ", " Dbo. Fact Currency Rate ");
                txtAverageRate.Focus();
                return false;}
            if (txtEndOfDayRate.Text == "") {
                ec.ShowMessage(" End Of Day Rate is Required. ", " Dbo. Fact Currency Rate ");
                txtEndOfDayRate.Focus();
                return false;}
            return true;
        }

        private Boolean VerifyDataNew()
        {
            DropDownList txtNewCurrencyKey = (DropDownList)grddbo_FactCurrencyRate.FooterRow.FindControl("txtNewCurrencyKey");
            DropDownList txtNewDateKey = (DropDownList)grddbo_FactCurrencyRate.FooterRow.FindControl("txtNewDateKey");
            TextBox txtNewAverageRate = (TextBox)grddbo_FactCurrencyRate.FooterRow.FindControl("txtNewAverageRate");
            TextBox txtNewEndOfDayRate = (TextBox)grddbo_FactCurrencyRate.FooterRow.FindControl("txtNewEndOfDayRate");
            TextBox txtNewDate = (TextBox)grddbo_FactCurrencyRate.FooterRow.FindControl("txtNewDate");

            if (txtNewCurrencyKey.Text == "") {
                ec.ShowMessage(" Currency Key is Required. ", " Dbo. Fact Currency Rate ");
                txtNewCurrencyKey.Focus();
                return false;}
            if (txtNewDateKey.Text == "") {
                ec.ShowMessage(" Date Key is Required. ", " Dbo. Fact Currency Rate ");
                txtNewDateKey.Focus();
                return false;}
            if (txtNewAverageRate.Text == "") {
                ec.ShowMessage(" Average Rate is Required. ", " Dbo. Fact Currency Rate ");
                txtNewAverageRate.Focus();
                return false;}
            if (txtNewEndOfDayRate.Text == "") {
                ec.ShowMessage(" End Of Day Rate is Required. ", " Dbo. Fact Currency Rate ");
                txtNewEndOfDayRate.Focus();
                return false;}
            if (
                txtNewCurrencyKey.SelectedIndex != -1 
                && txtNewDateKey.SelectedIndex != -1 
            )  {
                dbo_FactCurrencyRateClass clsdbo_FactCurrencyRate = new dbo_FactCurrencyRateClass();
                clsdbo_FactCurrencyRate.CurrencyKey = System.Convert.ToInt32(txtNewCurrencyKey.SelectedValue);
                clsdbo_FactCurrencyRate.DateKey = System.Convert.ToInt32(txtNewDateKey.SelectedValue);
                clsdbo_FactCurrencyRate = dbo_FactCurrencyRateDataClass.Select_Record(clsdbo_FactCurrencyRate);
                if (clsdbo_FactCurrencyRate != null) {
                    ec.ShowMessage(" Record already exists. ", " Dbo. Fact Currency Rate ");
                    txtNewCurrencyKey.Focus();
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
		    grddbo_FactCurrencyRate.PageIndex = 0;
		    grddbo_FactCurrencyRate.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_FactCurrencyRate();
        }

        public void butShowAll_Click(object sender, System.EventArgs e)
        {
		    txtSearch.Text = null;
		    Session.Remove("dvdbo_FactCurrencyRate");
		    LoadGriddbo_FactCurrencyRate();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
		    	Session.Remove("dvdbo_FactCurrencyRate");
			if ((Session["dvdbo_FactCurrencyRate"] != null)) {
				dvdbo_FactCurrencyRate = (DataView)Session["dvdbo_FactCurrencyRate"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_FactCurrencyRate = dbo_FactCurrencyRateDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_FactCurrencyRate"] = dvdbo_FactCurrencyRate;
		    	}
                if (dvdbo_FactCurrencyRate.Count > 0) {
                    grddbo_FactCurrencyRate.DataSource = dvdbo_FactCurrencyRate;
                    grddbo_FactCurrencyRate.DataBind();
                }
                if (dvdbo_FactCurrencyRate.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("CurrencyName", Type.GetType("System.Int32"));
                    dt.Columns.Add("FullDateAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("AverageRate", Type.GetType("System.Decimal"));
                    dt.Columns.Add("EndOfDayRate", Type.GetType("System.Decimal"));
                    dt.Columns.Add("Date", Type.GetType("System.DateTime"));
                    dvdbo_FactCurrencyRate = dt.DefaultView;
                    Session["dvdbo_FactCurrencyRate"] = dvdbo_FactCurrencyRate;

                    grddbo_FactCurrencyRate.DataSource = dvdbo_FactCurrencyRate;
                    grddbo_FactCurrencyRate.DataBind();

                    int TotalColumns = grddbo_FactCurrencyRate.Rows[0].Cells.Count;
                    grddbo_FactCurrencyRate.Rows[0].Cells.Clear();
                    grddbo_FactCurrencyRate.Rows[0].Cells.Add(new TableCell());
                    grddbo_FactCurrencyRate.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_FactCurrencyRate.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_FactCurrencyRate.Sort = htmlHiddenSortExpression.Value;
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Currency Rate ");
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
                    { dt = dbo_FactCurrencyRateDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_FactCurrencyRateDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Fact Currency Rate", "Many");
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
                    GVExport.DataSource = Session["dvdbo_FactCurrencyRate"];
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
 

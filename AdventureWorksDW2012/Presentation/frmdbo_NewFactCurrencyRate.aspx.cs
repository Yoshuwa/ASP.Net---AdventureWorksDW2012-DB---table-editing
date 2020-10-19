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
    public partial class frmdbo_NewFactCurrencyRate : System.Web.UI.Page
    {

        private dbo_NewFactCurrencyRateDataClass clsdbo_NewFactCurrencyRateData = new dbo_NewFactCurrencyRateDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_NewFactCurrencyRate;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {

                Session.Remove("dvdbo_NewFactCurrencyRate");
                Session.Remove("Row");

                cmbFields.Items.Add("Average Rate");
                cmbFields.Items.Add("Currency I D");
                cmbFields.Items.Add("Currency Date");
                cmbFields.Items.Add("End Of Day Rate");
                cmbFields.Items.Add("Currency Key");
                cmbFields.Items.Add("Date Key");

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

                LoadGriddbo_NewFactCurrencyRate();
            }
        }

        private void LoadGriddbo_NewFactCurrencyRate()
        {
            try {
                if ((Session["dvdbo_NewFactCurrencyRate"] != null)) {
                    dvdbo_NewFactCurrencyRate = (DataView)Session["dvdbo_NewFactCurrencyRate"];
                    // DataView was not found in the session.
                } else {
                    dvdbo_NewFactCurrencyRate = dbo_NewFactCurrencyRateDataClass.SelectAll().DefaultView;
                    Session["dvdbo_NewFactCurrencyRate"] = dvdbo_NewFactCurrencyRate;
                }
                if (dvdbo_NewFactCurrencyRate.Count > 0) {
                    grddbo_NewFactCurrencyRate.DataSource = dvdbo_NewFactCurrencyRate;
                    grddbo_NewFactCurrencyRate.DataBind();
                }
                if (dvdbo_NewFactCurrencyRate.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("AverageRate", Type.GetType("System.Decimal"));
                    dt.Columns.Add("CurrencyID", Type.GetType("System.String"));
                    dt.Columns.Add("CurrencyDate", Type.GetType("System.DateTime"));
                    dt.Columns.Add("EndOfDayRate", Type.GetType("System.Decimal"));
                    dt.Columns.Add("CurrencyKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("DateKey", Type.GetType("System.Int32"));
                    dvdbo_NewFactCurrencyRate = dt.DefaultView;
                    Session["dvdbo_NewFactCurrencyRate"] = dvdbo_NewFactCurrencyRate;

                    grddbo_NewFactCurrencyRate.DataSource = dvdbo_NewFactCurrencyRate;
                    grddbo_NewFactCurrencyRate.DataBind();

                    int TotalColumns = grddbo_NewFactCurrencyRate.Rows[0].Cells.Count;
                    grddbo_NewFactCurrencyRate.Rows[0].Cells.Clear();
                    grddbo_NewFactCurrencyRate.Rows[0].Cells.Add(new TableCell());
                    grddbo_NewFactCurrencyRate.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_NewFactCurrencyRate.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_NewFactCurrencyRate.Sort = htmlHiddenSortExpression.Value;
            }
            catch (Exception ex)
            {
                ec.ShowMessage(ex.Message, " Dbo. New Fact Currency Rate ");
            }
        }

        protected void grddbo_NewFactCurrencyRate_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                TextBox txtAverageRate = (TextBox)e.Row.FindControl("txtAverageRate");
                if (txtAverageRate != null) {
                    txtAverageRate.Enabled = false;
                }
                TextBox txtCurrencyID = (TextBox)e.Row.FindControl("txtCurrencyID");
                if (txtCurrencyID != null) {
                    txtCurrencyID.Enabled = false;
                }
                TextBox txtCurrencyDate = (TextBox)e.Row.FindControl("txtCurrencyDate");
                if (txtCurrencyDate != null) {
                    txtCurrencyDate.Enabled = false;
                }
                TextBox txtEndOfDayRate = (TextBox)e.Row.FindControl("txtEndOfDayRate");
                if (txtEndOfDayRate != null) {
                    txtEndOfDayRate.Enabled = false;
                }
                TextBox txtCurrencyKey = (TextBox)e.Row.FindControl("txtCurrencyKey");
                if (txtCurrencyKey != null) {
                    txtCurrencyKey.Enabled = false;
                }
                TextBox txtDateKey = (TextBox)e.Row.FindControl("txtDateKey");
                if (txtDateKey != null) {
                    txtDateKey.Enabled = false;
                }
            }
        }

        protected void grddbo_NewFactCurrencyRate_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grddbo_NewFactCurrencyRate.EditIndex = -1;
            LoadGriddbo_NewFactCurrencyRate();
        }

        protected void grddbo_NewFactCurrencyRate_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grddbo_NewFactCurrencyRate.EditIndex = e.NewEditIndex;
            Edit();
        }

        protected void grddbo_NewFactCurrencyRate_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            UpdateRecord();
        }

        protected void grddbo_NewFactCurrencyRate_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            DeleteRecord();
        }

        protected void grddbo_NewFactCurrencyRate_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert")) {
                InsertRecord();
            }
        }

        protected void grddbo_NewFactCurrencyRate_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            GridViewRow gvr = (GridViewRow)gv.BottomPagerRow;
            if (gvr != null) {
                gvr.Visible = true;
            }
        }

        protected void grddbo_NewFactCurrencyRate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddbo_NewFactCurrencyRate.PageIndex = e.NewPageIndex;
            LoadGriddbo_NewFactCurrencyRate();
        }

        protected void grddbo_NewFactCurrencyRate_Sorting(object sender, GridViewSortEventArgs e)
        {
            htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            LoadGriddbo_NewFactCurrencyRate();
        }

        private void Edit()
        {
            try {
                dbo_NewFactCurrencyRateClass clsdbo_NewFactCurrencyRate = new dbo_NewFactCurrencyRateClass();
                Label lblAverageRate = (Label)grddbo_NewFactCurrencyRate.Rows[grddbo_NewFactCurrencyRate.EditIndex].FindControl("lblAverageRate");
                clsdbo_NewFactCurrencyRate.AverageRate = System.Convert.ToDecimal(lblAverageRate.Text);
                clsdbo_NewFactCurrencyRate = dbo_NewFactCurrencyRateDataClass.Select_Record(clsdbo_NewFactCurrencyRate);


                LoadGriddbo_NewFactCurrencyRate();
            } catch {  
            }
        }

        private void InsertRecord()
        {
            try {
                TextBox txtNewAverageRate = (TextBox)grddbo_NewFactCurrencyRate.FooterRow.FindControl("txtNewAverageRate");
                TextBox txtNewCurrencyID = (TextBox)grddbo_NewFactCurrencyRate.FooterRow.FindControl("txtNewCurrencyID");
                TextBox txtNewCurrencyDate = (TextBox)grddbo_NewFactCurrencyRate.FooterRow.FindControl("txtNewCurrencyDate");
                TextBox txtNewEndOfDayRate = (TextBox)grddbo_NewFactCurrencyRate.FooterRow.FindControl("txtNewEndOfDayRate");
                TextBox txtNewCurrencyKey = (TextBox)grddbo_NewFactCurrencyRate.FooterRow.FindControl("txtNewCurrencyKey");
                TextBox txtNewDateKey = (TextBox)grddbo_NewFactCurrencyRate.FooterRow.FindControl("txtNewDateKey");

                dbo_NewFactCurrencyRateClass clsdbo_NewFactCurrencyRate = new dbo_NewFactCurrencyRateClass();
                if (VerifyDataNew() == true) {
                    if (string.IsNullOrEmpty(txtNewAverageRate.Text)) {
                        clsdbo_NewFactCurrencyRate.AverageRate = null;
                    } else {
                        clsdbo_NewFactCurrencyRate.AverageRate = System.Convert.ToDecimal(txtNewAverageRate.Text); }
                    if (string.IsNullOrEmpty(txtNewCurrencyID.Text)) {
                        clsdbo_NewFactCurrencyRate.CurrencyID = null;
                    } else {
                        clsdbo_NewFactCurrencyRate.CurrencyID = txtNewCurrencyID.Text; }
                    if (string.IsNullOrEmpty(txtNewCurrencyDate.Text)) {
                        clsdbo_NewFactCurrencyRate.CurrencyDate = null;
                    } else {
                        clsdbo_NewFactCurrencyRate.CurrencyDate = System.Convert.ToDateTime(txtNewCurrencyDate.Text); }
                    if (string.IsNullOrEmpty(txtNewEndOfDayRate.Text)) {
                        clsdbo_NewFactCurrencyRate.EndOfDayRate = null;
                    } else {
                        clsdbo_NewFactCurrencyRate.EndOfDayRate = System.Convert.ToDecimal(txtNewEndOfDayRate.Text); }
                    if (string.IsNullOrEmpty(txtNewCurrencyKey.Text)) {
                        clsdbo_NewFactCurrencyRate.CurrencyKey = null;
                    } else {
                        clsdbo_NewFactCurrencyRate.CurrencyKey = System.Convert.ToInt32(txtNewCurrencyKey.Text); }
                    if (string.IsNullOrEmpty(txtNewDateKey.Text)) {
                        clsdbo_NewFactCurrencyRate.DateKey = null;
                    } else {
                        clsdbo_NewFactCurrencyRate.DateKey = System.Convert.ToInt32(txtNewDateKey.Text); }
                    bool bSucess = false;
                    bSucess = dbo_NewFactCurrencyRateDataClass.Add(clsdbo_NewFactCurrencyRate);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_NewFactCurrencyRate");
                        LoadGriddbo_NewFactCurrencyRate();
                    } else {
                        ec.ShowMessage(" Insert failed. ", " Dbo. New Fact Currency Rate ");
                    }
                }
            } catch {  
            }
        }

        private void UpdateRecord()
        {
            try {
                TextBox txtAverageRate = (TextBox)grddbo_NewFactCurrencyRate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAverageRate");
                TextBox txtCurrencyID = (TextBox)grddbo_NewFactCurrencyRate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCurrencyID");
                TextBox txtCurrencyDate = (TextBox)grddbo_NewFactCurrencyRate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCurrencyDate");
                TextBox txtEndOfDayRate = (TextBox)grddbo_NewFactCurrencyRate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEndOfDayRate");
                TextBox txtCurrencyKey = (TextBox)grddbo_NewFactCurrencyRate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCurrencyKey");
                TextBox txtDateKey = (TextBox)grddbo_NewFactCurrencyRate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDateKey");

                dbo_NewFactCurrencyRateClass oclsdbo_NewFactCurrencyRate = new dbo_NewFactCurrencyRateClass();
                dbo_NewFactCurrencyRateClass clsdbo_NewFactCurrencyRate = new dbo_NewFactCurrencyRateClass();
                oclsdbo_NewFactCurrencyRate.AverageRate = System.Convert.ToDecimal(txtAverageRate.Text);
                oclsdbo_NewFactCurrencyRate = dbo_NewFactCurrencyRateDataClass.Select_Record(oclsdbo_NewFactCurrencyRate);

                if (VerifyData() == true) {
                    if (string.IsNullOrEmpty(txtAverageRate.Text)) {
                        clsdbo_NewFactCurrencyRate.AverageRate = null;
                    } else {
                        clsdbo_NewFactCurrencyRate.AverageRate = System.Convert.ToDecimal(txtAverageRate.Text); }
                    if (string.IsNullOrEmpty(txtCurrencyID.Text)) {
                        clsdbo_NewFactCurrencyRate.CurrencyID = null;
                    } else {
                        clsdbo_NewFactCurrencyRate.CurrencyID = txtCurrencyID.Text; }
                    if (string.IsNullOrEmpty(txtCurrencyDate.Text)) {
                        clsdbo_NewFactCurrencyRate.CurrencyDate = null;
                    } else {
                        clsdbo_NewFactCurrencyRate.CurrencyDate = System.Convert.ToDateTime(txtCurrencyDate.Text); }
                    if (string.IsNullOrEmpty(txtEndOfDayRate.Text)) {
                        clsdbo_NewFactCurrencyRate.EndOfDayRate = null;
                    } else {
                        clsdbo_NewFactCurrencyRate.EndOfDayRate = System.Convert.ToDecimal(txtEndOfDayRate.Text); }
                    if (string.IsNullOrEmpty(txtCurrencyKey.Text)) {
                        clsdbo_NewFactCurrencyRate.CurrencyKey = null;
                    } else {
                        clsdbo_NewFactCurrencyRate.CurrencyKey = System.Convert.ToInt32(txtCurrencyKey.Text); }
                    if (string.IsNullOrEmpty(txtDateKey.Text)) {
                        clsdbo_NewFactCurrencyRate.DateKey = null;
                    } else {
                        clsdbo_NewFactCurrencyRate.DateKey = System.Convert.ToInt32(txtDateKey.Text); }
                    bool bSucess = false;
                    bSucess = dbo_NewFactCurrencyRateDataClass.Update(oclsdbo_NewFactCurrencyRate, clsdbo_NewFactCurrencyRate);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_NewFactCurrencyRate");
                        grddbo_NewFactCurrencyRate.EditIndex = -1;
                        LoadGriddbo_NewFactCurrencyRate();
                    } else {
                        ec.ShowMessage(" Update failed. ", " Dbo. New Fact Currency Rate ");
                    }
                }
            } catch {  
            }
        }

        private void DeleteRecord()
        {
            dbo_NewFactCurrencyRateClass clsdbo_NewFactCurrencyRate = new dbo_NewFactCurrencyRateClass();
            Label lblAverageRate = (Label)grddbo_NewFactCurrencyRate.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblAverageRate");
            clsdbo_NewFactCurrencyRate.AverageRate = System.Convert.ToDecimal(lblAverageRate.Text);
            clsdbo_NewFactCurrencyRate = dbo_NewFactCurrencyRateDataClass.Select_Record(clsdbo_NewFactCurrencyRate);
            bool bSucess = false;
            bSucess = dbo_NewFactCurrencyRateDataClass.Delete(clsdbo_NewFactCurrencyRate);
            if (bSucess == true) {
                Session.Remove("dvdbo_NewFactCurrencyRate");
                LoadGriddbo_NewFactCurrencyRate();
            } else {
                ec.ShowMessage(" Delete failed. ", " Dbo. New Fact Currency Rate ");
            }
        }

        private Boolean VerifyData()
        {
            TextBox txtAverageRate = (TextBox)grddbo_NewFactCurrencyRate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtAverageRate");
            TextBox txtCurrencyID = (TextBox)grddbo_NewFactCurrencyRate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCurrencyID");
            TextBox txtCurrencyDate = (TextBox)grddbo_NewFactCurrencyRate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCurrencyDate");
            TextBox txtEndOfDayRate = (TextBox)grddbo_NewFactCurrencyRate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEndOfDayRate");
            TextBox txtCurrencyKey = (TextBox)grddbo_NewFactCurrencyRate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCurrencyKey");
            TextBox txtDateKey = (TextBox)grddbo_NewFactCurrencyRate.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDateKey");

            return true;
        }

        private Boolean VerifyDataNew()
        {
            TextBox txtNewAverageRate = (TextBox)grddbo_NewFactCurrencyRate.FooterRow.FindControl("txtNewAverageRate");
            TextBox txtNewCurrencyID = (TextBox)grddbo_NewFactCurrencyRate.FooterRow.FindControl("txtNewCurrencyID");
            TextBox txtNewCurrencyDate = (TextBox)grddbo_NewFactCurrencyRate.FooterRow.FindControl("txtNewCurrencyDate");
            TextBox txtNewEndOfDayRate = (TextBox)grddbo_NewFactCurrencyRate.FooterRow.FindControl("txtNewEndOfDayRate");
            TextBox txtNewCurrencyKey = (TextBox)grddbo_NewFactCurrencyRate.FooterRow.FindControl("txtNewCurrencyKey");
            TextBox txtNewDateKey = (TextBox)grddbo_NewFactCurrencyRate.FooterRow.FindControl("txtNewDateKey");

            if (
                txtNewAverageRate.Text != "" 
            )  {
                dbo_NewFactCurrencyRateClass clsdbo_NewFactCurrencyRate = new dbo_NewFactCurrencyRateClass();
                clsdbo_NewFactCurrencyRate.AverageRate = System.Convert.ToDecimal(txtNewAverageRate.Text);
                clsdbo_NewFactCurrencyRate = dbo_NewFactCurrencyRateDataClass.Select_Record(clsdbo_NewFactCurrencyRate);
                if (clsdbo_NewFactCurrencyRate != null) {
                    ec.ShowMessage(" Record already exists. ", " Dbo. New Fact Currency Rate ");
                    txtNewAverageRate.Focus();
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
		    grddbo_NewFactCurrencyRate.PageIndex = 0;
		    grddbo_NewFactCurrencyRate.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_NewFactCurrencyRate();
        }

        public void butShowAll_Click(object sender, System.EventArgs e)
        {
		    txtSearch.Text = null;
		    Session.Remove("dvdbo_NewFactCurrencyRate");
		    LoadGriddbo_NewFactCurrencyRate();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
		    	Session.Remove("dvdbo_NewFactCurrencyRate");
			if ((Session["dvdbo_NewFactCurrencyRate"] != null)) {
				dvdbo_NewFactCurrencyRate = (DataView)Session["dvdbo_NewFactCurrencyRate"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_NewFactCurrencyRate = dbo_NewFactCurrencyRateDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_NewFactCurrencyRate"] = dvdbo_NewFactCurrencyRate;
		    	}
                if (dvdbo_NewFactCurrencyRate.Count > 0) {
                    grddbo_NewFactCurrencyRate.DataSource = dvdbo_NewFactCurrencyRate;
                    grddbo_NewFactCurrencyRate.DataBind();
                }
                if (dvdbo_NewFactCurrencyRate.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("AverageRate", Type.GetType("System.Decimal"));
                    dt.Columns.Add("CurrencyID", Type.GetType("System.String"));
                    dt.Columns.Add("CurrencyDate", Type.GetType("System.DateTime"));
                    dt.Columns.Add("EndOfDayRate", Type.GetType("System.Decimal"));
                    dt.Columns.Add("CurrencyKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("DateKey", Type.GetType("System.Int32"));
                    dvdbo_NewFactCurrencyRate = dt.DefaultView;
                    Session["dvdbo_NewFactCurrencyRate"] = dvdbo_NewFactCurrencyRate;

                    grddbo_NewFactCurrencyRate.DataSource = dvdbo_NewFactCurrencyRate;
                    grddbo_NewFactCurrencyRate.DataBind();

                    int TotalColumns = grddbo_NewFactCurrencyRate.Rows[0].Cells.Count;
                    grddbo_NewFactCurrencyRate.Rows[0].Cells.Clear();
                    grddbo_NewFactCurrencyRate.Rows[0].Cells.Add(new TableCell());
                    grddbo_NewFactCurrencyRate.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_NewFactCurrencyRate.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_NewFactCurrencyRate.Sort = htmlHiddenSortExpression.Value;
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. New Fact Currency Rate ");
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
                    { dt = dbo_NewFactCurrencyRateDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_NewFactCurrencyRateDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. New Fact Currency Rate", "Many");
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
                    GVExport.DataSource = Session["dvdbo_NewFactCurrencyRate"];
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
 

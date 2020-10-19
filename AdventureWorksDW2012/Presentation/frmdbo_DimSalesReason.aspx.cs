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
    public partial class frmdbo_DimSalesReason : System.Web.UI.Page
    {

        private dbo_DimSalesReasonDataClass clsdbo_DimSalesReasonData = new dbo_DimSalesReasonDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimSalesReason;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {

                Session.Remove("dvdbo_DimSalesReason");
                Session.Remove("Row");

                cmbFields.Items.Add("Sales Reason Key");
                cmbFields.Items.Add("Sales Reason Alternate Key");
                cmbFields.Items.Add("Sales Reason Name");
                cmbFields.Items.Add("Sales Reason Reason Type");

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

                LoadGriddbo_DimSalesReason();
            }
        }

        private void LoadGriddbo_DimSalesReason()
        {
            try {
                if ((Session["dvdbo_DimSalesReason"] != null)) {
                    dvdbo_DimSalesReason = (DataView)Session["dvdbo_DimSalesReason"];
                    // DataView was not found in the session.
                } else {
                    dvdbo_DimSalesReason = dbo_DimSalesReasonDataClass.SelectAll().DefaultView;
                    Session["dvdbo_DimSalesReason"] = dvdbo_DimSalesReason;
                }
                if (dvdbo_DimSalesReason.Count > 0) {
                    grddbo_DimSalesReason.DataSource = dvdbo_DimSalesReason;
                    grddbo_DimSalesReason.DataBind();
                }
                if (dvdbo_DimSalesReason.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("SalesReasonKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("SalesReasonAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("SalesReasonName", Type.GetType("System.String"));
                    dt.Columns.Add("SalesReasonReasonType", Type.GetType("System.String"));
                    dvdbo_DimSalesReason = dt.DefaultView;
                    Session["dvdbo_DimSalesReason"] = dvdbo_DimSalesReason;

                    grddbo_DimSalesReason.DataSource = dvdbo_DimSalesReason;
                    grddbo_DimSalesReason.DataBind();

                    int TotalColumns = grddbo_DimSalesReason.Rows[0].Cells.Count;
                    grddbo_DimSalesReason.Rows[0].Cells.Clear();
                    grddbo_DimSalesReason.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimSalesReason.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimSalesReason.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimSalesReason.Sort = htmlHiddenSortExpression.Value;
            }
            catch (Exception ex)
            {
                ec.ShowMessage(ex.Message, " Dbo. Dim Sales Reason ");
            }
        }

        protected void grddbo_DimSalesReason_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                TextBox txtSalesReasonKey = (TextBox)e.Row.FindControl("txtSalesReasonKey");
                if (txtSalesReasonKey != null) {
                    txtSalesReasonKey.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                TextBox txtNewSalesReasonKey = (TextBox)e.Row.FindControl("txtNewSalesReasonKey");
                if (txtNewSalesReasonKey != null) {
                    txtNewSalesReasonKey.Enabled = false;
                }
                txtNewSalesReasonKey.Text = System.Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "DimSalesReason"));
            }
        }

        protected void grddbo_DimSalesReason_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grddbo_DimSalesReason.EditIndex = -1;
            LoadGriddbo_DimSalesReason();
        }

        protected void grddbo_DimSalesReason_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grddbo_DimSalesReason.EditIndex = e.NewEditIndex;
            Edit();
        }

        protected void grddbo_DimSalesReason_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            UpdateRecord();
        }

        protected void grddbo_DimSalesReason_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            DeleteRecord();
        }

        protected void grddbo_DimSalesReason_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert")) {
                InsertRecord();
            }
        }

        protected void grddbo_DimSalesReason_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            GridViewRow gvr = (GridViewRow)gv.BottomPagerRow;
            if (gvr != null) {
                gvr.Visible = true;
            }
        }

        protected void grddbo_DimSalesReason_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddbo_DimSalesReason.PageIndex = e.NewPageIndex;
            LoadGriddbo_DimSalesReason();
        }

        protected void grddbo_DimSalesReason_Sorting(object sender, GridViewSortEventArgs e)
        {
            htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            LoadGriddbo_DimSalesReason();
        }

        private void Edit()
        {
            try {
                dbo_DimSalesReasonClass clsdbo_DimSalesReason = new dbo_DimSalesReasonClass();
                Label lblSalesReasonKey = (Label)grddbo_DimSalesReason.Rows[grddbo_DimSalesReason.EditIndex].FindControl("lblSalesReasonKey");
                clsdbo_DimSalesReason.SalesReasonKey = System.Convert.ToInt32(lblSalesReasonKey.Text);
                clsdbo_DimSalesReason = dbo_DimSalesReasonDataClass.Select_Record(clsdbo_DimSalesReason);


                LoadGriddbo_DimSalesReason();
            } catch {  
            }
        }

        private void InsertRecord()
        {
            try {
                TextBox txtNewSalesReasonAlternateKey = (TextBox)grddbo_DimSalesReason.FooterRow.FindControl("txtNewSalesReasonAlternateKey");
                TextBox txtNewSalesReasonName = (TextBox)grddbo_DimSalesReason.FooterRow.FindControl("txtNewSalesReasonName");
                TextBox txtNewSalesReasonReasonType = (TextBox)grddbo_DimSalesReason.FooterRow.FindControl("txtNewSalesReasonReasonType");

                dbo_DimSalesReasonClass clsdbo_DimSalesReason = new dbo_DimSalesReasonClass();
                if (VerifyDataNew() == true) {
                    clsdbo_DimSalesReason.SalesReasonAlternateKey = System.Convert.ToInt32(txtNewSalesReasonAlternateKey.Text);
                    clsdbo_DimSalesReason.SalesReasonName = System.Convert.ToString(txtNewSalesReasonName.Text);
                    clsdbo_DimSalesReason.SalesReasonReasonType = System.Convert.ToString(txtNewSalesReasonReasonType.Text);
                    bool bSucess = false;
                    bSucess = dbo_DimSalesReasonDataClass.Add(clsdbo_DimSalesReason);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimSalesReason");
                        LoadGriddbo_DimSalesReason();
                    } else {
                        ec.ShowMessage(" Insert failed. ", " Dbo. Dim Sales Reason ");
                    }
                }
            } catch {  
            }
        }

        private void UpdateRecord()
        {
            try {
                TextBox txtSalesReasonKey = (TextBox)grddbo_DimSalesReason.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesReasonKey");
                TextBox txtSalesReasonAlternateKey = (TextBox)grddbo_DimSalesReason.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesReasonAlternateKey");
                TextBox txtSalesReasonName = (TextBox)grddbo_DimSalesReason.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesReasonName");
                TextBox txtSalesReasonReasonType = (TextBox)grddbo_DimSalesReason.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesReasonReasonType");

                dbo_DimSalesReasonClass oclsdbo_DimSalesReason = new dbo_DimSalesReasonClass();
                dbo_DimSalesReasonClass clsdbo_DimSalesReason = new dbo_DimSalesReasonClass();
                oclsdbo_DimSalesReason.SalesReasonKey = System.Convert.ToInt32(txtSalesReasonKey.Text);
                oclsdbo_DimSalesReason = dbo_DimSalesReasonDataClass.Select_Record(oclsdbo_DimSalesReason);

                if (VerifyData() == true) {
                    clsdbo_DimSalesReason.SalesReasonAlternateKey = System.Convert.ToInt32(txtSalesReasonAlternateKey.Text);
                    clsdbo_DimSalesReason.SalesReasonName = System.Convert.ToString(txtSalesReasonName.Text);
                    clsdbo_DimSalesReason.SalesReasonReasonType = System.Convert.ToString(txtSalesReasonReasonType.Text);
                    bool bSucess = false;
                    bSucess = dbo_DimSalesReasonDataClass.Update(oclsdbo_DimSalesReason, clsdbo_DimSalesReason);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimSalesReason");
                        grddbo_DimSalesReason.EditIndex = -1;
                        LoadGriddbo_DimSalesReason();
                    } else {
                        ec.ShowMessage(" Update failed. ", " Dbo. Dim Sales Reason ");
                    }
                }
            } catch {  
            }
        }

        private void DeleteRecord()
        {
            dbo_DimSalesReasonClass clsdbo_DimSalesReason = new dbo_DimSalesReasonClass();
            Label lblSalesReasonKey = (Label)grddbo_DimSalesReason.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblSalesReasonKey");
            clsdbo_DimSalesReason.SalesReasonKey = System.Convert.ToInt32(lblSalesReasonKey.Text);
            clsdbo_DimSalesReason = dbo_DimSalesReasonDataClass.Select_Record(clsdbo_DimSalesReason);
            bool bSucess = false;
            bSucess = dbo_DimSalesReasonDataClass.Delete(clsdbo_DimSalesReason);
            if (bSucess == true) {
                Session.Remove("dvdbo_DimSalesReason");
                LoadGriddbo_DimSalesReason();
            } else {
                ec.ShowMessage(" Delete failed. ", " Dbo. Dim Sales Reason ");
            }
        }

        private Boolean VerifyData()
        {
            TextBox txtSalesReasonKey = (TextBox)grddbo_DimSalesReason.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesReasonKey");
            TextBox txtSalesReasonAlternateKey = (TextBox)grddbo_DimSalesReason.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesReasonAlternateKey");
            TextBox txtSalesReasonName = (TextBox)grddbo_DimSalesReason.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesReasonName");
            TextBox txtSalesReasonReasonType = (TextBox)grddbo_DimSalesReason.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesReasonReasonType");

            if (txtSalesReasonAlternateKey.Text == "") {
                ec.ShowMessage(" Sales Reason Alternate Key is Required. ", " Dbo. Dim Sales Reason ");
                txtSalesReasonAlternateKey.Focus();
                return false;}
            if (txtSalesReasonName.Text == "") {
                ec.ShowMessage(" Sales Reason Name is Required. ", " Dbo. Dim Sales Reason ");
                txtSalesReasonName.Focus();
                return false;}
            if (txtSalesReasonReasonType.Text == "") {
                ec.ShowMessage(" Sales Reason Reason Type is Required. ", " Dbo. Dim Sales Reason ");
                txtSalesReasonReasonType.Focus();
                return false;}
            return true;
        }

        private Boolean VerifyDataNew()
        {
            TextBox txtNewSalesReasonAlternateKey = (TextBox)grddbo_DimSalesReason.FooterRow.FindControl("txtNewSalesReasonAlternateKey");
            TextBox txtNewSalesReasonName = (TextBox)grddbo_DimSalesReason.FooterRow.FindControl("txtNewSalesReasonName");
            TextBox txtNewSalesReasonReasonType = (TextBox)grddbo_DimSalesReason.FooterRow.FindControl("txtNewSalesReasonReasonType");

            if (txtNewSalesReasonAlternateKey.Text == "") {
                ec.ShowMessage(" Sales Reason Alternate Key is Required. ", " Dbo. Dim Sales Reason ");
                txtNewSalesReasonAlternateKey.Focus();
                return false;}
            if (txtNewSalesReasonName.Text == "") {
                ec.ShowMessage(" Sales Reason Name is Required. ", " Dbo. Dim Sales Reason ");
                txtNewSalesReasonName.Focus();
                return false;}
            if (txtNewSalesReasonReasonType.Text == "") {
                ec.ShowMessage(" Sales Reason Reason Type is Required. ", " Dbo. Dim Sales Reason ");
                txtNewSalesReasonReasonType.Focus();
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
		    grddbo_DimSalesReason.PageIndex = 0;
		    grddbo_DimSalesReason.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimSalesReason();
        }

        public void butShowAll_Click(object sender, System.EventArgs e)
        {
		    txtSearch.Text = null;
		    Session.Remove("dvdbo_DimSalesReason");
		    LoadGriddbo_DimSalesReason();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
		    	Session.Remove("dvdbo_DimSalesReason");
			if ((Session["dvdbo_DimSalesReason"] != null)) {
				dvdbo_DimSalesReason = (DataView)Session["dvdbo_DimSalesReason"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimSalesReason = dbo_DimSalesReasonDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimSalesReason"] = dvdbo_DimSalesReason;
		    	}
                if (dvdbo_DimSalesReason.Count > 0) {
                    grddbo_DimSalesReason.DataSource = dvdbo_DimSalesReason;
                    grddbo_DimSalesReason.DataBind();
                }
                if (dvdbo_DimSalesReason.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("SalesReasonKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("SalesReasonAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("SalesReasonName", Type.GetType("System.String"));
                    dt.Columns.Add("SalesReasonReasonType", Type.GetType("System.String"));
                    dvdbo_DimSalesReason = dt.DefaultView;
                    Session["dvdbo_DimSalesReason"] = dvdbo_DimSalesReason;

                    grddbo_DimSalesReason.DataSource = dvdbo_DimSalesReason;
                    grddbo_DimSalesReason.DataBind();

                    int TotalColumns = grddbo_DimSalesReason.Rows[0].Cells.Count;
                    grddbo_DimSalesReason.Rows[0].Cells.Clear();
                    grddbo_DimSalesReason.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimSalesReason.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimSalesReason.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimSalesReason.Sort = htmlHiddenSortExpression.Value;
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Sales Reason ");
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
                    { dt = dbo_DimSalesReasonDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimSalesReasonDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Sales Reason", "Many");
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
                    GVExport.DataSource = Session["dvdbo_DimSalesReason"];
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
 

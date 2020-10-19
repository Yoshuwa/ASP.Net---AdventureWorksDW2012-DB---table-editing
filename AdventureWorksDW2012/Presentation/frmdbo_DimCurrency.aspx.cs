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
    public partial class frmdbo_DimCurrency : System.Web.UI.Page
    {

        private dbo_DimCurrencyDataClass clsdbo_DimCurrencyData = new dbo_DimCurrencyDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimCurrency;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {

                Session.Remove("dvdbo_DimCurrency");
                Session.Remove("Row");

                cmbFields.Items.Add("Currency Key");
                cmbFields.Items.Add("Currency Alternate Key");
                cmbFields.Items.Add("Currency Name");

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

                LoadGriddbo_DimCurrency();
            }
        }

        private void LoadGriddbo_DimCurrency()
        {
            try {
                if ((Session["dvdbo_DimCurrency"] != null)) {
                    dvdbo_DimCurrency = (DataView)Session["dvdbo_DimCurrency"];
                    // DataView was not found in the session.
                } else {
                    dvdbo_DimCurrency = dbo_DimCurrencyDataClass.SelectAll().DefaultView;
                    Session["dvdbo_DimCurrency"] = dvdbo_DimCurrency;
                }
                if (dvdbo_DimCurrency.Count > 0) {
                    grddbo_DimCurrency.DataSource = dvdbo_DimCurrency;
                    grddbo_DimCurrency.DataBind();
                }
                if (dvdbo_DimCurrency.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("CurrencyKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("CurrencyAlternateKey", Type.GetType("System.String"));
                    dt.Columns.Add("CurrencyName", Type.GetType("System.String"));
                    dvdbo_DimCurrency = dt.DefaultView;
                    Session["dvdbo_DimCurrency"] = dvdbo_DimCurrency;

                    grddbo_DimCurrency.DataSource = dvdbo_DimCurrency;
                    grddbo_DimCurrency.DataBind();

                    int TotalColumns = grddbo_DimCurrency.Rows[0].Cells.Count;
                    grddbo_DimCurrency.Rows[0].Cells.Clear();
                    grddbo_DimCurrency.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimCurrency.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimCurrency.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimCurrency.Sort = htmlHiddenSortExpression.Value;
            }
            catch (Exception ex)
            {
                ec.ShowMessage(ex.Message, " Dbo. Dim Currency ");
            }
        }

        protected void grddbo_DimCurrency_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                TextBox txtCurrencyKey = (TextBox)e.Row.FindControl("txtCurrencyKey");
                if (txtCurrencyKey != null) {
                    txtCurrencyKey.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                TextBox txtNewCurrencyKey = (TextBox)e.Row.FindControl("txtNewCurrencyKey");
                if (txtNewCurrencyKey != null) {
                    txtNewCurrencyKey.Enabled = false;
                }
                txtNewCurrencyKey.Text = System.Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "DimCurrency"));
            }
        }

        protected void grddbo_DimCurrency_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grddbo_DimCurrency.EditIndex = -1;
            LoadGriddbo_DimCurrency();
        }

        protected void grddbo_DimCurrency_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grddbo_DimCurrency.EditIndex = e.NewEditIndex;
            Edit();
        }

        protected void grddbo_DimCurrency_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            UpdateRecord();
        }

        protected void grddbo_DimCurrency_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            DeleteRecord();
        }

        protected void grddbo_DimCurrency_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert")) {
                InsertRecord();
            }
        }

        protected void grddbo_DimCurrency_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            GridViewRow gvr = (GridViewRow)gv.BottomPagerRow;
            if (gvr != null) {
                gvr.Visible = true;
            }
        }

        protected void grddbo_DimCurrency_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddbo_DimCurrency.PageIndex = e.NewPageIndex;
            LoadGriddbo_DimCurrency();
        }

        protected void grddbo_DimCurrency_Sorting(object sender, GridViewSortEventArgs e)
        {
            htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            LoadGriddbo_DimCurrency();
        }

        private void Edit()
        {
            try {
                dbo_DimCurrencyClass clsdbo_DimCurrency = new dbo_DimCurrencyClass();
                Label lblCurrencyKey = (Label)grddbo_DimCurrency.Rows[grddbo_DimCurrency.EditIndex].FindControl("lblCurrencyKey");
                clsdbo_DimCurrency.CurrencyKey = System.Convert.ToInt32(lblCurrencyKey.Text);
                clsdbo_DimCurrency = dbo_DimCurrencyDataClass.Select_Record(clsdbo_DimCurrency);


                LoadGriddbo_DimCurrency();
            } catch {  
            }
        }

        private void InsertRecord()
        {
            try {
                TextBox txtNewCurrencyAlternateKey = (TextBox)grddbo_DimCurrency.FooterRow.FindControl("txtNewCurrencyAlternateKey");
                TextBox txtNewCurrencyName = (TextBox)grddbo_DimCurrency.FooterRow.FindControl("txtNewCurrencyName");

                dbo_DimCurrencyClass clsdbo_DimCurrency = new dbo_DimCurrencyClass();
                if (VerifyDataNew() == true) {
                    clsdbo_DimCurrency.CurrencyAlternateKey = System.Convert.ToString(txtNewCurrencyAlternateKey.Text);
                    clsdbo_DimCurrency.CurrencyName = System.Convert.ToString(txtNewCurrencyName.Text);
                    bool bSucess = false;
                    bSucess = dbo_DimCurrencyDataClass.Add(clsdbo_DimCurrency);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimCurrency");
                        LoadGriddbo_DimCurrency();
                    } else {
                        ec.ShowMessage(" Insert failed. ", " Dbo. Dim Currency ");
                    }
                }
            } catch {  
            }
        }

        private void UpdateRecord()
        {
            try {
                TextBox txtCurrencyKey = (TextBox)grddbo_DimCurrency.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCurrencyKey");
                TextBox txtCurrencyAlternateKey = (TextBox)grddbo_DimCurrency.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCurrencyAlternateKey");
                TextBox txtCurrencyName = (TextBox)grddbo_DimCurrency.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCurrencyName");

                dbo_DimCurrencyClass oclsdbo_DimCurrency = new dbo_DimCurrencyClass();
                dbo_DimCurrencyClass clsdbo_DimCurrency = new dbo_DimCurrencyClass();
                oclsdbo_DimCurrency.CurrencyKey = System.Convert.ToInt32(txtCurrencyKey.Text);
                oclsdbo_DimCurrency = dbo_DimCurrencyDataClass.Select_Record(oclsdbo_DimCurrency);

                if (VerifyData() == true) {
                    clsdbo_DimCurrency.CurrencyAlternateKey = System.Convert.ToString(txtCurrencyAlternateKey.Text);
                    clsdbo_DimCurrency.CurrencyName = System.Convert.ToString(txtCurrencyName.Text);
                    bool bSucess = false;
                    bSucess = dbo_DimCurrencyDataClass.Update(oclsdbo_DimCurrency, clsdbo_DimCurrency);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimCurrency");
                        grddbo_DimCurrency.EditIndex = -1;
                        LoadGriddbo_DimCurrency();
                    } else {
                        ec.ShowMessage(" Update failed. ", " Dbo. Dim Currency ");
                    }
                }
            } catch {  
            }
        }

        private void DeleteRecord()
        {
            dbo_DimCurrencyClass clsdbo_DimCurrency = new dbo_DimCurrencyClass();
            Label lblCurrencyKey = (Label)grddbo_DimCurrency.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblCurrencyKey");
            clsdbo_DimCurrency.CurrencyKey = System.Convert.ToInt32(lblCurrencyKey.Text);
            clsdbo_DimCurrency = dbo_DimCurrencyDataClass.Select_Record(clsdbo_DimCurrency);
            bool bSucess = false;
            bSucess = dbo_DimCurrencyDataClass.Delete(clsdbo_DimCurrency);
            if (bSucess == true) {
                Session.Remove("dvdbo_DimCurrency");
                LoadGriddbo_DimCurrency();
            } else {
                ec.ShowMessage(" Delete failed. ", " Dbo. Dim Currency ");
            }
        }

        private Boolean VerifyData()
        {
            TextBox txtCurrencyKey = (TextBox)grddbo_DimCurrency.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCurrencyKey");
            TextBox txtCurrencyAlternateKey = (TextBox)grddbo_DimCurrency.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCurrencyAlternateKey");
            TextBox txtCurrencyName = (TextBox)grddbo_DimCurrency.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCurrencyName");

            if (txtCurrencyAlternateKey.Text == "") {
                ec.ShowMessage(" Currency Alternate Key is Required. ", " Dbo. Dim Currency ");
                txtCurrencyAlternateKey.Focus();
                return false;}
            if (txtCurrencyName.Text == "") {
                ec.ShowMessage(" Currency Name is Required. ", " Dbo. Dim Currency ");
                txtCurrencyName.Focus();
                return false;}
            return true;
        }

        private Boolean VerifyDataNew()
        {
            TextBox txtNewCurrencyAlternateKey = (TextBox)grddbo_DimCurrency.FooterRow.FindControl("txtNewCurrencyAlternateKey");
            TextBox txtNewCurrencyName = (TextBox)grddbo_DimCurrency.FooterRow.FindControl("txtNewCurrencyName");

            if (txtNewCurrencyAlternateKey.Text == "") {
                ec.ShowMessage(" Currency Alternate Key is Required. ", " Dbo. Dim Currency ");
                txtNewCurrencyAlternateKey.Focus();
                return false;}
            if (txtNewCurrencyName.Text == "") {
                ec.ShowMessage(" Currency Name is Required. ", " Dbo. Dim Currency ");
                txtNewCurrencyName.Focus();
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
		    grddbo_DimCurrency.PageIndex = 0;
		    grddbo_DimCurrency.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimCurrency();
        }

        public void butShowAll_Click(object sender, System.EventArgs e)
        {
		    txtSearch.Text = null;
		    Session.Remove("dvdbo_DimCurrency");
		    LoadGriddbo_DimCurrency();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
		    	Session.Remove("dvdbo_DimCurrency");
			if ((Session["dvdbo_DimCurrency"] != null)) {
				dvdbo_DimCurrency = (DataView)Session["dvdbo_DimCurrency"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimCurrency = dbo_DimCurrencyDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimCurrency"] = dvdbo_DimCurrency;
		    	}
                if (dvdbo_DimCurrency.Count > 0) {
                    grddbo_DimCurrency.DataSource = dvdbo_DimCurrency;
                    grddbo_DimCurrency.DataBind();
                }
                if (dvdbo_DimCurrency.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("CurrencyKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("CurrencyAlternateKey", Type.GetType("System.String"));
                    dt.Columns.Add("CurrencyName", Type.GetType("System.String"));
                    dvdbo_DimCurrency = dt.DefaultView;
                    Session["dvdbo_DimCurrency"] = dvdbo_DimCurrency;

                    grddbo_DimCurrency.DataSource = dvdbo_DimCurrency;
                    grddbo_DimCurrency.DataBind();

                    int TotalColumns = grddbo_DimCurrency.Rows[0].Cells.Count;
                    grddbo_DimCurrency.Rows[0].Cells.Clear();
                    grddbo_DimCurrency.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimCurrency.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimCurrency.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimCurrency.Sort = htmlHiddenSortExpression.Value;
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Currency ");
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
                    { dt = dbo_DimCurrencyDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimCurrencyDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Currency", "Many");
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
                    GVExport.DataSource = Session["dvdbo_DimCurrency"];
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
 

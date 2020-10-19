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
    public partial class frmdbo_DimProductCategory : System.Web.UI.Page
    {

        private dbo_DimProductCategoryDataClass clsdbo_DimProductCategoryData = new dbo_DimProductCategoryDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimProductCategory;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {

                Session.Remove("dvdbo_DimProductCategory");
                Session.Remove("Row");

                cmbFields.Items.Add("Product Category Key");
                cmbFields.Items.Add("Product Category Alternate Key");
                cmbFields.Items.Add("English Product Category Name");
                cmbFields.Items.Add("Spanish Product Category Name");
                cmbFields.Items.Add("French Product Category Name");

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

                LoadGriddbo_DimProductCategory();
            }
        }

        private void LoadGriddbo_DimProductCategory()
        {
            try {
                if ((Session["dvdbo_DimProductCategory"] != null)) {
                    dvdbo_DimProductCategory = (DataView)Session["dvdbo_DimProductCategory"];
                    // DataView was not found in the session.
                } else {
                    dvdbo_DimProductCategory = dbo_DimProductCategoryDataClass.SelectAll().DefaultView;
                    Session["dvdbo_DimProductCategory"] = dvdbo_DimProductCategory;
                }
                if (dvdbo_DimProductCategory.Count > 0) {
                    grddbo_DimProductCategory.DataSource = dvdbo_DimProductCategory;
                    grddbo_DimProductCategory.DataBind();
                }
                if (dvdbo_DimProductCategory.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("ProductCategoryKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("ProductCategoryAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("EnglishProductCategoryName", Type.GetType("System.String"));
                    dt.Columns.Add("SpanishProductCategoryName", Type.GetType("System.String"));
                    dt.Columns.Add("FrenchProductCategoryName", Type.GetType("System.String"));
                    dvdbo_DimProductCategory = dt.DefaultView;
                    Session["dvdbo_DimProductCategory"] = dvdbo_DimProductCategory;

                    grddbo_DimProductCategory.DataSource = dvdbo_DimProductCategory;
                    grddbo_DimProductCategory.DataBind();

                    int TotalColumns = grddbo_DimProductCategory.Rows[0].Cells.Count;
                    grddbo_DimProductCategory.Rows[0].Cells.Clear();
                    grddbo_DimProductCategory.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimProductCategory.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimProductCategory.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimProductCategory.Sort = htmlHiddenSortExpression.Value;
            }
            catch (Exception ex)
            {
                ec.ShowMessage(ex.Message, " Dbo. Dim Product Category ");
            }
        }

        protected void grddbo_DimProductCategory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                TextBox txtProductCategoryKey = (TextBox)e.Row.FindControl("txtProductCategoryKey");
                if (txtProductCategoryKey != null) {
                    txtProductCategoryKey.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                TextBox txtNewProductCategoryKey = (TextBox)e.Row.FindControl("txtNewProductCategoryKey");
                if (txtNewProductCategoryKey != null) {
                    txtNewProductCategoryKey.Enabled = false;
                }
                txtNewProductCategoryKey.Text = System.Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "DimProductCategory"));
            }
        }

        protected void grddbo_DimProductCategory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grddbo_DimProductCategory.EditIndex = -1;
            LoadGriddbo_DimProductCategory();
        }

        protected void grddbo_DimProductCategory_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grddbo_DimProductCategory.EditIndex = e.NewEditIndex;
            Edit();
        }

        protected void grddbo_DimProductCategory_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            UpdateRecord();
        }

        protected void grddbo_DimProductCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            DeleteRecord();
        }

        protected void grddbo_DimProductCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert")) {
                InsertRecord();
            }
        }

        protected void grddbo_DimProductCategory_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            GridViewRow gvr = (GridViewRow)gv.BottomPagerRow;
            if (gvr != null) {
                gvr.Visible = true;
            }
        }

        protected void grddbo_DimProductCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddbo_DimProductCategory.PageIndex = e.NewPageIndex;
            LoadGriddbo_DimProductCategory();
        }

        protected void grddbo_DimProductCategory_Sorting(object sender, GridViewSortEventArgs e)
        {
            htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            LoadGriddbo_DimProductCategory();
        }

        private void Edit()
        {
            try {
                dbo_DimProductCategoryClass clsdbo_DimProductCategory = new dbo_DimProductCategoryClass();
                Label lblProductCategoryKey = (Label)grddbo_DimProductCategory.Rows[grddbo_DimProductCategory.EditIndex].FindControl("lblProductCategoryKey");
                clsdbo_DimProductCategory.ProductCategoryKey = System.Convert.ToInt32(lblProductCategoryKey.Text);
                clsdbo_DimProductCategory = dbo_DimProductCategoryDataClass.Select_Record(clsdbo_DimProductCategory);


                LoadGriddbo_DimProductCategory();
            } catch {  
            }
        }

        private void InsertRecord()
        {
            try {
                TextBox txtNewProductCategoryAlternateKey = (TextBox)grddbo_DimProductCategory.FooterRow.FindControl("txtNewProductCategoryAlternateKey");
                TextBox txtNewEnglishProductCategoryName = (TextBox)grddbo_DimProductCategory.FooterRow.FindControl("txtNewEnglishProductCategoryName");
                TextBox txtNewSpanishProductCategoryName = (TextBox)grddbo_DimProductCategory.FooterRow.FindControl("txtNewSpanishProductCategoryName");
                TextBox txtNewFrenchProductCategoryName = (TextBox)grddbo_DimProductCategory.FooterRow.FindControl("txtNewFrenchProductCategoryName");

                dbo_DimProductCategoryClass clsdbo_DimProductCategory = new dbo_DimProductCategoryClass();
                if (VerifyDataNew() == true) {
                    if (string.IsNullOrEmpty(txtNewProductCategoryAlternateKey.Text)) {
                        clsdbo_DimProductCategory.ProductCategoryAlternateKey = null;
                    } else {
                        clsdbo_DimProductCategory.ProductCategoryAlternateKey = System.Convert.ToInt32(txtNewProductCategoryAlternateKey.Text); }
                    clsdbo_DimProductCategory.EnglishProductCategoryName = System.Convert.ToString(txtNewEnglishProductCategoryName.Text);
                    clsdbo_DimProductCategory.SpanishProductCategoryName = System.Convert.ToString(txtNewSpanishProductCategoryName.Text);
                    clsdbo_DimProductCategory.FrenchProductCategoryName = System.Convert.ToString(txtNewFrenchProductCategoryName.Text);
                    bool bSucess = false;
                    bSucess = dbo_DimProductCategoryDataClass.Add(clsdbo_DimProductCategory);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimProductCategory");
                        LoadGriddbo_DimProductCategory();
                    } else {
                        ec.ShowMessage(" Insert failed. ", " Dbo. Dim Product Category ");
                    }
                }
            } catch {  
            }
        }

        private void UpdateRecord()
        {
            try {
                TextBox txtProductCategoryKey = (TextBox)grddbo_DimProductCategory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductCategoryKey");
                TextBox txtProductCategoryAlternateKey = (TextBox)grddbo_DimProductCategory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductCategoryAlternateKey");
                TextBox txtEnglishProductCategoryName = (TextBox)grddbo_DimProductCategory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEnglishProductCategoryName");
                TextBox txtSpanishProductCategoryName = (TextBox)grddbo_DimProductCategory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSpanishProductCategoryName");
                TextBox txtFrenchProductCategoryName = (TextBox)grddbo_DimProductCategory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFrenchProductCategoryName");

                dbo_DimProductCategoryClass oclsdbo_DimProductCategory = new dbo_DimProductCategoryClass();
                dbo_DimProductCategoryClass clsdbo_DimProductCategory = new dbo_DimProductCategoryClass();
                oclsdbo_DimProductCategory.ProductCategoryKey = System.Convert.ToInt32(txtProductCategoryKey.Text);
                oclsdbo_DimProductCategory = dbo_DimProductCategoryDataClass.Select_Record(oclsdbo_DimProductCategory);

                if (VerifyData() == true) {
                    if (string.IsNullOrEmpty(txtProductCategoryAlternateKey.Text)) {
                        clsdbo_DimProductCategory.ProductCategoryAlternateKey = null;
                    } else {
                        clsdbo_DimProductCategory.ProductCategoryAlternateKey = System.Convert.ToInt32(txtProductCategoryAlternateKey.Text); }
                    clsdbo_DimProductCategory.EnglishProductCategoryName = System.Convert.ToString(txtEnglishProductCategoryName.Text);
                    clsdbo_DimProductCategory.SpanishProductCategoryName = System.Convert.ToString(txtSpanishProductCategoryName.Text);
                    clsdbo_DimProductCategory.FrenchProductCategoryName = System.Convert.ToString(txtFrenchProductCategoryName.Text);
                    bool bSucess = false;
                    bSucess = dbo_DimProductCategoryDataClass.Update(oclsdbo_DimProductCategory, clsdbo_DimProductCategory);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimProductCategory");
                        grddbo_DimProductCategory.EditIndex = -1;
                        LoadGriddbo_DimProductCategory();
                    } else {
                        ec.ShowMessage(" Update failed. ", " Dbo. Dim Product Category ");
                    }
                }
            } catch {  
            }
        }

        private void DeleteRecord()
        {
            dbo_DimProductCategoryClass clsdbo_DimProductCategory = new dbo_DimProductCategoryClass();
            Label lblProductCategoryKey = (Label)grddbo_DimProductCategory.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblProductCategoryKey");
            clsdbo_DimProductCategory.ProductCategoryKey = System.Convert.ToInt32(lblProductCategoryKey.Text);
            clsdbo_DimProductCategory = dbo_DimProductCategoryDataClass.Select_Record(clsdbo_DimProductCategory);
            bool bSucess = false;
            bSucess = dbo_DimProductCategoryDataClass.Delete(clsdbo_DimProductCategory);
            if (bSucess == true) {
                Session.Remove("dvdbo_DimProductCategory");
                LoadGriddbo_DimProductCategory();
            } else {
                ec.ShowMessage(" Delete failed. ", " Dbo. Dim Product Category ");
            }
        }

        private Boolean VerifyData()
        {
            TextBox txtProductCategoryKey = (TextBox)grddbo_DimProductCategory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductCategoryKey");
            TextBox txtProductCategoryAlternateKey = (TextBox)grddbo_DimProductCategory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductCategoryAlternateKey");
            TextBox txtEnglishProductCategoryName = (TextBox)grddbo_DimProductCategory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEnglishProductCategoryName");
            TextBox txtSpanishProductCategoryName = (TextBox)grddbo_DimProductCategory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSpanishProductCategoryName");
            TextBox txtFrenchProductCategoryName = (TextBox)grddbo_DimProductCategory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFrenchProductCategoryName");

            if (txtEnglishProductCategoryName.Text == "") {
                ec.ShowMessage(" English Product Category Name is Required. ", " Dbo. Dim Product Category ");
                txtEnglishProductCategoryName.Focus();
                return false;}
            if (txtSpanishProductCategoryName.Text == "") {
                ec.ShowMessage(" Spanish Product Category Name is Required. ", " Dbo. Dim Product Category ");
                txtSpanishProductCategoryName.Focus();
                return false;}
            if (txtFrenchProductCategoryName.Text == "") {
                ec.ShowMessage(" French Product Category Name is Required. ", " Dbo. Dim Product Category ");
                txtFrenchProductCategoryName.Focus();
                return false;}
            return true;
        }

        private Boolean VerifyDataNew()
        {
            TextBox txtNewProductCategoryAlternateKey = (TextBox)grddbo_DimProductCategory.FooterRow.FindControl("txtNewProductCategoryAlternateKey");
            TextBox txtNewEnglishProductCategoryName = (TextBox)grddbo_DimProductCategory.FooterRow.FindControl("txtNewEnglishProductCategoryName");
            TextBox txtNewSpanishProductCategoryName = (TextBox)grddbo_DimProductCategory.FooterRow.FindControl("txtNewSpanishProductCategoryName");
            TextBox txtNewFrenchProductCategoryName = (TextBox)grddbo_DimProductCategory.FooterRow.FindControl("txtNewFrenchProductCategoryName");

            if (txtNewEnglishProductCategoryName.Text == "") {
                ec.ShowMessage(" English Product Category Name is Required. ", " Dbo. Dim Product Category ");
                txtNewEnglishProductCategoryName.Focus();
                return false;}
            if (txtNewSpanishProductCategoryName.Text == "") {
                ec.ShowMessage(" Spanish Product Category Name is Required. ", " Dbo. Dim Product Category ");
                txtNewSpanishProductCategoryName.Focus();
                return false;}
            if (txtNewFrenchProductCategoryName.Text == "") {
                ec.ShowMessage(" French Product Category Name is Required. ", " Dbo. Dim Product Category ");
                txtNewFrenchProductCategoryName.Focus();
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
		    grddbo_DimProductCategory.PageIndex = 0;
		    grddbo_DimProductCategory.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimProductCategory();
        }

        public void butShowAll_Click(object sender, System.EventArgs e)
        {
		    txtSearch.Text = null;
		    Session.Remove("dvdbo_DimProductCategory");
		    LoadGriddbo_DimProductCategory();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
		    	Session.Remove("dvdbo_DimProductCategory");
			if ((Session["dvdbo_DimProductCategory"] != null)) {
				dvdbo_DimProductCategory = (DataView)Session["dvdbo_DimProductCategory"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimProductCategory = dbo_DimProductCategoryDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimProductCategory"] = dvdbo_DimProductCategory;
		    	}
                if (dvdbo_DimProductCategory.Count > 0) {
                    grddbo_DimProductCategory.DataSource = dvdbo_DimProductCategory;
                    grddbo_DimProductCategory.DataBind();
                }
                if (dvdbo_DimProductCategory.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("ProductCategoryKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("ProductCategoryAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("EnglishProductCategoryName", Type.GetType("System.String"));
                    dt.Columns.Add("SpanishProductCategoryName", Type.GetType("System.String"));
                    dt.Columns.Add("FrenchProductCategoryName", Type.GetType("System.String"));
                    dvdbo_DimProductCategory = dt.DefaultView;
                    Session["dvdbo_DimProductCategory"] = dvdbo_DimProductCategory;

                    grddbo_DimProductCategory.DataSource = dvdbo_DimProductCategory;
                    grddbo_DimProductCategory.DataBind();

                    int TotalColumns = grddbo_DimProductCategory.Rows[0].Cells.Count;
                    grddbo_DimProductCategory.Rows[0].Cells.Clear();
                    grddbo_DimProductCategory.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimProductCategory.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimProductCategory.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimProductCategory.Sort = htmlHiddenSortExpression.Value;
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Product Category ");
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
                    { dt = dbo_DimProductCategoryDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimProductCategoryDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Product Category", "Many");
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
                    GVExport.DataSource = Session["dvdbo_DimProductCategory"];
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
 

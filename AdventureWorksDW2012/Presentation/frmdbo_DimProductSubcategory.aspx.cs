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
    public partial class frmdbo_DimProductSubcategory : System.Web.UI.Page
    {

        private dbo_DimProductSubcategoryDataClass clsdbo_DimProductSubcategoryData = new dbo_DimProductSubcategoryDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimProductSubcategory;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                Session["ProductCategoryKey_SelectedValue"] = "";

                Session.Remove("dvdbo_DimProductSubcategory");
                Session.Remove("Row");

                cmbFields.Items.Add("Product Subcategory Key");
                cmbFields.Items.Add("Product Subcategory Alternate Key");
                cmbFields.Items.Add("English Product Subcategory Name");
                cmbFields.Items.Add("Spanish Product Subcategory Name");
                cmbFields.Items.Add("French Product Subcategory Name");
                cmbFields.Items.Add("Product Category Key");

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

                LoadGriddbo_DimProductSubcategory();
            }
        }

        private void Loaddbo_DimProductSubcategory_dbo_DimProductCategoryComboBox(GridViewRowEventArgs e)
        {
            List<dbo_DimProductSubcategory_dbo_DimProductCategoryClass> dbo_DimProductSubcategory_dbo_DimProductCategoryList = new  List<dbo_DimProductSubcategory_dbo_DimProductCategoryClass>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtProductCategoryKey = (DropDownList)e.Row.FindControl("txtProductCategoryKey");
                if (txtProductCategoryKey != null) {
                    try {
                        dbo_DimProductSubcategory_dbo_DimProductCategoryList = dbo_DimProductSubcategory_dbo_DimProductCategoryDataClass.List();
                        txtProductCategoryKey.DataSource = dbo_DimProductSubcategory_dbo_DimProductCategoryList;
                        txtProductCategoryKey.DataValueField = "ProductCategoryKey";
                        txtProductCategoryKey.DataTextField = "EnglishProductCategoryName";
                        txtProductCategoryKey.DataBind();
                        txtProductCategoryKey.SelectedValue = Convert.ToString(Session["ProductCategoryKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Dim Product Subcategory ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewProductCategoryKey = (DropDownList)e.Row.FindControl("txtNewProductCategoryKey");
                if (txtNewProductCategoryKey != null) {
                    try {
                        dbo_DimProductSubcategory_dbo_DimProductCategoryList = dbo_DimProductSubcategory_dbo_DimProductCategoryDataClass.List();
                        txtNewProductCategoryKey.DataSource = dbo_DimProductSubcategory_dbo_DimProductCategoryList;
                        txtNewProductCategoryKey.DataValueField = "ProductCategoryKey";
                        txtNewProductCategoryKey.DataTextField = "EnglishProductCategoryName";
                        txtNewProductCategoryKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Dim Product Subcategory ");
                    }
                }
            }
        }

        private void LoadGriddbo_DimProductSubcategory()
        {
            try {
                if ((Session["dvdbo_DimProductSubcategory"] != null)) {
                    dvdbo_DimProductSubcategory = (DataView)Session["dvdbo_DimProductSubcategory"];
                    // DataView was not found in the session.
                } else {
                    dvdbo_DimProductSubcategory = dbo_DimProductSubcategoryDataClass.SelectAll().DefaultView;
                    Session["dvdbo_DimProductSubcategory"] = dvdbo_DimProductSubcategory;
                }
                if (dvdbo_DimProductSubcategory.Count > 0) {
                    grddbo_DimProductSubcategory.DataSource = dvdbo_DimProductSubcategory;
                    grddbo_DimProductSubcategory.DataBind();
                }
                if (dvdbo_DimProductSubcategory.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("ProductSubcategoryKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("ProductSubcategoryAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("EnglishProductSubcategoryName", Type.GetType("System.String"));
                    dt.Columns.Add("SpanishProductSubcategoryName", Type.GetType("System.String"));
                    dt.Columns.Add("FrenchProductSubcategoryName", Type.GetType("System.String"));
                    dt.Columns.Add("EnglishProductCategoryName", Type.GetType("System.Int32"));
                    dvdbo_DimProductSubcategory = dt.DefaultView;
                    Session["dvdbo_DimProductSubcategory"] = dvdbo_DimProductSubcategory;

                    grddbo_DimProductSubcategory.DataSource = dvdbo_DimProductSubcategory;
                    grddbo_DimProductSubcategory.DataBind();

                    int TotalColumns = grddbo_DimProductSubcategory.Rows[0].Cells.Count;
                    grddbo_DimProductSubcategory.Rows[0].Cells.Clear();
                    grddbo_DimProductSubcategory.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimProductSubcategory.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimProductSubcategory.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimProductSubcategory.Sort = htmlHiddenSortExpression.Value;
            }
            catch (Exception ex)
            {
                ec.ShowMessage(ex.Message, " Dbo. Dim Product Subcategory ");
            }
        }

        protected void grddbo_DimProductSubcategory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Loaddbo_DimProductSubcategory_dbo_DimProductCategoryComboBox(e);
            if (e.Row.RowType == DataControlRowType.DataRow) {
                TextBox txtProductSubcategoryKey = (TextBox)e.Row.FindControl("txtProductSubcategoryKey");
                if (txtProductSubcategoryKey != null) {
                    txtProductSubcategoryKey.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                TextBox txtNewProductSubcategoryKey = (TextBox)e.Row.FindControl("txtNewProductSubcategoryKey");
                if (txtNewProductSubcategoryKey != null) {
                    txtNewProductSubcategoryKey.Enabled = false;
                }
                txtNewProductSubcategoryKey.Text = System.Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "DimProductSubcategory"));
            }
        }

        protected void grddbo_DimProductSubcategory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grddbo_DimProductSubcategory.EditIndex = -1;
            LoadGriddbo_DimProductSubcategory();
        }

        protected void grddbo_DimProductSubcategory_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grddbo_DimProductSubcategory.EditIndex = e.NewEditIndex;
            Edit();
        }

        protected void grddbo_DimProductSubcategory_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            UpdateRecord();
        }

        protected void grddbo_DimProductSubcategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            DeleteRecord();
        }

        protected void grddbo_DimProductSubcategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert")) {
                InsertRecord();
            }
        }

        protected void grddbo_DimProductSubcategory_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            GridViewRow gvr = (GridViewRow)gv.BottomPagerRow;
            if (gvr != null) {
                gvr.Visible = true;
            }
        }

        protected void grddbo_DimProductSubcategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddbo_DimProductSubcategory.PageIndex = e.NewPageIndex;
            LoadGriddbo_DimProductSubcategory();
        }

        protected void grddbo_DimProductSubcategory_Sorting(object sender, GridViewSortEventArgs e)
        {
            htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            LoadGriddbo_DimProductSubcategory();
        }

        private void Edit()
        {
            try {
                dbo_DimProductSubcategoryClass clsdbo_DimProductSubcategory = new dbo_DimProductSubcategoryClass();
                Label lblProductSubcategoryKey = (Label)grddbo_DimProductSubcategory.Rows[grddbo_DimProductSubcategory.EditIndex].FindControl("lblProductSubcategoryKey");
                clsdbo_DimProductSubcategory.ProductSubcategoryKey = System.Convert.ToInt32(lblProductSubcategoryKey.Text);
                clsdbo_DimProductSubcategory = dbo_DimProductSubcategoryDataClass.Select_Record(clsdbo_DimProductSubcategory);

                Session["ProductCategoryKey_SelectedValue"] = clsdbo_DimProductSubcategory.ProductCategoryKey;

                LoadGriddbo_DimProductSubcategory();
            } catch {  
            }
        }

        private void InsertRecord()
        {
            try {
                TextBox txtNewProductSubcategoryAlternateKey = (TextBox)grddbo_DimProductSubcategory.FooterRow.FindControl("txtNewProductSubcategoryAlternateKey");
                TextBox txtNewEnglishProductSubcategoryName = (TextBox)grddbo_DimProductSubcategory.FooterRow.FindControl("txtNewEnglishProductSubcategoryName");
                TextBox txtNewSpanishProductSubcategoryName = (TextBox)grddbo_DimProductSubcategory.FooterRow.FindControl("txtNewSpanishProductSubcategoryName");
                TextBox txtNewFrenchProductSubcategoryName = (TextBox)grddbo_DimProductSubcategory.FooterRow.FindControl("txtNewFrenchProductSubcategoryName");
                DropDownList txtNewProductCategoryKey = (DropDownList)grddbo_DimProductSubcategory.FooterRow.FindControl("txtNewProductCategoryKey");

                dbo_DimProductSubcategoryClass clsdbo_DimProductSubcategory = new dbo_DimProductSubcategoryClass();
                if (VerifyDataNew() == true) {
                    if (string.IsNullOrEmpty(txtNewProductSubcategoryAlternateKey.Text)) {
                        clsdbo_DimProductSubcategory.ProductSubcategoryAlternateKey = null;
                    } else {
                        clsdbo_DimProductSubcategory.ProductSubcategoryAlternateKey = System.Convert.ToInt32(txtNewProductSubcategoryAlternateKey.Text); }
                    clsdbo_DimProductSubcategory.EnglishProductSubcategoryName = System.Convert.ToString(txtNewEnglishProductSubcategoryName.Text);
                    clsdbo_DimProductSubcategory.SpanishProductSubcategoryName = System.Convert.ToString(txtNewSpanishProductSubcategoryName.Text);
                    clsdbo_DimProductSubcategory.FrenchProductSubcategoryName = System.Convert.ToString(txtNewFrenchProductSubcategoryName.Text);
                    if (string.IsNullOrEmpty(txtNewProductCategoryKey.SelectedValue)) {
                        clsdbo_DimProductSubcategory.ProductCategoryKey = null;
                    } else {
                        clsdbo_DimProductSubcategory.ProductCategoryKey = System.Convert.ToInt32(txtNewProductCategoryKey.SelectedValue); }
                    bool bSucess = false;
                    bSucess = dbo_DimProductSubcategoryDataClass.Add(clsdbo_DimProductSubcategory);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimProductSubcategory");
                        LoadGriddbo_DimProductSubcategory();
                    } else {
                        ec.ShowMessage(" Insert failed. ", " Dbo. Dim Product Subcategory ");
                    }
                }
            } catch {  
            }
        }

        private void UpdateRecord()
        {
            try {
                TextBox txtProductSubcategoryKey = (TextBox)grddbo_DimProductSubcategory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductSubcategoryKey");
                TextBox txtProductSubcategoryAlternateKey = (TextBox)grddbo_DimProductSubcategory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductSubcategoryAlternateKey");
                TextBox txtEnglishProductSubcategoryName = (TextBox)grddbo_DimProductSubcategory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEnglishProductSubcategoryName");
                TextBox txtSpanishProductSubcategoryName = (TextBox)grddbo_DimProductSubcategory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSpanishProductSubcategoryName");
                TextBox txtFrenchProductSubcategoryName = (TextBox)grddbo_DimProductSubcategory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFrenchProductSubcategoryName");
                DropDownList txtProductCategoryKey = (DropDownList)grddbo_DimProductSubcategory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductCategoryKey");

                dbo_DimProductSubcategoryClass oclsdbo_DimProductSubcategory = new dbo_DimProductSubcategoryClass();
                dbo_DimProductSubcategoryClass clsdbo_DimProductSubcategory = new dbo_DimProductSubcategoryClass();
                oclsdbo_DimProductSubcategory.ProductSubcategoryKey = System.Convert.ToInt32(txtProductSubcategoryKey.Text);
                oclsdbo_DimProductSubcategory = dbo_DimProductSubcategoryDataClass.Select_Record(oclsdbo_DimProductSubcategory);

                if (VerifyData() == true) {
                    if (string.IsNullOrEmpty(txtProductSubcategoryAlternateKey.Text)) {
                        clsdbo_DimProductSubcategory.ProductSubcategoryAlternateKey = null;
                    } else {
                        clsdbo_DimProductSubcategory.ProductSubcategoryAlternateKey = System.Convert.ToInt32(txtProductSubcategoryAlternateKey.Text); }
                    clsdbo_DimProductSubcategory.EnglishProductSubcategoryName = System.Convert.ToString(txtEnglishProductSubcategoryName.Text);
                    clsdbo_DimProductSubcategory.SpanishProductSubcategoryName = System.Convert.ToString(txtSpanishProductSubcategoryName.Text);
                    clsdbo_DimProductSubcategory.FrenchProductSubcategoryName = System.Convert.ToString(txtFrenchProductSubcategoryName.Text);
                    if (string.IsNullOrEmpty(txtProductCategoryKey.SelectedValue)) {
                        clsdbo_DimProductSubcategory.ProductCategoryKey = null;
                    } else {
                        clsdbo_DimProductSubcategory.ProductCategoryKey = System.Convert.ToInt32(txtProductCategoryKey.SelectedValue); }
                    bool bSucess = false;
                    bSucess = dbo_DimProductSubcategoryDataClass.Update(oclsdbo_DimProductSubcategory, clsdbo_DimProductSubcategory);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimProductSubcategory");
                        grddbo_DimProductSubcategory.EditIndex = -1;
                        LoadGriddbo_DimProductSubcategory();
                    } else {
                        ec.ShowMessage(" Update failed. ", " Dbo. Dim Product Subcategory ");
                    }
                }
            } catch {  
            }
        }

        private void DeleteRecord()
        {
            dbo_DimProductSubcategoryClass clsdbo_DimProductSubcategory = new dbo_DimProductSubcategoryClass();
            Label lblProductSubcategoryKey = (Label)grddbo_DimProductSubcategory.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblProductSubcategoryKey");
            clsdbo_DimProductSubcategory.ProductSubcategoryKey = System.Convert.ToInt32(lblProductSubcategoryKey.Text);
            clsdbo_DimProductSubcategory = dbo_DimProductSubcategoryDataClass.Select_Record(clsdbo_DimProductSubcategory);
            bool bSucess = false;
            bSucess = dbo_DimProductSubcategoryDataClass.Delete(clsdbo_DimProductSubcategory);
            if (bSucess == true) {
                Session.Remove("dvdbo_DimProductSubcategory");
                LoadGriddbo_DimProductSubcategory();
            } else {
                ec.ShowMessage(" Delete failed. ", " Dbo. Dim Product Subcategory ");
            }
        }

        private Boolean VerifyData()
        {
            TextBox txtProductSubcategoryKey = (TextBox)grddbo_DimProductSubcategory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductSubcategoryKey");
            TextBox txtProductSubcategoryAlternateKey = (TextBox)grddbo_DimProductSubcategory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductSubcategoryAlternateKey");
            TextBox txtEnglishProductSubcategoryName = (TextBox)grddbo_DimProductSubcategory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEnglishProductSubcategoryName");
            TextBox txtSpanishProductSubcategoryName = (TextBox)grddbo_DimProductSubcategory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSpanishProductSubcategoryName");
            TextBox txtFrenchProductSubcategoryName = (TextBox)grddbo_DimProductSubcategory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFrenchProductSubcategoryName");
            DropDownList txtProductCategoryKey = (DropDownList)grddbo_DimProductSubcategory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductCategoryKey");

            if (txtEnglishProductSubcategoryName.Text == "") {
                ec.ShowMessage(" English Product Subcategory Name is Required. ", " Dbo. Dim Product Subcategory ");
                txtEnglishProductSubcategoryName.Focus();
                return false;}
            if (txtSpanishProductSubcategoryName.Text == "") {
                ec.ShowMessage(" Spanish Product Subcategory Name is Required. ", " Dbo. Dim Product Subcategory ");
                txtSpanishProductSubcategoryName.Focus();
                return false;}
            if (txtFrenchProductSubcategoryName.Text == "") {
                ec.ShowMessage(" French Product Subcategory Name is Required. ", " Dbo. Dim Product Subcategory ");
                txtFrenchProductSubcategoryName.Focus();
                return false;}
            return true;
        }

        private Boolean VerifyDataNew()
        {
            TextBox txtNewProductSubcategoryAlternateKey = (TextBox)grddbo_DimProductSubcategory.FooterRow.FindControl("txtNewProductSubcategoryAlternateKey");
            TextBox txtNewEnglishProductSubcategoryName = (TextBox)grddbo_DimProductSubcategory.FooterRow.FindControl("txtNewEnglishProductSubcategoryName");
            TextBox txtNewSpanishProductSubcategoryName = (TextBox)grddbo_DimProductSubcategory.FooterRow.FindControl("txtNewSpanishProductSubcategoryName");
            TextBox txtNewFrenchProductSubcategoryName = (TextBox)grddbo_DimProductSubcategory.FooterRow.FindControl("txtNewFrenchProductSubcategoryName");
            DropDownList txtNewProductCategoryKey = (DropDownList)grddbo_DimProductSubcategory.FooterRow.FindControl("txtNewProductCategoryKey");

            if (txtNewEnglishProductSubcategoryName.Text == "") {
                ec.ShowMessage(" English Product Subcategory Name is Required. ", " Dbo. Dim Product Subcategory ");
                txtNewEnglishProductSubcategoryName.Focus();
                return false;}
            if (txtNewSpanishProductSubcategoryName.Text == "") {
                ec.ShowMessage(" Spanish Product Subcategory Name is Required. ", " Dbo. Dim Product Subcategory ");
                txtNewSpanishProductSubcategoryName.Focus();
                return false;}
            if (txtNewFrenchProductSubcategoryName.Text == "") {
                ec.ShowMessage(" French Product Subcategory Name is Required. ", " Dbo. Dim Product Subcategory ");
                txtNewFrenchProductSubcategoryName.Focus();
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
		    grddbo_DimProductSubcategory.PageIndex = 0;
		    grddbo_DimProductSubcategory.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimProductSubcategory();
        }

        public void butShowAll_Click(object sender, System.EventArgs e)
        {
		    txtSearch.Text = null;
		    Session.Remove("dvdbo_DimProductSubcategory");
		    LoadGriddbo_DimProductSubcategory();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
		    	Session.Remove("dvdbo_DimProductSubcategory");
			if ((Session["dvdbo_DimProductSubcategory"] != null)) {
				dvdbo_DimProductSubcategory = (DataView)Session["dvdbo_DimProductSubcategory"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimProductSubcategory = dbo_DimProductSubcategoryDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimProductSubcategory"] = dvdbo_DimProductSubcategory;
		    	}
                if (dvdbo_DimProductSubcategory.Count > 0) {
                    grddbo_DimProductSubcategory.DataSource = dvdbo_DimProductSubcategory;
                    grddbo_DimProductSubcategory.DataBind();
                }
                if (dvdbo_DimProductSubcategory.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("ProductSubcategoryKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("ProductSubcategoryAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("EnglishProductSubcategoryName", Type.GetType("System.String"));
                    dt.Columns.Add("SpanishProductSubcategoryName", Type.GetType("System.String"));
                    dt.Columns.Add("FrenchProductSubcategoryName", Type.GetType("System.String"));
                    dt.Columns.Add("EnglishProductCategoryName", Type.GetType("System.Int32"));
                    dvdbo_DimProductSubcategory = dt.DefaultView;
                    Session["dvdbo_DimProductSubcategory"] = dvdbo_DimProductSubcategory;

                    grddbo_DimProductSubcategory.DataSource = dvdbo_DimProductSubcategory;
                    grddbo_DimProductSubcategory.DataBind();

                    int TotalColumns = grddbo_DimProductSubcategory.Rows[0].Cells.Count;
                    grddbo_DimProductSubcategory.Rows[0].Cells.Clear();
                    grddbo_DimProductSubcategory.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimProductSubcategory.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimProductSubcategory.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimProductSubcategory.Sort = htmlHiddenSortExpression.Value;
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Product Subcategory ");
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
                    { dt = dbo_DimProductSubcategoryDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimProductSubcategoryDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Product Subcategory", "Many");
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
                    GVExport.DataSource = Session["dvdbo_DimProductSubcategory"];
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
 

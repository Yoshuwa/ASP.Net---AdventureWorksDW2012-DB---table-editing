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
    public partial class frmdbo_FactAdditionalInternationalProductDescription : System.Web.UI.Page
    {

        private dbo_FactAdditionalInternationalProductDescriptionDataClass clsdbo_FactAdditionalInternationalProductDescriptionData = new dbo_FactAdditionalInternationalProductDescriptionDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_FactAdditionalInternationalProductDescription;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {

                Session.Remove("dvdbo_FactAdditionalInternationalProductDescription");
                Session.Remove("Row");

                cmbFields.Items.Add("Product Key");
                cmbFields.Items.Add("Culture Name");
                cmbFields.Items.Add("Product Description");

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

                LoadGriddbo_FactAdditionalInternationalProductDescription();
            }
        }

        private void LoadGriddbo_FactAdditionalInternationalProductDescription()
        {
            try {
                if ((Session["dvdbo_FactAdditionalInternationalProductDescription"] != null)) {
                    dvdbo_FactAdditionalInternationalProductDescription = (DataView)Session["dvdbo_FactAdditionalInternationalProductDescription"];
                    // DataView was not found in the session.
                } else {
                    dvdbo_FactAdditionalInternationalProductDescription = dbo_FactAdditionalInternationalProductDescriptionDataClass.SelectAll().DefaultView;
                    Session["dvdbo_FactAdditionalInternationalProductDescription"] = dvdbo_FactAdditionalInternationalProductDescription;
                }
                if (dvdbo_FactAdditionalInternationalProductDescription.Count > 0) {
                    grddbo_FactAdditionalInternationalProductDescription.DataSource = dvdbo_FactAdditionalInternationalProductDescription;
                    grddbo_FactAdditionalInternationalProductDescription.DataBind();
                }
                if (dvdbo_FactAdditionalInternationalProductDescription.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("ProductKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("CultureName", Type.GetType("System.String"));
                    dt.Columns.Add("ProductDescription", Type.GetType("System.String"));
                    dvdbo_FactAdditionalInternationalProductDescription = dt.DefaultView;
                    Session["dvdbo_FactAdditionalInternationalProductDescription"] = dvdbo_FactAdditionalInternationalProductDescription;

                    grddbo_FactAdditionalInternationalProductDescription.DataSource = dvdbo_FactAdditionalInternationalProductDescription;
                    grddbo_FactAdditionalInternationalProductDescription.DataBind();

                    int TotalColumns = grddbo_FactAdditionalInternationalProductDescription.Rows[0].Cells.Count;
                    grddbo_FactAdditionalInternationalProductDescription.Rows[0].Cells.Clear();
                    grddbo_FactAdditionalInternationalProductDescription.Rows[0].Cells.Add(new TableCell());
                    grddbo_FactAdditionalInternationalProductDescription.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_FactAdditionalInternationalProductDescription.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_FactAdditionalInternationalProductDescription.Sort = htmlHiddenSortExpression.Value;
            }
            catch (Exception ex)
            {
                ec.ShowMessage(ex.Message, " Dbo. Fact Additional International Product Description ");
            }
        }

        protected void grddbo_FactAdditionalInternationalProductDescription_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                TextBox txtProductKey = (TextBox)e.Row.FindControl("txtProductKey");
                if (txtProductKey != null) {
                    txtProductKey.Enabled = false;
                }
                TextBox txtCultureName = (TextBox)e.Row.FindControl("txtCultureName");
                if (txtCultureName != null) {
                    txtCultureName.Enabled = false;
                }
            }
        }

        protected void grddbo_FactAdditionalInternationalProductDescription_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grddbo_FactAdditionalInternationalProductDescription.EditIndex = -1;
            LoadGriddbo_FactAdditionalInternationalProductDescription();
        }

        protected void grddbo_FactAdditionalInternationalProductDescription_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grddbo_FactAdditionalInternationalProductDescription.EditIndex = e.NewEditIndex;
            Edit();
        }

        protected void grddbo_FactAdditionalInternationalProductDescription_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            UpdateRecord();
        }

        protected void grddbo_FactAdditionalInternationalProductDescription_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            DeleteRecord();
        }

        protected void grddbo_FactAdditionalInternationalProductDescription_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert")) {
                InsertRecord();
            }
        }

        protected void grddbo_FactAdditionalInternationalProductDescription_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            GridViewRow gvr = (GridViewRow)gv.BottomPagerRow;
            if (gvr != null) {
                gvr.Visible = true;
            }
        }

        protected void grddbo_FactAdditionalInternationalProductDescription_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddbo_FactAdditionalInternationalProductDescription.PageIndex = e.NewPageIndex;
            LoadGriddbo_FactAdditionalInternationalProductDescription();
        }

        protected void grddbo_FactAdditionalInternationalProductDescription_Sorting(object sender, GridViewSortEventArgs e)
        {
            htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            LoadGriddbo_FactAdditionalInternationalProductDescription();
        }

        private void Edit()
        {
            try {
                dbo_FactAdditionalInternationalProductDescriptionClass clsdbo_FactAdditionalInternationalProductDescription = new dbo_FactAdditionalInternationalProductDescriptionClass();
                Label lblProductKey = (Label)grddbo_FactAdditionalInternationalProductDescription.Rows[grddbo_FactAdditionalInternationalProductDescription.EditIndex].FindControl("lblProductKey");
                clsdbo_FactAdditionalInternationalProductDescription.ProductKey = System.Convert.ToInt32(lblProductKey.Text);
                Label lblCultureName = (Label)grddbo_FactAdditionalInternationalProductDescription.Rows[grddbo_FactAdditionalInternationalProductDescription.EditIndex].FindControl("lblCultureName");
                clsdbo_FactAdditionalInternationalProductDescription.CultureName = System.Convert.ToString(lblCultureName.Text);
                clsdbo_FactAdditionalInternationalProductDescription = dbo_FactAdditionalInternationalProductDescriptionDataClass.Select_Record(clsdbo_FactAdditionalInternationalProductDescription);


                LoadGriddbo_FactAdditionalInternationalProductDescription();
            } catch {  
            }
        }

        private void InsertRecord()
        {
            try {
                TextBox txtNewProductKey = (TextBox)grddbo_FactAdditionalInternationalProductDescription.FooterRow.FindControl("txtNewProductKey");
                TextBox txtNewCultureName = (TextBox)grddbo_FactAdditionalInternationalProductDescription.FooterRow.FindControl("txtNewCultureName");
                TextBox txtNewProductDescription = (TextBox)grddbo_FactAdditionalInternationalProductDescription.FooterRow.FindControl("txtNewProductDescription");

                dbo_FactAdditionalInternationalProductDescriptionClass clsdbo_FactAdditionalInternationalProductDescription = new dbo_FactAdditionalInternationalProductDescriptionClass();
                if (VerifyDataNew() == true) {
                    clsdbo_FactAdditionalInternationalProductDescription.ProductKey = System.Convert.ToInt32(txtNewProductKey.Text);
                    clsdbo_FactAdditionalInternationalProductDescription.CultureName = System.Convert.ToString(txtNewCultureName.Text);
                    clsdbo_FactAdditionalInternationalProductDescription.ProductDescription = System.Convert.ToString(txtNewProductDescription.Text);
                    bool bSucess = false;
                    bSucess = dbo_FactAdditionalInternationalProductDescriptionDataClass.Add(clsdbo_FactAdditionalInternationalProductDescription);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_FactAdditionalInternationalProductDescription");
                        LoadGriddbo_FactAdditionalInternationalProductDescription();
                    } else {
                        ec.ShowMessage(" Insert failed. ", " Dbo. Fact Additional International Product Description ");
                    }
                }
            } catch {  
            }
        }

        private void UpdateRecord()
        {
            try {
                TextBox txtProductKey = (TextBox)grddbo_FactAdditionalInternationalProductDescription.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductKey");
                TextBox txtCultureName = (TextBox)grddbo_FactAdditionalInternationalProductDescription.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCultureName");
                TextBox txtProductDescription = (TextBox)grddbo_FactAdditionalInternationalProductDescription.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductDescription");

                dbo_FactAdditionalInternationalProductDescriptionClass oclsdbo_FactAdditionalInternationalProductDescription = new dbo_FactAdditionalInternationalProductDescriptionClass();
                dbo_FactAdditionalInternationalProductDescriptionClass clsdbo_FactAdditionalInternationalProductDescription = new dbo_FactAdditionalInternationalProductDescriptionClass();
                oclsdbo_FactAdditionalInternationalProductDescription.ProductKey = System.Convert.ToInt32(txtProductKey.Text);
                oclsdbo_FactAdditionalInternationalProductDescription.CultureName = System.Convert.ToString(txtCultureName.Text);
                oclsdbo_FactAdditionalInternationalProductDescription = dbo_FactAdditionalInternationalProductDescriptionDataClass.Select_Record(oclsdbo_FactAdditionalInternationalProductDescription);

                if (VerifyData() == true) {
                    clsdbo_FactAdditionalInternationalProductDescription.ProductKey = System.Convert.ToInt32(txtProductKey.Text);
                    clsdbo_FactAdditionalInternationalProductDescription.CultureName = System.Convert.ToString(txtCultureName.Text);
                    clsdbo_FactAdditionalInternationalProductDescription.ProductDescription = System.Convert.ToString(txtProductDescription.Text);
                    bool bSucess = false;
                    bSucess = dbo_FactAdditionalInternationalProductDescriptionDataClass.Update(oclsdbo_FactAdditionalInternationalProductDescription, clsdbo_FactAdditionalInternationalProductDescription);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_FactAdditionalInternationalProductDescription");
                        grddbo_FactAdditionalInternationalProductDescription.EditIndex = -1;
                        LoadGriddbo_FactAdditionalInternationalProductDescription();
                    } else {
                        ec.ShowMessage(" Update failed. ", " Dbo. Fact Additional International Product Description ");
                    }
                }
            } catch {  
            }
        }

        private void DeleteRecord()
        {
            dbo_FactAdditionalInternationalProductDescriptionClass clsdbo_FactAdditionalInternationalProductDescription = new dbo_FactAdditionalInternationalProductDescriptionClass();
            Label lblProductKey = (Label)grddbo_FactAdditionalInternationalProductDescription.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblProductKey");
            clsdbo_FactAdditionalInternationalProductDescription.ProductKey = System.Convert.ToInt32(lblProductKey.Text);
            Label lblCultureName = (Label)grddbo_FactAdditionalInternationalProductDescription.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblCultureName");
            clsdbo_FactAdditionalInternationalProductDescription.CultureName = System.Convert.ToString(lblCultureName.Text);
            clsdbo_FactAdditionalInternationalProductDescription = dbo_FactAdditionalInternationalProductDescriptionDataClass.Select_Record(clsdbo_FactAdditionalInternationalProductDescription);
            bool bSucess = false;
            bSucess = dbo_FactAdditionalInternationalProductDescriptionDataClass.Delete(clsdbo_FactAdditionalInternationalProductDescription);
            if (bSucess == true) {
                Session.Remove("dvdbo_FactAdditionalInternationalProductDescription");
                LoadGriddbo_FactAdditionalInternationalProductDescription();
            } else {
                ec.ShowMessage(" Delete failed. ", " Dbo. Fact Additional International Product Description ");
            }
        }

        private Boolean VerifyData()
        {
            TextBox txtProductKey = (TextBox)grddbo_FactAdditionalInternationalProductDescription.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductKey");
            TextBox txtCultureName = (TextBox)grddbo_FactAdditionalInternationalProductDescription.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCultureName");
            TextBox txtProductDescription = (TextBox)grddbo_FactAdditionalInternationalProductDescription.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductDescription");

            if (txtProductKey.Text == "") {
                ec.ShowMessage(" Product Key is Required. ", " Dbo. Fact Additional International Product Description ");
                txtProductKey.Focus();
                return false;}
            if (txtCultureName.Text == "") {
                ec.ShowMessage(" Culture Name is Required. ", " Dbo. Fact Additional International Product Description ");
                txtCultureName.Focus();
                return false;}
            if (txtProductDescription.Text == "") {
                ec.ShowMessage(" Product Description is Required. ", " Dbo. Fact Additional International Product Description ");
                txtProductDescription.Focus();
                return false;}
            return true;
        }

        private Boolean VerifyDataNew()
        {
            TextBox txtNewProductKey = (TextBox)grddbo_FactAdditionalInternationalProductDescription.FooterRow.FindControl("txtNewProductKey");
            TextBox txtNewCultureName = (TextBox)grddbo_FactAdditionalInternationalProductDescription.FooterRow.FindControl("txtNewCultureName");
            TextBox txtNewProductDescription = (TextBox)grddbo_FactAdditionalInternationalProductDescription.FooterRow.FindControl("txtNewProductDescription");

            if (txtNewProductKey.Text == "") {
                ec.ShowMessage(" Product Key is Required. ", " Dbo. Fact Additional International Product Description ");
                txtNewProductKey.Focus();
                return false;}
            if (txtNewCultureName.Text == "") {
                ec.ShowMessage(" Culture Name is Required. ", " Dbo. Fact Additional International Product Description ");
                txtNewCultureName.Focus();
                return false;}
            if (txtNewProductDescription.Text == "") {
                ec.ShowMessage(" Product Description is Required. ", " Dbo. Fact Additional International Product Description ");
                txtNewProductDescription.Focus();
                return false;}
            if (
                txtNewProductKey.Text != "" 
                && txtNewCultureName.Text != "" 
            )  {
                dbo_FactAdditionalInternationalProductDescriptionClass clsdbo_FactAdditionalInternationalProductDescription = new dbo_FactAdditionalInternationalProductDescriptionClass();
                clsdbo_FactAdditionalInternationalProductDescription.ProductKey = System.Convert.ToInt32(txtNewProductKey.Text);
                clsdbo_FactAdditionalInternationalProductDescription.CultureName = System.Convert.ToString(txtNewCultureName.Text);
                clsdbo_FactAdditionalInternationalProductDescription = dbo_FactAdditionalInternationalProductDescriptionDataClass.Select_Record(clsdbo_FactAdditionalInternationalProductDescription);
                if (clsdbo_FactAdditionalInternationalProductDescription != null) {
                    ec.ShowMessage(" Record already exists. ", " Dbo. Fact Additional International Product Description ");
                    txtNewProductKey.Focus();
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
		    grddbo_FactAdditionalInternationalProductDescription.PageIndex = 0;
		    grddbo_FactAdditionalInternationalProductDescription.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_FactAdditionalInternationalProductDescription();
        }

        public void butShowAll_Click(object sender, System.EventArgs e)
        {
		    txtSearch.Text = null;
		    Session.Remove("dvdbo_FactAdditionalInternationalProductDescription");
		    LoadGriddbo_FactAdditionalInternationalProductDescription();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
		    	Session.Remove("dvdbo_FactAdditionalInternationalProductDescription");
			if ((Session["dvdbo_FactAdditionalInternationalProductDescription"] != null)) {
				dvdbo_FactAdditionalInternationalProductDescription = (DataView)Session["dvdbo_FactAdditionalInternationalProductDescription"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_FactAdditionalInternationalProductDescription = dbo_FactAdditionalInternationalProductDescriptionDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_FactAdditionalInternationalProductDescription"] = dvdbo_FactAdditionalInternationalProductDescription;
		    	}
                if (dvdbo_FactAdditionalInternationalProductDescription.Count > 0) {
                    grddbo_FactAdditionalInternationalProductDescription.DataSource = dvdbo_FactAdditionalInternationalProductDescription;
                    grddbo_FactAdditionalInternationalProductDescription.DataBind();
                }
                if (dvdbo_FactAdditionalInternationalProductDescription.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("ProductKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("CultureName", Type.GetType("System.String"));
                    dt.Columns.Add("ProductDescription", Type.GetType("System.String"));
                    dvdbo_FactAdditionalInternationalProductDescription = dt.DefaultView;
                    Session["dvdbo_FactAdditionalInternationalProductDescription"] = dvdbo_FactAdditionalInternationalProductDescription;

                    grddbo_FactAdditionalInternationalProductDescription.DataSource = dvdbo_FactAdditionalInternationalProductDescription;
                    grddbo_FactAdditionalInternationalProductDescription.DataBind();

                    int TotalColumns = grddbo_FactAdditionalInternationalProductDescription.Rows[0].Cells.Count;
                    grddbo_FactAdditionalInternationalProductDescription.Rows[0].Cells.Clear();
                    grddbo_FactAdditionalInternationalProductDescription.Rows[0].Cells.Add(new TableCell());
                    grddbo_FactAdditionalInternationalProductDescription.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_FactAdditionalInternationalProductDescription.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_FactAdditionalInternationalProductDescription.Sort = htmlHiddenSortExpression.Value;
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Additional International Product Description ");
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
                    { dt = dbo_FactAdditionalInternationalProductDescriptionDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_FactAdditionalInternationalProductDescriptionDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Fact Additional International Product Description", "Many");
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
                    GVExport.DataSource = Session["dvdbo_FactAdditionalInternationalProductDescription"];
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
 

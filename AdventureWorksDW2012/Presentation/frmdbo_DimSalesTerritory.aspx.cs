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
    public partial class frmdbo_DimSalesTerritory : System.Web.UI.Page
    {

        private dbo_DimSalesTerritoryDataClass clsdbo_DimSalesTerritoryData = new dbo_DimSalesTerritoryDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimSalesTerritory;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {

                Session.Remove("dvdbo_DimSalesTerritory");
                Session.Remove("Row");

                cmbFields.Items.Add("Sales Territory Key");
                cmbFields.Items.Add("Sales Territory Alternate Key");
                cmbFields.Items.Add("Sales Territory Region");
                cmbFields.Items.Add("Sales Territory Country");
                cmbFields.Items.Add("Sales Territory Group");

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

                LoadGriddbo_DimSalesTerritory();
            }
        }

        private void LoadGriddbo_DimSalesTerritory()
        {
            try {
                if ((Session["dvdbo_DimSalesTerritory"] != null)) {
                    dvdbo_DimSalesTerritory = (DataView)Session["dvdbo_DimSalesTerritory"];
                    // DataView was not found in the session.
                } else {
                    dvdbo_DimSalesTerritory = dbo_DimSalesTerritoryDataClass.SelectAll().DefaultView;
                    Session["dvdbo_DimSalesTerritory"] = dvdbo_DimSalesTerritory;
                }
                if (dvdbo_DimSalesTerritory.Count > 0) {
                    grddbo_DimSalesTerritory.DataSource = dvdbo_DimSalesTerritory;
                    grddbo_DimSalesTerritory.DataBind();
                }
                if (dvdbo_DimSalesTerritory.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("SalesTerritoryKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("SalesTerritoryAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("SalesTerritoryRegion", Type.GetType("System.String"));
                    dt.Columns.Add("SalesTerritoryCountry", Type.GetType("System.String"));
                    dt.Columns.Add("SalesTerritoryGroup", Type.GetType("System.String"));
                    dvdbo_DimSalesTerritory = dt.DefaultView;
                    Session["dvdbo_DimSalesTerritory"] = dvdbo_DimSalesTerritory;

                    grddbo_DimSalesTerritory.DataSource = dvdbo_DimSalesTerritory;
                    grddbo_DimSalesTerritory.DataBind();

                    int TotalColumns = grddbo_DimSalesTerritory.Rows[0].Cells.Count;
                    grddbo_DimSalesTerritory.Rows[0].Cells.Clear();
                    grddbo_DimSalesTerritory.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimSalesTerritory.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimSalesTerritory.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimSalesTerritory.Sort = htmlHiddenSortExpression.Value;
            }
            catch (Exception ex)
            {
                ec.ShowMessage(ex.Message, " Dbo. Dim Sales Territory ");
            }
        }

        protected void grddbo_DimSalesTerritory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                TextBox txtSalesTerritoryKey = (TextBox)e.Row.FindControl("txtSalesTerritoryKey");
                if (txtSalesTerritoryKey != null) {
                    txtSalesTerritoryKey.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                TextBox txtNewSalesTerritoryKey = (TextBox)e.Row.FindControl("txtNewSalesTerritoryKey");
                if (txtNewSalesTerritoryKey != null) {
                    txtNewSalesTerritoryKey.Enabled = false;
                }
                txtNewSalesTerritoryKey.Text = System.Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "DimSalesTerritory"));
            }
        }

        protected void grddbo_DimSalesTerritory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grddbo_DimSalesTerritory.EditIndex = -1;
            LoadGriddbo_DimSalesTerritory();
        }

        protected void grddbo_DimSalesTerritory_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grddbo_DimSalesTerritory.EditIndex = e.NewEditIndex;
            Edit();
        }

        protected void grddbo_DimSalesTerritory_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            UpdateRecord();
        }

        protected void grddbo_DimSalesTerritory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            DeleteRecord();
        }

        protected void grddbo_DimSalesTerritory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert")) {
                InsertRecord();
            }
        }

        protected void grddbo_DimSalesTerritory_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            GridViewRow gvr = (GridViewRow)gv.BottomPagerRow;
            if (gvr != null) {
                gvr.Visible = true;
            }
        }

        protected void grddbo_DimSalesTerritory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddbo_DimSalesTerritory.PageIndex = e.NewPageIndex;
            LoadGriddbo_DimSalesTerritory();
        }

        protected void grddbo_DimSalesTerritory_Sorting(object sender, GridViewSortEventArgs e)
        {
            htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            LoadGriddbo_DimSalesTerritory();
        }

        private void Edit()
        {
            try {
                dbo_DimSalesTerritoryClass clsdbo_DimSalesTerritory = new dbo_DimSalesTerritoryClass();
                Label lblSalesTerritoryKey = (Label)grddbo_DimSalesTerritory.Rows[grddbo_DimSalesTerritory.EditIndex].FindControl("lblSalesTerritoryKey");
                clsdbo_DimSalesTerritory.SalesTerritoryKey = System.Convert.ToInt32(lblSalesTerritoryKey.Text);
                clsdbo_DimSalesTerritory = dbo_DimSalesTerritoryDataClass.Select_Record(clsdbo_DimSalesTerritory);


                LoadGriddbo_DimSalesTerritory();
            } catch {  
            }
        }

        private void InsertRecord()
        {
            try {
                TextBox txtNewSalesTerritoryAlternateKey = (TextBox)grddbo_DimSalesTerritory.FooterRow.FindControl("txtNewSalesTerritoryAlternateKey");
                TextBox txtNewSalesTerritoryRegion = (TextBox)grddbo_DimSalesTerritory.FooterRow.FindControl("txtNewSalesTerritoryRegion");
                TextBox txtNewSalesTerritoryCountry = (TextBox)grddbo_DimSalesTerritory.FooterRow.FindControl("txtNewSalesTerritoryCountry");
                TextBox txtNewSalesTerritoryGroup = (TextBox)grddbo_DimSalesTerritory.FooterRow.FindControl("txtNewSalesTerritoryGroup");

                dbo_DimSalesTerritoryClass clsdbo_DimSalesTerritory = new dbo_DimSalesTerritoryClass();
                if (VerifyDataNew() == true) {
                    if (string.IsNullOrEmpty(txtNewSalesTerritoryAlternateKey.Text)) {
                        clsdbo_DimSalesTerritory.SalesTerritoryAlternateKey = null;
                    } else {
                        clsdbo_DimSalesTerritory.SalesTerritoryAlternateKey = System.Convert.ToInt32(txtNewSalesTerritoryAlternateKey.Text); }
                    clsdbo_DimSalesTerritory.SalesTerritoryRegion = System.Convert.ToString(txtNewSalesTerritoryRegion.Text);
                    clsdbo_DimSalesTerritory.SalesTerritoryCountry = System.Convert.ToString(txtNewSalesTerritoryCountry.Text);
                    if (string.IsNullOrEmpty(txtNewSalesTerritoryGroup.Text)) {
                        clsdbo_DimSalesTerritory.SalesTerritoryGroup = null;
                    } else {
                        clsdbo_DimSalesTerritory.SalesTerritoryGroup = txtNewSalesTerritoryGroup.Text; }
                    bool bSucess = false;
                    bSucess = dbo_DimSalesTerritoryDataClass.Add(clsdbo_DimSalesTerritory);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimSalesTerritory");
                        LoadGriddbo_DimSalesTerritory();
                    } else {
                        ec.ShowMessage(" Insert failed. ", " Dbo. Dim Sales Territory ");
                    }
                }
            } catch {  
            }
        }

        private void UpdateRecord()
        {
            try {
                TextBox txtSalesTerritoryKey = (TextBox)grddbo_DimSalesTerritory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesTerritoryKey");
                TextBox txtSalesTerritoryAlternateKey = (TextBox)grddbo_DimSalesTerritory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesTerritoryAlternateKey");
                TextBox txtSalesTerritoryRegion = (TextBox)grddbo_DimSalesTerritory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesTerritoryRegion");
                TextBox txtSalesTerritoryCountry = (TextBox)grddbo_DimSalesTerritory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesTerritoryCountry");
                TextBox txtSalesTerritoryGroup = (TextBox)grddbo_DimSalesTerritory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesTerritoryGroup");

                dbo_DimSalesTerritoryClass oclsdbo_DimSalesTerritory = new dbo_DimSalesTerritoryClass();
                dbo_DimSalesTerritoryClass clsdbo_DimSalesTerritory = new dbo_DimSalesTerritoryClass();
                oclsdbo_DimSalesTerritory.SalesTerritoryKey = System.Convert.ToInt32(txtSalesTerritoryKey.Text);
                oclsdbo_DimSalesTerritory = dbo_DimSalesTerritoryDataClass.Select_Record(oclsdbo_DimSalesTerritory);

                if (VerifyData() == true) {
                    if (string.IsNullOrEmpty(txtSalesTerritoryAlternateKey.Text)) {
                        clsdbo_DimSalesTerritory.SalesTerritoryAlternateKey = null;
                    } else {
                        clsdbo_DimSalesTerritory.SalesTerritoryAlternateKey = System.Convert.ToInt32(txtSalesTerritoryAlternateKey.Text); }
                    clsdbo_DimSalesTerritory.SalesTerritoryRegion = System.Convert.ToString(txtSalesTerritoryRegion.Text);
                    clsdbo_DimSalesTerritory.SalesTerritoryCountry = System.Convert.ToString(txtSalesTerritoryCountry.Text);
                    if (string.IsNullOrEmpty(txtSalesTerritoryGroup.Text)) {
                        clsdbo_DimSalesTerritory.SalesTerritoryGroup = null;
                    } else {
                        clsdbo_DimSalesTerritory.SalesTerritoryGroup = txtSalesTerritoryGroup.Text; }
                    bool bSucess = false;
                    bSucess = dbo_DimSalesTerritoryDataClass.Update(oclsdbo_DimSalesTerritory, clsdbo_DimSalesTerritory);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimSalesTerritory");
                        grddbo_DimSalesTerritory.EditIndex = -1;
                        LoadGriddbo_DimSalesTerritory();
                    } else {
                        ec.ShowMessage(" Update failed. ", " Dbo. Dim Sales Territory ");
                    }
                }
            } catch {  
            }
        }

        private void DeleteRecord()
        {
            dbo_DimSalesTerritoryClass clsdbo_DimSalesTerritory = new dbo_DimSalesTerritoryClass();
            Label lblSalesTerritoryKey = (Label)grddbo_DimSalesTerritory.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblSalesTerritoryKey");
            clsdbo_DimSalesTerritory.SalesTerritoryKey = System.Convert.ToInt32(lblSalesTerritoryKey.Text);
            clsdbo_DimSalesTerritory = dbo_DimSalesTerritoryDataClass.Select_Record(clsdbo_DimSalesTerritory);
            bool bSucess = false;
            bSucess = dbo_DimSalesTerritoryDataClass.Delete(clsdbo_DimSalesTerritory);
            if (bSucess == true) {
                Session.Remove("dvdbo_DimSalesTerritory");
                LoadGriddbo_DimSalesTerritory();
            } else {
                ec.ShowMessage(" Delete failed. ", " Dbo. Dim Sales Territory ");
            }
        }

        private Boolean VerifyData()
        {
            TextBox txtSalesTerritoryKey = (TextBox)grddbo_DimSalesTerritory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesTerritoryKey");
            TextBox txtSalesTerritoryAlternateKey = (TextBox)grddbo_DimSalesTerritory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesTerritoryAlternateKey");
            TextBox txtSalesTerritoryRegion = (TextBox)grddbo_DimSalesTerritory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesTerritoryRegion");
            TextBox txtSalesTerritoryCountry = (TextBox)grddbo_DimSalesTerritory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesTerritoryCountry");
            TextBox txtSalesTerritoryGroup = (TextBox)grddbo_DimSalesTerritory.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesTerritoryGroup");

            if (txtSalesTerritoryRegion.Text == "") {
                ec.ShowMessage(" Sales Territory Region is Required. ", " Dbo. Dim Sales Territory ");
                txtSalesTerritoryRegion.Focus();
                return false;}
            if (txtSalesTerritoryCountry.Text == "") {
                ec.ShowMessage(" Sales Territory Country is Required. ", " Dbo. Dim Sales Territory ");
                txtSalesTerritoryCountry.Focus();
                return false;}
            return true;
        }

        private Boolean VerifyDataNew()
        {
            TextBox txtNewSalesTerritoryAlternateKey = (TextBox)grddbo_DimSalesTerritory.FooterRow.FindControl("txtNewSalesTerritoryAlternateKey");
            TextBox txtNewSalesTerritoryRegion = (TextBox)grddbo_DimSalesTerritory.FooterRow.FindControl("txtNewSalesTerritoryRegion");
            TextBox txtNewSalesTerritoryCountry = (TextBox)grddbo_DimSalesTerritory.FooterRow.FindControl("txtNewSalesTerritoryCountry");
            TextBox txtNewSalesTerritoryGroup = (TextBox)grddbo_DimSalesTerritory.FooterRow.FindControl("txtNewSalesTerritoryGroup");

            if (txtNewSalesTerritoryRegion.Text == "") {
                ec.ShowMessage(" Sales Territory Region is Required. ", " Dbo. Dim Sales Territory ");
                txtNewSalesTerritoryRegion.Focus();
                return false;}
            if (txtNewSalesTerritoryCountry.Text == "") {
                ec.ShowMessage(" Sales Territory Country is Required. ", " Dbo. Dim Sales Territory ");
                txtNewSalesTerritoryCountry.Focus();
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
		    grddbo_DimSalesTerritory.PageIndex = 0;
		    grddbo_DimSalesTerritory.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimSalesTerritory();
        }

        public void butShowAll_Click(object sender, System.EventArgs e)
        {
		    txtSearch.Text = null;
		    Session.Remove("dvdbo_DimSalesTerritory");
		    LoadGriddbo_DimSalesTerritory();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
		    	Session.Remove("dvdbo_DimSalesTerritory");
			if ((Session["dvdbo_DimSalesTerritory"] != null)) {
				dvdbo_DimSalesTerritory = (DataView)Session["dvdbo_DimSalesTerritory"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimSalesTerritory = dbo_DimSalesTerritoryDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimSalesTerritory"] = dvdbo_DimSalesTerritory;
		    	}
                if (dvdbo_DimSalesTerritory.Count > 0) {
                    grddbo_DimSalesTerritory.DataSource = dvdbo_DimSalesTerritory;
                    grddbo_DimSalesTerritory.DataBind();
                }
                if (dvdbo_DimSalesTerritory.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("SalesTerritoryKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("SalesTerritoryAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("SalesTerritoryRegion", Type.GetType("System.String"));
                    dt.Columns.Add("SalesTerritoryCountry", Type.GetType("System.String"));
                    dt.Columns.Add("SalesTerritoryGroup", Type.GetType("System.String"));
                    dvdbo_DimSalesTerritory = dt.DefaultView;
                    Session["dvdbo_DimSalesTerritory"] = dvdbo_DimSalesTerritory;

                    grddbo_DimSalesTerritory.DataSource = dvdbo_DimSalesTerritory;
                    grddbo_DimSalesTerritory.DataBind();

                    int TotalColumns = grddbo_DimSalesTerritory.Rows[0].Cells.Count;
                    grddbo_DimSalesTerritory.Rows[0].Cells.Clear();
                    grddbo_DimSalesTerritory.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimSalesTerritory.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimSalesTerritory.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimSalesTerritory.Sort = htmlHiddenSortExpression.Value;
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Sales Territory ");
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
                    { dt = dbo_DimSalesTerritoryDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimSalesTerritoryDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Sales Territory", "Many");
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
                    GVExport.DataSource = Session["dvdbo_DimSalesTerritory"];
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
 

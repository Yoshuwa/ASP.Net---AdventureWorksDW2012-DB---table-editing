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
    public partial class frmdbo_DimDepartmentGroup : System.Web.UI.Page
    {

        private dbo_DimDepartmentGroupDataClass clsdbo_DimDepartmentGroupData = new dbo_DimDepartmentGroupDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimDepartmentGroup;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                Session["ParentDepartmentGroupKey_SelectedValue"] = "";

                Session.Remove("dvdbo_DimDepartmentGroup");
                Session.Remove("Row");

                cmbFields.Items.Add("Department Group Key");
                cmbFields.Items.Add("Parent Department Group Key");
                cmbFields.Items.Add("Department Group Name");

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

                LoadGriddbo_DimDepartmentGroup();
            }
        }

        private void Loaddbo_DimDepartmentGroup_dbo_DimDepartmentGroupComboBox65(GridViewRowEventArgs e)
        {
            List<dbo_DimDepartmentGroup_dbo_DimDepartmentGroupClass65> dbo_DimDepartmentGroup_dbo_DimDepartmentGroupList = new  List<dbo_DimDepartmentGroup_dbo_DimDepartmentGroupClass65>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtParentDepartmentGroupKey = (DropDownList)e.Row.FindControl("txtParentDepartmentGroupKey");
                if (txtParentDepartmentGroupKey != null) {
                    try {
                        dbo_DimDepartmentGroup_dbo_DimDepartmentGroupList = dbo_DimDepartmentGroup_dbo_DimDepartmentGroupDataClass65.List();
                        txtParentDepartmentGroupKey.DataSource = dbo_DimDepartmentGroup_dbo_DimDepartmentGroupList;
                        txtParentDepartmentGroupKey.DataValueField = "DepartmentGroupKey";
                        txtParentDepartmentGroupKey.DataTextField = "DepartmentGroupName";
                        txtParentDepartmentGroupKey.DataBind();
                        txtParentDepartmentGroupKey.SelectedValue = Convert.ToString(Session["ParentDepartmentGroupKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Dim Department Group ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewParentDepartmentGroupKey = (DropDownList)e.Row.FindControl("txtNewParentDepartmentGroupKey");
                if (txtNewParentDepartmentGroupKey != null) {
                    try {
                        dbo_DimDepartmentGroup_dbo_DimDepartmentGroupList = dbo_DimDepartmentGroup_dbo_DimDepartmentGroupDataClass65.List();
                        txtNewParentDepartmentGroupKey.DataSource = dbo_DimDepartmentGroup_dbo_DimDepartmentGroupList;
                        txtNewParentDepartmentGroupKey.DataValueField = "DepartmentGroupKey";
                        txtNewParentDepartmentGroupKey.DataTextField = "DepartmentGroupName";
                        txtNewParentDepartmentGroupKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Dim Department Group ");
                    }
                }
            }
        }

        private void LoadGriddbo_DimDepartmentGroup()
        {
            try {
                if ((Session["dvdbo_DimDepartmentGroup"] != null)) {
                    dvdbo_DimDepartmentGroup = (DataView)Session["dvdbo_DimDepartmentGroup"];
                    // DataView was not found in the session.
                } else {
                    dvdbo_DimDepartmentGroup = dbo_DimDepartmentGroupDataClass.SelectAll().DefaultView;
                    Session["dvdbo_DimDepartmentGroup"] = dvdbo_DimDepartmentGroup;
                }
                if (dvdbo_DimDepartmentGroup.Count > 0) {
                    grddbo_DimDepartmentGroup.DataSource = dvdbo_DimDepartmentGroup;
                    grddbo_DimDepartmentGroup.DataBind();
                }
                if (dvdbo_DimDepartmentGroup.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("DepartmentGroupKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("DepartmentGroupName", Type.GetType("System.Int32"));
                    dt.Columns.Add("DepartmentGroupName", Type.GetType("System.String"));
                    dvdbo_DimDepartmentGroup = dt.DefaultView;
                    Session["dvdbo_DimDepartmentGroup"] = dvdbo_DimDepartmentGroup;

                    grddbo_DimDepartmentGroup.DataSource = dvdbo_DimDepartmentGroup;
                    grddbo_DimDepartmentGroup.DataBind();

                    int TotalColumns = grddbo_DimDepartmentGroup.Rows[0].Cells.Count;
                    grddbo_DimDepartmentGroup.Rows[0].Cells.Clear();
                    grddbo_DimDepartmentGroup.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimDepartmentGroup.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimDepartmentGroup.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimDepartmentGroup.Sort = htmlHiddenSortExpression.Value;
            }
            catch (Exception ex)
            {
                ec.ShowMessage(ex.Message, " Dbo. Dim Department Group ");
            }
        }

        protected void grddbo_DimDepartmentGroup_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Loaddbo_DimDepartmentGroup_dbo_DimDepartmentGroupComboBox65(e);
            if (e.Row.RowType == DataControlRowType.DataRow) {
                TextBox txtDepartmentGroupKey = (TextBox)e.Row.FindControl("txtDepartmentGroupKey");
                if (txtDepartmentGroupKey != null) {
                    txtDepartmentGroupKey.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                TextBox txtNewDepartmentGroupKey = (TextBox)e.Row.FindControl("txtNewDepartmentGroupKey");
                if (txtNewDepartmentGroupKey != null) {
                    txtNewDepartmentGroupKey.Enabled = false;
                }
                txtNewDepartmentGroupKey.Text = System.Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "DimDepartmentGroup"));
            }
        }

        protected void grddbo_DimDepartmentGroup_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grddbo_DimDepartmentGroup.EditIndex = -1;
            LoadGriddbo_DimDepartmentGroup();
        }

        protected void grddbo_DimDepartmentGroup_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grddbo_DimDepartmentGroup.EditIndex = e.NewEditIndex;
            Edit();
        }

        protected void grddbo_DimDepartmentGroup_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            UpdateRecord();
        }

        protected void grddbo_DimDepartmentGroup_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            DeleteRecord();
        }

        protected void grddbo_DimDepartmentGroup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert")) {
                InsertRecord();
            }
        }

        protected void grddbo_DimDepartmentGroup_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            GridViewRow gvr = (GridViewRow)gv.BottomPagerRow;
            if (gvr != null) {
                gvr.Visible = true;
            }
        }

        protected void grddbo_DimDepartmentGroup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddbo_DimDepartmentGroup.PageIndex = e.NewPageIndex;
            LoadGriddbo_DimDepartmentGroup();
        }

        protected void grddbo_DimDepartmentGroup_Sorting(object sender, GridViewSortEventArgs e)
        {
            htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            LoadGriddbo_DimDepartmentGroup();
        }

        private void Edit()
        {
            try {
                dbo_DimDepartmentGroupClass clsdbo_DimDepartmentGroup = new dbo_DimDepartmentGroupClass();
                Label lblDepartmentGroupKey = (Label)grddbo_DimDepartmentGroup.Rows[grddbo_DimDepartmentGroup.EditIndex].FindControl("lblDepartmentGroupKey");
                clsdbo_DimDepartmentGroup.DepartmentGroupKey = System.Convert.ToInt32(lblDepartmentGroupKey.Text);
                clsdbo_DimDepartmentGroup = dbo_DimDepartmentGroupDataClass.Select_Record(clsdbo_DimDepartmentGroup);

                Session["ParentDepartmentGroupKey_SelectedValue"] = clsdbo_DimDepartmentGroup.ParentDepartmentGroupKey;

                LoadGriddbo_DimDepartmentGroup();
            } catch {  
            }
        }

        private void InsertRecord()
        {
            try {
                DropDownList txtNewParentDepartmentGroupKey = (DropDownList)grddbo_DimDepartmentGroup.FooterRow.FindControl("txtNewParentDepartmentGroupKey");
                TextBox txtNewDepartmentGroupName = (TextBox)grddbo_DimDepartmentGroup.FooterRow.FindControl("txtNewDepartmentGroupName");

                dbo_DimDepartmentGroupClass clsdbo_DimDepartmentGroup = new dbo_DimDepartmentGroupClass();
                if (VerifyDataNew() == true) {
                    if (string.IsNullOrEmpty(txtNewParentDepartmentGroupKey.SelectedValue)) {
                        clsdbo_DimDepartmentGroup.ParentDepartmentGroupKey = null;
                    } else {
                        clsdbo_DimDepartmentGroup.ParentDepartmentGroupKey = System.Convert.ToInt32(txtNewParentDepartmentGroupKey.SelectedValue); }
                    if (string.IsNullOrEmpty(txtNewDepartmentGroupName.Text)) {
                        clsdbo_DimDepartmentGroup.DepartmentGroupName = null;
                    } else {
                        clsdbo_DimDepartmentGroup.DepartmentGroupName = txtNewDepartmentGroupName.Text; }
                    bool bSucess = false;
                    bSucess = dbo_DimDepartmentGroupDataClass.Add(clsdbo_DimDepartmentGroup);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimDepartmentGroup");
                        LoadGriddbo_DimDepartmentGroup();
                    } else {
                        ec.ShowMessage(" Insert failed. ", " Dbo. Dim Department Group ");
                    }
                }
            } catch {  
            }
        }

        private void UpdateRecord()
        {
            try {
                TextBox txtDepartmentGroupKey = (TextBox)grddbo_DimDepartmentGroup.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDepartmentGroupKey");
                DropDownList txtParentDepartmentGroupKey = (DropDownList)grddbo_DimDepartmentGroup.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtParentDepartmentGroupKey");
                TextBox txtDepartmentGroupName = (TextBox)grddbo_DimDepartmentGroup.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDepartmentGroupName");

                dbo_DimDepartmentGroupClass oclsdbo_DimDepartmentGroup = new dbo_DimDepartmentGroupClass();
                dbo_DimDepartmentGroupClass clsdbo_DimDepartmentGroup = new dbo_DimDepartmentGroupClass();
                oclsdbo_DimDepartmentGroup.DepartmentGroupKey = System.Convert.ToInt32(txtDepartmentGroupKey.Text);
                oclsdbo_DimDepartmentGroup = dbo_DimDepartmentGroupDataClass.Select_Record(oclsdbo_DimDepartmentGroup);

                if (VerifyData() == true) {
                    if (string.IsNullOrEmpty(txtParentDepartmentGroupKey.SelectedValue)) {
                        clsdbo_DimDepartmentGroup.ParentDepartmentGroupKey = null;
                    } else {
                        clsdbo_DimDepartmentGroup.ParentDepartmentGroupKey = System.Convert.ToInt32(txtParentDepartmentGroupKey.SelectedValue); }
                    if (string.IsNullOrEmpty(txtDepartmentGroupName.Text)) {
                        clsdbo_DimDepartmentGroup.DepartmentGroupName = null;
                    } else {
                        clsdbo_DimDepartmentGroup.DepartmentGroupName = txtDepartmentGroupName.Text; }
                    bool bSucess = false;
                    bSucess = dbo_DimDepartmentGroupDataClass.Update(oclsdbo_DimDepartmentGroup, clsdbo_DimDepartmentGroup);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimDepartmentGroup");
                        grddbo_DimDepartmentGroup.EditIndex = -1;
                        LoadGriddbo_DimDepartmentGroup();
                    } else {
                        ec.ShowMessage(" Update failed. ", " Dbo. Dim Department Group ");
                    }
                }
            } catch {  
            }
        }

        private void DeleteRecord()
        {
            dbo_DimDepartmentGroupClass clsdbo_DimDepartmentGroup = new dbo_DimDepartmentGroupClass();
            Label lblDepartmentGroupKey = (Label)grddbo_DimDepartmentGroup.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblDepartmentGroupKey");
            clsdbo_DimDepartmentGroup.DepartmentGroupKey = System.Convert.ToInt32(lblDepartmentGroupKey.Text);
            clsdbo_DimDepartmentGroup = dbo_DimDepartmentGroupDataClass.Select_Record(clsdbo_DimDepartmentGroup);
            bool bSucess = false;
            bSucess = dbo_DimDepartmentGroupDataClass.Delete(clsdbo_DimDepartmentGroup);
            if (bSucess == true) {
                Session.Remove("dvdbo_DimDepartmentGroup");
                LoadGriddbo_DimDepartmentGroup();
            } else {
                ec.ShowMessage(" Delete failed. ", " Dbo. Dim Department Group ");
            }
        }

        private Boolean VerifyData()
        {
            TextBox txtDepartmentGroupKey = (TextBox)grddbo_DimDepartmentGroup.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDepartmentGroupKey");
            DropDownList txtParentDepartmentGroupKey = (DropDownList)grddbo_DimDepartmentGroup.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtParentDepartmentGroupKey");
            TextBox txtDepartmentGroupName = (TextBox)grddbo_DimDepartmentGroup.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDepartmentGroupName");

            return true;
        }

        private Boolean VerifyDataNew()
        {
            DropDownList txtNewParentDepartmentGroupKey = (DropDownList)grddbo_DimDepartmentGroup.FooterRow.FindControl("txtNewParentDepartmentGroupKey");
            TextBox txtNewDepartmentGroupName = (TextBox)grddbo_DimDepartmentGroup.FooterRow.FindControl("txtNewDepartmentGroupName");

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
		    grddbo_DimDepartmentGroup.PageIndex = 0;
		    grddbo_DimDepartmentGroup.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimDepartmentGroup();
        }

        public void butShowAll_Click(object sender, System.EventArgs e)
        {
		    txtSearch.Text = null;
		    Session.Remove("dvdbo_DimDepartmentGroup");
		    LoadGriddbo_DimDepartmentGroup();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
		    	Session.Remove("dvdbo_DimDepartmentGroup");
			if ((Session["dvdbo_DimDepartmentGroup"] != null)) {
				dvdbo_DimDepartmentGroup = (DataView)Session["dvdbo_DimDepartmentGroup"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimDepartmentGroup = dbo_DimDepartmentGroupDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimDepartmentGroup"] = dvdbo_DimDepartmentGroup;
		    	}
                if (dvdbo_DimDepartmentGroup.Count > 0) {
                    grddbo_DimDepartmentGroup.DataSource = dvdbo_DimDepartmentGroup;
                    grddbo_DimDepartmentGroup.DataBind();
                }
                if (dvdbo_DimDepartmentGroup.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("DepartmentGroupKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("DepartmentGroupName", Type.GetType("System.Int32"));
                    dt.Columns.Add("DepartmentGroupName", Type.GetType("System.String"));
                    dvdbo_DimDepartmentGroup = dt.DefaultView;
                    Session["dvdbo_DimDepartmentGroup"] = dvdbo_DimDepartmentGroup;

                    grddbo_DimDepartmentGroup.DataSource = dvdbo_DimDepartmentGroup;
                    grddbo_DimDepartmentGroup.DataBind();

                    int TotalColumns = grddbo_DimDepartmentGroup.Rows[0].Cells.Count;
                    grddbo_DimDepartmentGroup.Rows[0].Cells.Clear();
                    grddbo_DimDepartmentGroup.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimDepartmentGroup.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimDepartmentGroup.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimDepartmentGroup.Sort = htmlHiddenSortExpression.Value;
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Department Group ");
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
                    { dt = dbo_DimDepartmentGroupDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimDepartmentGroupDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Department Group", "Many");
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
                    GVExport.DataSource = Session["dvdbo_DimDepartmentGroup"];
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
 

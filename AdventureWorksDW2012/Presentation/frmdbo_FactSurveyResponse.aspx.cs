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
    public partial class frmdbo_FactSurveyResponse : System.Web.UI.Page
    {

        private dbo_FactSurveyResponseDataClass clsdbo_FactSurveyResponseData = new dbo_FactSurveyResponseDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_FactSurveyResponse;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                Session["DateKey_SelectedValue"] = "";
                Session["CustomerKey_SelectedValue"] = "";

                Session.Remove("dvdbo_FactSurveyResponse");
                Session.Remove("Row");

                cmbFields.Items.Add("Survey Response Key");
                cmbFields.Items.Add("Date Key");
                cmbFields.Items.Add("Customer Key");
                cmbFields.Items.Add("Product Category Key");
                cmbFields.Items.Add("English Product Category Name");
                cmbFields.Items.Add("Product Subcategory Key");
                cmbFields.Items.Add("English Product Subcategory Name");
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

                LoadGriddbo_FactSurveyResponse();
            }
        }

        private void Loaddbo_FactSurveyResponse_dbo_DimDateComboBox307(GridViewRowEventArgs e)
        {
            List<dbo_FactSurveyResponse_dbo_DimDateClass307> dbo_FactSurveyResponse_dbo_DimDateList = new  List<dbo_FactSurveyResponse_dbo_DimDateClass307>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtDateKey = (DropDownList)e.Row.FindControl("txtDateKey");
                if (txtDateKey != null) {
                    try {
                        dbo_FactSurveyResponse_dbo_DimDateList = dbo_FactSurveyResponse_dbo_DimDateDataClass307.List();
                        txtDateKey.DataSource = dbo_FactSurveyResponse_dbo_DimDateList;
                        txtDateKey.DataValueField = "DateKey";
                        txtDateKey.DataTextField = "DateKey";
                        txtDateKey.DataBind();
                        txtDateKey.SelectedValue = Convert.ToString(Session["DateKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Survey Response ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewDateKey = (DropDownList)e.Row.FindControl("txtNewDateKey");
                if (txtNewDateKey != null) {
                    try {
                        dbo_FactSurveyResponse_dbo_DimDateList = dbo_FactSurveyResponse_dbo_DimDateDataClass307.List();
                        txtNewDateKey.DataSource = dbo_FactSurveyResponse_dbo_DimDateList;
                        txtNewDateKey.DataValueField = "DateKey";
                        txtNewDateKey.DataTextField = "DateKey";
                        txtNewDateKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Survey Response ");
                    }
                }
            }
        }

        private void Loaddbo_FactSurveyResponse_dbo_DimCustomerComboBox308(GridViewRowEventArgs e)
        {
            List<dbo_FactSurveyResponse_dbo_DimCustomerClass308> dbo_FactSurveyResponse_dbo_DimCustomerList = new  List<dbo_FactSurveyResponse_dbo_DimCustomerClass308>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtCustomerKey = (DropDownList)e.Row.FindControl("txtCustomerKey");
                if (txtCustomerKey != null) {
                    try {
                        dbo_FactSurveyResponse_dbo_DimCustomerList = dbo_FactSurveyResponse_dbo_DimCustomerDataClass308.List();
                        txtCustomerKey.DataSource = dbo_FactSurveyResponse_dbo_DimCustomerList;
                        txtCustomerKey.DataValueField = "CustomerKey";
                        txtCustomerKey.DataTextField = "CustomerKey";
                        txtCustomerKey.DataBind();
                        txtCustomerKey.SelectedValue = Convert.ToString(Session["CustomerKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Survey Response ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewCustomerKey = (DropDownList)e.Row.FindControl("txtNewCustomerKey");
                if (txtNewCustomerKey != null) {
                    try {
                        dbo_FactSurveyResponse_dbo_DimCustomerList = dbo_FactSurveyResponse_dbo_DimCustomerDataClass308.List();
                        txtNewCustomerKey.DataSource = dbo_FactSurveyResponse_dbo_DimCustomerList;
                        txtNewCustomerKey.DataValueField = "CustomerKey";
                        txtNewCustomerKey.DataTextField = "CustomerKey";
                        txtNewCustomerKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Fact Survey Response ");
                    }
                }
            }
        }

        private void LoadGriddbo_FactSurveyResponse()
        {
            try {
                if ((Session["dvdbo_FactSurveyResponse"] != null)) {
                    dvdbo_FactSurveyResponse = (DataView)Session["dvdbo_FactSurveyResponse"];
                    // DataView was not found in the session.
                } else {
                    dvdbo_FactSurveyResponse = dbo_FactSurveyResponseDataClass.SelectAll().DefaultView;
                    Session["dvdbo_FactSurveyResponse"] = dvdbo_FactSurveyResponse;
                }
                if (dvdbo_FactSurveyResponse.Count > 0) {
                    grddbo_FactSurveyResponse.DataSource = dvdbo_FactSurveyResponse;
                    grddbo_FactSurveyResponse.DataBind();
                }
                if (dvdbo_FactSurveyResponse.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("SurveyResponseKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("DateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("CustomerKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("ProductCategoryKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("EnglishProductCategoryName", Type.GetType("System.String"));
                    dt.Columns.Add("ProductSubcategoryKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("EnglishProductSubcategoryName", Type.GetType("System.String"));
                    dt.Columns.Add("Date", Type.GetType("System.DateTime"));
                    dvdbo_FactSurveyResponse = dt.DefaultView;
                    Session["dvdbo_FactSurveyResponse"] = dvdbo_FactSurveyResponse;

                    grddbo_FactSurveyResponse.DataSource = dvdbo_FactSurveyResponse;
                    grddbo_FactSurveyResponse.DataBind();

                    int TotalColumns = grddbo_FactSurveyResponse.Rows[0].Cells.Count;
                    grddbo_FactSurveyResponse.Rows[0].Cells.Clear();
                    grddbo_FactSurveyResponse.Rows[0].Cells.Add(new TableCell());
                    grddbo_FactSurveyResponse.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_FactSurveyResponse.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_FactSurveyResponse.Sort = htmlHiddenSortExpression.Value;
            }
            catch (Exception ex)
            {
                ec.ShowMessage(ex.Message, " Dbo. Fact Survey Response ");
            }
        }

        protected void grddbo_FactSurveyResponse_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Loaddbo_FactSurveyResponse_dbo_DimDateComboBox307(e);
            Loaddbo_FactSurveyResponse_dbo_DimCustomerComboBox308(e);
            if (e.Row.RowType == DataControlRowType.DataRow) {
                TextBox txtSurveyResponseKey = (TextBox)e.Row.FindControl("txtSurveyResponseKey");
                if (txtSurveyResponseKey != null) {
                    txtSurveyResponseKey.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                TextBox txtNewSurveyResponseKey = (TextBox)e.Row.FindControl("txtNewSurveyResponseKey");
                if (txtNewSurveyResponseKey != null) {
                    txtNewSurveyResponseKey.Enabled = false;
                }
                txtNewSurveyResponseKey.Text = System.Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "FactSurveyResponse"));
            }
        }

        protected void grddbo_FactSurveyResponse_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grddbo_FactSurveyResponse.EditIndex = -1;
            LoadGriddbo_FactSurveyResponse();
        }

        protected void grddbo_FactSurveyResponse_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grddbo_FactSurveyResponse.EditIndex = e.NewEditIndex;
            Edit();
        }

        protected void grddbo_FactSurveyResponse_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            UpdateRecord();
        }

        protected void grddbo_FactSurveyResponse_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            DeleteRecord();
        }

        protected void grddbo_FactSurveyResponse_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert")) {
                InsertRecord();
            }
        }

        protected void grddbo_FactSurveyResponse_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            GridViewRow gvr = (GridViewRow)gv.BottomPagerRow;
            if (gvr != null) {
                gvr.Visible = true;
            }
        }

        protected void grddbo_FactSurveyResponse_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddbo_FactSurveyResponse.PageIndex = e.NewPageIndex;
            LoadGriddbo_FactSurveyResponse();
        }

        protected void grddbo_FactSurveyResponse_Sorting(object sender, GridViewSortEventArgs e)
        {
            htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            LoadGriddbo_FactSurveyResponse();
        }

        private void Edit()
        {
            try {
                dbo_FactSurveyResponseClass clsdbo_FactSurveyResponse = new dbo_FactSurveyResponseClass();
                Label lblSurveyResponseKey = (Label)grddbo_FactSurveyResponse.Rows[grddbo_FactSurveyResponse.EditIndex].FindControl("lblSurveyResponseKey");
                clsdbo_FactSurveyResponse.SurveyResponseKey = System.Convert.ToInt32(lblSurveyResponseKey.Text);
                clsdbo_FactSurveyResponse = dbo_FactSurveyResponseDataClass.Select_Record(clsdbo_FactSurveyResponse);

                Session["DateKey_SelectedValue"] = clsdbo_FactSurveyResponse.DateKey;
                Session["CustomerKey_SelectedValue"] = clsdbo_FactSurveyResponse.CustomerKey;

                LoadGriddbo_FactSurveyResponse();
            } catch {  
            }
        }

        private void InsertRecord()
        {
            try {
                DropDownList txtNewDateKey = (DropDownList)grddbo_FactSurveyResponse.FooterRow.FindControl("txtNewDateKey");
                DropDownList txtNewCustomerKey = (DropDownList)grddbo_FactSurveyResponse.FooterRow.FindControl("txtNewCustomerKey");
                TextBox txtNewProductCategoryKey = (TextBox)grddbo_FactSurveyResponse.FooterRow.FindControl("txtNewProductCategoryKey");
                TextBox txtNewEnglishProductCategoryName = (TextBox)grddbo_FactSurveyResponse.FooterRow.FindControl("txtNewEnglishProductCategoryName");
                TextBox txtNewProductSubcategoryKey = (TextBox)grddbo_FactSurveyResponse.FooterRow.FindControl("txtNewProductSubcategoryKey");
                TextBox txtNewEnglishProductSubcategoryName = (TextBox)grddbo_FactSurveyResponse.FooterRow.FindControl("txtNewEnglishProductSubcategoryName");
                TextBox txtNewDate = (TextBox)grddbo_FactSurveyResponse.FooterRow.FindControl("txtNewDate");

                dbo_FactSurveyResponseClass clsdbo_FactSurveyResponse = new dbo_FactSurveyResponseClass();
                if (VerifyDataNew() == true) {
                    clsdbo_FactSurveyResponse.DateKey = System.Convert.ToInt32(txtNewDateKey.SelectedValue);
                    clsdbo_FactSurveyResponse.CustomerKey = System.Convert.ToInt32(txtNewCustomerKey.SelectedValue);
                    clsdbo_FactSurveyResponse.ProductCategoryKey = System.Convert.ToInt32(txtNewProductCategoryKey.Text);
                    clsdbo_FactSurveyResponse.EnglishProductCategoryName = System.Convert.ToString(txtNewEnglishProductCategoryName.Text);
                    clsdbo_FactSurveyResponse.ProductSubcategoryKey = System.Convert.ToInt32(txtNewProductSubcategoryKey.Text);
                    clsdbo_FactSurveyResponse.EnglishProductSubcategoryName = System.Convert.ToString(txtNewEnglishProductSubcategoryName.Text);
                    if (string.IsNullOrEmpty(txtNewDate.Text)) {
                        clsdbo_FactSurveyResponse.Date = null;
                    } else {
                        clsdbo_FactSurveyResponse.Date = System.Convert.ToDateTime(txtNewDate.Text); }
                    bool bSucess = false;
                    bSucess = dbo_FactSurveyResponseDataClass.Add(clsdbo_FactSurveyResponse);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_FactSurveyResponse");
                        LoadGriddbo_FactSurveyResponse();
                    } else {
                        ec.ShowMessage(" Insert failed. ", " Dbo. Fact Survey Response ");
                    }
                }
            } catch {  
            }
        }

        private void UpdateRecord()
        {
            try {
                TextBox txtSurveyResponseKey = (TextBox)grddbo_FactSurveyResponse.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSurveyResponseKey");
                DropDownList txtDateKey = (DropDownList)grddbo_FactSurveyResponse.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDateKey");
                DropDownList txtCustomerKey = (DropDownList)grddbo_FactSurveyResponse.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCustomerKey");
                TextBox txtProductCategoryKey = (TextBox)grddbo_FactSurveyResponse.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductCategoryKey");
                TextBox txtEnglishProductCategoryName = (TextBox)grddbo_FactSurveyResponse.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEnglishProductCategoryName");
                TextBox txtProductSubcategoryKey = (TextBox)grddbo_FactSurveyResponse.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductSubcategoryKey");
                TextBox txtEnglishProductSubcategoryName = (TextBox)grddbo_FactSurveyResponse.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEnglishProductSubcategoryName");
                TextBox txtDate = (TextBox)grddbo_FactSurveyResponse.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDate");

                dbo_FactSurveyResponseClass oclsdbo_FactSurveyResponse = new dbo_FactSurveyResponseClass();
                dbo_FactSurveyResponseClass clsdbo_FactSurveyResponse = new dbo_FactSurveyResponseClass();
                oclsdbo_FactSurveyResponse.SurveyResponseKey = System.Convert.ToInt32(txtSurveyResponseKey.Text);
                oclsdbo_FactSurveyResponse = dbo_FactSurveyResponseDataClass.Select_Record(oclsdbo_FactSurveyResponse);

                if (VerifyData() == true) {
                    clsdbo_FactSurveyResponse.DateKey = System.Convert.ToInt32(txtDateKey.SelectedValue);
                    clsdbo_FactSurveyResponse.CustomerKey = System.Convert.ToInt32(txtCustomerKey.SelectedValue);
                    clsdbo_FactSurveyResponse.ProductCategoryKey = System.Convert.ToInt32(txtProductCategoryKey.Text);
                    clsdbo_FactSurveyResponse.EnglishProductCategoryName = System.Convert.ToString(txtEnglishProductCategoryName.Text);
                    clsdbo_FactSurveyResponse.ProductSubcategoryKey = System.Convert.ToInt32(txtProductSubcategoryKey.Text);
                    clsdbo_FactSurveyResponse.EnglishProductSubcategoryName = System.Convert.ToString(txtEnglishProductSubcategoryName.Text);
                    if (string.IsNullOrEmpty(txtDate.Text)) {
                        clsdbo_FactSurveyResponse.Date = null;
                    } else {
                        clsdbo_FactSurveyResponse.Date = System.Convert.ToDateTime(txtDate.Text); }
                    bool bSucess = false;
                    bSucess = dbo_FactSurveyResponseDataClass.Update(oclsdbo_FactSurveyResponse, clsdbo_FactSurveyResponse);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_FactSurveyResponse");
                        grddbo_FactSurveyResponse.EditIndex = -1;
                        LoadGriddbo_FactSurveyResponse();
                    } else {
                        ec.ShowMessage(" Update failed. ", " Dbo. Fact Survey Response ");
                    }
                }
            } catch {  
            }
        }

        private void DeleteRecord()
        {
            dbo_FactSurveyResponseClass clsdbo_FactSurveyResponse = new dbo_FactSurveyResponseClass();
            Label lblSurveyResponseKey = (Label)grddbo_FactSurveyResponse.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblSurveyResponseKey");
            clsdbo_FactSurveyResponse.SurveyResponseKey = System.Convert.ToInt32(lblSurveyResponseKey.Text);
            clsdbo_FactSurveyResponse = dbo_FactSurveyResponseDataClass.Select_Record(clsdbo_FactSurveyResponse);
            bool bSucess = false;
            bSucess = dbo_FactSurveyResponseDataClass.Delete(clsdbo_FactSurveyResponse);
            if (bSucess == true) {
                Session.Remove("dvdbo_FactSurveyResponse");
                LoadGriddbo_FactSurveyResponse();
            } else {
                ec.ShowMessage(" Delete failed. ", " Dbo. Fact Survey Response ");
            }
        }

        private Boolean VerifyData()
        {
            TextBox txtSurveyResponseKey = (TextBox)grddbo_FactSurveyResponse.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSurveyResponseKey");
            DropDownList txtDateKey = (DropDownList)grddbo_FactSurveyResponse.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDateKey");
            DropDownList txtCustomerKey = (DropDownList)grddbo_FactSurveyResponse.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCustomerKey");
            TextBox txtProductCategoryKey = (TextBox)grddbo_FactSurveyResponse.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductCategoryKey");
            TextBox txtEnglishProductCategoryName = (TextBox)grddbo_FactSurveyResponse.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEnglishProductCategoryName");
            TextBox txtProductSubcategoryKey = (TextBox)grddbo_FactSurveyResponse.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtProductSubcategoryKey");
            TextBox txtEnglishProductSubcategoryName = (TextBox)grddbo_FactSurveyResponse.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEnglishProductSubcategoryName");
            TextBox txtDate = (TextBox)grddbo_FactSurveyResponse.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDate");

            if (txtDateKey.Text == "") {
                ec.ShowMessage(" Date Key is Required. ", " Dbo. Fact Survey Response ");
                txtDateKey.Focus();
                return false;}
            if (txtCustomerKey.Text == "") {
                ec.ShowMessage(" Customer Key is Required. ", " Dbo. Fact Survey Response ");
                txtCustomerKey.Focus();
                return false;}
            if (txtProductCategoryKey.Text == "") {
                ec.ShowMessage(" Product Category Key is Required. ", " Dbo. Fact Survey Response ");
                txtProductCategoryKey.Focus();
                return false;}
            if (txtEnglishProductCategoryName.Text == "") {
                ec.ShowMessage(" English Product Category Name is Required. ", " Dbo. Fact Survey Response ");
                txtEnglishProductCategoryName.Focus();
                return false;}
            if (txtProductSubcategoryKey.Text == "") {
                ec.ShowMessage(" Product Subcategory Key is Required. ", " Dbo. Fact Survey Response ");
                txtProductSubcategoryKey.Focus();
                return false;}
            if (txtEnglishProductSubcategoryName.Text == "") {
                ec.ShowMessage(" English Product Subcategory Name is Required. ", " Dbo. Fact Survey Response ");
                txtEnglishProductSubcategoryName.Focus();
                return false;}
            return true;
        }

        private Boolean VerifyDataNew()
        {
            DropDownList txtNewDateKey = (DropDownList)grddbo_FactSurveyResponse.FooterRow.FindControl("txtNewDateKey");
            DropDownList txtNewCustomerKey = (DropDownList)grddbo_FactSurveyResponse.FooterRow.FindControl("txtNewCustomerKey");
            TextBox txtNewProductCategoryKey = (TextBox)grddbo_FactSurveyResponse.FooterRow.FindControl("txtNewProductCategoryKey");
            TextBox txtNewEnglishProductCategoryName = (TextBox)grddbo_FactSurveyResponse.FooterRow.FindControl("txtNewEnglishProductCategoryName");
            TextBox txtNewProductSubcategoryKey = (TextBox)grddbo_FactSurveyResponse.FooterRow.FindControl("txtNewProductSubcategoryKey");
            TextBox txtNewEnglishProductSubcategoryName = (TextBox)grddbo_FactSurveyResponse.FooterRow.FindControl("txtNewEnglishProductSubcategoryName");
            TextBox txtNewDate = (TextBox)grddbo_FactSurveyResponse.FooterRow.FindControl("txtNewDate");

            if (txtNewDateKey.Text == "") {
                ec.ShowMessage(" Date Key is Required. ", " Dbo. Fact Survey Response ");
                txtNewDateKey.Focus();
                return false;}
            if (txtNewCustomerKey.Text == "") {
                ec.ShowMessage(" Customer Key is Required. ", " Dbo. Fact Survey Response ");
                txtNewCustomerKey.Focus();
                return false;}
            if (txtNewProductCategoryKey.Text == "") {
                ec.ShowMessage(" Product Category Key is Required. ", " Dbo. Fact Survey Response ");
                txtNewProductCategoryKey.Focus();
                return false;}
            if (txtNewEnglishProductCategoryName.Text == "") {
                ec.ShowMessage(" English Product Category Name is Required. ", " Dbo. Fact Survey Response ");
                txtNewEnglishProductCategoryName.Focus();
                return false;}
            if (txtNewProductSubcategoryKey.Text == "") {
                ec.ShowMessage(" Product Subcategory Key is Required. ", " Dbo. Fact Survey Response ");
                txtNewProductSubcategoryKey.Focus();
                return false;}
            if (txtNewEnglishProductSubcategoryName.Text == "") {
                ec.ShowMessage(" English Product Subcategory Name is Required. ", " Dbo. Fact Survey Response ");
                txtNewEnglishProductSubcategoryName.Focus();
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
		    grddbo_FactSurveyResponse.PageIndex = 0;
		    grddbo_FactSurveyResponse.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_FactSurveyResponse();
        }

        public void butShowAll_Click(object sender, System.EventArgs e)
        {
		    txtSearch.Text = null;
		    Session.Remove("dvdbo_FactSurveyResponse");
		    LoadGriddbo_FactSurveyResponse();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
		    	Session.Remove("dvdbo_FactSurveyResponse");
			if ((Session["dvdbo_FactSurveyResponse"] != null)) {
				dvdbo_FactSurveyResponse = (DataView)Session["dvdbo_FactSurveyResponse"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_FactSurveyResponse = dbo_FactSurveyResponseDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_FactSurveyResponse"] = dvdbo_FactSurveyResponse;
		    	}
                if (dvdbo_FactSurveyResponse.Count > 0) {
                    grddbo_FactSurveyResponse.DataSource = dvdbo_FactSurveyResponse;
                    grddbo_FactSurveyResponse.DataBind();
                }
                if (dvdbo_FactSurveyResponse.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("SurveyResponseKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("DateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("CustomerKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("ProductCategoryKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("EnglishProductCategoryName", Type.GetType("System.String"));
                    dt.Columns.Add("ProductSubcategoryKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("EnglishProductSubcategoryName", Type.GetType("System.String"));
                    dt.Columns.Add("Date", Type.GetType("System.DateTime"));
                    dvdbo_FactSurveyResponse = dt.DefaultView;
                    Session["dvdbo_FactSurveyResponse"] = dvdbo_FactSurveyResponse;

                    grddbo_FactSurveyResponse.DataSource = dvdbo_FactSurveyResponse;
                    grddbo_FactSurveyResponse.DataBind();

                    int TotalColumns = grddbo_FactSurveyResponse.Rows[0].Cells.Count;
                    grddbo_FactSurveyResponse.Rows[0].Cells.Clear();
                    grddbo_FactSurveyResponse.Rows[0].Cells.Add(new TableCell());
                    grddbo_FactSurveyResponse.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_FactSurveyResponse.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_FactSurveyResponse.Sort = htmlHiddenSortExpression.Value;
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Survey Response ");
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
                    { dt = dbo_FactSurveyResponseDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_FactSurveyResponseDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Fact Survey Response", "Many");
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
                    GVExport.DataSource = Session["dvdbo_FactSurveyResponse"];
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
 

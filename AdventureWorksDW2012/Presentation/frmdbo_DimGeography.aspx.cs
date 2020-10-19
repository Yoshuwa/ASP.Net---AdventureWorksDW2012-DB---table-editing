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
    public partial class frmdbo_DimGeography : System.Web.UI.Page
    {

        private dbo_DimGeographyDataClass clsdbo_DimGeographyData = new dbo_DimGeographyDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimGeography;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                Session["SalesTerritoryKey_SelectedValue"] = "";

                Session.Remove("dvdbo_DimGeography");
                Session.Remove("Row");

                cmbFields.Items.Add("Geography Key");
                cmbFields.Items.Add("City");
                cmbFields.Items.Add("State Province Code");
                cmbFields.Items.Add("State Province Name");
                cmbFields.Items.Add("Country Region Code");
                cmbFields.Items.Add("English Country Region Name");
                cmbFields.Items.Add("Spanish Country Region Name");
                cmbFields.Items.Add("French Country Region Name");
                cmbFields.Items.Add("Postal Code");
                cmbFields.Items.Add("Sales Territory Key");
                cmbFields.Items.Add("Ip Address Locator");

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

                LoadGriddbo_DimGeography();
            }
        }

        private void Loaddbo_DimGeography_dbo_DimSalesTerritoryComboBox(GridViewRowEventArgs e)
        {
            List<dbo_DimGeography_dbo_DimSalesTerritoryClass> dbo_DimGeography_dbo_DimSalesTerritoryList = new  List<dbo_DimGeography_dbo_DimSalesTerritoryClass>();
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList txtSalesTerritoryKey = (DropDownList)e.Row.FindControl("txtSalesTerritoryKey");
                if (txtSalesTerritoryKey != null) {
                    try {
                        dbo_DimGeography_dbo_DimSalesTerritoryList = dbo_DimGeography_dbo_DimSalesTerritoryDataClass.List();
                        txtSalesTerritoryKey.DataSource = dbo_DimGeography_dbo_DimSalesTerritoryList;
                        txtSalesTerritoryKey.DataValueField = "SalesTerritoryKey";
                        txtSalesTerritoryKey.DataTextField = "SalesTerritoryAlternateKey";
                        txtSalesTerritoryKey.DataBind();
                        txtSalesTerritoryKey.SelectedValue = Convert.ToString(Session["SalesTerritoryKey_SelectedValue"]);
                    }
                        catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Dim Geography ");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                DropDownList txtNewSalesTerritoryKey = (DropDownList)e.Row.FindControl("txtNewSalesTerritoryKey");
                if (txtNewSalesTerritoryKey != null) {
                    try {
                        dbo_DimGeography_dbo_DimSalesTerritoryList = dbo_DimGeography_dbo_DimSalesTerritoryDataClass.List();
                        txtNewSalesTerritoryKey.DataSource = dbo_DimGeography_dbo_DimSalesTerritoryList;
                        txtNewSalesTerritoryKey.DataValueField = "SalesTerritoryKey";
                        txtNewSalesTerritoryKey.DataTextField = "SalesTerritoryAlternateKey";
                        txtNewSalesTerritoryKey.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ec.ShowMessage(ex.Message, " Dbo. Dim Geography ");
                    }
                }
            }
        }

        private void LoadGriddbo_DimGeography()
        {
            try {
                if ((Session["dvdbo_DimGeography"] != null)) {
                    dvdbo_DimGeography = (DataView)Session["dvdbo_DimGeography"];
                    // DataView was not found in the session.
                } else {
                    dvdbo_DimGeography = dbo_DimGeographyDataClass.SelectAll().DefaultView;
                    Session["dvdbo_DimGeography"] = dvdbo_DimGeography;
                }
                if (dvdbo_DimGeography.Count > 0) {
                    grddbo_DimGeography.DataSource = dvdbo_DimGeography;
                    grddbo_DimGeography.DataBind();
                }
                if (dvdbo_DimGeography.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("GeographyKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("City", Type.GetType("System.String"));
                    dt.Columns.Add("StateProvinceCode", Type.GetType("System.String"));
                    dt.Columns.Add("StateProvinceName", Type.GetType("System.String"));
                    dt.Columns.Add("CountryRegionCode", Type.GetType("System.String"));
                    dt.Columns.Add("EnglishCountryRegionName", Type.GetType("System.String"));
                    dt.Columns.Add("SpanishCountryRegionName", Type.GetType("System.String"));
                    dt.Columns.Add("FrenchCountryRegionName", Type.GetType("System.String"));
                    dt.Columns.Add("PostalCode", Type.GetType("System.String"));
                    dt.Columns.Add("SalesTerritoryAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("IpAddressLocator", Type.GetType("System.String"));
                    dvdbo_DimGeography = dt.DefaultView;
                    Session["dvdbo_DimGeography"] = dvdbo_DimGeography;

                    grddbo_DimGeography.DataSource = dvdbo_DimGeography;
                    grddbo_DimGeography.DataBind();

                    int TotalColumns = grddbo_DimGeography.Rows[0].Cells.Count;
                    grddbo_DimGeography.Rows[0].Cells.Clear();
                    grddbo_DimGeography.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimGeography.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimGeography.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimGeography.Sort = htmlHiddenSortExpression.Value;
            }
            catch (Exception ex)
            {
                ec.ShowMessage(ex.Message, " Dbo. Dim Geography ");
            }
        }

        protected void grddbo_DimGeography_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Loaddbo_DimGeography_dbo_DimSalesTerritoryComboBox(e);
            if (e.Row.RowType == DataControlRowType.DataRow) {
                TextBox txtGeographyKey = (TextBox)e.Row.FindControl("txtGeographyKey");
                if (txtGeographyKey != null) {
                    txtGeographyKey.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                TextBox txtNewGeographyKey = (TextBox)e.Row.FindControl("txtNewGeographyKey");
                if (txtNewGeographyKey != null) {
                    txtNewGeographyKey.Enabled = false;
                }
                txtNewGeographyKey.Text = System.Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "DimGeography"));
            }
        }

        protected void grddbo_DimGeography_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grddbo_DimGeography.EditIndex = -1;
            LoadGriddbo_DimGeography();
        }

        protected void grddbo_DimGeography_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grddbo_DimGeography.EditIndex = e.NewEditIndex;
            Edit();
        }

        protected void grddbo_DimGeography_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            UpdateRecord();
        }

        protected void grddbo_DimGeography_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            DeleteRecord();
        }

        protected void grddbo_DimGeography_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert")) {
                InsertRecord();
            }
        }

        protected void grddbo_DimGeography_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            GridViewRow gvr = (GridViewRow)gv.BottomPagerRow;
            if (gvr != null) {
                gvr.Visible = true;
            }
        }

        protected void grddbo_DimGeography_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddbo_DimGeography.PageIndex = e.NewPageIndex;
            LoadGriddbo_DimGeography();
        }

        protected void grddbo_DimGeography_Sorting(object sender, GridViewSortEventArgs e)
        {
            htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            LoadGriddbo_DimGeography();
        }

        private void Edit()
        {
            try {
                dbo_DimGeographyClass clsdbo_DimGeography = new dbo_DimGeographyClass();
                Label lblGeographyKey = (Label)grddbo_DimGeography.Rows[grddbo_DimGeography.EditIndex].FindControl("lblGeographyKey");
                clsdbo_DimGeography.GeographyKey = System.Convert.ToInt32(lblGeographyKey.Text);
                clsdbo_DimGeography = dbo_DimGeographyDataClass.Select_Record(clsdbo_DimGeography);

                Session["SalesTerritoryKey_SelectedValue"] = clsdbo_DimGeography.SalesTerritoryKey;

                LoadGriddbo_DimGeography();
            } catch {  
            }
        }

        private void InsertRecord()
        {
            try {
                TextBox txtNewCity = (TextBox)grddbo_DimGeography.FooterRow.FindControl("txtNewCity");
                TextBox txtNewStateProvinceCode = (TextBox)grddbo_DimGeography.FooterRow.FindControl("txtNewStateProvinceCode");
                TextBox txtNewStateProvinceName = (TextBox)grddbo_DimGeography.FooterRow.FindControl("txtNewStateProvinceName");
                TextBox txtNewCountryRegionCode = (TextBox)grddbo_DimGeography.FooterRow.FindControl("txtNewCountryRegionCode");
                TextBox txtNewEnglishCountryRegionName = (TextBox)grddbo_DimGeography.FooterRow.FindControl("txtNewEnglishCountryRegionName");
                TextBox txtNewSpanishCountryRegionName = (TextBox)grddbo_DimGeography.FooterRow.FindControl("txtNewSpanishCountryRegionName");
                TextBox txtNewFrenchCountryRegionName = (TextBox)grddbo_DimGeography.FooterRow.FindControl("txtNewFrenchCountryRegionName");
                TextBox txtNewPostalCode = (TextBox)grddbo_DimGeography.FooterRow.FindControl("txtNewPostalCode");
                DropDownList txtNewSalesTerritoryKey = (DropDownList)grddbo_DimGeography.FooterRow.FindControl("txtNewSalesTerritoryKey");
                TextBox txtNewIpAddressLocator = (TextBox)grddbo_DimGeography.FooterRow.FindControl("txtNewIpAddressLocator");

                dbo_DimGeographyClass clsdbo_DimGeography = new dbo_DimGeographyClass();
                if (VerifyDataNew() == true) {
                    if (string.IsNullOrEmpty(txtNewCity.Text)) {
                        clsdbo_DimGeography.City = null;
                    } else {
                        clsdbo_DimGeography.City = txtNewCity.Text; }
                    if (string.IsNullOrEmpty(txtNewStateProvinceCode.Text)) {
                        clsdbo_DimGeography.StateProvinceCode = null;
                    } else {
                        clsdbo_DimGeography.StateProvinceCode = txtNewStateProvinceCode.Text; }
                    if (string.IsNullOrEmpty(txtNewStateProvinceName.Text)) {
                        clsdbo_DimGeography.StateProvinceName = null;
                    } else {
                        clsdbo_DimGeography.StateProvinceName = txtNewStateProvinceName.Text; }
                    if (string.IsNullOrEmpty(txtNewCountryRegionCode.Text)) {
                        clsdbo_DimGeography.CountryRegionCode = null;
                    } else {
                        clsdbo_DimGeography.CountryRegionCode = txtNewCountryRegionCode.Text; }
                    if (string.IsNullOrEmpty(txtNewEnglishCountryRegionName.Text)) {
                        clsdbo_DimGeography.EnglishCountryRegionName = null;
                    } else {
                        clsdbo_DimGeography.EnglishCountryRegionName = txtNewEnglishCountryRegionName.Text; }
                    if (string.IsNullOrEmpty(txtNewSpanishCountryRegionName.Text)) {
                        clsdbo_DimGeography.SpanishCountryRegionName = null;
                    } else {
                        clsdbo_DimGeography.SpanishCountryRegionName = txtNewSpanishCountryRegionName.Text; }
                    if (string.IsNullOrEmpty(txtNewFrenchCountryRegionName.Text)) {
                        clsdbo_DimGeography.FrenchCountryRegionName = null;
                    } else {
                        clsdbo_DimGeography.FrenchCountryRegionName = txtNewFrenchCountryRegionName.Text; }
                    if (string.IsNullOrEmpty(txtNewPostalCode.Text)) {
                        clsdbo_DimGeography.PostalCode = null;
                    } else {
                        clsdbo_DimGeography.PostalCode = txtNewPostalCode.Text; }
                    if (string.IsNullOrEmpty(txtNewSalesTerritoryKey.SelectedValue)) {
                        clsdbo_DimGeography.SalesTerritoryKey = null;
                    } else {
                        clsdbo_DimGeography.SalesTerritoryKey = System.Convert.ToInt32(txtNewSalesTerritoryKey.SelectedValue); }
                    if (string.IsNullOrEmpty(txtNewIpAddressLocator.Text)) {
                        clsdbo_DimGeography.IpAddressLocator = null;
                    } else {
                        clsdbo_DimGeography.IpAddressLocator = txtNewIpAddressLocator.Text; }
                    bool bSucess = false;
                    bSucess = dbo_DimGeographyDataClass.Add(clsdbo_DimGeography);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimGeography");
                        LoadGriddbo_DimGeography();
                    } else {
                        ec.ShowMessage(" Insert failed. ", " Dbo. Dim Geography ");
                    }
                }
            } catch {  
            }
        }

        private void UpdateRecord()
        {
            try {
                TextBox txtGeographyKey = (TextBox)grddbo_DimGeography.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtGeographyKey");
                TextBox txtCity = (TextBox)grddbo_DimGeography.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCity");
                TextBox txtStateProvinceCode = (TextBox)grddbo_DimGeography.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtStateProvinceCode");
                TextBox txtStateProvinceName = (TextBox)grddbo_DimGeography.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtStateProvinceName");
                TextBox txtCountryRegionCode = (TextBox)grddbo_DimGeography.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCountryRegionCode");
                TextBox txtEnglishCountryRegionName = (TextBox)grddbo_DimGeography.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEnglishCountryRegionName");
                TextBox txtSpanishCountryRegionName = (TextBox)grddbo_DimGeography.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSpanishCountryRegionName");
                TextBox txtFrenchCountryRegionName = (TextBox)grddbo_DimGeography.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFrenchCountryRegionName");
                TextBox txtPostalCode = (TextBox)grddbo_DimGeography.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtPostalCode");
                DropDownList txtSalesTerritoryKey = (DropDownList)grddbo_DimGeography.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesTerritoryKey");
                TextBox txtIpAddressLocator = (TextBox)grddbo_DimGeography.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtIpAddressLocator");

                dbo_DimGeographyClass oclsdbo_DimGeography = new dbo_DimGeographyClass();
                dbo_DimGeographyClass clsdbo_DimGeography = new dbo_DimGeographyClass();
                oclsdbo_DimGeography.GeographyKey = System.Convert.ToInt32(txtGeographyKey.Text);
                oclsdbo_DimGeography = dbo_DimGeographyDataClass.Select_Record(oclsdbo_DimGeography);

                if (VerifyData() == true) {
                    if (string.IsNullOrEmpty(txtCity.Text)) {
                        clsdbo_DimGeography.City = null;
                    } else {
                        clsdbo_DimGeography.City = txtCity.Text; }
                    if (string.IsNullOrEmpty(txtStateProvinceCode.Text)) {
                        clsdbo_DimGeography.StateProvinceCode = null;
                    } else {
                        clsdbo_DimGeography.StateProvinceCode = txtStateProvinceCode.Text; }
                    if (string.IsNullOrEmpty(txtStateProvinceName.Text)) {
                        clsdbo_DimGeography.StateProvinceName = null;
                    } else {
                        clsdbo_DimGeography.StateProvinceName = txtStateProvinceName.Text; }
                    if (string.IsNullOrEmpty(txtCountryRegionCode.Text)) {
                        clsdbo_DimGeography.CountryRegionCode = null;
                    } else {
                        clsdbo_DimGeography.CountryRegionCode = txtCountryRegionCode.Text; }
                    if (string.IsNullOrEmpty(txtEnglishCountryRegionName.Text)) {
                        clsdbo_DimGeography.EnglishCountryRegionName = null;
                    } else {
                        clsdbo_DimGeography.EnglishCountryRegionName = txtEnglishCountryRegionName.Text; }
                    if (string.IsNullOrEmpty(txtSpanishCountryRegionName.Text)) {
                        clsdbo_DimGeography.SpanishCountryRegionName = null;
                    } else {
                        clsdbo_DimGeography.SpanishCountryRegionName = txtSpanishCountryRegionName.Text; }
                    if (string.IsNullOrEmpty(txtFrenchCountryRegionName.Text)) {
                        clsdbo_DimGeography.FrenchCountryRegionName = null;
                    } else {
                        clsdbo_DimGeography.FrenchCountryRegionName = txtFrenchCountryRegionName.Text; }
                    if (string.IsNullOrEmpty(txtPostalCode.Text)) {
                        clsdbo_DimGeography.PostalCode = null;
                    } else {
                        clsdbo_DimGeography.PostalCode = txtPostalCode.Text; }
                    if (string.IsNullOrEmpty(txtSalesTerritoryKey.SelectedValue)) {
                        clsdbo_DimGeography.SalesTerritoryKey = null;
                    } else {
                        clsdbo_DimGeography.SalesTerritoryKey = System.Convert.ToInt32(txtSalesTerritoryKey.SelectedValue); }
                    if (string.IsNullOrEmpty(txtIpAddressLocator.Text)) {
                        clsdbo_DimGeography.IpAddressLocator = null;
                    } else {
                        clsdbo_DimGeography.IpAddressLocator = txtIpAddressLocator.Text; }
                    bool bSucess = false;
                    bSucess = dbo_DimGeographyDataClass.Update(oclsdbo_DimGeography, clsdbo_DimGeography);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimGeography");
                        grddbo_DimGeography.EditIndex = -1;
                        LoadGriddbo_DimGeography();
                    } else {
                        ec.ShowMessage(" Update failed. ", " Dbo. Dim Geography ");
                    }
                }
            } catch {  
            }
        }

        private void DeleteRecord()
        {
            dbo_DimGeographyClass clsdbo_DimGeography = new dbo_DimGeographyClass();
            Label lblGeographyKey = (Label)grddbo_DimGeography.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblGeographyKey");
            clsdbo_DimGeography.GeographyKey = System.Convert.ToInt32(lblGeographyKey.Text);
            clsdbo_DimGeography = dbo_DimGeographyDataClass.Select_Record(clsdbo_DimGeography);
            bool bSucess = false;
            bSucess = dbo_DimGeographyDataClass.Delete(clsdbo_DimGeography);
            if (bSucess == true) {
                Session.Remove("dvdbo_DimGeography");
                LoadGriddbo_DimGeography();
            } else {
                ec.ShowMessage(" Delete failed. ", " Dbo. Dim Geography ");
            }
        }

        private Boolean VerifyData()
        {
            TextBox txtGeographyKey = (TextBox)grddbo_DimGeography.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtGeographyKey");
            TextBox txtCity = (TextBox)grddbo_DimGeography.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCity");
            TextBox txtStateProvinceCode = (TextBox)grddbo_DimGeography.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtStateProvinceCode");
            TextBox txtStateProvinceName = (TextBox)grddbo_DimGeography.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtStateProvinceName");
            TextBox txtCountryRegionCode = (TextBox)grddbo_DimGeography.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtCountryRegionCode");
            TextBox txtEnglishCountryRegionName = (TextBox)grddbo_DimGeography.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEnglishCountryRegionName");
            TextBox txtSpanishCountryRegionName = (TextBox)grddbo_DimGeography.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSpanishCountryRegionName");
            TextBox txtFrenchCountryRegionName = (TextBox)grddbo_DimGeography.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFrenchCountryRegionName");
            TextBox txtPostalCode = (TextBox)grddbo_DimGeography.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtPostalCode");
            DropDownList txtSalesTerritoryKey = (DropDownList)grddbo_DimGeography.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSalesTerritoryKey");
            TextBox txtIpAddressLocator = (TextBox)grddbo_DimGeography.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtIpAddressLocator");

            return true;
        }

        private Boolean VerifyDataNew()
        {
            TextBox txtNewCity = (TextBox)grddbo_DimGeography.FooterRow.FindControl("txtNewCity");
            TextBox txtNewStateProvinceCode = (TextBox)grddbo_DimGeography.FooterRow.FindControl("txtNewStateProvinceCode");
            TextBox txtNewStateProvinceName = (TextBox)grddbo_DimGeography.FooterRow.FindControl("txtNewStateProvinceName");
            TextBox txtNewCountryRegionCode = (TextBox)grddbo_DimGeography.FooterRow.FindControl("txtNewCountryRegionCode");
            TextBox txtNewEnglishCountryRegionName = (TextBox)grddbo_DimGeography.FooterRow.FindControl("txtNewEnglishCountryRegionName");
            TextBox txtNewSpanishCountryRegionName = (TextBox)grddbo_DimGeography.FooterRow.FindControl("txtNewSpanishCountryRegionName");
            TextBox txtNewFrenchCountryRegionName = (TextBox)grddbo_DimGeography.FooterRow.FindControl("txtNewFrenchCountryRegionName");
            TextBox txtNewPostalCode = (TextBox)grddbo_DimGeography.FooterRow.FindControl("txtNewPostalCode");
            DropDownList txtNewSalesTerritoryKey = (DropDownList)grddbo_DimGeography.FooterRow.FindControl("txtNewSalesTerritoryKey");
            TextBox txtNewIpAddressLocator = (TextBox)grddbo_DimGeography.FooterRow.FindControl("txtNewIpAddressLocator");

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
		    grddbo_DimGeography.PageIndex = 0;
		    grddbo_DimGeography.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimGeography();
        }

        public void butShowAll_Click(object sender, System.EventArgs e)
        {
		    txtSearch.Text = null;
		    Session.Remove("dvdbo_DimGeography");
		    LoadGriddbo_DimGeography();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
		    	Session.Remove("dvdbo_DimGeography");
			if ((Session["dvdbo_DimGeography"] != null)) {
				dvdbo_DimGeography = (DataView)Session["dvdbo_DimGeography"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimGeography = dbo_DimGeographyDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimGeography"] = dvdbo_DimGeography;
		    	}
                if (dvdbo_DimGeography.Count > 0) {
                    grddbo_DimGeography.DataSource = dvdbo_DimGeography;
                    grddbo_DimGeography.DataBind();
                }
                if (dvdbo_DimGeography.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("GeographyKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("City", Type.GetType("System.String"));
                    dt.Columns.Add("StateProvinceCode", Type.GetType("System.String"));
                    dt.Columns.Add("StateProvinceName", Type.GetType("System.String"));
                    dt.Columns.Add("CountryRegionCode", Type.GetType("System.String"));
                    dt.Columns.Add("EnglishCountryRegionName", Type.GetType("System.String"));
                    dt.Columns.Add("SpanishCountryRegionName", Type.GetType("System.String"));
                    dt.Columns.Add("FrenchCountryRegionName", Type.GetType("System.String"));
                    dt.Columns.Add("PostalCode", Type.GetType("System.String"));
                    dt.Columns.Add("SalesTerritoryAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("IpAddressLocator", Type.GetType("System.String"));
                    dvdbo_DimGeography = dt.DefaultView;
                    Session["dvdbo_DimGeography"] = dvdbo_DimGeography;

                    grddbo_DimGeography.DataSource = dvdbo_DimGeography;
                    grddbo_DimGeography.DataBind();

                    int TotalColumns = grddbo_DimGeography.Rows[0].Cells.Count;
                    grddbo_DimGeography.Rows[0].Cells.Clear();
                    grddbo_DimGeography.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimGeography.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimGeography.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimGeography.Sort = htmlHiddenSortExpression.Value;
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Geography ");
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
                    { dt = dbo_DimGeographyDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimGeographyDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Geography", "Many");
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
                    GVExport.DataSource = Session["dvdbo_DimGeography"];
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
 

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
    public partial class frmdbo_DimPromotion : System.Web.UI.Page
    {

        private dbo_DimPromotionDataClass clsdbo_DimPromotionData = new dbo_DimPromotionDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimPromotion;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {

                Session.Remove("dvdbo_DimPromotion");
                Session.Remove("Row");

                cmbFields.Items.Add("Promotion Key");
                cmbFields.Items.Add("Promotion Alternate Key");
                cmbFields.Items.Add("English Promotion Name");
                cmbFields.Items.Add("Spanish Promotion Name");
                cmbFields.Items.Add("French Promotion Name");
                cmbFields.Items.Add("Discount Pct");
                cmbFields.Items.Add("English Promotion Type");
                cmbFields.Items.Add("Spanish Promotion Type");
                cmbFields.Items.Add("French Promotion Type");
                cmbFields.Items.Add("English Promotion Category");
                cmbFields.Items.Add("Spanish Promotion Category");
                cmbFields.Items.Add("French Promotion Category");
                cmbFields.Items.Add("Start Date");
                cmbFields.Items.Add("End Date");
                cmbFields.Items.Add("Min Qty");
                cmbFields.Items.Add("Max Qty");

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

                LoadGriddbo_DimPromotion();
            }
        }

        private void LoadGriddbo_DimPromotion()
        {
            try {
                if ((Session["dvdbo_DimPromotion"] != null)) {
                    dvdbo_DimPromotion = (DataView)Session["dvdbo_DimPromotion"];
                    // DataView was not found in the session.
                } else {
                    dvdbo_DimPromotion = dbo_DimPromotionDataClass.SelectAll().DefaultView;
                    Session["dvdbo_DimPromotion"] = dvdbo_DimPromotion;
                }
                if (dvdbo_DimPromotion.Count > 0) {
                    grddbo_DimPromotion.DataSource = dvdbo_DimPromotion;
                    grddbo_DimPromotion.DataBind();
                }
                if (dvdbo_DimPromotion.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("PromotionKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("PromotionAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("EnglishPromotionName", Type.GetType("System.String"));
                    dt.Columns.Add("SpanishPromotionName", Type.GetType("System.String"));
                    dt.Columns.Add("FrenchPromotionName", Type.GetType("System.String"));
                    dt.Columns.Add("DiscountPct", Type.GetType("System.Decimal"));
                    dt.Columns.Add("EnglishPromotionType", Type.GetType("System.String"));
                    dt.Columns.Add("SpanishPromotionType", Type.GetType("System.String"));
                    dt.Columns.Add("FrenchPromotionType", Type.GetType("System.String"));
                    dt.Columns.Add("EnglishPromotionCategory", Type.GetType("System.String"));
                    dt.Columns.Add("SpanishPromotionCategory", Type.GetType("System.String"));
                    dt.Columns.Add("FrenchPromotionCategory", Type.GetType("System.String"));
                    dt.Columns.Add("StartDate", Type.GetType("System.DateTime"));
                    dt.Columns.Add("EndDate", Type.GetType("System.DateTime"));
                    dt.Columns.Add("MinQty", Type.GetType("System.Int32"));
                    dt.Columns.Add("MaxQty", Type.GetType("System.Int32"));
                    dvdbo_DimPromotion = dt.DefaultView;
                    Session["dvdbo_DimPromotion"] = dvdbo_DimPromotion;

                    grddbo_DimPromotion.DataSource = dvdbo_DimPromotion;
                    grddbo_DimPromotion.DataBind();

                    int TotalColumns = grddbo_DimPromotion.Rows[0].Cells.Count;
                    grddbo_DimPromotion.Rows[0].Cells.Clear();
                    grddbo_DimPromotion.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimPromotion.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimPromotion.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimPromotion.Sort = htmlHiddenSortExpression.Value;
            }
            catch (Exception ex)
            {
                ec.ShowMessage(ex.Message, " Dbo. Dim Promotion ");
            }
        }

        protected void grddbo_DimPromotion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                TextBox txtPromotionKey = (TextBox)e.Row.FindControl("txtPromotionKey");
                if (txtPromotionKey != null) {
                    txtPromotionKey.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer) {
                TextBox txtNewPromotionKey = (TextBox)e.Row.FindControl("txtNewPromotionKey");
                if (txtNewPromotionKey != null) {
                    txtNewPromotionKey.Enabled = false;
                }
                txtNewPromotionKey.Text = System.Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "DimPromotion"));
            }
        }

        protected void grddbo_DimPromotion_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grddbo_DimPromotion.EditIndex = -1;
            LoadGriddbo_DimPromotion();
        }

        protected void grddbo_DimPromotion_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grddbo_DimPromotion.EditIndex = e.NewEditIndex;
            Edit();
        }

        protected void grddbo_DimPromotion_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            UpdateRecord();
        }

        protected void grddbo_DimPromotion_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["Row"] = e.RowIndex;
            DeleteRecord();
        }

        protected void grddbo_DimPromotion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert")) {
                InsertRecord();
            }
        }

        protected void grddbo_DimPromotion_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            GridViewRow gvr = (GridViewRow)gv.BottomPagerRow;
            if (gvr != null) {
                gvr.Visible = true;
            }
        }

        protected void grddbo_DimPromotion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddbo_DimPromotion.PageIndex = e.NewPageIndex;
            LoadGriddbo_DimPromotion();
        }

        protected void grddbo_DimPromotion_Sorting(object sender, GridViewSortEventArgs e)
        {
            htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            LoadGriddbo_DimPromotion();
        }

        private void Edit()
        {
            try {
                dbo_DimPromotionClass clsdbo_DimPromotion = new dbo_DimPromotionClass();
                Label lblPromotionKey = (Label)grddbo_DimPromotion.Rows[grddbo_DimPromotion.EditIndex].FindControl("lblPromotionKey");
                clsdbo_DimPromotion.PromotionKey = System.Convert.ToInt32(lblPromotionKey.Text);
                clsdbo_DimPromotion = dbo_DimPromotionDataClass.Select_Record(clsdbo_DimPromotion);


                LoadGriddbo_DimPromotion();
            } catch {  
            }
        }

        private void InsertRecord()
        {
            try {
                TextBox txtNewPromotionAlternateKey = (TextBox)grddbo_DimPromotion.FooterRow.FindControl("txtNewPromotionAlternateKey");
                TextBox txtNewEnglishPromotionName = (TextBox)grddbo_DimPromotion.FooterRow.FindControl("txtNewEnglishPromotionName");
                TextBox txtNewSpanishPromotionName = (TextBox)grddbo_DimPromotion.FooterRow.FindControl("txtNewSpanishPromotionName");
                TextBox txtNewFrenchPromotionName = (TextBox)grddbo_DimPromotion.FooterRow.FindControl("txtNewFrenchPromotionName");
                TextBox txtNewDiscountPct = (TextBox)grddbo_DimPromotion.FooterRow.FindControl("txtNewDiscountPct");
                TextBox txtNewEnglishPromotionType = (TextBox)grddbo_DimPromotion.FooterRow.FindControl("txtNewEnglishPromotionType");
                TextBox txtNewSpanishPromotionType = (TextBox)grddbo_DimPromotion.FooterRow.FindControl("txtNewSpanishPromotionType");
                TextBox txtNewFrenchPromotionType = (TextBox)grddbo_DimPromotion.FooterRow.FindControl("txtNewFrenchPromotionType");
                TextBox txtNewEnglishPromotionCategory = (TextBox)grddbo_DimPromotion.FooterRow.FindControl("txtNewEnglishPromotionCategory");
                TextBox txtNewSpanishPromotionCategory = (TextBox)grddbo_DimPromotion.FooterRow.FindControl("txtNewSpanishPromotionCategory");
                TextBox txtNewFrenchPromotionCategory = (TextBox)grddbo_DimPromotion.FooterRow.FindControl("txtNewFrenchPromotionCategory");
                TextBox txtNewStartDate = (TextBox)grddbo_DimPromotion.FooterRow.FindControl("txtNewStartDate");
                TextBox txtNewEndDate = (TextBox)grddbo_DimPromotion.FooterRow.FindControl("txtNewEndDate");
                TextBox txtNewMinQty = (TextBox)grddbo_DimPromotion.FooterRow.FindControl("txtNewMinQty");
                TextBox txtNewMaxQty = (TextBox)grddbo_DimPromotion.FooterRow.FindControl("txtNewMaxQty");

                dbo_DimPromotionClass clsdbo_DimPromotion = new dbo_DimPromotionClass();
                if (VerifyDataNew() == true) {
                    if (string.IsNullOrEmpty(txtNewPromotionAlternateKey.Text)) {
                        clsdbo_DimPromotion.PromotionAlternateKey = null;
                    } else {
                        clsdbo_DimPromotion.PromotionAlternateKey = System.Convert.ToInt32(txtNewPromotionAlternateKey.Text); }
                    if (string.IsNullOrEmpty(txtNewEnglishPromotionName.Text)) {
                        clsdbo_DimPromotion.EnglishPromotionName = null;
                    } else {
                        clsdbo_DimPromotion.EnglishPromotionName = txtNewEnglishPromotionName.Text; }
                    if (string.IsNullOrEmpty(txtNewSpanishPromotionName.Text)) {
                        clsdbo_DimPromotion.SpanishPromotionName = null;
                    } else {
                        clsdbo_DimPromotion.SpanishPromotionName = txtNewSpanishPromotionName.Text; }
                    if (string.IsNullOrEmpty(txtNewFrenchPromotionName.Text)) {
                        clsdbo_DimPromotion.FrenchPromotionName = null;
                    } else {
                        clsdbo_DimPromotion.FrenchPromotionName = txtNewFrenchPromotionName.Text; }
                    if (string.IsNullOrEmpty(txtNewDiscountPct.Text)) {
                        clsdbo_DimPromotion.DiscountPct = null;
                    } else {
                        clsdbo_DimPromotion.DiscountPct = System.Convert.ToDecimal(txtNewDiscountPct.Text); }
                    if (string.IsNullOrEmpty(txtNewEnglishPromotionType.Text)) {
                        clsdbo_DimPromotion.EnglishPromotionType = null;
                    } else {
                        clsdbo_DimPromotion.EnglishPromotionType = txtNewEnglishPromotionType.Text; }
                    if (string.IsNullOrEmpty(txtNewSpanishPromotionType.Text)) {
                        clsdbo_DimPromotion.SpanishPromotionType = null;
                    } else {
                        clsdbo_DimPromotion.SpanishPromotionType = txtNewSpanishPromotionType.Text; }
                    if (string.IsNullOrEmpty(txtNewFrenchPromotionType.Text)) {
                        clsdbo_DimPromotion.FrenchPromotionType = null;
                    } else {
                        clsdbo_DimPromotion.FrenchPromotionType = txtNewFrenchPromotionType.Text; }
                    if (string.IsNullOrEmpty(txtNewEnglishPromotionCategory.Text)) {
                        clsdbo_DimPromotion.EnglishPromotionCategory = null;
                    } else {
                        clsdbo_DimPromotion.EnglishPromotionCategory = txtNewEnglishPromotionCategory.Text; }
                    if (string.IsNullOrEmpty(txtNewSpanishPromotionCategory.Text)) {
                        clsdbo_DimPromotion.SpanishPromotionCategory = null;
                    } else {
                        clsdbo_DimPromotion.SpanishPromotionCategory = txtNewSpanishPromotionCategory.Text; }
                    if (string.IsNullOrEmpty(txtNewFrenchPromotionCategory.Text)) {
                        clsdbo_DimPromotion.FrenchPromotionCategory = null;
                    } else {
                        clsdbo_DimPromotion.FrenchPromotionCategory = txtNewFrenchPromotionCategory.Text; }
                    clsdbo_DimPromotion.StartDate = System.Convert.ToDateTime(txtNewStartDate.Text);
                    if (string.IsNullOrEmpty(txtNewEndDate.Text)) {
                        clsdbo_DimPromotion.EndDate = null;
                    } else {
                        clsdbo_DimPromotion.EndDate = System.Convert.ToDateTime(txtNewEndDate.Text); }
                    if (string.IsNullOrEmpty(txtNewMinQty.Text)) {
                        clsdbo_DimPromotion.MinQty = null;
                    } else {
                        clsdbo_DimPromotion.MinQty = System.Convert.ToInt32(txtNewMinQty.Text); }
                    if (string.IsNullOrEmpty(txtNewMaxQty.Text)) {
                        clsdbo_DimPromotion.MaxQty = null;
                    } else {
                        clsdbo_DimPromotion.MaxQty = System.Convert.ToInt32(txtNewMaxQty.Text); }
                    bool bSucess = false;
                    bSucess = dbo_DimPromotionDataClass.Add(clsdbo_DimPromotion);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimPromotion");
                        LoadGriddbo_DimPromotion();
                    } else {
                        ec.ShowMessage(" Insert failed. ", " Dbo. Dim Promotion ");
                    }
                }
            } catch {  
            }
        }

        private void UpdateRecord()
        {
            try {
                TextBox txtPromotionKey = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtPromotionKey");
                TextBox txtPromotionAlternateKey = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtPromotionAlternateKey");
                TextBox txtEnglishPromotionName = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEnglishPromotionName");
                TextBox txtSpanishPromotionName = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSpanishPromotionName");
                TextBox txtFrenchPromotionName = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFrenchPromotionName");
                TextBox txtDiscountPct = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDiscountPct");
                TextBox txtEnglishPromotionType = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEnglishPromotionType");
                TextBox txtSpanishPromotionType = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSpanishPromotionType");
                TextBox txtFrenchPromotionType = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFrenchPromotionType");
                TextBox txtEnglishPromotionCategory = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEnglishPromotionCategory");
                TextBox txtSpanishPromotionCategory = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSpanishPromotionCategory");
                TextBox txtFrenchPromotionCategory = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFrenchPromotionCategory");
                TextBox txtStartDate = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtStartDate");
                TextBox txtEndDate = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEndDate");
                TextBox txtMinQty = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtMinQty");
                TextBox txtMaxQty = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtMaxQty");

                dbo_DimPromotionClass oclsdbo_DimPromotion = new dbo_DimPromotionClass();
                dbo_DimPromotionClass clsdbo_DimPromotion = new dbo_DimPromotionClass();
                oclsdbo_DimPromotion.PromotionKey = System.Convert.ToInt32(txtPromotionKey.Text);
                oclsdbo_DimPromotion = dbo_DimPromotionDataClass.Select_Record(oclsdbo_DimPromotion);

                if (VerifyData() == true) {
                    if (string.IsNullOrEmpty(txtPromotionAlternateKey.Text)) {
                        clsdbo_DimPromotion.PromotionAlternateKey = null;
                    } else {
                        clsdbo_DimPromotion.PromotionAlternateKey = System.Convert.ToInt32(txtPromotionAlternateKey.Text); }
                    if (string.IsNullOrEmpty(txtEnglishPromotionName.Text)) {
                        clsdbo_DimPromotion.EnglishPromotionName = null;
                    } else {
                        clsdbo_DimPromotion.EnglishPromotionName = txtEnglishPromotionName.Text; }
                    if (string.IsNullOrEmpty(txtSpanishPromotionName.Text)) {
                        clsdbo_DimPromotion.SpanishPromotionName = null;
                    } else {
                        clsdbo_DimPromotion.SpanishPromotionName = txtSpanishPromotionName.Text; }
                    if (string.IsNullOrEmpty(txtFrenchPromotionName.Text)) {
                        clsdbo_DimPromotion.FrenchPromotionName = null;
                    } else {
                        clsdbo_DimPromotion.FrenchPromotionName = txtFrenchPromotionName.Text; }
                    if (string.IsNullOrEmpty(txtDiscountPct.Text)) {
                        clsdbo_DimPromotion.DiscountPct = null;
                    } else {
                        clsdbo_DimPromotion.DiscountPct = System.Convert.ToDecimal(txtDiscountPct.Text); }
                    if (string.IsNullOrEmpty(txtEnglishPromotionType.Text)) {
                        clsdbo_DimPromotion.EnglishPromotionType = null;
                    } else {
                        clsdbo_DimPromotion.EnglishPromotionType = txtEnglishPromotionType.Text; }
                    if (string.IsNullOrEmpty(txtSpanishPromotionType.Text)) {
                        clsdbo_DimPromotion.SpanishPromotionType = null;
                    } else {
                        clsdbo_DimPromotion.SpanishPromotionType = txtSpanishPromotionType.Text; }
                    if (string.IsNullOrEmpty(txtFrenchPromotionType.Text)) {
                        clsdbo_DimPromotion.FrenchPromotionType = null;
                    } else {
                        clsdbo_DimPromotion.FrenchPromotionType = txtFrenchPromotionType.Text; }
                    if (string.IsNullOrEmpty(txtEnglishPromotionCategory.Text)) {
                        clsdbo_DimPromotion.EnglishPromotionCategory = null;
                    } else {
                        clsdbo_DimPromotion.EnglishPromotionCategory = txtEnglishPromotionCategory.Text; }
                    if (string.IsNullOrEmpty(txtSpanishPromotionCategory.Text)) {
                        clsdbo_DimPromotion.SpanishPromotionCategory = null;
                    } else {
                        clsdbo_DimPromotion.SpanishPromotionCategory = txtSpanishPromotionCategory.Text; }
                    if (string.IsNullOrEmpty(txtFrenchPromotionCategory.Text)) {
                        clsdbo_DimPromotion.FrenchPromotionCategory = null;
                    } else {
                        clsdbo_DimPromotion.FrenchPromotionCategory = txtFrenchPromotionCategory.Text; }
                    clsdbo_DimPromotion.StartDate = System.Convert.ToDateTime(txtStartDate.Text);
                    if (string.IsNullOrEmpty(txtEndDate.Text)) {
                        clsdbo_DimPromotion.EndDate = null;
                    } else {
                        clsdbo_DimPromotion.EndDate = System.Convert.ToDateTime(txtEndDate.Text); }
                    if (string.IsNullOrEmpty(txtMinQty.Text)) {
                        clsdbo_DimPromotion.MinQty = null;
                    } else {
                        clsdbo_DimPromotion.MinQty = System.Convert.ToInt32(txtMinQty.Text); }
                    if (string.IsNullOrEmpty(txtMaxQty.Text)) {
                        clsdbo_DimPromotion.MaxQty = null;
                    } else {
                        clsdbo_DimPromotion.MaxQty = System.Convert.ToInt32(txtMaxQty.Text); }
                    bool bSucess = false;
                    bSucess = dbo_DimPromotionDataClass.Update(oclsdbo_DimPromotion, clsdbo_DimPromotion);
                    if (bSucess == true) {
                        Session.Remove("dvdbo_DimPromotion");
                        grddbo_DimPromotion.EditIndex = -1;
                        LoadGriddbo_DimPromotion();
                    } else {
                        ec.ShowMessage(" Update failed. ", " Dbo. Dim Promotion ");
                    }
                }
            } catch {  
            }
        }

        private void DeleteRecord()
        {
            dbo_DimPromotionClass clsdbo_DimPromotion = new dbo_DimPromotionClass();
            Label lblPromotionKey = (Label)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("lblPromotionKey");
            clsdbo_DimPromotion.PromotionKey = System.Convert.ToInt32(lblPromotionKey.Text);
            clsdbo_DimPromotion = dbo_DimPromotionDataClass.Select_Record(clsdbo_DimPromotion);
            bool bSucess = false;
            bSucess = dbo_DimPromotionDataClass.Delete(clsdbo_DimPromotion);
            if (bSucess == true) {
                Session.Remove("dvdbo_DimPromotion");
                LoadGriddbo_DimPromotion();
            } else {
                ec.ShowMessage(" Delete failed. ", " Dbo. Dim Promotion ");
            }
        }

        private Boolean VerifyData()
        {
            TextBox txtPromotionKey = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtPromotionKey");
            TextBox txtPromotionAlternateKey = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtPromotionAlternateKey");
            TextBox txtEnglishPromotionName = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEnglishPromotionName");
            TextBox txtSpanishPromotionName = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSpanishPromotionName");
            TextBox txtFrenchPromotionName = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFrenchPromotionName");
            TextBox txtDiscountPct = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtDiscountPct");
            TextBox txtEnglishPromotionType = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEnglishPromotionType");
            TextBox txtSpanishPromotionType = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSpanishPromotionType");
            TextBox txtFrenchPromotionType = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFrenchPromotionType");
            TextBox txtEnglishPromotionCategory = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEnglishPromotionCategory");
            TextBox txtSpanishPromotionCategory = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtSpanishPromotionCategory");
            TextBox txtFrenchPromotionCategory = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtFrenchPromotionCategory");
            TextBox txtStartDate = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtStartDate");
            TextBox txtEndDate = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtEndDate");
            TextBox txtMinQty = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtMinQty");
            TextBox txtMaxQty = (TextBox)grddbo_DimPromotion.Rows[Convert.ToInt32(Session["Row"])].FindControl("txtMaxQty");

            
            return true;
        }

        private Boolean VerifyDataNew()
        {
            TextBox txtNewPromotionAlternateKey = (TextBox)grddbo_DimPromotion.FooterRow.FindControl("txtNewPromotionAlternateKey");
            TextBox txtNewEnglishPromotionName = (TextBox)grddbo_DimPromotion.FooterRow.FindControl("txtNewEnglishPromotionName");
            TextBox txtNewSpanishPromotionName = (TextBox)grddbo_DimPromotion.FooterRow.FindControl("txtNewSpanishPromotionName");
            TextBox txtNewFrenchPromotionName = (TextBox)grddbo_DimPromotion.FooterRow.FindControl("txtNewFrenchPromotionName");
            TextBox txtNewDiscountPct = (TextBox)grddbo_DimPromotion.FooterRow.FindControl("txtNewDiscountPct");
            TextBox txtNewEnglishPromotionType = (TextBox)grddbo_DimPromotion.FooterRow.FindControl("txtNewEnglishPromotionType");
            TextBox txtNewSpanishPromotionType = (TextBox)grddbo_DimPromotion.FooterRow.FindControl("txtNewSpanishPromotionType");
            TextBox txtNewFrenchPromotionType = (TextBox)grddbo_DimPromotion.FooterRow.FindControl("txtNewFrenchPromotionType");
            TextBox txtNewEnglishPromotionCategory = (TextBox)grddbo_DimPromotion.FooterRow.FindControl("txtNewEnglishPromotionCategory");
            TextBox txtNewSpanishPromotionCategory = (TextBox)grddbo_DimPromotion.FooterRow.FindControl("txtNewSpanishPromotionCategory");
            TextBox txtNewFrenchPromotionCategory = (TextBox)grddbo_DimPromotion.FooterRow.FindControl("txtNewFrenchPromotionCategory");
            TextBox txtNewStartDate = (TextBox)grddbo_DimPromotion.FooterRow.FindControl("txtNewStartDate");
            TextBox txtNewEndDate = (TextBox)grddbo_DimPromotion.FooterRow.FindControl("txtNewEndDate");
            TextBox txtNewMinQty = (TextBox)grddbo_DimPromotion.FooterRow.FindControl("txtNewMinQty");
            TextBox txtNewMaxQty = (TextBox)grddbo_DimPromotion.FooterRow.FindControl("txtNewMaxQty");

            
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
		    grddbo_DimPromotion.PageIndex = 0;
		    grddbo_DimPromotion.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimPromotion();
        }

        public void butShowAll_Click(object sender, System.EventArgs e)
        {
		    txtSearch.Text = null;
		    Session.Remove("dvdbo_DimPromotion");
		    LoadGriddbo_DimPromotion();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
		    	Session.Remove("dvdbo_DimPromotion");
			if ((Session["dvdbo_DimPromotion"] != null)) {
				dvdbo_DimPromotion = (DataView)Session["dvdbo_DimPromotion"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimPromotion = dbo_DimPromotionDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimPromotion"] = dvdbo_DimPromotion;
		    	}
                if (dvdbo_DimPromotion.Count > 0) {
                    grddbo_DimPromotion.DataSource = dvdbo_DimPromotion;
                    grddbo_DimPromotion.DataBind();
                }
                if (dvdbo_DimPromotion.Count == 0) {
                    DataTable dt = new DataTable();
                    dt.Rows.Add(dt.NewRow());
                    dt.Columns.Add("PromotionKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("PromotionAlternateKey", Type.GetType("System.Int32"));
                    dt.Columns.Add("EnglishPromotionName", Type.GetType("System.String"));
                    dt.Columns.Add("SpanishPromotionName", Type.GetType("System.String"));
                    dt.Columns.Add("FrenchPromotionName", Type.GetType("System.String"));
                    dt.Columns.Add("DiscountPct", Type.GetType("System.Decimal"));
                    dt.Columns.Add("EnglishPromotionType", Type.GetType("System.String"));
                    dt.Columns.Add("SpanishPromotionType", Type.GetType("System.String"));
                    dt.Columns.Add("FrenchPromotionType", Type.GetType("System.String"));
                    dt.Columns.Add("EnglishPromotionCategory", Type.GetType("System.String"));
                    dt.Columns.Add("SpanishPromotionCategory", Type.GetType("System.String"));
                    dt.Columns.Add("FrenchPromotionCategory", Type.GetType("System.String"));
                    dt.Columns.Add("StartDate", Type.GetType("System.DateTime"));
                    dt.Columns.Add("EndDate", Type.GetType("System.DateTime"));
                    dt.Columns.Add("MinQty", Type.GetType("System.Int32"));
                    dt.Columns.Add("MaxQty", Type.GetType("System.Int32"));
                    dvdbo_DimPromotion = dt.DefaultView;
                    Session["dvdbo_DimPromotion"] = dvdbo_DimPromotion;

                    grddbo_DimPromotion.DataSource = dvdbo_DimPromotion;
                    grddbo_DimPromotion.DataBind();

                    int TotalColumns = grddbo_DimPromotion.Rows[0].Cells.Count;
                    grddbo_DimPromotion.Rows[0].Cells.Clear();
                    grddbo_DimPromotion.Rows[0].Cells.Add(new TableCell());
                    grddbo_DimPromotion.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grddbo_DimPromotion.Rows[0].Cells[0].Text = "No Record Found";
                }
                dvdbo_DimPromotion.Sort = htmlHiddenSortExpression.Value;
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Promotion ");
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
                    { dt = dbo_DimPromotionDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimPromotionDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Promotion", "Many");
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
                    GVExport.DataSource = Session["dvdbo_DimPromotion"];
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
 

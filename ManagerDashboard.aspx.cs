using OrderManagementApp.App_Code;
using System;
using System.Drawing;
using System.IO;

namespace OrderManagementApp
{
    public partial class ManagerDashboard : System.Web.UI.Page
    {
        FoodDAL dal = new FoodDAL();
        InventoryDAL inventoryDal = new InventoryDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (Session["Role"] == null || Session["Role"].ToString() != "Manager")
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadMainCategories();
            }
        }

        private void LoadMainCategories()
        {
            ddlMainCategory.DataSource = dal.GetMainCategories();
            ddlMainCategory.DataTextField = "CategoryName";
            ddlMainCategory.DataValueField = "MainCategoryID";
            ddlMainCategory.DataBind();
        }

        protected void btnAddMain_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMainCategory.Text))
            {
                dal.AddMainCategory(txtMainCategory.Text.Trim());
                txtMainCategory.Text = "";
                lblMessage.Text = "Main Category Added Successfully!";
                LoadMainCategories();
            }
        }

        protected void btnAddSub_Click(object sender, EventArgs e)
        {
            int mainID = Convert.ToInt32(ddlMainCategory.SelectedValue);
            string subName = txtSubCategory.Text.Trim();
            decimal price = Convert.ToDecimal(txtPrice.Text);

            dal.AddSubCategory(mainID, subName, price);

            txtSubCategory.Text = "";
            txtPrice.Text = "";

            lblMessage.Text = "Sub Category Added Successfully!";
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (!fileUploadExcel.HasFile)
            {
                lblMessage.Text = "Please select an Excel file.";
                return;
            }

            string fileName = Path.GetFileName(fileUploadExcel.FileName);

            InventoryDAL inventoryDal = new InventoryDAL();
            inventoryDal.UploadInventoryFromExcel(fileUploadExcel.FileContent, fileName);

            lblMessage.Text = "Inventory uploaded successfully!";
        }


    }
}
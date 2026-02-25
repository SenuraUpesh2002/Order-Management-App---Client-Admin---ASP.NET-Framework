using OrderManagementApp.App_Code;
using System;
using System.Web.UI;

namespace OrderManagementApp
{
    public partial class FoodOrder : Page
    {
        private FoodDAL dal = new FoodDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            //  Check login session
            if (Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadMainCategories();
            }
        }

     
        // Load Main Categories
     
        private void LoadMainCategories()
        {
            ddlMainCategory.DataSource = dal.GetMainCategories();
            ddlMainCategory.DataTextField = "CategoryName";
            ddlMainCategory.DataValueField = "MainCategoryID";
            ddlMainCategory.DataBind();

            ddlMainCategory.Items.Insert(0, "-- Select Main Category --");
        }

    
        // Load Sub Categories

        protected void ddlMainCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSubCategory.Items.Clear();
            ddlSubCategory.Items.Insert(0, "-- Select Sub Category --");

            txtPrice.Text = "";
            txtQuantity.Text = "";
            txtTotal.Text = "";

            if (ddlMainCategory.SelectedIndex > 0)
            {
                int mainID = Convert.ToInt32(ddlMainCategory.SelectedValue);

                ddlSubCategory.DataSource = dal.GetSubCategories(mainID);
                ddlSubCategory.DataTextField = "SubCategoryName";
                ddlSubCategory.DataValueField = "SubCategoryID";
                ddlSubCategory.DataBind();

                ddlSubCategory.Items.Insert(0, "-- Select Sub Category --");
            }
        }

   
        // Load Price
   
        protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPrice.Text = "";
            txtTotal.Text = "";

            if (ddlSubCategory.SelectedIndex > 0)
            {
                int subID = Convert.ToInt32(ddlSubCategory.SelectedValue);

                decimal price = dal.GetPrice(subID);
                txtPrice.Text = price.ToString("0.00");

                CalculateTotal();
            }
        }


        // Quantity Changed
       
        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

   
        // Calculate Total
  
        private void CalculateTotal()
        {
            if (decimal.TryParse(txtPrice.Text, out decimal price) &&
                int.TryParse(txtQuantity.Text, out int quantity) &&
                quantity > 0)
            {
                txtTotal.Text = (price * quantity).ToString("0.00");
            }
            else
            {
                txtTotal.Text = "";
            }
        }

  
        // Confirm Order

        protected void btnConfirmOrder_Click(object sender, EventArgs e)
        {
            // Validate dropdown selections
            if (ddlMainCategory.SelectedIndex == 0 ||
                ddlSubCategory.SelectedIndex == 0)
            {
                return;
            }

            // Validate quantity
            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                return;
            }

            // Validate price
            if (!decimal.TryParse(txtPrice.Text, out decimal itemPrice))
            {
                return;
            }

            // Validate total
            if (!decimal.TryParse(txtTotal.Text, out decimal totalAmount))
            {
                return;
            }

            int userID = Convert.ToInt32(Session["UserID"]);
            int subCategoryID = Convert.ToInt32(ddlSubCategory.SelectedValue);

            // Now passing itemPrice also
            int orderID = dal.PlaceOrder(userID, subCategoryID, quantity, totalAmount, itemPrice);

            if (orderID > 0)
            {
                Response.Redirect("MyOrders.aspx");
            }
        }
    }
}
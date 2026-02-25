using OrderManagementApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrderManagementApp
{
    public partial class Test : System.Web.UI.Page
    {
        private object txtFullName;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            LoginDAL dal = new LoginDAL();
            User user = dal.ValidateUser(txtEmail.Text, txtPassword.Text);

            if (user != null)
            {
                Session["UserID"] = user.UserID;
                Session["Role"] = user.Role;
                Session["Email"] = txtEmail.Text.ToString();
                

                if (user.Role == "Manager")
                {
                    Response.Redirect("ManagerDashboard.aspx");
                }
                else
                {
                    Response.Redirect("CustomerDashboard.aspx");
                }
            }
            else
            {
                lblMessage.Text = "Invalid Email or Password!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}